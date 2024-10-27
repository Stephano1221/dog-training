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
    public partial class FrmHolder : Form
    {
        public FrmHolder()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            IsMdiContainer = true;
            frmMainMenu frmMainMenu = new frmMainMenu
            {
                MdiParent = this,
                Dock = DockStyle.Fill
            };
            frmMainMenu.Show();
        }
    }
}
