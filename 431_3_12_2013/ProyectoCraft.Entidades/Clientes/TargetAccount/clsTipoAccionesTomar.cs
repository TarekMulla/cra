using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Clientes.TargetAccount
{
    public class clsTipoAccionesTomar: GlobalObject.IdentifiableObject
    {
        public clsTipoAccionesTomar(){}

        public Int64 IdTargetAccount { get; set; }
        public string QueNecesita { get; set; }
        public DateTime? ProximaOrden { get; set; }
        public string ComoComunicara { get; set; }
        public DateTime FechaCreacion { get; set; }
        
    }
}
