using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Paperless;
using SCCMultimodal.Paperless.Usuario2;
using SCCMultimodal.Utils;
using log4net;

namespace ProyectoCraft.WinForm.Paperless.Usuario2
{

    public partial class frmPaperlessUser2 : Form, IFrmPaperlessUser2
    {
        private static readonly ILog Log = LogManager.GetLogger("Paperless");
        public frmPaperlessUser2()
        {
            InitializeComponent();
        }

        private static frmPaperlessUser2 _instancia;
        public static frmPaperlessUser2 Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmPaperlessUser2();

                return _instancia;
            }
            set { _instancia = value; }
        }

        private PaperlessAsignacion _asignacion;
        public PaperlessAsignacion PaperlessAsignacionActual
        {
            get
            {
                if (_asignacion == null)
                    _asignacion = new PaperlessAsignacion();

                return _asignacion;
            }
            set { _asignacion = value; }
        }

        private Enums.TipoAccionFormulario _accion;
        public Enums.TipoAccionFormulario Accion
        {
            get { return _accion; }
            set { _accion = value; }
        }

        private void frmPaperlessUser2_Load(object sender, EventArgs e)
        {
            //ProyectoCraft.WinForm.Controles.EstadoPaperless control = new EstadoPaperless();
            //panel1.Controls.Add(control);

            gridView2.CustomRowCellEditForEditing += new CustomRowCellEditEventHandler(MarcarPaso);

            if (Accion == Enums.TipoAccionFormulario.Consultar)
                RepositoryCheckPasos.CheckStateChanged += RecargarPasos;
            else
                RepositoryCheckPasos.CheckStateChanged += MarcarCambioEstadoPaso;

            CargarPasos();
            CargarPaso1Excepciones();
            CargarP2ContactarEmbarcadores();
            CargarP3AperturaEmbarcadores();

            ValidarAccion();

            //Control Tiempo
            //control.AsignacionActual = PaperlessAsignacionActual;
            //control.ObtenerTiemposProcesoUsuario2();


            ////control.ObtenerTiempoEstimadoProcesoUsuario2();
            ////control.ConfigurarIniciarTiempo(true);

        }

        private void ValidarAccion()
        {
            if (Accion == Enums.TipoAccionFormulario.Consultar)
            {
                btnP1GuardarExcepciones.Visible = false;
                btnP2ContactarEmbarcador.Visible = false;
                btnP3GuardarAperturaEmbarcadores.Visible = false;
            }
        }

        private void CargarP2ContactarEmbarcadores()
        {
            IList<PaperlessUsuario1HousesBL> houses =
                LogicaNegocios.Paperless.Paperless.Usuario1ObtenerHousesBL(PaperlessAsignacionActual.Id);

            houses = LogicaNegocios.Paperless.Paperless.ObtenerEmbarcadores(houses);

            grdContactarembarcador.DataSource = houses;

            //houses[0].EmbarcadorContactado
        }

        private void CargarP3AperturaEmbarcadores()
        {
            IList<PaperlessUsuario1HousesBL> houses = LogicaNegocios.Paperless.Paperless.Usuario1ObtenerHousesBL(PaperlessAsignacionActual.Id);
            foreach (var paperlessUsuario1HousesBl in houses)
            {
                ResultadoTransaccion res = LogicaNegocios.Clientes.clsCuentas.BuscarCuentaPorId(paperlessUsuario1HousesBl.Cliente.Id);
                paperlessUsuario1HousesBl.Cliente.Cuenta = (Entidades.Clientes.Cuenta.clsCuenta)res.ObjetoTransaccion;
                if (paperlessUsuario1HousesBl.TipoReciboAperturaEmbarcador.Equals(Enums.PaperlessTipoReciboAperturaEmbarcador.NoDefinido))
                    if (paperlessUsuario1HousesBl.Cliente.Cuenta != null)
                        paperlessUsuario1HousesBl.TipoReciboAperturaEmbarcador = paperlessUsuario1HousesBl.Cliente.Cuenta.TipoReciboAperturaEmbarcador;
            }

            houses = LogicaNegocios.Paperless.Paperless.ObtenerEmbarcadores(houses);

            grdRecibirAperturaEmb.DataSource = houses;

        }

        private PaperlessPasosEstado ObtenerPasoSeleccionado()
        {
            var filaSelected = grdPasos.DefaultView.GetRow(gridView2.FocusedRowHandle);

            if (filaSelected == null)
            {
                return null;
            }

            PaperlessPasosEstado housesbl = (PaperlessPasosEstado)filaSelected;

            return housesbl;
        }

        protected void RecargarPasos(object sender, EventArgs e)
        {
            PaperlessPasosEstado paso = ObtenerPasoSeleccionado();
            if (paso.Paso.NumPaso == 4)
            {
                if (PaperlessAsignacionActual.Estado == Enums.EstadoPaperless.ProcesoTerminado)
                {
                    pnlReenviarCorreo.Visible = true;
                    btnReenviarCorreoTermino.Visible = true;
                }

            }

            CargarPasos();
        }

        protected void MarcarCambioEstadoPaso(object sender, EventArgs e)
        {
            var mail = new EnvioMailObject();
            DevExpress.XtraEditors.CheckEdit check = sender as DevExpress.XtraEditors.CheckEdit;
            if (check == null) return;

            PaperlessPasosEstado paso = ObtenerPasoSeleccionado();

            if (paso.Paso.NumPaso == 1 || paso.Paso.NumPaso == 2 || paso.Paso.NumPaso == 3)
            {
                paso.Estado = false;
                CargarPasos();
                return;
            }

            if (!ValidarPermiteCambiarPasoEstado(paso))
            {
                paso.Estado = false;
                CargarPasos();
                return;
            }

            if (paso.Estado)
            {
                CargarPasos();
                return;
            }


            paso.Estado = check.Checked;

            if (paso != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                PaperlessAsignacionActual.Estado = Enums.EstadoPaperless.ProcesoTerminado;

                PaperlessProcesoRegistroTiempo termino = new PaperlessProcesoRegistroTiempo();
                termino.IdAsignacion = PaperlessAsignacionActual.Id;
                termino.TerminoUsuario2 = DateTime.Now;

                Entidades.GlobalObject.ResultadoTransaccion resultado =
                    LogicaNegocios.Paperless.Paperless.Usuario2TerminaProceso(PaperlessAsignacionActual, paso, termino);
                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Error al cambiar estado del paso. \n" + resultado.Descripcion, "Paperless",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    PaperlessUsuario1HouseBLInfo info =
                        LogicaNegocios.Paperless.Paperless.Usuario1ObtenerHousesBLInfo(PaperlessAsignacionActual.Id);
                    resultado = mail.EnviarMailPaperlessUsuario2TerminaProceso(PaperlessAsignacionActual, info);
                    //resultado = Utils.EnvioEmail.EnviarMailPaperlessUsuario2TerminaProceso(PaperlessAsignacionActual,info);

                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Error al enviar email de termino de proceso. \n" + resultado.Descripcion, "Paperless",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        frmListarUsuario2 form = frmListarUsuario2.Instancia;
                        form.ObtenerAsignaciones();

                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Proceso ha sido finalizado con exito", "Paperless", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                        this.Close();
                    }
                    Cursor.Current = Cursors.Default;
                    //CargarPasos();
                }
            }
        }

        private bool ValidarPermiteCambiarPasoEstado(PaperlessPasosEstado pasoactual)
        {
            IList<PaperlessPasosEstado> pasos = (IList<PaperlessPasosEstado>)grdPasos.DataSource;

            foreach (var paso in pasos)
            {
                if (paso.IdPasoEstado < pasoactual.IdPasoEstado && !paso.Estado)
                {
                    MessageBox.Show("Hay pasos previos pendientes de realizar. Debe marcarlos como realizados para continuar", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        public Entidades.GlobalObject.ResultadoTransaccion PrepararPasos()
        {
            PaperlessAsignacionActual.Estado = Enums.EstadoPaperless.EnProcesoUsuario2;

            Entidades.GlobalObject.ResultadoTransaccion resultado =
                LogicaNegocios.Paperless.Paperless.PreparaPasosUsuario2(PaperlessAsignacionActual);

            if (resultado.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                //PaperlessAsignacionActual.Estado = Enums.EstadoPaperless.EnProcesoUsuario2;
                //resultado = LogicaNegocios.Paperless.Paperless.CambiaEstadoAsignacion(PaperlessAsignacionActual);
            }
            else
            {
                MessageBox.Show("Error al preparar los pasos de usuario 2. \n" + resultado.Descripcion, "Paperless",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return resultado;
        }

        private void CargarPasos()
        {
            try
            {
                IList<PaperlessPasosEstado> pasos =
                LogicaNegocios.Paperless.Paperless.ListarPasosEstadoUsuario2(PaperlessAsignacionActual.Id);

                grdPasos.DataSource = pasos;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        private void CargarPaso1Excepciones()
        {
            IList<PaperlessExcepcion> excepciones =
                LogicaNegocios.Paperless.Paperless.Usuario1ObtenerExcepciones(PaperlessAsignacionActual.Id);


            PaperlessAsignacionActual.DataUsuario1.Excepciones = excepciones;

            grdExcepciones.DataSource = PaperlessAsignacionActual.DataUsuario1.Excepciones;
            grdExcepciones.RefreshDataSource();

        }

        //private void RecibirAperturaEmbarcador()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add(new DataColumn("Embarcador"));
        //    dt.Columns.Add(new DataColumn("Recibido"));

        //    DataRow dr = dt.NewRow();
        //    dr["Embarcador"] = "Embarcador A";
        //    dr["Recibido"] = "true";
        //    dt.Rows.Add(dr);

        //    dr = dt.NewRow();
        //    dr["Embarcador"] = "Embarcador B";
        //    dr["Recibido"] = "false";
        //    dt.Rows.Add(dr);

        //    grdRecibirAperturaEmb.DataSource = dt;
        //}

        private void Contactarembarcador()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Embarcador"));
            dt.Columns.Add(new DataColumn("Contactado"));

            DataRow dr = dt.NewRow();
            dr["Embarcador"] = "Embarcador A";
            dr["Contactado"] = "true";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Embarcador"] = "Embarcador B";
            dr["Contactado"] = "false";
            dt.Rows.Add(dr);

            grdContactarembarcador.DataSource = dt;
        }

        private void RegistrarExcepciones()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("HBL"));
            dt.Columns.Add(new DataColumn("Cliente"));
            dt.Columns.Add(new DataColumn("TipoCliente"));
            dt.Columns.Add(new DataColumn("Freehand"));
            dt.Columns.Add(new DataColumn("RecargoCollect"));
            dt.Columns.Add(new DataColumn("Sobrevalor"));
            dt.Columns.Add(new DataColumn("Aviso"));

            DataRow dr = dt.NewRow();
            dr["HBL"] = "11111";
            dr["Cliente"] = "Cliente A";
            dr["TipoCliente"] = "Embarcador";
            dr["Freehand"] = "false";
            dr["RecargoCollect"] = "false";
            dr["Sobrevalor"] = "false";
            dr["Aviso"] = "false";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["HBL"] = "2222";
            dr["Cliente"] = "Cliente B";
            dr["TipoCliente"] = "Directo";
            dr["Freehand"] = "false";
            dr["RecargoCollect"] = "false";
            dr["Sobrevalor"] = "false";
            dr["Aviso"] = "false";
            dt.Rows.Add(dr);



            grdExcepciones.DataSource = dt;
        }

        protected void MarcarPaso(object sender, CustomRowCellEditEventArgs e)
        {
            pnlExcepciones.Visible = false;
            pnlContactarembarcador.Visible = false;
            pnlRecibirAperturaEmb.Visible = false;
            pnlReenviarCorreo.Visible = false;
            //pnlEnviarAviso.Visible = false;

            //if(e.Column.FieldName == "Estado")
            //{
            if (e.RowHandle == 0)
            {
                pnlExcepciones.Visible = true;
            }
            if (e.RowHandle == 1)
            {
                pnlContactarembarcador.Visible = true;
            }
            if (e.RowHandle == 2)
            {
                pnlRecibirAperturaEmb.Visible = true;
            }
            if (e.RowHandle == 11)
            {
                //pnlEnviarAviso.Visible = true;
            }

            //}


        }

        private PaperlessPasosEstado ObtenerPasoSelccionadoDesdeGrilla(int numpaso)
        {
            IList<PaperlessPasosEstado> pasos = (IList<PaperlessPasosEstado>)grdPasos.DataSource;

            return pasos[numpaso - 1];

        }

        private void btnP1GuardarExcepciones_Click(object sender, EventArgs e)
        {
            long IdAsignacion = 0;
            try
            {
                IList<PaperlessExcepcion> excepciones = (IList<PaperlessExcepcion>)grdExcepciones.DataSource;

                if (excepciones != null)
                {
                    PaperlessPasosEstado pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla(1);
                    pasoSeleccionado.Estado = true;
                    IdAsignacion = pasoSeleccionado.IdAsignacion;
                    ResultadoTransaccion resultado =
                        LogicaNegocios.Paperless.Paperless.Usuario2IngresarExcepxiones(excepciones, pasoSeleccionado);

                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    {
                        Log.Info(" btnP1GuardarExcepciones_Click Rechazada");
                        MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Log.Info(" btnP1GuardarExcepciones_Click Aceptada");
                        CargarPasos();
                        MessageBox.Show("Houses han sido guardados", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Id asignacion " + IdAsignacion);
                Log.Error(ex);
                throw;
            }


        }

        private void gridView2_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;

            if (e.RowHandle >= 0)
            {
                var estado = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Estado"]);
                bool estado2 = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["Estado"]));

                if (estado2)
                {
                    e.Appearance.ForeColor = Color.Green;
                }
                else
                {
                    e.Appearance.ForeColor = Color.Red;
                }
            }
        }

        private void btnP2ContactarEmbarcador_Click(object sender, EventArgs e)
        {
            long idAsignacion = 0;
            try
            {
                IList<PaperlessUsuario1HousesBL> houses = (IList<PaperlessUsuario1HousesBL>)grdContactarembarcador.DataSource;
                //var cuenta = LogicaNegocios.Clientes.clsCuentas.BuscarCuentaPorId(house.Cliente);
                if (houses != null)
                {
                    PaperlessPasosEstado pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla(2);
                    pasoSeleccionado.Estado = true;

                    foreach (var house in houses)
                    {
                        if (!house.FechaReciboAperturaEmbarcador.HasValue) house.FechaReciboAperturaEmbarcador = new DateTime(9999, 1, 1);
                        idAsignacion = house.IdAsignacion;
                    }

                    ResultadoTransaccion resultado =
                        LogicaNegocios.Paperless.Paperless.Usuario2ActualizarHouseBL(houses, pasoSeleccionado);

                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    {
                        Log.Info("btnP2ContactarEmbarcador_Click Rechazada");
                        MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Log.Info("btnP2ContactarEmbarcador_Click Aceptada");
                        CargarPasos();
                        MessageBox.Show("Embarcadores Contactados han sido guardados", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("ID asignacion " + idAsignacion);
                Log.Error(ex);
                throw;
            }
        }

        private bool ValidarAperturaEmbarcadores()
        {
            bool valida = true;

            IList<PaperlessUsuario1HousesBL> houses = (IList<PaperlessUsuario1HousesBL>)grdRecibirAperturaEmb.DataSource;

            foreach (var house in houses)
            {
                if (house.ReciboAperturaEmbarcador &&
                    (house.TipoReciboAperturaEmbarcador == Enums.PaperlessTipoReciboAperturaEmbarcador.NoDefinido
                    || house.TipoReciboAperturaEmbarcador == Enums.PaperlessTipoReciboAperturaEmbarcador.NoRecibida))
                {
                    valida = false;
                    MessageBox.Show(
                        "Debe seleccionar el Modo de recibo para el Embarcador " + house.Cliente.NombreCompañia,
                        "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                if (!house.ReciboAperturaEmbarcador &&
                    (house.TipoReciboAperturaEmbarcador.Equals(Enums.PaperlessTipoReciboAperturaEmbarcador.Mail)
                     || house.TipoReciboAperturaEmbarcador.Equals(Enums.PaperlessTipoReciboAperturaEmbarcador.Papel)
                     || house.TipoReciboAperturaEmbarcador.Equals(Enums.PaperlessTipoReciboAperturaEmbarcador.NoDefinido)))
                {
                    valida = false;
                    MessageBox.Show("Para el Embarcador " + house.Cliente.NombreCompañia + " seleccion de recibo.",
                                    "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                if (ValidaTipoReciboAperturaEmbarcador(house).Equals(true) && house.Observacion.Equals(""))
                {
                    MessageBox.Show("Debe ingresar una observacion en " + house.Cliente.NombreCompañia, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    valida = false;
                    break;
                }
            }

            return valida;
        }

        private void btnP3GuardarAperturaEmbarcadores_Click(object sender, EventArgs e)
        {
            long IdAsignacion = 0;
            try
            {
                IList<PaperlessUsuario1HousesBL> houses = (IList<PaperlessUsuario1HousesBL>)grdRecibirAperturaEmb.DataSource;

                if (!ValidarAperturaEmbarcadores()) return;

                if (houses != null)
                {
                    PaperlessPasosEstado pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla(3);

                    bool pasocompleto = true;
                    foreach (var house in houses)
                    {
                        if (!house.FechaReciboAperturaEmbarcador.HasValue)
                            house.FechaReciboAperturaEmbarcador = DateTime.Now;

                        if (house.TipoReciboAperturaEmbarcador == Enums.PaperlessTipoReciboAperturaEmbarcador.NoDefinido)
                            pasocompleto = false;
                        IdAsignacion = house.IdAsignacion;
                    }


                    if (pasocompleto)
                        pasoSeleccionado.Estado = true;
                    else
                        pasoSeleccionado.Estado = false;

                    ResultadoTransaccion resultado =
                        LogicaNegocios.Paperless.Paperless.Usuario2ActualizarHouseBL(houses, pasoSeleccionado);

                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    {
                        Log.Info("btnP3GuardarAperturaEmbarcadores_Click  Rechazada");
                        MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Log.Info("btnP3GuardarAperturaEmbarcadores_Click  ACEPTADA");
                        CargarPasos();
                        MessageBox.Show("Aperturas de Embarcadores han sido guardadas", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("IdAsignacion " + IdAsignacion);
                Log.Error(ex);
                throw;
            }


        }

        private void frmPaperlessUser2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
            frmListarUsuario2 form = frmListarUsuario2.Instancia;
            form.ObtenerAsignaciones();
        }


        private void Menu_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void gridView5_ShownEditor(object sender, EventArgs e)
        {
            if (this.gridView5.FocusedColumn.FieldName.Equals("TipoReciboAperturaEmbarcador"))
            {
                DevExpress.XtraEditors.ComboBoxEdit cbo = (sender as DevExpress.XtraGrid.Views.Base.BaseView).ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                if (cbo != null)
                {
                    if (((PaperlessUsuario1HousesBL)(gridView5.GetRow(gridView5.FocusedRowHandle))).ReciboAperturaEmbarcador.Equals(true))
                    {
                        ComboBoxItemCollection coll = cbo.Properties.Items;
                        coll.Add(Enums.PaperlessTipoReciboAperturaEmbarcador.Mail);
                        coll.Add(Enums.PaperlessTipoReciboAperturaEmbarcador.Papel);
                    }
                    else
                    {
                        ComboBoxItemCollection coll = cbo.Properties.Items;
                        coll.Add(Enums.PaperlessTipoReciboAperturaEmbarcador.NoRecibida);
                    }
                }
            }

        }

        private void btnReenviarCorreoTermino_Click(object sender, EventArgs e)
        {
            long IdAsignacion = 0;
            try
            {
                var mail = new EnvioMailObject();
                PaperlessUsuario1HouseBLInfo info =
                            LogicaNegocios.Paperless.Paperless.Usuario1ObtenerHousesBLInfo(PaperlessAsignacionActual.Id);
                ResultadoTransaccion resultado = mail.EnviarMailPaperlessUsuario2TerminaProceso(PaperlessAsignacionActual, info);
                //Entidades.GlobalObject.ResultadoTransaccion resultado = Utils.EnvioEmail.EnviarMailPaperlessUsuario2TerminaProceso(PaperlessAsignacionActual, info);
                IdAsignacion = info.IdAsignacion;
                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                {
                    Log.Info("btnReenviarCorreoTermino_Click Rechazada");
                    MessageBox.Show("Error al enviar email de termino de proceso. \n" + resultado.Descripcion, "Paperless",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Log.Info("btnReenviarCorreoTermino_Click Aceptada");
                    MessageBox.Show("Se ha renviado el mail de termino de proceso", "Paperless", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    Close();
                }
            }
            catch (Exception ex)
            {
                Log.Error("IdAsignacion " + IdAsignacion);
                Log.Error(ex);
                throw;
            }
        }        
        private bool ValidaTipoReciboAperturaEmbarcador(PaperlessUsuario1HousesBL  houses)
        {
            if (houses.Cliente != null && houses.Cliente.Cuenta != null)
            {
                 var cta = houses.Cliente.Cuenta;
                if (cta.TipoReciboAperturaEmbarcador != Enums.PaperlessTipoReciboAperturaEmbarcador.NoDefinido)
                    if (houses.TipoReciboAperturaEmbarcador != cta.TipoReciboAperturaEmbarcador)
                    {
                        return true;
                    }
            }
            return false;
        }
     
        private void gridView5_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (this.gridView5.FocusedColumn.FieldName.Equals("TipoReciboAperturaEmbarcador"))
            {
                DialogResult msg;
                var hoses = ((PaperlessUsuario1HousesBL)(gridView5.GetRow(gridView5.FocusedRowHandle)));
                if (ValidaTipoReciboAperturaEmbarcador(hoses).Equals(true))
                {
                    msg = MessageBox.Show("El tipo de recibo seleccionado es Distinto al definido en la Cuenta, ¿desea conservar el de la cuenta?", "Paperless", MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Information);
                    if (msg.Equals(DialogResult.Yes))
                    {
                        hoses.TipoReciboAperturaEmbarcador = hoses.Cliente.Cuenta.TipoReciboAperturaEmbarcador;
                    }
                }
            }
        }


        //private void CargarPasos()
        //{
        //    IList<Usuario1.PasosPaperless> pasos = new List<PasosPaperless>();
        //    PasosPaperless paso;

        //    paso = new PasosPaperless("1", "Resolver Excepciones", false);
        //    pasos.Add(paso);
        //    paso = new PasosPaperless("2", "Contactar Embarcador", false);
        //    pasos.Add(paso);
        //    paso = new PasosPaperless("3", "Recibir Apertura Embarcadores", false);
        //    pasos.Add(paso);
        //    paso = new PasosPaperless("4", "Presentar Manifiesto", false);
        //    pasos.Add(paso);

        //    grdPasos.DataSource = pasos;

        //}


        public void MyShowDialog() {
            ShowDialog();
        }
    }
}
