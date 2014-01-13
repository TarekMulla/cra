using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Usuarios
{
    public class clsUsuarioCargo: GlobalObject.NamedObject
    {
        public clsUsuarioCargo(){}
        public clsUsuarioCargo(Int16 id, string descripcion)
        {
            this.Id = id;
            this.Nombre = descripcion;
        }

        public DateTime FechaCreacion { get; set; }
        public Enums.Enums.UsuariosCargo CargoEnum { get; set; }
    }
}
