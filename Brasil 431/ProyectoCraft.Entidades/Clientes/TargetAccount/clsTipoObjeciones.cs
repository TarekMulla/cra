using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Clientes.TargetAccount
{
    public class clsTipoObjeciones: GlobalObject.NamedObject
    {
        public clsTipoObjeciones(){}

        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
    }
}
