using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SCCMultimodal.Mantenedores {
    public partial class frmPuertos : Form {
        public frmPuertos() {
            InitializeComponent();
        }

        private static frmPuertos _instancia = null;
        public static frmPuertos Instancia {
            get {
                if (_instancia == null)
                    _instancia = new frmPuertos();

                return _instancia;
            }
            set {
                _instancia = value;
            }
        }


        private void LimpiarDatos() {
            txtCodigo.Text = txtNombre.Text = txtPais.Text = String.Empty;
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e) {
            LimpiarDatos();
        }

        private void MenuGuardar_Click(object sender, EventArgs e) {

        }

        private void btnBuscar_Click(object sender, EventArgs e){
            ListarPuertos();
        }

        private void ListarPuertos(){
            throw new NotImplementedException();
        }
    }
}
