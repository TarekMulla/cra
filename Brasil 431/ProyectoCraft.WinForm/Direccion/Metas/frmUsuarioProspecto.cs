using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Repository;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Usuarios;

namespace ProyectoCraft.WinForm.Direccion.Metas
{
    public partial class frmUsuarioProspecto : Form
    {
        public frmUsuarioProspecto()
        {
            InitializeComponent();
        }
        private static frmUsuarioProspecto _form = null;
        private static string _NombreProspecto = "";
        private static long  _IdVendedorActual = 0;
        private static long  _IdMeta = 0;
        private static string _NombreVendedorActual = "";
        public static string NombreProspecto
        {
            set
            {
                _NombreProspecto = value;
            }
        }
        public static long  IdVendedorActual
        {
            set
            {
                _IdVendedorActual = value;
            }
        }
        public static long  IdMeta
        {
            set
            {
                _IdMeta = value;
            }
        }
        public static string NombreVendedorActual
        {
            set
            {
                _NombreVendedorActual = value;
            }
        }
        public static frmUsuarioProspecto Instancia
        {
            get
            {
                if (_form == null)
                    _form = new frmUsuarioProspecto();

                return _form;
            }
            set
            {
                _form = value;
            }
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
        }
        private void frmUsuarioProspecto_Load(object sender, EventArgs e)
        {
            this.lblProspecto.Text = _NombreProspecto;
            this.lblVendedorA.Text = _NombreVendedorActual;
            this.lblFechaAsignacion.Text = Convert.ToString(DateTime.Now);
            CargarVendedores();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void sButtonSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void sButtonGrabarObs_Click(object sender, EventArgs e)
        {
            clsUsuario ObjUsuario;
            long IdVendedorAsignado;
            DateTime FechaAsignacion;
            int IdEstadoMeta;

            //Valida Datos Obligatorios
            if (_IdMeta==0)
            {
                MessageBox.Show("Debe seleccionar un Target antes de Asignarlo","Sistema Comercial Craft",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (cboVendedores.SelectedIndex<=0)
            {
                MessageBox.Show("Debe seleccionar un vendedor al cual asignar el Target", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Advertencia
            if (MessageBox.Show("¿Desea Reasignar el Target seleccionado?", "Sistema Comercial Craft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ObjUsuario = (clsUsuario)this.cboVendedores.SelectedItem;
                IdVendedorAsignado = ObjUsuario.Id;
                FechaAsignacion = DateTime.Now;
                IdEstadoMeta = Convert.ToInt16(Enums.EstadosMetas.Propuesta);

                Entidades.GlobalObject.ResultadoTransaccion res =
                    LogicaNegocios.Direccion.Metas.clsMetaNegocio.AsignarProspecto(_IdMeta, IdEstadoMeta, IdVendedorAsignado, FechaAsignacion);
                if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                {
                    MessageBox.Show("El Target ha sido Reasignado exitosamente", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
       }
    }
}
