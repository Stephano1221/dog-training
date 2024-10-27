namespace Database
{
    partial class frmCertificate
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
            this.xmsMenu = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xpbxBack = new System.Windows.Forms.PictureBox();
            this.xpbxCertificate = new System.Windows.Forms.PictureBox();
            this.xpbxSave = new System.Windows.Forms.PictureBox();
            this.xpbxPrint = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.xmsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpbxBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpbxCertificate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpbxSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpbxPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.xpbxBack, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.xpbxCertificate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.xpbxSave, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.xpbxPrint, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 29);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(576, 259);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // xmsMenu
            // 
            this.xmsMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.xmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.xmsMenu.Location = new System.Drawing.Point(0, 0);
            this.xmsMenu.Name = "xmsMenu";
            this.xmsMenu.Size = new System.Drawing.Size(600, 24);
            this.xmsMenu.TabIndex = 1;
            this.xmsMenu.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            this.menuToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.xmsMenu_DropDownItemClicked);
            // 
            // xpbxBack
            // 
            this.xpbxBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xpbxBack.Location = new System.Drawing.Point(3, 3);
            this.xpbxBack.Name = "xpbxBack";
            this.xpbxBack.Size = new System.Drawing.Size(20, 19);
            this.xpbxBack.TabIndex = 2;
            this.xpbxBack.TabStop = false;
            this.xpbxBack.Click += new System.EventHandler(this.xpbxBack_Click);
            this.xpbxBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xpbxBack_MouseDown);
            this.xpbxBack.MouseEnter += new System.EventHandler(this.xpbxBack_MouseEnter);
            this.xpbxBack.MouseLeave += new System.EventHandler(this.xpbxBack_MouseLeave);
            this.xpbxBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xpbxBack_MouseUp);
            // 
            // xpbxCertificate
            // 
            this.xpbxCertificate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.xpbxCertificate, 4);
            this.xpbxCertificate.Location = new System.Drawing.Point(3, 43);
            this.xpbxCertificate.Name = "xpbxCertificate";
            this.xpbxCertificate.Size = new System.Drawing.Size(570, 213);
            this.xpbxCertificate.TabIndex = 0;
            this.xpbxCertificate.TabStop = false;
            // 
            // xpbxSave
            // 
            this.xpbxSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xpbxSave.Location = new System.Drawing.Point(33, 3);
            this.xpbxSave.Name = "xpbxSave";
            this.xpbxSave.Size = new System.Drawing.Size(34, 34);
            this.xpbxSave.TabIndex = 3;
            this.xpbxSave.TabStop = false;
            this.xpbxSave.Click += new System.EventHandler(this.xpbxSave_Click);
            this.xpbxSave.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xpbxSave_MouseDown);
            this.xpbxSave.MouseEnter += new System.EventHandler(this.xpbxSave_MouseEnter);
            this.xpbxSave.MouseLeave += new System.EventHandler(this.xpbxSave_MouseLeave);
            this.xpbxSave.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xpbxSave_MouseUp);
            // 
            // xpbxPrint
            // 
            this.xpbxPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xpbxPrint.Location = new System.Drawing.Point(73, 3);
            this.xpbxPrint.Name = "xpbxPrint";
            this.xpbxPrint.Size = new System.Drawing.Size(34, 34);
            this.xpbxPrint.TabIndex = 3;
            this.xpbxPrint.TabStop = false;
            this.xpbxPrint.Click += new System.EventHandler(this.xpbxPrint_Click);
            this.xpbxPrint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xpbxPrint_MouseDown);
            this.xpbxPrint.MouseEnter += new System.EventHandler(this.xpbxPrint_MouseEnter);
            this.xpbxPrint.MouseLeave += new System.EventHandler(this.xpbxPrint_MouseLeave);
            this.xpbxPrint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xpbxPrint_MouseUp);
            // 
            // frmCertificate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.xmsMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.xmsMenu;
            this.MinimumSize = new System.Drawing.Size(250, 250);
            this.Name = "frmCertificate";
            this.Text = "frmCertificate";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.xmsMenu.ResumeLayout(false);
            this.xmsMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpbxBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpbxCertificate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpbxSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpbxPrint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip xmsMenu;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.PictureBox xpbxCertificate;
        private System.Windows.Forms.PictureBox xpbxBack;
        private System.Windows.Forms.PictureBox xpbxSave;
        private System.Windows.Forms.PictureBox xpbxPrint;
    }
}