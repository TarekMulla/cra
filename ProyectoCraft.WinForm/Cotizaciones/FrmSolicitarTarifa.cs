using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraEditors.DXErrorProvider;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Cotizaciones;
using ProyectoCraft.Entidades.Cotizaciones.Indirecta;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.LogicaNegocios.Clientes;
using ProyectoCraft.LogicaNegocios.Cotizaciones;
using ProyectoCraft.LogicaNegocios.Cotizaciones.Directa;
using ProyectoCraft.LogicaNegocios.Cotizaciones.Indirecta;
using ProyectoCraft.LogicaNegocios.Mantenedores;
using ProyectoCraft.LogicaNegocios.Parametros;
using SCCMultimodal.Utils;


namespace SCCMultimodal.Cotizaciones {
    public partial class FrmSolicitarTarifa : Form {
        public CotizacionIndirecta CotizacionIndirecta = new CotizacionIndirecta();
        private List<clsClienteMaster> _clientes = new List<clsClienteMaster>();
        private List<ClsNaviera> _navieras = new List<ClsNaviera>();
        private List<Puerto> _puertos = new List<Puerto>();
        public String mode = "Nueva";
        public CotizacionSetting CotizacionSetting { set; get; }


        public FrmSolicitarTarifa() {
            InitializeComponent();
        }

        private static FrmSolicitarTarifa _form = null;
        public static FrmSolicitarTarifa Instancia {
            get { return _form ?? (_form = new FrmSolicitarTarifa()); }
            set {
                _form = value;
            }
        }

        private void MenuSalir_Click(object sender, System.EventArgs e) {
            Instancia = null;
            Close();
        }

        private void FrmSolicitarTarifa_FormClosed(object sender, FormClosedEventArgs e) {
            Instancia = null;
        }

        private void FrmSolicitarTarifa_Load(object sender, System.EventArgs e) {
            TxtGastosLocales.Properties.Mask.Culture = new CultureInfo("es-CL");
            BeginForm();
            CotizacionSetting = new CotizacionSetting();
        }

        public void BeginForm() {
            _clientes = clsClientesMaster.ListarClienteMaster
                            (String.Empty, Enums.TipoPersona.Comercial, Enums.Estado.Todos, true) as
                        List<clsClienteMaster>;
            _navieras = (List<ClsNaviera>)ClsNavieras.ListarNavieras(true);

            _puertos = ClsPuertos.ObtieneTodosLosPuertos().ObjetoTransaccion as List<Puerto>;


            CboCliente.Properties.Items.Clear();
            foreach (var c in _clientes)
                CboCliente.Properties.Items.Add(c);

            CboPOL.Properties.Items.Clear();
            foreach (var p in _puertos)
                CboPOL.Properties.Items.Add(p);

            CboNaviera.Properties.Items.Clear();
            foreach (var n in _navieras)
                CboNaviera.Properties.Items.Add(n);

            CboPOD.Properties.Items.Clear();
            foreach (var p in _puertos)
                CboPOD.Properties.Items.Add(p);

            var tipoTransbordos = ClsTipoTransbordo.ObtieneTodos().ObjetoTransaccion as List<TipoTransbordo>;
            CboTransbordo.Properties.Items.Clear();
            foreach (var t in tipoTransbordos)
                CboTransbordo.Properties.Items.Add(t);

            GridDetalle.DataSource = new List<CotizacionIndirectaDetalle>();

            var items = ClsCotizacionIndirectaItem.ObtieneTodos().ObjetoTransaccion as List<CotizacionIndirectaItem>;
            foreach (var i in items)
                repositoryItemComboBox1.Items.Add(i);

            if (mode == "Nueva")
                NuevaCotizacion();
            else
                CargarCotizacionIndirecta();
        }

        private void CargarCotizacionIndirecta() {
            if (mode != "borrador") {
                CotizacionIndirecta =
                    ClsCotizacionIndirecta.ObtieneCotizacionIndirecta(CotizacionIndirecta.Id32).ObjetoTransaccion as
                    CotizacionIndirecta;
                Text = "Ingreso de Solicitud de Tarifa";
            } else {
                Text = "Copia de Solicitud de Tarifa";
            }
            txtEjecutivo.Text = CotizacionIndirecta.Usuario.NombreCompleto;
            TxtFecha.DateTime = CotizacionIndirecta.FechaSolicitud;
            TxtFechaEmbarque.DateTime = CotizacionIndirecta.FechaEstimadaEmbarque;
            CboCliente.SelectedItem = CotizacionIndirecta.Cliente;

            ChkFob.Checked = CotizacionIndirecta.IncoTerm.Codigo.ToUpper().Equals("FOB");
            ChkFca.Checked = CotizacionIndirecta.IncoTerm.Codigo.ToUpper().Equals("FCA");
            ChkExw.Checked = CotizacionIndirecta.IncoTerm.Codigo.ToUpper().Equals("EXW");


            CboPOD.SelectedItem = _puertos.Find(foo => foo.Codigo.Equals(CotizacionIndirecta.POD.Codigo));
            CboPOL.SelectedItem = _puertos.Find(foo => foo.Codigo.Equals(CotizacionIndirecta.POL.Codigo));
            chkConAgenciamiento.Checked = CotizacionIndirecta.ConAgenciamiento;
            chkSinAgenciamiento.Checked = !chkConAgenciamiento.Checked;

            CboTransbordo.SelectedItem = CotizacionIndirecta.TipoTransbordo;
            CboNaviera.SelectedItem = _navieras.Find(foo => foo.Id32.Equals(CotizacionIndirecta.Naviera.Id32));
            TxtTarifa.Text = CotizacionIndirecta.TarifaReferencia;
            TxtCommodity.Text = CotizacionIndirecta.Commodity;
            TxtGastosLocales.Text = CotizacionIndirecta.GastosLocales.ToString();
            TxtCredido.Text = CotizacionIndirecta.Credito;
            TxtObservaciones.Text = CotizacionIndirecta.Observaciones;
            TxtProveedor.Text = CotizacionIndirecta.ProveedorCarga;
            GridDetalle.DataSource = CotizacionIndirecta.Detalles;
            GridDetalle.RefreshDataSource();
        }

        private void NuevaCotizacion() {
            TxtFecha.DateTime = DateTime.Now;
            txtEjecutivo.Text = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario.NombreCompleto;
            LblGastosLocales.Text = "Sin Gastos Locales";
            TxtFechaEmbarque.DateTime = DateTime.Now;
        }

        private void sButtonAgregarUnidad_Click(object sender, EventArgs e) {
            var foo = GridDetalle.DataSource as List<CotizacionIndirectaDetalle>;
            foo.Add(new CotizacionIndirectaDetalle());
            GridDetalle.DataSource = foo;
            GridDetalle.RefreshDataSource();
        }

        private void sButtonEliminarUnidad_Click(object sender, EventArgs e) {
            gridView1.DeleteSelectedRows();
        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            ActiveControl = TxtObservaciones;

            if (ElFormularioTieneErrores())
                return;

            CargaDatosDelFormulario();

            if (CotizacionIndirecta.IsNew)
                CrearCotizacion();
            else
                ActualizarCotizacion();

            Instancia = null;
            Close();
        }

        private bool ElFormularioTieneErrores() {
            var errorTexto = String.Empty;
            ctrldxError.ClearErrors();

            if (CboCliente.SelectedIndex == -1)
                ctrldxError.SetError(CboCliente, "Debe seleccionar un cliente", ErrorType.Critical);

            if (CboPOD.Visible && CboPOD.SelectedIndex == -1)
                ctrldxError.SetError(CboPOD, "Debe selecionar un POD", ErrorType.Critical);

            if (CboPOL.Visible && CboPOL.SelectedIndex == -1)
                ctrldxError.SetError(CboPOL, "Debe selecionar un POL", ErrorType.Critical);

            if (chkConAgenciamiento.Checked == false && chkSinAgenciamiento.Checked == false)
                ctrldxError.SetError(chkConAgenciamiento, "Debe selecionar si es con agenciamiento", ErrorType.Critical);

            if (CboTransbordo.Visible && CboTransbordo.SelectedIndex == -1)
                ctrldxError.SetError(CboTransbordo, "Debe selecionar el tipo de transbordo", ErrorType.Critical);

            if (CboNaviera.SelectedIndex == -1)
                ctrldxError.SetError(CboNaviera, "Debe selecionar la Naviera", ErrorType.Critical);

            if (String.IsNullOrEmpty(TxtCommodity.Text))
                ctrldxError.SetError(TxtCommodity, "Debe ingresar el Commodity", ErrorType.Critical);

            if (String.IsNullOrEmpty(TxtCredido.Text))
                ctrldxError.SetError(TxtCredido, "Debe ingresar Credito", ErrorType.Critical);

            if (String.IsNullOrEmpty(TxtTarifa.Text))
                ctrldxError.SetError(TxtTarifa, "Debe ingresar la tarifa de referencia", ErrorType.Critical);

            if (String.IsNullOrEmpty(TxtProveedor.Text))
                ctrldxError.SetError(TxtProveedor, "Debe ingresar el Proveedor", ErrorType.Critical);

            if (String.IsNullOrEmpty(TxtObservaciones.Text))
                ctrldxError.SetError(TxtObservaciones, "Debe ingresar el Comentario", ErrorType.Critical);

            var detalle = GridDetalle.DataSource as List<CotizacionIndirectaDetalle>;
            if (detalle.Count == 0) {
                errorTexto = "Debe ingresar un al menos un concepto a cotizar";
                ctrldxError.SetError(GridDetalle, "Debe ingresar un al menos un concepto a cotizar", ErrorType.Critical);
            }

            if (!String.IsNullOrEmpty(errorTexto)) {
                MessageBox.Show("Se han encontrado los siguientes problemas: " + Environment.NewLine + errorTexto,
                                 "validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!String.IsNullOrEmpty(errorTexto))
                return true;

            return ctrldxError.HasErrors;
        }

        private void ActualizarCotizacion() {

        }

        private void CrearCotizacion() {
            var resultado = ClsCotizacionIndirecta.Crear(CotizacionIndirecta);
            ClsCotizacionDirecta.CambioEstado(CotizacionIndirecta, 1, ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario);
            var mailObject = new EnvioMailObject();
            mailObject.EnviarMail(CotizacionSetting.NotificacionesIndirectas.Destinatarios,
                                  CotizacionSetting.NotificacionesIndirectas.SubjectNuevaCotizacion,
                                  CotizacionSetting.NotificacionesIndirectas.TemplateNuevaCotizacion.Replace("[NumeroCotizacion]",CotizacionIndirecta.Numero));
            
            MessageBox.Show(resultado.Descripcion);
        }

        private void CargaDatosDelFormulario() {
            CotizacionIndirecta = new CotizacionIndirecta();
            CotizacionIndirecta.Producto = "FCL Importacion";

            var xmldoc = new XmlDocument();
            xmldoc.Load(Path.Combine(Application.StartupPath, @"Cotizaciones\CotizacionSetting.xml"));
            CotizacionIndirecta.ObservacionesFijas = xmldoc.SelectSingleNode("/setting/cotizacionDirecta/observacionFija").InnerText;

            var list = (List<clsIncoTerm>)clsParametrosClientes.ListarIncoTerms(true);
            clsIncoTerm incoTerm = null;

            if (ChkFob.Checked)
                incoTerm = list.Find(foo => foo.Codigo.ToUpper().Equals("FOB"));

            if (ChkFca.Checked)
                incoTerm = list.Find(foo => foo.Codigo.ToUpper().Equals("FCA"));

            if (ChkExw.Checked)
                incoTerm = list.Find(foo => foo.Codigo.ToUpper().Equals("EXW"));

            if (CotizacionIndirecta.IsNew) {
                CotizacionIndirecta.FechaSolicitud = TxtFecha.DateTime;
                CotizacionIndirecta.Usuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario;
            }

            CotizacionIndirecta.IncoTerm = incoTerm;
            CotizacionIndirecta.Cliente = CboCliente.SelectedItem as clsClienteMaster;
            CotizacionIndirecta.NombreCliente = CotizacionIndirecta.Cliente.ToString();
            CotizacionIndirecta.Naviera = CboNaviera.SelectedItem as ClsNaviera;
            CotizacionIndirecta.TarifaReferencia = TxtTarifa.Text;
            CotizacionIndirecta.Commodity = TxtCommodity.Text;
            CotizacionIndirecta.POD = CboPOD.SelectedItem as Puerto;
            CotizacionIndirecta.POL = CboPOL.SelectedItem as Puerto;
            CotizacionIndirecta.ConAgenciamiento = chkConAgenciamiento.Checked;

            if (!String.IsNullOrEmpty(TxtGastosLocales.EditValue.ToString()))
                CotizacionIndirecta.GastosLocales = Convert.ToDecimal(TxtGastosLocales.EditValue);

            CotizacionIndirecta.TipoTransbordo = CboTransbordo.SelectedItem as TipoTransbordo;
            CotizacionIndirecta.Credito = TxtCredido.Text;
            CotizacionIndirecta.ProveedorCarga = TxtProveedor.Text;
            CotizacionIndirecta.FechaEstimadaEmbarque = TxtFechaEmbarque.DateTime;
            CotizacionIndirecta.Observaciones = TxtObservaciones.Text;
            CotizacionIndirecta.Detalles = GridDetalle.DataSource as List<CotizacionIndirectaDetalle>;

        }

        private void TxtGastosLocales_EditValueChanged(object sender, EventArgs e) {
            if (!String.IsNullOrEmpty(TxtGastosLocales.Text)) {
                if (Convert.ToDecimal(TxtGastosLocales.EditValue) == 0)
                    LblGastosLocales.Text = "Sin Gastos Locales";
                else
                    LblGastosLocales.Text = "+ IVA";
            } else {
                LblGastosLocales.Text = String.Empty;
            }

        }

    }
}