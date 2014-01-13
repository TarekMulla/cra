using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Calendario
{
    public class clsLogEmailVisita: GlobalObject.IdentifiableObject
    {
        public clsLogEmailVisita()
        {
            
        }

        public Int64 IdVisita { get; set; }
        public Int64 IdEstadoVisitaOld { get; set; }
        public Int64 IdEstadoVisitaNew { get; set; }
        public string AsuntoEmail { get; set; }
        public string CuerpoEmail { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string EmailEmisor { get; set; }
        public string EmailReceptores { get; set; }
        public Int64 IdUsuasrio { get; set; }


    }
}
