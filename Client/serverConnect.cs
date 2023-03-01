using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SNUBclientFinalProject
{
    internal class serverConnect
    {
        public static string getValue(string path, string key)
        {
            // Method to retreive any specific json key from the server
            string url = $"https://snub.kitsunehosting.net{path}";

            string json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(url);
            }

            JObject arr = JObject.Parse(json);

            return (string)arr[key];
        }
    }
}
