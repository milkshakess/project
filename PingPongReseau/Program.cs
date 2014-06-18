using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PingPongReseau
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            login Auth = new login();

            if (Auth.ShowDialog() == DialogResult.OK)
            {
                FormPrincipal MainForm = new FormPrincipal();
                Application.Run(new FormPrincipal());
            }
        }
    }
}
