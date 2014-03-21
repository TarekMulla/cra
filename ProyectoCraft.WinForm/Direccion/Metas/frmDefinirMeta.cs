using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Base.Log;
using DevExpress.XtraPrinting;
using ProyectoCraft.Entidades.Direccion.Metas;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Ventas.Productos;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.LogicaNegocios.Parametros;
using ProyectoCraft.LogicaNegocios.Direccion.Metas;
using SCCMultimodal.Utils;

namespace ProyectoCraft.WinForm.Direccion.Metas
{
    public partial class frmDefinirMeta : Form
    {
        long IdUsuario;

        public static frmDefinirMeta Instancia
        {
            get
            {
                if (_form == null)
                    _form = new frmDefinirMeta();

                return _form;
            }
            set
            {
                _form = value;
            }
        }
        public frmDefinirMeta()
        {
            InitializeComponent();
        }

        private static frmDefinirMeta _form = null;
        private void CargarGraficos(string Estados, long IdUsuario, DateTime FechaDesde, DateTime FechaHasta)
        {
            DataTable res =
                LogicaNegocios.Direccion.Metas.clsMetaNegocio.GraficaEstadoUsuario(Estados, IdUsuario,FechaDesde,FechaHasta);

            this.ChartProspectos.Series.Clear();
            this.ChartProspectos.SeriesDataMember = "Estado";
            this.ChartProspectos.SeriesTemplate.ArgumentDataMember = "Vendedor";
            this.ChartProspectos.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Value" });
            ChartProspectos.DataSource = (DataTable)res;
        }
        private void CargarComboCuentas(long IdUsuario, string Busqueda)
        {
            //Llena el combo con la lista de Targets
            CboCliente.ResetText();
            IList<clsClienteMaster> ListaClienteMaster = LogicaNegocios.Clientes.clsClientesMaster.ListarClienteMaster(Busqueda, Enums.TipoPersona.Cuenta, Enums.Estado.Habilitado, true);

            ComboBoxItemCollection coll = CboCliente.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in ListaClienteMaster)
            {
                coll.Add(list);
            }

            CboCliente.SelectedIndex = 0;

            AutoCompleteStringCollection textoAutocompletar = new AutoCompleteStringCollection();
            textoAutocompletar = new AutoCompleteStringCollection();

            CboCliente.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboCliente.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (var list in ListaClienteMaster)
            {
                textoAutocompletar.Add(list.NombreCliente);
            }
            CboCliente.MaskBox.AutoCompleteCustomSource = textoAutocompletar;
        }
        private void CargarCbosParametroTipoContenedor()
        {
            clsParametrosInfo lstTipoContenedores =
                clsParametros.ListarParametrosPorTipo(Enums.TipoParametro.TipoContenedor);
            Utils.Utils.CargaComboBoxParametros(lstTipoContenedores, this.lstTipoContenedor);
        }
        private void CargarCbosParametroPrioridad()
        {
            clsParametrosInfo lstTipoContenedores =
                clsParametros.ListarParametrosPorTipo(Enums.TipoParametro.Prioridad);
            Utils.Utils.CargaComboBoxParametros(lstTipoContenedores, this.cboPrioridad);
        }
        private void CargarComboTiposProductos(string ExpoImpo, string Activo)
        {
            Entidades.GlobalObject.ResultadoTransaccion res
                = LogicaNegocios.Ventas.Productos.clsTipoProducto.ListarTiposProducto(ExpoImpo, Activo);

            IList<clsTipoProducto> ListaTiposProductos = (IList<clsTipoProducto>)res.ObjetoTransaccion;
            lstProductos.DataSource = null;
            lstProductos.DataSource = ListaTiposProductos;
        }
        private void CargarVendedores()
        {
            Entidades.GlobalObject.ResultadoTransaccion res = LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Enums.Estado.Habilitado, Enums.CargosUsuarios.Vendedor);
            IList<clsUsuario> listVendedores = (IList<clsUsuario>)res.ObjetoTransaccion;

            ComboBoxItemCollection coll = cboVendedores.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listVendedores)
            {
                coll.Add(list);
            }
            cboVendedores.SelectedIndex = 0;

            //AutoCompleteStringCollection textoAutocompletar = new AutoCompleteStringCollection();
            //textoAutocompletar = new AutoCompleteStringCollection();
            //foreach (var list in listVendedores)
            //{
            //    textoAutocompletar.Add(list.Nombre);
            //}
        }
        private void NuevoIngreso()
        {
            this.rbCuenta.Checked = true;
            this.txtTarget.Text = "";
            this.CboCliente.SelectedIndex = 0;
            this.lstProductos.Refresh();
            this.gridCompetencia.DataSource = null;
            this.gridTraficos.DataSource = null;
            this.txtCommodity.Text = "";
            this.lstTipoContenedor.SelectedIndex = 0;
            this.DateRevision.DateTime = DateTime.Now;
            this.cboVendedores.SelectedIndex = 0;
        }
        private Boolean AsignarProspectoGrilla()
        {
            clsMeta ObjMeta = new clsMeta();
            string Vendedor = "";
            long IdCliente = 0;
            string NombreProspecto = "";
            string TipoOportunidad = "";
            string Vendedor_paso = "";
            long IdCliente_paso = 0;
            string NombreProspecto_paso = "";
            string TipoOportunidad_paso = "";
            //ObjRegistroAsignacion.ObjMeta = new clsMeta();

            // Prospecto de nueva Cuenta
            if (this.rbCuenta.Checked == true)
            {
                ObjMeta.TipoOportunidad = "C";
                ObjMeta.GlosaClienteTarget = this.txtTarget.Text;
                // Se pone cero para indicar que en este caso no se requiere un valor
                // para el cliente master
                ObjMeta.ObjClienteMaster = new clsClienteMaster(true);
                ObjMeta.ObjClienteMaster.Id = -1;
                NombreProspecto_paso = ObjMeta.GlosaClienteTarget;
            }
            // Prospecto de nuevo Trafico
            else
            {
                ObjMeta.TipoOportunidad = "T";
                ObjMeta.GlosaClienteTarget = "";
                ObjMeta.ObjClienteMaster = (clsClienteMaster)CboCliente.SelectedItem;
                IdCliente_paso = ObjMeta.ObjClienteMaster.Id;
            }
            ObjMeta.TipoTarget = "P";
            ObjMeta.EstadoMeta = Enums.EstadosMetas.Propuesta;
            ObjMeta.UsuarioAsignador = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario;

            TipoOportunidad_paso = ObjMeta.TipoOportunidad;
            ObjMeta.ObjTipoProducto = new List<clsTipoProducto>();
            // AgregaProductosMeta
            foreach (clsTipoProducto i in lstProductos.CheckedItems)
            {
                ObjMeta.ObjTipoProducto.Add(i);
            }
            // AgregaProdutosTrafico
            ObjMeta.ObjMetaGlosasTrafico = (IList<clsMetaGlosasTrafico>)gridTraficos.DataSource;
            // AgregaCompetencia
            ObjMeta.ObjMetaCompetencia = (IList<clsMetaCompetencia>)gridCompetencia.DataSource;

            // AgregaVendedorAsignado
            ObjMeta.ObjMetaAsignacion = new clsMetaAsignacion();
            //            ObjRegistroAsignacion.ObjMeta.ObjMetaAsignacion.ObjVendedorAsignado = new clsUsuario();
            ObjMeta.ObjMetaAsignacion.ObjVendedorAsignado = (clsUsuario)cboVendedores.SelectedItem;
            Vendedor_paso = ObjMeta.ObjMetaAsignacion.ObjVendedorAsignado.NombreUsuario;

            // Fecha Asignacion
            ObjMeta.ObjMetaAsignacion.FechaAsignacion = DateTime.Today;

            // Agregar Commodity
            ObjMeta.GlosaCommodity = this.txtCommodity.Text;

            // Agregar Fecha Apertura
            ObjMeta.FechaApertura = this.DateApertura.DateTime;

            // Agregar Fecha de revisión de avance del prospecto
            //ObjMeta.FechaRevision = this.DateRevision.DateTime;
            if (ObjMeta.FollowUps == null) {
                ObjMeta.FollowUps = new List<clsClienteFollowUp>();
                if (ObjMeta.FollowUps.Count==0) {
                    var followup = new clsClienteFollowUp();
                    followup.FechaFollowUp = this.DateRevision.DateTime;
                    followup.Descripcion = "Primera reunión de seguimiento";
                    followup.Usuario = ObjMeta.UsuarioAsignador;
                    followup.Activo = true;
                    followup.Cliente = ObjMeta.ObjClienteMaster;
                    ObjMeta.FollowUps.Add(followup);
                }
            }

            // Agregar Tipo Contenedor
            ObjMeta.ObjTipoContenedor = (clsItemParametro)this.lstTipoContenedor.SelectedItem;

            // Prioridad
            ObjMeta.Prioridad = (clsItemParametro)this.cboPrioridad.SelectedItem;

            // Shipper
            ObjMeta.Shipper = this.txtShipper.Text;

            //Obtener el source actual de la grilla
            if (gridAsignaciones.DataSource != null)
            {
                IList<clsMeta> ListaProspectos = (IList<clsMeta>)gridAsignaciones.DataSource;
                foreach (clsMeta Prospecto in ListaProspectos)
                {
                    TipoOportunidad = Prospecto.TipoOportunidad;
                    if (TipoOportunidad == "C")
                    {
                        NombreProspecto = Prospecto.GlosaClienteTarget;
                    }
                    else
                    {
                        IdCliente = Prospecto.ObjClienteMaster.Id;
                    }
                    Vendedor = Prospecto.ObjMetaAsignacion.ObjVendedorAsignado.NombreUsuario;
                    if (Vendedor_paso == Vendedor && ((IdCliente == IdCliente_paso) || (NombreProspecto == NombreProspecto_paso)) && (TipoOportunidad == TipoOportunidad_paso))
                    {
                        return false;
                    }
                    else
                    {
                        ListaProspectos.Add(ObjMeta);
                    }
                    // Agrego el prospecto a la lista de prospectos asignados en la sesion
                    // ListaProspectos.Add(ObjRegistroAsignacion);
                    gridAsignaciones.DataSource = ListaProspectos;
                    gridAsignaciones.RefreshDataSource();
                }
            }
            else
            {
                IList<clsMeta> ListaProspectos = new List<clsMeta>();
                ListaProspectos.Add(ObjMeta);
                gridAsignaciones.DataSource = ListaProspectos;
            }
            return true;
        }
        private Boolean DatosValidos()
        {
            //Valida Datos Obligatorios
            //Tipo Cuenta
            if (this.rbCuenta.Checked == true && this.txtTarget.Text.Trim() == "")
            {
                ctrldxError.SetError(this.txtTarget, "Debe Digitar el nombre del Prospecto", ErrorType.Critical);
                return false;
            }
            else
            {
                ctrldxError.SetError(this.txtTarget, "", ErrorType.None);
            }
            // Tipo Prospecto
            if (this.rbTarget.Checked == true && (this.CboCliente.Text == "" || this.CboCliente.SelectedIndex <= 0))
            {
                ctrldxError.SetError(this.CboCliente, "Debe seleccionar la Cuenta", ErrorType.Critical);
                return false;
            }
            else
            {
                ctrldxError.SetError(this.CboCliente, "", ErrorType.None);
            }
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
            // Prioridad
            // LK 20-03-2014 Se incorpora linea para incorporar el selectedindex en la validacion
            if (this.cboPrioridad.Text  == "" || this.cboPrioridad.SelectedIndex<=0)
            {
                ctrldxError.SetError(this.cboPrioridad, "Debe seleccionar una prioridad para el Target", ErrorType.Critical);
                return false;
            }
            else
            {
                ctrldxError.SetError(this.cboPrioridad, "", ErrorType.None);
            }

            return true;

        }
        private void frmDefinirMeta_Load(object sender, EventArgs e)
        {
            DateTime FechaDesde;
            DateTime FechaHasta;

            IdUsuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario.Id;

            gridAsignaciones.DataSource = null;
            CargarComboTiposProductos("", "");
            CargarComboCuentas(IdUsuario, "");
            CargarVendedores();
            this.DateDesde.DateTime = System.DateTime.Now.AddMonths(-6);
            this.DateHasta.DateTime = System.DateTime.Now;
            this.DateApertura.DateTime = System.DateTime.Now;
            FechaDesde = DateDesde.DateTime.Date;
            FechaHasta = DateHasta.DateTime.Date;
            CargarGraficos("1,2,3", 0, FechaDesde, FechaHasta);
            CargarCbosParametroPrioridad();
            CargarCbosParametroTipoContenedor();
            this.lblTarget.Visible = true;
            this.txtTarget.Visible = true;
            rbCuenta.Checked = true;
            this.lblCuenta.Enabled = false;
            this.CboCliente.Enabled = false;
            this.lblTarget.Enabled = true;
            this.txtTarget.Enabled = true;
        }

        private void rbCuenta_CheckedChanged(object sender, EventArgs e)
        {
            this.lblCuenta.Enabled = false;
            this.CboCliente.Enabled = false;
            this.lblTarget.Enabled = true;
            this.txtTarget.Enabled = true;
        }

        private void rbTarget_CheckedChanged(object sender, EventArgs e)
        {
            this.lblCuenta.Enabled = true;
            this.CboCliente.Enabled = true;
            this.lblTarget.Enabled = false;
            this.txtTarget.Enabled = false;
        }

        private void sBAgregar_Click(object sender, EventArgs e)
        {
            IList<clsMetaCompetencia> ListaLlamadas = new List<clsMetaCompetencia>();

            if (this.gridCompetencia.DataSource != null)
            {
                ListaLlamadas = (IList<clsMetaCompetencia>)this.gridCompetencia.DataSource;
            }

            clsMetaCompetencia ObjCompetencia = new clsMetaCompetencia();
            ObjCompetencia.Descripcion = "";
            ListaLlamadas.Add(ObjCompetencia);

            this.gridCompetencia.DataSource = null;
            this.gridCompetencia.DataSource = ListaLlamadas;
        }

        private void sButtonEliminar_Click(object sender, EventArgs e)
        {
            this.gridViewCompetencia.DeleteSelectedRows();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ButtonAsignar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (DatosValidos())
            {
                if (!AsignarProspectoGrilla())
                {
                    MessageBox.Show("El Prospecto ya ha sido asignado al vendedor en esta sesión", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Cursor.Current = Cursors.Default;
        }

            private void MenuSalir_Click_1(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void frmDefinirMeta_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }

        private void sButtonAgregarTrafico_Click(object sender, EventArgs e)
        {
            IList<clsMetaGlosasTrafico> ListaTraficos = new List<clsMetaGlosasTrafico>();

            this.ChartProspectos.Series.Clear();
            if (this.gridTraficos.DataSource != null)
            {
                ListaTraficos = (IList<clsMetaGlosasTrafico>)this.gridTraficos.DataSource;
            }

            clsMetaGlosasTrafico ObjTraficos = new clsMetaGlosasTrafico();
            ObjTraficos.Glosa = "";
            ObjTraficos.TipoGlosa = "T";

            ListaTraficos.Add(ObjTraficos);

            this.gridTraficos.DataSource = null;
            this.gridTraficos.DataSource = ListaTraficos;
        }

        private void sButtonEliminarTrafico_Click(object sender, EventArgs e)
        {
            this.gridViewTraficos.DeleteSelectedRows();
        }

        private void ButtonEnviar_Click(object sender, EventArgs e)
        {
            var mail = new EnvioMailObject();
            if (MessageBox.Show("¿Desea Ud. Asignar los Target seleccionados?", "Sistema Comercial Craft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                IList<clsMeta> ListaProspectos = new List<clsMeta>();

                if (this.gridAsignaciones.DataSource != null)
                {
                    ListaProspectos = (IList<clsMeta>)this.gridAsignaciones.DataSource;
                    ResultadoTransaccion Res = clsMetaNegocio.GuardarVariosProspectos(ListaProspectos);
                    if (Res.Estado == Enums.EstadoTransaccion.Rechazada)
                    {
                        MessageBox.Show(Res.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        ResultadoTransaccion Res2 = mail.EnviarAsignacionTargets(ListaProspectos, ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario);
                        //ResultadoTransaccion Res2 = Utils.EnvioEmail.EnviarAsignacionTargets(ListaProspectos, ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario);
                        if (Res2.Estado == Enums.EstadoTransaccion.Rechazada)
                        {
                            MessageBox.Show(Res.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            NuevoIngreso();
                        }
                    }
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtTarget_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtTarget_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCommodity_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void lstTipoContenedor_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void txtCommodity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void lstTipoContenedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void DateRevision_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCommodity_EditValueChanged_1(object sender, EventArgs e)
        {

        }

        private void DateApertura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }

        }

        private void cboVendedores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboVendedores_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void CboCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTarget_Enter(object sender, EventArgs e)
        {

        }

        private void txtTarget_Click(object sender, EventArgs e)
        {
            this.txtTarget.SelectAll();
        }

        private void rbCuenta_Enter(object sender, EventArgs e)
        {
        }

        private void txtCommodity_Enter(object sender, EventArgs e)
        {
            this.txtCommodity.SelectAll();
        }

        private void txtCommodity_Click(object sender, EventArgs e)
        {
            this.txtCommodity.SelectAll();
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DateDesde_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void DateHasta_Leave(object sender, EventArgs e)
        {
            DateTime FechaDesde;
            DateTime FechaHasta;

            Cursor.Current = Cursors.WaitCursor;
            FechaDesde = DateDesde.DateTime.Date;
            FechaHasta = DateHasta.DateTime.Date;
            CargarGraficos("1,2,3", 0,FechaDesde,FechaHasta);
            Cursor.Current = Cursors.Default;
        }

        private void DateHasta_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void DateDesde_Leave(object sender, EventArgs e)
        {
            DateTime FechaDesde;
            DateTime FechaHasta;

            Cursor.Current = Cursors.WaitCursor;
            FechaDesde = DateDesde.DateTime.Date;
            FechaHasta = DateHasta.DateTime.Date;
            CargarGraficos("1,2,3", 0, FechaDesde, FechaHasta);
            Cursor.Current = Cursors.Default;
        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}