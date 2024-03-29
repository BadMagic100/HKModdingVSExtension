﻿namespace HKModWizard.ModDependenciesCommand
{
    partial class ManageModDependenciesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageModDependenciesForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.referenceList = new System.Windows.Forms.ListView();
            this.folderNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modDepsList = new System.Windows.Forms.ListView();
            this.modlinkNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modAliasHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modDownloadHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.rectifyButton = new System.Windows.Forms.Button();
            this.errorCheck = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(711, 360);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.cancelButton);
            this.flowLayoutPanel1.Controls.Add(this.submitButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(559, 322);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(149, 36);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.AutoSize = true;
            this.cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(3, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(68, 30);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // submitButton
            // 
            this.submitButton.AutoSize = true;
            this.submitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.submitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.submitButton.Location = new System.Drawing.Point(77, 3);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(69, 30);
            this.submitButton.TabIndex = 1;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.splitContainer1, 2);
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 2);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.referenceList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.modDepsList);
            this.splitContainer1.Size = new System.Drawing.Size(705, 316);
            this.splitContainer1.SplitterDistance = 185;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // referenceList
            // 
            this.referenceList.CheckBoxes = true;
            this.referenceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.folderNameHeader,
            this.fileNameHeader});
            this.referenceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.referenceList.HideSelection = false;
            this.referenceList.Location = new System.Drawing.Point(0, 0);
            this.referenceList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.referenceList.Name = "referenceList";
            this.referenceList.Size = new System.Drawing.Size(705, 185);
            this.referenceList.TabIndex = 0;
            this.referenceList.UseCompatibleStateImageBehavior = false;
            this.referenceList.View = System.Windows.Forms.View.Details;
            // 
            // folderNameHeader
            // 
            this.folderNameHeader.Text = "Mod Folder Name";
            this.folderNameHeader.Width = 300;
            // 
            // fileNameHeader
            // 
            this.fileNameHeader.Text = "File Name";
            this.fileNameHeader.Width = 615;
            // 
            // modDepsList
            // 
            this.modDepsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.modlinkNameHeader,
            this.modAliasHeader,
            this.modDownloadHeader});
            this.modDepsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modDepsList.HideSelection = false;
            this.modDepsList.Location = new System.Drawing.Point(0, 0);
            this.modDepsList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.modDepsList.Name = "modDepsList";
            this.modDepsList.Size = new System.Drawing.Size(705, 128);
            this.modDepsList.TabIndex = 0;
            this.modDepsList.UseCompatibleStateImageBehavior = false;
            this.modDepsList.View = System.Windows.Forms.View.Details;
            // 
            // modlinkNameHeader
            // 
            this.modlinkNameHeader.Text = "ModLinks Name";
            this.modlinkNameHeader.Width = 300;
            // 
            // modAliasHeader
            // 
            this.modAliasHeader.Text = "Local Alias";
            this.modAliasHeader.Width = 175;
            // 
            // modDownloadHeader
            // 
            this.modDownloadHeader.Text = "Direct Download Link";
            this.modDownloadHeader.Width = 440;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.rectifyButton);
            this.flowLayoutPanel2.Controls.Add(this.errorCheck);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 322);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(276, 36);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // rectifyButton
            // 
            this.rectifyButton.AutoSize = true;
            this.rectifyButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rectifyButton.Location = new System.Drawing.Point(3, 3);
            this.rectifyButton.Name = "rectifyButton";
            this.rectifyButton.Size = new System.Drawing.Size(153, 30);
            this.rectifyButton.TabIndex = 0;
            this.rectifyButton.Text = "Fix Inconsistencies";
            this.rectifyButton.UseVisualStyleBackColor = true;
            this.rectifyButton.Click += new System.EventHandler(this.FixInconsistencies);
            // 
            // errorCheck
            // 
            this.errorCheck.AutoSize = true;
            this.errorCheck.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.errorCheck.Location = new System.Drawing.Point(162, 3);
            this.errorCheck.Name = "errorCheck";
            this.errorCheck.Size = new System.Drawing.Size(111, 30);
            this.errorCheck.TabIndex = 1;
            this.errorCheck.Text = "Check Errors";
            this.errorCheck.UseVisualStyleBackColor = true;
            this.errorCheck.Click += new System.EventHandler(this.CheckErrors);
            // 
            // ManageModDependenciesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ManageModDependenciesForm";
            this.Text = "Manage Mod Dependencies";
            this.Load += new System.EventHandler(this.OnReady);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView referenceList;
        private System.Windows.Forms.ColumnHeader folderNameHeader;
        private System.Windows.Forms.ColumnHeader fileNameHeader;
        private System.Windows.Forms.ListView modDepsList;
        private System.Windows.Forms.ColumnHeader modlinkNameHeader;
        private System.Windows.Forms.ColumnHeader modAliasHeader;
        private System.Windows.Forms.ColumnHeader modDownloadHeader;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button rectifyButton;
        private System.Windows.Forms.Button errorCheck;
    }
}