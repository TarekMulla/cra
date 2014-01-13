using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.WinForm.Clientes.Target
{
    public partial class frmDescalificar : Form
    {
        public frmDescalificar()
        {
            InitializeComponent();
        }

        private static frmDescalificar _form = null;
        public static frmDescalificar Instancia
        {
            get
            {
                if (_form == null)
                    _form = new frmDescalificar();

                return _form;
            }
            set
            {
                _form = value;
            }
        }

        private Int64 _idTarget;
        public Int64 IdTarget
        {
            get
            {
                return _idTarget;
            }
            set { _idTarget = value; }
        }


        private void frmDescalificar_Load(object sender, EventArgs e)
        {
            CargarMotivos();
            txtUsuario.Text = Base.Usuario.UsuarioConectado.Usuario.ToString();
            txtFecha.Text = DateTime.Now.ToShortDateString();
        }

        private void CargarMotivos()
        {
            Entidades.Parametros.clsParametrosInfo motivos =
                LogicaNegocios.Parametros.clsParametros.ListarParametrosPorTipo(
                    Entidades.Enums.Enums.TipoParametro.TipoMotivoDescalificacion);
            Utils.Utils.CargaComboBoxParametros(motivos,cboMotivo);


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void btnDescalificar_Click(object sender, EventArgs e)
        {
            if(ValidarFormulario())
            {
                ResultadoTransaccion resultado = new ResultadoTransaccion();
                resultado = LogicaNegocios.Clientes.clsTarget.DescalificarTarget(IdTarget);

                if(resultado.Estado == Entidades.Enums.Enums.EstadoTransaccion.Rechazada)
                {
                    MessageBox.Show(resultado.Descripcion, "Target", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Instancia = null;
                    frmTarget form = frmTarget.Instancia;
                    form.CargarFormulario();

                    frmListarTarget form2 = frmListarTarget.Instancia;
                    form2.Listartarget();

                    MDICraft mdi = MDICraft.Instancia;
                    mdi.MensajeAccion(Entidades.Enums.Enums.TipoAccionFormulario.CambiarEstado);

                    frmTarget.Instancia = null;
                    form.Close();

                    this.Close();
                }
            }
        }

        protected bool ValidarFormulario()
        {
            bool validar = true;

            if(cboMotivo.SelectedIndex == 0)
            {
                dxErrorProvider1.SetError(cboMotivo,"Debe seleccionar un motivo de Descalificacion",ErrorType.Critical);
                validar = false;
            }

            if(txtObservacion.Text.Trim().Length == 0)
            {
                dxErrorProvider1.SetError(txtObservacion, "Debe ingresar una observación o motivo", ErrorType.Critical);
                validar = false;
            }

            return validar;
        }

        
        
    }
}
