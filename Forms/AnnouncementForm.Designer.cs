namespace AnnouncementHelper
{
    partial class AnnouncementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnnouncementForm));
            this.DateLabel = new System.Windows.Forms.Label();
            this.PublisherLabel = new System.Windows.Forms.Label();
            this.DataTextbox = new System.Windows.Forms.RichTextBox();
            this.TitleTextbox = new System.Windows.Forms.RichTextBox();
            this.ReminderSet = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(16, 54);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(28, 13);
            this.DateLabel.TabIndex = 1;
            this.DateLabel.Text = "date";
            // 
            // PublisherLabel
            // 
            this.PublisherLabel.AutoSize = true;
            this.PublisherLabel.Location = new System.Drawing.Point(17, 495);
            this.PublisherLabel.Name = "PublisherLabel";
            this.PublisherLabel.Size = new System.Drawing.Size(27, 13);
            this.PublisherLabel.TabIndex = 3;
            this.PublisherLabel.Text = "from";
            // 
            // DataTextbox
            // 
            this.DataTextbox.Location = new System.Drawing.Point(17, 70);
            this.DataTextbox.Name = "DataTextbox";
            this.DataTextbox.ReadOnly = true;
            this.DataTextbox.Size = new System.Drawing.Size(538, 407);
            this.DataTextbox.TabIndex = 4;
            this.DataTextbox.Text = "";
            this.DataTextbox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.Data_LinkClicked);
            // 
            // TitleTextbox
            // 
            this.TitleTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.TitleTextbox.Location = new System.Drawing.Point(17, 12);
            this.TitleTextbox.Name = "TitleTextbox";
            this.TitleTextbox.ReadOnly = true;
            this.TitleTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.TitleTextbox.Size = new System.Drawing.Size(538, 39);
            this.TitleTextbox.TabIndex = 5;
            this.TitleTextbox.Text = "Title\nSecondLine\n";
            // 
            // ReminderSet
            // 
            this.ReminderSet.Location = new System.Drawing.Point(431, 484);
            this.ReminderSet.Name = "ReminderSet";
            this.ReminderSet.Size = new System.Drawing.Size(124, 23);
            this.ReminderSet.TabIndex = 6;
            this.ReminderSet.Text = "Set a reminder";
            this.ReminderSet.UseVisualStyleBackColor = true;
            this.ReminderSet.Click += new System.EventHandler(this.ReminderSet_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(226, 486);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // AnnouncementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 520);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.ReminderSet);
            this.Controls.Add(this.TitleTextbox);
            this.Controls.Add(this.DataTextbox);
            this.Controls.Add(this.PublisherLabel);
            this.Controls.Add(this.DateLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnnouncementForm";
            this.Text = "AnnouncementForm";
            this.Load += new System.EventHandler(this.AnnouncementForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Label PublisherLabel;
        private System.Windows.Forms.RichTextBox DataTextbox;
        private System.Windows.Forms.RichTextBox TitleTextbox;
        private System.Windows.Forms.Button ReminderSet;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}