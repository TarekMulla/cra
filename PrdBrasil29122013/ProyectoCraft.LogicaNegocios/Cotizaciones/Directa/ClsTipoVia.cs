using ProyectoCraft.AccesoDatos.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;


namespace ProyectoCraft.LogicaNegocios.Cotizaciones.Directa {
    public class ClsTipoVia {
        public static ResultadoTransaccion ObtieneTiposVias() {
            return ClsTipoViaDao.ObtieneTiposVias();
        }
    }
}
