using System;
using System.Collections.Generic;
using System.Text;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.Entidades.Ventas.Actividades
{
    public class clsTipoActividad: GlobalObject.NamedObject 
    {
        private string _alias;
        private string _activo;

        public string Activo { get; set; }
        public string Alias { get; set; }
    }
}
