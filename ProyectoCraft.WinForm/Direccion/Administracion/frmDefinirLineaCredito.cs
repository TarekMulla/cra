using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.LogicaNegocios.Parametros;
using ProyectoCraft.LogicaNegocios.Clientes;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Clientes.Target;
using ProyectoCraft.Entidades.Clientes.Contacto;
using ProyectoCraft.Entidades.Clientes.Cuenta;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Direccion.Administracion;
using ProyectoCraft.Entidades.Tarifado;

namespace ProyectoCraft.WinForm.Direccion.Administracion
{
    public partial class frmDefinirLineaCredito : Form
    {
        private static frmDefinirLineaCredito _form = null;
        public frmDefinirLineaCredito()
        {
            InitializeComponent();
        }
        public static frmDefinirLineaCredito Instancia
        {
            get
            {
                if (_form == null)
                    _form = new frmDefinirLineaCredito();

                return _form;
            }
            set
            {
                _form = value;
            }
        }
        private void EditarRegistro(int fila_sel)
        {
            clsCreditoCliente ObjCreditoCliente = new clsCreditoCliente();

            ObjCreditoCliente =  (clsCreditoCliente)gridViewLineaCredito.GetRow(fila_sel);
            this.cboCuenta.SelectedItem = ObjCreditoCliente.ObjCuenta;
            this.cboMoneda.SelectedItem = ObjCreditoCliente.ObjMoneda;
            this.cboCategoria.SelectedItem = ObjCreditoCliente.ObjCuentaClasificacion;
            this.txtMonto.Text = ObjCreditoCliente.MontoLineaCredito.ToString();
            this.txtId.Text = ObjCreditoCliente.Id.ToString();
        }
        private void CargarMonedas()
        {
            IList<Entidades.Tarifado.clsTipoMoneda> lstMonedas = clsParametros.ListarMonedas();
            ComboBoxItemCollection coll = cboMoneda.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in lstMonedas)
            {
                coll.Add(list);
            }
            this.cboMoneda.SelectedIndex = 0;
        }
        private static Entidades.GlobalObject.ResultadoTransaccion AgregarCreditoCliente(clsCreditoCliente ObjCredito)
        {
            Entidades.GlobalObject.ResultadoTransaccion res = new Entidades.GlobalObject.ResultadoTransaccion();

            res = LogicaNegocios.Direccion.Administracion.clsControlCredito.GuardarCreditoCliente(ObjCredito);
            return res;
         }
        private void Limpia()
        {
            CargarMonedas();
            cboMoneda.SelectedIndex = 1;
            CargarClasificaciones();
            CargarCuentas();
            txtMonto.Text = "";
        }
        private void ActualizarGrilla()
        {
            Entidades.GlobalObject.ResultadoTransaccion res =
                LogicaNegocios.Direccion.Administracion.clsControlCredito.ListarCreditoClientes();

            IList<clsCreditoCliente> ListaCreditoClientes = (IList<clsCreditoCliente>)res.ObjetoTransaccion;

            this.gridLineaCredito.DataSource = null;
            this.gridLineaCredito.DataSource = ListaCreditoClientes;
        }
        private void CargarClasificaciones()
        {
            IList<clsCuentaclasificacion> clasificaciones =
                LogicaNegocios.Clientes.clsCuentas.ListarClasificaciones(Enums.Estado.Habilitado);

            ComboBoxItemCollection coll = cboCategoria.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in clasificaciones)
            {
                coll.Add(list);
            }
            cboCategoria.SelectedIndex = 0;
        }
        private void CargarCuentas()
        {
            //Llena el combo con la lista de Targets
            this.cboCuenta.ResetText();
            IList<clsClienteMaster> listCuentas = LogicaNegocios.Clientes.clsClientesMaster.ListarClienteMaster("", Enums.TipoPersona.Cuenta, Enums.Estado.Habilitado,true);

            ComboBoxItemCollection coll = cboCuenta.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listCuentas)
            {
                coll.Add(list);
            }

            cboCuenta.SelectedIndex = 0;

            AutoCompleteStringCollection textoAutocompletar = new AutoCompleteStringCollection();
            textoAutocompletar = new AutoCompleteStringCollection();

            cboCuenta.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCuenta.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (var list in listCuentas)
            {
                textoAutocompletar.Add(list.ToString());
            }
            cboCuenta.MaskBox.AutoCompleteCustomSource = textoAutocompletar;
            cboCuenta.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
        }
        private void frmDefinirLineaCredito_Load(object sender, EventArgs e)
        {
            Limpia();
            ActualizarGrilla();
         }
        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void frmDefinirLineaCredito_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            Entidades.GlobalObject.ResultadoTransaccion res;

            // Validar Datos Obligatorios
            // Cuenta
            if (cboCuenta.SelectedItem == null || cboCuenta.SelectedIndex <= 0)
            {
                ctrldxError.SetError(this.cboCuenta, "Debe Seleccionar una Cuenta", ErrorType.Critical);
                return;
            }
            else
            {
                ctrldxError.SetError(this.cboCuenta, "", ErrorType.None);
            }
            // Moneda
            if (cboMoneda.SelectedItem == null || cboMoneda.SelectedIndex <= 0)
            {
                ctrldxError.SetError(this.cboMoneda, "Debe Seleccionar la moneda definida para el crédito", ErrorType.Critical);
                return;
            }
            else
            {
                ctrldxError.SetError(this.cboMoneda, "", ErrorType.None);
            }
            // Monto Credito
            if (this.txtMonto.Text.Trim()=="")
            {
                ctrldxError.SetError(this.txtMonto, "Debe digitar el monto permitido de crédito", ErrorType.Critical);
                return;
            }
            else
            {
                ctrldxError.SetError(this.txtMonto, "", ErrorType.None);
            }

            clsCreditoCliente ObjClienteCredito = new clsCreditoCliente();

            if (this.txtId.Text.Trim() == "")
            {
                //Nuevo Registro
                ObjClienteCredito.Id = 0;
            }
            else
            {
                ObjClienteCredito.Id = Convert.ToInt32(txtId.Text);
            }

            ObjClienteCredito.MontoLineaCredito = Convert.ToDouble(this.txtMonto.Text);
            ObjClienteCredito.ObjCuenta = new clsClienteMaster(true);
            ObjClienteCredito.ObjCuenta = (clsClienteMaster)cboCuenta.SelectedItem;

            ObjClienteCredito.ObjMoneda = new clsTipoMoneda();
            ObjClienteCredito.ObjMoneda = (clsTipoMoneda) cboMoneda.SelectedItem;

            res=AgregarCreditoCliente(ObjClienteCredito);
            if (res.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                ActualizarGrilla();
                cboCuenta.Focus();
            }
            else
            {
                MessageBox.Show(res.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Actualizar Consulta Grilla
        }

        private void cboCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SelectNextControl(this.cboMoneda, true, true, true, true);
            }
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cboMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SelectNextControl(this.txtMonto, true, true, true, true);
            }
        }

        private void cboCuenta_Enter(object sender, EventArgs e)
        {
            this.cboCuenta.SelectionStart = 0;
            this.cboCuenta.SelectionLength = this.cboCuenta.Text.Length;
        }

        private void cboMoneda_Enter(object sender, EventArgs e)
        {
            this.cboMoneda.SelectionStart = 0;
            this.cboMoneda.SelectionLength = this.cboMoneda.Text.Length;
        }

        private void txtMonto_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtMonto_Enter(object sender, EventArgs e)
        {
            this.txtMonto.SelectionStart = 0;
            this.txtMonto.SelectionLength = this.cboMoneda.Text.Length;
        }

        private void gridLineaCredito_Click(object sender, EventArgs e)
        {

        }

        private void gridLineaCredito_DoubleClick(object sender, EventArgs e)
        {
            int fila_sel;
            if (gridViewLineaCredito.SelectedRowsCount == 1)
            {
                fila_sel = this.gridViewLineaCredito.GetSelectedRows()[0];
                EditarRegistro(fila_sel);
                txtMonto.Focus();
            }
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            Limpia();
            cboCuenta.Focus();
        }
    }
}
