using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //System.IO.StreamReader file = new System.IO.StreamReader(@"C:\\Users\\akand\\Desktop\\test.txt");
            //string data = "";
            //string line = "";

            //while ((line = file.ReadLine()) != null)
            //{
            //    data += line + "\n";
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Window A = new Window();
            //A.update_label1(data);
            Application.Run(A);
        }
    }
}
