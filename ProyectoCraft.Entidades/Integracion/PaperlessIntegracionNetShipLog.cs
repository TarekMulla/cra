using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Integracion
{
     public class PaperlessIntegracionNetShipLog
    {
         public PaperlessIntegracionNetShipLog()
         {
         }

         public long IdPaperless { get; set; }
         public string ValorPaperless { get; set; }
         public string ValorNetship { get; set; }
         public string Mensaje { get; set; }
         public DateTime CreateDate { get; set; }

    }
}
