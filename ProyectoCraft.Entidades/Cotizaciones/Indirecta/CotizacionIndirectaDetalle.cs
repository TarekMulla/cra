using System;
using ProyectoCraft.Entidades.GlobalObject;


namespace ProyectoCraft.Entidades.Cotizaciones.Indirecta {
    public class CotizacionIndirectaDetalle : IdentifiableObject {
        public CotizacionIndirectaItem Item { set; get; }
        public Decimal Cantidad { set; get; }
    }
}
