using System;
using ProyectoCraft.AccesoDatos.Ventas.pricing;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.Entidades.Ventas.Pricing;
using modelo = ProyectoCraft.Entidades.Ventas.Pricing;

namespace ProyectoCraft.LogicaNegocios.Ventas.pricing
{
    public  class ClsCotizacion{
        public static ResultadoTransaccion ListarTodosLosItems()
        {
            return ClsCotizacionADO.ListarTodosLosItems();
        }
        
        public static ResultadoTransaccion ListarCotizacionDirectaITems()
        {
            return ClsCotizacionADO.ListarCotizacionDirectaITems();
        }


        public static ResultadoTransaccion GuardarCotizacion(modelo.ClsSolicitudCotizacionIndirecta solicitudCotizacionIndirecta){
            return ClsCotizacionADO.GuardarCotizacion(solicitudCotizacionIndirecta);
        }
        public static ResultadoTransaccion ListarTodosLasCotizaciones()
        {
            return ClsCotizacionADO.ListarTodosLasCotizaciones();
        }

        public static ResultadoTransaccion ListarTodosLasCotizacionesMiscotizaciones(clsUsuario usuario)
        {
            return ClsCotizacionADO.ListarTodosLasCotizacionesMiscotizaciones(usuario);
        }


        public static ResultadoTransaccion ListarTodosLasCotizacionesPorUsuario(Int64 usuario)
        {
            return ClsCotizacionADO.ListarTodosLasCotizacionesPorUsuario(usuario);
        }
        public static ResultadoTransaccion ActualizaEstadoCotizacion(modelo.ClsSolicitudCotizacionIndirecta solicitudCotizacionIndirecta)
        {
            return ClsCotizacionADO.ActualizaEstadoCotizacion(solicitudCotizacionIndirecta);
        }

        public static ResultadoTransaccion GuardarSolicitudDeCotizacion(ClsSolicitudCotizacionDirecta cotizacion){
            return ClsCotizacionADO.GuardarSolicitudDeCotizacion(cotizacion);
        }
    }
}
