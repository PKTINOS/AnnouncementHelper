namespace AnnouncementHelper.Forms
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SettingsList = new System.Windows.Forms.ListBox();
            this.StartupPanel = new System.Windows.Forms.Panel();
            this.RemindersPanel = new System.Windows.Forms.Panel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CustomizationPanel = new System.Windows.Forms.Panel();
            this.ColorPick = new System.Windows.Forms.ColorDialog();
            this.BgColorButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.StartupPanel.SuspendLayout();
            this.RemindersPanel.SuspendLayout();
            this.CustomizationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 13);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Run on startup";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.Startup_CheckedChanged);
            // 
            // SettingsList
            // 
            this.SettingsList.FormattingEnabled = true;
            this.SettingsList.Items.AddRange(new object[] {
            "Startup",
            "Reminders",
            "Customization"});
            this.SettingsList.Location = new System.Drawing.Point(0, 0);
            this.SettingsList.Name = "SettingsList";
            this.SettingsList.Size = new System.Drawing.Size(120, 446);
            this.SettingsList.TabIndex = 1;
            this.SettingsList.SelectedIndexChanged += new System.EventHandler(this.SettingsList_SelectedIndexChanged);
            // 
            // StartupPanel
            // 
            this.StartupPanel.Controls.Add(this.label1);
            this.StartupPanel.Controls.Add(this.checkBox2);
            this.StartupPanel.Controls.Add(this.checkBox1);
            this.StartupPanel.Location = new System.Drawing.Point(120, 0);
            this.StartupPanel.Name = "StartupPanel";
            this.StartupPanel.Size = new System.Drawing.Size(144, 116);
            this.StartupPanel.TabIndex = 2;
            this.StartupPanel.Visible = false;
            // 
            // RemindersPanel
            // 
            this.RemindersPanel.Controls.Add(this.label2);
            this.RemindersPanel.Location = new System.Drawing.Point(120, 122);
            this.RemindersPanel.Name = "RemindersPanel";
            this.RemindersPanel.Size = new System.Drawing.Size(144, 115);
            this.RemindersPanel.TabIndex = 3;
            this.RemindersPanel.Visible = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(7, 36);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(81, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Silent mode";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Minimize to task bar and only show reminders";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Suggest settings on github!";
            // 
            // CustomizationPanel
            // 
            this.CustomizationPanel.Controls.Add(this.pictureBox1);
            this.CustomizationPanel.Controls.Add(this.BgColorButton);
            this.CustomizationPanel.Location = new System.Drawing.Point(120, 243);
            this.CustomizationPanel.Name = "CustomizationPanel";
            this.CustomizationPanel.Size = new System.Drawing.Size(200, 118);
            this.CustomizationPanel.TabIndex = 4;
            this.CustomizationPanel.Visible = false;
            // 
            // BgColorButton
            // 
            this.BgColorButton.Location = new System.Drawing.Point(36, 14);
            this.BgColorButton.Name = "BgColorButton";
            this.BgColorButton.Size = new System.Drawing.Size(139, 23);
            this.BgColorButton.TabIndex = 5;
            this.BgColorButton.Text = "Select background color";
            this.BgColorButton.UseVisualStyleBackColor = true;
            this.BgColorButton.Click += new System.EventHandler(this.BgColorButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(7, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 23);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 439);
            this.Controls.Add(this.CustomizationPanel);
            this.Controls.Add(this.RemindersPanel);
            this.Controls.Add(this.StartupPanel);
            this.Controls.Add(this.SettingsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.StartupPanel.ResumeLayout(false);
            this.StartupPanel.PerformLayout();
            this.RemindersPanel.ResumeLayout(false);
            this.RemindersPanel.PerformLayout();
            this.CustomizationPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ListBox SettingsList;
        private System.Windows.Forms.Panel StartupPanel;
        private System.Windows.Forms.Panel RemindersPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel CustomizationPanel;
        private System.Windows.Forms.Button BgColorButton;
        private System.Windows.Forms.ColorDialog ColorPick;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}