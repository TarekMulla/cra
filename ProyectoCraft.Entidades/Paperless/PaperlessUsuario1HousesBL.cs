using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Paperless
{
    public class PaperlessUsuario1HousesBL: GlobalObject.IdentifiableObject
    {
        public PaperlessUsuario1HousesBL(){}

        public Int64 IdAsignacion { get; set; }
        public int Index { get; set; }
        public string HouseBL { get; set; }
        public bool Freehand { get; set; }
        public Entidades.Clientes.clsClienteMaster Cliente { get; set; }
        public PaperlessTipoCliente TipoCliente { get; set; }
        public bool Ruteado { get; set; }
        public PaperlessExcepcion ExcepcionRecargoCollect { get; set; }
        public bool EmbarcadorContactado { get; set; }
        public bool ReciboAperturaEmbarcador { get; set; }
        public DateTime? FechaReciboAperturaEmbarcador { get; set; }
        public Enums.Enums.PaperlessTipoReciboAperturaEmbarcador TipoReciboAperturaEmbarcador { get; set; }
        public String Observacion { set; get; }
        public PaperlessTipoTransito TransbordoTransito { set; get; }
    }
}
