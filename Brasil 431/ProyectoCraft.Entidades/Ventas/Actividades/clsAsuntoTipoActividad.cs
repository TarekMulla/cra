using System;
using System.Collections.Generic;
using System.Text;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.Entidades.Ventas.Actividades
{
    public class clsAsuntoTipoActividad : GlobalObject.NamedObject  
    {
        public clsTipoActividad ObjTipoActividad { get; set; }
        public string Activo { get; set; }
    }
    public class clsAsuntoActividad : IdentifiableObject
    {
        public clsAsuntoTipoActividad ObjAsuntoTipoActividad { get; set; }
        public Int32 IdActividad { get; set; }
    }
}
