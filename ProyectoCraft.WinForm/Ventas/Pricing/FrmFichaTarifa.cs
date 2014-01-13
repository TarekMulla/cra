using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProyectoCraft.Entidades.Ventas.Pricing;

namespace SCCMultimodal.Ventas.Pricing {
    public partial class FrmFichaTarifa : Form {
        public FrmFichaTarifa() {
            InitializeComponent();
        }

        private static FrmFichaTarifa _form = null;
        public static FrmFichaTarifa Instancia {
            get {
                if (_form == null)
                    _form = new FrmFichaTarifa();

                return _form;
            }
            set {
                _form = value;
            }
        }

        public void LlenaDatos(ClsSolicitudCotizacionIndirecta tarifa)
        {
            //gridObservacionesSL.DataSource = tarifa.Comentarios;
            //gridHistorial.DataSource = tarifa.Historials;
        }

        private void groupBox2_Enter(object sender, EventArgs e) {

        }

        private void tabPage4_Click(object sender, EventArgs e) {

        }

        private void MenuSalir_Click(object sender, EventArgs e) {
            Instancia = null;
            Close();
        }
    }
}
