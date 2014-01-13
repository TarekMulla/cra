using System.ComponentModel;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.Entidades.Ventas.Pricing
{
    public class ClsTipoCotizacion : NamedObject {

        public enum Tipo
        {
            Directa = 1,

            [Description("Solicitud De Tarifa")]
            SolicitudDeTarifa = 2
        }

    }
}