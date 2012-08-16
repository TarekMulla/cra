using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace ProyectoCraft.Base.Log
{
    public static class Log
    {
        private static ILog GetLog(string logName)
        {
            ILog log = LogManager.GetLogger(logName);
            log4net.Config.XmlConfigurator.Configure();
            return log;
        }
        public static void EscribirLog(string mensaje)
        {
            GetLog("SistemaComercialCraft").Error(mensaje);
        }

    }
}
