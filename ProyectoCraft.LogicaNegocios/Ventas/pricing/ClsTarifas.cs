using ProyectoCraft.AccesoDatos.Ventas.pricing;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Ventas.Pricing;
using modelo = ProyectoCraft.Entidades.Ventas.Pricing;

namespace ProyectoCraft.LogicaNegocios.Ventas.pricing
{
    public class ClsTarifas
    {
        public static ResultadoTransaccion ListarTodosLasTarifas(ClsSolicitudCotizacionIndirecta solicitudCotizacionIndirecta)
        {
            return clsTarifaADO.ListarTarifas(solicitudCotizacionIndirecta);
        }
        public static ResultadoTransaccion GuardarTarifa(ClsSolicitudCotizacionIndirecta solicitudCotizacionIndirecta, ClsSolicitudCotizacionInDirectaOpciones tarifas)
        {
            return clsTarifaADO.GuardarTarifa(solicitudCotizacionIndirecta, tarifas);
        }
        public static ResultadoTransaccion ActualizaTarifa(ClsSolicitudCotizacionIndirecta solicitudCotizacionIndirecta, ClsSolicitudCotizacionInDirectaOpciones tarifas)
        {
            return clsTarifaADO.ActualizaTarifa(solicitudCotizacionIndirecta, tarifas);
        }
        public static ResultadoTransaccion ListarItemsTarifas()
        {
            return clsTarifaADO.ListarItemsTarifas();
        }
        public static ResultadoTransaccion ListarMonedasTarifas()
        {
            return clsTarifaADO.ListarMonedasTarifas();
        }
    }
}
