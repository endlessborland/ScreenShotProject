using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ScreenShot
{
    public class VersionControl
    {

        /// <summary>
        /// Checks the version number
        /// </summary>
        /// <param name="url">Server url</param>
        /// <returns>Is the client up-to-date</returns>
        static public bool VersionUpToDate(string url)
        {
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major.ToString();
            string response = null;
            if (InetrnetAvailible() && (response = ParseAnwer(ServerVersion(url))) == version)
                return true;
            else
            {
                if (response != null)
                    MessageBox.Show("The client if outdated. Please upgrade");
                return false;
            }
        }

        /// <summary>
        /// Checks the internet status
        /// </summary>
        /// <returns>Connection Status - true or false</returns>
        static private bool InetrnetAvailible()
        {
            try
            {
                IPHostEntry entry = Dns.GetHostEntry("dns.msftncsi.com");
                if (entry.AddressList.Length == 0)
                {
                    return false;
                }
                else
                {
                    if (!entry.AddressList[0].ToString().Equals("131.107.255.255"))
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
            var request = (HttpWebRequest)HttpWebRequest.Create("http://www.msftncsi.com/ncsi.txt");
            try
            {
                var responce = (HttpWebResponse)request.GetResponse();
                if (responce.StatusCode != HttpStatusCode.OK)
                {
                    return false;
                }
                using (var sr = new StreamReader(responce.GetResponseStream()))
                {
                    if (sr.ReadToEnd().Equals("Microsoft NCSI"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// Gets the server /info
        /// </summary>
        /// <param name="url">Server url</param>
        /// <returns>JSON info</returns>
        static private string ServerVersion(string url)
        {
            try
            {
                var request = WebRequest.Create(url.Replace("upload", "info"));
                request.Timeout = 5000;
                var stream = request.GetResponse().GetResponseStream(); // This one isn't async!
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
        /// Parses JSON answer
        /// </summary>
        /// <param name="response">JSON info</param>
        /// <returns>Version number</returns>
        static private string ParseAnwer(string response)
        {
            try
            {
                var json = new JavaScriptSerializer(); // Parsing JSON-response into a Dictionary
                var data = json.Deserialize<Dictionary<string, string>>(response);
                return data["version"]; // Value of "version"
            }
            catch
            {
                MessageBox.Show("Server is most likely offline");
                return null;
            }
        }
    }
}
