using System;
using log4net;

namespace ProyectoCraft.Base.Log
{
    public static class Log {
        public static ILog log;
        private static ILog GetLog(string logName)
        {
            if (log == null)
                log = LogManager.GetLogger(logName);
            log4net.Config.XmlConfigurator.Configure();
            return log;
        }

        public static void EscribirLog(string mensaje){
            try{
                var foo = Usuario.UsuarioConectado.Usuario.NombreUsuario;
                mensaje = string.Format("[{0}]{1}", foo, mensaje);
            }catch(Exception e){
                Console.Write(e.InnerException);
            }
            GetLog("SistemaComercialCraft").Error(mensaje);
        }
    }
}
