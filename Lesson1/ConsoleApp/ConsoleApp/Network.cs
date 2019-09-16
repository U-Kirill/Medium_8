using System;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace ConsoleApp
{
    class Network
    {
        public static async void SendRequestAsync(string url, Callback callback)
        {
            await Task.Run(() => {
                WebResponse response = GetResponse(url);

                Console.WriteLine("Request recived with status: " + ((HttpWebResponse)response).StatusDescription + " and contetn type: " + response.ContentType);

                string responseText = ReadResponse(response);

                if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK && response.ContentType.Contains("html"))
                    callback(responseText);

                response.Close();
            });
        }

        private static WebResponse GetResponse(string url)
        {
            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            return webRequest.GetResponse();
        }

        private static string ReadResponse(WebResponse response)
        {
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream);
                return reader.ReadToEnd();
            }
        }
    }
    
}
