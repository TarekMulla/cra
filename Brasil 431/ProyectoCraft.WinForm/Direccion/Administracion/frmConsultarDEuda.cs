using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProyectoCraft.Entidades.Direccion.Administracion;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using ProyectoCraft.Base.Log;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;

namespace ProyectoCraft.WinForm.Direccion.Administracion
{
    public partial class frmConsultarDEuda : Form
    {
        public frmConsultarDEuda()
        {
            InitializeComponent();
        }
        private static frmConsultarDEuda _form = null;

        private void CargaGrilla(DateTime Fecha)
        {
            this.gridConsultaDeuda.DataSource = null;
            Entidades.GlobalObject.ResultadoTransaccion res = 
                LogicaNegocios.Direccion.Administracion.clsControlCredito.ListarContrlDeudoresFecha(Fecha);
            this.gridConsultaDeuda.DataSource = res.ObjetoTransaccion;
            this.gridConsultaDeuda.Refresh();
        }

        public static frmConsultarDEuda Instancia
        {
            get
            {
                if (_form == null)
                    _form = new frmConsultarDEuda();

                return _form;
            }
            set
            {
                _form = value;
            }
        }

        private void gridConsultaDeuda_Click(object sender, EventArgs e)
        {

        }

        private void sButtonBuscar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            CargaGrilla(this.Date.DateTime);
            Cursor.Current = Cursors.Default;
        }

        private void Padre_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            //if (e.RowHandle == 0 && e.RelationIndex == 0)
                
        }

        private void frmConsultarDEuda_Load(object sender, EventArgs e)
        {
            this.Date.DateTime = System.DateTime.Now;
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConsultarDEuda_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }

        private void MenuExportar_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog GrabarArchivo = new SaveFileDialog();
                GrabarArchivo.Filter = "Excel(xls)|*.xls";
                GrabarArchivo.Title = "Exportar Excel";
                GrabarArchivo.DefaultExt = "xls";
                GrabarArchivo.FileName = "";
                GrabarArchivo.OverwritePrompt = true;
                GrabarArchivo.ShowDialog();

                if (GrabarArchivo.FileName != "")
                {
                    // Saves the Image via a FileStream created by the OpenFile method.
                    System.IO.FileStream fs =
                       (System.IO.FileStream)GrabarArchivo.OpenFile();
                    this.gridConsultaDeuda.ExportToXls(fs, true);

                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);
                MessageBox.Show("Error al generar archivo Excel: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bandedGridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
        }

        private void bandedGridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            double riesgo;
            GridView currentView = sender as GridView;

            if (e.Column.FieldName == "Riesgo")
            {
                if (currentView.GetRowCellValue(e.RowHandle, currentView.Columns[11]) != null)
                {
                    riesgo = (double)currentView.GetRowCellValue(e.RowHandle, currentView.Columns[11]);
                    if (riesgo < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                }
            }
        }

        private void bandedGridView1_DataSourceChanged(object sender, EventArgs e)
        {

        }
    }
}
