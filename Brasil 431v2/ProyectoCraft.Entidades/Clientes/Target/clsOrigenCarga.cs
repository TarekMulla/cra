using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Clientes.Target
{
    public class clsOrigenCarga: GlobalObject.NamedObject
    {
        public clsOrigenCarga(){}
        public clsOrigenCarga(Int64 id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }

        public DateTime FechaCreacion { get; set; }
    }
}
