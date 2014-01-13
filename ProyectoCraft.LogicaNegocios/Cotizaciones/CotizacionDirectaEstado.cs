using System;
using ProyectoCraft.AccesoDatos.Cotizaciones.Directa;
using ProyectoCraft.Entidades.Cotizaciones;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Usuarios;


namespace ProyectoCraft.LogicaNegocios.Cotizaciones {
    public class CotizacionDirectaEstado {
        public static ResultadoTransaccion ListarEstadosCotizacionDirecta() {
            return ClsCotizacionDirectaEstadoDao.ListarEstadosCotizacionDirecta();
        }




        public static ResultadoTransaccion ModificarEstado(ITableable cotizacion, Int32 idEstado,  clsUsuario usuario) {
            return ClsCotizacionDirectaEstadoDao.CambioEstado(cotizacion, idEstado,  usuario);
        }

    }
}
