using System;
using System.Collections.Generic;
//using System.Linq;
using System.Reflection;
using System.Windows.Forms;


namespace ProyectoCraft.WinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        // Set version number for the assembly.
        [STAThread]
        static void Main()
        {
            //try
            //{          
                log4net.Config.XmlConfigurator.Configure();
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
