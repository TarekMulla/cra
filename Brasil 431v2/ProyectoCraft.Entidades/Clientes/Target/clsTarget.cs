using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Clientes.Direcciones;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Tarifado;
using ProyectoCraft.Entidades.Usuarios;

namespace ProyectoCraft.Entidades.Clientes.Target
{
    public class clsTarget : IdentifiableObject
    {        
        public clsTarget()
        {
            this.ClienteMaster = new clsClienteMaster(true);
            TipoSaludo = new clsItemParametro();
            SectorEconomico = new clsItemParametro();
            OrigenCliente = new clsItemParametro();
            MotivoInteres = new clsItemParametro();
            NivelInteres = new clsItemParametro();
            EmpresaConQueTrabaja = new clsEmpresaCompetencia();
            OrigenCarga = new clsOrigenCarga();
            FormaContactoPreferida = new clsItemParametro();
            VendedorAsignado = new clsUsuario();
            TipoMonedaVtaEstimada = new clsTipoMoneda();
            DiaPreferido  = new clsItemParametro();
            JornadaPreferida = new clsItemParametro();            
        }
        
        public clsClienteMaster ClienteMaster { get; set; }
        public string Cargo { get; set; }     
        public string Telefono { get; set; }        
        public string CuentaSkype { get; set; }
        public string Email { get; set; }
        public string SitioWeb { get; set; }
        public string Observacion { get; set; }

        public decimal MontoVentaEstimada { get; set; }
        public Int64 NumEmpleados { get; set; }

        public bool PermiteTelOficina { get; set; }
        public bool PermiteTelParticular { get; set; }
        public bool PermiteTelCelular { get; set; }
        public bool PermiteSkype { get; set; }
        public bool PermiteEmail { get; set; }
        public bool PermiteEmailMasivo { get; set; }

        public clsItemParametro TipoSaludo { get; set; }
        //public clsTipoSaludo TipoSaludo { get; set; }
        public Enums.Enums.EstadoTarget Estado { get; set; }
        public clsItemParametro SectorEconomico { get; set; }
        //public clsSectorEconomico SectorEconomico { get; set; }
        public Tarifado.clsTipoMoneda TipoMonedaVtaEstimada { get; set; }
        //public clsMoneda TipoMonedaVtaEstimada { get; set; }

        public clsItemParametro OrigenCliente { get; set; }
        //public clsOrigenCliente OrigenCliente { get; set; }
        public clsItemParametro MotivoInteres { get; set; }
        //public clsMotivoInteres MotivoInteres { get; set; }
        public clsItemParametro NivelInteres { get; set; }
        //public clsNivelInteres NivelInteres { get; set; }
        public clsEmpresaCompetencia EmpresaConQueTrabaja { get; set; }
        public clsOrigenCarga OrigenCarga { get; set; }
        public clsItemParametro FormaContactoPreferida { get; set; }
        //public clsFormaContacto FormaContactoPreferida { get; set; }
        public clsItemParametro DiaPreferido { get; set; }
        public clsItemParametro JornadaPreferida { get; set; }

        public clsUsuario VendedorAsignado { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
