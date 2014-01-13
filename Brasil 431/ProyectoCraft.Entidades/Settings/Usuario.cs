using System;
using System.Collections.Generic;
using ProyectoCraft.Entidades.Perfiles;

namespace ProyectoCraft.Entidades.Settings
{
    public class Usuario: GlobalObject.NamedObject
    {

        public string NombreUsuario { get; set; }
        public bool EsAdministrador { get; set; }
        public bool Habilitado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public IList<clsPerfil> Perfiles { set; get; }

        public Usuario () {
            Perfiles = new List<clsPerfil>();
        }
    }
}
