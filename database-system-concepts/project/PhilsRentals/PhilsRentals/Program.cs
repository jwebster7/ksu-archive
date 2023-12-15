using PhilsRentals.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhilsRentals
{
    /// <summary>
    /// Delegate for getting the selected account.
    /// </summary>
    public delegate string AccountSelector();

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /* Create controller and attach main view */
            MainWindowController mwc = new MainWindowController(); // Create controller
            MainWindow mw = new MainWindow(mwc); // Create view with controller operation handler

            Application.Run(mw);
        }
    }
}
