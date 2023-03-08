using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Serialization;

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
            if (serverConnect.getValue("/cmds/version", "version") != null) { toolStipConLabel.Text = "Connected"; }

            //toolStipConLabel.Text = $"Connected to server version {serverConnect.getValue("/cmds/version", "version")}";
        }

        private void classToolStripMenuItem_Click(object sender, EventArgs e)
        {
            classListComboBox.Items.Clear();

            List <string> classList = new List <string>(serverConnect.getValues("/cmds/classes"));
            for (int i = 0; i < classList.Count; i++)
            {


                classListComboBox.Items.Add(classList[i]);
            }



        }
    }
}