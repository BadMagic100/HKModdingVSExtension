using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HKModWizard
{
    public partial class UserInputForm : Form
    {
        public string Author => AuthorField.Text;
        public string Description => DescriptionField.Text;
        public string HollowKnightManagedFolder => InstallFolderField.Text;
        public bool Nullable => UseNullablesCheckbox.Checked;

        public UserInputForm()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Properties.Settings.Default.Save();
            Close();
        }

        private void UserInputForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(HollowKnightManagedFolder) && HKAutoDetect.TryAutoDetectPath(out string path))
            {
                InstallFolderField.Text = path;
            }
        }

        private void InstallFolderBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
            {
                RootFolder = Environment.SpecialFolder.MyComputer,
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) 
            {
                InstallFolderField.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
