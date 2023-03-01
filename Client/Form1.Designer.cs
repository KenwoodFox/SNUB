namespace SNUBclientFinalProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            connLabel = new Label();
            connectButton = new Button();
            SuspendLayout();
            // 
            // connLabel
            // 
            connLabel.AutoSize = true;
            connLabel.Location = new Point(12, 38);
            connLabel.Name = "connLabel";
            connLabel.Size = new Size(88, 15);
            connLabel.TabIndex = 0;
            connLabel.Text = "No Connection";
            connLabel.Click += label1_Click;
            // 
            // connectButton
            // 
            connectButton.Location = new Point(12, 12);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(75, 23);
            connectButton.TabIndex = 1;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(connectButton);
            Controls.Add(connLabel);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label connLabel;
        private Button connectButton;
    }
}