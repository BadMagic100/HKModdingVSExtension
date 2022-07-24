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

        public ProjectSetupForm(HKSettings settings)
        {
            InitializeComponent();

            AuthorField.DataBindings.Add(new Binding(nameof(AuthorField.Text), settings, nameof(settings.Author), 
                false, DataSourceUpdateMode.OnPropertyChanged));
            AuthorField.Text = settings.Author;

            InstallFolderField.DataBindings.Add(new Binding(nameof(InstallFolderField.Text), settings, nameof(settings.HKManagedPath), 
                false, DataSourceUpdateMode.OnPropertyChanged));
            InstallFolderField.Text = settings.HKManagedPath;

            UseNullablesCheckbox.DataBindings.Add(new Binding(nameof(UseNullablesCheckbox.Checked), settings, nameof(settings.UseNullables),
                false, DataSourceUpdateMode.OnPropertyChanged));
            UseNullablesCheckbox.Checked = settings.UseNullables;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
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
