namespace Database
{
    partial class frmReportView
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DatabaseDataSet = new Database.DatabaseDataSet();
            this.xrpvReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.xtlpReportViewer = new System.Windows.Forms.TableLayoutPanel();
            this.xpbxBack = new System.Windows.Forms.PictureBox();
            this.xtbxQuickSearch = new System.Windows.Forms.TextBox();
            this.xmsMenu = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DatabaseDataSet)).BeginInit();
            this.xtlpReportViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpbxBack)).BeginInit();
            this.xmsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // DatabaseDataSet
            // 
            this.DatabaseDataSet.DataSetName = "DatabaseDataSet";
            this.DatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // xrpvReportViewer
            // 
            this.xrpvReportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xrpvReportViewer.DocumentMapWidth = 92;
            reportDataSource1.Name = "DSClass";
            reportDataSource1.Value = null;
            reportDataSource2.Name = "DSCustomer";
            reportDataSource2.Value = null;
            reportDataSource3.Name = "DSDog";
            reportDataSource3.Value = null;
            reportDataSource4.Name = "DSProgramme";
            reportDataSource4.Value = null;
            reportDataSource5.Name = "DSSession";
            reportDataSource5.Value = null;
            this.xrpvReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.xrpvReportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.xrpvReportViewer.LocalReport.DataSources.Add(reportDataSource3);
            this.xrpvReportViewer.LocalReport.DataSources.Add(reportDataSource4);
            this.xrpvReportViewer.LocalReport.DataSources.Add(reportDataSource5);
            this.xrpvReportViewer.Location = new System.Drawing.Point(3, 53);
            this.xrpvReportViewer.Name = "xrpvReportViewer";
            this.xrpvReportViewer.Size = new System.Drawing.Size(570, 203);
            this.xrpvReportViewer.TabIndex = 0;
            // 
            // xtlpReportViewer
            // 
            this.xtlpReportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtlpReportViewer.ColumnCount = 1;
            this.xtlpReportViewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xtlpReportViewer.Controls.Add(this.xpbxBack, 0, 0);
            this.xtlpReportViewer.Controls.Add(this.xtbxQuickSearch, 0, 1);
            this.xtlpReportViewer.Controls.Add(this.xrpvReportViewer, 0, 2);
            this.xtlpReportViewer.Location = new System.Drawing.Point(12, 29);
            this.xtlpReportViewer.Name = "xtlpReportViewer";
            this.xtlpReportViewer.RowCount = 3;
            this.xtlpReportViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.xtlpReportViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.xtlpReportViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xtlpReportViewer.Size = new System.Drawing.Size(576, 259);
            this.xtlpReportViewer.TabIndex = 1;
            // 
            // xpbxBack
            // 
            this.xpbxBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xpbxBack.Location = new System.Drawing.Point(3, 3);
            this.xpbxBack.Name = "xpbxBack";
            this.xpbxBack.Size = new System.Drawing.Size(20, 19);
            this.xpbxBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.xpbxBack.TabIndex = 3;
            this.xpbxBack.TabStop = false;
            this.xpbxBack.Click += new System.EventHandler(this.xpbxBack_Click);
            this.xpbxBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xpbxBack_MouseDown);
            this.xpbxBack.MouseEnter += new System.EventHandler(this.xpbxBack_MouseEnter);
            this.xpbxBack.MouseLeave += new System.EventHandler(this.xpbxBack_MouseLeave);
            this.xpbxBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xpbxBack_MouseUp);
            // 
            // xtbxQuickSearch
            // 
            this.xtbxQuickSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtbxQuickSearch.ForeColor = System.Drawing.Color.Gray;
            this.xtbxQuickSearch.Location = new System.Drawing.Point(3, 28);
            this.xtbxQuickSearch.Name = "xtbxQuickSearch";
            this.xtbxQuickSearch.Size = new System.Drawing.Size(570, 20);
            this.xtbxQuickSearch.TabIndex = 1;
            this.xtbxQuickSearch.Text = "Quick search...";
            this.xtbxQuickSearch.TextChanged += new System.EventHandler(this.xtbxQuickSearch_TextChanged);
            this.xtbxQuickSearch.Enter += new System.EventHandler(this.xtbxQuickSearch_Enter);
            this.xtbxQuickSearch.Leave += new System.EventHandler(this.xtbxQuickSearch_Leave);
            // 
            // xmsMenu
            // 
            this.xmsMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.xmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.xmsMenu.Location = new System.Drawing.Point(0, 0);
            this.xmsMenu.Name = "xmsMenu";
            this.xmsMenu.Size = new System.Drawing.Size(600, 24);
            this.xmsMenu.TabIndex = 2;
            this.xmsMenu.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            this.menuToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.xmsMenu_DropDownItemClicked);
            // 
            // frmReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.Controls.Add(this.xtlpReportViewer);
            this.Controls.Add(this.xmsMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.xmsMenu;
            this.MinimumSize = new System.Drawing.Size(250, 250);
            this.Name = "frmReportView";
            this.Text = "Report View";
            ((System.ComponentModel.ISupportInitialize)(this.DatabaseDataSet)).EndInit();
            this.xtlpReportViewer.ResumeLayout(false);
            this.xtlpReportViewer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpbxBack)).EndInit();
            this.xmsMenu.ResumeLayout(false);
            this.xmsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer xrpvReportViewer;
        private System.Windows.Forms.TableLayoutPanel xtlpReportViewer;
        private System.Windows.Forms.MenuStrip xmsMenu;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private DatabaseDataSet DatabaseDataSet;
        private System.Windows.Forms.TextBox xtbxQuickSearch;
        private System.Windows.Forms.PictureBox xpbxBack;
    }
}