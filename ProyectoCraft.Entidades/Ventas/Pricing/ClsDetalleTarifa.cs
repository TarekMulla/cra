using System;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.Entidades.Ventas.Pricing
{
    [Obsolete]
    public class ClsDetalleTarifa:IdentifiableObject {
        public Decimal Cantidad { set; get; }
        public Decimal Costo { set; get; }
        public Decimal Venta { set; get; }
        public ClsMonedas Moneda { set; get; }
        public ClsItem Item { set; get; }
        //public List<ClsMonedas> ListaMonedas { get; set; }
    }
}