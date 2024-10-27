namespace Database
{
    partial class frmSearch
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
            this.xtlpSearch = new System.Windows.Forms.TableLayoutPanel();
            this.xlblSearchDog = new System.Windows.Forms.Label();
            this.xlblError = new System.Windows.Forms.Label();
            this.xbtnSearch = new System.Windows.Forms.Button();
            this.xlblName = new System.Windows.Forms.Label();
            this.xtbxName = new System.Windows.Forms.TextBox();
            this.xcbxColumn = new System.Windows.Forms.ComboBox();
            this.xlblColumn = new System.Windows.Forms.Label();
            this.xtlpSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtlpSearch
            // 
            this.xtlpSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtlpSearch.ColumnCount = 1;
            this.xtlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xtlpSearch.Controls.Add(this.xlblSearchDog, 0, 0);
            this.xtlpSearch.Controls.Add(this.xlblError, 0, 6);
            this.xtlpSearch.Controls.Add(this.xbtnSearch, 0, 7);
            this.xtlpSearch.Controls.Add(this.xlblName, 0, 3);
            this.xtlpSearch.Controls.Add(this.xtbxName, 0, 4);
            this.xtlpSearch.Controls.Add(this.xcbxColumn, 0, 2);
            this.xtlpSearch.Controls.Add(this.xlblColumn, 0, 1);
            this.xtlpSearch.Location = new System.Drawing.Point(13, 12);
            this.xtlpSearch.Name = "xtlpSearch";
            this.xtlpSearch.RowCount = 8;
            this.xtlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.xtlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.xtlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.xtlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.xtlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.xtlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.xtlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.xtlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.xtlpSearch.Size = new System.Drawing.Size(259, 249);
            this.xtlpSearch.TabIndex = 0;
            // 
            // xlblSearchDog
            // 
            this.xlblSearchDog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xlblSearchDog.AutoSize = true;
            this.xlblSearchDog.Location = new System.Drawing.Point(3, 0);
            this.xlblSearchDog.Name = "xlblSearchDog";
            this.xlblSearchDog.Size = new System.Drawing.Size(253, 13);
            this.xlblSearchDog.TabIndex = 1;
            this.xlblSearchDog.Text = "Search Dogs";
            this.xlblSearchDog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xlblError
            // 
            this.xlblError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.xlblError.AutoSize = true;
            this.xlblError.ForeColor = System.Drawing.Color.Red;
            this.xlblError.Location = new System.Drawing.Point(3, 177);
            this.xlblError.Name = "xlblError";
            this.xlblError.Size = new System.Drawing.Size(29, 13);
            this.xlblError.TabIndex = 2;
            this.xlblError.Text = "Error";
            // 
            // xbtnSearch
            // 
            this.xbtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xbtnSearch.Location = new System.Drawing.Point(3, 193);
            this.xbtnSearch.Name = "xbtnSearch";
            this.xbtnSearch.Size = new System.Drawing.Size(253, 53);
            this.xbtnSearch.TabIndex = 1;
            this.xbtnSearch.Text = "Search";
            this.xbtnSearch.UseVisualStyleBackColor = true;
            this.xbtnSearch.Click += new System.EventHandler(this.XbtnSearch_Click);
            // 
            // xlblName
            // 
            this.xlblName.AutoSize = true;
            this.xlblName.Location = new System.Drawing.Point(3, 90);
            this.xlblName.Name = "xlblName";
            this.xlblName.Size = new System.Drawing.Size(35, 13);
            this.xlblName.TabIndex = 3;
            this.xlblName.Text = "Name";
            // 
            // xtbxName
            // 
            this.xtbxName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtbxName.Location = new System.Drawing.Point(3, 113);
            this.xtbxName.Name = "xtbxName";
            this.xtbxName.Size = new System.Drawing.Size(253, 20);
            this.xtbxName.TabIndex = 0;
            // 
            // xcbxColumn
            // 
            this.xcbxColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xcbxColumn.FormattingEnabled = true;
            this.xcbxColumn.Location = new System.Drawing.Point(3, 58);
            this.xcbxColumn.Name = "xcbxColumn";
            this.xcbxColumn.Size = new System.Drawing.Size(253, 21);
            this.xcbxColumn.TabIndex = 4;
            // 
            // xlblColumn
            // 
            this.xlblColumn.AutoSize = true;
            this.xlblColumn.Location = new System.Drawing.Point(3, 35);
            this.xlblColumn.Name = "xlblColumn";
            this.xlblColumn.Size = new System.Drawing.Size(42, 13);
            this.xlblColumn.TabIndex = 6;
            this.xlblColumn.Text = "Column";
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.xtlpSearch);
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "frmSearch";
            this.Text = "Search Dog Name";
            this.xtlpSearch.ResumeLayout(false);
            this.xtlpSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel xtlpSearch;
        private System.Windows.Forms.TextBox xtbxName;
        private System.Windows.Forms.Button xbtnSearch;
        private System.Windows.Forms.Label xlblError;
        private System.Windows.Forms.Label xlblName;
        private System.Windows.Forms.Label xlblSearchDog;
        private System.Windows.Forms.ComboBox xcbxColumn;
        private System.Windows.Forms.Label xlblColumn;
    }
}