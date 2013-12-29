using System;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Usuarios;

namespace ProyectoCraft.Entidades.Cotizaciones.Directa {
    public class Comentario : IdentifiableObject {
        public DateTime Fecha { set; get; }
        public Boolean EsHistorial { set; get; }
        public String Observacion { set; get; }
        public clsUsuario Usuario { set; get; }
    }
}
