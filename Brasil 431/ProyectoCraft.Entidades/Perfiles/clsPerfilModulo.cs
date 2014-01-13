using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Perfiles
{
    public class clsPerfilModulo: GlobalObject.NamedObject
    {
        public clsPerfil Perfil { get; set; }
        public clsModulo Modulo { get; set; }

    }
}
