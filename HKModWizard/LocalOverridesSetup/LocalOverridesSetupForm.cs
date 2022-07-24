using HKModWizard.Util;
using System;
using System.Windows.Forms;

namespace HKModWizard.LocalOverridesSetup
{
    public partial class LocalOverridesSetupForm : Form
    {
        public string HollowKnightManagedFolder => InstallDirField.Text;

        public LocalOverridesSetupForm(HKSettings settings)
        {
            InitializeComponent();

            InstallDirField.DataBindings.Add(new Binding(nameof(InstallDirField.Text), settings, nameof(settings.HKManagedPath)));
            InstallDirField.Text = settings.HKManagedPath;
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
