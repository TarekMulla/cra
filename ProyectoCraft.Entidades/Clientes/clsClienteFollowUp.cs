using System;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.Entidades.Ventas.Actividades;

namespace ProyectoCraft.Entidades.Clientes {
    public class clsClienteFollowUp : GlobalObject.IdentifiableObject {
        public clsClienteFollowUp() {
            Cliente = new clsClienteMaster(true);
            TipoActividad = new clsTipoActividad();
            Usuario = new clsUsuario();
            Activo = true;
        }

        public Int64? IdInformeVisita { get; set; }
        public Int64? IdLlamadaTelefonica { get; set; }
        public Int64? IdSalesLead { get; set; }
        public Int64? IdTarget { get; set; }
        public DateTime? FechaFollowUp { get; set; }
        public clsTipoActividad TipoActividad { get; set; }
        public clsClienteMaster Cliente { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public clsUsuario Usuario { get; set; }

        public Boolean Activo { get; set; }

        public Int64? IdCotizacion { get; set; }
    }
}
