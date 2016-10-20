using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Screenshot_project
{
    /// <summary>
    /// This class is used to create screen shots
    /// </summary>
    class ScreenShot
    {

        private DirectoryInfo path; //File path is, "path\..."
        private string filename; //Full filename, "path\filename.png"
        private Bitmap bitmap; //The image itself
        private Point MousePosition; //Pointer position (at the moment of screen shot)
        private Rectangle bounds; //Screen bounds
        private string URL;

        /// <summary>
        /// Class constructor:
        /// * Gets pointer position to determine which screen should we save
        /// * Gets screen's bounds
        /// * Generates full file name for the screen shot
        /// </summary>
        public ScreenShot(string url)
        {
            MousePosition = new Point(Cursor.Position.X, Cursor.Position.Y); //позиция курсора мыши
            bounds = Screen.GetBounds(MousePosition); //размер экрана
            bitmap = new Bitmap(bounds.Width, bounds.Height); //создание пустого изображения
            path = new DirectoryInfo(Environment.GetEnvironmentVariable("TEMP") + "\\ScreenShotTool"); //генерация пути
            URL = url;
            Create_directory(); //check if path exists
            Generate_Name(); //filename generation
        }
        /// <summary>
        /// This method captures a screenshot
        /// </summary>
        public async void CaptureScreen()
        {
            using (Graphics gr = Graphics.FromImage(bitmap))
            {
                gr.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            }
            string jsonresponse = await Send(); //JSON string server send us... TODO: parse JSON for further use
            Save();
        }
        /// <summary>
        /// This method, obviously, saves image to "%TEMP%\filename.png"
        /// </summary>
        private void Save()
        {
            bitmap.Save(filename, ImageFormat.Png);
        }
        /// <summary>
        /// This method checks if path exists, and if it does not, creates it 
        /// </summary>
        private void Create_directory()
        {
            if (!path.Exists)
                path.Create();
        }
        /// <summary>
        /// Method generates file name, in fact, file name is its number in dir
        /// </summary>
        private void Generate_Name()
        {
            filename = path.FullName + "\\" + (path.GetFiles().Count() + 1) + ".png";
        }

        private byte[] BitmapToByte()
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(bitmap, typeof(byte[]));
        }

        public async Task<string> Send()
        {
            var requestContent = new MultipartFormDataContent();
            var imageContent = new ByteArrayContent(BitmapToByte());
            imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/png");
            requestContent.Add(imageContent, "up_image", "image.png");
            var client = new HttpClient();
           // MessageBox.Show(requestContent.Headers.ToString());

            HttpResponseMessage response = await client.PostAsync(URL, requestContent);
            return await response.Content.ReadAsStringAsync(); //wait for content to be read and return it as string
        }
        }
    }

