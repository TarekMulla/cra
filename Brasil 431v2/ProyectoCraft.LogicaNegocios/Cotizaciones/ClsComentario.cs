using ProyectoCraft.AccesoDatos.Cotizaciones;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;


namespace ProyectoCraft.LogicaNegocios.Cotizaciones {
    public class ClsComentario {
        private static ResultadoTransaccion Guardar(CotizacionDirecta cotizacionDirecta, Comentario comentario) {
            return ClsComentarioDao.Guardar(cotizacionDirecta, comentario);
        }

        private static ResultadoTransaccion Guardar(Opcion opcion, Comentario comentario) {
            return ClsComentarioDao.Guardar(opcion, comentario);
        }

        public static ResultadoTransaccion GuardarMensaje(CotizacionDirecta cotizacionDirecta, Comentario comentario) {
            comentario.EsHistorial = false;
            return Guardar(cotizacionDirecta, comentario);
        }

        public static ResultadoTransaccion GuardarMensaje(Opcion opcion, Comentario comentario) {
            comentario.EsHistorial = false;
            return Guardar(opcion, comentario);
        }

        public static ResultadoTransaccion GuardarHistorial(CotizacionDirecta cotizacionDirecta, Comentario comentario) {
            comentario.EsHistorial = true;
            return Guardar(cotizacionDirecta, comentario);
        }

        public static ResultadoTransaccion GuardarHistorial(Opcion opcion, Comentario comentario) {
            comentario.EsHistorial = true;
            return Guardar(opcion, comentario);
        }

        /// <summary>
        /// Retorna todos los mensajes incluidos los historiales
        /// </summary>
        /// <param name="cotizacionDirecta"></param>
        /// <returns></returns>
        public static ResultadoTransaccion ObtieneTodosLosMensajes(CotizacionDirecta cotizacionDirecta) {
            return ClsComentarioDao.ObtieneTodosLosMensajes(cotizacionDirecta);
        }

        /// <summary>
        /// Retorna todos los mensajes incluido los historiales
        /// </summary>
        /// <param name="opcion"></param>
        /// <returns></returns>
        public static ResultadoTransaccion ObtieneTodosLosMensajes(Opcion opcion) {
            return ClsComentarioDao.ObtieneTodosLosMensajes(opcion);
        }

    }
}
