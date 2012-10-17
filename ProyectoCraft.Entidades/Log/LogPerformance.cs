using System;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.Entidades.Log {
    /// <summary>
    /// Clase para registrar los tiempos que se demora algunas actividades en el sistema.
    /// </summary>
    public class LogPerformance : IdentifiableObject {
        public Usuarios.clsUsuario Usuario { set; get; }
        public String Modulo{ set; get; }
        public String Accion { set; get; }
        public Double Tiempo { set; get; }
    }
}
