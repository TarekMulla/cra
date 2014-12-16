using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProyectoCraft.Entidades.Paperless
{
    public class PaperlessUsuario2Rechaza : GlobalObject.IdentifiableObject
    {
        public PaperlessUsuario2Rechaza() { }

        public Int64 IdAsignacion { get; set; }
        //public Int64 IdUsuario { get; set; }
        public Entidades.Usuarios.clsUsuario Usuario { get; set; }
        public string Motivo { get; set; }
        public DateTime FechaRechazo { get; set; }
    }
}
