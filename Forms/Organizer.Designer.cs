namespace AnnouncementHelper
{
    partial class Organizer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Organizer));
            this.AnnouncementGridView = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublisherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attachments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateSelectBox = new System.Windows.Forms.ComboBox();
            this.DateLabel = new System.Windows.Forms.Label();
            this.PublisherListbox = new System.Windows.Forms.CheckedListBox();
            this.PublisherLabel = new System.Windows.Forms.Label();
            this.SelectAllPublisher = new System.Windows.Forms.Button();
            this.UnselectAllPublisher = new System.Windows.Forms.Button();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.CategoryListbox = new System.Windows.Forms.CheckedListBox();
            this.ShowAnnouncementsButton = new System.Windows.Forms.Button();
            this.SelectAllCategory = new System.Windows.Forms.Button();
            this.UnselectAllCategory = new System.Windows.Forms.Button();
            this.CaseCheckbox = new System.Windows.Forms.CheckBox();
            this.StressCheckbox = new System.Windows.Forms.CheckBox();
            this.GrammarCheckbox = new System.Windows.Forms.CheckBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchBar = new System.Windows.Forms.RichTextBox();
            this.OrganizerStrip = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.AnnouncementGridView)).BeginInit();
            this.OrganizerStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // AnnouncementGridView
            // 
            this.AnnouncementGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AnnouncementGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Category,
            this.Title,
            this.PublisherName,
            this.Date,
            this.Attachments});
            this.AnnouncementGridView.Location = new System.Drawing.Point(12, 28);
            this.AnnouncementGridView.Name = "AnnouncementGridView";
            this.AnnouncementGridView.Size = new System.Drawing.Size(586, 556);
            this.AnnouncementGridView.TabIndex = 0;
            this.AnnouncementGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AnnouncementGridView_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 30;
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Width = 60;
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 150;
            // 
            // PublisherName
            // 
            this.PublisherName.HeaderText = "PublisherName";
            this.PublisherName.Name = "PublisherName";
            this.PublisherName.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Attachments
            // 
            this.Attachments.HeaderText = "Attachments";
            this.Attachments.Name = "Attachments";
            this.Attachments.Width = 80;
            // 
            // DateSelectBox
            // 
            this.DateSelectBox.FormattingEnabled = true;
            this.DateSelectBox.Items.AddRange(new object[] {
            "All",
            "Last 3 months",
            "This month",
            "This week"});
            this.DateSelectBox.Location = new System.Drawing.Point(604, 44);
            this.DateSelectBox.Name = "DateSelectBox";
            this.DateSelectBox.Size = new System.Drawing.Size(121, 21);
            this.DateSelectBox.TabIndex = 1;
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(603, 28);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(33, 13);
            this.DateLabel.TabIndex = 2;
            this.DateLabel.Text = "Date:";
            // 
            // PublisherListbox
            // 
            this.PublisherListbox.FormattingEnabled = true;
            this.PublisherListbox.Location = new System.Drawing.Point(604, 93);
            this.PublisherListbox.Name = "PublisherListbox";
            this.PublisherListbox.Size = new System.Drawing.Size(184, 124);
            this.PublisherListbox.TabIndex = 3;
            // 
            // PublisherLabel
            // 
            this.PublisherLabel.AutoSize = true;
            this.PublisherLabel.Location = new System.Drawing.Point(604, 77);
            this.PublisherLabel.Name = "PublisherLabel";
            this.PublisherLabel.Size = new System.Drawing.Size(53, 13);
            this.PublisherLabel.TabIndex = 4;
            this.PublisherLabel.Text = "Publisher:";
            // 
            // SelectAllPublisher
            // 
            this.SelectAllPublisher.Location = new System.Drawing.Point(604, 223);
            this.SelectAllPublisher.Name = "SelectAllPublisher";
            this.SelectAllPublisher.Size = new System.Drawing.Size(85, 23);
            this.SelectAllPublisher.TabIndex = 5;
            this.SelectAllPublisher.Text = "Select All";
            this.SelectAllPublisher.UseVisualStyleBackColor = true;
            this.SelectAllPublisher.Click += new System.EventHandler(this.SelectAllPublisher_Click);
            // 
            // UnselectAllPublisher
            // 
            this.UnselectAllPublisher.Location = new System.Drawing.Point(703, 223);
            this.UnselectAllPublisher.Name = "UnselectAllPublisher";
            this.UnselectAllPublisher.Size = new System.Drawing.Size(85, 23);
            this.UnselectAllPublisher.TabIndex = 6;
            this.UnselectAllPublisher.Text = "Unselect All";
            this.UnselectAllPublisher.UseVisualStyleBackColor = true;
            this.UnselectAllPublisher.Click += new System.EventHandler(this.UnselectAllPublisher_Click);
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Location = new System.Drawing.Point(604, 260);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(52, 13);
            this.CategoryLabel.TabIndex = 7;
            this.CategoryLabel.Text = "Category:";
            // 
            // CategoryListbox
            // 
            this.CategoryListbox.FormattingEnabled = true;
            this.CategoryListbox.Location = new System.Drawing.Point(604, 276);
            this.CategoryListbox.Name = "CategoryListbox";
            this.CategoryListbox.Size = new System.Drawing.Size(184, 109);
            this.CategoryListbox.TabIndex = 8;
            // 
            // ShowAnnouncementsButton
            // 
            this.ShowAnnouncementsButton.Location = new System.Drawing.Point(604, 420);
            this.ShowAnnouncementsButton.Name = "ShowAnnouncementsButton";
            this.ShowAnnouncementsButton.Size = new System.Drawing.Size(184, 56);
            this.ShowAnnouncementsButton.TabIndex = 9;
            this.ShowAnnouncementsButton.Text = "Apply filter";
            this.ShowAnnouncementsButton.UseVisualStyleBackColor = true;
            this.ShowAnnouncementsButton.Click += new System.EventHandler(this.ShowAnnouncements_Click);
            // 
            // SelectAllCategory
            // 
            this.SelectAllCategory.Location = new System.Drawing.Point(604, 391);
            this.SelectAllCategory.Name = "SelectAllCategory";
            this.SelectAllCategory.Size = new System.Drawing.Size(85, 23);
            this.SelectAllCategory.TabIndex = 10;
            this.SelectAllCategory.Text = "Select All";
            this.SelectAllCategory.UseVisualStyleBackColor = true;
            this.SelectAllCategory.Click += new System.EventHandler(this.SelectAllCategory_Click);
            // 
            // UnselectAllCategory
            // 
            this.UnselectAllCategory.Location = new System.Drawing.Point(703, 391);
            this.UnselectAllCategory.Name = "UnselectAllCategory";
            this.UnselectAllCategory.Size = new System.Drawing.Size(85, 23);
            this.UnselectAllCategory.TabIndex = 11;
            this.UnselectAllCategory.Text = "Unselect All";
            this.UnselectAllCategory.UseVisualStyleBackColor = true;
            this.UnselectAllCategory.Click += new System.EventHandler(this.UnselectAllCategory_Click);
            // 
            // CaseCheckbox
            // 
            this.CaseCheckbox.AutoSize = true;
            this.CaseCheckbox.Location = new System.Drawing.Point(604, 521);
            this.CaseCheckbox.Name = "CaseCheckbox";
            this.CaseCheckbox.Size = new System.Drawing.Size(102, 17);
            this.CaseCheckbox.TabIndex = 12;
            this.CaseCheckbox.Text = "Case insensitive";
            this.CaseCheckbox.UseVisualStyleBackColor = true;
            // 
            // StressCheckbox
            // 
            this.StressCheckbox.AutoSize = true;
            this.StressCheckbox.Location = new System.Drawing.Point(604, 544);
            this.StressCheckbox.Name = "StressCheckbox";
            this.StressCheckbox.Size = new System.Drawing.Size(142, 17);
            this.StressCheckbox.TabIndex = 13;
            this.StressCheckbox.Text = "Stress insensitive (ά = α)";
            this.StressCheckbox.UseVisualStyleBackColor = true;
            // 
            // GrammarCheckbox
            // 
            this.GrammarCheckbox.AutoSize = true;
            this.GrammarCheckbox.Location = new System.Drawing.Point(604, 567);
            this.GrammarCheckbox.Name = "GrammarCheckbox";
            this.GrammarCheckbox.Size = new System.Drawing.Size(171, 17);
            this.GrammarCheckbox.TabIndex = 14;
            this.GrammarCheckbox.Text = "Grammar insensitive (η = ι = ει)";
            this.GrammarCheckbox.UseVisualStyleBackColor = true;
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Location = new System.Drawing.Point(601, 479);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(153, 13);
            this.SearchLabel.TabIndex = 16;
            this.SearchLabel.Text = "Search (seperate with comma):";
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.SearchButton.Location = new System.Drawing.Point(753, 495);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(35, 20);
            this.SearchButton.TabIndex = 17;
            this.SearchButton.Text = "\t🔍";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchBar
            // 
            this.SearchBar.Location = new System.Drawing.Point(604, 495);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(143, 20);
            this.SearchBar.TabIndex = 18;
            this.SearchBar.Text = "";
            // 
            // OrganizerStrip
            // 
            this.OrganizerStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.OrganizerStrip.Location = new System.Drawing.Point(0, 0);
            this.OrganizerStrip.Name = "OrganizerStrip";
            this.OrganizerStrip.Size = new System.Drawing.Size(796, 24);
            this.OrganizerStrip.TabIndex = 19;
            this.OrganizerStrip.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // Organizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 596);
            this.Controls.Add(this.SearchBar);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchLabel);
            this.Controls.Add(this.GrammarCheckbox);
            this.Controls.Add(this.StressCheckbox);
            this.Controls.Add(this.CaseCheckbox);
            this.Controls.Add(this.UnselectAllCategory);
            this.Controls.Add(this.SelectAllCategory);
            this.Controls.Add(this.ShowAnnouncementsButton);
            this.Controls.Add(this.CategoryListbox);
            this.Controls.Add(this.CategoryLabel);
            this.Controls.Add(this.UnselectAllPublisher);
            this.Controls.Add(this.SelectAllPublisher);
            this.Controls.Add(this.PublisherLabel);
            this.Controls.Add(this.PublisherListbox);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.DateSelectBox);
            this.Controls.Add(this.AnnouncementGridView);
            this.Controls.Add(this.OrganizerStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.OrganizerStrip;
            this.Name = "Organizer";
            this.Text = "Organizer";
            this.Load += new System.EventHandler(this.Organizer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AnnouncementGridView)).EndInit();
            this.OrganizerStrip.ResumeLayout(false);
            this.OrganizerStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView AnnouncementGridView;
        private System.Windows.Forms.ComboBox DateSelectBox;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.CheckedListBox PublisherListbox;
        private System.Windows.Forms.Label PublisherLabel;
        private System.Windows.Forms.Button SelectAllPublisher;
        private System.Windows.Forms.Button UnselectAllPublisher;
        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.CheckedListBox CategoryListbox;
        private System.Windows.Forms.Button ShowAnnouncementsButton;
        private System.Windows.Forms.Button SelectAllCategory;
        private System.Windows.Forms.Button UnselectAllCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublisherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attachments;
        private System.Windows.Forms.CheckBox CaseCheckbox;
        private System.Windows.Forms.CheckBox StressCheckbox;
        private System.Windows.Forms.CheckBox GrammarCheckbox;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.RichTextBox SearchBar;
        private System.Windows.Forms.MenuStrip OrganizerStrip;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}
