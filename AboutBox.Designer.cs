namespace AnnouncementHelper.Forms
{
    partial class AboutBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DeveloperLink = new System.Windows.Forms.LinkLabel();
            this.ITApiLink = new System.Windows.Forms.LinkLabel();
            this.Description = new System.Windows.Forms.Label();
            this.AppName = new System.Windows.Forms.GroupBox();
            this.CloseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.AppName.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 119);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // DeveloperLink
            // 
            this.DeveloperLink.AutoSize = true;
            this.DeveloperLink.Location = new System.Drawing.Point(212, 19);
            this.DeveloperLink.Name = "DeveloperLink";
            this.DeveloperLink.Size = new System.Drawing.Size(144, 13);
            this.DeveloperLink.TabIndex = 2;
            this.DeveloperLink.TabStop = true;
            this.DeveloperLink.Text = "Made by PKTINOS/it185246";
            this.DeveloperLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DeveloperLink_LinkClicked);
            // 
            // ITApiLink
            // 
            this.ITApiLink.AutoSize = true;
            this.ITApiLink.Location = new System.Drawing.Point(11, 143);
            this.ITApiLink.Name = "ITApiLink";
            this.ITApiLink.Size = new System.Drawing.Size(67, 13);
            this.ITApiLink.TabIndex = 3;
            this.ITApiLink.TabStop = true;
            this.ITApiLink.Text = "Using IT API";
            this.ITApiLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ITAPI_LinkClicked);
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Location = new System.Drawing.Point(11, 170);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(259, 39);
            this.Description.TabIndex = 4;
            this.Description.Text = "Helps you sort announcements, search through them,\r\nmark the ones you\'ve seen, an" +
    "d notify you upon new\r\nannouncements.";
            // 
            // AppName
            // 
            this.AppName.Controls.Add(this.CloseButton);
            this.AppName.Controls.Add(this.pictureBox1);
            this.AppName.Controls.Add(this.ITApiLink);
            this.AppName.Controls.Add(this.Description);
            this.AppName.Controls.Add(this.DeveloperLink);
            this.AppName.Location = new System.Drawing.Point(1, 0);
            this.AppName.Name = "AppName";
            this.AppName.Size = new System.Drawing.Size(384, 255);
            this.AppName.TabIndex = 5;
            this.AppName.TabStop = false;
            this.AppName.Text = "AnnouncementHelper ";
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(330, 226);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(48, 23);
            this.CloseButton.TabIndex = 5;
            this.CloseButton.Text = "OK";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 255);
            this.Controls.Add(this.AppName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AboutBox";
            this.Load += new System.EventHandler(this.AboutBox1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.AppName.ResumeLayout(false);
            this.AppName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel DeveloperLink;
        private System.Windows.Forms.LinkLabel ITApiLink;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.GroupBox AppName;
        private System.Windows.Forms.Button CloseButton;
    }
}
