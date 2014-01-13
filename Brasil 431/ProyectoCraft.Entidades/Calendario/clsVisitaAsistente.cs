using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Calendario
{
    public class clsVisitaAsistente: GlobalObject.IdentifiableObject
    {
        public clsVisitaAsistente(){}

        public Int64 IdVisita { get; set; }
        public Usuarios.clsUsuario Usuario { get; set; }
        public Clientes.Contacto.clsContacto Contacto { get; set; }
        public Enums.Enums.VisitaTipoAsistente TipoAsistente { get; set; }
        public Enums.Enums.VisitaEstadoAsistente Confirmo { get; set; }

    }
}
