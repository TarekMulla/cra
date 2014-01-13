using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProyectoCraft.Entidades.Ventas.Pricing;
using ProyectoCraft.WinForm.Utils;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace SCCMultimodal.Ventas.Pricing
{
    public partial class FrmListarCotizaciones : Form
    {

        private static FrmListarCotizaciones _form = null;
        public static FrmListarCotizaciones Instancia
        {
            get
            {
                if (_form == null)
                    _form = new FrmListarCotizaciones();

                return _form;
            }
            set
            {
                _form = value;
            }
        }

        public FrmListarCotizaciones()
        {
            InitializeComponent();
        }

        private void MenuSalir_Click(object sender, System.EventArgs e)
        {
            Instancia = null;
            Close();
        }

        private void FrmListarTarifas_Load(object sender, System.EventArgs e)
        {
            Dock = DockStyle.Fill;
            CargarGrillaCotizaciones();
        }

        public void CargarGrillaCotizaciones()
        {
            var cot = ProyectoCraft.LogicaNegocios.Ventas.pricing.ClsCotizacion.ListarTodosLasCotizacionesMiscotizaciones(ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario).ObjetoTransaccion ;
                gridSLeads.DataSource = cot;
        }

        private void toolStripButton2_Click_1(object sender, System.EventArgs e)
        {
            
            var formulario = FrmCotizacionDirecta.Instancia;
            formulario.FrmListarCotizaciones = this;
            formulario.ShowDialog();
        }

        private void MenuEnviarAlCliente_Click(object sender, EventArgs e)
        {
            Document document = new Document();
            var foo = AppDomain.CurrentDomain.BaseDirectory;
            System.IO.MemoryStream m = new System.IO.MemoryStream();
            var f = new FileStream("prueba.pdf", FileMode.OpenOrCreate);
            PdfWriter.GetInstance(document, f);
            document.Open();
            document.Add(new Paragraph("Este es mi primer PDF al vuelo"));
            document.Close();



            /*PdfWriter.GetInstance(document,m);
            document.Open();
            document.Add(new Paragraph("Este es mi primer PDF al vuelo"));
            document.Close();*/
            var list = new List<object>();
            list.Add(f);
            EnvioEmail.EnviarEmailConAdjunto("vhspiceros@gmail.com", "prueba de envio de pdf adjunto", "prueba", list);


        }

        private void menuNuevaTarifa_Click(object sender, EventArgs e)
        {
            var formulario = FrmSolicitarTarifa.Instancia;
            formulario.FrmListarCotizaciones = this;
            formulario.ShowDialog();
        }

        private void FrmListarCotizaciones_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }

        private void comboEstados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}