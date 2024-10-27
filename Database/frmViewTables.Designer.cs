namespace Database
{
    partial class frmViewTables
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
            this.xmsMenu = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xtlpEntities = new System.Windows.Forms.TableLayoutPanel();
            this.xpbxBack = new System.Windows.Forms.PictureBox();
            this.xbtnDeleteEntity0 = new System.Windows.Forms.Button();
            this.xdgvEntity0 = new System.Windows.Forms.DataGridView();
            this.xbtnEditEntity0 = new System.Windows.Forms.Button();
            this.xbtnAddEntity0 = new System.Windows.Forms.Button();
            this.xdgvEntity1 = new System.Windows.Forms.DataGridView();
            this.xbtnAddEntity1 = new System.Windows.Forms.Button();
            this.xbtnEditEntity1 = new System.Windows.Forms.Button();
            this.xbtnDeleteEntity1 = new System.Windows.Forms.Button();
            this.xbtnLinkLeft = new System.Windows.Forms.Button();
            this.xcbxLinkedRecordsEntity1 = new System.Windows.Forms.CheckBox();
            this.xtbxQuickSearchEntity0 = new System.Windows.Forms.TextBox();
            this.xtbxQuickSearchEntity1 = new System.Windows.Forms.TextBox();
            this.xcbxLinkedRecordsEntity0 = new System.Windows.Forms.CheckBox();
            this.xcbxAllLinkedEntity0 = new System.Windows.Forms.CheckBox();
            this.xcbxAllLinkedEntity1 = new System.Windows.Forms.CheckBox();
            this.xlblEntityName0 = new System.Windows.Forms.Label();
            this.xlblEntityName1 = new System.Windows.Forms.Label();
            this.xpbxHideEntity1 = new System.Windows.Forms.PictureBox();
            this.xmsMenu.SuspendLayout();
            this.xtlpEntities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpbxBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xdgvEntity0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xdgvEntity1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpbxHideEntity1)).BeginInit();
            this.SuspendLayout();
            // 
            // xmsMenu
            // 
            this.xmsMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.xmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.xmsMenu.Location = new System.Drawing.Point(0, 0);
            this.xmsMenu.Name = "xmsMenu";
            this.xmsMenu.Size = new System.Drawing.Size(600, 24);
            this.xmsMenu.TabIndex = 0;
            this.xmsMenu.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            this.menuToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.xmsMenu_DropDownItemClicked);
            // 
            // xtlpEntities
            // 
            this.xtlpEntities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtlpEntities.ColumnCount = 7;
            this.xtlpEntities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66681F));
            this.xtlpEntities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.6668F));
            this.xtlpEntities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66681F));
            this.xtlpEntities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.xtlpEntities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66514F));
            this.xtlpEntities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66514F));
            this.xtlpEntities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66931F));
            this.xtlpEntities.Controls.Add(this.xpbxBack, 0, 0);
            this.xtlpEntities.Controls.Add(this.xbtnDeleteEntity0, 2, 4);
            this.xtlpEntities.Controls.Add(this.xdgvEntity0, 0, 3);
            this.xtlpEntities.Controls.Add(this.xbtnEditEntity0, 1, 4);
            this.xtlpEntities.Controls.Add(this.xbtnAddEntity0, 0, 4);
            this.xtlpEntities.Controls.Add(this.xdgvEntity1, 4, 3);
            this.xtlpEntities.Controls.Add(this.xbtnAddEntity1, 4, 4);
            this.xtlpEntities.Controls.Add(this.xbtnEditEntity1, 5, 4);
            this.xtlpEntities.Controls.Add(this.xbtnDeleteEntity1, 6, 4);
            this.xtlpEntities.Controls.Add(this.xbtnLinkLeft, 3, 3);
            this.xtlpEntities.Controls.Add(this.xcbxLinkedRecordsEntity1, 4, 2);
            this.xtlpEntities.Controls.Add(this.xtbxQuickSearchEntity0, 0, 1);
            this.xtlpEntities.Controls.Add(this.xtbxQuickSearchEntity1, 4, 1);
            this.xtlpEntities.Controls.Add(this.xcbxLinkedRecordsEntity0, 1, 2);
            this.xtlpEntities.Controls.Add(this.xcbxAllLinkedEntity0, 0, 2);
            this.xtlpEntities.Controls.Add(this.xcbxAllLinkedEntity1, 6, 2);
            this.xtlpEntities.Controls.Add(this.xlblEntityName0, 1, 0);
            this.xtlpEntities.Controls.Add(this.xlblEntityName1, 5, 0);
            this.xtlpEntities.Controls.Add(this.xpbxHideEntity1, 6, 0);
            this.xtlpEntities.Location = new System.Drawing.Point(12, 29);
            this.xtlpEntities.Name = "xtlpEntities";
            this.xtlpEntities.RowCount = 5;
            this.xtlpEntities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.xtlpEntities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.xtlpEntities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.xtlpEntities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xtlpEntities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.xtlpEntities.Size = new System.Drawing.Size(576, 259);
            this.xtlpEntities.TabIndex = 2;
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
            // xbtnDeleteEntity0
            // 
            this.xbtnDeleteEntity0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xbtnDeleteEntity0.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xbtnDeleteEntity0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xbtnDeleteEntity0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xbtnDeleteEntity0.Location = new System.Drawing.Point(181, 227);
            this.xbtnDeleteEntity0.Name = "xbtnDeleteEntity0";
            this.xbtnDeleteEntity0.Size = new System.Drawing.Size(83, 29);
            this.xbtnDeleteEntity0.TabIndex = 4;
            this.xbtnDeleteEntity0.Text = "Delete";
            this.xbtnDeleteEntity0.UseVisualStyleBackColor = false;
            this.xbtnDeleteEntity0.Click += new System.EventHandler(this.xbtnDeleteEntity0_Click);
            // 
            // xdgvEntity0
            // 
            this.xdgvEntity0.AllowUserToAddRows = false;
            this.xdgvEntity0.AllowUserToDeleteRows = false;
            this.xdgvEntity0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xdgvEntity0.BackgroundColor = System.Drawing.Color.DarkGray;
            this.xdgvEntity0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xtlpEntities.SetColumnSpan(this.xdgvEntity0, 3);
            this.xdgvEntity0.Location = new System.Drawing.Point(3, 78);
            this.xdgvEntity0.Name = "xdgvEntity0";
            this.xdgvEntity0.ReadOnly = true;
            this.xdgvEntity0.Size = new System.Drawing.Size(261, 143);
            this.xdgvEntity0.TabIndex = 1;
            this.xdgvEntity0.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.xdgvEntity0_DataBindingComplete);
            this.xdgvEntity0.SelectionChanged += new System.EventHandler(this.xdgvEntity_SelectionChanged);
            // 
            // xbtnEditEntity0
            // 
            this.xbtnEditEntity0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xbtnEditEntity0.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xbtnEditEntity0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xbtnEditEntity0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xbtnEditEntity0.Location = new System.Drawing.Point(92, 227);
            this.xbtnEditEntity0.Name = "xbtnEditEntity0";
            this.xbtnEditEntity0.Size = new System.Drawing.Size(83, 29);
            this.xbtnEditEntity0.TabIndex = 3;
            this.xbtnEditEntity0.Text = "Edit";
            this.xbtnEditEntity0.UseVisualStyleBackColor = false;
            this.xbtnEditEntity0.Click += new System.EventHandler(this.xbtnEditEntity0_Click);
            // 
            // xbtnAddEntity0
            // 
            this.xbtnAddEntity0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xbtnAddEntity0.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xbtnAddEntity0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xbtnAddEntity0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xbtnAddEntity0.Location = new System.Drawing.Point(3, 227);
            this.xbtnAddEntity0.Name = "xbtnAddEntity0";
            this.xbtnAddEntity0.Size = new System.Drawing.Size(83, 29);
            this.xbtnAddEntity0.TabIndex = 2;
            this.xbtnAddEntity0.Text = "Add";
            this.xbtnAddEntity0.UseVisualStyleBackColor = false;
            this.xbtnAddEntity0.Click += new System.EventHandler(this.xbtnAddEntity0_Click);
            // 
            // xdgvEntity1
            // 
            this.xdgvEntity1.AllowUserToAddRows = false;
            this.xdgvEntity1.AllowUserToDeleteRows = false;
            this.xdgvEntity1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xdgvEntity1.BackgroundColor = System.Drawing.Color.DarkGray;
            this.xdgvEntity1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xtlpEntities.SetColumnSpan(this.xdgvEntity1, 3);
            this.xdgvEntity1.Location = new System.Drawing.Point(310, 78);
            this.xdgvEntity1.Name = "xdgvEntity1";
            this.xdgvEntity1.ReadOnly = true;
            this.xdgvEntity1.Size = new System.Drawing.Size(263, 143);
            this.xdgvEntity1.TabIndex = 5;
            this.xdgvEntity1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.xdgvEntity1_DataBindingComplete);
            this.xdgvEntity1.SelectionChanged += new System.EventHandler(this.xdgvEntity_SelectionChanged);
            // 
            // xbtnAddEntity1
            // 
            this.xbtnAddEntity1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xbtnAddEntity1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xbtnAddEntity1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xbtnAddEntity1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xbtnAddEntity1.Location = new System.Drawing.Point(310, 227);
            this.xbtnAddEntity1.Name = "xbtnAddEntity1";
            this.xbtnAddEntity1.Size = new System.Drawing.Size(83, 29);
            this.xbtnAddEntity1.TabIndex = 6;
            this.xbtnAddEntity1.Text = "Add";
            this.xbtnAddEntity1.UseVisualStyleBackColor = false;
            this.xbtnAddEntity1.Click += new System.EventHandler(this.xbtnAddEntity1_Click);
            // 
            // xbtnEditEntity1
            // 
            this.xbtnEditEntity1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xbtnEditEntity1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xbtnEditEntity1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xbtnEditEntity1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xbtnEditEntity1.Location = new System.Drawing.Point(399, 227);
            this.xbtnEditEntity1.Name = "xbtnEditEntity1";
            this.xbtnEditEntity1.Size = new System.Drawing.Size(83, 29);
            this.xbtnEditEntity1.TabIndex = 7;
            this.xbtnEditEntity1.Text = "Edit";
            this.xbtnEditEntity1.UseVisualStyleBackColor = false;
            this.xbtnEditEntity1.Click += new System.EventHandler(this.xbtnEditEntity1_Click);
            // 
            // xbtnDeleteEntity1
            // 
            this.xbtnDeleteEntity1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xbtnDeleteEntity1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xbtnDeleteEntity1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xbtnDeleteEntity1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xbtnDeleteEntity1.Location = new System.Drawing.Point(488, 227);
            this.xbtnDeleteEntity1.Name = "xbtnDeleteEntity1";
            this.xbtnDeleteEntity1.Size = new System.Drawing.Size(85, 29);
            this.xbtnDeleteEntity1.TabIndex = 8;
            this.xbtnDeleteEntity1.Text = "Delete";
            this.xbtnDeleteEntity1.UseVisualStyleBackColor = false;
            this.xbtnDeleteEntity1.Click += new System.EventHandler(this.xbtnDeleteEntity1_Click);
            // 
            // xbtnLinkLeft
            // 
            this.xbtnLinkLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.xbtnLinkLeft.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xbtnLinkLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xbtnLinkLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xbtnLinkLeft.Location = new System.Drawing.Point(270, 138);
            this.xbtnLinkLeft.Name = "xbtnLinkLeft";
            this.xbtnLinkLeft.Size = new System.Drawing.Size(34, 23);
            this.xbtnLinkLeft.TabIndex = 9;
            this.xbtnLinkLeft.Text = "<";
            this.xbtnLinkLeft.UseVisualStyleBackColor = false;
            this.xbtnLinkLeft.Click += new System.EventHandler(this.xbtnLinkLeft_Click);
            // 
            // xcbxLinkedRecordsEntity1
            // 
            this.xcbxLinkedRecordsEntity1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xcbxLinkedRecordsEntity1.AutoSize = true;
            this.xtlpEntities.SetColumnSpan(this.xcbxLinkedRecordsEntity1, 2);
            this.xcbxLinkedRecordsEntity1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xcbxLinkedRecordsEntity1.Location = new System.Drawing.Point(310, 53);
            this.xcbxLinkedRecordsEntity1.Name = "xcbxLinkedRecordsEntity1";
            this.xcbxLinkedRecordsEntity1.Size = new System.Drawing.Size(172, 17);
            this.xcbxLinkedRecordsEntity1.TabIndex = 11;
            this.xcbxLinkedRecordsEntity1.Text = "Only linked records";
            this.xcbxLinkedRecordsEntity1.UseVisualStyleBackColor = true;
            this.xcbxLinkedRecordsEntity1.CheckedChanged += new System.EventHandler(this.xcbxLinkedRecords_CheckedChanged);
            // 
            // xtbxQuickSearchEntity0
            // 
            this.xtbxQuickSearchEntity0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtlpEntities.SetColumnSpan(this.xtbxQuickSearchEntity0, 3);
            this.xtbxQuickSearchEntity0.ForeColor = System.Drawing.Color.Gray;
            this.xtbxQuickSearchEntity0.Location = new System.Drawing.Point(3, 28);
            this.xtbxQuickSearchEntity0.Name = "xtbxQuickSearchEntity0";
            this.xtbxQuickSearchEntity0.Size = new System.Drawing.Size(261, 20);
            this.xtbxQuickSearchEntity0.TabIndex = 12;
            this.xtbxQuickSearchEntity0.Text = "Quick search...";
            this.xtbxQuickSearchEntity0.TextChanged += new System.EventHandler(this.xtbxQuickSearch_TextChanged);
            this.xtbxQuickSearchEntity0.Enter += new System.EventHandler(this.xtbxQuickSearch_Enter);
            this.xtbxQuickSearchEntity0.Leave += new System.EventHandler(this.xtbxQuickSearch_Leave);
            // 
            // xtbxQuickSearchEntity1
            // 
            this.xtbxQuickSearchEntity1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtlpEntities.SetColumnSpan(this.xtbxQuickSearchEntity1, 3);
            this.xtbxQuickSearchEntity1.ForeColor = System.Drawing.Color.Gray;
            this.xtbxQuickSearchEntity1.Location = new System.Drawing.Point(310, 28);
            this.xtbxQuickSearchEntity1.Name = "xtbxQuickSearchEntity1";
            this.xtbxQuickSearchEntity1.Size = new System.Drawing.Size(263, 20);
            this.xtbxQuickSearchEntity1.TabIndex = 13;
            this.xtbxQuickSearchEntity1.Text = "Quick search...";
            this.xtbxQuickSearchEntity1.TextChanged += new System.EventHandler(this.xtbxQuickSearch_TextChanged);
            this.xtbxQuickSearchEntity1.Enter += new System.EventHandler(this.xtbxQuickSearch_Enter);
            this.xtbxQuickSearchEntity1.Leave += new System.EventHandler(this.xtbxQuickSearch_Leave);
            // 
            // xcbxLinkedRecordsEntity0
            // 
            this.xcbxLinkedRecordsEntity0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xcbxLinkedRecordsEntity0.AutoSize = true;
            this.xcbxLinkedRecordsEntity0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.xtlpEntities.SetColumnSpan(this.xcbxLinkedRecordsEntity0, 2);
            this.xcbxLinkedRecordsEntity0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xcbxLinkedRecordsEntity0.Location = new System.Drawing.Point(92, 53);
            this.xcbxLinkedRecordsEntity0.Name = "xcbxLinkedRecordsEntity0";
            this.xcbxLinkedRecordsEntity0.Size = new System.Drawing.Size(172, 17);
            this.xcbxLinkedRecordsEntity0.TabIndex = 10;
            this.xcbxLinkedRecordsEntity0.Text = "Only linked records";
            this.xcbxLinkedRecordsEntity0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.xcbxLinkedRecordsEntity0.UseVisualStyleBackColor = true;
            this.xcbxLinkedRecordsEntity0.CheckedChanged += new System.EventHandler(this.xcbxLinkedRecords_CheckedChanged);
            // 
            // xcbxAllLinkedEntity0
            // 
            this.xcbxAllLinkedEntity0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xcbxAllLinkedEntity0.AutoSize = true;
            this.xcbxAllLinkedEntity0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xcbxAllLinkedEntity0.Location = new System.Drawing.Point(3, 53);
            this.xcbxAllLinkedEntity0.Name = "xcbxAllLinkedEntity0";
            this.xcbxAllLinkedEntity0.Size = new System.Drawing.Size(83, 17);
            this.xcbxAllLinkedEntity0.TabIndex = 14;
            this.xcbxAllLinkedEntity0.Text = "All linked";
            this.xcbxAllLinkedEntity0.UseVisualStyleBackColor = true;
            this.xcbxAllLinkedEntity0.CheckedChanged += new System.EventHandler(this.xcbxLinkedRecords_CheckedChanged);
            // 
            // xcbxAllLinkedEntity1
            // 
            this.xcbxAllLinkedEntity1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xcbxAllLinkedEntity1.AutoSize = true;
            this.xcbxAllLinkedEntity1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.xcbxAllLinkedEntity1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xcbxAllLinkedEntity1.Location = new System.Drawing.Point(488, 53);
            this.xcbxAllLinkedEntity1.Name = "xcbxAllLinkedEntity1";
            this.xcbxAllLinkedEntity1.Size = new System.Drawing.Size(85, 17);
            this.xcbxAllLinkedEntity1.TabIndex = 15;
            this.xcbxAllLinkedEntity1.Text = "All linked";
            this.xcbxAllLinkedEntity1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.xcbxAllLinkedEntity1.UseVisualStyleBackColor = true;
            this.xcbxAllLinkedEntity1.CheckedChanged += new System.EventHandler(this.xcbxLinkedRecords_CheckedChanged);
            // 
            // xlblEntityName0
            // 
            this.xlblEntityName0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xlblEntityName0.AutoSize = true;
            this.xlblEntityName0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xlblEntityName0.Location = new System.Drawing.Point(92, 9);
            this.xlblEntityName0.Name = "xlblEntityName0";
            this.xlblEntityName0.Size = new System.Drawing.Size(83, 16);
            this.xlblEntityName0.TabIndex = 16;
            this.xlblEntityName0.Text = "Entity0";
            this.xlblEntityName0.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // xlblEntityName1
            // 
            this.xlblEntityName1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xlblEntityName1.AutoSize = true;
            this.xlblEntityName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xlblEntityName1.Location = new System.Drawing.Point(399, 9);
            this.xlblEntityName1.Name = "xlblEntityName1";
            this.xlblEntityName1.Size = new System.Drawing.Size(83, 16);
            this.xlblEntityName1.TabIndex = 17;
            this.xlblEntityName1.Text = "Entity1";
            this.xlblEntityName1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // xpbxHideEntity1
            // 
            this.xpbxHideEntity1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xpbxHideEntity1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xpbxHideEntity1.Location = new System.Drawing.Point(553, 3);
            this.xpbxHideEntity1.Name = "xpbxHideEntity1";
            this.xpbxHideEntity1.Size = new System.Drawing.Size(20, 19);
            this.xpbxHideEntity1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.xpbxHideEntity1.TabIndex = 3;
            this.xpbxHideEntity1.TabStop = false;
            this.xpbxHideEntity1.Click += new System.EventHandler(this.xpbxHideEntity1_Click);
            this.xpbxHideEntity1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xpbxHideEntity1_MouseDown);
            this.xpbxHideEntity1.MouseEnter += new System.EventHandler(this.xpbxHideEntity1_MouseEnter);
            this.xpbxHideEntity1.MouseLeave += new System.EventHandler(this.xpbxHideEntity1_MouseLeave);
            this.xpbxHideEntity1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xpbxHideEntity1_MouseUp);
            // 
            // frmViewTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.Controls.Add(this.xtlpEntities);
            this.Controls.Add(this.xmsMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.xmsMenu;
            this.MinimumSize = new System.Drawing.Size(250, 250);
            this.Name = "frmViewTables";
            this.Text = "Tables";
            this.xmsMenu.ResumeLayout(false);
            this.xmsMenu.PerformLayout();
            this.xtlpEntities.ResumeLayout(false);
            this.xtlpEntities.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpbxBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xdgvEntity0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xdgvEntity1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpbxHideEntity1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip xmsMenu;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel xtlpEntities;
        private System.Windows.Forms.Button xbtnAddEntity0;
        private System.Windows.Forms.Button xbtnEditEntity0;
        private System.Windows.Forms.Button xbtnDeleteEntity0;
        private System.Windows.Forms.DataGridView xdgvEntity0;
        private System.Windows.Forms.DataGridView xdgvEntity1;
        private System.Windows.Forms.Button xbtnAddEntity1;
        private System.Windows.Forms.Button xbtnEditEntity1;
        private System.Windows.Forms.Button xbtnDeleteEntity1;
        private System.Windows.Forms.Button xbtnLinkLeft;
        private System.Windows.Forms.CheckBox xcbxLinkedRecordsEntity0;
        private System.Windows.Forms.CheckBox xcbxLinkedRecordsEntity1;
        private System.Windows.Forms.TextBox xtbxQuickSearchEntity0;
        private System.Windows.Forms.TextBox xtbxQuickSearchEntity1;
        private System.Windows.Forms.CheckBox xcbxAllLinkedEntity0;
        private System.Windows.Forms.CheckBox xcbxAllLinkedEntity1;
        private System.Windows.Forms.PictureBox xpbxBack;
        private System.Windows.Forms.Label xlblEntityName0;
        private System.Windows.Forms.Label xlblEntityName1;
        private System.Windows.Forms.PictureBox xpbxHideEntity1;
    }
}

