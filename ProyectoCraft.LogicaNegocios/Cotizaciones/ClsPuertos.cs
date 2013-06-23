using System;
using ProyectoCraft.AccesoDatos.Cotizaciones;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.LogicaNegocios.Mantenedores;


namespace ProyectoCraft.LogicaNegocios.Cotizaciones {
    public class ClsPuertos {
        public static ResultadoTransaccion ObtieneTodosLosPuertos() {
            return ClsPuertosDao.ObtieneTodosLosPuertos();
        }

        public static ResultadoTransaccion ObtienePuertoPorCodigo(String codigo) {
            return ClsPuertosDao.ObtienePuertoPorCodigo(codigo);
        }

        public static ResultadoTransaccion ObtienePuertosPorNaviera(ClsNaviera naviera) {
            return ClsPuertosDao.ObtienePuertosPorNaviera(naviera);
        }
    }
}
