using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraEditors.Controls;
using ProyectoCraft.Entidades.Clientes.Contacto;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.WinForm.Clientes.Contacto
{
    public partial class frmListarContacto : Form
    {
        public frmListarContacto()
        {
            InitializeComponent();
        }

        private static frmListarContacto _form = null;
        public static frmListarContacto Instancia
        {
            get
            {
                if (_form == null)
                    _form = new frmListarContacto();

                return _form;
            }
            set
            {
                _form = value;
            }
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
                        Instancia = null;
            this.Close();
        }

        private void MenuCrearContacto_Click(object sender, EventArgs e)
        {
            frmContacto form = frmContacto.Instancia;
            form.Accion = Entidades.Enums.Enums.TipoAccionFormulario.Nuevo;
            form.ShowDialog();
        }

        private void frmListarContacto_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;            
            Nombre = "-1";
            IdEstado = (Int16)Enums.Estado.Habilitado;
            IdPropietario = -1;
            IdCliente = -1;
            lstBusquedas.SelectedIndex = 3;

            CargarClientes();
            //ListarContactos();
        }

        private void CargarClientes()
        {
            IList<clsClienteMaster> listclientes =
                LogicaNegocios.Clientes.clsClientesMaster.ListarClienteMaster(this.txtCliente.Text,
                                                                              Enums.TipoPersona.Comercial, Enums.Estado.Habilitado,true);

            ComboBoxItemCollection coll = cboClientes.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listclientes)
            {
                coll.Add(list);
            }
            cboClientes.SelectedIndex = 0;
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(txtCliente.Text);

            foreach (var list in listclientes)
            {
                auto.Add(list.NombreCliente);
            }

            txtCliente.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCliente.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCliente.MaskBox.AutoCompleteCustomSource = auto;
        }


        public string Nombre { get; set; }
        public Int64 IdCliente { get; set; }
        public Int16 IdEstado { get; set; }
        public Int64 IdPropietario { get; set; }

        public void ListarContactos()
        {            
            IList<clsContacto> listContactos = LogicaNegocios.Clientes.clsContactos.ListarContactos(Nombre, IdCliente,IdPropietario,IdEstado);
            grdContactos.DataSource = listContactos;                        
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            IdCliente = -1;
            Nombre = "-1";
            IdPropietario = -1;
            IdEstado = (Int16) Enums.Estado.Habilitado;

            if (txtNombre.Text == "")
                Nombre = "-1";
            else
                Nombre = txtNombre.Text;


            if (txtCliente.Text != "")
            {
                cboClientes.SelectedIndex = 0;
                for (int i = 0; i < cboClientes.Properties.Items.Count; i++)
                {
                    if(cboClientes.Properties.Items[i] is clsClienteMaster)
                    {
                        if(((clsClienteMaster)cboClientes.Properties.Items[i]).NombreCliente == txtCliente.Text)
                        {
                            cboClientes.SelectedIndex = i;        
                            break;
                        }                                                
                    }                    
                }

                if (cboClientes.SelectedIndex != 0)
                {
                    IdCliente = ((Entidades.Clientes.clsClienteMaster)this.cboClientes.SelectedItem).Id;
                }
                else
                {
                    MessageBox.Show("El Cliente no es valido", "Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }                
            }

            IdEstado = (Int16)Enums.Estado.Habilitado;

            ListarContactos();
        }

        private void MenuVerContacto_Click(object sender, EventArgs e)
        {                        
            frmContacto frm = frmContacto.Instancia;
            clsContacto contacto = ObtenerContacto();            
            if (contacto != null)
            {
                frm.ContactoActual = contacto;
                frm.FormLoad();
                if (frm.CargarFormulario())
                {                    
                    frm.Accion = Enums.TipoAccionFormulario.Editar;
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Contacto", "Contacto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private clsContacto ObtenerContacto()
        {
            var filaSelected = grdContactos.DefaultView.GetRow(gridView1.FocusedRowHandle);

            if (filaSelected == null)
            {
                return null;
            }

            clsContacto cuenta = (clsContacto)filaSelected;

            return cuenta;
        }

        private void MenuEliminarContacto_Click(object sender, EventArgs e)
        {
            clsContacto ContactoTemp = ObtenerContacto();

            if (ContactoTemp != null)
            {
                DialogResult resdialogo = MessageBox.Show("¿Está seguro de eliminar el Contacto", "Contacto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resdialogo == DialogResult.Yes)
                {
                    ResultadoTransaccion res =
                        LogicaNegocios.Clientes.clsContactos.ObtenerContactoPorIdTransaccion(ContactoTemp.Id);
                    if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                    {
                        clsContacto contacto = (clsContacto)res.ObjetoTransaccion;

                        res = new ResultadoTransaccion();
                        res = LogicaNegocios.Clientes.clsContactos.EliminarContacto(contacto);

                        if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                        {                            
                            ListarContactos();
                            MDICraft mdi = MDICraft.Instancia;
                            mdi.MensajeAccion(Enums.TipoAccionFormulario.Eliminar);
                        }
                        else
                            MessageBox.Show(res.Descripcion, "Contacto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Contacto", "Contacto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }                               
        }

        private void lstBusquedas_SelectedIndexChanged(object sender, EventArgs e)
        {
            IdEstado = (Int16)lstBusquedas.SelectedIndex;
            Nombre = "-1";
            IdCliente = -1;
            IdPropietario = -1;

            //todos
            if(lstBusquedas.SelectedIndex == 0)
            {
                IdEstado = -1;
            }

            if (lstBusquedas.SelectedIndex == 2)
            {
                IdEstado = (Int16)Enums.Estado.Deshabilitado;
            }

            //Mis Contactos
            if(lstBusquedas.SelectedIndex == 3)
            {
                IdPropietario = Base.Usuario.UsuarioConectado.Usuario.Id;
                IdEstado = (Int16) Enums.Estado.Habilitado;
            }

            ListarContactos();
        }

        

        
    }

    public class ListaParGrilla
    {
        public Entidades.Clientes.Contacto.clsContacto Contacto { get; set; }
        public bool EstaChequeado { get; set; }
    }
}
