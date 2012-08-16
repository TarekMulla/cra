using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.WinForm.Clientes.Target
{
    public partial class frmListarTarget : Form
    {
        public frmListarTarget()
            : base()
        {
            InitializeComponent();
        }

        private static frmListarTarget _form = null;
        public static  frmListarTarget Instancia
        {
            get
            {
                if (_form == null)
                    _form = new frmListarTarget();
                
                 return _form;
            }
            set
            {
            	_form = value;
            }
        }


        #region "Private"

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

        #endregion

        #region "Public"

        private string Nombre { get; set; }
        private Int64 IdVendedor { get; set; }
        private Int32 IdTipoBusqueda { get; set; }
        

        public void Listartarget()
        {                                                
            IList<Entidades.Clientes.Target.clsTarget> lista = LogicaNegocios.Clientes.clsTarget.ListarTarget(Nombre, IdVendedor, IdTipoBusqueda);
            this.grdListaTarget.DataSource = lista;                        
        }

        #endregion

        #region "Form Events"

        private void frmListarTarget_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;            
            IdTipoBusqueda = 4;
            IdVendedor = -1;
            lstTipoBusqueda.SelectedIndex = 4;
            //Listartarget();
            CargarVendedores();            
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void MenuNuevoTarget_Click(object sender, EventArgs e)
        {
            frmTarget form = frmTarget.Instancia;
            form.Accion = Entidades.Enums.Enums.TipoAccionFormulario.Nuevo;
            form.ShowDialog();
        }

        private void btnBuscarTargets_Click(object sender, EventArgs e)
        {
            Int64 idVendedor = -1;

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
                    idVendedor = ((Entidades.Usuarios.clsUsuario)this.cboVendedores.SelectedItem).Id;
                }
                else
                {
                    MessageBox.Show("El vendedor no es valido", "Target", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }

            Nombre = txtNombre.Text;
            IdVendedor = idVendedor;
            IdTipoBusqueda = -1;

            this.Listartarget();
        }

        private Entidades.Clientes.Target.clsTarget ObtenerTarget()
        {
            var filaSelected = grdListaTarget.DefaultView.GetRow(gridView1.FocusedRowHandle);

            if (filaSelected == null)
            {                
                return null;
            }
            
            Entidades.Clientes.Target.clsTarget target = (Entidades.Clientes.Target.clsTarget)filaSelected;

            return target;
        }

        private void MenuVerDatos_Click(object sender, EventArgs e)
        {
            Entidades.Clientes.Target.clsTarget target = ObtenerTarget();
            frmTarget frm = frmTarget.Instancia;

            if(ObtenerTarget() != null)
            {
                frm.IdTarget = target.Id;
                frm.FormLoad();
                if (frm.CargarFormulario())
                {
                    frm.Accion = Entidades.Enums.Enums.TipoAccionFormulario.Editar;
                    frm.ShowDialog();
                }
            }
            else
                MessageBox.Show("Debe seleccionar un Target", "Target", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion

        private void lstTipoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 idTipoBusqueda = -1;
            Int64 idVendedor = -1;

            idTipoBusqueda = lstTipoBusqueda.SelectedIndex;

            if (idTipoBusqueda == 4)
            {
                idVendedor = Base.Usuario.UsuarioConectado.Usuario.Id;
                txtVendedor.Text = "";
                cboVendedores.SelectedIndex = 0;
            }

            Nombre = "";
            IdVendedor = idVendedor;
            IdTipoBusqueda = idTipoBusqueda;

            Listartarget();
        }

        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            Entidades.Clientes.Target.clsTarget targettemp = ObtenerTarget();

            if(targettemp != null)
            {
                DialogResult resdialogo = MessageBox.Show("¿Está seguro de eliminar el Target", "Target", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resdialogo == System.Windows.Forms.DialogResult.Yes)
                {
                    Entidades.GlobalObject.ResultadoTransaccion res = LogicaNegocios.Clientes.clsTarget.ObtenerTargetPorId(targettemp.Id);
                    if (res.Estado == Entidades.Enums.Enums.EstadoTransaccion.Aceptada)
                    {
                        Entidades.Clientes.Target.clsTarget target = (Entidades.Clientes.Target.clsTarget)res.ObjetoTransaccion;

                        res = new ResultadoTransaccion();
                        res = LogicaNegocios.Clientes.clsTarget.EliminarTarget(target);

                        if (res.Estado == Entidades.Enums.Enums.EstadoTransaccion.Aceptada)
                        {
                            Listartarget();
                        }
                        else
                            MessageBox.Show(res.Descripcion, "Target", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }                 
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Target", "Target", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }
    }
}
