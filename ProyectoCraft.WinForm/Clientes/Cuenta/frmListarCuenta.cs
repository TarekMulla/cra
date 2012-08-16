using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using ProyectoCraft.Entidades.Clientes.Cuenta;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.LogicaNegocios.Clientes;

namespace ProyectoCraft.WinForm.Clientes.Cuenta
{
    public partial class frmListarCuenta : Form
    {
        public frmListarCuenta()
        {
            InitializeComponent();
        }

        private static frmListarCuenta instancia = null;
        public static frmListarCuenta Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new frmListarCuenta();

                return instancia;
            }
            set
            {
                instancia = value;
            }
        }

        private void MenuNuevoTarget_Click(object sender, EventArgs e)
        {
            frmCuenta form = frmCuenta.Instancia;
            form.Accion = Entidades.Enums.Enums.TipoAccionFormulario.Nuevo;
            form.ShowDialog();
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void frmListarCuenta_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }

        private void frmListarCuenta_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            lstTipoBusqueda.SelectedIndex = 3;

            //ListarCuentas();
            CargarVendedores();
            CargarCustomers();
        }

        public string Nombre { get; set; }
        public Int64 IdVendedor { get; set; }
        public Int64 IdCustumer { get; set; }
        public Int16 IdEstado { get; set; }

        public void ListarCuentas()
        {            
            IList<clsCuenta> listCuentas = clsCuentas.ListarCuentas(Nombre, IdVendedor, IdCustumer, IdEstado);                                                                                                        
            grdCuentas.DataSource = listCuentas;
            grdCuentas.RefreshDataSource();
        }

        private void CargarVendedores()
        {
            Entidades.GlobalObject.ResultadoTransaccion res = LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Entidades.Enums.Enums.Estado.Habilitado, Entidades.Enums.Enums.CargosUsuarios.Vendedor);
            IList<Entidades.Usuarios.clsUsuario> listVendedores = (IList<Entidades.Usuarios.clsUsuario>)res.ObjetoTransaccion;

            ComboBoxItemCollection coll = cboVendedores.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listVendedores)
            {
                coll.Add(list);
            }
            cboVendedores.SelectedIndex = 0;
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(txtVendedor.Text);

            foreach (var list in listVendedores)
            {
                auto.Add(list.Nombre + " " + list.ApellidoPaterno + " " + list.ApellidoMaterno);
            }

            txtVendedor.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtVendedor.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtVendedor.MaskBox.AutoCompleteCustomSource = auto;
        }

        private void CargarCustomers()
        {
            Entidades.GlobalObject.ResultadoTransaccion res = LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Entidades.Enums.Enums.Estado.Habilitado, Entidades.Enums.Enums.CargosUsuarios.CustomerService);
            IList<Entidades.Usuarios.clsUsuario> listCustomers = (IList<Entidades.Usuarios.clsUsuario>)res.ObjetoTransaccion;

            ComboBoxItemCollection coll = cboCustomers.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listCustomers)
            {
                coll.Add(list);
            }
            cboCustomers.SelectedIndex = 0;
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(txtVendedor.Text);

            foreach (var list in listCustomers)
            {
                auto.Add(list.Nombre + " " + list.ApellidoPaterno + " " + list.ApellidoMaterno);
            }

            txtCustomer.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCustomer.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCustomer.MaskBox.AutoCompleteCustomSource = auto;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtNombreCompania.Text.Trim() != "")
                Nombre = txtNombreCompania.Text;
            else
                Nombre = "-1";

            if (txtVendedor.Text.Trim() != "")
            {
                cboVendedores.SelectedIndex = 0;
                for (int i = 0; i < cboVendedores.Properties.Items.Count; i++)
                {
                    if (cboVendedores.Properties.Items[i].ToString() == txtVendedor.Text)
                        cboVendedores.SelectedIndex = i;
                }

                if (cboVendedores.SelectedIndex != 0)
                {
                    IdVendedor = ((Entidades.Usuarios.clsUsuario)this.cboVendedores.SelectedItem).Id;
                }
                else
                {
                    MessageBox.Show("El vendedor no es valido", "Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (txtCustomer.Text.Trim() != "")
            {
                cboCustomers.SelectedIndex = 0;
                for (int i = 0; i < cboCustomers.Properties.Items.Count; i++)
                {
                    if (cboCustomers.Properties.Items[i].ToString() == txtCustomer.Text)
                        cboCustomers.SelectedIndex = i;
                }

                if (cboCustomers.SelectedIndex != 0)
                {
                    IdCustumer = ((Entidades.Usuarios.clsUsuario)this.cboCustomers.SelectedItem).Id;
                }
                else
                {
                    MessageBox.Show("El Customer no es valido", "Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            IdEstado = (Int16)Entidades.Enums.Enums.Estado.Habilitado;

            //lstTipoBusqueda.SelectedIndex = -1;

            ListarCuentas();
        }

        private void MenuVerDatos_Click(object sender, EventArgs e)
        {

            clsCuenta cuenta = ObtenerCuenta();
            frmCuenta form = frmCuenta.Instancia;
            
            if(cuenta != null)
            {
                form.CuentaActual = cuenta;                
                form.FormLoad();
                if(form.CargarFormulario())
                {
                    form.Accion = Entidades.Enums.Enums.TipoAccionFormulario.Editar;
                    form.ShowDialog();    
                }                
            }
            else
                MessageBox.Show("Debe seleccionar una Cuenta", "Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Warning);           
        }

        private void lstTipoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTipoBusqueda.SelectedIndex == 0)
                IdEstado = -1;
            else if (lstTipoBusqueda.SelectedIndex == 2)
                IdEstado = (Int16)Entidades.Enums.Enums.Estado.Deshabilitado;
            else 
                IdEstado =(Int16)lstTipoBusqueda.SelectedIndex;

            IdVendedor = -1;
            IdCustumer = -1;

            if(lstTipoBusqueda.SelectedIndex == 3)
            {
                IdEstado = 1;
                if(Base.Usuario.UsuarioConectado.Usuario.Cargo.Id == (Int16)Entidades.Enums.Enums.CargosUsuarios.Vendedor)
                {
                    IdVendedor = Base.Usuario.UsuarioConectado.Usuario.Id;
                }
                if (Base.Usuario.UsuarioConectado.Usuario.Cargo.Id == (Int16)Entidades.Enums.Enums.CargosUsuarios.CustomerService)
                {
                    IdCustumer = Base.Usuario.UsuarioConectado.Usuario.Id;
                }

            }

            Nombre = "-1";            
            ListarCuentas();
        }

        private clsCuenta ObtenerCuenta()
        {
            var filaSelected = grdCuentas.DefaultView.GetRow(gridView1.FocusedRowHandle);

            if (filaSelected == null)
            {
                return null;
            }

            clsCuenta cuenta = (clsCuenta)filaSelected;

            return cuenta;
        }

        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            clsCuenta Cuentatemp = ObtenerCuenta();

            if (Cuentatemp != null)
            {
                DialogResult resdialogo = MessageBox.Show("¿Está seguro de eliminar la Cuenta", "Target", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resdialogo == System.Windows.Forms.DialogResult.Yes)
                {
                    ResultadoTransaccion res = clsCuentas.BuscarCuentaPorId(Cuentatemp.Id);
                    if (res.Estado == Entidades.Enums.Enums.EstadoTransaccion.Aceptada)
                    {
                        clsCuenta cuenta = (clsCuenta)res.ObjetoTransaccion;

                        res = new ResultadoTransaccion();
                        res = clsCuentas.EliminarCuenta(cuenta);

                        if (res.Estado == Entidades.Enums.Enums.EstadoTransaccion.Aceptada)
                        {
                            ListarCuentas();
                        }
                        else
                            MessageBox.Show(res.Descripcion, "Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar a Cuenta", "Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void lstTipoBusqueda_Click(object sender, EventArgs e)
        {
            if (lstTipoBusqueda.SelectedIndex == 0)
                IdEstado = -1;
            else if (lstTipoBusqueda.SelectedIndex == 2)
                IdEstado = (Int16)Entidades.Enums.Enums.Estado.Deshabilitado;
            else
                IdEstado = (Int16)lstTipoBusqueda.SelectedIndex;

            IdVendedor = -1;
            IdCustumer = -1;

            if (lstTipoBusqueda.SelectedIndex == 3)
            {
                IdEstado = 1;
                if (Base.Usuario.UsuarioConectado.Usuario.Cargo.Id == (Int16)Entidades.Enums.Enums.CargosUsuarios.Vendedor)
                {
                    IdVendedor = Base.Usuario.UsuarioConectado.Usuario.Id;
                }
                if (Base.Usuario.UsuarioConectado.Usuario.Cargo.Id == (Int16)Entidades.Enums.Enums.CargosUsuarios.CustomerService)
                {
                    IdCustumer = Base.Usuario.UsuarioConectado.Usuario.Id;
                }

            }

            Nombre = "-1";
            ListarCuentas();
        }        
    }
}
