using System;

namespace ProyectoCraft.Entidades.Paperless
{
    public class PaperlessExcepcionMaster : GlobalObject.IdentifiableObject
    {

        public Int64 IdAsignacion { get; set; }
        //public Int64 Idhousebl { get; set; }
        public bool TieneExcepcion { get; set; }
        public int Index { get; set; }
        public PaperlessTipoExcepcion TipoExcepcion { get; set; }
        public PaperlessTipoResponsabilidad Tiporesponsabilidad { get; set; }
        public string Comentario { get; set; }
        public bool Resuelto { get; set; }
        public bool Estado { get; set; }
        public Int64 IdUsuarioUltimaModificacion { get; set; }
        public PaperlessAgenteCausador AgenteCausador { get; set; }

    }
}
