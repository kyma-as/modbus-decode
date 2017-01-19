namespace ModbusDecode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.tabControlFiles = new System.Windows.Forms.TabControl();
            this.tabPageReadMe = new System.Windows.Forms.TabPage();
            this.tabPageVersionHistory = new System.Windows.Forms.TabPage();
            this.tabPageErrorCodes = new System.Windows.Forms.TabPage();
            this.readmeBox = new System.Windows.Forms.RichTextBox();
            this.versionHistoryBox = new System.Windows.Forms.RichTextBox();
            this.errorCodesBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.tabControlFiles.SuspendLayout();
            this.tabPageReadMe.SuspendLayout();
            this.tabPageVersionHistory.SuspendLayout();
            this.tabPageErrorCodes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.70197F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.29803F));
            this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.labelCopyright, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.labelCompanyName, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.textBoxDescription, 1, 4);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(673, 170);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(3, 3);
            this.logoPictureBox.Name = "logoPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 5);
            this.logoPictureBox.Size = new System.Drawing.Size(200, 164);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // labelProductName
            // 
            this.labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProductName.Location = new System.Drawing.Point(259, 0);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelProductName.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(411, 17);
            this.labelProductName.TabIndex = 19;
            this.labelProductName.Text = "Product Name";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVersion
            // 
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelVersion.Location = new System.Drawing.Point(259, 28);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelVersion.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(411, 17);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "Version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCopyright
            // 
            this.labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCopyright.Location = new System.Drawing.Point(259, 56);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelCopyright.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(411, 17);
            this.labelCopyright.TabIndex = 21;
            this.labelCopyright.Text = "Copyright";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCompanyName.Location = new System.Drawing.Point(259, 84);
            this.labelCompanyName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelCompanyName.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(411, 17);
            this.labelCompanyName.TabIndex = 22;
            this.labelCompanyName.Text = "Company Name";
            this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(259, 115);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDescription.Size = new System.Drawing.Size(411, 52);
            this.textBoxDescription.TabIndex = 23;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Text = "Description";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(604, 551);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "&OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // tabControlFiles
            // 
            this.tabControlFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlFiles.Controls.Add(this.tabPageReadMe);
            this.tabControlFiles.Controls.Add(this.tabPageVersionHistory);
            this.tabControlFiles.Controls.Add(this.tabPageErrorCodes);
            this.tabControlFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlFiles.Location = new System.Drawing.Point(9, 182);
            this.tabControlFiles.Multiline = true;
            this.tabControlFiles.Name = "tabControlFiles";
            this.tabControlFiles.SelectedIndex = 0;
            this.tabControlFiles.Size = new System.Drawing.Size(670, 363);
            this.tabControlFiles.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlFiles.TabIndex = 28;
            // 
            // tabPageReadMe
            // 
            this.tabPageReadMe.Controls.Add(this.readmeBox);
            this.tabPageReadMe.Location = new System.Drawing.Point(4, 4);
            this.tabPageReadMe.Name = "tabPageReadMe";
            this.tabPageReadMe.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReadMe.Size = new System.Drawing.Size(662, 337);
            this.tabPageReadMe.TabIndex = 0;
            this.tabPageReadMe.Text = "ReadMe";
            this.tabPageReadMe.UseVisualStyleBackColor = true;
            // 
            // tabPageVersionHistory
            // 
            this.tabPageVersionHistory.Controls.Add(this.versionHistoryBox);
            this.tabPageVersionHistory.Location = new System.Drawing.Point(4, 4);
            this.tabPageVersionHistory.Name = "tabPageVersionHistory";
            this.tabPageVersionHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVersionHistory.Size = new System.Drawing.Size(662, 337);
            this.tabPageVersionHistory.TabIndex = 1;
            this.tabPageVersionHistory.Text = "Version History";
            this.tabPageVersionHistory.UseVisualStyleBackColor = true;
            // 
            // tabPageErrorCodes
            // 
            this.tabPageErrorCodes.Controls.Add(this.errorCodesBox);
            this.tabPageErrorCodes.Location = new System.Drawing.Point(4, 4);
            this.tabPageErrorCodes.Name = "tabPageErrorCodes";
            this.tabPageErrorCodes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageErrorCodes.Size = new System.Drawing.Size(662, 337);
            this.tabPageErrorCodes.TabIndex = 2;
            this.tabPageErrorCodes.Text = "Error Codes";
            this.tabPageErrorCodes.UseVisualStyleBackColor = true;
            // 
            // readmeBox
            // 
            this.readmeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.readmeBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readmeBox.Location = new System.Drawing.Point(3, 3);
            this.readmeBox.Name = "readmeBox";
            this.readmeBox.Size = new System.Drawing.Size(656, 331);
            this.readmeBox.TabIndex = 26;
            this.readmeBox.Text = "";
            // 
            // versionHistoryBox
            // 
            this.versionHistoryBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionHistoryBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionHistoryBox.Location = new System.Drawing.Point(3, 3);
            this.versionHistoryBox.Name = "versionHistoryBox";
            this.versionHistoryBox.Size = new System.Drawing.Size(656, 331);
            this.versionHistoryBox.TabIndex = 27;
            this.versionHistoryBox.Text = "";
            // 
            // errorCodesBox
            // 
            this.errorCodesBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorCodesBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorCodesBox.Location = new System.Drawing.Point(3, 3);
            this.errorCodesBox.Name = "errorCodesBox";
            this.errorCodesBox.Size = new System.Drawing.Size(656, 331);
            this.errorCodesBox.TabIndex = 27;
            this.errorCodesBox.Text = "";
            // 
            // AboutBox
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(691, 586);
            this.Controls.Add(this.tabControlFiles);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.okButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Name = "AboutBox";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ModbusDecode - About";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.tabControlFiles.ResumeLayout(false);
            this.tabPageReadMe.ResumeLayout(false);
            this.tabPageVersionHistory.ResumeLayout(false);
            this.tabPageErrorCodes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TabControl tabControlFiles;
        private System.Windows.Forms.TabPage tabPageReadMe;
        private System.Windows.Forms.TabPage tabPageVersionHistory;
        private System.Windows.Forms.TabPage tabPageErrorCodes;
        private System.Windows.Forms.RichTextBox readmeBox;
        private System.Windows.Forms.RichTextBox versionHistoryBox;
        private System.Windows.Forms.RichTextBox errorCodesBox;
    }
}
