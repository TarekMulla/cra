using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProyectoCraft.WinForm.Controles;

namespace ProyectoCraft.WinForm.Paperless
{
    public partial class frmPaperlessAsignacion : Form
    {
        public frmPaperlessAsignacion()
        {
            InitializeComponent();
        }

        private void frmPaperless_Load(object sender, EventArgs e)
        {
            //this.Dock = DockStyle.Fill;

            Controles.EstadoPaperless control = new EstadoPaperless();
            panel1.Controls.Add(control);

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            frmPaperlessUser1 form = new frmPaperlessUser1();
            form.Show();
        }
    }
}
