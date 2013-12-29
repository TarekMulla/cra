using System;
using System.Collections.Generic;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.LogicaNegocios.Mantenedores;

namespace ProyectoCraft.Entidades.Cotizaciones.Directa {
    public class Opcion : IdentifiableObject, ITableableOpcion {
        public Opcion() {
            Detalles = new List<DetalleOpcion>();
            Pod = new List<Puerto>();
            Pol = new List<Puerto>();
            FechaValidezInicio = DateTime.Now;

            var cotizacionDirectaFechaValidezFinTXT = System.Configuration.ConfigurationSettings.AppSettings.Get("CotizacionDirectaFechaValidezFin");
            var dias = 0;
            if (String.IsNullOrEmpty(cotizacionDirectaFechaValidezFinTXT))
                dias = 15;
            else
                dias = Convert.ToInt32(cotizacionDirectaFechaValidezFinTXT);

            FechaValidezFin = FechaValidezInicio.AddDays(dias);
            
        }

        public String Numero { set; get; }
        public DateTime FechaValidezInicio { set; get; }
        public DateTime FechaValidezFin { set; get; }
        public string NavieraDescripcion { get { return Naviera.Nombre; } }
        public DateTime FechaCreacion { set; get; }
        public ClsNaviera Naviera { set; get; }
        public List<Puerto> Pol { set; get; }
        public List<Puerto> Pod { set; get; }
        public String TiempoTransito { set; get; }
        public List<DetalleOpcion> Detalles { set; get; }
        public clsUsuario Usuario { set; get; }
        public Estado Estado { set; get; }
        public String EstadoDescripcion { get { return Estado.Nombre; } }
        public bool Seleccionado { set; get; }
        public List<Comentario> Comentarios { set; get; }

        public TiposServicio TiposServicio { set; get; }
        public TiposVia TipoVia { set; get; }
    }
}