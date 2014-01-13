using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using ProyectoCraft.Entidades.Usuarios;
using DevExpress.XtraEditors.DXErrorProvider;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Base.Log;
using ProyectoCraft.LogicaNegocios.Direccion.Metas;
using ProyectoCraft.Entidades.Direccion.Metas;
using System.IO;
using System.Reflection;
using ProyectoCraft.WinForm.Direccion.Metas;
using ProyectoCraft.WinForm.Utils;
using SCCMultimodal.Utils;

namespace ProyectoCraft.WinForm.Ventas.Metas
{
    public partial class frmRevisarAsigSalesLead : Form
    {
        long IdUsuario;
        Assembly _assembly;
        Stream ImageStream;
        ClsSalesLead objSalesLead;

        public frmRevisarAsigSalesLead()
        {
            InitializeComponent();
        }

        private static frmRevisarAsigSalesLead _form = null;

        public static frmRevisarAsigSalesLead Instancia
        {
            get
            {
                if (_form == null)
                    _form = new frmRevisarAsigSalesLead();

                return _form;
            }
            set
            {
                _form = value;
            }
        }

        private void CargarGrillaObservaciones(long IdSalesLead)
        {
            Entidades.GlobalObject.ResultadoTransaccion res =
                LogicaNegocios.Direccion.Metas.ClsSalesLeadNegocio.ListarObservacionesSalesLead(IdSalesLead);

            IList<clsSalesLeadObservaciones> ListaObservaciones = (IList<clsSalesLeadObservaciones>)res.ObjetoTransaccion;

            this.gridObservacionesSL.DataSource = null;
            this.gridObservacionesSL.DataSource = ListaObservaciones;
        }
        private string ObtenerDestinatarios(IList<clsMetaObservaciones> ListaObservaciones)
        {
            string Destinatarios = "";
            foreach (clsMetaObservaciones Observacion in ListaObservaciones)
            {
                if (Destinatarios == "")
                {
                    Destinatarios = Observacion.ObjUsuario.Email;
                }
                else
                {
                    if (Destinatarios.Contains(Observacion.ObjUsuario.Email) == false)
                    {
                        Destinatarios = Destinatarios + ";" + Observacion.ObjUsuario.Email;
                    }
                }
            }
            return Destinatarios;
        }
        private void CargarGraficos(string Estados,long IdUsuario, DateTime FechaDesde, DateTime FechaHasta)
        {
            //DataTable res = LogicaNegocios.Direccion.Metas.ClsSalesLeadNegocio.GraficaEstadoAgente(Estados, IdUsuario, FechaDesde, FechaHasta);

            DataTable res = LogicaNegocios.Direccion.Metas.ClsSalesLeadNegocio.GraficaEstadoAgente(Estados, 0, FechaDesde, FechaHasta);

            this.ChartProspectos.Series.Clear();
            this.ChartProspectos.SeriesDataMember = "Estado";
            this.ChartProspectos.SeriesTemplate.ArgumentDataMember = "Agente";
            this.ChartProspectos.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Value" });
            ChartProspectos.DataSource = (DataTable)res;

        }
        private bool ValidaObligatoriosGrilla(string Mensaje)
        {
            IList<clsMetaObservaciones> ListaObservaciones = new List<clsMetaObservaciones>();

            //ListaObservaciones = (IList<clsMetaObservaciones>)gridObservaciones.DataSource;
            Mensaje = "";

            foreach (clsMetaObservaciones Observacion in ListaObservaciones)
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
        private void CargarGrillaSLeads(long IdVendedor, string Estados)
        {

            var res = ClsSalesLeadNegocio.ListarSalesLeadUsuarioEstado(IdVendedor, Estados);

            var listaSLeads = (IList<ClsSalesLead>)res.ObjetoTransaccion;
            gridSLeads.DataSource = null;
            gridSLeads.DataSource = listaSLeads;
        }
        private void frmRevisarAsigMetas_Load(object sender, EventArgs e)
        {
            IdUsuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario.Id;
            this.ChartProspectos.Series.Clear();
            this.DateDesde.DateTime = System.DateTime.Now.AddMonths(-6);
            this.DateHasta.DateTime = System.DateTime.Now;
        }

        private void MenuNuevo_Click(object sender, EventArgs e)
        {
            DateTime FechaDesde;
            DateTime FechaHasta;
            long IdVendedor;
            string Estados;

            Cursor.Current = Cursors.WaitCursor;
            IdVendedor = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario.Id;
            Estados = "1,2,3,4,5";

            this.CargarGrillaSLeads(IdVendedor,Estados);

            FechaDesde = DateDesde.DateTime.Date;
            FechaHasta = DateHasta.DateTime.Date;

            CargarGraficos("1,2,3,4,5", IdVendedor, FechaDesde, FechaHasta);
            Cursor.Current = Cursors.Default;
            MenuFollowUp.Enabled = true;
        }

        private void gridMisMetas_Click(object sender, EventArgs e)
        {
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MenuDevolver_Click(object sender, EventArgs e)
        {
            long IdMeta;
            long IdVendedorAsignado;
            DateTime FechaAsignacion;
            int IdEstadoMeta;
            int IdEstadoActual;

            //Valida Datos Obligatorios
            if (objSalesLead == null)
            {
                MessageBox.Show("Debe seleccionar un Target antes de Devolverlo", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                IdEstadoActual = Convert.ToInt16(objSalesLead.EstadoSLead);
                if (IdEstadoActual != Convert.ToInt16(Enums.EstadosMetas.Propuesta))
                {
                    MessageBox.Show("No es posible Devolver este Target (revise el estado actual)", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            //Advertencia
            if (MessageBox.Show("¿Desea Devolver el Target Asignado?", "Sistema Comercial Craft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IdMeta = objSalesLead.Id;
                IdEstadoMeta = Convert.ToInt16(Enums.EstadosMetas.Revision);

                Entidades.GlobalObject.ResultadoTransaccion res =
                    LogicaNegocios.Direccion.Metas.clsMetaNegocio.CambiarEstado(objSalesLead.Id, IdEstadoMeta);
                if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                {
                    MessageBox.Show("El Target ha sido asignado a revisión", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al Devolver Target", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void MenuGenerarOportunidad_Click(object sender, EventArgs e)
        {
            int IdEstadoActual;
            ClsSalesLead ObjPaso;
            int fila_sel = 0;


            //Valida Datos Obligatorios
            if (objSalesLead == null)
            {
                MessageBox.Show("Debe seleccionar un Sales Lead antes de Cerrarlo", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                IdEstadoActual = Convert.ToInt16(objSalesLead.EstadoSLead);
                if (IdEstadoActual == Convert.ToInt16(Enums.EstadosSLead.Cancelada) || IdEstadoActual == Convert.ToInt16(Enums.EstadosSLead.Cierre) || IdEstadoActual == Convert.ToInt16(Enums.EstadosMetas.Cancelado) )
                {
                    MessageBox.Show("No es posible Cerrar este Sales Lead (revise el estado actual)", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (this.gridViewSLeads.SelectedRowsCount == 1)
            {
                //Advertencia
                if (MessageBox.Show("¿Desea Cerrar el Sales Lead Seleccionado?", "Sistema Comercial Craft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    fila_sel = gridViewSLeads.GetSelectedRows()[0];
                    ObjPaso = (ClsSalesLead)gridViewSLeads.GetRow(fila_sel);

                    Ventas.Metas.frmCerrarSLead.ObjSalesLead = ObjPaso;
                    Ventas.Metas.frmCerrarSLead form = Ventas.Metas.frmCerrarSLead.Instancia;
                    form.ShowDialog(this);
                }
            }
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
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
                    //                                                                objSalesLead.Asignacion.VendedorAsignado,
                    //                                                                objSalesLead.UsuarioAsignador,
                    //                                                                DestinatariosCopia,
                    //                                                                Observacion.FechaHora,
                    //                                                                Observacion.Observacion,
                    //                                                                objSalesLead.Reference);
                }

            }
            Cursor.Current = Cursors.Default;            
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
                    Entidades.GlobalObject.ResultadoTransaccion res = ClsSalesLeadNegocio.EliminarObservacionesSalesLead(ObjObservacion.Id);
                    
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

        private void MenuFichaTarget_Click(object sender, EventArgs e)
        {
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

        private void gridViewProspectos_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            int Diferencia = 0;
            string Prioridad = "0";

            if (e.RowHandle >= 0)
            {
                //DateTime FechaActualizacion = (DateTime)View.GetRowCellValue(e.RowHandle, gridColFechaActualizacion);
                //DateTime FechaHoy = (DateTime)View.GetRowCellValue(e.RowHandle, gridColFechaHoy);
                //Diferencia = DateTime.Compare(FechaHoy.Date, FechaActualizacion.Date);
                ////Actualizado en la semana
                //if (Diferencia >= 0 && Diferencia <= 7)
                //{
                //    e.Appearance.BackColor = Color.GreenYellow;
                //    e.Appearance.BackColor2 = Color.SeaShell;
                //}
                ////Actualizado hace dos Semana
                //if (Diferencia > 7 && Diferencia <= 14)
                //{
                //    e.Appearance.BackColor = Color.Yellow;
                //    e.Appearance.BackColor2 = Color.SeaShell;
                //}
                ////Actualizado hace mas de dos semanas
                //if (Diferencia > 14)
                //{
                //    e.Appearance.BackColor = Color.Salmon;
                //    e.Appearance.BackColor2 = Color.SeaShell;
                //}
                
            }
        }

        private void gridViewObs_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            int Diferencia = 0;

            if (e.RowHandle >= 0)
            {
                //DateTime FechaObservacion = (DateTime)View.GetRowCellValue(e.RowHandle, gridColFecha);
                DateTime FechaHoy = DateTime.Now.Date;

                //Diferencia = DateTime.Compare(FechaHoy, FechaObservacion.Date);
                //Actualizado hoy
                if (Diferencia == 0)
                {
                    e.Appearance.BackColor = Color.Yellow;
                    e.Appearance.BackColor2 = Color.SeaShell;
                }
            }
        }

        private void DateDesde_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void DateDesde_Leave(object sender, EventArgs e)
        {
            DateTime FechaDesde;
            DateTime FechaHasta;
            string Estados;
            long IdVendedor;

            Cursor.Current = Cursors.WaitCursor;

            IdVendedor = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario.Id;
            Estados = "1,2,3,4,5,6,7,8,9";
            FechaDesde = DateDesde.DateTime.Date;
            FechaHasta = DateHasta.DateTime.Date;
            CargarGraficos(Estados, IdUsuario, FechaDesde, FechaHasta);

            Cursor.Current = Cursors.Default;
        }

        private void DateHasta_Leave(object sender, EventArgs e)
        {

        }

        private void toolStripBarraLlamada_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void gridViewProspectos_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            int fila_sel = 0;

            if (this.gridViewSLeads.RowCount > 0)
            {
                fila_sel = gridViewSLeads.GetSelectedRows()[0];
                if (fila_sel >= 0)
                {
                    objSalesLead = (ClsSalesLead)gridViewSLeads.GetRow(fila_sel);
                    CargarGrillaObservaciones(objSalesLead.Id);
                }
            }

        }

        private void DateHasta_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void sBActualizar_Click(object sender, EventArgs e)
        {
            DateTime FechaDesde;
            DateTime FechaHasta;
            string Estados;
            long IdVendedor;

            Cursor.Current = Cursors.WaitCursor;

            IdVendedor = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario.Id;
            Estados = "1,2,3,4,5,6,7,8,9";
            FechaDesde = DateDesde.DateTime.Date;
            FechaHasta = DateHasta.DateTime.Date;
            CargarGraficos(Estados, IdUsuario, FechaDesde, FechaHasta);

            Cursor.Current = Cursors.Default;
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
                    this.gridSLeads.ExportToXls(fs, true);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);
                MessageBox.Show("Error al generar archivo Excel: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuFollowUp_Click(object sender, EventArgs e) {
            if (gridViewSLeads.SelectedRowsCount == 1)
            {

                var meta = (clsMeta)gridViewSLeads.GetRow(gridViewSLeads.GetSelectedRows()[0]);
                var form = Clientes.frmtargetFollowUP.Instancia;
                form.Meta = meta;
                form.ShowDialog();
            }
        }

        private void gridViewSLeads_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            objSalesLead = (ClsSalesLead)gridViewSLeads.GetRow(e.FocusedRowHandle);
            CargarGrillaObservaciones(objSalesLead.Id);
            return;
        }

        private void MenuEnviarSalesLead_Click(object sender, EventArgs e)
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

        private void MenuFollowUp_Click_1(object sender, EventArgs e) {
            if (this.gridViewSLeads.SelectedRowsCount == 1) {
                var sLead = (ClsSalesLead)gridViewSLeads.GetRow(gridViewSLeads.GetSelectedRows()[0]);
                var form = Clientes.frmSLeadFollowUP.Instancia;
                form.SalesLead = sLead;
                form.ShowDialog();
            }
        }

        private void frmRevisarAsigSalesLead_FormClosed(object sender, FormClosedEventArgs e) {
            Instancia = null;
        }
    }
}