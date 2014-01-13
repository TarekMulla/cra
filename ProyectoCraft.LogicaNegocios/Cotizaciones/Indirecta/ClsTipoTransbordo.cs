using ProyectoCraft.AccesoDatos.Cotizaciones.Indirecta;
using ProyectoCraft.Entidades.GlobalObject;


namespace ProyectoCraft.LogicaNegocios.Cotizaciones.Indirecta {
    public class ClsTipoTransbordo {
        public static ResultadoTransaccion ObtieneTodos() {
            return ClsTipoTransbordoDao.ObtieneTodos();
        }
    }
}
