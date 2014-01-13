using System;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.Entidades.Ventas.Pricing
{
    public class ClsEstado : NamedObject
    {
        public String Descripcion { set; get; }


        public enum Estado
        {
            Ingresado = 1,
            Enproceso = 2,
            Tarifadisponible = 3,
            EnviadaAlCliente = 4,
            Reevaluación = 5,
            PerdidoTarifa = 6,
            PerdidoOtros = 7,
            Cerrado = 8,
            CerradoLcl = 9
        }
    }
}