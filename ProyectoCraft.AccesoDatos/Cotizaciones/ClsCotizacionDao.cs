using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoCraft.AccesoDatos.Cotizaciones.Directa;
using ProyectoCraft.AccesoDatos.Cotizaciones.Indirecta;
using ProyectoCraft.Entidades.Cotizaciones;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.Cotizaciones.Indirecta;
using ProyectoCraft.Entidades.Usuarios;


namespace ProyectoCraft.AccesoDatos.Cotizaciones {
    public class ClsCotizacionDao {
        private const String NombreClase = "ClsCotizacionDao";
        public static IList<ITableable> ListarTodasLasCotizacionesDirectasPorUsuario(clsUsuario usuario) {

            var cotizaciones = new List<ITableable>();
            var directas = ClsCotizacionDirectaDao.ListarTodasLasCotizacionesDirectas(usuario).ObjetoTransaccion as List<CotizacionDirecta>;


            var indirectas = ClsCotizacionIndirectaDao.ListarTodasLasCotizacionesIndirectas(usuario).ObjetoTransaccion as List<CotizacionIndirecta>;


            if (directas != null)
                cotizaciones.AddRange(directas.Cast<ITableable>().ToList());

            if (indirectas != null)
                cotizaciones.AddRange(indirectas.Cast<ITableable>().ToList());


            cotizaciones = cotizaciones.OrderByDescending(x => x.Id32).ToList();
            return cotizaciones;
        }

        public static IList<ITableable> ListarTodasLasTarifasPorUsuario(clsUsuario usuario){
            var cotizaciones = new List<ITableable>();
            var indirectas = ClsCotizacionIndirectaDao.ListarTodasLasCotizacionesIndirectas(usuario).ObjetoTransaccion as List<CotizacionIndirecta>;

            if (indirectas != null)
                cotizaciones.AddRange(indirectas.Cast<ITableable>().ToList());



            cotizaciones = cotizaciones.OrderByDescending(x => x.Id32).ToList();
            return cotizaciones;
 
            
        }
    }
}
