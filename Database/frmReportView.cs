using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Database
{
    public partial class frmReportView : Form
    {
        private string entity;

        private readonly Bitmap leftArrow = Properties.Resources.leftArrow2;
        private readonly Bitmap leftArrowHover = Properties.Resources.leftArrow2Hover;
        private readonly Bitmap leftArrowClick = Properties.Resources.leftArrow2Click;

        public frmReportView(string entity)
        {
            InitializeComponent();
            this.entity = entity;
            AddMenuAndItems();
            SetupReport(null);
            xpbxBack.Image = leftArrow;
            xpbxBack.SizeMode = PictureBoxSizeMode.Zoom;
        }

        // Adds xmsMenu ToolStripMenuItem items.
        private void AddMenuAndItems()
        {
            (xmsMenu.Items[0] as ToolStripMenuItem).DropDownItems.Add("Back");
            (xmsMenu.Items[0] as ToolStripMenuItem).DropDownItems.Add("Main Menu");

        }

        // Calls the correct method when a ToolStripMenuItem is clicked.
        private void xmsMenu_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Back")
            {
                this.Close();
            }
            else if (e.ClickedItem.Text == "Main Menu")
            {
                OpenMainMenu();
            }
        }

        private void SetupReport(string searchTerm)
        {
            xrpvReportViewer.Reset();
            xrpvReportViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            DataTable dataTable;
            if (!(string.IsNullOrWhiteSpace(searchTerm)))
            {
                dataTable = DAL.SearchRecords(entity, null, null, searchTerm, null, null, true, null, false, false, false, false);
            }
            else
            {
                dataTable = DAL.LoadEntireEntity(entity);
            }
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);
            xrpvReportViewer.LocalReport.DataSources.Clear();
            for (int i = 0; i < dataSet.Tables.Count; i++)
            {
                xrpvReportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource($"DS{entity}", dataSet.Tables[i]));
            }
            //xrpvReportViewer.LocalReport.ReportPath = $@"reports\rpt{entity}.rdlc"; //Uses .rdlc file on a drive
            xrpvReportViewer.LocalReport.ReportEmbeddedResource = $@"Database.Reports.rpt{entity}.rdlc"; //Uses .rdlc file in solution
            xrpvReportViewer.RefreshReport();
        }

        //Opens the main menu
        private void OpenMainMenu()
        {
            frmMainMenu frmMainMenu = new frmMainMenu()
            {
                MdiParent = this.ParentForm,
                Dock = DockStyle.Fill,
            };
            frmMainMenu.Show();
            this.Close();
        }

        private void xtbxQuickSearch_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.ForeColor != Color.Gray)
            {
                SetupReport(textBox.Text);
            }
        }

        private void xtbxQuickSearch_Enter(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.ForeColor == Color.Gray)
            {
                textbox.ForeColor = Color.Black;
                textbox.Clear();
            }
        }

        private void xtbxQuickSearch_Leave(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textbox.Text))
            {
                textbox.ForeColor = Color.Gray;
                textbox.Text = "Quick search...";
            }
        }

        private void xpbxBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xpbxBack_MouseDown(object sender, MouseEventArgs e)
        {
            xpbxBack.Image = leftArrowClick;
        }

        private void xpbxBack_MouseEnter(object sender, EventArgs e)
        {
            xpbxBack.Image = leftArrowHover;
        }

        private void xpbxBack_MouseLeave(object sender, EventArgs e)
        {
            xpbxBack.Image = leftArrow;
        }

        private void xpbxBack_MouseUp(object sender, MouseEventArgs e)
        {
            xpbxBack.Image = leftArrow;
        }
    }
}
