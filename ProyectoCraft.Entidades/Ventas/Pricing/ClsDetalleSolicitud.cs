using System;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.Entidades.Ventas.Pricing
{
    public class ClsDetalleSolicitud:IdentifiableObject {
        public Decimal Cantidad { set; get; }
        public ClsItem Item { set; get; }
        public string Descripcion { set; get; }
    }
}