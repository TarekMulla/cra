using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Direccion.Metas;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.Entidades.Ventas.Productos;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.LogicaNegocios.Parametros;
using ProyectoCraft.LogicaNegocios.Direccion.Metas;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Paperless;
using SCCMultimodal.Utils;

namespace ProyectoCraft.WinForm.Direccion.Metas {
    public partial class frmDefinirSLead : Form {
        private static frmDefinirSLead _form = null;
        public  ClsSalesLead objSalesLead { set; get; }

        public static frmDefinirSLead Instancia {
            get { return _form ?? (_form = new frmDefinirSLead()); }
            set {
                _form = value;
            }
        }

        private void DesactivaControlesPanel(Control panel) {
            foreach (var control in panel.Controls) {
                var c = control as Control;

                if (c != null)
                    c.Enabled = false;

                if (c is LabelControl)
                    c.Enabled = true;
            }

        }

        private  void DeactivaFormulario() {
            
            DesactivaControlesPanel(groupControl3);
            DesactivaControlesPanel(groupControl1);
            DesactivaControlesPanel(groupControl2);
            DesactivaControlesPanel(groupBox2);
            DesactivaControlesPanel(groupBox3);
            DesactivaControlesPanel(groupBox4);

            toolStripBarraLlamada.Enabled = true;
            MenuSalir.Enabled = true;
            MenuNuevo.Enabled = false;



        }
        public frmDefinirSLead() {
            InitializeComponent();
        }


        private void CargarSalesLeadControls() {
            textSLeadReferencia.Text = objSalesLead.Reference;
            DateApertura.Text = objSalesLead.FechaApertura.ToString();
            DateRevision.Text = objSalesLead.FechaRevision.ToString();

            cboagente.SelectedItem = objSalesLead.Agente;



            txtShipNombre.Text = objSalesLead.ShipperWeb;
        }

        private void CargarCombosTipoCompetencia() {


            cmbTipoCompetencia.Properties.Items.Clear();
            var param= clsParametros.ListarParametrosPorTipo(Enums.TipoParametro.TipoCompentencia);
            foreach (var clsItemParametro in param.Items) {
                cmbTipoCompetencia.Properties.Items.Add(clsItemParametro);
            }
            if (cmbTipoCompetencia.Properties.Items.Count > 1)
                cmbTipoCompetencia.SelectedIndex = 0;
        }

        private void NuevoSLead() {
            DateApertura.DateTime = DateTime.Now;
            gridAsignaciones.DataSource = null;
            CargarComboTiposProductos("", "");
            CargarVendedores();
            CargarTerminosCompras();
            CargaIncoterms();
            CargarTiposDeContenedor();
            CargarUnidadesDeMedida();
            CargarAgentesExistentes();
            CargarCombosTipoCompetencia();

            
            DateRevision.Text = null;
            txtShipNombre.Text = txtShipDireccion.Text = txtShipZipCode.Text = txtShipContacto.Text =
                                                                               txtShipCiudad.Text =
                                                                               txtShipWeb.Text =
                                                                               txtShipPais.Text =
                                                                               txtShipTelefono.Text = String.Empty;

            txtConsigNombre.Text =
                txtConsigDireccion.Text =
                txtConsigCiudad.Text = txtConsigCiudad.Text = txtConsigContacto.Text = String.Empty;

            this.snNumEmbMes.Value = 0;

            txtCantidadAereo.Text = txtCantidadFCL.Text = txtCantidadLCL.Text = String.Empty;
            cboUMAereo.SelectedIndex = cboUMAereo.SelectedIndex = cboUMAereo.SelectedIndex = 0;

            DateUltimoEmbarque.Text = txtpol.Text = String.Empty;


            gridCompetencia.DataSource = null;

        }

        private void FrmDefinirSLeadLoad(object sender, EventArgs e) {
            NuevoSLead();
        }

        private void CargarAgentesExistentes()
        {
            cboagente.Properties.Items.Clear();
            ComboBoxItemCollection coll = this.cboagente.Properties.Items;
            IList<Entidades.Paperless.PaperlessAgente> listAgentes = new List<Entidades.Paperless.PaperlessAgente>();

            listAgentes = LogicaNegocios.Paperless.Paperless.ObtenerAgentes(Entidades.Enums.Enums.Estado.Habilitado);

            coll = this.cboagente.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listAgentes)
            {
                coll.Add(list);
            }
            this.cboagente.SelectedIndex = 0;
            this.cboagente.Properties.AutoComplete = true;

            //AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            //auto.Add(txtAgente.Text);
            //txtAgente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //txtAgente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //foreach (var list in listAgentes)
            //{
            //    auto.Add(list.Nombre);
            //}
            //txtAgente.AutoCompleteCustomSource = auto;
        }

        private void CargarUnidadesDeMedida()
        {
            clsParametrosInfo UMLCL =
                clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.UnidadMedidaLCL);
            Utils.Utils.CargaComboBoxParametros(UMLCL, cboUMLCL);

            clsParametrosInfo UMFCL =
                                clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.UnidadMedidaFCL);
            Utils.Utils.CargaComboBoxParametros(UMFCL, cboUMFCL);

            clsParametrosInfo UMAereo =
                clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.UnidadMedidaAereo);
            Utils.Utils.CargaComboBoxParametros(UMAereo, cboUMAereo);

        } 

        private void CargarComboTiposProductos(string expoImpo, string activo) {
            var res = LogicaNegocios.Ventas.Productos.clsTipoProducto.ListarTiposProducto(expoImpo, activo);
            var listaTiposProductos = (IList<clsTipoProducto>)res.ObjetoTransaccion;
            lstProductos.DataSource = null;
            lstProductos.DataSource = listaTiposProductos;
        }

        private void CargaIncoterms() {
            var incoterms = clsParametros.ListarParametrosPorTipo(Enums.TipoParametro.Incoterms);
            var  listaIncorterms= new List<clsItemParametro>();

            foreach (var item in incoterms.Items) 
                listaIncorterms.Add(item);

            lstIncoterms.DataSource = null;
            lstIncoterms.DataSource = listaIncorterms;
        }

        private void CargarTiposDeContenedor() {
            clsParametrosInfo lstTipoContenedores =
                clsParametros.ListarParametrosPorTipo(Enums.TipoParametro.TipoContenedor);
            Utils.Utils.CargaComboBoxParametros(lstTipoContenedores, this.lstTipoContenedor);
        }

        private void CargarTerminosCompras()
        {
            clsParametrosInfo TerminosCompra = clsParametros.ListarParametrosPorTipo(Enums.TipoParametro.TerminioCompra);
            IList<clsItemParametro> ListaTerminosCompra = new List<clsItemParametro>();

            foreach (var item in TerminosCompra.Items)
            {
                ListaTerminosCompra.Add(item);
            }
            lstTerminosCompra.DataSource = null;
            lstTerminosCompra.DataSource = ListaTerminosCompra;
        }
        private void CargarVendedores() {
            var res = LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Enums.Estado.Habilitado, Enums.CargosUsuarios.UsuarioSalesLead);
            var listVendedores = (IList<clsUsuario>)res.ObjetoTransaccion;

            ComboBoxItemCollection coll = cboVendedores.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listVendedores)
                coll.Add(list);

            cboVendedores.SelectedIndex = 0;
        }

        private void MenuNuevoClick(object sender, EventArgs e) {
            NuevoSLead();
        }

        private void SBAgregarClick(object sender, EventArgs e) {
            IList<clsMetaCompetencia> listaLlamadas = new List<clsMetaCompetencia>();

            if (gridCompetencia.DataSource != null) 
                listaLlamadas = (IList<clsMetaCompetencia>)gridCompetencia.DataSource;



            var objCompetencia = new clsMetaCompetencia {Descripcion = txtCompetencia.Text,TipoCompetencia = (clsItemParametro)cmbTipoCompetencia.SelectedItem};
            listaLlamadas.Add(objCompetencia);
            gridCompetencia.DataSource = null;
            gridCompetencia.DataSource = listaLlamadas;
            txtCompetencia.Text = string.Empty;
        }

        private void SButtonEliminarClick(object sender, EventArgs e) {
            gridViewCompetencia.DeleteSelectedRows();
        }

        private void MenuSalirClick(object sender, EventArgs e) {
            Instancia = null;
            Close();
        }

        private void BtnAsignarClick(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            if (ValidarDatos()) {
                if (!AsignarGrilla()) {
                    MessageBox.Show("El Sales Lead ya ha sido asignado al vendedor en esta sesión", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private bool AsignarGrilla() {

            var salesLead = new ClsSalesLead();

            // Inicializa Datos NO obligatorios
            salesLead.LCLCantidad = 0;
            salesLead.LCLMedida.Id=0;
            salesLead.FCLCantidad = 0;
            salesLead.FCLMedida.Id=0;
            salesLead.AereoCantidad = 0;
            salesLead.AereoMedida.Id=0;
            
            // Información general
            salesLead.GlosaSalesLead = this.textSLeadReferencia.Text;
            salesLead.FechaApertura = this.DateApertura.DateTime;
            salesLead.UsuarioAsignador = Base.Usuario.UsuarioConectado.Usuario;
            salesLead.EmbarquesPorMes = (Int32)snNumEmbMes.Value;

            salesLead.ObjTipoContenedor = (clsItemParametro)this.lstTipoContenedor.SelectedItem;

            if (DateUltimoEmbarque.Text == "")
            {
                salesLead.FechaUltimoEmbarque = new DateTime(2000, 1, 1);
            }
            else
            {
                salesLead.FechaUltimoEmbarque = DateUltimoEmbarque.DateTime;
            }
            

            salesLead.CarrierAirline = txtCarrier.Text;
            salesLead.Pol = txtpol.Text;
            salesLead.Pod = txtPod.Text;
            salesLead.EstadoSLead = Enums.EstadosSLead.Asignado;

            //Agente
            salesLead.Agente = new PaperlessAgente();
            salesLead.Agente = (PaperlessAgente)this.cboagente.SelectedItem;
            
            //Asignación del Venedror
            salesLead.Asignacion = new ClsSalesLeadAsignacion();
            salesLead.Asignacion.VendedorAsignado = (clsUsuario)cboVendedores.SelectedItem;
            salesLead.Asignacion.FechaAsignacion = this.DateApertura.DateTime;

            //Datos Shipper
            salesLead.ShipperNombre = txtShipNombre.Text;
            salesLead.Shipperdireccion = txtShipDireccion.Text;
            salesLead.ShipperZipCode = txtShipZipCode.Text;
            salesLead.ShipperCiudad = txtShipCiudad.Text;
            salesLead.ShipperContacto = txtShipContacto.Text;
            salesLead.ShipperEmail = txtShipEmail.Text;
            salesLead.ShipperWeb = txtShipWeb.Text;
            salesLead.ShipperFono = txtShipTelefono.Text;
            salesLead.ShipperPais = txtShipPais.Text;

            //Datos Consignatario
            salesLead.ConsigContacto = txtConsigContacto.Text;
            salesLead.ConsigDireccion = txtConsigDireccion.Text;
            salesLead.Consigciudad = txtConsigCiudad.Text;
            salesLead.ConsigNombre = txtConsigNombre.Text;
            salesLead.ConsigTelefono = txtConsigTelefono.Text;
            salesLead.ConsigEmail = txtconsigEmail.Text;
            salesLead.GlosaCommodity = txtCommodity.Text;

            //Tipos de Producto
            foreach (clsTipoProducto i in lstProductos.CheckedItems) 
                salesLead.TiposProductos.Add(i);

            //Unidades de Medida
            if (this.txtCantidadLCL.Text != "")
            {
                salesLead.LCLCantidad = Convert.ToInt64(txtCantidadLCL.Text);
                if (this.cboUMLCL.SelectedIndex > 0)
                {
                    salesLead.LCLMedida = (clsItemParametro)cboUMLCL.SelectedItem;
                }
            }
            if (this.txtCantidadFCL.Text != "")
            {
                salesLead.FCLCantidad = Convert.ToInt64(txtCantidadFCL.Text);
                if (this.cboUMFCL.SelectedIndex > 0)
                {
                    salesLead.FCLMedida = (clsItemParametro)cboUMFCL.SelectedItem;
                }
            }
            if (this.txtCantidadAereo.Text != "")
            {
                salesLead.AereoCantidad = Convert.ToInt64(txtCantidadAereo.Text);
                if (this.cboUMAereo.SelectedIndex > 0)
                {
                    salesLead.AereoMedida = (clsItemParametro)cboUMAereo.SelectedItem;
                }
            }

            //Terminos de Compra
            for (int i = 0; i <= this.lstTerminosCompra.ItemCount - 1; i++)
            {
                clsItemParametro ObjPaso = new clsItemParametro();
                ObjPaso = (clsItemParametro)lstTerminosCompra.GetItemValue(i);
                if (lstTerminosCompra.GetItemCheckState(i) == CheckState.Checked)
                {
                    salesLead.TerminosCompra.Add(ObjPaso);
                }
            }


            //incoterms
            foreach (clsItemParametro incoterm in lstIncoterms.CheckedItems) 
                    salesLead.Incoterms.Add(incoterm);
            
            //Competencia
            if (this.gridCompetencia.DataSource != null)
            {
                salesLead.Competencias = (IList<clsMetaCompetencia>)gridCompetencia.DataSource;
            }

            //Follow UP
            if (salesLead.FollowUps.Count == 0) {
                var followup = new clsClienteFollowUp();
                followup.FechaFollowUp = DateRevision.DateTime;
                followup.Descripcion = "Primera reunión de seguimiento";
                followup.Usuario = salesLead.UsuarioAsignador;
                followup.Activo = true;
                salesLead.FollowUps.Add(followup);
            }
            
            var listaProspectos = (IList<ClsSalesLead>)gridAsignaciones.DataSource;
            if (listaProspectos== null)
                listaProspectos = new List<ClsSalesLead>();
            listaProspectos.Add(salesLead);
            gridAsignaciones.DataSource = listaProspectos;
            gridAsignaciones.RefreshDataSource();

            return true;
        }

        private bool ValidarDatos() {


            //Validacion de datos numeros
            Int32 tempValidacion;

            if (!String.IsNullOrEmpty(txtCantidadLCL.Text)) {
                if (!Int32.TryParse(txtCantidadLCL.Text, out tempValidacion)) {
                    ctrldxError.SetError(txtCantidadLCL, "La cantidad LCL debe ser Numerico", ErrorType.Critical);
                    return false;
                }
                ctrldxError.SetError(txtCantidadLCL, "", ErrorType.None);
                if (cboUMLCL.SelectedIndex == 0) {
                    ctrldxError.SetError(cboUMLCL, "Debe seleccionar una unidad de medida", ErrorType.Critical);
                    return false;
                }
                ctrldxError.SetError(cboUMLCL, "", ErrorType.None);
            }

            if (!String.IsNullOrEmpty(txtCantidadFCL.Text)) {
                if (!Int32.TryParse(txtCantidadFCL.Text, out tempValidacion)) {
                    ctrldxError.SetError(txtCantidadFCL, "La cantidad FCL debe ser Numerico", ErrorType.Critical);
                    return false;
                }
                ctrldxError.SetError(txtCantidadFCL, "", ErrorType.None);
                if (cboUMFCL.SelectedIndex == 0) {
                    ctrldxError.SetError(cboUMFCL, "Debe seleccionar una unidad de medida", ErrorType.Critical);
                    return false;
                }
                ctrldxError.SetError(cboUMFCL, "", ErrorType.None);
            }

            if (!String.IsNullOrEmpty(txtCantidadAereo.Text)) {
                if (!Int32.TryParse(txtCantidadAereo.Text, out tempValidacion)) {
                    ctrldxError.SetError(txtCantidadAereo, "La cantidad Aereo debe ser Numerico", ErrorType.Critical);
                    return false;
                }
                ctrldxError.SetError(txtCantidadAereo, "", ErrorType.None);
                if (cboUMAereo.SelectedIndex == 0) {
                    ctrldxError.SetError(cboUMAereo, "Debe seleccionar una unidad de medida", ErrorType.Critical);
                    return false;
                }
                ctrldxError.SetError(cboUMAereo, "", ErrorType.None);
            }


            //Valida Datos Obligatorios
            // Vendedor
            if (this.cboVendedores.Text == "" || this.cboVendedores.SelectedIndex <= 0)
            {
                ctrldxError.SetError(this.cboVendedores, "Debe seleccionar un vendedor", ErrorType.Critical);
                return false;
            }
            else
            {
                ctrldxError.SetError(this.cboVendedores, "", ErrorType.None);
            }
            // Fecha Revision
            if (this.DateRevision.Text == "")
            {
                ctrldxError.SetError(this.DateRevision, "Debe seleccionar una fecha de revisión", ErrorType.Critical);
                return false;
            }
            else
            {
                ctrldxError.SetError(this.DateRevision, "", ErrorType.None);
            }
            // Fecha Apertura
            if (this.DateApertura.Text == "")
            {
                ctrldxError.SetError(this.DateApertura, "Debe seleccionar una fecha de apertura", ErrorType.Critical);
                return false;
            }
            else
            {
                ctrldxError.SetError(this.DateApertura, "", ErrorType.None);
            }
            // Nombre Agente
            if (this.cboagente.SelectedIndex <= 0)
            {
                ctrldxError.SetError(this.cboagente, "Debe seleccionar un Agente", ErrorType.Critical);
                return false;
            }
            else
            {
                ctrldxError.SetError(this.cboagente, "", ErrorType.None);
            }
            

            // fecha follow up
            if (this.DateRevision.Text == "") {
                ctrldxError.SetError(this.DateRevision, "Debe ingresar la fecha de follow up", ErrorType.Critical);
                return false;
            } 
            ctrldxError.SetError(this.DateRevision, "", ErrorType.None);

            // Shipper Nombre 
            if (this.txtShipNombre.Text == "") {
                ctrldxError.SetError(this.txtShipNombre, "Debe digitar el Nombre del Shipper", ErrorType.Critical);
                return false;
            } else {
                ctrldxError.SetError(this.txtShipNombre, "", ErrorType.None);
            }
            


            // Fecha ultimo embarque
            if (DateUltimoEmbarque.Text == "") {
                ctrldxError.SetError(DateUltimoEmbarque, "Debe ingresar la fecha del ultimo embarque", ErrorType.Critical);
                return false;
            } 
            ctrldxError.SetError(DateUltimoEmbarque, "", ErrorType.None);
            



            return true;
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboagente_SelectedIndexChanged(object sender, EventArgs e)
        {
            PaperlessAgente ObjAgente = new PaperlessAgente();

            if (cboagente.SelectedIndex>0)
            {
                ObjAgente = (PaperlessAgente)cboagente.SelectedItem;
                this.txtContacto.Text = ObjAgente.Contacto.ToString();
            }
        }

        private void txtUltimoEmbarque_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void ButtonEnviar_Click(object sender, EventArgs e)
        {
            var mail = new EnvioMailObject();
            if (MessageBox.Show("¿Desea Ud. Asignar los SalesLead seleccionados?", "Sistema Comercial Craft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                IList<ClsSalesLead> ListaSalesLead = new List<ClsSalesLead>();

                if (this.gridAsignaciones.DataSource != null)
                {
                    ListaSalesLead = (IList<ClsSalesLead>)this.gridAsignaciones.DataSource;
                    ResultadoTransaccion Res = ClsSalesLeadNegocio.GuardarVariosClsSalesLead(ListaSalesLead);

                    if (Res.Estado == Enums.EstadoTransaccion.Rechazada)
                    {
                        MessageBox.Show(Res.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        ResultadoTransaccion Res2 = mail.EnviarAsignacionSalesLead(ListaSalesLead, ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario);
                        //ResultadoTransaccion Res2 = Utils.EnvioEmail.EnviarAsignacionSalesLead(ListaSalesLead, ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario);
                        if (Res2.Estado == Enums.EstadoTransaccion.Rechazada)
                        {
                            MessageBox.Show(Res.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }else{
                            MessageBox.Show(Res.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NuevoSLead();
                        }
                    }
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void frmDefinirSLead_FormClosed(object sender, FormClosedEventArgs e) {
            Instancia = null;
        } 
    }
}