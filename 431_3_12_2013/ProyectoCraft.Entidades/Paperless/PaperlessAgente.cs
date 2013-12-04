using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Paperless
{
    public class PaperlessAgente: GlobalObject.NamedObject
    {
        public PaperlessAgente()
        {
        }

        public String Alias { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Contacto { get; set; }
        public string Email { get; set; }
    }
}
