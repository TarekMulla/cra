using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Paperless
{
    public class PaperlessUsuario1HouseBLInfo: GlobalObject.IdentifiableObject
    {
        public PaperlessUsuario1HouseBLInfo(){}

        public Int64 IdAsignacion { get; set; }
        public string NumConsolidado { get; set; }
        public Int64 CantHouses { get; set; }
        //public Int64 NumHouse { get; set; }
        //public Clientes.clsClienteMaster Cliente { get; set; }
    }
}
