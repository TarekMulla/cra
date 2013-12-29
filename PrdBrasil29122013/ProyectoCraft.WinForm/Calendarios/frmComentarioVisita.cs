using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProyectoCraft.Entidades.Calendario;
using ProyectoCraft.Entidades.GlobalObject;
using SCCMultimodal.Utils;

namespace ProyectoCraft.WinForm.Calendarios
{
    public partial class frmComentarioVisita : Form
    {
        public frmComentarioVisita()
        {
            InitializeComponent();
        }

        private static frmComentarioVisita _instance = null;
        public static frmComentarioVisita Instancia
        {
            get
            {
                if (_instance == null)
                    _instance = new frmComentarioVisita();

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        private clsVisita _visita;
        public clsVisita Visita
        {
            get { return _visita; }
            set { _visita = value; }
        }

        private bool _desdeListado;
        public bool DesdeListado
        {
            get { return _desdeListado ; }
            set { _desdeListado = value; }
        }


        private void frmComentarioVisita_Load(object sender, EventArgs e)
        {

        }

        private void frmComentarioVisita_FormClosed(object sender, FormClosedEventArgs e)
        {            
            if(DesdeListado)
            {
                frmListarComentarios form = frmListarComentarios.Instancia;
                form.ListarComentarios();
            }

            Instancia = null;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var mail = new EnvioMailObject();
            if(txtComentario.Text == "")
            {
                dxErrorProvider1.SetError(txtComentario,"Debe ingresar un comentario");
            }

            clsInformeComentario comentario = new clsInformeComentario();
            comentario.IdInforme = this.Visita.Informvisita.Id;
            comentario.Usuario = Base.Usuario.UsuarioConectado.Usuario;
            comentario.Comentario = txtComentario.Text.Trim();


            ResultadoTransaccion res = new ResultadoTransaccion();
            res = LogicaNegocios.Calendarios.clsCalendarios.AgregarComentarioInformeVisita(comentario);

            
            //SI no es vendedor enviar email al vendedor
            if (Base.Usuario.UsuarioConectado.Usuario.Id != Visita.Vendedor.Id)
            {
                mail.EnviarEmailComentarioEnInforme(Visita, comentario, false, null);
                //Utils.EnvioEmail.EnviarEmailComentarioEnInforme(Visita, comentario, false, null);
            }            
            else //Si es vendedor enviar email a usuarios que han comentado
            {
                mail.EnviarEmailComentarioRespondidoPorVendedor(Visita, comentario);
                //Utils.EnvioEmail.EnviarEmailComentarioRespondidoPorVendedor(Visita, comentario);
            }
            

            

            if (res.Estado == Entidades.Enums.Enums.EstadoTransaccion.Rechazada)
            {
                MessageBox.Show(res.Descripcion, "Comentarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            

            MessageBox.Show("Comentario guardado exitosamente.", "Comentarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }

        
    }
}
