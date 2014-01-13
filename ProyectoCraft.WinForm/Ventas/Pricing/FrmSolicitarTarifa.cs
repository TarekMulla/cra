using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Settings;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.Entidades.Ventas.Pricing;
using ProyectoCraft.LogicaNegocios.Parametros;
using ProyectoCraft.LogicaNegocios.Usuarios;


namespace SCCMultimodal.Ventas.Pricing {
    public partial class FrmSolicitarTarifa : Form {
        public FrmSolicitarTarifa() {
            InitializeComponent();
        }

        private List<clsClienteMaster> Clientes { set; get; }
        private List<ClsItem> Items { set; get; }

        private static FrmSolicitarTarifa _form = null;
        public static FrmSolicitarTarifa Instancia {
            get {
                if (_form == null)
                    _form = new FrmSolicitarTarifa();

                return _form;
            }
            set {
                _form = value;
            }
        }

        public FrmListarCotizaciones FrmListarCotizaciones { set; get; }

        private void SolicitarTarifa_Load(object sender, EventArgs e) {
            
            
            CargarComboTodosClientes(0, "");
            CargasUsuariosPricing();
            TxtFecha.DateTime = DateTime.Now;
            var txt = TxtCliente;
            if (txt.MaskBox.AutoCompleteCustomSource.Count == 0) {
                txt.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt.MaskBox.AutoCompleteCustomSource = GetClientes(txt);
            }
            txtEjecutivo.Text = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario.NombreCompleto;
            
            if (txtNaviera.MaskBox.AutoCompleteCustomSource.Count==0) {
                txtNaviera.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtNaviera.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtNaviera.MaskBox.AutoCompleteCustomSource = GetNavieras(txt);
            }

        }

        private void CargasUsuariosPricing(){
            var resultado =  clsUsuarios.ObtieneUsuariosDeUnPerfil(24);
            var usuarios = resultado.ObjetoTransaccion as List<ProyectoCraft.Entidades.Usuarios.clsUsuario>;
            foreach (var usuario in usuarios){
                CboPrecingAsignado.Properties.Items.Add(usuario);
            }
            CboPrecingAsignado.SelectedIndex=0;
        }

        private AutoCompleteStringCollection GetNavieras(DevExpress.XtraEditors.TextEdit txt) {
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (var list in comboNaviera.Properties.Items)
                auto.Add(list.ToString());
            return auto;
        }

        private AutoCompleteStringCollection GetClientes(DevExpress.XtraEditors.TextEdit txt) {
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (var list in CboCliente.Properties.Items)
                auto.Add(list.ToString());
            return auto;
        }
        private void MenuSalir_Click(object sender, EventArgs e) {
            Instancia = null;
            this.Close();
        }

        private void CargarComboTodosClientes(long IdUsuario, string Busqueda) {
            //Llena el combo con la lista de Targets
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

        private void ChkExw_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExw.Checked)
                LblPol.Visible = txtPol.Visible = false;
        }

        private void ChkFob_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkFob.Checked)
                LblPol.Visible = txtPol.Visible = true;
        }

        private void ChkFca_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkFca.Checked)
                LblPol.Visible = txtPol.Visible = true;
        }

        private void sButtonAgregarObservacion_Click(object sender, EventArgs e)
        {
            var foo = GridUnidad.DataSource as List<Unidad>;
            if (foo == null)
                foo = new List<Unidad>();
            foo.Add(new Unidad());
            GridUnidad.DataSource = foo;
            GridUnidad.RefreshDataSource();
        }

        private void sButtonEliminarUnidad_Click(object sender, EventArgs e)
        {
            gridView1.DeleteSelectedRows();
        }

        private void FrmSolicitarTarifa_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var cotizacion = new ClsSolicitudCotizacionIndirecta();
            cotizacion.Usuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario;
            var c = Clientes.Find(foo => foo.NombreCliente.Equals(TxtCliente.Text));
            if (c != null)
                cotizacion.Cliente = c;
            else
            {
                cotizacion.Cliente = new clsClienteMaster(true) { NombreCompañia = TxtCliente.Text };
            }

            cotizacion.FechaSolicitud = DateTime.Now;
            cotizacion.POD = TxtPod.Text;
            cotizacion.POL = txtPol.Text;
            cotizacion.TarifaReferencia = TxtTarifa.Text;
            cotizacion.PuertoEmbarque = TxtPuertoEmbarque.Text;


            var list = (List<clsIncoTerm>)clsParametrosClientes.ListarIncoTerms(true);

            clsIncoTerm incoTerm = null;
            if (ChkFob.Checked)
                incoTerm = list.Find(foo => foo.Codigo.ToUpper().Equals("FOB"));
            if (ChkFca.Checked)
                incoTerm = list.Find(foo => foo.Codigo.ToUpper().Equals("FCA"));
            if (ChkExw.Checked)
                incoTerm = list.Find(foo => foo.Codigo.ToUpper().Equals("EXW"));

            cotizacion.IncoTerm = incoTerm;
            /*var tarifa = new ClsTarifa();
            tarifa.Detalle = gridView1.DataSource as List<ClsDetalleTarifa>;
            */
            cotizacion.AddTarifa(new ClsSolicitudCotizacionInDirectaOpciones());

            cotizacion.NavieraReferencia = txtNaviera.Text; //new ClsNavLiera();
            //cotizacion.NavieraReferencia.Nombre = txtNaviera.Text;

            cotizacion.Mercaderia = TxtMercaderia.Text;
            cotizacion.GastosLocales = TxtGastosLocales.Text;
            cotizacion.ProveedorCarga = TxtProveedor.Text;
            cotizacion.Comentario = TxtComentario.Text;
            cotizacion.UsuarioAsignadoPricing = CboPrecingAsignado.SelectedItem as clsUsuario;

            var res = ProyectoCraft.LogicaNegocios.Ventas.pricing.ClsCotizacion.GuardarCotizacion(cotizacion);
            MessageBox.Show(res.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            FrmListarCotizaciones.CargarGrillaCotizaciones();
            Close();
        }
    }
}
