using System;
using System.Collections.Generic;
using ProyectoCraft.AccesoDatos.Cotizaciones;
using ProyectoCraft.AccesoDatos.Cotizaciones.Directa;
using ProyectoCraft.Entidades.Cotizaciones;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Usuarios;

namespace ProyectoCraft.LogicaNegocios.Cotizaciones.Directa {
    public class ClsCotizacionDirecta {
        public static IList<ITableable> ListarTodasLasCotizacionesPorUsuario(clsUsuario usuario) {
            return ClsCotizacionDao.ListarTodasLasCotizacionesDirectasPorUsuario(usuario);
        }

        public static ResultadoTransaccion Crear(CotizacionDirecta cotizacionDirecta) {
            return ClsCotizacionDirectaDao.Crear(cotizacionDirecta);
        }

        public static ResultadoTransaccion Modificar(CotizacionDirecta cotizacionDirecta) {
            return ClsCotizacionDirectaDao.Modificar(cotizacionDirecta);
        }

        public static ResultadoTransaccion ObtieneCotizacionDirecta(Int32 id) {
            return ClsCotizacionDirectaDao.ObtieneCotizacionDirecta(id);
        }

        public static IList<ITableable> ListarTodasLasTarifasPorUsuario(clsUsuario usuario) {
            return ClsCotizacionDao.ListarTodasLasTarifasPorUsuario(usuario);
        }

        public static void CambioEstado(ITableable tableable, int idEstado, clsUsuario usuario) {
            ClsCotizacionDirectaEstadoDao.CambioEstado(tableable, idEstado, usuario);
        }
    }

}
