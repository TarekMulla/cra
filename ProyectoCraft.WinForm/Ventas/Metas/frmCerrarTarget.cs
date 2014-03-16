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
//using DevExpress.XtraPrinting;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Direccion.Metas;
using SCCMultimodal.Utils;


namespace ProyectoCraft.WinForm.Ventas.Metas
{
    public partial class frmCerrarTarget : Form
    {
        public frmCerrarTarget()
        {
            InitializeComponent();
        }
        private static string _NombreProspecto = "";
        private static long _IdVendedorActual = 0;
        private static long _IdMeta = 0;
        private static string _NombreVendedorAsignado ="" ;
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

        private static frmCerrarTarget _form = null;
        public static frmCerrarTarget Instancia
        {
            get
            {
                if (_form == null)
                    _form = new frmCerrarTarget();

                return _form;
            }
            set
            {
                _form = value;
            }
        }
        private void CargarVendedores()
        {
            Entidades.GlobalObject.ResultadoTransaccion res = LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Enums.Estado.Habilitado, Enums.CargosUsuarios.Vendedor);
            IList<clsUsuario> listVendedores = (IList<clsUsuario>)res.ObjetoTransaccion;

            ComboBoxItemCollection coll = cboVendedores.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listVendedores)
            {
                coll.Add(list);
            }
            cboVendedores.SelectedIndex = 0;

            //AutoCompleteStringCollection textoAutocompletar = new AutoCompleteStringCollection();
            //textoAutocompletar = new AutoCompleteStringCollection();
            //foreach (var list in listVendedores)
            //{
            //    textoAutocompletar.Add(list.Nombre);
            //}
        }

        private void frmCerrarTarget_Load(object sender, EventArgs e)
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
            CargarVendedores();
            lblVendedorAsignado.Text = _NombreVendedorAsignado;
            lblProspecto.Text = _NombreProspecto;
            this.DateCierre.DateTime = DateTime.Now;
        }

        private void sButtonSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void sButtonGrabarObs_Click(object sender, EventArgs e)
        {
            var mail = new EnvioMailObject();
            {
                clsUsuario ObjUsuario;
                long IdUsuarioCierra=0;
                string Instruction;
                DateTime FechaCierre;
                string Observaciones;

                //Valida Datos Obligatorios
                if (_IdMeta == 0)
                {
                    MessageBox.Show("Debe seleccionar un Target antes de Cerrarlo", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cboVendedores.SelectedIndex <= 0)
                {
                    MessageBox.Show("Debe seleccionar un vendedor al cual asignar el Target", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (this.TxtShippingInstruction.Text.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar el código de Shipping Instruction", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (this.MemoObservaciones.Text.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar las observaciones del cierre del Target", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Advertencia
                if (MessageBox.Show("¿Desea Cerrar el Target seleccionado?", "Sistema Comercial Craft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ObjUsuario = (clsUsuario)this.cboVendedores.SelectedItem;
                    IdUsuarioCierra = ObjUsuario.Id;
                    FechaCierre = this.DateCierre.DateTime;
                    Observaciones = this.MemoObservaciones.Text;
                    Instruction = this.TxtShippingInstruction.Text;

                    Entidades.GlobalObject.ResultadoTransaccion res =
                        LogicaNegocios.Direccion.Metas.clsMetaNegocio.CerrarTarget(_IdMeta, Instruction, Observaciones, FechaCierre,IdUsuarioCierra);
                    if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                    {
                        MessageBox.Show("El Target ha sido Cerrado exitosamente", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.sButtonGrabarObs.Enabled = false;
                        ResultadoTransaccion Res2 = mail.EnviarMailAvisoCierreTarget(Base.Usuario.UsuarioConectado.Usuario, _Objtarget, Observaciones);
                        //ResultadoTransaccion Res2 = Utils.EnvioEmail.EnviarMailAvisoCierreTarget(ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario, _Objtarget, Observaciones);
                        if (Res2.Estado == Enums.EstadoTransaccion.Rechazada)
                        {
                            MessageBox.Show(Res2.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                }
            }
        }
    }
}
