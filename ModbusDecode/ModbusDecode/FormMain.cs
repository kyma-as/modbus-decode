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
    public partial class MainForm : Form
    {
        public MainForm()
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
            try
            {
                MdbusMessage mdbusMessage = MdbusMessage.Decode(txtInput.Text, checkBoxModiconFloat.Checked);
                resultBox.Text = mdbusMessage.ToString() + resultBox.Text;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error decoding input string. Message:" + Environment.NewLine + e.Message, "Decoding Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            resultBox.Clear();
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            RequestHelp();
        }

        private void MainForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            RequestHelp();
        }

        private static void RequestHelp()
        {
            AboutBox box = new AboutBox();
            box.Show();
        }
    }
}
