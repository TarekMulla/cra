using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Cotizaciones;
using ProyectoCraft.Entidades.Cotizaciones.Indirecta;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.LogicaNegocios.Clientes;
using ProyectoCraft.LogicaNegocios.Cotizaciones;
using ProyectoCraft.LogicaNegocios.Cotizaciones.Indirecta;
using ProyectoCraft.LogicaNegocios.Mantenedores;


namespace SCCMultimodal.Cotizaciones
{
    public partial class FrmIngresarTarifa : Form
    {
        public CotizacionIndirecta CotizacionIndirecta = new CotizacionIndirecta();
        private List<clsClienteMaster> _clientes = new List<clsClienteMaster>();
        private List<ClsNaviera> _navieras = new List<ClsNaviera>();
        private List<Puerto> _puertos = new List<Puerto>();
        public String mode = "Nueva";


        public FrmIngresarTarifa()
        {
            InitializeComponent();
        }
        private static FrmIngresarTarifa _form = null;
        public static FrmIngresarTarifa Instancia
        {
            get { return _form ?? (_form = new FrmIngresarTarifa()); }
            set
            {
                _form = value;
            }
        }

        private void FrmIngresarTarifa_Load(object sender, EventArgs e)
        {
            TxtGastosLocales.Properties.Mask.Culture = new CultureInfo("es-CL");
            BeginForm();
        }

        public void BeginForm()
        {
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

            CargarCotizacionIndirecta();
        }

        private void CargarCotizacionIndirecta()
        {
            if (mode != "borrador")
                CotizacionIndirecta = ClsCotizacionIndirecta.ObtieneCotizacionIndirecta(CotizacionIndirecta.Id32).ObjetoTransaccion as CotizacionIndirecta;
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

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            Close();
        }

        private void grpOportunidad_Enter(object sender, EventArgs e)
        {

        }

        private void txtFecha_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var form = new FrmNuevaTarifa();
            form.ShowDialog();
        }
    }
}
