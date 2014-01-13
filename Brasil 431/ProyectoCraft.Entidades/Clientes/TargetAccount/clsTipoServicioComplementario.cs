using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Clientes.TargetAccount
{
    public class clsTipoServicioComplementario: GlobalObject.NamedObject
    {
        public clsTipoServicioComplementario(){}

        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }

    }
}
