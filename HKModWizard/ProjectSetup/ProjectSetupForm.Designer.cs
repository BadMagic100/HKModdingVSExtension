﻿namespace HKModWizard.ProjectSetup
{
    partial class ProjectSetupForm
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
            this.PolyfillCheckbox = new System.Windows.Forms.CheckBox();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.InstallPathLabel = new System.Windows.Forms.Label();
            this.AuthorField = new System.Windows.Forms.TextBox();
            this.DescriptionField = new System.Windows.Forms.TextBox();
            this.UseNullablesCheckbox = new System.Windows.Forms.CheckBox();
            this.InstallFolderField = new System.Windows.Forms.TextBox();
            this.InstallFolderBrowseButton = new System.Windows.Forms.Button();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.PolyfillCheckbox, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.AuthorLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DescriptionLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.InstallPathLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.AuthorField, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.DescriptionField, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.UseNullablesCheckbox, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.InstallFolderField, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.InstallFolderBrowseButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.SubmitButton, 2, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(693, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // PolyfillCheckbox
            // 
            this.PolyfillCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PolyfillCheckbox.AutoSize = true;
            this.PolyfillCheckbox.Checked = true;
            this.PolyfillCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PolyfillCheckbox.Location = new System.Drawing.Point(502, 117);
            this.PolyfillCheckbox.Name = "PolyfillCheckbox";
            this.PolyfillCheckbox.Size = new System.Drawing.Size(188, 20);
            this.PolyfillCheckbox.TabIndex = 10;
            this.PolyfillCheckbox.Text = "Polyfill Language Features";
            this.PolyfillCheckbox.UseVisualStyleBackColor = true;
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(86, 6);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(45, 16);
            this.AuthorLabel.TabIndex = 0;
            this.AuthorLabel.Text = "Author";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(56, 34);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(75, 16);
            this.DescriptionLabel.TabIndex = 1;
            this.DescriptionLabel.Text = "Description";
            // 
            // InstallPathLabel
            // 
            this.InstallPathLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.InstallPathLabel.AutoSize = true;
            this.InstallPathLabel.Location = new System.Drawing.Point(3, 64);
            this.InstallPathLabel.Name = "InstallPathLabel";
            this.InstallPathLabel.Size = new System.Drawing.Size(128, 16);
            this.InstallPathLabel.TabIndex = 2;
            this.InstallPathLabel.Text = "HK Managed Folder";
            // 
            // AuthorField
            // 
            this.AuthorField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AuthorField.Location = new System.Drawing.Point(137, 3);
            this.AuthorField.Name = "AuthorField";
            this.AuthorField.Size = new System.Drawing.Size(359, 22);
            this.AuthorField.TabIndex = 4;
            // 
            // DescriptionField
            // 
            this.DescriptionField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionField.Location = new System.Drawing.Point(137, 31);
            this.DescriptionField.Name = "DescriptionField";
            this.DescriptionField.Size = new System.Drawing.Size(359, 22);
            this.DescriptionField.TabIndex = 5;
            this.DescriptionField.Text = "A Hollow Knight mod that...";
            // 
            // UseNullablesCheckbox
            // 
            this.UseNullablesCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UseNullablesCheckbox.AutoSize = true;
            this.UseNullablesCheckbox.Checked = true;
            this.UseNullablesCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseNullablesCheckbox.Location = new System.Drawing.Point(576, 91);
            this.UseNullablesCheckbox.Name = "UseNullablesCheckbox";
            this.UseNullablesCheckbox.Size = new System.Drawing.Size(114, 20);
            this.UseNullablesCheckbox.TabIndex = 6;
            this.UseNullablesCheckbox.Text = "Use Nullables";
            this.UseNullablesCheckbox.UseVisualStyleBackColor = true;
            // 
            // InstallFolderField
            // 
            this.InstallFolderField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InstallFolderField.Location = new System.Drawing.Point(137, 59);
            this.InstallFolderField.Name = "InstallFolderField";
            this.InstallFolderField.Size = new System.Drawing.Size(359, 22);
            this.InstallFolderField.TabIndex = 7;
            // 
            // InstallFolderBrowseButton
            // 
            this.InstallFolderBrowseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InstallFolderBrowseButton.Location = new System.Drawing.Point(502, 59);
            this.InstallFolderBrowseButton.Name = "InstallFolderBrowseButton";
            this.InstallFolderBrowseButton.Size = new System.Drawing.Size(188, 26);
            this.InstallFolderBrowseButton.TabIndex = 8;
            this.InstallFolderBrowseButton.Text = "Browse";
            this.InstallFolderBrowseButton.UseVisualStyleBackColor = true;
            this.InstallFolderBrowseButton.Click += new System.EventHandler(this.InstallFolderBrowseButton_Click);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmitButton.Location = new System.Drawing.Point(613, 422);
            this.SubmitButton.Margin = new System.Windows.Forms.Padding(5);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 9;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.Submit_Click);
            // 
            // ProjectSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProjectSetupForm";
            this.ShowIcon = false;
            this.Text = "Configure Mod Project";
            this.Load += new System.EventHandler(this.UserInputForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label InstallPathLabel;
        private System.Windows.Forms.TextBox AuthorField;
        private System.Windows.Forms.TextBox DescriptionField;
        private System.Windows.Forms.CheckBox UseNullablesCheckbox;
        private System.Windows.Forms.TextBox InstallFolderField;
        private System.Windows.Forms.Button InstallFolderBrowseButton;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.CheckBox PolyfillCheckbox;
    }
}