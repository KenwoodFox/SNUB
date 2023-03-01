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

        

        

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStipConLabel.Text = $"Connected to server version {serverConnect.getValue("/cmds/version", "version")}";
        }
    }
}