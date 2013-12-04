using System;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.Entidades.Log {
    /// <summary>
    /// Clase para registrar los tiempos que se demora algunas actividades en el sistema.
    /// </summary>
    public class LogPerformance : IdentifiableObject {
        public LogPerformance(Usuarios.clsUsuario usuario,Double tiempo) {
            Usuario = usuario;
            Tiempo = tiempo;
        }
        public LogPerformance(Usuarios.clsUsuario usuario, Double tiempo,String accion) {
            Usuario = usuario;
            Tiempo = tiempo;
            Accion = accion;
        }

        public Usuarios.clsUsuario Usuario { set; get; }
        public String Modulo{ set; get; }
        public String Accion { set; get; }
        public Double Tiempo { set; get; }
    }
}
