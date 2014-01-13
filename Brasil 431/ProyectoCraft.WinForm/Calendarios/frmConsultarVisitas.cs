using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Usuarios;
using DevExpress.XtraScheduler;

namespace ProyectoCraft.WinForm.Calendarios
{
    public partial class frmConsultarVisitas : Form
    {
        public frmConsultarVisitas()
        {
            InitializeComponent();
        }

        private static frmConsultarVisitas _form = null;
        public static frmConsultarVisitas Instancia
        {
            get
            {
                if (_form == null)
                    _form = new frmConsultarVisitas();

                return _form;
            }
            set { _form = value; }
        }



        private void frmConsultarVisitas_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            CargarVendedores();
            ListarEstados();
            CargarClientes();

            

            //repositoryItemButtonEdit1.Buttons[0].Caption = "Ver Informe";
            //repositoryItemButtonEdit1.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
        }

        private void CargarClientes()
        {
            IList<clsClienteMaster> listclientes =
                LogicaNegocios.Clientes.clsClientesMaster.ListarClienteMaster(this.cboCliente.Text,
                                                                              Enums.TipoPersona.Comercial, Enums.Estado.Habilitado, true);

            ComboBoxItemCollection coll = cboCliente.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listclientes)
            {
                coll.Add(list);                
            }
            cboCliente.SelectedIndex = 0;
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(txtCliente.Text);

            foreach (var list in listclientes)
            {
                auto.Add(list.ToString());                
            }

            txtCliente.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCliente.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCliente.MaskBox.AutoCompleteCustomSource = auto;
        }

        private void CargarVendedores()
        {
            ResultadoTransaccion res = LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Enums.Estado.Habilitado, Enums.CargosUsuarios.Vendedor);
            IList<clsUsuario> listVendedores = (IList<clsUsuario>)res.ObjetoTransaccion;

            ComboBoxItemCollection coll = cboVendedor.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listVendedores)
            {
                coll.Add(list);
            }
            cboVendedor.SelectedIndex = 0;
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(txtVendedor.Text);

            foreach (var list in listVendedores)
            {
                auto.Add(list.Nombre + " " + list.ApellidoPaterno + " " + list.ApellidoMaterno);
            }

            txtVendedor.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtVendedor.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtVendedor.MaskBox.AutoCompleteCustomSource = auto;

        }

        private void ListarEstados()
        {
            IList<Entidades.Calendario.clsVisitaEstado> estados =
                LogicaNegocios.Calendarios.clsCalendarios.ListarVisitaEstados();

            ComboBoxItemCollection coll = CboEstado.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in estados)
            {
                coll.Add(list);
            }
            CboEstado.SelectedIndex = 0;

        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Int64 IdVendedor;
            Int64 IdCliente;
            DateTime desde;
            DateTime hasta;
            Int64 estado;

            if (txtVendedor.Text == "")
                IdVendedor = -1;
            else
            {
                for (int i = 0; i < cboVendedor.Properties.Items.Count; i++)
                {
                    if (cboVendedor.Properties.Items[i].ToString() == txtVendedor.Text)
                    {
                        cboVendedor.SelectedIndex = i;
                        break;
                    }
                        
                }
                
                IdVendedor = ((clsUsuario)cboVendedor.SelectedItem).Id;
            }
                

            if (txtCliente.Text == "")
                IdCliente = -1;
            else
            {
                for (int i = 0; i < cboCliente.Properties.Items.Count; i++)
                {
                    if (cboCliente.Properties.Items[i].ToString() == txtCliente.Text)
                    {
                        cboCliente.SelectedIndex = i;
                        break;
                    }
                        
                }
                IdCliente = ((clsClienteMaster)cboCliente.SelectedItem).Id;
            }
                

            if (txtDesde.Text == "")
                desde = new DateTime(9999, 1, 1);
            else
                desde = txtDesde.DateTime;

            if (txtHasta.Text == "")
                hasta = new DateTime(9999, 1, 1);
            else
                hasta = txtHasta.DateTime;

            if (CboEstado.SelectedIndex == 0)
                estado = -1;
            else            
                estado = ((Entidades.Calendario.clsVisitaEstado) CboEstado.SelectedItem).Id;

            desde = new DateTime(desde.Year,desde.Month,desde.Day,0,0,1);
            hasta = new DateTime(hasta.Year,hasta.Month,hasta.Day,23,59,59);


            Cursor.Current = Cursors.WaitCursor;
            ConsultarVisitas(IdVendedor,IdCliente,desde,hasta,estado);
            Cursor.Current = Cursors.Default;
        }

        private void ConsultarVisitas(Int64 IdVendedor, Int64 IdCliente, DateTime desde, DateTime hasta, Int64 estado)
        {
            IList<Entidades.Calendario.clsVisita> visitas =
                LogicaNegocios.Calendarios.clsCalendarios.ListarVisitasInforme(IdVendedor, IdCliente, desde, hasta,estado);
            grdVisitas.DataSource = visitas;

            RepositoryItemButtonEdit rep = new RepositoryItemButtonEdit();
            rep.CreateDefaultButton();
            grdVisitas.RepositoryItems.Add(rep);
            
            //visitas[0].Informvisita.ResumenVisita
            //visitas[0].Vendedor.NombreCompleto;
            //visitas[0].Cliente.NombreCompañia
            //visitas[0].FechaHoraComienzo;
            //visitas[0].FechaHoraTermino;
            //visitas[0].EsReplanificada;
            //visitas[0].Asunto;
            //visitas[0].Ubicacion
            //visitas[0].EstadoBD
            //visitas[0].UsuarioOrganizador.NombreCompleto
            //visitas[0].Informvisita.FollowUp;
            //visitas[0].NivelImportancia.Nombre


        }

        private void MenuExcel_Click(object sender, EventArgs e)
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
                    this.grdVisitas.ExportToXls(fs, true);

                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);
                MessageBox.Show("Error al generar archivo Excel: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarVisita(Entidades.Calendario.clsVisita visita)
        {
            if (visita != null)
            {
                FrmNuevaVisita form = FrmNuevaVisita.Instancia;
                form.IdVisitaConsulta = visita.Id;
                form.Accion = Enums.TipoAccionFormulario.Consultar;
                form.EsInforme = true;             
                form.ShowDialog();
            }  
        }

        private Entidades.Calendario.clsVisita ObtenerVisitaDesdeGrilla()
        {
            Entidades.Calendario.clsVisita ObjPaso = null;
            int fila_sel = 0;

            if (gridView1.SelectedRowsCount == 1)
            {
                fila_sel = gridView1.GetSelectedRows()[0];
                ObjPaso = (Entidades.Calendario.clsVisita)gridView1.GetRow(fila_sel);                
            }
            return ObjPaso;
        }

        private void grdVisitas_DoubleClick(object sender, EventArgs e)
        {
            CargarVisita(ObtenerVisitaDesdeGrilla());
        }
               
        private void MenuVerVisita_Click(object sender, EventArgs e)
        {
            CargarVisita(ObtenerVisitaDesdeGrilla());
        }

        private void MenuVerInforme_Click(object sender, EventArgs e)
        {
            Entidades.Calendario.clsVisita visita = ObtenerVisitaDesdeGrilla();

            if(visita != null && visita.TieneInforme)
            {
                CargarInformeVisita(visita);
            }
            else
            {
                MessageBox.Show("La Visita seleccionada no tiene Informe registrado", "Consulta Visitas",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void CargarInformeVisita(Entidades.Calendario.clsVisita visita)
        {
            if(visita != null)
            {
                frmInformeVisita form = frmInformeVisita.Instancia;
                form.Visita = visita;
                form.Accion = Enums.TipoAccionFormulario.Consultar;
                form.ShowDialog();
            }
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string Tope = View.GetRowCellDisplayText(e.RowHandle, View.Columns["NivelImportancia.Nombre"]);

                if (Tope == "Urgente")
                {
                    e.Appearance.Font = new Font(e.Appearance.Font,FontStyle.Bold);
                    //e.Appearance.BackColor = Color.Salmon;
                    //e.Appearance.BackColor2 = Color.Salmon;
                }
                                                
                string estado = View.GetRowCellDisplayText(e.RowHandle, View.Columns["EstadoVistaDescripcion"]);
                if (estado == "Incompleta")
                {
                    e.Appearance.BackColor = Color.White;                    
                }
                if (estado == "Planificada Por confirmar")
                {
                    e.Appearance.BackColor = Color.SandyBrown;                    
                }
                if (estado == "Confirmada")
                {
                    e.Appearance.BackColor = Color.Khaki;                    
                }
                if (estado == "Realizada Informe Pendiente")
                {
                    e.Appearance.BackColor = Color.YellowGreen;                    
                }
                if (estado == "Realizada Con Informe")
                {
                    e.Appearance.BackColor = Color.LightGreen;                    
                }
                if (estado == "No Realizada")
                {
                    e.Appearance.BackColor = Color.LightCoral;                    
                }
                if (estado == "Realizada Con Informe Fuera De Plazo")
                {
                    e.Appearance.BackColor = Color.LightCoral;                    
                }
                

            }
        }                            
    }
}
