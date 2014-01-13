using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectoCraft.WinForm.Ventas.Oportunidades
{
    public partial class FrmOportunidad : Form
    {
        public FrmOportunidad()
        {
            InitializeComponent();
        }
        private static FrmOportunidad _form = null;
        public static FrmOportunidad Instancia
        {
            get
            {
                if (_form == null)
                    _form = new FrmOportunidad();

                return _form;
            }
            set
            {
                _form = value;
            }
        }

        private void FrmOportunidad_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void MenuSalir_Click_1(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();

        }

        private void FrmOportunidad_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();

        }


    }
}
