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

namespace Screenshot_project
{
    /// <summary>
    /// Этот класс используется для создания снимка экрана
    /// </summary>
    class ScreenShot
    {

        private DirectoryInfo path; //Файл находится по адресу, "path\..."
        private string filename; //Полное имя файла, "path\filename.png"
        private Bitmap bitmap; //Само изображение
        private Point MousePosition; //Позиция мыши (на момент снимка экрана)
        private Rectangle bounds; //Размер экрана
        private string URL;

        /// <summary>
        /// Конструктор класса
        /// Получает положение курсора мыши, чтобы определить, какой экран снимать
        /// Определяет размер этого экрана
        /// Генерирует полное имя файла, в который сохраняется снимок экрана
        /// </summary>
        public ScreenShot(string url)
        {
            MousePosition = new Point(Cursor.Position.X, Cursor.Position.Y); //позиция курсора мыши
            bounds = Screen.GetBounds(MousePosition); //размер экрана
            bitmap = new Bitmap(bounds.Width, bounds.Height); //создание пустого изображения
            path = new DirectoryInfo(Environment.GetEnvironmentVariable("TEMP") + "\\ScreenShotTool"); //генерация пути
            URL = url;
            Create_directory(); //проверка существования пути
            Generate_Name(); //генерация имени файла
        }
        /// <summary>
        /// Метод делает снимок экрана
        /// </summary>
        public void CaptureScreen()
        {
            using (Graphics gr = Graphics.FromImage(bitmap))
            {
                gr.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            }
            Send();
            Save();
        }
        /// <summary>
        /// Метод, очевидно, сохраняет файл в "%TEMP%\filename.png"
        /// </summary>
        private void Save()
        {
            bitmap.Save(filename, ImageFormat.Png);
        }
        /// <summary>
        /// Метод проверяет существование пути, и, если путь не существует, создает его
        /// </summary>
        private void Create_directory()
        {
            if (!path.Exists)
                path.Create();
        }
        /// <summary>
        /// Метод генерирует имя файла, фактически, имя файла - его порядковый номер в папке
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

        private async void Send()
        {
            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(URL);
            MultipartFormDataContent form = new MultipartFormDataContent();
            HttpContent content = new StringContent("up_image");
            form.Add(content, "up_image");
            //var stream = await file.OpenStreamForReadAsync();
            var stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Png);
            content = new StreamContent(stream);
            MessageBox.Show(stream.Length.ToString());
            content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "up_image",
                FileName = filename,
            };
            form.Add(content);
            //var response = await client.PostAsync("upload.php", form);
            var response = await client.PostAsync(URL, form);
        }
    }
}
