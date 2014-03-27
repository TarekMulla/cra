using ProyectoCraft.AccesoDatos.Cotizaciones.Directa;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.LogicaNegocios.Cotizaciones.Directa {
    public class ClsLogCotizacionesDirecta {
        public static ResultadoTransaccion Guardar(LogCotizacionesDirecta logCotizacionesDirecta) {
            return ClsLogCotizacionesDirectaDao.Guardar(logCotizacionesDirecta);
        }
    }
}