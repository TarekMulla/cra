using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Direccion.Metas;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.Entidades.Ventas.Productos;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.LogicaNegocios.Direccion.Metas;
using ProyectoCraft.LogicaNegocios.Parametros;
using ProyectoCraft.Entidades.Paperless;

namespace ProyectoCraft.WinForm.Direccion.Metas {
    public partial class frmEditarSLead : Form {
        private static frmEditarSLead _form = null;
        public ClsSalesLead objSalesLead { set; get; }

        public static frmEditarSLead Instancia {
            get { return _form ?? (_form = new frmEditarSLead()); }
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

        private void CargarSalesLead() {
            // Información general
            DateApertura.DateTime = objSalesLead.FechaApertura;
            snNumEmbMes.Value = objSalesLead.EmbarquesPorMes;

            lstTipoContenedor.SelectedItem = objSalesLead.ObjTipoContenedor;
            DateUltimoEmbarque.DateTime = objSalesLead.FechaUltimoEmbarque;


            txtCarrier.Text = objSalesLead.CarrierAirline;
            txtpol.Text = objSalesLead.Pol;
            txtPod.Text = objSalesLead.Pod;

            // Inicializa Datos NO obligatorios
            txtCantidadLCL.Text = objSalesLead.LCLCantidad.ToString();
            txtCantidadFCL.Text = objSalesLead.FCLCantidad.ToString();
            txtCantidadAereo.Text = objSalesLead.AereoCantidad.ToString();


            //Agente
            cboagente.SelectedItem = objSalesLead.Agente;

            //Asignación del Venedror
            cboVendedores.SelectedItem = objSalesLead.Asignacion.VendedorAsignado;

            //Datos Shipper
            txtShipNombre.Text = objSalesLead.ShipperNombre; ;
            txtShipZipCode.Text = objSalesLead.ShipperZipCode;
            txtShipCiudad.Text = objSalesLead.ShipperCiudad;
            txtShipContacto.Text = objSalesLead.ShipperContacto;
            txtShipEmail.Text = objSalesLead.ShipperEmail;
            txtShipWeb.Text = objSalesLead.ShipperWeb;
            txtShipPais.Text = objSalesLead.ShipperPais;
            txtShipDireccion.Text = objSalesLead.Shipperdireccion;
            txtShipTelefono.Text = objSalesLead.ShipperFono;

            //Datos Consignatario
            txtConsigContacto.Text = objSalesLead.ConsigContacto;
            txtConsigDireccion.Text = objSalesLead.ConsigDireccion;
            txtConsigCiudad.Text = objSalesLead.Consigciudad;
            txtConsigNombre.Text = objSalesLead.ConsigNombre;
            txtConsigTelefono.Text = objSalesLead.ConsigTelefono;
            txtconsigEmail.Text = objSalesLead.ConsigEmail;
            txtCommodity.Text = objSalesLead.GlosaCommodity;

            //Unidades de Medida
            cboUMLCL.SelectedItem = objSalesLead.LCLMedida;
            cboUMFCL.SelectedItem = objSalesLead.FCLMedida;
            cboUMAereo.SelectedItem = objSalesLead.AereoMedida;

            //Terminos de Compra
            foreach (var clsItemParametro in objSalesLead.TerminosCompra) {
                foreach (CheckedListBoxItem item in lstTerminosCompra.Items) {
                    if (clsItemParametro.Id == ((clsItemParametro)item.Value).Id)
                        item.CheckState = CheckState.Checked;
                }
            }

            //incoterms
            foreach (clsItemParametro incoterm in objSalesLead.Incoterms)
                foreach (CheckedListBoxItem item in lstIncoterms.Items)
                    if (incoterm.Id == ((clsItemParametro)item.Value).Id)
                        item.CheckState = CheckState.Checked;
            //productos
            foreach (var clsTipoProducto in objSalesLead.TiposProductos)
                foreach (CheckedListBoxItem item in lstProductos.Items)
                    if (clsTipoProducto.Id == ((clsTipoProducto)item.Value).Id)
                        item.CheckState = CheckState.Checked;

            //Competencia
            gridCompetencia.DataSource = objSalesLead.Competencias;

            //Follow UP
            DateRevision.DateTime = objSalesLead.FechaRevision;
        }

        public frmEditarSLead() {
            InitializeComponent();
        }

        private void CargarCombosTipoCompetencia() {


            cmbTipoCompetencia.Properties.Items.Clear();
            var param = clsParametros.ListarParametrosPorTipo(Enums.TipoParametro.TipoCompentencia);
            foreach (var clsItemParametro in param.Items) {
                cmbTipoCompetencia.Properties.Items.Add(clsItemParametro);
            }
            if (cmbTipoCompetencia.Properties.Items.Count > 1)
                cmbTipoCompetencia.SelectedIndex = 0;
        }

        private void NuevoSLead() {
            DateApertura.DateTime = DateTime.Now;
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

            snNumEmbMes.Value = 0;

            txtCantidadAereo.Text = txtCantidadFCL.Text = txtCantidadLCL.Text = String.Empty;
            cboUMAereo.SelectedIndex = cboUMAereo.SelectedIndex = cboUMAereo.SelectedIndex = 0;

            DateUltimoEmbarque.Text = txtpol.Text = String.Empty;


            gridCompetencia.DataSource = null;

        }

        private void FrmDefinirSLeadLoad(object sender, EventArgs e) {
            NuevoSLead();
            CargarSalesLead();
        }

        private void CargarAgentesExistentes() {
            ComboBoxItemCollection coll = this.cboagente.Properties.Items;
            IList<Entidades.Paperless.PaperlessAgente> listAgentes = new List<Entidades.Paperless.PaperlessAgente>();

            listAgentes = LogicaNegocios.Paperless.Paperless.ObtenerAgentes(Entidades.Enums.Enums.Estado.Habilitado);

            coll = this.cboagente.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listAgentes) {
                coll.Add(list);
            }
            this.cboagente.SelectedIndex = 0;
            this.cboagente.Properties.AutoComplete = true;
        }

        private void CargarUnidadesDeMedida() {
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
            lstProductos.DataSource = null;
            lstProductos.Items.Clear();
            foreach (var tipoProducto in (IList<clsTipoProducto>)res.ObjetoTransaccion)
                lstProductos.Items.Add(tipoProducto);
        }

        private void CargaIncoterms() {
            var incoterms = clsParametros.ListarParametrosPorTipo(Enums.TipoParametro.Incoterms);
            lstIncoterms.DataSource = null;
            lstIncoterms.Items.Clear();
            foreach (var item in incoterms.Items)
                lstIncoterms.Items.Add(item);
        }

        private void CargarTiposDeContenedor() {
            clsParametrosInfo lstTipoContenedores =
                clsParametros.ListarParametrosPorTipo(Enums.TipoParametro.TipoContenedor);
            Utils.Utils.CargaComboBoxParametros(lstTipoContenedores, this.lstTipoContenedor);
        }

        private void CargarTerminosCompras() {
            clsParametrosInfo TerminosCompra = clsParametros.ListarParametrosPorTipo(Enums.TipoParametro.TerminioCompra);
            lstTerminosCompra.Items.Clear();
            foreach (var item in TerminosCompra.Items)
                lstTerminosCompra.Items.Add(item);
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

        private void SBAgregarClick(object sender, EventArgs e) {
            IList<clsMetaCompetencia> listaLlamadas = new List<clsMetaCompetencia>();

            if (gridCompetencia.DataSource != null)
                listaLlamadas = (IList<clsMetaCompetencia>)gridCompetencia.DataSource;



            var objCompetencia = new clsMetaCompetencia { Descripcion = txtCompetencia.Text, TipoCompetencia = (clsItemParametro)cmbTipoCompetencia.SelectedItem };
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
                var saleslead = ObtieneSalesLead();
                ResultadoTransaccion Res = ClsSalesLeadNegocio.EditarClsSalesLead(saleslead);
                if (Res.Estado == Enums.EstadoTransaccion.Rechazada) {
                    MessageBox.Show(Res.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else {
                    MessageBox.Show(Res.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private ClsSalesLead ObtieneSalesLead() {

            var salesLead = new ClsSalesLead();

            // Inicializa Datos NO obligatorios
            salesLead.LCLCantidad = 0;
            salesLead.LCLMedida.Id = 0;
            salesLead.FCLCantidad = 0;
            salesLead.FCLMedida.Id = 0;
            salesLead.AereoCantidad = 0;
            salesLead.AereoMedida.Id = 0;

            // Información general
            salesLead.GlosaSalesLead = this.textSLeadReferencia.Text;
            salesLead.FechaApertura = this.DateApertura.DateTime;
            salesLead.UsuarioAsignador = Base.Usuario.UsuarioConectado.Usuario;
            salesLead.EmbarquesPorMes = (Int32)snNumEmbMes.Value;

            salesLead.ObjTipoContenedor = (clsItemParametro)this.lstTipoContenedor.SelectedItem;

            if (DateUltimoEmbarque.Text == "") {
                salesLead.FechaUltimoEmbarque = new DateTime(2000, 1, 1);
            } else {
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
            foreach (CheckedListBoxItem  i in lstProductos.CheckedItems)
                salesLead.TiposProductos.Add((clsTipoProducto) i.Value);

            //Unidades de Medida
            if (this.txtCantidadLCL.Text != "") {
                salesLead.LCLCantidad = Convert.ToInt64(txtCantidadLCL.Text);
                if (this.cboUMLCL.SelectedIndex > 0) {
                    salesLead.LCLMedida = (clsItemParametro)cboUMLCL.SelectedItem;
                }
            }

            if (this.txtCantidadFCL.Text != "") {
                salesLead.FCLCantidad = Convert.ToInt64(txtCantidadFCL.Text);
                if (this.cboUMFCL.SelectedIndex > 0) {
                    salesLead.FCLMedida = (clsItemParametro)cboUMFCL.SelectedItem;
                }
            }

            if (this.txtCantidadAereo.Text != "") {
                salesLead.AereoCantidad = Convert.ToInt64(txtCantidadAereo.Text);
                if (this.cboUMAereo.SelectedIndex > 0) {
                    salesLead.AereoMedida = (clsItemParametro)cboUMAereo.SelectedItem;
                }
            }

            //Terminos de Compra
            for (int i = 0; i <= this.lstTerminosCompra.ItemCount - 1; i++) {
                clsItemParametro ObjPaso = new clsItemParametro();
                ObjPaso = (clsItemParametro)lstTerminosCompra.GetItemValue(i);
                if (lstTerminosCompra.GetItemCheckState(i) == CheckState.Checked) {
                    salesLead.TerminosCompra.Add(ObjPaso);
                }
            }


            //incoterms
            foreach (CheckedListBoxItem incoterm in lstIncoterms.CheckedItems)
                salesLead.Incoterms.Add((clsItemParametro)incoterm.Value);

            //Competencia
            if (this.gridCompetencia.DataSource != null) {
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
            salesLead.Id = objSalesLead.Id;
            salesLead.Id32 = objSalesLead.Id32;

            return salesLead;
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
            if (this.cboVendedores.Text == "" || this.cboVendedores.SelectedIndex <= 0) {
                ctrldxError.SetError(this.cboVendedores, "Debe seleccionar un vendedor", ErrorType.Critical);
                return false;
            } else {
                ctrldxError.SetError(this.cboVendedores, "", ErrorType.None);
            }
            // Fecha Revision
            if (this.DateRevision.Text == "") {
                ctrldxError.SetError(this.DateRevision, "Debe seleccionar una fecha de revisión", ErrorType.Critical);
                return false;
            } else {
                ctrldxError.SetError(this.DateRevision, "", ErrorType.None);
            }
            // Fecha Apertura
            if (this.DateApertura.Text == "") {
                ctrldxError.SetError(this.DateApertura, "Debe seleccionar una fecha de apertura", ErrorType.Critical);
                return false;
            } else {
                ctrldxError.SetError(this.DateApertura, "", ErrorType.None);
            }
            // Nombre Agente
            if (this.cboagente.SelectedIndex <= 0) {
                ctrldxError.SetError(this.cboagente, "Debe seleccionar un Agente", ErrorType.Critical);
                return false;
            } else {
                ctrldxError.SetError(this.cboagente, "", ErrorType.None);
            }
            // Shipper Nombre 
            if (this.txtShipNombre.Text == "") {
                ctrldxError.SetError(this.txtShipNombre, "Debe digitar el Nombre del Shipper", ErrorType.Critical);
                return false;
            } else {
                ctrldxError.SetError(this.txtShipNombre, "", ErrorType.None);
            }
            
            // fecha follow up
            if (this.DateRevision.Text == "") {
                ctrldxError.SetError(this.DateRevision, "Debe ingresar la fecha de follow up", ErrorType.Critical);
                return false;
            }
            ctrldxError.SetError(this.DateRevision, "", ErrorType.None);



            // Fecha ultimo embarque
            if (DateUltimoEmbarque.Text == "") {
                ctrldxError.SetError(DateUltimoEmbarque, "Debe ingresar la fecha del ultimo embarque", ErrorType.Critical);
                return false;
            }
            ctrldxError.SetError(DateUltimoEmbarque, "", ErrorType.None);




            return true;
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e) {

        }

        private void cboagente_SelectedIndexChanged(object sender, EventArgs e) {
            PaperlessAgente ObjAgente = new PaperlessAgente();

            if (cboagente.SelectedIndex > 0) {
                ObjAgente = (PaperlessAgente)cboagente.SelectedItem;
                this.txtContacto.Text = ObjAgente.Contacto.ToString();
            }
        }

        private void txtUltimoEmbarque_EditValueChanged(object sender, EventArgs e) {

        }

        private void txtShipPais_EditValueChanged(object sender, EventArgs e) {

        }

        private void txtShipTelefono_EditValueChanged(object sender, EventArgs e) {

        }
    }
}