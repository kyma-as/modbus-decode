namespace ModbusDecode
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnDecode = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxModiconFormat = new System.Windows.Forms.CheckBox();
            this.resultBox = new System.Windows.Forms.RichTextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.radioButtonSlave = new System.Windows.Forms.RadioButton();
            this.radioButtonMaster = new System.Windows.Forms.RadioButton();
            this.buttonReadMe = new System.Windows.Forms.Button();
            this.buttonVersionHistory = new System.Windows.Forms.Button();
            this.buttonErrorCodes = new System.Windows.Forms.Button();
            this.radioButtonFloats = new System.Windows.Forms.RadioButton();
            this.radioButtonInts = new System.Windows.Forms.RadioButton();
            this.radioButtonLongInts = new System.Windows.Forms.RadioButton();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.groupBoxMode = new System.Windows.Forms.GroupBox();
            this.groupBoxData.SuspendLayout();
            this.groupBoxMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(12, 82);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(771, 20);
            this.txtInput.TabIndex = 0;
            this.txtInput.Text = "RX 01 04 10 60 3A 46 33 69 89 44 57 33 CE 43 06 8B 59 3B 72 C4 8E ";
            // 
            // btnDecode
            // 
            this.btnDecode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(161)))));
            this.btnDecode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(68)))));
            this.btnDecode.Location = new System.Drawing.Point(12, 108);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(92, 44);
            this.btnDecode.TabIndex = 1;
            this.btnDecode.Text = "Decode";
            this.toolTip.SetToolTip(this.btnDecode, "Decodes the Modbus message in the input form.\r\nAll result will be added to the re" +
        "sult window below");
            this.btnDecode.UseVisualStyleBackColor = false;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(12, 155);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(40, 13);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "Result:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please enter the Modbus communication string as hex values.\r\nEnter bytes separate" +
    "d with space, like: [RX] 01 04 0B B8 00 08 73 CD";
            // 
            // checkBoxModiconFormat
            // 
            this.checkBoxModiconFormat.AutoSize = true;
            this.checkBoxModiconFormat.Checked = true;
            this.checkBoxModiconFormat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxModiconFormat.Location = new System.Drawing.Point(484, 123);
            this.checkBoxModiconFormat.Name = "checkBoxModiconFormat";
            this.checkBoxModiconFormat.Size = new System.Drawing.Size(124, 17);
            this.checkBoxModiconFormat.TabIndex = 12;
            this.checkBoxModiconFormat.Text = "Use Modicon Format";
            this.toolTip.SetToolTip(this.checkBoxModiconFormat, "Check this if Modicon Float/LongInt format is used. \r\nThis means:\r\nThe least sign" +
        "ificant bytes are sent in the first register \r\nand the most significant bytes in" +
        " the second register.");
            this.checkBoxModiconFormat.UseVisualStyleBackColor = true;
            // 
            // resultBox
            // 
            this.resultBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultBox.Location = new System.Drawing.Point(12, 171);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(771, 363);
            this.resultBox.TabIndex = 15;
            this.resultBox.Text = "";
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Location = new System.Drawing.Point(645, 540);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(138, 23);
            this.buttonClear.TabIndex = 16;
            this.buttonClear.Text = "Clear Result Window";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonAbout
            // 
            this.buttonAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAbout.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAbout.BackgroundImage")));
            this.buttonAbout.Location = new System.Drawing.Point(706, 12);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(77, 64);
            this.buttonAbout.TabIndex = 17;
            this.toolTip.SetToolTip(this.buttonAbout, "Click here to get more information about how to use this \r\nprogram and sample Mod" +
        "bus messages.");
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // radioButtonSlave
            // 
            this.radioButtonSlave.AutoSize = true;
            this.radioButtonSlave.Location = new System.Drawing.Point(69, 19);
            this.radioButtonSlave.Name = "radioButtonSlave";
            this.radioButtonSlave.Size = new System.Drawing.Size(52, 17);
            this.radioButtonSlave.TabIndex = 18;
            this.radioButtonSlave.Text = "Slave";
            this.toolTip.SetToolTip(this.radioButtonSlave, resources.GetString("radioButtonSlave.ToolTip"));
            this.radioButtonSlave.UseVisualStyleBackColor = true;
            // 
            // radioButtonMaster
            // 
            this.radioButtonMaster.AutoSize = true;
            this.radioButtonMaster.Checked = true;
            this.radioButtonMaster.Location = new System.Drawing.Point(6, 19);
            this.radioButtonMaster.Name = "radioButtonMaster";
            this.radioButtonMaster.Size = new System.Drawing.Size(57, 17);
            this.radioButtonMaster.TabIndex = 19;
            this.radioButtonMaster.TabStop = true;
            this.radioButtonMaster.Text = "Master";
            this.toolTip.SetToolTip(this.radioButtonMaster, resources.GetString("radioButtonMaster.ToolTip"));
            this.radioButtonMaster.UseVisualStyleBackColor = true;
            // 
            // buttonReadMe
            // 
            this.buttonReadMe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReadMe.Location = new System.Drawing.Point(12, 540);
            this.buttonReadMe.Name = "buttonReadMe";
            this.buttonReadMe.Size = new System.Drawing.Size(108, 23);
            this.buttonReadMe.TabIndex = 20;
            this.buttonReadMe.Text = "ReadMe";
            this.buttonReadMe.UseVisualStyleBackColor = true;
            this.buttonReadMe.Click += new System.EventHandler(this.buttonReadMe_Click);
            // 
            // buttonVersionHistory
            // 
            this.buttonVersionHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonVersionHistory.Location = new System.Drawing.Point(126, 540);
            this.buttonVersionHistory.Name = "buttonVersionHistory";
            this.buttonVersionHistory.Size = new System.Drawing.Size(108, 23);
            this.buttonVersionHistory.TabIndex = 21;
            this.buttonVersionHistory.Text = "Version History";
            this.buttonVersionHistory.UseVisualStyleBackColor = true;
            this.buttonVersionHistory.Click += new System.EventHandler(this.buttonVersionHistory_Click);
            // 
            // buttonErrorCodes
            // 
            this.buttonErrorCodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonErrorCodes.Location = new System.Drawing.Point(240, 540);
            this.buttonErrorCodes.Name = "buttonErrorCodes";
            this.buttonErrorCodes.Size = new System.Drawing.Size(108, 23);
            this.buttonErrorCodes.TabIndex = 22;
            this.buttonErrorCodes.Text = "Error Codes";
            this.buttonErrorCodes.UseVisualStyleBackColor = true;
            this.buttonErrorCodes.Click += new System.EventHandler(this.buttonErrorCodes_Click);
            // 
            // radioButtonFloats
            // 
            this.radioButtonFloats.AutoSize = true;
            this.radioButtonFloats.Checked = true;
            this.radioButtonFloats.Location = new System.Drawing.Point(6, 19);
            this.radioButtonFloats.Name = "radioButtonFloats";
            this.radioButtonFloats.Size = new System.Drawing.Size(53, 17);
            this.radioButtonFloats.TabIndex = 23;
            this.radioButtonFloats.TabStop = true;
            this.radioButtonFloats.Text = "Floats";
            this.radioButtonFloats.UseVisualStyleBackColor = true;
            // 
            // radioButtonInts
            // 
            this.radioButtonInts.AutoSize = true;
            this.radioButtonInts.Location = new System.Drawing.Point(65, 19);
            this.radioButtonInts.Name = "radioButtonInts";
            this.radioButtonInts.Size = new System.Drawing.Size(63, 17);
            this.radioButtonInts.TabIndex = 24;
            this.radioButtonInts.Text = "Integers";
            this.radioButtonInts.UseVisualStyleBackColor = true;
            // 
            // radioButtonLongInts
            // 
            this.radioButtonLongInts.AutoSize = true;
            this.radioButtonLongInts.Location = new System.Drawing.Point(134, 19);
            this.radioButtonLongInts.Name = "radioButtonLongInts";
            this.radioButtonLongInts.Size = new System.Drawing.Size(69, 17);
            this.radioButtonLongInts.TabIndex = 25;
            this.radioButtonLongInts.Text = "Long Ints";
            this.radioButtonLongInts.UseVisualStyleBackColor = true;
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.radioButtonLongInts);
            this.groupBoxData.Controls.Add(this.radioButtonFloats);
            this.groupBoxData.Controls.Add(this.radioButtonInts);
            this.groupBoxData.Location = new System.Drawing.Point(261, 108);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(217, 44);
            this.groupBoxData.TabIndex = 26;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "Data";
            // 
            // groupBoxMode
            // 
            this.groupBoxMode.Controls.Add(this.radioButtonMaster);
            this.groupBoxMode.Controls.Add(this.radioButtonSlave);
            this.groupBoxMode.Location = new System.Drawing.Point(110, 108);
            this.groupBoxMode.Name = "groupBoxMode";
            this.groupBoxMode.Size = new System.Drawing.Size(145, 44);
            this.groupBoxMode.TabIndex = 27;
            this.groupBoxMode.TabStop = false;
            this.groupBoxMode.Text = "Mode";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 575);
            this.Controls.Add(this.groupBoxMode);
            this.Controls.Add(this.groupBoxData);
            this.Controls.Add(this.buttonErrorCodes);
            this.Controls.Add(this.checkBoxModiconFormat);
            this.Controls.Add(this.buttonVersionHistory);
            this.Controls.Add(this.buttonReadMe);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.txtInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Modbus Decoder";
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.MainForm_HelpRequested);
            this.groupBoxData.ResumeLayout(false);
            this.groupBoxData.PerformLayout();
            this.groupBoxMode.ResumeLayout(false);
            this.groupBoxMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxModiconFormat;
        private System.Windows.Forms.RichTextBox resultBox;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.RadioButton radioButtonSlave;
        private System.Windows.Forms.RadioButton radioButtonMaster;
        private System.Windows.Forms.Button buttonReadMe;
        private System.Windows.Forms.Button buttonVersionHistory;
        private System.Windows.Forms.Button buttonErrorCodes;
        private System.Windows.Forms.RadioButton radioButtonFloats;
        private System.Windows.Forms.RadioButton radioButtonInts;
        private System.Windows.Forms.RadioButton radioButtonLongInts;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.GroupBox groupBoxMode;
    }
}

