using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Paperless
{
    public class PaperlessLogAperturaNavieras: GlobalObject.IdentifiableObject
    {
        public PaperlessLogAperturaNavieras()
        {            
        }

        public Int64 IdAsignacion { get; set; }
        public Enums.Enums.TipoActividadUsuario Accion { get; set; }
        public Int64 IdUsuario { get; set; }
        public DateTime? ValorAnterior { get; set; }
        public DateTime? ValorNuevo { get; set; }
    }
}
