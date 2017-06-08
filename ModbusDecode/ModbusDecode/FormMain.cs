﻿using System;
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
            Text += String.Format(" - Version {0}", AboutBox.AssemblyVersion);
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            Decode();
        }

        private void Decode()
        {
            try
            {
                ModbusMessageMode mode = radioButtonMaster.Checked ? ModbusMessageMode.Master : ModbusMessageMode.Slave;
                ModbusDataType dataType = ModbusDataType.Float;
                if (radioButtonInts.Checked)
                {
                    dataType = ModbusDataType.Integer;
                }
                else if (radioButtonLongInts.Checked)
                {
                    dataType = ModbusDataType.LongInt;
                }
                MdbusMessage mdbusMessage = MdbusMessage.Decode(txtInput.Text, checkBoxModiconFormat.Checked, mode, dataType);
                resultBox.Text = mdbusMessage.ToString(true) + resultBox.Text;
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
            RequestHelp(HelpTabs.ReadMe);
        }

        private static void RequestHelp(HelpTabs helpTab)
        {
            AboutBox box = new AboutBox();
            box.ShowTab(helpTab);
            box.Show();
        }

        private void pictureBoxKymaLogo_DoubleClick(object sender, EventArgs e)
        {
            RequestHelp();
        }

        private void buttonReadMe_Click(object sender, EventArgs e)
        {
            RequestHelp(HelpTabs.ReadMe);
        }

        private void buttonVersionHistory_Click(object sender, EventArgs e)
        {
            RequestHelp(HelpTabs.VersionHistory);
        }

        private void buttonErrorCodes_Click(object sender, EventArgs e)
        {
            RequestHelp(HelpTabs.ErrorCodes);
        }

    }
}
