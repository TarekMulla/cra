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
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Direccion.Metas;
using ProyectoCraft.Entidades.GlobalObject;
using SCCMultimodal.Utils;

namespace ProyectoCraft.WinForm.Ventas.Metas
{
    public partial class frmCancelarTarget : Form
    {
        public frmCancelarTarget()
        {
            InitializeComponent();
        }
        private static string _NombreProspecto = "";
        private static long _IdVendedorActual = 0;
        private static long _IdMeta = 0;
        private static string _NombreVendedorAsignado = "";
        private static string _TipoTarget = "";
        private static clsMeta _Objtarget;
        public static clsMeta ObjTarget
        {
            set
            {
                _Objtarget = value;
            }
        }
        public static string TipoTarget
        {
            set
            {
                _TipoTarget = value;
            }
        }
        public static string NombreProspecto
        {
            set
            {
                _NombreProspecto = value;
            }
        }
        public static long IdVendedorActual
        {
            set
            {
                _IdVendedorActual = value;
            }
        }
        public static long IdMeta
        {
            set
            {
                _IdMeta = value;
            }
        }
        public static string NombreVendedorAsignado
        {
            set
            {
                _NombreVendedorAsignado = value;
            }
        }

        private static frmCancelarTarget _form = null;
        public static frmCancelarTarget Instancia
        {
            get
            {
                if (_form == null)
                    _form = new frmCancelarTarget();

                return _form;
            }
            set
            {
                _form = value;
            }
        }

        private void frmCancelarTarget_Load(object sender, EventArgs e)
        {
            if (_TipoTarget == "C")
            {
                this.rbCuenta.Checked = true;
                this.rbTarget.Checked = false;
            }
            else
            {
                this.rbCuenta.Checked = false;
                this.rbTarget.Checked = true;
            }
            lblVendedorAsignado.Text = _NombreVendedorAsignado;
            lblProspecto.Text = _NombreProspecto;
            this.DateCancelacion.DateTime = DateTime.Now;
        }

        private void sButtonSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void sButtonGrabarObs_Click(object sender, EventArgs e)
        {
            var mail = new EnvioMailObject();
            DateTime FechaCancelacion;
            string Observaciones;

            //Valida Datos Obligatorios
            if (_IdMeta == 0)
            {
                MessageBox.Show("Debe seleccionar un Target antes de Cancelarlo", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.MemoObservaciones.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar las observaciones de la cancelación del Target", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Advertencia
            if (MessageBox.Show("¿Desea Cancelar el Target seleccionado?", "Sistema Comercial Craft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FechaCancelacion = this.DateCancelacion.DateTime;
                Observaciones = this.MemoObservaciones.Text;

                Entidades.GlobalObject.ResultadoTransaccion res =
                    LogicaNegocios.Direccion.Metas.clsMetaNegocio.CancelarTarget(_IdMeta,Observaciones, FechaCancelacion);
                if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                {
                    MessageBox.Show("El Target ha sido Cancelado exitosamente", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.sButtonGrabarObs.Enabled = false;
                    ResultadoTransaccion Res2 = mail.EnviarMailAvisoCancelacionTarget(ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario, _Objtarget, Observaciones);
                    //ResultadoTransaccion Res2 = Utils.EnvioEmail.EnviarMailAvisoCancelacionTarget(ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario, _Objtarget, Observaciones);
                    if (Res2.Estado == Enums.EstadoTransaccion.Rechazada)
                    {
                        MessageBox.Show(Res2.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmCancelarTarget_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }
    }
}
