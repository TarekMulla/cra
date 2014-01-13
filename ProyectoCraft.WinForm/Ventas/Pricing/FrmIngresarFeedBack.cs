using System;
using System.Windows.Forms;

namespace SCCMultimodal.Ventas.Pricing {
    public partial class FrmIngresarFeedBack : Form {
        public FrmIngresarFeedBack() {
            InitializeComponent();
        }

        private static FrmIngresarFeedBack _form = null;
        public static FrmIngresarFeedBack Instancia {
            get {
                if (_form == null)
                    _form = new FrmIngresarFeedBack();

                return _form;
            }
            set {
                _form = value;
            }
        }



        private void SolicitarTarifa_Load(object sender, EventArgs e) {
            Fecha.DateTime = DateTime.Now;
        }

        private void MenuSalir_Click(object sender, EventArgs e) {
            Instancia = null;
            this.Close();
        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

    }
}
