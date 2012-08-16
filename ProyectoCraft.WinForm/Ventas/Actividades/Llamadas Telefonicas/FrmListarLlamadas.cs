using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using ProyectoCraft.Entidades.Ventas.Actividades.Llamadas_Telefonicas;
using ProyectoCraft.Entidades.Ventas.Actividades;
using ProyectoCraft.Entidades.Clientes.Target;
using ProyectoCraft.Entidades.Clientes.Contacto;
using ProyectoCraft.Entidades.Clientes.Cuenta;
using ProyectoCraft.Entidades.Clientes;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Base.Log;

namespace ProyectoCraft.WinForm.Ventas.Actividades.Llamadas_Telefonicas
{
    public partial class FrmListarLlamadas : Form
    {
        long IdUsuario;        
        private static FrmListarLlamadas _form = null;
        public static FrmListarLlamadas Instancia
        {
            get
            {
                if (_form == null)
                    _form = new FrmListarLlamadas();

                return _form;
            }
            set
            {
                _form = value;
            }
        }
        public FrmListarLlamadas()
        {
            InitializeComponent();
        }

        private void CargarComboContactos(int IdCliente, string Nombre, long IdPropietario, short IdEstado)
        {
            //Llena el combo con la lista de Targets
            CboContactos.Properties.Items.Clear();
            //Entidades.GlobalObject.ResultadoTransaccion res = LogicaNegocios.Clientes.clsTarget.ListarContactoporClienteUsuario(IdUsuario, IdCliente);
            IList<clsContacto> ListaContactos = LogicaNegocios.Clientes.clsContactos.ListarContactos(Nombre, IdCliente, IdPropietario, IdEstado);

            ComboBoxItemCollection coll = CboContactos.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in ListaContactos)
            {
                coll.Add(list);
            }

            CboContactos.SelectedIndex = 0;

            AutoCompleteStringCollection textoAutocompletar = new AutoCompleteStringCollection();
            textoAutocompletar = new AutoCompleteStringCollection();

            //TxtContacto.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //TxtContacto.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (var list in ListaContactos)
            {
                textoAutocompletar.Add(list.Nombre);
            }
            foreach (var list in ListaContactos)
            {
                textoAutocompletar.Add(list.Nombre);
            }
            //TxtContacto.MaskBox.AutoCompleteCustomSource = textoAutocompletar;

        }

        private void EditarLlamada()
        {
            ClsLlamadaTelefonica ObjPaso;
            int fila_sel=0;

            if (gridViewLlamadas.SelectedRowsCount==1)
            {
                fila_sel = gridViewLlamadas.GetSelectedRows()[0];
                ObjPaso =  (ClsLlamadaTelefonica)gridViewLlamadas.GetRow(fila_sel);
                Ventas.Actividades.Llamadas_Telefonicas.FrmLlamadaTelefonica.ObjLlamadaTelefonica = ObjPaso;

                Ventas.Actividades.Llamadas_Telefonicas.FrmLlamadaTelefonica form = Ventas.Actividades.Llamadas_Telefonicas.FrmLlamadaTelefonica.Instancia;
                //Ventas.Actividades.Llamadas_Telefonicas.FrmEstadisticaLlamadas form = Ventas.Actividades.Llamadas_Telefonicas.FrmEstadisticaLlamadas.Instancia;
                form.ShowDialog(this);            
            }
        }

        private void CargarComboClientesTodos(long IdUsuario, string Busqueda)
        {
            //Llena el combo con la lista de Targets
            CboCliente.ResetText();
            IList<clsClienteMaster> ListaClienteMaster = LogicaNegocios.Clientes.clsClientesMaster.ListarClienteMaster(Busqueda, Enums.TipoPersona.Comercial, Enums.Estado.Todos,true);

            ComboBoxItemCollection coll = CboCliente.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in ListaClienteMaster)
            {
                coll.Add(list);
            }

            CboCliente.SelectedIndex = 0;

            AutoCompleteStringCollection textoAutocompletar = new AutoCompleteStringCollection();
            textoAutocompletar = new AutoCompleteStringCollection();

            CboCliente.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboCliente.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (var list in ListaClienteMaster)
            {
                textoAutocompletar.Add(list.NombreCliente);
            }
            CboCliente.MaskBox.AutoCompleteCustomSource = textoAutocompletar;
        }

        private void CargarGrillaLlamadas(DateTime FechaInicio, DateTime FechaTermino, long IdContacto, long IdClienteMaster, long IdUsuario, int TipoSelect)
        {
            Entidades.GlobalObject.ResultadoTransaccion res = 
                LogicaNegocios.Ventas.Actividades.Llamadas_Telefonicas.ClsLlamataTelefonica.ListarLlamadasTelefonicas(FechaInicio, FechaTermino, IdContacto, IdClienteMaster,IdUsuario, TipoSelect);
            
            IList<ClsLlamadaTelefonica> ListaLlamadas = (IList<ClsLlamadaTelefonica>)res.ObjetoTransaccion;

            this.gridLlamadas.DataSource = null;
            this.gridLlamadas.DataSource = ListaLlamadas;

        }

        private void FrmListarLlamadas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }

        private void sButtonBuscar_Click(object sender, EventArgs e)
        {
            DateTime  FechaInicio ;
            DateTime  FechaTermino ;

            FechaInicio = dateInicio.DateTime;
            FechaTermino = dateHasta.DateTime;
            int IdContacto = 0;

            clsContacto ObjContacto = new clsContacto();
            clsClienteMaster ObjClienteMaster = new clsClienteMaster(true);

            if (CboContactos.SelectedItem != null && CboContactos.SelectedIndex > 0)
            {
                ObjContacto = (clsContacto)CboContactos.SelectedItem;
            }
            else
            {
                ObjContacto.Id = 0;
            }

            if (CboCliente.SelectedItem != null && CboCliente.SelectedIndex > 0)
            {
                ObjClienteMaster = (clsClienteMaster)CboCliente.SelectedItem;
            }
            else
            {
                ObjClienteMaster.Id = 0;
            }

            Cursor.Current = Cursors.WaitCursor;
            CargarGrillaLlamadas(FechaInicio, FechaTermino, ObjContacto.Id, ObjClienteMaster.Id,IdUsuario,0);
            Cursor.Current = Cursors.Default;
        }

        private void FrmListarLlamadas_Load(object sender, EventArgs e)
        {
            IdUsuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario.Id;
            CargarComboClientesTodos(IdUsuario, "");
            CargarComboContactos(-1,"-1",-1,-1);
            this.dateInicio.DateTime = System.DateTime.Now; 
            this.dateHasta.DateTime = System.DateTime.Now;
        }

        private void CboContactos_Leave(object sender, EventArgs e)
        {
        }

        private void MenuEditarLlamada_Click(object sender, EventArgs e)
        {
            EditarLlamada();
        }

        private void CboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuCrearLlamada_Click(object sender, EventArgs e)
        {
            Ventas.Actividades.Llamadas_Telefonicas.FrmLlamadaTelefonica form = Ventas.Actividades.Llamadas_Telefonicas.FrmLlamadaTelefonica.Instancia;
            form.ShowDialog(this);
        }

        private void grpFiltros_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            ClsLlamadaTelefonica ObjPaso;
            int fila_sel = 0;
            long IdLlamada;
            Entidades.GlobalObject.ResultadoTransaccion res;
            DateTime FechaInicio;
            DateTime FechaTermino;

            if (gridViewLlamadas.SelectedRowsCount == 1)
            {
                DialogResult resdialogo = MessageBox.Show("¿Está seguro de eliminar la Llamada", "Llamadas Telefónicas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resdialogo == System.Windows.Forms.DialogResult.Yes)
                {
                    fila_sel = gridViewLlamadas.GetSelectedRows()[0];
                    ObjPaso = (ClsLlamadaTelefonica)gridViewLlamadas.GetRow(fila_sel);
                    IdLlamada = ObjPaso.Id;
                    res = LogicaNegocios.Ventas.Actividades.Llamadas_Telefonicas.ClsLlamataTelefonica.EliminarLlamadaTelefonica(IdLlamada);

                    FechaInicio = dateInicio.DateTime;
                    FechaTermino = dateHasta.DateTime;
                    int IdContacto = 0;

                    clsContacto ObjContacto = new clsContacto();

                    if (CboContactos.SelectedItem != null && CboContactos.SelectedIndex > 0)
                    {
                        ObjContacto = (clsContacto)CboContactos.SelectedItem;
                    }
                    else
                    {
                        ObjContacto.Id = 0;
                    }

                    clsClienteMaster ObjClienteMaster = new clsClienteMaster(true);

                    if (CboCliente.SelectedItem != null && CboCliente.SelectedIndex > 0)
                    {
                        ObjClienteMaster = (clsClienteMaster)CboCliente.SelectedItem;
                    }
                    else
                    {
                        ObjClienteMaster.Id = 0;
                    }

                    Cursor.Current = Cursors.WaitCursor;
                    CargarGrillaLlamadas(FechaInicio, FechaTermino, ObjContacto.Id, ObjClienteMaster.Id,IdUsuario,0 );
                    Cursor.Current = Cursors.Default;
                }
            }
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
                    this.gridLlamadas.ExportToXls(fs, true);

                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);
                MessageBox.Show("Error al generar archivo Excel: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBoxConsultasRapidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime FechaInicio;
            DateTime FechaTermino;
            int TipoSelect=0;

            FechaInicio = dateInicio.DateTime;
            FechaTermino = dateHasta.DateTime;

            if (lstTipoBusqueda.SelectedIndex > 0)
                TipoSelect = lstTipoBusqueda.SelectedIndex;

            Cursor.Current = Cursors.WaitCursor;
            CargarGrillaLlamadas(FechaInicio, FechaTermino, 0, 0,IdUsuario,TipoSelect);
            Cursor.Current = Cursors.Default;
        }

        private void gridLlamadas_DoubleClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            EditarLlamada();
            Cursor.Current = Cursors.Default;
        }

        private void gridLlamadas_Click(object sender, EventArgs e)
        {

        }
    }
}
