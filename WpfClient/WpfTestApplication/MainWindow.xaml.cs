﻿using SNUBclientFinalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTestApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            /*
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
            */
        }
    }
}
