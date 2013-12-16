using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using ProyectoCraft.Entidades.Clientes.TargetAccount;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Usuarios;
using DevExpress.XtraEditors.DXErrorProvider;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Direccion.Metas;
using ProyectoCraft.LogicaNegocios.Parametros;
using ProyectoCraft.Entidades.Ventas.Productos;
using System.IO;
using System.Reflection;
using SCCMultimodal.Utils;

namespace ProyectoCraft.WinForm.Ventas.Metas
{
    public partial class frmRevisarAsigMetas : Form
    {
        clsMeta ObjProspecto;
        long IdUsuario;
        Assembly _assembly;
        Stream ImageStream;

        public frmRevisarAsigMetas()
        {
            InitializeComponent();
        }

        private static frmRevisarAsigMetas _form = null;

        public static frmRevisarAsigMetas Instancia
        {
            get
            {
                if (_form == null)
                    _form = new frmRevisarAsigMetas();

                return _form;
            }
            set
            {
                _form = value;
            }
        }

        private clsTargetAccount _targetaccount = null;
        private clsTargetAccount TargetAccount
        {
            get { return _targetaccount; }
            set { _targetaccount = value; }

        }

        private void CargarGrillaObservaciones(long IdProspecto)
        {
            Entidades.GlobalObject.ResultadoTransaccion res =
                LogicaNegocios.Direccion.Metas.clsMetaNegocio.ListarObservacionesProspecto(IdProspecto);

            IList<clsMetaObservaciones> ListaObservaciones = (IList<clsMetaObservaciones>)res.ObjetoTransaccion;

            this.gridObservaciones.DataSource = null;
            this.gridObservaciones.DataSource = ListaObservaciones;
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
        private void CargarGraficos(string Estados, long IdUsuario, DateTime FechaDesde, DateTime FechaHasta)
        {
            DataTable res =
                LogicaNegocios.Direccion.Metas.clsMetaNegocio.GraficaEstadoUsuario(Estados, IdUsuario, FechaDesde, FechaHasta);

            this.ChartProspectos.Series.Clear();
            this.ChartProspectos.SeriesDataMember = "Estado";
            this.ChartProspectos.SeriesTemplate.ArgumentDataMember = "Vendedor";
            this.ChartProspectos.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Value" });
            ChartProspectos.DataSource = (DataTable)res;

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
        private void CargarGrillaProspectos(long IdVendedor, string Estados)
        {
            Entidades.GlobalObject.ResultadoTransaccion res =
                LogicaNegocios.Direccion.Metas.clsMetaNegocio.ListarProspectosUsuarioEstado(IdVendedor, Estados);

            IList<clsMeta> ListaProspectos = (IList<clsMeta>)res.ObjetoTransaccion;

            this.gridMisProspectos.DataSource = null;
            this.gridMisProspectos.DataSource = ListaProspectos;
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
            string Estados;
            long IdVendedor;

            DateTime FechaDesde;
            DateTime FechaHasta;

            IdVendedor = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario.Id;
            Estados = "1,2,3,4,5,6,7,8,9";

            Cursor.Current = Cursors.WaitCursor;
            CargarGrillaProspectos(IdVendedor, Estados);
            FechaDesde = DateDesde.DateTime.Date;
            FechaHasta = DateHasta.DateTime.Date;
            CargarGraficos(Estados, IdUsuario, FechaDesde, FechaHasta);
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
            if (ObjProspecto == null)
            {
                MessageBox.Show("Debe seleccionar un Target antes de Devolverlo", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                IdEstadoActual = Convert.ToInt16(ObjProspecto.EstadoMeta);
                if (IdEstadoActual != Convert.ToInt16(Enums.EstadosMetas.Propuesta))
                {
                    MessageBox.Show("No es posible Devolver este Target (revise el estado actual)", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            //Advertencia
            if (MessageBox.Show("¿Desea Devolver el Target Asignado?", "Sistema Comercial Craft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IdMeta = ObjProspecto.Id;
                IdEstadoMeta = Convert.ToInt16(Enums.EstadosMetas.Revision);

                Entidades.GlobalObject.ResultadoTransaccion res =
                    LogicaNegocios.Direccion.Metas.clsMetaNegocio.CambiarEstado(ObjProspecto.Id, IdEstadoMeta);
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
        private void MenuAceptar_Click(object sender, EventArgs e)
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
                MessageBox.Show("Debe seleccionar un Target antes de Aceptarlo", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                IdEstadoActual = Convert.ToInt16(ObjProspecto.EstadoMeta);
                if (IdEstadoActual != Convert.ToInt16(Enums.EstadosMetas.Revision) && IdEstadoActual != Convert.ToInt16(Enums.EstadosMetas.Propuesta))
                {
                    MessageBox.Show("No es posible Aceptar este Target (revise el estado actual)", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            //Advertencia
            if (MessageBox.Show("¿Desea Aceptar el Target Asignado?", "Sistema Comercial Craft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IdMeta = ObjProspecto.Id;
                IdEstadoMeta = Convert.ToInt16(Enums.EstadosMetas.Asignado);

                Entidades.GlobalObject.ResultadoTransaccion res =
                    LogicaNegocios.Direccion.Metas.clsMetaNegocio.CambiarEstado(ObjProspecto.Id, IdEstadoMeta);
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
                        MessageBox.Show("El Target ha sido Aceptado", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al Aceptar Target", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void MenuGenerarOportunidad_Click(object sender, EventArgs e)
        {
            long IdMeta;
            long IdVendedorAsignado;
            DateTime FechaAsignacion;
            int IdEstadoMeta;
            int IdEstadoActual;
            clsMeta ObjPaso;
            int fila_sel = 0;


            //Valida Datos Obligatorios
            if (ObjProspecto == null)
            {
                MessageBox.Show("Debe seleccionar un Target antes de Cerrarlo", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                IdEstadoActual = Convert.ToInt16(ObjProspecto.EstadoMeta);
                if (IdEstadoActual == Convert.ToInt16(Enums.EstadosMetas.Propuesta) || IdEstadoActual == Convert.ToInt16(Enums.EstadosMetas.Revision) || IdEstadoActual == Convert.ToInt16(Enums.EstadosMetas.Cancelado) || IdEstadoActual == Convert.ToInt16(Enums.EstadosMetas.Cierre))
                {
                    MessageBox.Show("No es posible Cerrar este Target (revise el estado actual)", "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (this.gridViewProspectos.SelectedRowsCount == 1)
            {
                //Advertencia
                if (MessageBox.Show("¿Desea Cerrar el Target Seleccionado?", "Sistema Comercial Craft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    fila_sel = gridViewProspectos.GetSelectedRows()[0];
                    ObjPaso = (clsMeta)gridViewProspectos.GetRow(fila_sel);
                    Ventas.Metas.frmCerrarTarget.IdMeta = ObjPaso.Id;
                    Ventas.Metas.frmCerrarTarget.NombreProspecto = ObjPaso.GlosaClienteTarget;
                    Ventas.Metas.frmCerrarTarget.NombreVendedorAsignado = ObjPaso.ObjMetaAsignacion.ObjVendedorAsignado.NombreUsuario;
                    Ventas.Metas.frmCerrarTarget.IdVendedorActual = ObjPaso.ObjMetaAsignacion.ObjVendedorAsignado.Id;
                    Ventas.Metas.frmCerrarTarget.TipoTarget = ObjPaso.TipoOportunidad;
                    Ventas.Metas.frmCerrarTarget.ObjTarget = ObjPaso;
                    Ventas.Metas.frmCerrarTarget form = Ventas.Metas.frmCerrarTarget.Instancia;
                    form.ShowDialog(this);
                }
            }
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }
        private void BuscarTargetAccount()
        {
            ResultadoTransaccion resultado = new ResultadoTransaccion();

            resultado = LogicaNegocios.Clientes.clsTargetAccount.ObtenerTargetAccountPorIdSource(ObjProspecto.Id);
            if (resultado.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                TargetAccount = new clsTargetAccount();
                TargetAccount = (clsTargetAccount)resultado.ObjetoTransaccion;

                if (TargetAccount == null)
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show(resultado.Descripcion, "Target Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void sButtonGrabarObs_Click(object sender, EventArgs e)
        {
            BuscarTargetAccount();
            var mail = new EnvioMailObject();
            string Mensaje = "";
            string ModificaGlosa = "";
            string NombreTarget = "";
            string emailInformeLcl = "";
            string emailInformeFcl = "";
            string emailInformeAereo = "";
            string emailInformeFijo = "";
            
            IList<clsMetaObservaciones> ListaObservaciones;

            //Valida Datos Obligatorios
            if (this.gridObservaciones.DataSource == null)
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
                    LogicaNegocios.Direccion.Metas.clsMetaNegocio.GuardarObservacion(ObjProspecto.Id, Observacion, ref ModificaGlosa);
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
                    string Destinatarios = ObtenerDestinatarios(ListaObservaciones);

                    emailInformeFijo = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailInformeFijo");
                    

                    if (!string.IsNullOrEmpty(emailInformeFijo) && !Destinatarios.Contains(emailInformeFijo))
                        Destinatarios = Destinatarios + ";" + emailInformeFijo;
                    

                    if (TargetAccount != null && TargetAccount.ClienteMaster != null && TargetAccount.ClienteMaster.ProductosPreferidos != null)
                        foreach (var proPref in TargetAccount.ClienteMaster.ProductosPreferidos)
                        {
                            emailInformeLcl = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailInformeLCL");
                            emailInformeFcl = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailInformeFCL");
                            emailInformeAereo = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailInformeAereo");

                            if (proPref.Producto.EsAereo)
                            {
                                if (!Destinatarios.Contains(emailInformeAereo))
                                    Destinatarios = Destinatarios + ";" + emailInformeAereo;
                            }
                            if (proPref.Producto.EsFCL)
                            {
                                if (!Destinatarios.Contains(emailInformeFcl))
                                    Destinatarios = Destinatarios + ";" + emailInformeFcl;
                            }
                            if (proPref.Producto.EsLCL)
                            {
                                if (!Destinatarios.Contains(emailInformeLcl))
                                    Destinatarios = Destinatarios + ";" + emailInformeLcl;
                            }
                        }
                    Entidades.GlobalObject.ResultadoTransaccion res2 =
                            mail.EnviarMailAvisoNewObservacionVendedor(ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario,
                                                                                    ObjProspecto.UsuarioAsignador,
                                                                                    Observacion.FechaHora,
                                                                                    Observacion.Observacion,
                                                                                    NombreTarget,
                                                                                    Destinatarios);
                    //Entidades.GlobalObject.ResultadoTransaccion res2 = 
                    //        Utils.EnvioEmail.EnviarMailAvisoNewObservacionVendedor(ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario, 
                    //                                                                ObjProspecto.UsuarioAsignador,
                    //                                                                Observacion.FechaHora,  
                    //                                                                Observacion.Observacion, 
                    //                                                                NombreTarget,
                    //                                                                Destinatarios);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void sButtonEliminarObservacion_Click(object sender, EventArgs e)
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

        private void MenuFichaTarget_Click(object sender, EventArgs e)
        {
            Clientes.TargetAccount.frmTargetAccount form = Clientes.TargetAccount.frmTargetAccount.Instancia;
            form.IdTargetSource = ObjProspecto.Id;
            form.ShowDialog(this);
        }

        private void gridViewProspectos_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            int Diferencia = 0;
            string Prioridad = "0";

            if (e.RowHandle >= 0)
            {
                DateTime FechaActualizacion = (DateTime)View.GetRowCellValue(e.RowHandle, gridColFechaActualizacion);
                DateTime FechaHoy = (DateTime)View.GetRowCellValue(e.RowHandle, gridColFechaHoy);
                Diferencia = DateTime.Compare(FechaHoy.Date, FechaActualizacion.Date);
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
                DateTime FechaObservacion = (DateTime)View.GetRowCellValue(e.RowHandle, gridColFecha);
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

        private void sBActualizar_Click(object sender, EventArgs e)
        {
            DateTime FechaDesde;
            DateTime FechaHasta;
            string Estados;
            long IdVendedor;

            Cursor.Current = Cursors.WaitCursor;

            IdVendedor = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario.Id;
            Estados = "1,2,3,4,5,6,7,8,9";

            Cursor.Current = Cursors.WaitCursor;
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
                    this.gridMisProspectos.ExportToXls(fs, true);

                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);
                MessageBox.Show("Error al generar archivo Excel: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuFollowUp_Click(object sender, EventArgs e)
        {
            if (gridViewProspectos.SelectedRowsCount == 1)
            {

                var meta = (clsMeta)gridViewProspectos.GetRow(gridViewProspectos.GetSelectedRows()[0]);
                var form = Clientes.frmtargetFollowUP.Instancia;
                form.Meta = meta;
                form.ShowDialog();
            }
        }

        private void gridViewProspectos_ColumnFilterChanged(object sender, EventArgs e)
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

        private void frmRevisarAsigMetas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }
    }
}
