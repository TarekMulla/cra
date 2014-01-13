using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Clientes.Target;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.LogicaNegocios.Mantenedores;


namespace ProyectoCraft.Entidades.Cotizaciones.Indirecta {

    public class CotizacionIndirecta : IdentifiableObject, ITableable {
        public CotizacionIndirecta() {
            Detalles = new List<CotizacionIndirectaDetalle>();
        }

        public String Producto { set; get; }
        public String Numero {
            get {
                return String.Format("{0:d4}", Id32);
            }
        }

        public clsUsuario Usuario { set; get; }
        public clsClienteMaster Cliente { set; get; }
        public clsTarget Target { set; get; }
        public String NombreCliente { set; get; }
        public DateTime FechaSolicitud { set; get; }
        public DateTime FechaEstimadaEmbarque { set; get; }
        public Puerto POL { set; get; }
        public Puerto POD { set; get; }
        public Boolean ConAgenciamiento { set; get; }
        public TipoTransbordo TipoTransbordo { set; get; }
        public ClsNaviera Naviera { set; get; }
        public String TarifaReferencia { set; get; }
        public clsIncoTerm IncoTerm { set; get; }
        public String Commodity { set; get; }

        public String Credito { set; get; }
        public Decimal? GastosLocales { set; get; }
        public String CondicionFija { set; get; }
        public String CondicionVariable { set; get; }
        public Estado Estado { set; get; }
        public String EstadoDescripcion { get { return Estado.Nombre; } }
        public String ProveedorCarga { set; get; }
        public String Observaciones { set; get; }
        public String ObservacionesFijas { set; get; }
        public List<CotizacionIndirectaDetalle> Detalles { set; get; }

        public List<CotizacionIndirectaOpcion> Opciones { set; get; }
        public List<Comentario> Comentarios { set; get; }

        public string Tipo {
            get { return "Solicitud de tarifa"; }
        }

        public bool Seleccionado { set; get; }

        public List<ITableableOpcion> OpcionesView {
            get {
                if (Opciones != null)
                    return Opciones.Cast<ITableableOpcion>().ToList();
                return null;
            }
        }

        public bool PermiteEnviarPorCorreo {
            get {
                if (Estado.Id32 >= 3)
                    return true;
                return false;
            }
        }

        public bool PermiteCopiar {
            get { return true; }
        }

        public bool PermiteAceptarUsuarioPricing {
            get { return Estado.Id32 == 1; }
        }

        public bool PermiteIngresarTarifa {
            get { return Estado.Id32 > 1; }
        }

        public int CantidadOpciones {
            get {
                return 0;
            }
        }

        public String GenerateHtmlPreviewAndBody(String startupPath) {
            return renderHtml(Path.Combine(startupPath, @"cotizaciones\TemplateCotizacionPreview.html"));
        }

        public String GenerateHTMLforPDF(String startupPath) {
            return renderHtml(Path.Combine(startupPath, @"cotizaciones\TemplateCotizacionMailPDF.html"));
        }

        private String renderHtml(String path) {
            return "";
        }

    }
}