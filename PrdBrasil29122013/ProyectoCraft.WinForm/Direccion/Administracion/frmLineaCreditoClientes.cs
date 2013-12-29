using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.LogicaNegocios.Parametros;
using ProyectoCraft.LogicaNegocios.Clientes;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Clientes.Target;
using ProyectoCraft.Entidades.Clientes.Contacto;
using ProyectoCraft.Entidades.Clientes.Cuenta;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Direccion.Administracion;
using ProyectoCraft.Entidades.Tarifado;
using ProyectoCraft.Base.Log;

namespace ProyectoCraft.WinForm.Direccion.Administracion
{
    public partial class frmLineaCreditoClientes : Form
    {
        private static frmLineaCreditoClientes _form = null;
        public frmLineaCreditoClientes()
        {
            InitializeComponent();
        }
        public static frmLineaCreditoClientes Instancia
        {
            get
            {
                if (_form == null)
                    _form = new frmLineaCreditoClientes();

                return _form;
            }
            set
            {
                _form = value;
            }
        }
        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void frmLineaCreditoClientes_Load(object sender, EventArgs e)
        {

        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void BuscarLineaCredito()
        {
            Entidades.GlobalObject.ResultadoTransaccion res =
                LogicaNegocios.Direccion.Administracion.clsControlCredito.ListarCreditoClientes();

            IList<clsCreditoCliente> ListaCreditoClientes = (IList<clsCreditoCliente>)res.ObjetoTransaccion;

            this.gridLineaCredito.DataSource = null;
            this.gridLineaCredito.DataSource = ListaCreditoClientes;
        }

        private void sButtonBuscar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.BuscarLineaCredito();
            Cursor.Current = Cursors.Default;
        }

        private void MenuSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
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
                    this.gridLineaCredito.ExportToXls(fs, true);

                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);
                MessageBox.Show("Error al generar archivo Excel: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLineaCreditoClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }
    }
}
