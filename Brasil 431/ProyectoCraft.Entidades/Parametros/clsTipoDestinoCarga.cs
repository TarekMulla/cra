using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Usuarios;

namespace ProyectoCraft.Entidades.Parametros
{
    public class clsTipoDestinoCarga: GlobalObject.NamedObject
    {
        public clsTipoDestinoCarga()
        {
            Usuario = new clsUsuario();
        }

        public Usuarios.clsUsuario Usuario { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
