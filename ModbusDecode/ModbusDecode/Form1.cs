using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModbusDecode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBoxModiconFloat_CheckedChanged(object sender, EventArgs e)
        {
            Decode();
        }
        
        private void btnDecode_Click(object sender, EventArgs e)
        {
            Decode();
        }

        private void Decode()
        {
            MdbusMessage mdbusMessage = MdbusMessage.Decode(txtInput.Text, checkBoxModiconFloat.Checked);
            resultBox.Text = mdbusMessage.ToString() + resultBox.Text;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            resultBox.Clear();
        }
    }
}
