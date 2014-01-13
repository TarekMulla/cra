using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Ventas.Pricing;
using ProyectoCraft.LogicaNegocios.Parametros;
using negocio = ProyectoCraft.LogicaNegocios.Ventas.pricing;

namespace SCCMultimodal.Ventas.Pricing
{
    public partial class FrmCotizacionDirecta : Form
    {
        private List<clsClienteMaster> Clientes { set; get; }
        private List<ClsItem> Items { set; get; }
        private ClsSolicitudCotizacionDirecta Cotizacion { set; get; }

        public FrmCotizacionDirecta()
        {
            InitializeComponent();
            Clientes = new List<clsClienteMaster>();
            Items = new List<ClsItem>();
            CargaItemTarifa();
        }

        private void CargaItemTarifa()
        {
            Items = negocio.ClsCotizacion.ListarCotizacionDirectaITems().ObjetoTransaccion as List<ClsItem>;
        }

        public FrmListarCotizaciones FrmListarCotizaciones { set; get; }
        private static FrmCotizacionDirecta _form = null;
        public static FrmCotizacionDirecta Instancia
        {
            get
            {
                if (_form == null)
                    _form = new FrmCotizacionDirecta();

                return _form;
            }
            set
            {
                _form = value;
            }
        }



        private void SolicitarTarifa_Load(object sender, EventArgs e)
        {
            Cotizacion = new ClsSolicitudCotizacionDirecta();
            Cotizacion.Opciones = new List<ClsSolicitudCotizacionDirectaOpciones>();
            Cotizacion.OpcionesDirecta = new List<ClsSolicitudCotizacionDirectaOpciones>();
            bindingSource1.DataSource = "Opcion";
            bindingSource1.DataSource = Cotizacion.OpcionesDirecta;

            txtNaviera.DataBindings.Add(new Binding("Text", bindingSource1, "Naviera", true));
            txtFechaValidez.DataBindings.Add(new Binding("Text", bindingSource1, "FechaValidezInicio", true));
            txtFechaValidezFin.DataBindings.Add(new Binding("Text", bindingSource1, "FechaValidezFin", true));
            //gridView1.DataSource
            GridUnidad.DataBindings.Add(new Binding("DataSource", bindingSource1, "Detalle"));

            CargarComboTodosClientes(0, "");
            TxtFecha.DateTime = DateTime.Now;
            txtEjecutivo.Text = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario.NombreCompleto;

            if (txtNaviera.MaskBox.AutoCompleteCustomSource.Count == 0)
            {
                txtNaviera.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtNaviera.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtNaviera.MaskBox.AutoCompleteCustomSource = GetNavieras(txtNaviera);
            }

        }


        private AutoCompleteStringCollection GetNavieras(DevExpress.XtraEditors.TextEdit txt)
        {
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (var list in comboNaviera.Properties.Items)
                auto.Add(list.ToString());
            return auto;
        }

        private AutoCompleteStringCollection GetClientes(DevExpress.XtraEditors.TextEdit txt)
        {
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (var list in CboCliente.Properties.Items)
                auto.Add(list.ToString());
            return auto;
        }
        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void CargarComboTodosClientes(long IdUsuario, string Busqueda)
        {
            //Llena el combo con la lista de Targets
            CboCliente.Properties.Items.Clear();

            Clientes =
                ProyectoCraft.LogicaNegocios.Clientes.clsClientesMaster.ListarClienteMaster(Busqueda, Enums.TipoPersona.Comercial,
                                                                              Enums.Estado.Todos, true) as List<clsClienteMaster>;

            ComboBoxItemCollection coll = CboCliente.Properties.Items;
            coll.Add(ProyectoCraft.WinForm.Utils.Utils.ObtenerPrimerItem());
            foreach (var list in Clientes)
                coll.Add(list);


            CboCliente.SelectedIndex = 0;
            CboCliente.Properties.AutoComplete = true;

            AutoCompleteStringCollection textoAutocompletar = new AutoCompleteStringCollection();
            textoAutocompletar = new AutoCompleteStringCollection();
            textoAutocompletar.Add(TxtCliente.Text);
            TxtCliente.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            TxtCliente.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (var list in Clientes)
                textoAutocompletar.Add(list.NombreCliente);

            TxtCliente.MaskBox.AutoCompleteCustomSource = textoAutocompletar;

        }

        private void sButtonAgregarObservacion_Click(object sender, EventArgs e)
        {
            var foo = GridUnidad.DataSource as List<ClsSolicitudCotizacionDirectaOpcionesDetalle>;
            if (foo == null)
                foo = new List<ClsSolicitudCotizacionDirectaOpcionesDetalle>();
            foo.Add(new ClsSolicitudCotizacionDirectaOpcionesDetalle());
            GridUnidad.DataSource = foo;
            GridUnidad.RefreshDataSource();
        }

        private void FrmCotizacionDirecta_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }

        private void sButtonEliminarUnidad_Click(object sender, EventArgs e)
        {
            gridView1.DeleteSelectedRows();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Cotizacion.Usuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario;
            var c = Clientes.Find(foo => foo.NombreCliente.Equals(TxtCliente.Text));
            if (c != null)
                Cotizacion.Cliente = c;
            else
                Cotizacion.Cliente = new clsClienteMaster(true) { NombreCompañia = TxtCliente.Text };
            

            Cotizacion.FechaSolicitud = DateTime.Now;
            Cotizacion.POD = TxtPod.Text;
            Cotizacion.POL = TxtPol.Text;
            

            var list = (List<clsIncoTerm>)clsParametrosClientes.ListarIncoTerms(true);
            var incoTerm = list.Find(foo => foo.Codigo.ToUpper().Equals("FOB"));
            Cotizacion.IncoTerm = incoTerm;

            Cotizacion.NavieraReferencia = txtNaviera.Text; 

            Cotizacion.Mercaderia = TxtMercaderia.Text;
            Cotizacion.GastosLocales = TxtGastosLocales.Text;
            Cotizacion.ProveedorCarga = TxtProveedor.Text;
            Cotizacion.Comentario = TxtComentario.Text;
            Cotizacion.Estado = ClsEstado.Estado.Ingresado;

            var res =  negocio.ClsCotizacion.GuardarSolicitudDeCotizacion(Cotizacion);
            MessageBox.Show(res.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            FrmListarCotizaciones.CargarGrillaCotizaciones();
           Close();
        }

        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            var foo = sender as GridView;

            if (foo.FocusedColumn.FieldName.Equals("Item.Nombre"))
            {
                DevExpress.XtraEditors.ComboBoxEdit cbo = (sender as DevExpress.XtraGrid.Views.Base.BaseView).ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                ComboBoxItemCollection coll = cbo.Properties.Items;
                foreach (var tipo in Items)
                    coll.Add(tipo.Nombre);
            }
        }
    }

    public class Unidad
    {
        public String Descripcion { set; get; }
        public Int32 Cantidad { set; get; }
        public Decimal Tarifa { set; get; }
    }
}

