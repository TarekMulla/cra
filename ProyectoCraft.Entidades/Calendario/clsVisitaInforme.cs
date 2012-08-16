using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Clientes;

namespace ProyectoCraft.Entidades.Calendario
{
    public class clsVisitaInforme: GlobalObject.IdentifiableObject
    {
        public clsVisitaInforme()
        {
            Productos = new List<clsVisitaInformeProductos>();
            Traficos = new List<clsVisitaInformeTrafico>();
            UsuariosParaRespuesta = new List<clsInformeRespuestaUsuario>();
            FollowUp = new clsClienteFollowUp();
        }

        public clsVisita Visita { get; set; }
        public bool TieneEspectativaCierre { get; set; }
        public int EspectativaCierre { get; set; }
        //public DateTime? FollowUp { get; set; }
        public string ResumenVisita { get; set; }
        public bool OtroTema { get; set; }
        public IList<clsVisitaInformeProductos> Productos { get; set; }
        public IList<clsVisitaInformeTrafico> Traficos { get; set; }
        
        public bool RequiereRespuesta { get; set; }
        public IList<clsInformeRespuestaUsuario> UsuariosParaRespuesta { get; set; }
        public bool EsBorrador { get; set; }

        public Clientes.clsClienteFollowUp FollowUp { get; set; }

        public DateTime FechaCreacion { get; set; }
        public Int64 IdUsuario { get; set; }

    }
}
