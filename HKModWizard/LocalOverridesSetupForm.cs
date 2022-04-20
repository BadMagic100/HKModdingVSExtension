using System;
using System.Windows.Forms;

namespace HKModWizard
{
    public partial class LocalOverridesSetupForm : Form
    {
        public string HollowKnightManagedFolder => InstallDirField.Text;

        public LocalOverridesSetupForm()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
            {
                RootFolder = Environment.SpecialFolder.MyComputer,
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                InstallDirField.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Properties.Settings.Default.Save();
            Close();
        }

        private void LocalOverridesSetupForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(HollowKnightManagedFolder) && HKAutoDetect.TryAutoDetectPath(out string path))
            {
                InstallDirField.Text = path;
            }
        }
    }
}
