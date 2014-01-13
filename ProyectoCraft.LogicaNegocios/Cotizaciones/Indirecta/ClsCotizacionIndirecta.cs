using System;
using ProyectoCraft.AccesoDatos.Cotizaciones.Indirecta;
using ProyectoCraft.Entidades.Cotizaciones.Indirecta;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Usuarios;


namespace ProyectoCraft.LogicaNegocios.Cotizaciones.Indirecta {
    public class ClsCotizacionIndirecta {
        public static ResultadoTransaccion Crear(CotizacionIndirecta cotizacionInDirecta) {
            return ClsCotizacionIndirectaDao.Crear(cotizacionInDirecta);
        }

        public static ResultadoTransaccion ObtieneCotizacionIndirecta(Int32 id) {
            return ClsCotizacionIndirectaDao.ObtieneCotizacionIndirecta(id);

        }

        public static ResultadoTransaccion AsignaUsuarioPricing(CotizacionIndirecta cotizacionInDirecta, clsUsuario usuario){
            return ClsCotizacionIndirectaDao.AsignaUsuarioPricing(cotizacionInDirecta, usuario);
        }
    }
}
