using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.DXErrorProvider;
using ProyectoCraft.Entidades.Direccion.Metas;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.Base.Log;
using SCCMultimodal.Utils;


namespace ProyectoCraft.WinForm.Direccion.Metas
{
    public partial class frmGestionarMetas : Form
    {
        clsMeta ObjProspecto;
        long IdUsuario;
        public frmGestionarMetas()
        {
            InitializeComponent();
        }
        private static frmGestionarMetas _form = null;

        public static frmGestionarMetas Instancia
        {
            get
            {
                if (_form == null)
                    _form = new frmGestionarMetas();

                return _form;
            }
            set
            {
                _form = value;
            }
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
        private bool ValidaObligatoriosGrilla(string Mensaje)
        {
            IList<clsMetaObservaciones> ListaObservaciones = new List<clsMetaObservaciones>();

            ListaObservaciones = (IList<clsMetaObservaciones>)gridObservaciones.DataSource;
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
        private void CargarGrillaProspectos()
        {
            Entidades.GlobalObject.ResultadoTransaccion res =
                LogicaNegocios.Direccion.Metas.clsMetaNegocio.ListarProspectos();

            IList<clsMeta> ListaProspectos = (IList<clsMeta>)res.ObjetoTransaccion;

            this.gridProspectos.DataSource = null;
            this.gridProspectos.DataSource = ListaProspectos;
        }
        private void CargarGraficos(string Estados,long IdUsuario, DateTime FechaDesde, DateTime FechaHasta)
        {
            DataTable res =
                LogicaNegocios.Direccion.Metas.clsMetaNegocio.GraficaEstadoUsuario(Estados,IdUsuario,FechaDesde,FechaHasta);

             this.ChartProspectos.Series.Clear();
             this.ChartProspectos.SeriesDataMember = "Estado";
             this.ChartProspectos.SeriesTemplate.ArgumentDataMember = "Vendedor";
             this.ChartProspectos.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Value" });
             ChartProspectos.DataSource=(DataTable)res;
        }
        private void CargarGrillaObservaciones(long IdProspecto)
        {
            Entidades.GlobalObject.ResultadoTransaccion res =
                LogicaNegocios.Direccion.Metas.clsMetaNegocio.ListarObservacionesProspecto(IdProspecto);

            IList<clsMetaObservaciones> ListaObservaciones = (IList<clsMetaObservaciones>)res.ObjetoTransaccion;

            this.gridObservaciones.DataSource = null;
            this.gridObservaciones.DataSource = ListaObservaciones;
        }
        private void frmGestionarMetas_Load(object sender, EventArgs e)
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

            Cursor.Current = Cursors.WaitCursor;
            CargarGrillaProspectos();

            FechaDesde = DateDesde.DateTime.Date;
            FechaHasta = DateHasta.DateTime.Date;

            CargarGraficos("1,2,3,4,5,6,7,8,9", 0,FechaDesde,FechaHasta);
            Cursor.Current = Cursors.Default;
            MenuFollowUp.Enabled = true;
        }
        private void MenuFichaTarget_Click(object sender, EventArgs e)
        {
            Clientes.TargetAccount.frmTargetAccount form = Clientes.TargetAccount.frmTargetAccount.Instancia;
            form.IdTargetSource = ObjProspecto.Id;
            form.ShowDialog(this);
        }
        private void sButtonEliminarObservacion_Click(object sender, EventArgs e)
        {

        }
        private void sButtonAgregarObservacion_Click(object sender, EventArgs e)
        {
            IList<clsMetaObservaciones> ListaObservaciones = new List<clsMetaObservaciones>();

            if (this.gridObservaciones.DataSource != null)
            {
                ListaObservaciones = (IList<clsMetaObservaciones>)this.gridObservaciones.DataSource;
            }

            clsMetaObservaciones ObjObservacion = new clsMetaObservaciones();

            ObjObservacion.FechaHora = DateTime.Now;
            ObjObservacion.ObjUsuario = new clsUsuario();
            ObjObservacion.ObjUsuario = (clsUsuario)Base.Usuario.UsuarioConectado.Usuario;
            ObjObservacion.Observacion = "";
            ListaObservaciones.Add(ObjObservacion);

            this.gridObservaciones.DataSource = null;
            this.gridObservaciones.DataSource = ListaObservaciones;
        }

        private void sButtonEliminarObservacion_Click_1(object sender, EventArgs e)
        {
            clsMetaObservaciones ObjObservacion = new clsMetaObservaciones();
            int fila_sel = 0;
            if (this.gridViewObs.DataSource != null)
            {
                if (MessageBox.Show("¿Está seguro que desea ELIMINAR el comentario?", "Sistema Comercial Craft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    fila_sel = this.gridViewObs.GetSelectedRows()[0];
                    ObjObservacion = (clsMetaObservaciones)this.gridViewObs.GetRow(fila_sel);
                    Entidades.GlobalObject.ResultadoTransaccion res =
                        LogicaNegocios.Direccion.Metas.clsMetaNegocio.EliminarObservacionesProspecto(ObjObservacion.Id);
                    if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                    {
                        this.gridViewObs.DeleteSelectedRows();
                    }
                    else
                    {
                        MessageBox.Show(res.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void gridProspectos_Click(object sender, EventArgs e)
        {

        }

        private void sButtonGrabarObs_Click(object sender, EventArgs e)
        {
            var mail = new EnvioMailObject();
            string Mensaje="";
            string ModificaGlosa = "";
            string NombreTarget = "";
            IList<clsMetaObservaciones> ListaObservaciones;
            string DestinatariosCopia = "";

            //Valida Datos Obligatorios
            if (this.gridObservaciones.DataSource==null)
            {
                ctrldxError.SetError(this.gridObservaciones, "Debe Ingresar al menos una observación", ErrorType.Critical);
                return;
            }
            else
            {
                if (!ValidaObligatoriosGrilla(Mensaje))
                {
                    ctrldxError.SetError(this.gridObservaciones, Mensaje, ErrorType.Critical);
                    return;
                }
                else
                {
                    ctrldxError.SetError(this.gridObservaciones, "", ErrorType.None);
                }
            }
            if (ObjProspecto == null)
            {
                ctrldxError.SetError(this.sButtonAgregarObservacion, "Debe seleccionar un prospecto antes de ingresar la observación", ErrorType.Critical);
                return;
            }
            else
            {
                ctrldxError.SetError(this.gridObservaciones, "", ErrorType.None);
            }
            Cursor.Current = Cursors.WaitCursor;
            ListaObservaciones = (IList<clsMetaObservaciones>)this.gridObservaciones.DataSource;

            foreach (clsMetaObservaciones Observacion in ListaObservaciones)
            {
                Entidades.GlobalObject.ResultadoTransaccion res =
                    LogicaNegocios.Direccion.Metas.clsMetaNegocio.GuardarObservacion(ObjProspecto.Id, Observacion,ref ModificaGlosa);
                    if (res.Estado == Enums.EstadoTransaccion.Aceptada && ModificaGlosa.ToUpper() == "S")
                    {
                        if (ObjProspecto.GlosaClienteTarget != "")
                        {
                            NombreTarget = ObjProspecto.GlosaClienteTarget;
                        }
                        else
                        {
                            NombreTarget = ObjProspecto.ObjClienteMaster.NombreFantasia;
                        }
                        DestinatariosCopia = ObtenerDestinatarios(ListaObservaciones);
                        Entidades.GlobalObject.ResultadoTransaccion res2 =
                               mail.EnviarMailAvisoNewObservacionGerente(ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario,
                                                                                     ObjProspecto.ObjMetaAsignacion.ObjVendedorAsignado,
                                                                                     ObjProspecto.UsuarioAsignador,
                                                                                     DestinatariosCopia,
                                                                                     Observacion.FechaHora,
                                                                                     Observacion.Observacion,
                                                                                     NombreTarget);
                        //Entidades.GlobalObject.ResultadoTransaccion res2 = 
                        //        Utils.EnvioEmail.EnviarMailAvisoNewObservacionGerente(ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario, 
                        //                                                              ObjProspecto.ObjMetaAsignacion.ObjVendedorAsignado,
                        //                                                              ObjProspecto.UsuarioAsignador,
                        //                                                              DestinatariosCopia,
                        //                                                              Observacion.FechaHora, 
                        //                                                              Observacion.Observacion, 
                        //                                                              NombreTarget);
                    }

            }
            Cursor.Current = Cursors.Default;
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void frmGestionarMetas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }

        private void MenuReasignar_Click(object sender, EventArgs e)
        {
            clsMeta ObjPaso;
            int fila_sel = 0;

            if (this.gridViewProspectos.SelectedRowsCount == 1)
            {
                fila_sel = gridViewProspectos.GetSelectedRows()[0];
                ObjPaso = (clsMeta)gridViewProspectos.GetRow(fila_sel);
                Direccion.Metas.frmUsuarioProspecto.IdMeta = ObjPaso.Id;
                Direccion.Metas.frmUsuarioProspecto.NombreProspecto = ObjPaso.GlosaClienteTarget;
                Direccion.Metas.frmUsuarioProspecto.NombreVendedorActual = ObjPaso.ObjMetaAsignacion.ObjVendedorAsignado.NombreUsuario;
                Direccion.Metas.frmUsuarioProspecto.IdVendedorActual = ObjPaso.ObjMetaAsignacion.ObjVendedorAsignado.Id;
                Direccion.Metas.frmUsuarioProspecto form = Direccion.Metas.frmUsuarioProspecto.Instancia;
                form.ShowDialog(this);
            }
        }

        private void MenuAsignar_Click(object sender, EventArgs e)
        {
            long IdMeta;
            long IdVendedorAsignado;
            DateTime FechaAsignacion;
            int IdEstadoMeta;
            int IdEstadoActual;
            string NombreTarget = "";

            //Valida Datos Obligatorios
            if (ObjProspecto == null)
            {
                MessageBox.Show("Debe seleccionar un Target antes de Asignarlo","Sistema Comercial Craft",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            else
            {
                IdEstadoActual = Convert.ToInt16(ObjProspecto.EstadoMeta);
                if (IdEstadoActual != Convert.ToInt16(Enums.EstadosMetas.Revision) && IdEstadoActual != Convert.ToInt16(Enums.EstadosMetas.Propuesta))
                {
                    MessageBox.Show("No es posible Asignar este Target (revise el estado actual)", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            //Advertencia
            if (MessageBox.Show("¿Desea Asignar el Target seleccionado?", "Sistema Comercial Craft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IdMeta = ObjProspecto.Id;
                IdVendedorAsignado = ObjProspecto.ObjMetaAsignacion.ObjVendedorAsignado.Id;
                FechaAsignacion = DateTime.Now;
                IdEstadoMeta = Convert.ToInt16(Enums.EstadosMetas.Asignado);

                Entidades.GlobalObject.ResultadoTransaccion res =
                    LogicaNegocios.Direccion.Metas.clsMetaNegocio.AsignarProspecto(ObjProspecto.Id, IdEstadoMeta, IdVendedorAsignado, FechaAsignacion);
                if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                {
                    if (ObjProspecto.TipoOportunidad == "C")
                    {
                        NombreTarget = ObjProspecto.GlosaClienteTarget;
                    }
                    else
                    {
                        NombreTarget = ObjProspecto.ObjClienteMaster.NombreFantasia;
                    }
                    Entidades.GlobalObject.ResultadoTransaccion res2 =
                        LogicaNegocios.Clientes.clsTargetAccount.CreatTargetAccount(NombreTarget, ObjProspecto.Id);
                    if (res2.Estado == Enums.EstadoTransaccion.Aceptada)
                    {
                        MessageBox.Show("El Target ha sido asignado exitosamente", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al asignar Target", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void gridViewProspectos_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
        }

        private void gridViewProspectos_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            int Diferencia=0;

            if (e.RowHandle >= 0)
            {
                DateTime FechaActualizacion = (DateTime)View.GetRowCellValue(e.RowHandle, gridColFActualizacion);
                DateTime FechaHoy = (DateTime)View.GetRowCellValue(e.RowHandle, gridColFHoy);
                Diferencia = DateTime.Compare(FechaHoy.Date, FechaActualizacion); 
                ////Actualizado en la semana
                //if (Diferencia >= 0 && Diferencia <= 7)
                //{
                //    e.Appearance.BackColor = Color.GreenYellow;
                //    e.Appearance.BackColor2 = Color.SeaShell;
                //}
                ////Actualizado hace dos Semana
                //if (Diferencia>7 && Diferencia<=14)
                //{
                //    e.Appearance.BackColor = Color.Yellow;
                //    e.Appearance.BackColor2 = Color.SeaShell;
                //}
                ////Actualizado hace mas de dos semanas
                //if (Diferencia>14)
                //{
                //    e.Appearance.BackColor = Color.Salmon;
                //    e.Appearance.BackColor2 = Color.SeaShell;
                //}
            }
        }

        private void gridViewObs_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            int Diferencia = 0;

            if (e.RowHandle >= 0)
            {
                DateTime FechaObservacion = (DateTime)View.GetRowCellValue(e.RowHandle, gridFechaHora);
                DateTime FechaHoy = DateTime.Now.Date;

                Diferencia = DateTime.Compare(FechaHoy, FechaObservacion.Date);
                //Actualizado hoy
                if (Diferencia == 0)
                {
                    e.Appearance.BackColor = Color.Yellow;
                    e.Appearance.BackColor2 = Color.SeaShell;
                }
            }
        }

        private void MenuCancelar_Click(object sender, EventArgs e)
        {
            int IdEstadoActual;
            clsMeta ObjPaso;
            int fila_sel = 0;

            //Valida Datos Obligatorios
            if (ObjProspecto == null)
            {
                MessageBox.Show("Debe seleccionar un Target antes de Cancelarlo", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                IdEstadoActual = Convert.ToInt16(ObjProspecto.EstadoMeta);
                if (IdEstadoActual == Convert.ToInt16(Enums.EstadosMetas.Cierre) || IdEstadoActual == Convert.ToInt16(Enums.EstadosMetas.Cancelado))
                {
                    MessageBox.Show("No es posible Cancelar este Target (revise el estado actual)", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (this.gridViewProspectos.SelectedRowsCount == 1)
            {
                //Advertencia
                if (MessageBox.Show("¿Desea Cancelar el Target Seleccionado?", "Sistema Comercial Craft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    fila_sel = gridViewProspectos.GetSelectedRows()[0];
                    ObjPaso = (clsMeta)gridViewProspectos.GetRow(fila_sel);
                    Ventas.Metas.frmCancelarTarget.IdMeta = ObjPaso.Id;
                    Ventas.Metas.frmCancelarTarget.NombreProspecto = ObjPaso.GlosaClienteTarget;
                    Ventas.Metas.frmCancelarTarget.NombreVendedorAsignado = ObjPaso.ObjMetaAsignacion.ObjVendedorAsignado.NombreUsuario;
                    Ventas.Metas.frmCancelarTarget.IdVendedorActual = ObjPaso.ObjMetaAsignacion.ObjVendedorAsignado.Id;
                    Ventas.Metas.frmCancelarTarget.TipoTarget = ObjPaso.TipoOportunidad;
                    Ventas.Metas.frmCancelarTarget.ObjTarget = ObjPaso;
                    Ventas.Metas.frmCancelarTarget form = Ventas.Metas.frmCancelarTarget.Instancia;
                    form.ShowDialog(this);
                }
            }
        }

        private void gridProspectos_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void gridProspectos_Leave(object sender, EventArgs e)
        {

        }

        private void gridViewProspectos_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            int fila_sel = 0;

            if (gridViewProspectos.RowCount > 0)
            {
                fila_sel = gridViewProspectos.GetSelectedRows()[0];
                if (fila_sel >= 0)
                {
                    ObjProspecto = (clsMeta)gridViewProspectos.GetRow(fila_sel);
                    CargarGrillaObservaciones(ObjProspecto.Id);
                }
            }
        }

        private void DateHasta_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void DateDesde_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void sBActualizar_Click(object sender, EventArgs e)
        {
            DateTime FechaDesde;
            DateTime FechaHasta;

            Cursor.Current = Cursors.WaitCursor;

            FechaDesde = DateDesde.DateTime.Date;
            FechaHasta = DateHasta.DateTime.Date;

            CargarGraficos("1,2,3,4,5,6,7,8,9", 0, FechaDesde, FechaHasta);
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
                    this.gridProspectos.ExportToXls(fs, true);

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
            if (this.gridViewProspectos.SelectedRowsCount == 1) {
                
                var meta  = (clsMeta)gridViewProspectos.GetRow(gridViewProspectos.GetSelectedRows()[0]);
                var form = Clientes.frmtargetFollowUP.Instancia;
                form.Meta = meta;
                form.ShowDialog();
            }
        }
    }
}
