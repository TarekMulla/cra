using System;
using ProyectoCraft.Entidades.GlobalObject;


namespace ProyectoCraft.Entidades.Cotizaciones.Directa
{
    public class GastoLocal : IdentifiableObject
    {
        public String Descripcion { set; get; }
        public Decimal Monto { set; get; }
    }
}
