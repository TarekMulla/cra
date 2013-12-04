using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Usuarios;

namespace ProyectoCraft.Entidades.Calendario
{
    public class clsInformeComentario: GlobalObject.IdentifiableObject
    {
        public clsInformeComentario()
        {
            Usuario = new clsUsuario();

        }

        public Usuarios.clsUsuario Usuario { get; set; }
        public Int64 IdInforme { get; set; }
        public string Comentario { get; set; }        
        public DateTime FechaComentario { get; set; }
    }
}
