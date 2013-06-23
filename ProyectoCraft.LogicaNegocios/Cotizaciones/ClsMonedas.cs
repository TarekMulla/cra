using ProyectoCraft.AccesoDatos.Cotizaciones;
using ProyectoCraft.Entidades.GlobalObject;


namespace ProyectoCraft.LogicaNegocios.Cotizaciones {
    public class ClsMonedas {
        public static ResultadoTransaccion ObtieneTodasLasMonedas() {
            return ClsMonedasDao.ObtieneTodasLasMonedas();
        }
    }
}
