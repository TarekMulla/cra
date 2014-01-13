using ProyectoCraft.Entidades.Cotizaciones.Directa;

namespace ProyectoCraft.Entidades.Cotizaciones.Indirecta
{
    public class CotizacionIndirectaOpcionDetalle
    {
        public Moneda Moneda { set; get; }//COTIZACION_MONEDAS_id BIGINT NOT NULL,
        public CotizacionIndirectaItem Item { set; get; }//COTIZACION_DIRECTA_ITEMS_id BIGINT NOT NULL, 
        public decimal Costo { set; get; }//costo DECIMAL(10,6), 
        public decimal Venta { set; get; }//venta DECIMAL(10,6),
        public int Cantidad { get; set; }//cantidad DECIMAL(10,6), 

        //COTIZACION_DIRECTA_OPCIONES_id BIGINT NOT NULL, 
    }
}