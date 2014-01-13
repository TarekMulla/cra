using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Native;
using ProyectoCraft.AccesoDatos.Cotizaciones.Directa;
using ProyectoCraft.Entidades.Cotizaciones;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.LogicaNegocios.Cotizaciones.Directa;
using SCCMultimodal.Utils;


namespace SCCMultimodal.Cotizaciones {
    public partial class FrmPrintPreviewCotizacoines : Form {
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
            foreach (var cot in ListCotizaciones) {
                var cotizacionDirecta = ClsCotizacionDirecta.ObtieneCotizacionDirecta(cot.Id32).ObjetoTransaccion as CotizacionDirecta;
                var mailObject = new EnvioMailObject();


                var xmldoc = new XmlDocument();
                xmldoc.Load(Path.Combine(Application.StartupPath, @"Cotizaciones\CotizacionSetting.xml"));
                var subject = xmldoc.SelectSingleNode("/setting/cotizacionDirecta/subjectMail").InnerText;
                subject = subject.Replace("[nombreCliente]", cotizacionDirecta.Cliente.NombreCliente);

                var htmlBody = cotizacionDirecta.GenerateHtmlPreviewAndBody(Application.StartupPath);
                var htmlPDF = cotizacionDirecta.GenerateHTMLforPDF(Application.StartupPath);

                var listPath = new List<String> { mailObject.GeneratePdfFromHtml(htmlPDF, cotizacionDirecta.Numero) };


                mailObject.EnviarMailCotizacionDirecta(subject, htmlBody, listPath);
                ClsCotizacionDirecta.CambioEstado(cotizacionDirecta, 4, ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario);
                //ClsCotizacionDirectaEstadoDao.CambioEstado(cotizacionDirecta.Id32, 4);
            }
            Instancia = null;
            Close();
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