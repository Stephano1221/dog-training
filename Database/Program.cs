using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //SetupDataDirectoryPath();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmHolder());
        }

        private static void SetupDataDirectoryPath()
        {
            string path = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(Environment.CurrentDirectory));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
        }
    }
}
