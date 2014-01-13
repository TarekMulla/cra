using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ProyectoCraft.WinForm.Utils
{
    public static class Outlook
    {
        public static bool VerificarOutlookAbierto()
        {
            bool resultado = false;
            bool OutloookAbierto = false;

            try
            {
                Process[] processes = Process.GetProcesses();

                foreach (Process process in processes)
                {
                    if (process.ProcessName.ToUpper() == "OUTLOOK")
                    {
                        OutloookAbierto = true;
                        resultado = true;
                        break;
                    }                        
                }  

                if(!OutloookAbierto)
                {                    
                    ProcessStartInfo procesInfo = new ProcessStartInfo("OUTLOOK");
                    procesInfo.CreateNoWindow = true;
                    procesInfo.WindowStyle = ProcessWindowStyle.Minimized;

                    Process.Start(procesInfo);

                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Base.Log.Log.EscribirLog(ex.Message);
            }

            return resultado;

        }


    }
}
