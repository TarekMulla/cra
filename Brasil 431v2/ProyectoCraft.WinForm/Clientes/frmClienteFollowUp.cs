using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProyectoCraft.WinForm.Clientes
{
    public partial class frmClienteFollowUp : Form
    {
        private static frmClienteFollowUp _instancia = null;
        public static frmClienteFollowUp Instancia
        {
            get
            {
                if(_instancia == null)
                    _instancia = new frmClienteFollowUp();

                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        private ProyectoCraft.Entidades.Clientes.clsClienteMaster _cliente;
        public ProyectoCraft.Entidades.Clientes.clsClienteMaster Cliente
        {
            get
            {
                return _cliente;
            }
            set
            {
            	_cliente = value;
            }
        }

        public frmClienteFollowUp()
        {
            InitializeComponent();
        }



        private void frmClienteFollowUp_Load(object sender, EventArgs e)
        {
            CargarFollowUp();

            this.Text = "Historial Follow Up Cliente " + Cliente.NombreCompañia + "(" + Cliente.NombreFantasia + ")";
        }

        private void CargarFollowUp()
        {
            IList<Entidades.Clientes.clsClienteFollowUp> listado =  LogicaNegocios.Clientes.clsClientesMaster.ObtenerFollowUpActivosCliente(Cliente.Id);
                      
            grdListado.DataSource = listado;

        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmClienteFollowUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }


    }
}
