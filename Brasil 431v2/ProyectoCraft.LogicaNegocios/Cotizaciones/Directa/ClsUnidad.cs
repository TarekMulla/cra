using ProyectoCraft.AccesoDatos.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.LogicaNegocios.Cotizaciones.Directa {
    public class ClsUnidad {
        public static ResultadoTransaccion ObtieneTodasLasUnidades() {
            return ClsUnidadDao.ObtieneTodasLasUnidades();
        }
    }
}
