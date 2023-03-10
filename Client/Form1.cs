using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Serialization;
using System.Net.Http.Json;
using System.CodeDom.Compiler;
using System.Diagnostics;

namespace SNUBclientFinalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Initialize class list.
        List<string> classList = new List<string>();


        /*
        Connect button on tool strip menu prompts connecection to the server
        If server returns value user is shown the connection status and server version
        Class list is populated from server upon connection
        */
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serverConnect.getValue("/cmds/version", "version") != null)
            {
                //Show connection status and version to user and change color of connection button.
                connectToolStripMenuItem.Text = "Connected";
                connectToolStripMenuItem.BackColor = Color.Green;
                toolStripConLabel.Text = $"Version: {serverConnect.getValue("/cmds/version", "version")}";

                //initiate class list and class list combo box
                classList = new List<string>(serverConnect.getValues("/cmds/classes"));
                classListComboBox.Items.Clear();

                for (int i = 0; i < classList.Count; i++)
                {

                    classListComboBox.Items.Add(classList[i]);
                }
            }
            else
            {
                toolStripConLabel.BackColor = Color.Red;
                toolStripConLabel.Text = "No Connection";
                connectToolStripMenuItem.Text = "No Connection";
            }

            
        }

        private void classToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                classNotes(classListComboBox.Text);
            
        }


        //Pass the selected class from combo list to the class notes server and populate list box
        private void classNotes(string classSelection)
        {
            listBox1.Items.Clear();
            List<string> classNotes = new List<string>(serverConnect.getValues($"/cmds/class_notes?class={classSelection}"));
            
            for(int i = 0; i < classNotes.Count; i++)
            {
                listBox1.Items.Add(classNotes[i]);
            }
            
            
        }
    }
}