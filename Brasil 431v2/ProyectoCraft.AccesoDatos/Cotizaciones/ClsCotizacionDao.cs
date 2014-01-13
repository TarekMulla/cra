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
        public static IList<ITableable> ListarTodasLasCotizacionesDirectasPorUsuario(clsUsuario usuario)
        {

            var Cotizaciones = new List<ITableable>();

            List<CotizacionDirecta> directas;
            directas = ClsCotizacionDirectaDao.ListarTodasLasCotizacionesDirectas(usuario).ObjetoTransaccion as List<CotizacionDirecta>;
           
            if (directas != null)
                Cotizaciones.AddRange(directas.Cast<ITableable>().ToList());

            return Cotizaciones;
        }
    }
}
