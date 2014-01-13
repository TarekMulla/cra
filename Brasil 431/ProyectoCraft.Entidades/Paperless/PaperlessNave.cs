using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Paperless
{
    public class PaperlessNave: GlobalObject.NamedObject
    {
        public PaperlessNave()
        {
            
        }

        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
