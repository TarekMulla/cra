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

namespace ProyectoCraft.WinForm.Ventas.Metas
{
    public partial class frmCerrarSLead : Form
    {
        public frmCerrarSLead()
        {
            InitializeComponent();
        }
        private static frmCerrarSLead _form = null;
        public static frmCerrarSLead Instancia
        {
            get
            {
                if (_form == null)
                    _form = new frmCerrarSLead();

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

        private void frmCerrarSLead_Load(object sender, EventArgs e)
        {
            lblAgente.Text = _ObjSalesLead.Agente.Nombre.ToString() ;
            lblSLead.Text = _ObjSalesLead.GlosaSalesLead.ToString();
            this.DateCierre.DateTime = DateTime.Now;
        }

        private void sButtonSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void frmCerrarSLead_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void sButtonGrabarObs_Click(object sender, EventArgs e)
        {
            {
                DateTime FechaCierre;
                string Observaciones;

                //Valida Datos Obligatorios
                if (_ObjSalesLead.Id == 0)
                {
                    MessageBox.Show("Debe seleccionar un Sales Lead antes de Cerrarlo", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (this.MemoObservaciones.Text.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar las observaciones del cierre del Sales Lead", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Advertencia
                if (MessageBox.Show("¿Desea Cerrar el Sales Lead seleccionado?", "Sistema Comercial Craft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FechaCierre = this.DateCierre.DateTime;
                    Observaciones = this.MemoObservaciones.Text;

                    Entidades.GlobalObject.ResultadoTransaccion res =
                        LogicaNegocios.Direccion.Metas.ClsSalesLeadNegocio.CerrarSalesLead(_ObjSalesLead.Id, Observaciones, FechaCierre);
                    if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                    {
                        MessageBox.Show("El Sales Lead ha sido Cerrado exitosamente", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.sButtonGrabarObs.Enabled = false;
                        //ResultadoTransaccion Res2 = Utils.EnvioEmail.EnviarMailAvisoCierreTarget(ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario, _Objtarget, Observaciones);
                        //if (Res2.Estado == Enums.EstadoTransaccion.Rechazada)
                        //{
                        //    MessageBox.Show(Res2.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                    }
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
