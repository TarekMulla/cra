using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoCraft.AccesoDatos.Cotizaciones.Directa;
using ProyectoCraft.Entidades.Cotizaciones;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.Usuarios;


namespace ProyectoCraft.AccesoDatos.Cotizaciones {
    public class ClsCotizacionDao {
        private const String NombreClase = "ClsCotizacionDao";
        public static IList<ITableable> ListarTodasLasCotizacionesDirectasPorUsuario(clsUsuario usuario,DateTime desde) {

            var Cotizaciones = new List<ITableable>();

            List<CotizacionDirecta> directas;
            directas = ClsCotizacionDirectaDao.ListarTodasLasCotizacionesDirectas(usuario,desde).ObjetoTransaccion as List<CotizacionDirecta>;

            if (directas != null)
                Cotizaciones.AddRange(directas.Cast<ITableable>().ToList());

            return Cotizaciones;
        }

        public static IList<ITableable> ListarTodasLasCotizacionesDirectas(DateTime desde) {

            var cotizaciones = new List<ITableable>();

            List<CotizacionDirecta> directas;
            directas = ClsCotizacionDirectaDao.ListarTodasLasCotizacionesDirectas(desde).ObjetoTransaccion as List<CotizacionDirecta>;

            if (directas != null)
                cotizaciones.AddRange(directas.Cast<ITableable>().ToList());

            return cotizaciones;
        }


    }
}
