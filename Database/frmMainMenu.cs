using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void ViewTables(string entity1, string entity2)
        {
            frmViewTables frmViewTables = new frmViewTables(entity1, entity2)
            {
                MdiParent = this.ParentForm,
                Dock = DockStyle.Fill,
            };
            if (frmViewTables.loaded == true)
            {
                frmViewTables.Show();
                this.Close();
            }
        }

        private void xbtnDogs_Click(object sender, EventArgs e)
        {
            ViewTables("Dog", "Class");
        }

        private void xbtnCustomers_Click(object sender, EventArgs e)
        {
            ViewTables("Customer", "Dog");
        }

        private void xbtnSessions_Click(object sender, EventArgs e)
        {
            ViewTables("Session", null); //Class?
        }

        private void xbtnClasses_Click(object sender, EventArgs e)
        {
            ViewTables("Class", "Dog");
        }

        private void xbtnProgrammes_Click(object sender, EventArgs e)
        {
            ViewTables("Programme", "Class");
        }
    }
}
