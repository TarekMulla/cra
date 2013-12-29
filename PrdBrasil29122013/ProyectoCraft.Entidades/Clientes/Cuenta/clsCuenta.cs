using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Tarifado;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.Entidades.Clientes.Cuenta
{
    public class clsCuenta: IdentifiableObject
    {        
        public clsCuenta()
        {
            ClienteMaster = new clsClienteMaster(true);
            ZonaVentas = new clsItemParametro();
            CategoriaCliente = new clsItemParametro();
            SectorEconomico = new clsItemParametro();
            TipoMonedaVtaEstimada = new clsTipoMoneda();
            UMMovimientoEstimado = new  clsItemParametro();
            FormaContactoPreferida = new clsItemParametro();
            DiaPreferido = new clsItemParametro();
            JornadaPreferida = new clsItemParametro();
            VendedorAsignado = new clsUsuario();
            //CustomerAsignado = new clsUsuario();
            Clasificacion = new clsCuentaclasificacion();
        }

        public clsClienteMaster ClienteMaster { get; set; }


        //public string NombreFantasia { get; set; }
        public string CodigoCompañia { get; set; }
        public string Telefono { get; set; }
        public string CuentaSkype { get; set; }
        public string SitioWeb { get; set; }
        public string Email { get; set; }
        public string Observacion { get; set; }

        public decimal MontoVentaEstimada { get; set; }
        public decimal MontoMovimientoEstimado { get; set; }
        public Int64 NumEmpleados { get; set; }

        public bool PermiteTelOficina { get; set; }
        public bool PermiteTelParticular { get; set; }
        public bool PermiteTelCelular { get; set; }
        public bool PermiteSkype { get; set; }
        public bool PermiteEmail { get; set; }
        public bool PermiteEmailMasivo { get; set; }
        public bool AutorizadoAduana { get; set; }
        
        public Enums.Enums.Estado Estado { get; set; }
        public clsItemParametro ZonaVentas { get; set; }
        public clsItemParametro CategoriaCliente { get; set; }
        public clsItemParametro SectorEconomico { get; set; }
        public Tarifado.clsTipoMoneda TipoMonedaVtaEstimada { get; set; }
        public clsItemParametro UMMovimientoEstimado { get; set; }

        public clsItemParametro FormaContactoPreferida { get; set; }
        public clsItemParametro DiaPreferido { get; set; }
        public clsItemParametro JornadaPreferida { get; set; }

        public clsUsuario VendedorAsignado { get; set; }
        //public clsUsuario CustomerAsignado { get; set; }
        public clsCuentaclasificacion Clasificacion { get; set; }
        public Enums.Enums.PaperlessTipoReciboAperturaEmbarcador TipoReciboAperturaEmbarcador { get; set; }
        public DateTime FechaCreacion { get; set; }

        
    }
}
