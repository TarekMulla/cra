using ProyectoCraft.AccesoDatos.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;


namespace ProyectoCraft.LogicaNegocios.Cotizaciones.Directa {
    public class ClsTipoServicio {
        public static ResultadoTransaccion ObtieneTiposServicios() {
            return ClsTiposServiciosDao.ObtieneTiposServicios();
        }
    }
}
