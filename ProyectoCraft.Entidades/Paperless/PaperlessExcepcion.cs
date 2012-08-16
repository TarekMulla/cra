using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Paperless
{
    public class PaperlessExcepcion: GlobalObject.IdentifiableObject
    {
        public PaperlessExcepcion()
        {
            HouseBL = new PaperlessUsuario1HousesBL();
        }

        public Int64 IdAsignacion { get; set; }
        //public Int64 IdHouseBL { get; set; }
        //public string HBLS { get; set; }


        public PaperlessUsuario1HousesBL HouseBL { get; set; }

        //public Entidades.Clientes.clsClienteMaster Cliente { get; set; }
        //public PaperlessTipoCliente TipoCliente { get; set; }
        //public bool Freehand { get; set; }


        //public bool FreehandResuelto { get; set; }
        public bool RecargoCollect { get; set; }
        public bool RecargoCollectResuelto { get; set; }
        public bool SobreValorPendiente { get; set; }
        public bool SobreValorPendienteResuelto { get; set; }
        public bool AvisoNoEnviado { get; set; }
        public bool AvisoNoEnviadoResuelto { get; set; }

    }
}
