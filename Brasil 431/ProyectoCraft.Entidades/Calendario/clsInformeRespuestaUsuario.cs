using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Usuarios;

namespace ProyectoCraft.Entidades.Calendario
{
    public class clsInformeRespuestaUsuario: GlobalObject.IdentifiableObject
    {
        public clsInformeRespuestaUsuario()
        {
            Usuario = new clsUsuario();
        }

        public Int64 IdComentario { get; set; }
        public Int64 IdInforme { get; set; }
        public Entidades.Usuarios.clsUsuario Usuario { get; set; }

    }
}
