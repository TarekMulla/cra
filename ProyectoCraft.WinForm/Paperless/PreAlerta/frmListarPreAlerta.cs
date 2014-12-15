using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPrinting;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Paperless;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.WinForm.Paperless.PreAlerta;
using ProyectoCraft.LogicaNegocios.Paperless;

namespace ProyectoCraft.WinForm.Paperless.PreAlerta

{
    public partial class frmListarPreAlerta : Form
    {
        public frmListarPreAlerta()
        {
            InitializeComponent();
        }

        private static frmListarPreAlerta _instancia;
        public static frmListarPreAlerta Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmListarPreAlerta();

                return _instancia;
            }
            set { _instancia = value; }
        }

       
        private void CargarNavesExistentes()
        {
            ComboBoxItemCollection coll = ddlNave.Properties.Items;
            IList<Entidades.Paperless.PaperlessNave> listNaves = new List<Entidades.Paperless.PaperlessNave>();

            listNaves = LogicaNegocios.Paperless.Paperless.ObtenerNaves(Entidades.Enums.Enums.Estado.Habilitado);

            coll = ddlNave.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listNaves)
            {
                coll.Add(list);
            }
            ddlNave.SelectedIndex = 0;
            ddlNave.Properties.AutoComplete = true;

        }
        private void CargarEstados()
        {
            string[] filtroestadosprealerta = System.Configuration.ConfigurationSettings.AppSettings.Get("FiltroEstadosPreAlerta").Split(',');
            IList<ProyectoCraft.Entidades.Paperless.PaperlessEstadoPreAlerta> estados =
                ProyectoCraft.LogicaNegocios.Paperless.Paperless.ObtenerEstadosPreAlertaPaperless(Enums.Estado.Habilitado);

            foreach (var list in estados)
            {
                //coll.Add(list);            
                if (filtroestadosprealerta.Contains(list.Nombre))
                    //ddlEstado.Properties.Items.Add(list);
                    ddlEstado.Properties.Items.Add(list, CheckState.Checked, true);
                else
                    ddlEstado.Properties.Items.Add(list, CheckState.Unchecked, true);
            }

            //ComboBoxItemCollection coll = ddlEstado.Properties.Items;
            //coll.Add(ProyectoCraft.WinForm.Utils.Utils.ObtenerPrimerItem());
            //foreach (var list in estados)
            //{
            //    coll.Add(list);
            //}
            //ddlEstado.SelectedIndex = 0;
        }

        public void ObtenerPreAlertas()
        {
            string numconsolidada = "";
            string estados = "";
            String agente = "-1";
            DateTime FechaSalidaDesde = new DateTime(9999, 1, 1);
            DateTime FechaSalidaHasta = new DateTime(9999, 1, 1);
            DateTime FechaLlegadaDesde = new DateTime(9999, 1, 1);
            DateTime FechaLlegadaHasta = new DateTime(9999, 1, 1);
            DateTime FechaRecibimientoDesde = new DateTime(9999, 1, 1);
            DateTime FechaRecibimientoHasta = new DateTime(9999, 1, 1);
            Boolean tieneEstadoChecked = false;

            if (txtFechaRecibimientoDesde.Text == "")
                FechaSalidaDesde = new DateTime(9999, 1, 1);
            else
                FechaSalidaDesde = Convert.ToDateTime(txtFechaRecibimientoDesde.Text);

            FechaSalidaDesde = new DateTime(FechaSalidaDesde.Year, FechaSalidaDesde.Month, FechaSalidaDesde.Day, 0, 0, 1);

            if (txtFechaRecibimientoHasta.Text == "")
                FechaSalidaHasta = new DateTime(9999, 1, 1);
            else
                FechaSalidaHasta = Convert.ToDateTime(txtFechaRecibimientoHasta.Text);

            FechaSalidaHasta = new DateTime(FechaSalidaHasta.Year, FechaSalidaHasta.Month, FechaSalidaHasta.Day, 23, 59, 59);
            
            for (int i = 0; i < ddlEstado.Properties.Items.Count; i++)
            {
                if (ddlEstado.Properties.Items[i].CheckState.Equals(CheckState.Checked))
                {
                    tieneEstadoChecked = true;
                    estados += (i + 1).ToString() + ",";
                }
            }
            if (tieneEstadoChecked)
            {
                //le quito la ultima coma siempre para poder agregarla en el IN de la consulta
                estados = estados.Remove(estados.Length - 1); //+ "''" "''" +;    
            }
            else
                estados = "-1";
            
            /*
            if (ddlEstado.SelectedIndex <= 0)
                estado = -1;
            else
                estado = ((Entidades.Paperless.PaperlessEstadoPreAlerta)ddlEstado.SelectedItem).Id;
            */
            if (txtNumConsolidado.Text.Length.Equals(0))
                numconsolidada = "-1";
            else
                numconsolidada = txtNumConsolidado.Text.Trim();
            
            if (ddlAgente.SelectedIndex <= 0)
                agente = "-1";
            else
                agente = ((Entidades.Paperless.PaperlessAgente)ddlAgente.SelectedItem).Nombre;

            if (txtFechaSalidaDesde.Enabled.Equals(true) && txtFechaSalidaDesde.Text.Length > 0)
                FechaSalidaDesde = new DateTime(txtFechaSalidaDesde.DateTime.Year, txtFechaSalidaDesde.DateTime.Month, txtFechaSalidaDesde.DateTime.Day, 0, 0, 1);

            if (txtFechaSalidaHasta.Enabled.Equals(true) && txtFechaSalidaHasta.Text.Length > 0)
                FechaSalidaHasta = new DateTime(txtFechaSalidaHasta.DateTime.Year, txtFechaSalidaHasta.DateTime.Month, txtFechaSalidaHasta.DateTime.Day, 23, 59, 59);

            if (txtFechaLlegadaDesde.Enabled.Equals(true) && txtFechaLlegadaDesde.Text.Length > 0)
                FechaLlegadaDesde = new DateTime(txtFechaLlegadaDesde.DateTime.Year, txtFechaLlegadaDesde.DateTime.Month, txtFechaLlegadaDesde.DateTime.Day, 0, 0, 1);

            if (txtFechaLlegadaHasta.Enabled.Equals(true) && txtFechaLlegadaHasta.Text.Length > 0)
                FechaLlegadaHasta = new DateTime(txtFechaLlegadaHasta.DateTime.Year, txtFechaLlegadaHasta.DateTime.Month, txtFechaLlegadaHasta.DateTime.Day, 23, 59, 59);

            if (txtFechaRecibimientoDesde.Enabled.Equals(true) && txtFechaRecibimientoDesde.Text.Length > 0)
                FechaRecibimientoDesde = new DateTime(txtFechaRecibimientoDesde.DateTime.Year, txtFechaRecibimientoDesde.DateTime.Month, txtFechaRecibimientoDesde.DateTime.Day, 0, 0, 1);

            if (txtFechaRecibimientoHasta.Enabled.Equals(true) && txtFechaRecibimientoHasta.Text.Length > 0)
                FechaRecibimientoHasta = new DateTime(txtFechaRecibimientoHasta.DateTime.Year, txtFechaRecibimientoHasta.DateTime.Month, txtFechaRecibimientoHasta.DateTime.Day, 23, 59, 59);

            gridPreAlerta.DataSource = null;

            IList<ProyectoCraft.Entidades.Paperless.PaperlessPreAlerta> prealerta =
                ProyectoCraft.LogicaNegocios.Paperless.Paperless.ObtenerPreAlertas(numconsolidada, estados, agente,
                FechaSalidaDesde, FechaSalidaHasta, FechaLlegadaDesde, FechaLlegadaHasta,
                FechaRecibimientoDesde, FechaRecibimientoHasta);


            gridPreAlerta.DataSource = prealerta;
            gridPreAlerta.RefreshDataSource();
            gridPreAlerta.Refresh();
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            Close();
        }

        private void MenuVer_Click(object sender, EventArgs e)
        {
            Entidades.Paperless.PaperlessPreAlerta prealerta = ObtenerPreAlerta();

            if (prealerta != null)
            {
                frmPaperlessPreAlerta form = Paperless.PreAlerta.frmPaperlessPreAlerta.Instancia;
                form.PaperlessPreAlertaActual = prealerta;
                form.Accion = Enums.TipoAccionFormulario.Consultar;
                form.ShowDialog();
            }
            else
                MessageBox.Show("Debe seleccionar una PreAlerta", "Paperless - PreAlerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            /*
            Entidades.Paperless.PaperlessPreAlerta prealerta = ObtenerPreAlerta();
            Paperless.PreAlerta.frmPaperlessPreAlerta form = Paperless.PreAlerta.frmPaperlessPreAlerta.Instancia;

            if (prealerta != null)
            {
                form.PaperlessPreAlertaActual = prealerta;
                form.CargarFormulario();
                form.Accion = Enums.TipoAccionFormulario.Consultar;
                form.ShowDialog();

            }
            else
                MessageBox.Show("Debe seleccionar una PreAlerta", "Paperless - PreAlerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            */
             
        }

        private Entidades.Paperless.PaperlessPreAlerta ObtenerPreAlerta()
        {
            var filaSelected = gridPreAlerta.DefaultView.GetRow(gridView1.FocusedRowHandle);

            if (filaSelected == null)
            {
                return null;
            }

            Entidades.Paperless.PaperlessPreAlerta prealerta = (Entidades.Paperless.PaperlessPreAlerta)filaSelected;

            return prealerta;
        }

        private void ValidaFechas()
        {
            DateTime FechaSalidaDesde = new DateTime(9999, 1, 1);
            DateTime FechaSalidaHasta = new DateTime(9999, 1, 1);
            DateTime FechaLlegadaDesde = new DateTime(9999, 1, 1);
            DateTime FechaLlegadaHasta = new DateTime(9999, 1, 1);
            DateTime FechaRecibimientoDesde = new DateTime(9999, 1, 1);
            DateTime FechaRecibimientoHasta = new DateTime(9999, 1, 1);

            if (txtFechaSalidaDesde.Enabled.Equals(true) && txtFechaSalidaDesde.Text.Length > 0)
                FechaSalidaDesde = new DateTime(txtFechaSalidaDesde.DateTime.Year, txtFechaSalidaDesde.DateTime.Month, txtFechaSalidaDesde.DateTime.Day, 0, 0, 1);

            if (txtFechaSalidaHasta.Enabled.Equals(true) && txtFechaSalidaHasta.Text.Length > 0)
                FechaSalidaHasta = new DateTime(txtFechaSalidaHasta.DateTime.Year, txtFechaSalidaHasta.DateTime.Month, txtFechaSalidaHasta.DateTime.Day, 23, 59, 59);

            if (txtFechaLlegadaDesde.Enabled.Equals(true) && txtFechaLlegadaDesde.Text.Length > 0)
                FechaLlegadaDesde = new DateTime(txtFechaLlegadaDesde.DateTime.Year, txtFechaLlegadaDesde.DateTime.Month, txtFechaLlegadaDesde.DateTime.Day, 0, 0, 1);

            if (txtFechaLlegadaHasta.Enabled.Equals(true) && txtFechaLlegadaHasta.Text.Length > 0)
                FechaLlegadaHasta = new DateTime(txtFechaLlegadaHasta.DateTime.Year, txtFechaLlegadaHasta.DateTime.Month, txtFechaLlegadaHasta.DateTime.Day, 23, 59, 59);

            if (txtFechaRecibimientoDesde.Enabled.Equals(true) && txtFechaRecibimientoDesde.Text.Length > 0)
                FechaRecibimientoDesde = new DateTime(txtFechaRecibimientoDesde.DateTime.Year, txtFechaRecibimientoDesde.DateTime.Month, txtFechaRecibimientoDesde.DateTime.Day, 0, 0, 1);

            if (txtFechaRecibimientoHasta.Enabled.Equals(true) && txtFechaRecibimientoHasta.Text.Length > 0)
                FechaRecibimientoHasta = new DateTime(txtFechaRecibimientoHasta.DateTime.Year, txtFechaRecibimientoHasta.DateTime.Month, txtFechaRecibimientoHasta.DateTime.Day, 23, 59, 59);


            if (chkFechaSalida.Checked.Equals(true))
            {
                int result = DateTime.Compare(FechaSalidaDesde, FechaSalidaHasta);
                if (result > 0)
                {
                    MessageBox.Show("Fecha Salida Hasta es Menor a Fecha Salida Desde.", "PreAlerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (chkFechaLlegada.Checked.Equals(true))
            {
                int result = DateTime.Compare(FechaLlegadaDesde, FechaLlegadaHasta);
                if (result > 0)
                {
                    MessageBox.Show("Fecha Llegada Hasta es Menor a Fecha Llegada Desde.", "PreAlerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (chkFechaRecibimiento.Checked.Equals(true))
            {
                int result = DateTime.Compare(FechaRecibimientoDesde, FechaRecibimientoHasta);
                if (result > 0)
                {
                    MessageBox.Show("Fecha Recibimiento Hasta es Menor a Fecha Recibimiento Desde.", "PreAlerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ValidaFechas();
            ObtenerPreAlertas();
        }

        private void MenuCancelar_Click(object sender, EventArgs e)
        {
            Entidades.Paperless.PaperlessPreAlerta prealerta = ObtenerPreAlerta();

            DialogResult resdialogo = new DialogResult();

            if (prealerta != null)
            {
                if (prealerta.Estado.Nombre.Equals("Abierto"))
                    resdialogo = MessageBox.Show("¿Está seguro de Cancelar la PreAlerta?", "PreAlerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (resdialogo == DialogResult.Yes)
                {
                    prealerta.Estado = new PaperlessEstadoPreAlerta() { id = 3, descripcion = "Cancelado", Activo = 1 };
                    ResultadoTransaccion res = new ResultadoTransaccion();
                    res = LogicaNegocios.Paperless.Paperless.CambiaEstadoCancelacionPreAlerta(prealerta);

                    if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                    {
                        frmListarPreAlerta form = frmListarPreAlerta.Instancia;
                        form.ObtenerPreAlertas();

                        MDICraft mdi = MDICraft.Instancia;
                        mdi.MensajeAccion(Enums.TipoAccionFormulario.CambiarEstado);

                        //Instancia = null;
                        //this.Close();
                    }
                    else
                        MessageBox.Show(res.Descripcion, "PreAlerta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void chkPlazoEmbarcador_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFechaSalida.Checked.Equals(true))
            {
                txtFechaSalidaDesde.Enabled = true;
                txtFechaSalidaHasta.Enabled = true;
            }
            else
            {
                txtFechaSalidaDesde.Enabled = false;
                txtFechaSalidaHasta.Enabled = false;
            }
        }

        private void chkAperturaNaviera_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFechaLlegada.Checked.Equals(true))
            {
                txtFechaLlegadaDesde.Enabled = true;
                txtFechaLlegadaHasta.Enabled = true;
            }
            else
            {
                txtFechaLlegadaDesde.Enabled = false;
                txtFechaLlegadaHasta.Enabled = false;
            }
        }

        private void chkCreacionPaperless_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFechaRecibimiento.Checked.Equals(true))
            {
                txtFechaRecibimientoDesde.Enabled = true;
                txtFechaRecibimientoHasta.Enabled = true;
            }
            else
            {
                txtFechaRecibimientoDesde.Enabled = false;
                txtFechaRecibimientoHasta.Enabled = false;
            }
        }

        private void frmListarPreAlerta_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            CargarAgentesExistentes();
            CargarEstados();

            ObtenerPreAlertas();

            /*
            gridPreAlerta.DataSource = PreAlerta;
            gridPreAlerta.RefreshDataSource();
            gridPreAlerta.Refresh();
            */
        }

        private void CargarAgentesExistentes()
        {
            ComboBoxItemCollection coll = ddlAgente.Properties.Items;

            IList<Entidades.Paperless.PaperlessAgente> listAgentes = new List<Entidades.Paperless.PaperlessAgente>();

            listAgentes = LogicaNegocios.Paperless.Paperless.ObtenerAgentes(Entidades.Enums.Enums.Estado.Habilitado);

            coll = ddlAgente.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listAgentes)
            {
                coll.Add(list);
            }
            ddlAgente.SelectedIndex = 0;
            ddlAgente.Properties.AutoComplete = true;

            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(txtAgente.Text);
            txtAgente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtAgente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (var list in listAgentes)
            {
                auto.Add(list.Nombre);
            }
            txtAgente.AutoCompleteCustomSource = auto;
        }


        private void MenuNuevo_Click_1(object sender, EventArgs e)
        {
            frmPaperlessPreAlerta form = Paperless.PreAlerta.frmPaperlessPreAlerta.Instancia;
            form.Accion = Enums.TipoAccionFormulario.Nuevo;
            form.ShowDialog();
        }

        private void gridPreAlerta_Click(object sender, EventArgs e)
        {
            Entidades.Paperless.PaperlessPreAlerta prealerta = ObtenerPreAlerta();
            MenuNuevo.Enabled = true;
            MenuVer.Enabled = true;
            MenuCancelar.Text = "Cancelar";
            if (prealerta != null)
            {
                if (prealerta.Estado.Nombre.Equals("Abierto"))
                    MenuCancelar.Enabled = true;
                else
                    MenuCancelar.Enabled = false;
            }
        }

        private void txtFechaSalidaHasta_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void MenuExportar_Click(object sender, EventArgs e)
        {
            try
            {
                var grabarArchivo = new SaveFileDialog();
                grabarArchivo.Filter = "Excel(xls)|*.xls";
                grabarArchivo.Title = "Exportar Excel";
                grabarArchivo.DefaultExt = "xls";
                grabarArchivo.FileName = "";
                grabarArchivo.OverwritePrompt = true;
                grabarArchivo.ShowDialog();

                if (grabarArchivo.FileName != "")
                {
                    // Saves the Image via a FileStream created by the OpenFile method.
                    var fs = (FileStream)grabarArchivo.OpenFile();
                    var options = new XlsExportOptions();
                    options.ShowGridLines = true;
                    options.UseNativeFormat = false;
                    gridView1.BestFitColumns();
                    gridView1.OptionsPrint.AutoWidth = false;
                    gridView1.ExportToXls(fs, options);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);
                MessageBox.Show("Error al generar archivo Excel: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ddlAgente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
