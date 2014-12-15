using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Direccion.Metas;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.LogicaNegocios.Direccion.Metas;
using ProyectoCraft.Entidades.Enums;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using ProyectoCraft.WinForm.Utils;
using SCCMultimodal.Utils;


namespace ProyectoCraft.WinForm.Direccion.Metas
{
    public partial class frmGestionarSLead : Form
    {
        private static frmGestionarSLead _form = null;
        ClsSalesLead objSalesLead;

        public static frmGestionarSLead Instancia
        {
            get
            {
                if (_form == null)
                    _form = new frmGestionarSLead();

                return _form;
            }
            set
            {
                _form = value;
            }
        }

        public frmGestionarSLead()
        {
            InitializeComponent();
        }

        private void frmGestionarSLead_Load(object sender, EventArgs e)
        {
            ChartSalesLead.Series.Clear();
            this.DateDesde.DateTime = System.DateTime.Now.AddMonths(-6);
            this.DateHasta.DateTime = System.DateTime.Now;
        }
        private void CargarGrillaObservaciones(long IdSalesLead)
        {
            Entidades.GlobalObject.ResultadoTransaccion res =
                LogicaNegocios.Direccion.Metas.ClsSalesLeadNegocio.ListarObservacionesSalesLead(IdSalesLead);

            IList<clsSalesLeadObservaciones> ListaObservaciones = (IList<clsSalesLeadObservaciones>)res.ObjetoTransaccion;

            this.gridObservacionesSL.DataSource = null;
            this.gridObservacionesSL.DataSource = ListaObservaciones;
        }
        private bool ValidaObligatoriosGrilla(string Mensaje)
        {
            IList<clsSalesLeadObservaciones> ListaObservaciones = new List<clsSalesLeadObservaciones>();

            ListaObservaciones = (IList<clsSalesLeadObservaciones>)gridObservacionesSL.DataSource;
            Mensaje = "";

            foreach (clsSalesLeadObservaciones Observacion in ListaObservaciones)
            {
                if (Observacion.ObjUsuario.NombreUsuario == "")
                {
                    Mensaje = "Falta el usuario que registra la observación";
                    return false;
                }
                if (Observacion.FechaHora.Date.ToString() == "")
                {
                    Mensaje = "Falta la fecha y hora de registro de la observación";
                    return false;
                }
                if (Observacion.Observacion == "")
                {
                    Mensaje = "Debe digitar el comentario";
                    return false;
                }
            }
            return true;
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
                    var  fs = (System.IO.FileStream)GrabarArchivo.OpenFile();
                    gridSLeads.ExportToXls(fs, true);

                    fs.Close();
                }
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);
                MessageBox.Show("Error al generar archivo Excel: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuNuevo_Click(object sender, EventArgs e) {

            DateTime FechaDesde;
            DateTime FechaHasta;

            Cursor.Current = Cursors.WaitCursor;
            this.CargarGrillaSLeads();

            FechaDesde = DateDesde.DateTime.Date;
            FechaHasta = DateHasta.DateTime.Date;

            CargarGraficos("1,2,3,4,5", 0, FechaDesde, FechaHasta);
            Cursor.Current = Cursors.Default;
            MenuFollowUp.Enabled = true;
        }

        private void CargarGrillaSLeads() {

            var res = ClsSalesLeadNegocio.ListarSalesLeads();

            var listaSLeads = (IList<ClsSalesLead>)res.ObjetoTransaccion;
            gridSLeads.DataSource = null;
            gridSLeads.DataSource = listaSLeads;
        }

        private void CargarGraficos(string Estados, long IdAgente, DateTime FechaDesde, DateTime FechaHasta)
        {
            DataTable res =
                LogicaNegocios.Direccion.Metas.ClsSalesLeadNegocio.GraficaEstadoAgente(Estados, IdAgente, FechaDesde, FechaHasta);

            this.ChartSalesLead.Series.Clear();
            this.ChartSalesLead.SeriesDataMember = "Estado";
            this.ChartSalesLead.SeriesTemplate.ArgumentDataMember = "Agente";
            this.ChartSalesLead.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Value" });
            ChartSalesLead.DataSource = (DataTable)res;
        }


        private void MenuSalir_Click(object sender, EventArgs e) {
            Instancia = null;
            Close();
        }

        private void gridViewProspectos_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e) {
            int fila_sel = 0;

            if (gridViewSLeads.RowCount > 0) {
                fila_sel = gridViewSLeads.GetSelectedRows()[0];
                if (fila_sel >= 0) {
                    objSalesLead = (ClsSalesLead)gridViewSLeads.GetRow(fila_sel);
                    //CargarGrillaObservaciones(ObjProspecto.Id);
                }
            }
        }

        private void sBActualizar_Click(object sender, EventArgs e)
        {
            DateTime FechaDesde;
            DateTime FechaHasta;

            Cursor.Current = Cursors.WaitCursor;

            FechaDesde = DateDesde.DateTime.Date;
            FechaHasta = DateHasta.DateTime.Date;

            CargarGraficos("1,2,3,4,5", 0, FechaDesde, FechaHasta);
            Cursor.Current = Cursors.Default;
        }

        private void gridSLeads_Click(object sender, EventArgs e)
        {

        }

        private void sButtonAgregarObservacion_Click(object sender, EventArgs e)
        {
            IList<clsSalesLeadObservaciones> ListaObservacionesSL = new List<clsSalesLeadObservaciones>();

            if (this.gridObservacionesSL.DataSource != null)
            {
                ListaObservacionesSL = (IList<clsSalesLeadObservaciones>)this.gridObservacionesSL.DataSource;
            }

            clsSalesLeadObservaciones ObjObservacion = new clsSalesLeadObservaciones();

            ObjObservacion.FechaHora = DateTime.Now;
            ObjObservacion.ObjUsuario = new clsUsuario();
            ObjObservacion.ObjUsuario = (clsUsuario)Base.Usuario.UsuarioConectado.Usuario;
            ObjObservacion.Observacion = "";
            ListaObservacionesSL.Add(ObjObservacion);

            this.gridObservacionesSL.DataSource = null;
            this.gridObservacionesSL.DataSource = ListaObservacionesSL;
        }

        private void sButtonEliminarObservacion_Click(object sender, EventArgs e)
        {
            clsSalesLeadObservaciones ObjObservacion = new clsSalesLeadObservaciones();
            int fila_sel = 0;
            if (this.gridViewObsSL.DataSource != null)
            {
                if (MessageBox.Show("¿Está seguro que desea ELIMINAR el comentario?", "Sistema Comercial Craft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    fila_sel = this.gridViewObsSL.GetSelectedRows()[0];
                    ObjObservacion = (clsSalesLeadObservaciones)this.gridViewObsSL.GetRow(fila_sel);
                    Entidades.GlobalObject.ResultadoTransaccion res =
                        ClsSalesLeadNegocio.EliminarObservacionesSalesLead(ObjObservacion.Id);
                    if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                    {
                        this.gridViewObsSL.DeleteSelectedRows();
                    }
                    else
                    {
                        MessageBox.Show(res.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void sButtonGrabarObs_Click(object sender, EventArgs e)
        {
            var mail = new EnvioMailObject();
            string Mensaje = "";
            string ModificaGlosa = "";
            string NombreTarget = "";
            IList<clsSalesLeadObservaciones> ListaObservaciones;
            string DestinatariosCopia = "";

            //Valida Datos Obligatorios
            if (this.gridObservacionesSL.DataSource == null)
            {
                ctrldxError.SetError(this.gridObservacionesSL, "Debe Ingresar al menos una observación", ErrorType.Critical);
                return;
            }
            else
            {
                if (!ValidaObligatoriosGrilla(Mensaje))
                {
                    ctrldxError.SetError(this.gridObservacionesSL, Mensaje, ErrorType.Critical);
                    return;
                }
                else
                {
                    ctrldxError.SetError(this.gridObservacionesSL, "", ErrorType.None);
                }
            }
            if (objSalesLead == null)
            {
                ctrldxError.SetError(this.sButtonAgregarObservacion, "Debe seleccionar un Sales Lead antes de ingresar la observación", ErrorType.Critical);
                return;
            }
            else
            {
                ctrldxError.SetError(this.gridObservacionesSL, "", ErrorType.None);
            }
            Cursor.Current = Cursors.WaitCursor;
            ListaObservaciones = (IList<clsSalesLeadObservaciones>)this.gridObservacionesSL.DataSource;

            foreach (clsSalesLeadObservaciones Observacion in ListaObservaciones)
            {
                Entidades.GlobalObject.ResultadoTransaccion res =
                    ClsSalesLeadNegocio.GuardarObservacion(objSalesLead.Id, Observacion, ref ModificaGlosa);
                if (res.Estado == Enums.EstadoTransaccion.Aceptada && ModificaGlosa.ToUpper() == "S")
                {
                    Entidades.GlobalObject.ResultadoTransaccion res2 = mail.EnviarMailAvisoNewObservacionSalesLeadGerente(Base.Usuario.UsuarioConectado.Usuario,
                                                                                          objSalesLead.Asignacion.VendedorAsignado,
                                                                                          objSalesLead.UsuarioAsignador,
                                                                                          DestinatariosCopia,
                                                                                          Observacion.FechaHora,
                                                                                          Observacion.Observacion,
                                                                                          objSalesLead.Reference);
                    //Entidades.GlobalObject.ResultadoTransaccion res2 = Utils.EnvioEmail.EnviarMailAvisoNewObservacionSalesLeadGerente(Base.Usuario.UsuarioConectado.Usuario,
                    //                                                                   objSalesLead.Asignacion.VendedorAsignado,
                    //                                                                   objSalesLead.UsuarioAsignador,
                    //                                                                   DestinatariosCopia,
                    //                                                                   Observacion.FechaHora,
                    //                                                                   Observacion.Observacion,
                    //                                                                   objSalesLead.Reference);
                }
            }
            Cursor.Current = Cursors.Default;            
        }

        private void gridViewSLeads_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {

            objSalesLead = (ClsSalesLead)gridViewSLeads.GetRow(e.FocusedRowHandle);
            CargarGrillaObservaciones(objSalesLead.Id);
            return;
        }

        private void gridViewSLeads_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            int Diferencia = 0;

            if (e.RowHandle >= 0)
            {
                //DateTime FechaActualizacion = (DateTime)View.GetRowCellValue(e.RowHandle, gridColFActualizacion);
                //DateTime FechaHoy = (DateTime)View.GetRowCellValue(e.RowHandle, gridColFHoy);
                //Diferencia = DateTime.Compare(FechaHoy.Date, FechaActualizacion);
            }

        }

        private void frmGestionarSLead_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }

        private void MenuCancelar_Click(object sender, EventArgs e)
        {
            int IdEstadoActual;
            ClsSalesLead ObjPaso;
            int fila_sel = 0;

            //Valida Datos Obligatorios
            if (objSalesLead == null)
            {
                MessageBox.Show("Debe seleccionar un Sales Lead antes de Cancelarlo", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                IdEstadoActual = Convert.ToInt16(objSalesLead.EstadoSLead);
                if (IdEstadoActual == Convert.ToInt16(Enums.EstadosSLead.Cierre) || IdEstadoActual == Convert.ToInt16(Enums.EstadosSLead.Cancelada))
                {
                    MessageBox.Show("No es posible Cancelar este Sales Lead (revise el estado actual)", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (this.gridViewSLeads.SelectedRowsCount == 1)
            {
                //Advertencia
                if (MessageBox.Show("¿Desea Cancelar el Sales Lead Seleccionado?", "Sistema Comercial Craft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    fila_sel = gridViewSLeads.GetSelectedRows()[0];
                    ObjPaso = (ClsSalesLead)gridViewSLeads.GetRow(fila_sel);
                    Ventas.Metas.frmCancelarSalesLead.ObjSalesLead = ObjPaso;
                    Ventas.Metas.frmCancelarSalesLead form = Ventas.Metas.frmCancelarSalesLead.Instancia;
                    form.ShowDialog(this);
                }
            }
        }

        private void MenuEnviarMail_Click(object sender, EventArgs e)
        {
            var mail = new EnvioMailObject();
            if (gridViewSLeads.GetSelectedRows().Length == 0) {
                MessageBox.Show("debe seleccionar una o varias filas de la grilla");
                return;
            }

            if (gridViewSLeads.GetSelectedRows().Length > 5) {
                MessageBox.Show("No se pueden enviar mas de 5 Emails simultaneos");
                return;
            }

            foreach (var selectedRow in gridViewSLeads.GetSelectedRows()) {
                var sLeads = (ClsSalesLead)gridViewSLeads.GetRow(selectedRow);
                mail.EnviarMaiSalesLead(sLeads);
                //EnvioEmail.EnviarMaiSalesLead(sLeads);
            }            
        }

        private void MenuFollowUp_Click(object sender, EventArgs e) {
            if (this.gridViewSLeads.SelectedRowsCount == 1) {

                var sLead = (ClsSalesLead)gridViewSLeads.GetRow(gridViewSLeads.GetSelectedRows()[0]);
                var form = Clientes.frmSLeadFollowUP.Instancia;
                form.SalesLead = sLead;
                form.ShowDialog();
            }
        }

        private void MenuFichaSLead_Click(object sender, EventArgs e) {
            if (gridViewSLeads.GetSelectedRows().Length == 0) {
                MessageBox.Show("Debe seleccionar una fila de la grilla");
                return;
            }

            if (gridViewSLeads.GetSelectedRows().Length > 1) {
                MessageBox.Show("Debe seleccionar solo una fila de la grilla");
                return;
            }
            var form = frmEditarSLead.Instancia;
            foreach (var selectedRow in gridViewSLeads.GetSelectedRows()) {
                form.objSalesLead = (ClsSalesLead)gridViewSLeads.GetRow(selectedRow);
                form.ShowDialog(this);
            }            
        }

    }
}
