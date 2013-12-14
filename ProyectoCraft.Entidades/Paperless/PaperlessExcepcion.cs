using System;

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

        public bool TieneExcepcion { get; set; }
        public PaperlessTipoExcepcion TipoExcepcion { set; get; }
        public PaperlessTipoResponsabilidad Responsabilidad { get; set; }

        public String Comentario { get; set; }
        public bool Resuelto { get; set; }
        public bool ResueltoUser2 { get; set; }
        public Int64 IdUsuarioUltimaModificacion { get; set; }
       
    }
}