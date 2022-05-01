using HKModWizard.Util;
using System;
using System.Windows.Forms;

namespace HKModWizard.ProjectSetup
{
    public partial class ProjectSetupForm : Form
    {
        public string Author => AuthorField.Text;
        public string Description => DescriptionField.Text;
        public string HollowKnightManagedFolder => InstallFolderField.Text;
        public bool Nullable => UseNullablesCheckbox.Checked;

        public ProjectSetupForm()
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
