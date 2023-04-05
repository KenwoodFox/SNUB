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
            if (serverCommunicationMethods.getServerVersion("/cmds/version", "version") != null)
            {
                //Show connection status and version to user and change color of connection button.
                connectToolStripMenuItem.Text = "Connected";
                connectToolStripMenuItem.BackColor = Color.Green;
                toolStripConLabel.Text = $"Version: {serverCommunicationMethods.getServerVersion("/cmds/version", "version")}";

                //initiate class list and class list combo box
                classList = new List<string>(serverCommunicationMethods.getClassList("/cmds/classes"));
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

        /*
        Displays selectable class note items in the listbox in the format
        Data - Author
         */
        private void classToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            uploadAndDisplayNoteMethods retrieve = new uploadAndDisplayNoteMethods();
            List<List<string>> contentList = retrieve.retrieveNotes(classListComboBox.Text);
            for (int i = 0; i < contentList.Count; i++)
            {

                listBox1.Items.Add(contentList[i][0] + "-" + contentList[i][2]);

            }

        }

        /*
        Initiating "add button" uploads text from the author text box and note text box to the server.
        First checks that the user has added content to each text box.
        if either textbox contains null values the user is notified of the error.
         */
        
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            uploadAndDisplayNoteMethods upload = new uploadAndDisplayNoteMethods();
            if (txtNote.Text != "" && txtAuthor.Text != "")
            {
                upload.uploadNotes(txtNote.Text, txtAuthor.Text, classListComboBox.Text);
                txtNote.Clear();
                txtNote.Focus();
                uploadAndDisplayNoteMethods retrieve = new uploadAndDisplayNoteMethods();
                List<List<string>> contentList = retrieve.retrieveNotes(classListComboBox.Text);
                
            }
            else { MessageBox.Show("Cannot Upload Null Value"); }
        }
        
        /*
        Populate display note text box with selected index of list box
         */
        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<List<string>> classNotes = new List<List<string>>(serverCommunicationMethods.getClassNotes($"/cmds/class_notes?class={classListComboBox.Text}"));
            txtDisplayNote.Text =classNotes[listBox1.SelectedIndex][3];
        }

        // Exit Program
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Clear User Entered Note
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNote.Clear();
            txtNote.Focus();
        }

        //Refresh List box
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            uploadAndDisplayNoteMethods retrieve = new uploadAndDisplayNoteMethods();
            List<List<string>> contentList = retrieve.retrieveNotes(classListComboBox.Text);
            for (int i = 0; i < contentList.Count; i++)
            {

                listBox1.Items.Add(contentList[i][0] + "-" + contentList[i][2]);

            }
        }
    }
}