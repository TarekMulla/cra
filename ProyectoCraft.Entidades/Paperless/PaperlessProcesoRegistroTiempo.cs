using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Paperless
{
    public class PaperlessProcesoRegistroTiempo: GlobalObject.IdentifiableObject
    {
        public PaperlessProcesoRegistroTiempo(){}

        public Int64 IdAsignacion { get; set; }
        public DateTime? ComienzoUsuario1 { get; set; }
        public DateTime? TerminoUsuario1 { get; set; }
        public DateTime? ComienzoUsuario2 { get; set; }
        public DateTime? TerminoUsuario2 { get; set; }

        //solo para informe gestion
        public DateTime? UltimoPasoUsuario1 { get; set; }
        public DateTime? UltimoPasoUsuario2 { get; set; }
    }
}
