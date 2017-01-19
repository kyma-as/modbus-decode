using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace ModbusDecode
{
    enum HelpTabs
    {
        ReadMe,
        VersionHistory,
        ErrorCodes,
    }

    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;

            LoadFile(readmeBox, "ModbusDecode ReadMe.txt");
            LoadFile(versionHistoryBox, "ModbusDecode Version.txt");
            LoadFile(errorCodesBox, "ModbusErrorCodes.txt");
        }

        private void LoadFile(RichTextBox textBox, string textBoxFile)
        {
            textBox.Clear();
            if (File.Exists(textBoxFile))
            {
                try
                {
                    textBox.LoadFile(textBoxFile, RichTextBoxStreamType.PlainText);
                }
                catch (Exception e)
                {
                    textBox.AppendText("Error loading help file '" + textBoxFile + "'.");
                    textBox.AppendText(Environment.NewLine + Environment.NewLine);
                    textBox.AppendText("Message: " + e.Message);
                }
            }
            else
            {
                textBox.AppendText("Help file '" + textBoxFile + "' not found!");
            }
        }

        #region Assembly Attribute Accessors

        public static string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public static string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public static string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public static string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public static string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        internal void ShowTab(HelpTabs helpTab)
        {
            switch (helpTab)
            {
                case HelpTabs.ReadMe:
                    tabControlFiles.SelectedTab = tabPageReadMe;
                    break;
                case HelpTabs.VersionHistory:
                    tabControlFiles.SelectedTab = tabPageVersionHistory;
                    break;
                case HelpTabs.ErrorCodes:
                    tabControlFiles.SelectedTab = tabPageErrorCodes;
                    break;
                default:
                    break;
            }
        }

    }
}
