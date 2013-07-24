
using System;

namespace ProyectoCraft.Entidades.Integracion
{
    public class IntegracionNetShip
    {
        public IntegracionNetShip()
        {
        }

        public string Consolidada { get; set; }
        public string HouseBl { get; set; }
        public string Rut  { get; set; }
        public string Cliente { get; set; }
        public string TipoCliente { get; set; }
        public bool Ruteado { get; set; }
        public string ShippingInstruction { get; set; }
        public string Puerto { get; set; }
        public Int32 IdPaperless { get; set; }
        public string ValorPaperless{ get; set; }
        public string ValorNetShip { get; set; }
        public string Mensaje { get; set; }
        public bool Activo { get; set; }
        public Int32 IdPaperlessTipoError { get; set; }
    }
}