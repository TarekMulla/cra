using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectoCraft.WinForm.Ventas.Actividades.EMail
{
    public partial class FrmNuevoMailOtros : Form
    {
        public FrmNuevoMailOtros()
        {
            InitializeComponent();
        }

        private static FrmNuevoMailOtros _form = null;
        public static FrmNuevoMailOtros Instancia
        {
            get
            {
                if (_form == null)
                    _form = new FrmNuevoMailOtros();

                return _form;
            }
            set
            {
                _form = value;
            }
        }

        private void FrmNuevoMailOtros_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void MenuSalir_Click_1(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();

        }

        private void FrmNuevoMailOtros_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }
        
        

    }
}
