using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.GlobalObject;
using System.Reflection;

namespace ProyectoCraft.Entidades.Log
{
    public class LogActividadUsuarios: IdentifiableObject
    {
        public LogActividadUsuarios(){}

        public LogActividadUsuarios(string  entidad, Int64 identidad, Enums.Enums.TipoActividadUsuario actividad, Usuarios.clsUsuario usuario)
        {
            Entidad = entidad;
            IdEntidad = identidad;
            Actividad = actividad;
            Usuario = usuario;
        }

        public string Entidad { get; set; }
        public Int64 IdEntidad { get; set; }
        public Enums.Enums.TipoActividadUsuario Actividad { get; set; }
        public Usuarios.clsUsuario Usuario { get; set; }
        public DateTime Fecha { get; set; }

    }
}
