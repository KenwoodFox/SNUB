using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;

namespace SNUBclientFinalProject
{
    internal class serverCommunicationMethods
    {
        //Method used to retrieve the server version.
        //Method used to verify connection to the server.

        public static string getServerVersion(string path, string key)
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
        
        //Method used to retrive list of classes form the server.
        public static List<string> getClassList(string path)
        {
            // Method to retreive any specific json key from the server
            string url = $"https://snub.kitsunehosting.net{path}";

            string json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(url);
            }

            JArray arr = JArray.Parse(json);


            List<string>req = arr.ToObject<List<string>>();


            return req;
        }

        //Method used to retrieve list of lists from server
        //of the format: {[Date, Author, Note], [Date, Author, Note]...}
        public static List<List<string>> getClassNotes(string path)
        {
            // Method to retreive any specific json key from the server
            string url = $"https://snub.kitsunehosting.net{path}";

            string json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(url);
            }

            JArray arr = JArray.Parse(json);


            List<List<string>> req = arr.ToObject<List<List<string>>>();


            return req;
        }
    }
}
