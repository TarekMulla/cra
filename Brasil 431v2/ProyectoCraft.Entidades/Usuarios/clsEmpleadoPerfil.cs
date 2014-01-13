using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Usuarios
{
    public class clsEmpleadoPerfil: GlobalObject.IdentifiableObject
    {
        public clsEmpleado Empleado { get; set; }
        public Perfiles.clsPerfil Perfil { get; set; }

    }
}
