namespace Database
{
    partial class frmAddEditRecord
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
            this.xtlpDetails = new System.Windows.Forms.TableLayoutPanel();
            this.xlblEnterDetails = new System.Windows.Forms.Label();
            this.xtlpDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtlpDetails
            // 
            this.xtlpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtlpDetails.ColumnCount = 1;
            this.xtlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xtlpDetails.Controls.Add(this.xlblEnterDetails, 0, 0);
            this.xtlpDetails.Location = new System.Drawing.Point(13, 13);
            this.xtlpDetails.Name = "xtlpDetails";
            this.xtlpDetails.RowCount = 1;
            this.xtlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xtlpDetails.Size = new System.Drawing.Size(267, 348);
            this.xtlpDetails.TabIndex = 0;
            // 
            // xlblEnterDetails
            // 
            this.xlblEnterDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xlblEnterDetails.AutoSize = true;
            this.xlblEnterDetails.Location = new System.Drawing.Point(3, 0);
            this.xlblEnterDetails.Name = "xlblEnterDetails";
            this.xlblEnterDetails.Size = new System.Drawing.Size(261, 13);
            this.xlblEnterDetails.TabIndex = 0;
            this.xlblEnterDetails.Text = "Enter Details";
            this.xlblEnterDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAddEditRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 373);
            this.Controls.Add(this.xtlpDetails);
            this.MinimumSize = new System.Drawing.Size(300, 400);
            this.Name = "frmAddEditRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Dog";
            this.xtlpDetails.ResumeLayout(false);
            this.xtlpDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel xtlpDetails;
        private System.Windows.Forms.Label xlblEnterDetails;
    }
}