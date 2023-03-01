using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SNUBclientFinalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string getValue(string path, string key)
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

        

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStipConLabel.Text = $"Connected to server version {getValue("/cmds/version", "version")}";
        }
    }
}