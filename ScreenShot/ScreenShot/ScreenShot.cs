using System;
using System.Web.Script.Serialization;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ScreenShot
{
    class ScreenShot
    {
        /// <summary>
        /// Server URL and local PATH
        /// </summary>
        private string URL;
        private string PATH;

        /// <summary>
        /// Sets the basic preferences
        /// </summary>
        /// <param name="url">Server URL</param>
        /// <param name="port">Server port</param>
        /// <param name="path">Local path</param>
        public ScreenShot(string url, string port, string path)
        {
            URL = "http://" + url + ":" + port + "/upload";
            PATH = path;
        }

        /// <summary>
        /// Parses JSON
        /// </summary>
        /// <param name="response">JSON</param>
        /// <param name="type">ResponseType</param>
        /// <returns>Single value from parsed string</returns>
        public string ParseAnswer(string response)
        {
                if (response == null)
                {
                    return "No data availible";
                }
                try
                {
                    var json = new JavaScriptSerializer();
                    var data = json.Deserialize<Dictionary<string, string>>(response); // Parsing JSON-response into a Dictionary
                    return data["filename"]; // Value of "filename"
                }
                catch
                {
                MessageBox.Show("Something went wrong while parsing JSON answer", "Error", MessageBoxButtons.OK, MessageBoxIcon.None,
                    MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);  // MB_TOPMOST
                return "No data availible";
                }
        }

        /// <summary>
        /// Gets answer from the server
        /// </summary>
        /// <returns>Server answer as string or null</returns>
        public async Task<string> GetImageDataFromServer()
        {
            try
            {
                var path = new DirectoryInfo(PATH);
                CheckDirectory(path); // Creating the directory if needed
                using (Bitmap bitmap = CaptureScreen(new Point(Cursor.Position.X, Cursor.Position.Y))) // Making a screenshot
                {
                    Save(bitmap, path); // Saving screenshot at %TEMP%\ScreenShotTool
                    if (VersionControl.VersionUpToDate(URL))
                        return ParseAnswer(await Send(bitmap, URL)); // Sending POST with image and parsing the JSON response
                    else
                        return null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("This is what went wrong: " + e.Message + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.None,
                        MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);  // MB_TOPMOST
                return null;
            }
        }

        /// <summary>
        /// Captures the screen
        /// </summary>
        /// <param name="mousePosition">Mouse Position</param>
        /// <param name="bitmap">Image</param>
        /// <returns>Captured screen image</returns>
        private Bitmap CaptureScreen(Point mousePosition)
        {
            Rectangle bounds = Screen.GetBounds(mousePosition); // Size of the screen where coursor located
            var bitmap = new Bitmap(bounds.Width, bounds.Height); // Image itself
            using (Graphics gr = Graphics.FromImage(bitmap))
            {
                gr.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size); // Taking a screenshot
            }
            return bitmap;
        }

        /// <summary>
        /// Saves the bitmap at path as .PNG
        /// </summary>
        /// <param name="bitmap">Bitmap image</param>
        /// <param name="path">DirectoryInfo path</param>
        private void Save(Bitmap bitmap, DirectoryInfo path)
        {
            bitmap.Save(GenerateName(path), ImageFormat.Png);
        }

        /// <summary>
        /// Generates name of the image
        /// </summary>
        /// <param name="path">Directory</param>
        /// <returns>Returns image name</returns>
        private string GenerateName(DirectoryInfo path)
        {
            try
            {
                return path.FullName + "\\" + (path.GetFiles().Count() + 1) + ".png"; // Filename here is actually it's number in directory
            }
            catch (OverflowException)
            {
                MessageBox.Show("Too many files. This one will be named 0.png", "Error", MessageBoxButtons.OK, MessageBoxIcon.None,
                        MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);  // MB_TOPMOST
                // If to many files -> name file "0.png"
                return path.FullName + "\\" + 0 + ".png";
            }
        }

        /// <summary>
        /// Checks the existance of the path
        /// If the path doesn't exist, creates one
        /// </summary>
        /// <param name="path">The path to check</param>
        private void CheckDirectory(DirectoryInfo path)
        {
                if (!path.Exists)
                    path.Create();
        }

        /// <summary>
        /// Converts bitmap to byte[]
        /// </summary>
        /// <param name="bitmap">Image itself</param>
        /// <returns>Bitmap as byte[]</returns>
        private byte[] ToByte(Bitmap bitmap)
        {
            var converter = new ImageConverter();
            return (byte[])converter.ConvertTo(bitmap, typeof(byte[]));
        }

        /// <summary>
        /// Sends an image to server and gets response
        /// </summary>
        /// <param name="bitmap">Image itself</param>
        /// <param name="url">Server address</param>
        /// <returns>Server response as string</returns>
        private async Task<string> Send(Bitmap bitmap, string url)
        {
            using (var requestContent = new MultipartFormDataContent()) 
            {
                using (var imageContent = new ByteArrayContent(ToByte(bitmap)))
                {
                    imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/png");
                    requestContent.Add(imageContent, "up_image", "image.png");
                    using (var client = new HttpClient())
                    {
                        HttpResponseMessage response = await client.PostAsync(url, requestContent);
                        return await response.Content.ReadAsStringAsync(); // Wait for content to be read and return it as string
                    }
                }
            }
        }
    }
}
