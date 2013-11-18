using System;
//using System.Linq;
using System.Windows.Forms;
using ProyectoCraft.Base.Log;


namespace ProyectoCraft.WinForm {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        // Set version number for the assembly.
        [STAThread]
        static void Main() {
            InicioCraft();
        }

        static void InicioCraft() {
            //try
            //{          
            log4net.Config.XmlConfigurator.Configure();
            Log.EscribirLog("Iniciando la Aplicacion....");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es");

            MDICraft mdi = MDICraft.Instancia;
            Application.Run(mdi);

            //}
            //catch (Exception ex)
            //{
            //    Base.Log.Log.EscribirLog(ex.Message);

            //}

        }



    }
}
