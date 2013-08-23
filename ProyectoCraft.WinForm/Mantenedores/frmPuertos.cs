using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.LogicaNegocios.Cotizaciones;

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

        private void ListarPuertos() {
            var puertos = ClsPuertos.ObtieneTodosLosPuertos().ObjetoTransaccion as List<ClsPuertos>;
            gridPuertos.DataSource = puertos;
            gridPuertos.RefreshDataSource();
        }

        private void frmPuertos_Load(object sender, EventArgs e) {
            ListarPuertos();
        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            Instancia = null;
            Close();
        }

        private void MenuExcel_Click(object sender, EventArgs e) {
            try {
                SaveFileDialog GrabarArchivo = new SaveFileDialog();
                GrabarArchivo.Filter = "Excel(xls)|*.xls";
                GrabarArchivo.Title = "Exportar Excel";
                GrabarArchivo.DefaultExt = "xls";
                GrabarArchivo.FileName = "";
                GrabarArchivo.OverwritePrompt = true;
                GrabarArchivo.ShowDialog();

                if (GrabarArchivo.FileName != "") {
                    // Saves the Image via a FileStream created by the OpenFile method.
                    System.IO.FileStream fs =
                       (System.IO.FileStream)GrabarArchivo.OpenFile();
                    gridPuertos.ExportToXls(fs, true);

                    fs.Close();
                }
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);
                MessageBox.Show("Error al generar archivo Excel: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            var puerto = GetSelectedRow(sender as GridView);
            txtCodigo.Text = puerto.Codigo;
            txtPais.Text = puerto.Pais;
            txtNombre.Text = puerto.Nombre;
        }

        private Puerto GetSelectedRow(GridView view) {
            return (Puerto)view.GetRow(view.FocusedRowHandle);
        }
    }
}
