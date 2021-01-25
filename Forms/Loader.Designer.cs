namespace AnnouncementHelper.Forms
{
    partial class Loader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loader));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.usernameInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordInput = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.loginBox = new System.Windows.Forms.GroupBox();
            this.loginManual = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.codeInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radiopanel = new System.Windows.Forms.Panel();
            this.loginBox.SuspendLayout();
            this.loginManual.SuspendLayout();
            this.radiopanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 297);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(371, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(383, 291);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // usernameInput
            // 
            this.usernameInput.Location = new System.Drawing.Point(13, 52);
            this.usernameInput.Name = "usernameInput";
            this.usernameInput.Size = new System.Drawing.Size(153, 20);
            this.usernameInput.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Username for iee.ihu.gr:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password:";
            // 
            // passwordInput
            // 
            this.passwordInput.Location = new System.Drawing.Point(13, 103);
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.Size = new System.Drawing.Size(153, 20);
            this.passwordInput.TabIndex = 6;
            this.passwordInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordInput_KeyDown);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 130);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Login";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // loginBox
            // 
            this.loginBox.Controls.Add(this.label1);
            this.loginBox.Controls.Add(this.button2);
            this.loginBox.Controls.Add(this.usernameInput);
            this.loginBox.Controls.Add(this.passwordInput);
            this.loginBox.Controls.Add(this.label2);
            this.loginBox.Enabled = false;
            this.loginBox.Location = new System.Drawing.Point(389, 12);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(181, 172);
            this.loginBox.TabIndex = 8;
            this.loginBox.TabStop = false;
            this.loginBox.Text = "Login form";
            // 
            // loginManual
            // 
            this.loginManual.Controls.Add(this.button1);
            this.loginManual.Controls.Add(this.codeInput);
            this.loginManual.Controls.Add(this.label4);
            this.loginManual.Controls.Add(this.button3);
            this.loginManual.Enabled = false;
            this.loginManual.Location = new System.Drawing.Point(389, 12);
            this.loginManual.Name = "loginManual";
            this.loginManual.Size = new System.Drawing.Size(183, 171);
            this.loginManual.TabIndex = 14;
            this.loginManual.TabStop = false;
            this.loginManual.Text = "Manual login";
            this.loginManual.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Open authorization page";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // codeInput
            // 
            this.codeInput.Location = new System.Drawing.Point(41, 72);
            this.codeInput.Name = "codeInput";
            this.codeInput.Size = new System.Drawing.Size(101, 20);
            this.codeInput.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Code:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(57, 99);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(70, 20);
            this.button3.TabIndex = 13;
            this.button3.Text = "Submit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(389, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 78);
            this.label3.TabIndex = 9;
            this.label3.Text = "Your credenitials are not stored and \r\nare only used to connect to the api.\r\nHowe" +
    "ver, you have the choice of\r\nconnecting yourself by switching \r\nto manual login." +
    "\r\n\r\n";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(2, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(76, 17);
            this.radioButton1.TabIndex = 15;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Silent login";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(84, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(85, 17);
            this.radioButton2.TabIndex = 16;
            this.radioButton2.Text = "Manual login";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radiopanel
            // 
            this.radiopanel.Controls.Add(this.radioButton1);
            this.radiopanel.Controls.Add(this.radioButton2);
            this.radiopanel.Enabled = false;
            this.radiopanel.Location = new System.Drawing.Point(387, 256);
            this.radiopanel.Name = "radiopanel";
            this.radiopanel.Size = new System.Drawing.Size(183, 22);
            this.radiopanel.TabIndex = 17;
            // 
            // Loader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 332);
            this.Controls.Add(this.radiopanel);
            this.Controls.Add(this.loginManual);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.loginBox);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.progressBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Loader";
            this.Text = "Loader";
            this.Load += new System.EventHandler(this.Loader_Load);
            this.loginBox.ResumeLayout(false);
            this.loginBox.PerformLayout();
            this.loginManual.ResumeLayout(false);
            this.loginManual.PerformLayout();
            this.radiopanel.ResumeLayout(false);
            this.radiopanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox usernameInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordInput;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox loginBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox codeInput;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox loginManual;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Panel radiopanel;
        private System.Windows.Forms.Button button1;
    }
}