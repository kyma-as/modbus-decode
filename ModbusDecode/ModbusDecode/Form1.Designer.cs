namespace ModbusDecode
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnDecode = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxModiconFloat = new System.Windows.Forms.CheckBox();
            this.resultBox = new System.Windows.Forms.RichTextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(42, 82);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(732, 20);
            this.txtInput.TabIndex = 0;
            this.txtInput.Text = "01 04 10 60 3A 46 33 69 89 44 57 33 CE 43 06 8B 59 3B 72 C4 8E ";
            // 
            // btnDecode
            // 
            this.btnDecode.Location = new System.Drawing.Point(42, 122);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(75, 23);
            this.btnDecode.TabIndex = 1;
            this.btnDecode.Text = "Decode";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(39, 163);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(40, 13);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "Result:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please enter the Modbus communication string as hex values.\r\nEnter bytes seperate" +
    "d with space, like: 01 04 0B B8 00 08 73 CD";
            // 
            // checkBoxModiconFloat
            // 
            this.checkBoxModiconFloat.AutoSize = true;
            this.checkBoxModiconFloat.Checked = true;
            this.checkBoxModiconFloat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxModiconFloat.Location = new System.Drawing.Point(146, 126);
            this.checkBoxModiconFloat.Name = "checkBoxModiconFloat";
            this.checkBoxModiconFloat.Size = new System.Drawing.Size(115, 17);
            this.checkBoxModiconFloat.TabIndex = 12;
            this.checkBoxModiconFloat.Text = "Use Modicon Float";
            this.checkBoxModiconFloat.UseVisualStyleBackColor = true;
            this.checkBoxModiconFloat.CheckedChanged += new System.EventHandler(this.checkBoxModiconFloat_CheckedChanged);
            // 
            // resultBox
            // 
            this.resultBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultBox.Location = new System.Drawing.Point(42, 179);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(732, 384);
            this.resultBox.TabIndex = 15;
            this.resultBox.Text = "";
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Location = new System.Drawing.Point(636, 153);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(138, 23);
            this.buttonClear.TabIndex = 16;
            this.buttonClear.Text = "Clear Result Window";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 575);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.checkBoxModiconFloat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.txtInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Name = "Form1";
            this.Text = "Modbus Decoder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxModiconFloat;
        private System.Windows.Forms.RichTextBox resultBox;
        private System.Windows.Forms.Button buttonClear;
    }
}

