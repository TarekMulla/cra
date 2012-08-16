using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Paperless
{
    public class PaperlessUsuario1Rechaza: GlobalObject.IdentifiableObject
    {
        public PaperlessUsuario1Rechaza(){}

        public Int64 IdAsignacion { get; set; }
        //public Int64 IdUsuario { get; set; }
        public Entidades.Usuarios.clsUsuario Usuario { get; set; }
        public string Motivo { get; set; }
        public DateTime FechaRechazo { get; set; }
    }
}
