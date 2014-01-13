using System;
using System.Windows.Forms;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Direccion.Metas;

namespace ProyectoCraft.WinForm.Ventas.Metas
{
    public partial class frmCancelarSalesLead : Form
    {
        public frmCancelarSalesLead()
        {
            InitializeComponent();
        }

        private static frmCancelarSalesLead _form = null;
        public static frmCancelarSalesLead Instancia
        {
            get
            {
                if (_form == null)
                    _form = new frmCancelarSalesLead();

                return _form;
            }
            set
            {
                _form = value;
            }
        }
        
        private static ClsSalesLead _ObjSalesLead;
        
        public static ClsSalesLead ObjSalesLead
        {
            set
            {
                _ObjSalesLead = value;
            }
        }

        private void frmCancelarSalesLead_Load(object sender, EventArgs e)
        {
            lblAgente.Text = _ObjSalesLead.Agente.Nombre.ToString() ;
            lblSLead.Text = _ObjSalesLead.Reference;
            this.DateCancelacion.DateTime = DateTime.Now;
        }

        private void sButtonSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void sButtonGrabarObs_Click(object sender, EventArgs e)
        {
            DateTime FechaCancelacion;
            string Observaciones;

            //Valida Datos Obligatorios
            if (_ObjSalesLead.Id == 0)
            {
                MessageBox.Show("Debe seleccionar un Sales Lead antes de Cancelarlo", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.MemoObservaciones.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar las observaciones de la cancelación del Sales Lead", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Advertencia
            if (MessageBox.Show("¿Desea Cancelar el Sales Lead seleccionado?", "Sistema Comercial Craft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FechaCancelacion = this.DateCancelacion.DateTime;
                Observaciones = this.MemoObservaciones.Text;

                Entidades.GlobalObject.ResultadoTransaccion res =
                    LogicaNegocios.Direccion.Metas.ClsSalesLeadNegocio.CancelarSalesLead(_ObjSalesLead.Id, Observaciones, FechaCancelacion);
                if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                {
                    MessageBox.Show("El Sales Lead ha sido Cancelado exitosamente", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.sButtonGrabarObs.Enabled = false;
                    //ResultadoTransaccion Res2 = Utils.EnvioEmail.EnviarMailAvisoCancelacionTarget(ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario, _Objtarget, Observaciones);
                    //if (Res2.Estado == Enums.EstadoTransaccion.Rechazada)
                    //{
                    //    MessageBox.Show(Res2.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
            }
        }
    }
}
