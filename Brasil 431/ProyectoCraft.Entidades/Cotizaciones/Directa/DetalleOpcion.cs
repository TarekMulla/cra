using System;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.Entidades.Cotizaciones.Directa {
    public class DetalleOpcion : IdentifiableObject {
        public DetalleOpcion() {
            Unidad = new Unidad();
            Moneda = new Moneda();
            Concepto = new Concepto();
            Cantidad = 1;
        }
        public Unidad Unidad { set; get; }
        public Decimal Cantidad { set; get; }
        public Decimal Costo { get; set; }
        public Decimal Venta { get; set; }
        public Moneda Moneda { set; get; }
        public Concepto Concepto { set; get; }

    }
}