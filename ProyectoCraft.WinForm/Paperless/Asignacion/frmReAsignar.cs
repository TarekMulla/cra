using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectoCraft.WinForm.Paperless.Asignacion
{
    public partial class frmReAsignar : Form
    {
        private static frmReAsignar _instancia = null;
        public static frmReAsignar Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmReAsignar();

                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmReAsignar()
        {
            InitializeComponent();
        }

        private void frmReAsignar_Load(object sender, EventArgs e)
        {

        }

        private void grpReAsignar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripBarraMantenedor_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
