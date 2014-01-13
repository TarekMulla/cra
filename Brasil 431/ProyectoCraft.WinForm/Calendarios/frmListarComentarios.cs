using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProyectoCraft.Entidades.Calendario;

namespace ProyectoCraft.WinForm.Calendarios
{
    public partial class frmListarComentarios : Form
    {
        public frmListarComentarios()
        {
            InitializeComponent();
        }

        private static frmListarComentarios _instance = null;
        public static frmListarComentarios Instancia
        {
            get
            {
                if(_instance == null)
                    _instance = new frmListarComentarios();

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
            get { return _visita ; }
            set { _visita = value; }
        }


        private void frmListarComentarios_Load(object sender, EventArgs e)
        {
            
            ListarComentarios();

        }

        public void ListarComentarios()
        {
            IList<clsInformeComentario> lista = new List<clsInformeComentario>();

            lista = LogicaNegocios.Calendarios.clsCalendarios.ListarComentariosVisita(Visita.Informvisita.Id);            
            grdComentarios.DataSource = lista;
        }

        private void frmListarComentarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmComentarioVisita form = frmComentarioVisita.Instancia;
            form.DesdeListado = true;
            form.Visita = this.Visita;
            form.ShowDialog();
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
