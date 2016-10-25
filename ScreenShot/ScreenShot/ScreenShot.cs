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
using System.Net;

namespace ScreenShot
{
    class ScreenShot
    {
        /// <summary>
        /// Simplification for checking internet access
        /// </summary>
        public enum ConnectionStatus
        {
            NotConnected = 0,
            Connected = 1
        }

        /// <summary>
        /// Simplification for parsing JSON strings
        /// </summary>
        public enum ResponseType
        {
            Image = 0,
            Info = 1
        }

        /// <summary>
        /// Server URL
        /// </summary>
        private string URL;

        /// <summary>
        /// Sets the URL for the server
        /// </summary>
        /// <param name="URL">Server URL</param>
        public ScreenShot(string url)
        {
            URL = url;
        }

        /// <summary>
        /// Parses JSON
        /// </summary>
        /// <param name="response">JSON</param>
        /// <param name="type">ResponseType</param>
        /// <returns>Single value from parsed string</returns>
        public string ParseAnswer(string response, ResponseType type)
        {
            if (type == ResponseType.Image) // Response when image is uploaded
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
                    MessageBox.Show("Something went wrong");
                    return "No data availible";
                }
            }
            else // Response when info is requested
            {
                if (response == null)
                {
                    return "Server if offline";
                }
                try
                {
                    var json = new JavaScriptSerializer(); // Parsing JSON-response into a Dictionary
                    var data = json.Deserialize<Dictionary<string, string>>(response);
                    return data["version"]; // Value of "version"
                }
                catch
                {
                    MessageBox.Show("Server is most likely offline");
                    return "Server if offline";
                }
            }
        }

        /// <summary>
        /// Gets answer from the server
        /// </summary>
        /// <returns>Server answer as string or "No connection"</returns>
        public async Task<string> GetImageDataFromServer()
        {
            try
            {
                var path = new DirectoryInfo(Environment.GetEnvironmentVariable("TEMP") + "\\ScreenShotTool"); // A path at %TEMP%\ScreenShotTool
                CheckDirectory(path); // Creating the directory if needed
                using (Bitmap bitmap = CaptureScreen(new Point(Cursor.Position.X, Cursor.Position.Y))) // Making a screenshot
                {
                    Save(bitmap, path); // Saving screenshot at %TEMP%\ScreenShotTool
                    if (CheckInternet() == ConnectionStatus.NotConnected)
                    {
                        MessageBox.Show("Sorry, but the internet doesn't work");
                        return "No connection";
                    }
                    if (ParseAnswer(ServerInfo(URL), ResponseType.Info) == null || ParseAnswer(ServerInfo(URL), ResponseType.Info) == "Server if offline")
                    {
                        MessageBox.Show("Sorry, but the server if offline");
                        return "No connection";
                    }
                    return ParseAnswer(await Send(bitmap, URL), ResponseType.Image); // Sending POST with image and parsing the JSON response
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("This is what went wrong: " + e.Message + e.ToString());
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
                MessageBox.Show("Too many files. This one will be named 0.png"); // If to many files -> name file "0.png"
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
        
        /// <summary>
        /// Gets server info
        /// </summary>
        /// <param name="url">Server url</param>
        /// <returns>JSON answer</returns>
        public string ServerInfo(string url)
        {
            try
            {
                var request = WebRequest.Create(url.Replace("upload", "info"));
                request.Timeout = 1000;
                var stream = request.GetResponse().GetResponseStream();
                var sr = new StreamReader(stream);
                string value = sr.ReadToEnd();
                sr.Close();
                return value;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Chtcks the internet connection
        /// </summary>
        /// <returns>ConnectionStatus</returns>
        private ConnectionStatus CheckInternet()
        {
            try
            {
                IPHostEntry entry = Dns.GetHostEntry("dns.msftncsi.com");
                if (entry.AddressList.Length == 0)
                {
                    return ConnectionStatus.NotConnected;
                }
                else
                {
                    if (!entry.AddressList[0].ToString().Equals("131.107.255.255"))
                    {
                        return ConnectionStatus.NotConnected;
                    }
                }
            }
            catch
            {
                return ConnectionStatus.NotConnected;
            }
            var request = (HttpWebRequest)HttpWebRequest.Create("http://www.msftncsi.com/ncsi.txt");
            try
            {
                var responce = (HttpWebResponse)request.GetResponse();
                if (responce.StatusCode != HttpStatusCode.OK)
                {
                    return ConnectionStatus.NotConnected;
                }
                using (var sr = new StreamReader(responce.GetResponseStream()))
                {
                    if (sr.ReadToEnd().Equals("Microsoft NCSI"))
                    {
                        return ConnectionStatus.Connected;
                    }
                    else
                    {
                        return ConnectionStatus.NotConnected;
                    }
                }
            }
            catch
            {
                return ConnectionStatus.NotConnected;
            }
        }
    }
}
