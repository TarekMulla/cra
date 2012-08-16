using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Ventas.Productos;
using ProyectoCraft.Entidades.Ventas.Traficos;

namespace ProyectoCraft.Entidades.Clientes.TargetAccount
{
    public class clsTargetAccount : IdentifiableObject
    {
        public clsTargetAccount()
        {
            ClienteMaster = new clsClienteMaster(true);
            OrigenesCarga = new List<clsTipoOrigenCarga>();
            DestinosCarga = new List<clsTipoDestinoCarga>();
            EmbarcaCon = new List<clsTargetAccountCompetencia>();
            TomaDesiciones = new List<clsTargetAccountTomaDesiciones>();            
            ServiciosComplementarios = new List<clsTipoServicioComplementario>();
            Personales = new List<clsTargetAccountPersonales>();
            Objeciones = new List<clsTipoObjeciones>();
            AccionTomar = new clsTipoAccionesTomar();
            Traficos = new List<clsTrafico>();
            UMLCL = new clsItemParametro();
            UMFCL = new clsItemParametro();
            UMAereo = new clsItemParametro();

        }

        
        public clsTargetAccount(string NombreCompania, Int64 IdTSource)
        {
            this.ClienteMaster = new clsClienteMaster(false);
            this.ClienteMaster.NombreCompañia = NombreCompania;
            this.ClienteMaster.NombreFantasia = NombreCompania;
            this.IdTargetSource = IdTSource;
        }

        public Int64 IdTargetSource { get; set; }

        public Enums.Enums.EstadosMetas Estado { get; set; }

        //Paso 1 Informacion General
        public clsClienteMaster ClienteMaster { get; set; }

        public string TelefonoEmpresa { get; set; }
        public string TelefonoDirecto { get; set; }

        public IList<Ventas.Traficos.clsTrafico> Traficos { get; set; }

        public Int64? EmbarquesPorMes { get; set; }
        public Int64? CantidadLCL { get; set; }
        public clsItemParametro UMLCL { get; set; }
        public Int64? CantidadFCL { get; set; }
        public clsItemParametro UMFCL { get; set; }
        public Int64? CantidadAereo { get; set; }
        public clsItemParametro UMAereo { get; set; }

        public clsItemParametro TerminoCompra { get; set; }
        public clsIncoTerm IncoTerm { get; set; }
        
        public IList<clsTipoOrigenCarga> OrigenesCarga { get; set; }
        public IList<clsTipoDestinoCarga> DestinosCarga { get; set; }

        public string ObservacionInfGeneral { get; set; }

        //Paso 2 Llamada Telefonica
        public string ContactoNombre { get; set; }
        public string ContactoEmail { get; set; }
        public string ContactoCargo { get; set; }

        public IList<clsTargetAccountCompetencia> EmbarcaCon { get; set; }
        public IList<clsTargetAccountTomaDesiciones> TomaDesiciones { get; set; }
        public string ObservacionLlamadaTelefonica { get; set; }

        //Paso 3 Visita
        //Productos: Se cargan en ClienteMaster.Productos
        public IList<clsTipoServicioComplementario> ServiciosComplementarios { get; set; }
        public IList<clsTargetAccountPersonales> Personales { get; set; }
        public IList<clsTipoObjeciones> Objeciones { get; set; }
        
        public clsTipoAccionesTomar AccionTomar { get; set; }
        
        public string ObservacionVisita { get; set; }
    }
}
