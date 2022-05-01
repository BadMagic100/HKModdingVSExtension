namespace HKModWizard.LocalOverridesSetup
{
    partial class LocalOverridesSetupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.InstallDirLabel = new System.Windows.Forms.Label();
            this.InstallDirField = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.InstallDirLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.InstallDirField, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BrowseButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.SubmitButton, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 562);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // InstallDirLabel
            // 
            this.InstallDirLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.InstallDirLabel.AutoSize = true;
            this.InstallDirLabel.Location = new System.Drawing.Point(3, 8);
            this.InstallDirLabel.Name = "InstallDirLabel";
            this.InstallDirLabel.Size = new System.Drawing.Size(151, 20);
            this.InstallDirLabel.TabIndex = 0;
            this.InstallDirLabel.Text = "HK Managed Folder";
            // 
            // InstallDirField
            // 
            this.InstallDirField.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::HKModWizard.Properties.Settings.Default, "HollowKnightManagedFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.InstallDirField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InstallDirField.Location = new System.Drawing.Point(160, 4);
            this.InstallDirField.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InstallDirField.Name = "InstallDirField";
            this.InstallDirField.Size = new System.Drawing.Size(641, 26);
            this.InstallDirField.TabIndex = 1;
            this.InstallDirField.Text = global::HKModWizard.Properties.Settings.Default.HollowKnightManagedFolder;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(807, 4);
            this.BrowseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(84, 29);
            this.BrowseButton.TabIndex = 2;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmitButton.Location = new System.Drawing.Point(810, 527);
            this.SubmitButton.Margin = new System.Windows.Forms.Padding(6);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(84, 29);
            this.SubmitButton.TabIndex = 3;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // LocalOverridesSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LocalOverridesSetupForm";
            this.ShowIcon = false;
            this.Text = "Local Overrides Setup";
            this.Load += new System.EventHandler(this.LocalOverridesSetupForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label InstallDirLabel;
        private System.Windows.Forms.TextBox InstallDirField;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Button SubmitButton;
    }
}