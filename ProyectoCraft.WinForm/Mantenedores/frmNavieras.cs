using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProyectoCraft.Entidades.Clientes.Cuenta;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.LogicaNegocios.Clientes;
using ProyectoCraft.LogicaNegocios.Mantenedores;

//namespace SCCMultimodal.Mantenedores
namespace ProyectoCraft.WinForm.Clientes
{
    public partial class frmNavieras : Form
    {
        private static frmNavieras _instancia = null;
        public static frmNavieras Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmNavieras();

                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        //public string Nombre { get; set; }
        //public Int64 Id { get; set; }
        //public bool Activo { get; set; }
        //public DateTime FechaCreacion { get; set; }

        private ClsNaviera _navieraactual;
        public ClsNaviera NavieraActual
        {
            get
            {
                if (_navieraactual == null)
                    _navieraactual = new ClsNaviera();

                return _navieraactual;
            }
            set { _navieraactual = value; }
        }
        private Enums.TipoAccionFormulario _accion;
        public Enums.TipoAccionFormulario Accion
        {
            get { return _accion; }
            set { _accion = value; }
        }

        public frmNavieras()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarNavieras();
        }
        public void ListarNavieras()
        {
            IList<ClsNaviera> listNavieras = ClsNavieras.ListarNavieras(true);
            grdNavieras.DataSource = listNavieras;
            grdNavieras.RefreshDataSource();
        }
        public void FormLoad()
        {
        }

        private void MenuVerDatos_Click(object sender, EventArgs e)
        {

            ClsNaviera naviera = ObtenerNaviera();
            frmNavieras form = frmNavieras.Instancia;


            if (naviera != null)
            {
                form.NavieraActual = naviera;
                txtNombre.Text = naviera.Nombre;
                txtId.Text = naviera.Id.ToString();

            }
            else
                MessageBox.Show("Debe seleccionar una Naviera", "Naviera", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private ClsNaviera ObtenerNaviera()
        {
            var filaSelected = grdNavieras.DefaultView.GetRow(gridView1.FocusedRowHandle);

            if (filaSelected == null)
            {
                return null;
            }

            ClsNaviera naviera = (ClsNaviera)filaSelected;

            return naviera;
        }

        private void MenuGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtId.Text))
            {
                var res = ClsNavieras.ActualizarNaviera(Convert.ToInt64(txtId.Text), txtNombre.Text);
                MessageBox.Show(res.Descripcion, "Naviera", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarDatos();
            }
            else if (!string.IsNullOrEmpty(txtNombre.Text) && string.IsNullOrEmpty(txtId.Text))
            {
                var res = ClsNavieras.NuevaNaviera(txtNombre.Text.Trim());
                MessageBox.Show(res.Descripcion, "Naviera", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarDatos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro para Editar", "Naviera", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LimpiarDatos()
        {
            txtNombre.Text = "";
            txtId.Text = "";
        }

        private void Menu_Nuevo_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }

        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            ClsNaviera naviera = ObtenerNaviera();
            frmNavieras form = frmNavieras.Instancia;
            if (naviera != null)
            {
                form.NavieraActual = naviera;
                txtNombre.Text = naviera.Nombre;
                txtId.Text = naviera.Id.ToString();
            }

            if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtId.Text))
            {
                var res = ClsNavieras.EliminaNaviera(Convert.ToInt64(txtId.Text));
                MessageBox.Show(res.Descripcion, "Naviera", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarDatos();
                ListarNavieras();
            }
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }
    }
}
