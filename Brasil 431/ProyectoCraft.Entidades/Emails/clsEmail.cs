using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Emails
{
    public class clsEmail: GlobalObject.IdentifiableObject
    {
        public clsEmail(){}

        public string Asunto { get; set; }
        public string Ubicacion { get; set; }
        public string Cuerpo { get; set; }
        public string Emisor { get; set; }
        public string Receptores { get; set; }
        public DateTime FechaEmision { get; set; }
        public Enums.Enums.VisitaTipoEmail TipoEmail { get; set; }
        public Entidades.Calendario.clsVisita Visita { get; set; }
    }
}
