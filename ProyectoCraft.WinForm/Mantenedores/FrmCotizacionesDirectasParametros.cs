using System.IO;
using System.Windows.Forms;
using System.Xml;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.LogicaNegocios.Parametros;


namespace SCCMultimodal.Mantenedores {
    public partial class FrmCotizacionesDirectasParametros : Form {
        public FrmCotizacionesDirectasParametros() {
            InitializeComponent();
        }

        private static clsItemParametro parametro;
        private static FrmCotizacionesDirectasParametros _instancia = null;
        public static FrmCotizacionesDirectasParametros Instancia {
            get {
                if (_instancia == null)
                    _instancia = new FrmCotizacionesDirectasParametros();
                return _instancia;
            }
            set {
                _instancia = value;
            }
        }


        private void FrmCotizacionesDirectasParametros_Load(object sender, System.EventArgs e) {
            /*          var xmldoc = new XmlDocument();
                        xmldoc.Load(Path.Combine(Application.StartupPath, @"Cotizaciones\CotizacionSetting.xml"));
                        var text = xmldoc.SelectSingleNode("/setting/cotizacionDirecta/observacionFija").InnerText;
                        TxtObservaciones.Text = text;*/
            parametro = clsParametros.ListarParametrosPorTipo(Enums.TipoParametro.CotizacionDirectaObsertvacionFija).Items[0];
            TxtObservaciones.Text = parametro.Nombre;
        }

        private void MenuGuardar_Click(object sender, System.EventArgs e) {

        }

        private void toolStripButton1_Click(object sender, System.EventArgs e) {
            Instancia = null;

        }

        private void toolStripButton3_Click(object sender, System.EventArgs e) {
            /*var xmldoc = new XmlDocument();
            xmldoc.Load(Path.Combine(Application.StartupPath, @"Cotizaciones\CotizacionSetting.xml"));
            xmldoc.SelectSingleNode("/setting/cotizacionDirecta/observacionFija").InnerText = TxtObservaciones.Text;
            xmldoc.Save(Path.Combine(Application.StartupPath, @"Cotizaciones\CotizacionSetting.xml"));*/
            parametro.Nombre = TxtObservaciones.Text;
            clsParametros.ActualizaParametroPorId(parametro);
            MessageBox.Show("Los paramatros se guardaron Satisfactoriamente", "Cotizacion Directa", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void toolStripButton2_Click(object sender, System.EventArgs e) {
            Instancia = null;
            Close();
        }

        private void FrmCotizacionesDirectasParametros_FormClosed(object sender, FormClosedEventArgs e) {
            Instancia = null;
        }
    }
}
