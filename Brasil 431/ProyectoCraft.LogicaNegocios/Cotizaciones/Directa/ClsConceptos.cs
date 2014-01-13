using ProyectoCraft.AccesoDatos.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;


namespace ProyectoCraft.LogicaNegocios.Cotizaciones.Directa {
    public class ClsConceptos {
        public static ResultadoTransaccion ObtieneTodosLosConceptos() {
            return ClsConceptoDao.ObtieneTodosLosConceptos();
        }
    }
}
