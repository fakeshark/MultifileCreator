namespace MultifileCreator
{
    partial class frmFileCreator
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
            this.lbxFileListBox = new System.Windows.Forms.ListBox();
            this.btnMoveFileUp = new System.Windows.Forms.Button();
            this.btnMakeFiles = new System.Windows.Forms.Button();
            this.txtFileNameEntry = new System.Windows.Forms.TextBox();
            this.lblFileNameEntry = new System.Windows.Forms.Label();
            this.btnAdd_UpdateFile = new System.Windows.Forms.Button();
            this.btnMoveFileDown = new System.Windows.Forms.Button();
            this.gbxInfoDisplay = new System.Windows.Forms.GroupBox();
            this.lblFileFolderPath = new System.Windows.Forms.Label();
            this.lblFileQty = new System.Windows.Forms.Label();
            this.btnFolderPathBrowse = new System.Windows.Forms.Button();
            this.btnEditFileName = new System.Windows.Forms.Button();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxFileInfo = new System.Windows.Forms.GroupBox();
            this.gbxGenerateContent = new System.Windows.Forms.GroupBox();
            this.rdoContentNo = new System.Windows.Forms.RadioButton();
            this.rdoContentYes = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblTMid = new System.Windows.Forms.Label();
            this.lblMaintLevel = new System.Windows.Forms.Label();
            this.cbxMaintLevel = new System.Windows.Forms.ComboBox();
            this.gbxInfoDisplay.SuspendLayout();
            this.gbxGenerateContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxFileListBox
            // 
            this.lbxFileListBox.FormattingEnabled = true;
            this.lbxFileListBox.ItemHeight = 20;
            this.lbxFileListBox.Location = new System.Drawing.Point(45, 195);
            this.lbxFileListBox.Name = "lbxFileListBox";
            this.lbxFileListBox.ScrollAlwaysVisible = true;
            this.lbxFileListBox.Size = new System.Drawing.Size(973, 564);
            this.lbxFileListBox.TabIndex = 0;
            // 
            // btnMoveFileUp
            // 
            this.btnMoveFileUp.Location = new System.Drawing.Point(45, 778);
            this.btnMoveFileUp.Name = "btnMoveFileUp";
            this.btnMoveFileUp.Size = new System.Drawing.Size(123, 41);
            this.btnMoveFileUp.TabIndex = 1;
            this.btnMoveFileUp.Text = "Move Up ▲";
            this.btnMoveFileUp.UseVisualStyleBackColor = true;
            this.btnMoveFileUp.Click += new System.EventHandler(this.btnMoveFileUp_Click);
            // 
            // btnMakeFiles
            // 
            this.btnMakeFiles.Location = new System.Drawing.Point(626, 778);
            this.btnMakeFiles.Name = "btnMakeFiles";
            this.btnMakeFiles.Size = new System.Drawing.Size(387, 41);
            this.btnMakeFiles.TabIndex = 2;
            this.btnMakeFiles.Text = "Make Files";
            this.btnMakeFiles.UseVisualStyleBackColor = true;
            this.btnMakeFiles.Click += new System.EventHandler(this.btnMakeFiles_Click);
            // 
            // txtFileNameEntry
            // 
            this.txtFileNameEntry.Location = new System.Drawing.Point(45, 151);
            this.txtFileNameEntry.Name = "txtFileNameEntry";
            this.txtFileNameEntry.Size = new System.Drawing.Size(765, 26);
            this.txtFileNameEntry.TabIndex = 3;
            this.txtFileNameEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFileNameEntry_KeyDown);
            // 
            // lblFileNameEntry
            // 
            this.lblFileNameEntry.AutoSize = true;
            this.lblFileNameEntry.Location = new System.Drawing.Point(41, 128);
            this.lblFileNameEntry.Name = "lblFileNameEntry";
            this.lblFileNameEntry.Size = new System.Drawing.Size(127, 20);
            this.lblFileNameEntry.TabIndex = 4;
            this.lblFileNameEntry.Text = "Enter File Name:";
            // 
            // btnAdd_UpdateFile
            // 
            this.btnAdd_UpdateFile.BackColor = System.Drawing.Color.Linen;
            this.btnAdd_UpdateFile.Location = new System.Drawing.Point(831, 136);
            this.btnAdd_UpdateFile.Name = "btnAdd_UpdateFile";
            this.btnAdd_UpdateFile.Size = new System.Drawing.Size(187, 41);
            this.btnAdd_UpdateFile.TabIndex = 5;
            this.btnAdd_UpdateFile.Tag = "AddFile";
            this.btnAdd_UpdateFile.Text = "Add File to List ▼";
            this.btnAdd_UpdateFile.UseVisualStyleBackColor = false;
            this.btnAdd_UpdateFile.Click += new System.EventHandler(this.btnAdd_UpdateFile_Click);
            // 
            // btnMoveFileDown
            // 
            this.btnMoveFileDown.Location = new System.Drawing.Point(468, 778);
            this.btnMoveFileDown.Name = "btnMoveFileDown";
            this.btnMoveFileDown.Size = new System.Drawing.Size(140, 41);
            this.btnMoveFileDown.TabIndex = 6;
            this.btnMoveFileDown.Text = "Move Down ▼";
            this.btnMoveFileDown.UseVisualStyleBackColor = true;
            this.btnMoveFileDown.Click += new System.EventHandler(this.btnMoveFileDown_Click);
            // 
            // gbxInfoDisplay
            // 
            this.gbxInfoDisplay.Controls.Add(this.lblFileFolderPath);
            this.gbxInfoDisplay.Controls.Add(this.lblFileQty);
            this.gbxInfoDisplay.Controls.Add(this.btnFolderPathBrowse);
            this.gbxInfoDisplay.Location = new System.Drawing.Point(45, 27);
            this.gbxInfoDisplay.Name = "gbxInfoDisplay";
            this.gbxInfoDisplay.Size = new System.Drawing.Size(882, 90);
            this.gbxInfoDisplay.TabIndex = 7;
            this.gbxInfoDisplay.TabStop = false;
            this.gbxInfoDisplay.Text = "Info:";
            // 
            // lblFileFolderPath
            // 
            this.lblFileFolderPath.AutoSize = true;
            this.lblFileFolderPath.Location = new System.Drawing.Point(198, 39);
            this.lblFileFolderPath.Name = "lblFileFolderPath";
            this.lblFileFolderPath.Size = new System.Drawing.Size(95, 20);
            this.lblFileFolderPath.TabIndex = 12;
            this.lblFileFolderPath.Text = "Folder Path:";
            // 
            // lblFileQty
            // 
            this.lblFileQty.AutoSize = true;
            this.lblFileQty.Location = new System.Drawing.Point(17, 39);
            this.lblFileQty.Name = "lblFileQty";
            this.lblFileQty.Size = new System.Drawing.Size(137, 20);
            this.lblFileQty.TabIndex = 11;
            this.lblFileQty.Text = "Number of Files: 0";
            // 
            // btnFolderPathBrowse
            // 
            this.btnFolderPathBrowse.Location = new System.Drawing.Point(783, 27);
            this.btnFolderPathBrowse.Name = "btnFolderPathBrowse";
            this.btnFolderPathBrowse.Size = new System.Drawing.Size(81, 41);
            this.btnFolderPathBrowse.TabIndex = 10;
            this.btnFolderPathBrowse.Text = "Browse";
            this.btnFolderPathBrowse.UseVisualStyleBackColor = true;
            this.btnFolderPathBrowse.Click += new System.EventHandler(this.btnFolderPathBrowse_Click);
            // 
            // btnEditFileName
            // 
            this.btnEditFileName.Location = new System.Drawing.Point(186, 778);
            this.btnEditFileName.Name = "btnEditFileName";
            this.btnEditFileName.Size = new System.Drawing.Size(123, 41);
            this.btnEditFileName.TabIndex = 8;
            this.btnEditFileName.Text = "Edit Name";
            this.btnEditFileName.UseVisualStyleBackColor = true;
            this.btnEditFileName.Click += new System.EventHandler(this.btnEditFileName_Click);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Location = new System.Drawing.Point(327, 778);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(123, 41);
            this.btnDeleteFile.TabIndex = 9;
            this.btnDeleteFile.Text = "Delete File";
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnExit.Location = new System.Drawing.Point(937, 36);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(81, 81);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Front Matter",
            "General Information - chapter start",
            "GIM - General Information WP",
            "GIM - Equip. Desc. & Data WP",
            "GIM - Theory of Operation WP",
            "General Information - chapter end",
            "Operator Instructions - chapter start",
            "Desc./Use Controls & Indicators WP",
            "Assembly & Prep for Use WP",
            "General Operations WP",
            "Stowage, Decals & Data Plates WP",
            "Operator Instructions - chapter end",
            "Troubleshooting Chapter - start",
            "Troubleshooting Index WP",
            "General Troubleshooting WP",
            "Troubleshooting Chapter - end",
            "Maintenance Chapter - start",
            "PMCS intro",
            "PMCS WP",
            "Standard Maintenance WP",
            "General Maint. Instructions WP",
            "Lubrication Instruct. WP",
            "Torque Limits WP",
            "Maintenance Chapter - end",
            "Parts Information Chapter - start",
            "RPSTL Introduction",
            "RPSTL WP",
            "Bulk Items List WP",
            "NSN Index",
            "Parts Information Chapter - end",
            "Supporting Info Chapter - start",
            "References WP",
            "MAC Introduction",
            "MAC WP",
            "COEI / BII WP",
            "AAL WP",
            "Expendable Durable WP",
            "Mandatory Replacement Parts WP",
            "Supporting Info Chapter - end",
            "Rear Matter"});
            this.comboBox1.Location = new System.Drawing.Point(1040, 328);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(287, 28);
            this.comboBox1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1040, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "TM Section Type:";
            // 
            // gbxFileInfo
            // 
            this.gbxFileInfo.Location = new System.Drawing.Point(1040, 475);
            this.gbxFileInfo.Name = "gbxFileInfo";
            this.gbxFileInfo.Size = new System.Drawing.Size(286, 344);
            this.gbxFileInfo.TabIndex = 15;
            this.gbxFileInfo.TabStop = false;
            this.gbxFileInfo.Text = "File Info:";
            // 
            // gbxGenerateContent
            // 
            this.gbxGenerateContent.Controls.Add(this.rdoContentNo);
            this.gbxGenerateContent.Controls.Add(this.rdoContentYes);
            this.gbxGenerateContent.Location = new System.Drawing.Point(1040, 367);
            this.gbxGenerateContent.Name = "gbxGenerateContent";
            this.gbxGenerateContent.Size = new System.Drawing.Size(285, 102);
            this.gbxGenerateContent.TabIndex = 16;
            this.gbxGenerateContent.TabStop = false;
            this.gbxGenerateContent.Text = "Auto-generate placeholder content?";
            // 
            // rdoContentNo
            // 
            this.rdoContentNo.AutoSize = true;
            this.rdoContentNo.Location = new System.Drawing.Point(183, 53);
            this.rdoContentNo.Name = "rdoContentNo";
            this.rdoContentNo.Size = new System.Drawing.Size(54, 24);
            this.rdoContentNo.TabIndex = 1;
            this.rdoContentNo.Text = "No";
            this.rdoContentNo.UseVisualStyleBackColor = true;
            // 
            // rdoContentYes
            // 
            this.rdoContentYes.AutoSize = true;
            this.rdoContentYes.Checked = true;
            this.rdoContentYes.Location = new System.Drawing.Point(48, 53);
            this.rdoContentYes.Name = "rdoContentYes";
            this.rdoContentYes.Size = new System.Drawing.Size(125, 24);
            this.rdoContentYes.TabIndex = 0;
            this.rdoContentYes.TabStop = true;
            this.rdoContentYes.Text = "Yes (default)";
            this.rdoContentYes.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1040, 160);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(287, 26);
            this.textBox1.TabIndex = 17;
            // 
            // lblTMid
            // 
            this.lblTMid.AutoSize = true;
            this.lblTMid.Location = new System.Drawing.Point(1040, 134);
            this.lblTMid.Name = "lblTMid";
            this.lblTMid.Size = new System.Drawing.Size(97, 20);
            this.lblTMid.TabIndex = 18;
            this.lblTMid.Text = "TM Base ID:";
            // 
            // lblMaintLevel
            // 
            this.lblMaintLevel.AutoSize = true;
            this.lblMaintLevel.Location = new System.Drawing.Point(1040, 217);
            this.lblMaintLevel.Name = "lblMaintLevel";
            this.lblMaintLevel.Size = new System.Drawing.Size(175, 20);
            this.lblMaintLevel.TabIndex = 19;
            this.lblMaintLevel.Text = "WP Maintenance Level:";
            // 
            // cbxMaintLevel
            // 
            this.cbxMaintLevel.FormattingEnabled = true;
            this.cbxMaintLevel.Items.AddRange(new object[] {
            "Crew",
            "Maintainer"});
            this.cbxMaintLevel.Location = new System.Drawing.Point(1040, 243);
            this.cbxMaintLevel.Name = "cbxMaintLevel";
            this.cbxMaintLevel.Size = new System.Drawing.Size(287, 28);
            this.cbxMaintLevel.TabIndex = 20;
            // 
            // frmFileCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 853);
            this.Controls.Add(this.lblMaintLevel);
            this.Controls.Add(this.cbxMaintLevel);
            this.Controls.Add(this.lblTMid);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.gbxGenerateContent);
            this.Controls.Add(this.gbxFileInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDeleteFile);
            this.Controls.Add(this.btnEditFileName);
            this.Controls.Add(this.gbxInfoDisplay);
            this.Controls.Add(this.btnMoveFileDown);
            this.Controls.Add(this.btnAdd_UpdateFile);
            this.Controls.Add(this.lblFileNameEntry);
            this.Controls.Add(this.txtFileNameEntry);
            this.Controls.Add(this.btnMakeFiles);
            this.Controls.Add(this.btnMoveFileUp);
            this.Controls.Add(this.lbxFileListBox);
            this.Name = "frmFileCreator";
            this.Text = "File Creator";
            this.gbxInfoDisplay.ResumeLayout(false);
            this.gbxInfoDisplay.PerformLayout();
            this.gbxGenerateContent.ResumeLayout(false);
            this.gbxGenerateContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxFileListBox;
        private System.Windows.Forms.Button btnMoveFileUp;
        private System.Windows.Forms.Button btnMakeFiles;
        private System.Windows.Forms.TextBox txtFileNameEntry;
        private System.Windows.Forms.Label lblFileNameEntry;
        private System.Windows.Forms.Button btnAdd_UpdateFile;
        private System.Windows.Forms.Button btnMoveFileDown;
        private System.Windows.Forms.GroupBox gbxInfoDisplay;
        private System.Windows.Forms.Label lblFileFolderPath;
        private System.Windows.Forms.Label lblFileQty;
        private System.Windows.Forms.Button btnFolderPathBrowse;
        private System.Windows.Forms.Button btnEditFileName;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbxFileInfo;
        private System.Windows.Forms.GroupBox gbxGenerateContent;
        private System.Windows.Forms.RadioButton rdoContentNo;
        private System.Windows.Forms.RadioButton rdoContentYes;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblTMid;
        private System.Windows.Forms.Label lblMaintLevel;
        private System.Windows.Forms.ComboBox cbxMaintLevel;
    }
}

