using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eurotrash.GrimDawn.WinFormsFrontEnd
{
    static class Program
    {
        private static object _syncRoot = new object();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;

            if (exception != null)
                ShowException(exception);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            ShowException(e.Exception);
        }

        private static void ShowException(Exception exception)
        {
            lock (_syncRoot)
            {
                var form = new Eurotrash.GrimDawn.WinFormsFrontEnd.Forms.ErrorForm();
                form.SetException(exception);

                form.ShowDialog();
            }
        }
    }
}
