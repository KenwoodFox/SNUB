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
    // Watched a youtube tutorial 0 warnings now
    // had to change a bit to fix one of the errors
    // because said to use HTTP instead of webclient warning


    internal class serverConnect
    {
        HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            serverConnect serverConnect = new serverConnect();
            await serverConnect.GetTodoItems();
        }
        private async Task GetTodoItems()
        {
            string response = await client.GetStringAsync(
                "https://snub.kitsunehosting.net");
        }

    }
}
/* OLD CODE
 * using System;
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

        public static List<string> getValues(string path)
        {
            // Method to retreive any specific json key from the server
            string url = $"https://snub.kitsunehosting.net{path}";

            string json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(url);
            }

            JArray arr = JArray.Parse(json);

            List<string> req = arr.ToObject<List<string>>();


            return req;
        }
    }
}

 */


