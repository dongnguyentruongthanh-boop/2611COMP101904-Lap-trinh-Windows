using System;
using System.Windows.Forms;

namespace Lab_6
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Khởi chạy trực tiếp Form FrmProduct
            Application.Run(new FrmProduct());
        }
    }
}