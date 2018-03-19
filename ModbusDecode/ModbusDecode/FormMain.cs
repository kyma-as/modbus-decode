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
            Text += String.Format(" - Version {0}", AboutBox.AssemblyVersion);

            if (System.IO.File.Exists("Mdbus.LOG"))
            {
                AddFileToListBox("Mdbus.LOG");
            }
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

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                string firstFile = files[0];
                AddFileToListBox(firstFile);
            }
        }

        private void AddFileToListBox(string mdbusLogFile)
        {
            var mdbusFile = MdbusFile.CreateFromFile(mdbusLogFile);
            listBoxCommands.Items.Clear();
            listBoxCommands.Items.AddRange(mdbusFile.GetAllCommands());
            // Display a shortened version of the file path above the list box
            // Found the solution here:
            // https://stackoverflow.com/questions/1764204/how-to-display-abbreviated-path-names-in-net
            // Thing to notice is that we have to make a copy of the string as the TextRenderer.MeasureText
            // actually changes the string even if .Net strings are immutable.
            var shortenFileName = string.Copy(mdbusLogFile);
            var size = new Size(listBoxCommands.Width, 0);
            TextRenderer.MeasureText(shortenFileName, lblCommands.Font, size, TextFormatFlags.PathEllipsis | TextFormatFlags.ModifyString);
            lblCommands.Text = shortenFileName;
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void ShowListBoxItem(object listboxItem, bool decode)
        {
            if ((listboxItem != null) && (listboxItem is MdbusCommand))
            {
                var mdbusCommand = (MdbusCommand)listboxItem;
                txtInput.Text = mdbusCommand.Message;
                if (decode)
                {
                    Decode();
                }
            }
        }

        private void listBoxCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowListBoxItem(listBoxCommands.SelectedItem, decode: false);
        }


        private void listBoxCommands_DoubleClick(object sender, EventArgs e)
        {
            ShowListBoxItem(listBoxCommands.SelectedItem, decode: true);
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Mdbus log files (Mdbus*.LOG)|Mdbus*.LOG|All log files (*.log)|*.log|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                AddFileToListBox(fileDialog.FileName);
            }
        }
    }
}
