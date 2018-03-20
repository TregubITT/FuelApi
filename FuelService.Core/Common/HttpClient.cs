using System.IO;
using System.Net;

namespace FuelService.Core.Common
{
    public class HttpClient : IHttpClient
    {
        public string GetResponceFromApi(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
