using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Usuarios;

namespace ProyectoCraft.Entidades.Paperless
{
    public class PaperlessPreAlerta : GlobalObject.NamedObject
    {
        public PaperlessPreAlerta()
        {
        }

        public PaperlessPreAlerta PreAlerta { get; set; }

        public Enums.Enums.EstadoPaperless EstadoFlujo { get; set; }
        public string EstadoFlujoDescripcion { get; set; }

        public Int64 Id { get; set; }
        public String NumConsolidada { get; set; }
        public String NumMaster { get; set; }

        public PaperlessAgente Agente { get; set; }
        public PaperlessNaviera Naviera { get; set; }
        public PaperlessNave Nave { get; set; }
        public PaperlessPuerto PuertoOrigen { get; set; }
        public PaperlessPuerto PuertoDestino { get; set; }

        
        public DateTime? FechaSalida { get; set; }
        public DateTime? FechaLlegada { get; set; }
        public DateTime? FechaRecibimiento { get; set; }
        public DateTime? FechaCreacion { get; set; }
        
        public clsUsuario Usuario { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public Int64 IdUsuarioModificacion { get; set; }
        public DateTime? FechaCancelacion { get; set; }
        public Int64 IdUsuarioCancelacion { get; set; }
        public PaperlessEstadoPreAlerta Estado { get; set; }
        public clsUsuario UsuarioModificacion { get; set; }


    }
}
