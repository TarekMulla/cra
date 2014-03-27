using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraGrid.Views.Grid;
using ProyectoCraft.AccesoDatos.Cotizaciones.Directa;
using ProyectoCraft.Entidades.Cotizaciones;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.LogicaNegocios.Cotizaciones.Directa;
using SCCMultimodal.Utils;


namespace SCCMultimodal.Cotizaciones {
    public partial class FrmPrintPreviewCotizacoines : DevExpress.XtraEditors.XtraForm {
        public static List<ITableable> ListCotizaciones { set; get; }
        public FrmPrintPreviewCotizacoines(List<ITableable> listCotizaciones) {
            ListCotizaciones = listCotizaciones;
            InitializeComponent();
            CargarGrillaCotizaciones();
        }

        private static FrmPrintPreviewCotizacoines _form = null;

        public static FrmPrintPreviewCotizacoines Instancia {
            get { return _form ?? (_form = new FrmPrintPreviewCotizacoines(ListCotizaciones)); }
            set {
                _form = value;
            }
        }

        public void CargarGrillaCotizaciones() {
            if (ListCotizaciones != null)
                GrdGrilla.DataSource = ListCotizaciones;
        }

        private void MenuSalir_Click(object sender, EventArgs e) {
            Instancia = null;
            Close();
        }

        private void MenuEnviarAlCliente_Click(object sender, EventArgs e) {
            var contieneCopiada = false;
            var cotizacionDirectas = new List<CotizacionDirecta>();        
            foreach (var c in ListCotizaciones) {
                var cot = ClsCotizacionDirecta.ObtieneCotizacionDirecta(c.Id32).ObjetoTransaccion as CotizacionDirecta;
                cotizacionDirectas.Add(cot);
                if (cot.CopiadoDe != null && cot.CopiadoDe != 0) {
                    contieneCopiada = true;
                    break;
                }
            }
            DialogResult res = DialogResult.None;
            if (contieneCopiada) {
                res =
                   MessageBox.Show("Algunas de las cotizaciones fueron copiadas. Confirma el envío al cliente?",
                       "Sistema Comercial Craft", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question);
            }

            if (!contieneCopiada || res == DialogResult.Yes)
                foreach (var cotizacionDirecta in cotizacionDirectas) {
                    var mailObject = new EnvioMailObject();


                    var xmldoc = new XmlDocument();
                    xmldoc.Load(Path.Combine(Application.StartupPath, @"Cotizaciones\CotizacionSetting.xml"));
                    var subject = xmldoc.SelectSingleNode("/setting/cotizacionDirecta/subjectMail").InnerText;
                    subject = subject.Replace("[nombreCliente]", cotizacionDirecta.Cliente.NombreCliente);

                    var htmlBody = cotizacionDirecta.GenerateHtmlPreviewAndBody(Application.StartupPath);
                    var htmlPDF = cotizacionDirecta.GenerateHTMLforPDF(Application.StartupPath);

                    var listPath = new List<String> { mailObject.GeneratePdfFromHtml(htmlPDF, cotizacionDirecta.Numero) };

                    mailObject.EnviarMailCotizacionDirecta(subject, htmlBody, listPath);
                    ClsCotizacionDirectaEstadoDao.CambioEstado(cotizacionDirecta.Id32, 4);
                    var logCot = CreaLog(cotizacionDirecta, EnumTipoLogCotizacionDirecta.Envio);
                    ClsLogCotizacionesDirecta.Guardar(logCot);
                }

            Instancia = null;
            Close();
        }

        private static LogCotizacionesDirecta CreaLog(CotizacionDirecta cotizacionDirecta, EnumTipoLogCotizacionDirecta tipo) {
            var logCot = new LogCotizacionesDirecta {
                CotizacionDirecta = cotizacionDirecta,
                Usuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario,
                Fecha = DateTime.Now,
                Tipo = tipo
            };
            return logCot;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            var grid = sender as GridView;
            var _cotizacionDirecta = grid.GetRow(e.FocusedRowHandle) as CotizacionDirecta;
            if (_cotizacionDirecta == null)
                return;

            var cotizacionDirecta = ClsCotizacionDirecta.ObtieneCotizacionDirecta(_cotizacionDirecta.Id32).ObjetoTransaccion as CotizacionDirecta;
            var html = cotizacionDirecta.GenerateHtmlPreviewAndBody(Application.StartupPath);

            webBrowser1.Navigate("about:blank");
            do {
                Thread.Sleep(100);
            } while (webBrowser1.IsBusy);

            webBrowser1.Document.Write(html);
            webBrowser1.Refresh();
        }
    }
}