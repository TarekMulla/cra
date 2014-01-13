using ProyectoCraft.AccesoDatos.Cotizaciones;
using ProyectoCraft.Entidades.Cotizaciones;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;


namespace ProyectoCraft.LogicaNegocios.Cotizaciones {
    public class ClsComentario {
        private static ResultadoTransaccion Guardar(ITableable cotizacion, Comentario comentario) {
            return ClsComentarioDao.Guardar(cotizacion, comentario);
        }

        private static ResultadoTransaccion Guardar(Opcion opcion, Comentario comentario) {
            return ClsComentarioDao.Guardar(opcion, comentario);
        }

        public static ResultadoTransaccion GuardarMensaje(ITableable cotizacion, Comentario comentario) {
            comentario.EsHistorial = false;
            return Guardar(cotizacion, comentario);
        }

        public static ResultadoTransaccion GuardarMensaje(Opcion opcion, Comentario comentario) {
            comentario.EsHistorial = false;
            return Guardar(opcion, comentario);
        }

        public static ResultadoTransaccion GuardarHistorial(ITableable cotizacion, Comentario comentario) {
            comentario.EsHistorial = true;
            return Guardar(cotizacion, comentario);
        }

        public static ResultadoTransaccion GuardarHistorial(Opcion opcion, Comentario comentario) {
            comentario.EsHistorial = true;
            return Guardar(opcion, comentario);
        }

        /// <summary>
        /// Retorna todos los mensajes incluidos los historiales
        /// </summary>
        /// <param name="cotizacion"></param>
        /// <returns></returns>
        public static ResultadoTransaccion ObtieneTodosLosMensajes(ITableable cotizacion) {
            return ClsComentarioDao.ObtieneTodosLosMensajes(cotizacion);
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
