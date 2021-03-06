﻿using System;
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
using ProyectoCraft.WinForm.Controles;

namespace ProyectoCraft.WinForm.Paperless.Usuario2 {

    public partial class frmPaperlessUser2v2 : Form, IFrmPaperlessUser2 {
        private static readonly ILog Log = LogManager.GetLogger("Paperless");
        public frmPaperlessUser2v2() {
            InitializeComponent();
        }

        private static frmPaperlessUser2v2 _instancia;
        public static frmPaperlessUser2v2 Instancia {
            get {
                if (_instancia == null)
                    _instancia = new frmPaperlessUser2v2();

                return _instancia;
            }
            set { _instancia = value; }
        }

        private PaperlessAsignacion _asignacion;
        public PaperlessAsignacion PaperlessAsignacionActual {
            get {
                if (_asignacion == null)
                    _asignacion = new PaperlessAsignacion();

                return _asignacion;
            }
            set { _asignacion = value; }
        }

        private Enums.TipoAccionFormulario _accion;
        public Enums.TipoAccionFormulario Accion {
            get { return _accion; }
            set { _accion = value; }
        }

        private PaperlessPasosEstado _pasoEstadoActual;
        private List<PaperlessTipoExcepcion> TiposDeExcepciones;
        private List<PaperlessTipoResponsabilidad> TiposResponsabilidad;
        private List<PaperlessAgenteCausador> TiposAgenteCausador;

        private bool IsBrasil { get; set; }

        private void frmPaperlessUser2_Load(object sender, EventArgs e) {

            var configuracion = Base.Configuracion.Configuracion.Instance();
            var opcion = configuracion.GetValue("Paperless_ParcialBrasil"); //puede retornar un true, false o null
            if (opcion.HasValue && opcion.Value.Equals(true)) {
                frmPaperlessUser2_LoadBrasil(sender, e);
                IsBrasil = true;
            } else {
                frmPaperlessUser2_LoadChile(sender, e);
                IsBrasil = false;
            }
            
            //TSC
            EstadoPaperless control = new EstadoPaperless();
            panel1.Controls.Add(control);
            //loadGeneralInfo();
            //CargarPasos();
            //CargarClientesExistentesHousesBl();

            //gridView4.CustomRowCellEditForEditing += new CustomRowCellEditEventHandler(MarcarPaso);

            //CargarPaso1HousesBL();        //TSC
            //ValidarAccion();

            //if (Accion == Enums.TipoAccionFormulario.Consultar)
            //    RepositoryCheckPasos.CheckStateChanged += RecargarPasos;
            //else
            //    RepositoryCheckPasos.CheckStateChanged += MarcarCambioEstadoPaso;

            //Control Tiempo
            control.AsignacionActual = PaperlessAsignacionActual;
            
            control.ConfigurarIniciarTiempo(false);
            control.ObtenerTiemposProcesoUsuario2();

            //control.ObtenerTiempoEstimadoProcesoUsuario2();
            //FIN TSC
            
        }

        private void frmPaperlessUser2_LoadBrasil(object sender, EventArgs e) {
            gridView2.CustomRowCellEditForEditing += new CustomRowCellEditEventHandler(MarcarPaso);

            if (Accion == Enums.TipoAccionFormulario.Consultar)
                RepositoryCheckPasos.CheckStateChanged += RecargarPasos;
            else
                RepositoryCheckPasos.CheckStateChanged += MarcarCambioEstadoPaso;

            CargarPasos();
            ValidarAccion();

            gridView1.Columns.View.Columns[10].Visible = true;
            MailExcepcion.Visible = true;
            AgregarExcepcionManual.Visible = true;
            gridView1.Columns.View.Columns[8].OptionsColumn.AllowEdit = true;
            gridView1.Columns.View.Columns[7].OptionsColumn.AllowEdit = true;
            //foo.FocusedColumn.OptionsColumn.AllowEdit = true;
        }
        private void frmPaperlessUser2_LoadChile(object sender, EventArgs e) {
            gridView2.CustomRowCellEditForEditing += new CustomRowCellEditEventHandler(MarcarPaso);

            if (Accion == Enums.TipoAccionFormulario.Consultar)
                RepositoryCheckPasos.CheckStateChanged += RecargarPasos;
            else
                RepositoryCheckPasos.CheckStateChanged += MarcarCambioEstadoPaso;

            CargarPasos();
            CargarPaso1Excepciones();
            CargarP2ContactarEmbarcadores();
            CargarP3AperturaEmbarcadores();
            gridView1.Columns.View.Columns[10].Visible = false;
            MailExcepcion.Visible = false;
            ValidarAccion();
            AgregarExcepcionManual.Visible = false;
        }

        private void ValidarAccion() {
            if (Accion == Enums.TipoAccionFormulario.Consultar) {
                btnP1GuardarExcepciones.Visible = false;
                btnP2ContactarEmbarcador.Visible = false;
                btnP3GuardarAperturaEmbarcadores.Visible = false;
            }
        }
        private void CargarP2ContactarEmbarcadoresBrasil() {
        }

        private void CargarP2ContactarEmbarcadoresChile() {
            IList<PaperlessUsuario1HousesBL> houses =
             LogicaNegocios.Paperless.Paperless.Usuario1ObtenerHousesBL(PaperlessAsignacionActual.Id);

            houses = LogicaNegocios.Paperless.Paperless.ObtenerEmbarcadores(houses);

            grdContactarembarcador.DataSource = houses;
        }

        private void CargarP2ContactarEmbarcadores() {
            if (IsBrasil)
                CargarP2ContactarEmbarcadoresBrasil();
            else
                CargarP2ContactarEmbarcadoresChile();
        }

        private void CargarP3AperturaEmbarcadores() {
            IList<PaperlessUsuario1HousesBL> houses = LogicaNegocios.Paperless.Paperless.Usuario1ObtenerHousesBL(PaperlessAsignacionActual.Id);
            foreach (var paperlessUsuario1HousesBl in houses) {
                if (paperlessUsuario1HousesBl.Cliente != null) {
                    ResultadoTransaccion res = LogicaNegocios.Clientes.clsCuentas.BuscarCuentaPorId(paperlessUsuario1HousesBl.Cliente.Id);
                    paperlessUsuario1HousesBl.Cliente.Cuenta = (Entidades.Clientes.Cuenta.clsCuenta)res.ObjetoTransaccion;
                }
                if (paperlessUsuario1HousesBl.TipoReciboAperturaEmbarcador.Equals(Enums.PaperlessTipoReciboAperturaEmbarcador.NoDefinido))
                    if (paperlessUsuario1HousesBl.Cliente != null && paperlessUsuario1HousesBl.Cliente.Cuenta != null)
                        paperlessUsuario1HousesBl.TipoReciboAperturaEmbarcador = paperlessUsuario1HousesBl.Cliente.Cuenta.TipoReciboAperturaEmbarcador;
            }

            houses = LogicaNegocios.Paperless.Paperless.ObtenerEmbarcadores(houses);

            grdRecibirAperturaEmb.DataSource = houses;

        }

        private PaperlessPasosEstado ObtenerPasoSeleccionado() {
            var filaSelected = grdPasos.DefaultView.GetRow(gridView2.FocusedRowHandle);

            if (filaSelected == null) {
                return null;
            }

            PaperlessPasosEstado housesbl = (PaperlessPasosEstado)filaSelected;

            return housesbl;
        }

        protected void RecargarPasos(object sender, EventArgs e) {
            CargarPasos();
        }
        private void MarcarCambioEstadoPasoChile(object sender, EventArgs e) {

            var mail = new EnvioMailObject();
            DevExpress.XtraEditors.CheckEdit check = sender as DevExpress.XtraEditors.CheckEdit;
            if (check == null) return;

            PaperlessPasosEstado paso = ObtenerPasoSeleccionado();

            if (paso.Paso.NumPaso == 1 || paso.Paso.NumPaso == 2 || paso.Paso.NumPaso == 3) {
                paso.Estado = false;
                CargarPasos();
                return;
            }

            if (!ValidarPermiteCambiarPasoEstado(paso)) {
                paso.Estado = false;
                CargarPasos();
                return;
            }

            if (paso.Estado) {
                CargarPasos();
                return;
            }


            paso.Estado = check.Checked;

            if (paso != null) {
                Cursor.Current = Cursors.WaitCursor;
                PaperlessAsignacionActual.Estado = Enums.EstadoPaperless.ProcesoTerminado;

                PaperlessProcesoRegistroTiempo termino = new PaperlessProcesoRegistroTiempo();
                termino.IdAsignacion = PaperlessAsignacionActual.Id;
                termino.TerminoUsuario2 = DateTime.Now;

                Entidades.GlobalObject.ResultadoTransaccion resultado =
                    LogicaNegocios.Paperless.Paperless.Usuario2TerminaProceso(PaperlessAsignacionActual, paso, termino);
                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada) {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Error al cambiar estado del paso. \n" + resultado.Descripcion, "Paperless",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    PaperlessUsuario1HouseBLInfo info =
                        LogicaNegocios.Paperless.Paperless.Usuario1ObtenerHousesBLInfo(PaperlessAsignacionActual.Id);
                    resultado = mail.EnviarMailPaperlessUsuario2TerminaProceso(PaperlessAsignacionActual, info);
                    //resultado = Utils.EnvioEmail.EnviarMailPaperlessUsuario2TerminaProceso(PaperlessAsignacionActual,info);

                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada) {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Error al enviar email de termino de proceso. \n" + resultado.Descripcion, "Paperless",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else {
                        frmListarUsuario2 form = frmListarUsuario2.Instancia;
                        form.ObtenerAsignaciones();

                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Proceso ha sido finalizado con éxito.", "Paperless", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                        this.Close();
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
        }
        private void MarcarCambioEstadoPasoBrasil(object sender, EventArgs e) {


            var check = sender as DevExpress.XtraEditors.CheckEdit;
            if (check == null) return;

            PaperlessPasosEstado paso = ObtenerPasoSeleccionado();

            if (!ValidarPermiteCambiarPasoEstado(paso)) {
                paso.Estado = false;
                CargarPasos();
                return;
            }

            if (!String.IsNullOrEmpty(paso.Pantalla)) {
                paso.Estado = false;
                CargarPasos();
                return;
            }


            if (paso.Estado) {
                CargarPasos();
                return;
            }

            paso.Estado = check.Checked;
            ResultadoTransaccion resultado = LogicaNegocios.Paperless.Paperless.Usuario2ActualizaPaso(PaperlessAsignacionActual, paso);
            if (resultado.Estado == Enums.EstadoTransaccion.Rechazada) {
                MessageBox.Show("Error al cambiar estado del paso. \n" + resultado.Descripcion, "Paperless",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                CargarPasos();
            }

            QuitaTodosPaneles();
            CallDinamicMethod(paso);

            return;

        }

        protected void MarcarCambioEstadoPaso(object sender, EventArgs e) {
            if (IsBrasil)
                MarcarCambioEstadoPasoBrasil(sender, e);
            else
                MarcarCambioEstadoPasoChile(sender, e);
        }

        private bool ValidarPermiteCambiarPasoEstado(PaperlessPasosEstado pasoactual) {
            IList<PaperlessPasosEstado> pasos = (IList<PaperlessPasosEstado>)grdPasos.DataSource;

            foreach (var paso in pasos) {
                if (paso.Paso.NumPaso < pasoactual.Paso.NumPaso && !paso.Estado) {
                    MessageBox.Show("Hay pasos previos pendientes de realizar. Debe marcarlos como realizados para continuar", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        public ResultadoTransaccion PrepararPasos() {
            PaperlessAsignacionActual.Estado = Enums.EstadoPaperless.EnProcesoUsuario2;

            ResultadoTransaccion resultado =
                LogicaNegocios.Paperless.Paperless.PreparaPasosUsuario2(PaperlessAsignacionActual);

            if (resultado.Estado == Enums.EstadoTransaccion.Aceptada) {
            } else {
                MessageBox.Show("Error al preparar los pasos de usuario 2. \n" + resultado.Descripcion, "Paperless",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return resultado;
        }

        public void MyShowDialog() {
            ShowDialog();
        }

        private void CargarPasos() {
            try {
                IList<PaperlessPasosEstado> pasos = LogicaNegocios.Paperless.Paperless.ListarPasosEstadoUsuario2(PaperlessAsignacionActual.Id);

                grdPasos.DataSource = pasos;
            } catch (Exception ex) {
                Log.Error(ex);
                throw;
            }
        }

        private void CargarPaso1Excepciones() {
            var excepciones = (List<PaperlessExcepcion>)LogicaNegocios.Paperless.Paperless.Usuario1ObtenerExcepciones(PaperlessAsignacionActual.Id);
            excepciones = (List<PaperlessExcepcion>)LogicaNegocios.Paperless.Paperless.RefrescarExcepciones(excepciones);
            var excepcionesUsuario2 = excepciones.FindAll(foo => foo.Responsabilidad.Id.Equals(2));

            PaperlessAsignacionActual.DataUsuario1.Excepciones = excepcionesUsuario2;
            grdExcepciones.DataSource = PaperlessAsignacionActual.DataUsuario1.Excepciones;
            grdExcepciones.RefreshDataSource();
        }

        public void CallDinamicMethod(PaperlessPasosEstado paso) {
            if (String.IsNullOrEmpty(paso.Pantalla))
                return;

            var name = paso.Pantalla;
            // Call it with each of these parameters.
            object[] parameters = { paso };
            // Get MethodInfo.
            var type = this.GetType();
            var info = type.GetMethod(name);
            info.Invoke(this, parameters);
        }


        #region pasosConPaneles
        public void ResolverExcepciones(PaperlessPasosEstado paso) {
            _pasoEstadoActual = paso;
            pnlExcepciones.Visible = true;
        }

        public void ContactarEnbarcador(PaperlessPasosEstado paso) {
            _pasoEstadoActual = paso;
            pnlContactarembarcador.Visible = true;

        }

        public void AperturaEmbarcadores(PaperlessPasosEstado paso) {
            _pasoEstadoActual = paso;
            pnlRecibirAperturaEmb.Visible = true;

        }
        public void Vinculacion(PaperlessPasosEstado paso) {
            if (PaperlessAsignacionActual.Estado == Enums.EstadoPaperless.ProcesoTerminado)
                return;

            Cursor.Current = Cursors.WaitCursor;
            if (PaperlessAsignacionActual.Estado != Enums.EstadoPaperless.EnviadoMercante) {
                _pasoEstadoActual = paso;
                var pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla();

                PaperlessAsignacionActual.Estado = Enums.EstadoPaperless.EnviadoMercante;

                var result = LogicaNegocios.Paperless.Paperless.CambiaEstadoAsignacion(PaperlessAsignacionActual);
                pasoSeleccionado.Estado = true;
                paso.Estado = true;
                ResultadoTransaccion resultado =
                    LogicaNegocios.Paperless.Paperless.Usuario2ActualizaPaso(PaperlessAsignacionActual, paso);
                CargarPasos();
                paso.Estado = true;
            }
            Cursor.Current = Cursors.Default;


        }

        public void Finalizar(PaperlessPasosEstado paso) {

            if (!validarCicloCompleto())
                return;

            var mail = new EnvioMailObject();
            _pasoEstadoActual = paso;
            if (PaperlessAsignacionActual.Estado == Enums.EstadoPaperless.ProcesoTerminado) {
                pnlReenviarCorreo.Visible = true;
                btnReenviarCorreoTermino.Visible = true;
                return;
            }
            paso.Estado = true;

            if (paso != null) {
                Cursor.Current = Cursors.WaitCursor;
                PaperlessAsignacionActual.Estado = Enums.EstadoPaperless.ProcesoTerminado;

                PaperlessProcesoRegistroTiempo termino = new PaperlessProcesoRegistroTiempo();
                termino.IdAsignacion = PaperlessAsignacionActual.Id;
                termino.TerminoUsuario2 = DateTime.Now;

                ResultadoTransaccion resultado =
                    LogicaNegocios.Paperless.Paperless.Usuario2TerminaProceso(PaperlessAsignacionActual, paso, termino);
                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada) {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Error al cambiar estado del paso. \n" + resultado.Descripcion, "Paperless",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    PaperlessUsuario1HouseBLInfo info =LogicaNegocios.Paperless.Paperless.Usuario1ObtenerHousesBLInfo(PaperlessAsignacionActual.Id);
                    //LK 03-05 Diferencia la rutina de envia de correo de proceso finalizado dependiendo si es Brasil o Chile
                    if (IsBrasil)
                    {
                        resultado = mail.EnviarMailPaperlessUsuario2TerminaProcesoBrasil(PaperlessAsignacionActual, info);
                    }
                    else
                    {
                        resultado = mail.EnviarMailPaperlessUsuario2TerminaProceso(PaperlessAsignacionActual, info);
                    }

                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada) {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Error al enviar email de termino de proceso. \n" + resultado.Descripcion, "Paperless",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else {
                        frmListarUsuario2 form = frmListarUsuario2.Instancia;
                        form.ObtenerAsignaciones();

                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Proceso ha sido finalizado con éxito", "Paperless", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                        this.Close();
                    }
                    Cursor.Current = Cursors.Default;
                }
            }

        }

        #endregion

        protected void MarcarPaso(object sender, CustomRowCellEditEventArgs e) {
            var paso = (PaperlessPasosEstado)((GridView)sender).GetRow(e.RowHandle);
            if (!ValidarPermiteCambiarPasoEstado(paso))
                return;

            var foo = LogicaNegocios.Paperless.Paperless.ListarPasosEstadoUsuario1V2(PaperlessAsignacionActual.Id);
            QuitaTodosPaneles();
            CallDinamicMethod(paso);

            return;
        }

        private void QuitaTodosPaneles() {
            pnlExcepciones.Visible = false;
            pnlContactarembarcador.Visible = false;
            pnlRecibirAperturaEmb.Visible = false;
            pnlReenviarCorreo.Visible = false;
            pnlExcepMaster.Visible = false;
        }

        private PaperlessPasosEstado ObtenerPasoSelccionadoDesdeGrilla() {
            return _pasoEstadoActual;
        }
        private PaperlessPasosEstado ObtenerPasoSelccionadoDesdeGrilla(int numpaso) {
            IList<PaperlessPasosEstado> pasos = (IList<PaperlessPasosEstado>)grdPasos.DataSource;

            return pasos[numpaso - 1];

        }

        private void btnP1GuardarExcepciones_Click(object sender, EventArgs e) {
            long IdAsignacion = 0;
            try {
                IList<PaperlessExcepcion> excepciones = (IList<PaperlessExcepcion>)grdExcepciones.DataSource;

                foreach (var pExcepcionMaster in excepciones) {
                    if (pExcepcionMaster.TieneExcepcion) {

                        if (pExcepcionMaster.TipoExcepcion == null ||
                            pExcepcionMaster.TipoExcepcion.ToString().Equals("")) {
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show(@"Seleccione tipo Excepcion", "Paperless", MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            return;
                        }
                        if (pExcepcionMaster.Causador == null || pExcepcionMaster.Causador.Nombre == null || pExcepcionMaster.Causador.ToString().Equals("")) {
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show(@"Seleccione Agente Causador", "Paperless", MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            return;
                        }
                        if (pExcepcionMaster.Responsabilidad == null ||
                            pExcepcionMaster.Responsabilidad.ToString().Equals("")) {
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show(@"Seleccione tipo Responsabilidad", "Paperless", MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            return;
                        }

                    }
                }
                if (excepciones != null) {
                    PaperlessPasosEstado pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla();
                    pasoSeleccionado.Estado = true;
                    IdAsignacion = pasoSeleccionado.IdAsignacion;
                    ResultadoTransaccion resultado;
                    resultado = LogicaNegocios.Paperless.Paperless.Usuario2IngresarExcepxiones(excepciones, pasoSeleccionado);
                    LogicaNegocios.Paperless.Paperless.Usuario1ActualizaExcepcionV2(excepciones, pasoSeleccionado);


                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada) {
                        Log.Info(" btnP1GuardarExcepciones_Click Rechazada");
                        MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else {
                        Log.Info(" btnP1GuardarExcepciones_Click Aceptada");
                        CargarPasos();
                        MessageBox.Show("Houses han sido guardados", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            } catch (Exception ex) {
                Log.Error("Id asignacion " + IdAsignacion);
                Log.Error(ex);
                throw;
            }


        }

        private void gridView2_RowStyle(object sender, RowStyleEventArgs e) {
            GridView View = sender as GridView;

            if (e.RowHandle >= 0) {
                var estado = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Estado"]);
                bool estado2 = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["Estado"]));

                if (estado2) {
                    e.Appearance.ForeColor = Color.Green;
                } else {
                    e.Appearance.ForeColor = Color.Red;
                }
            }
        }

        private void btnP2ContactarEmbarcador_Click(object sender, EventArgs e) {
            long idAsignacion = 0;
            try {
                IList<PaperlessUsuario1HousesBL> houses = (IList<PaperlessUsuario1HousesBL>)grdContactarembarcador.DataSource;
                //var cuenta = LogicaNegocios.Clientes.clsCuentas.BuscarCuentaPorId(house.Cliente);
                if (houses != null) {
                    PaperlessPasosEstado pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla();
                    pasoSeleccionado.Estado = true;

                    foreach (var house in houses) {
                        if (!house.FechaReciboAperturaEmbarcador.HasValue) house.FechaReciboAperturaEmbarcador = new DateTime(9999, 1, 1);
                        idAsignacion = house.IdAsignacion;
                    }

                    ResultadoTransaccion resultado =
                        LogicaNegocios.Paperless.Paperless.Usuario2ActualizarHouseBL(houses, pasoSeleccionado);

                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada) {
                        Log.Info("btnP2ContactarEmbarcador_Click Rechazada");
                        MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else {
                        Log.Info("btnP2ContactarEmbarcador_Click Aceptada");
                        CargarPasos();
                        MessageBox.Show("Embarcadores Contactados han sido guardados", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            } catch (Exception ex) {
                Log.Error("ID asignacion " + idAsignacion);
                Log.Error(ex);
                throw;
            }
        }

        private bool ValidarAperturaEmbarcadores() {
            bool valida = true;

            IList<PaperlessUsuario1HousesBL> houses = (IList<PaperlessUsuario1HousesBL>)grdRecibirAperturaEmb.DataSource;

            foreach (var house in houses) {
                if (house.ReciboAperturaEmbarcador &&
                    (house.TipoReciboAperturaEmbarcador == Enums.PaperlessTipoReciboAperturaEmbarcador.NoDefinido
                    || house.TipoReciboAperturaEmbarcador == Enums.PaperlessTipoReciboAperturaEmbarcador.NoRecibida)) {
                    valida = false;
                    MessageBox.Show(
                        "Debe seleccionar el Modo de recibo para el Embarcador " + house.Cliente.NombreCompañia,
                        "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                if (!house.ReciboAperturaEmbarcador &&
                    (house.TipoReciboAperturaEmbarcador.Equals(Enums.PaperlessTipoReciboAperturaEmbarcador.Mail)
                     || house.TipoReciboAperturaEmbarcador.Equals(Enums.PaperlessTipoReciboAperturaEmbarcador.Papel)
                     || house.TipoReciboAperturaEmbarcador.Equals(Enums.PaperlessTipoReciboAperturaEmbarcador.NoDefinido))) {
                    valida = false;
                    MessageBox.Show("Para el Embarcador " + house.Cliente.NombreCompañia + " seleccion de recibo.",
                                    "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                if (ValidaTipoReciboAperturaEmbarcador(house).Equals(true) && house.Observacion.Equals("")) {
                    MessageBox.Show("Debe ingresar una observacion en " + house.Cliente.NombreCompañia, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    valida = false;
                    break;
                }
            }

            return valida;
        }

        private void btnP3GuardarAperturaEmbarcadores_Click(object sender, EventArgs e) {
            long IdAsignacion = 0;
            try {
                IList<PaperlessUsuario1HousesBL> houses = (IList<PaperlessUsuario1HousesBL>)grdRecibirAperturaEmb.DataSource;

                if (!ValidarAperturaEmbarcadores()) return;

                if (houses != null) {
                    var pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla();
                    pasoSeleccionado.Estado = true;

                    bool pasocompleto = true;
                    foreach (var house in houses) {
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

                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada) {
                        Log.Info("btnP3GuardarAperturaEmbarcadores_Click  Rechazada");
                        MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else {
                        Log.Info("btnP3GuardarAperturaEmbarcadores_Click  ACEPTADA");
                        CargarPasos();
                        MessageBox.Show("Aperturas de Embarcadores han sido guardadas", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            } catch (Exception ex) {
                Log.Error("IdAsignacion " + IdAsignacion);
                Log.Error(ex);
                throw;
            }


        }

        private void frmPaperlessUser2_FormClosed(object sender, FormClosedEventArgs e) {
            Instancia = null;
            frmListarUsuario2 form = frmListarUsuario2.Instancia;
            form.ObtenerAsignaciones();
        }


        private void Menu_Salir_Click(object sender, EventArgs e) {
            this.Close();
        }


        private void gridView5_ShownEditor(object sender, EventArgs e) {
            if (this.gridView5.FocusedColumn.FieldName.Equals("TipoReciboAperturaEmbarcador")) {
                DevExpress.XtraEditors.ComboBoxEdit cbo = (sender as DevExpress.XtraGrid.Views.Base.BaseView).ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                if (cbo != null) {
                    if (((PaperlessUsuario1HousesBL)(gridView5.GetRow(gridView5.FocusedRowHandle))).ReciboAperturaEmbarcador.Equals(true)) {
                        ComboBoxItemCollection coll = cbo.Properties.Items;
                        coll.Add(Enums.PaperlessTipoReciboAperturaEmbarcador.Mail);
                        coll.Add(Enums.PaperlessTipoReciboAperturaEmbarcador.Papel);
                    } else {
                        ComboBoxItemCollection coll = cbo.Properties.Items;
                        coll.Add(Enums.PaperlessTipoReciboAperturaEmbarcador.NoRecibida);
                    }
                }
            }
        }

        private void btnReenviarCorreoTermino_Click(object sender, EventArgs e) {
            long IdAsignacion = 0;
            try {
                var mail = new EnvioMailObject();
                PaperlessUsuario1HouseBLInfo info =
                            LogicaNegocios.Paperless.Paperless.Usuario1ObtenerHousesBLInfo(PaperlessAsignacionActual.Id);
                ResultadoTransaccion resultado = mail.EnviarMailPaperlessUsuario2TerminaProceso(PaperlessAsignacionActual, info);
                //Entidades.GlobalObject.ResultadoTransaccion resultado = Utils.EnvioEmail.EnviarMailPaperlessUsuario2TerminaProceso(PaperlessAsignacionActual, info);
                IdAsignacion = info.IdAsignacion;
                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada) {
                    Log.Info("btnReenviarCorreoTermino_Click Rechazada");
                    MessageBox.Show("Error al enviar email de termino de proceso. \n" + resultado.Descripcion, "Paperless",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    Log.Info("btnReenviarCorreoTermino_Click Aceptada");
                    MessageBox.Show("Se ha renviado el mail de termino de proceso", "Paperless", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    Close();
                }
            } catch (Exception ex) {
                Log.Error("IdAsignacion " + IdAsignacion);
                Log.Error(ex);
                throw;
            }
        }
        private bool ValidaTipoReciboAperturaEmbarcador(PaperlessUsuario1HousesBL houses) {
            if (houses.Cliente != null && houses.Cliente.Cuenta != null) {
                var cta = houses.Cliente.Cuenta;
                if (cta.TipoReciboAperturaEmbarcador != Enums.PaperlessTipoReciboAperturaEmbarcador.NoDefinido)
                    if (houses.TipoReciboAperturaEmbarcador != cta.TipoReciboAperturaEmbarcador) {
                        return true;
                    }
            }
            return false;
        }

        private void gridView5_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e) {
            if (this.gridView5.FocusedColumn.FieldName.Equals("TipoReciboAperturaEmbarcador")) {
                DialogResult msg;
                var hoses = ((PaperlessUsuario1HousesBL)(gridView5.GetRow(gridView5.FocusedRowHandle)));
                if (ValidaTipoReciboAperturaEmbarcador(hoses).Equals(true)) {
                    msg = MessageBox.Show("El tipo de recibo seleccionado es Distinto al definido en la Cuenta, ¿desea conservar el de la cuenta?", "Paperless", MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Information);
                    if (msg.Equals(DialogResult.Yes)) {
                        hoses.TipoReciboAperturaEmbarcador = hoses.Cliente.Cuenta.TipoReciboAperturaEmbarcador;
                    }
                }
            }
        }

        private void gridView1_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e) {
            var foo = sender as GridView;
            DataRow row = foo.GetDataRow(foo.FocusedRowHandle);
            var lista = foo.DataSource as IList<PaperlessExcepcion>;
            var itemSelecccionado = lista[foo.FocusedRowHandle];
            if (foo.FocusedColumn.FieldName.Equals("Comentario")) {
                if (IsBrasil)
                    e.Cancel = false;
                else
                    if (!itemSelecccionado.TipoExcepcion.Id.Equals(6)) {
                        e.Cancel = true;
                    }
            }
        }

        private void pnlReenviarCorreo_Paint(object sender, PaintEventArgs e) {

        }

        public void RegistrarExcepciones(PaperlessPasosEstado paso) {
            _pasoEstadoActual = paso;
            pnlExcepciones.Visible = true;
            var excepciones = (List<PaperlessExcepcion>)LogicaNegocios.Paperless.Paperless.Usuario1ObtenerExcepciones(PaperlessAsignacionActual.Id);
            excepciones = (List<PaperlessExcepcion>)LogicaNegocios.Paperless.Paperless.RefrescarExcepciones(excepciones);
            PaperlessAsignacionActual.DataUsuario1.Excepciones = excepciones;
            grdExcepciones.DataSource = PaperlessAsignacionActual.DataUsuario1.Excepciones;
            grdExcepciones.RefreshDataSource();


        }


        private void grdExcepciones_ShownEditor(object sender, EventArgs e) {
            try {
                var foo = sender as GridView;
                var lista = foo.DataSource as IList<PaperlessExcepcion>;
                var itemSelecccionado = lista[foo.FocusedRowHandle];
                if (IsBrasil) {
                    TiposDeExcepciones = (List<PaperlessTipoExcepcion>)LogicaNegocios.Paperless.Paperless.ListarTiposExcepciones(PaperlessAsignacionActual.TipoCarga.Nombre);

                    TiposResponsabilidad = LogicaNegocios.Paperless.Paperless.ListarTiposResponsabilidad(PaperlessAsignacionActual.TipoCarga.Nombre);

                    if (TiposAgenteCausador == null)
                        TiposAgenteCausador = LogicaNegocios.Paperless.Paperless.ListarTiposPaperlessAgenteCausador();

                    DataRow row = foo.GetDataRow(foo.FocusedRowHandle);

                    if (itemSelecccionado.HouseBL.Cliente == null)
                        itemSelecccionado.TieneExcepcion = true;

                    if (!itemSelecccionado.TieneExcepcion) {
                        itemSelecccionado.TipoExcepcion = null;
                        itemSelecccionado.Responsabilidad = null;
                        itemSelecccionado.Comentario = String.Empty;
                    }

                }

                if (foo.FocusedColumn.FieldName.Equals("TipoExcepcion")) {
                    if (!IsBrasil)
                        foo.FocusedColumn.OptionsColumn.AllowEdit = false;
                    else {
                        foo.FocusedColumn.OptionsColumn.AllowEdit = true;
                        if (itemSelecccionado.TieneExcepcion) {
                            var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                            cbo.Properties.Items.Clear();
                            foreach (var tipos in TiposDeExcepciones) {
                                cbo.Properties.Items.Add(tipos);
                            }
                        } else {
                            var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                            cbo.Properties.Items.Clear();
                            cbo.EditValue = null;
                            cbo.Properties.Items.Add(new PaperlessTipoExcepcion());
                        }
                    }
                }

                if (foo.FocusedColumn.FieldName.Equals("Responsabilidad")) {
                    if (!IsBrasil)
                        foo.FocusedColumn.OptionsColumn.AllowEdit = false;
                    else {
                        foo.FocusedColumn.OptionsColumn.AllowEdit = true;
                        if (foo.FocusedColumn.OptionsColumn.AllowEdit.Equals(true))
                            if (itemSelecccionado.TieneExcepcion) {
                                var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                                cbo.Properties.Items.Clear();
                                foreach (var tipos in TiposResponsabilidad) {
                                    //    if (!tipos.Nombre.Equals("Usuario 1"))
                                    cbo.Properties.Items.Add(tipos);
                                }
                            } else {
                                var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                                cbo.Properties.Items.Clear();
                                cbo.EditValue = null;
                                cbo.Properties.Items.Add(new PaperlessTipoResponsabilidad());
                            }
                    }
                }
                if (foo.FocusedColumn.FieldName.Equals("Causador")) {
                    if (itemSelecccionado.TieneExcepcion) {
                        var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                        cbo.Properties.Items.Clear();
                        foreach (var tipos in TiposAgenteCausador)
                            cbo.Properties.Items.Add(tipos);
                    } else {
                        var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                        cbo.Properties.Items.Clear();
                        cbo.EditValue = null;
                        cbo.Properties.Items.Add(new PaperlessAgenteCausador());
                    }
                }
            } catch (Exception ex) {
                Log.Error(ex);
                throw;
            }

        }

        private void MailExcepcion_Click(object sender, EventArgs e) {
            var filaSelected = grdExcepciones.DefaultView.GetRow(gridView1.FocusedRowHandle);

            var x = (List<PaperlessExcepcion>)grdExcepciones.DefaultView.DataSource;
            foreach (var paperlessExcepcion in x) {
                if (paperlessExcepcion.TieneExcepcion) {
                    var mail = new EnvioMailObject();
                    Cursor.Current = Cursors.WaitCursor;

                    mail.MailEnBorrador("none@none.com", "Paperless Usuario 2 Excepciones", paperlessExcepcion.TipoExcepcion.ToString());
                }
            }
        }
        private bool validarPasoExcepciones(List<PaperlessExcepcion> excepciones) {
            foreach (PaperlessExcepcion excepcion in excepciones) {
                if (!IsBrasil) {
                    if (excepcion.TieneExcepcion && (excepcion.TipoExcepcion == null || excepcion.Responsabilidad == null))
                        return false;

                } else
                    if (excepcion.TieneExcepcion && (excepcion.TipoExcepcion == null || excepcion.Responsabilidad == null))//!excepcion.Resuelto
                        return false;

                if (excepcion.TieneExcepcion) {
                    if (!excepcion.Resuelto)
                        return false;
                }
            }
            return true;
        }

        private void AgregarExcepcionManual_Click(object sender, EventArgs e) {

            IList<PaperlessExcepcion> excepciones = (IList<PaperlessExcepcion>)grdExcepciones.DataSource;
            var excep = new PaperlessExcepcion();
            excep.IdAsignacion = _asignacion.Id;
            excep.HouseBL.Index = excepciones.Count + 1;
            var excepSeleccionada = Obtiene_Excepcion();

            if (excepSeleccionada != null) {
                excep.HouseBL.Cliente = excepSeleccionada.HouseBL.Cliente;
                excep.HouseBL.TipoCliente = excepSeleccionada.HouseBL.TipoCliente;
                excep.HouseBL.HouseBL = excepSeleccionada.HouseBL.HouseBL;
                excep.HouseBL.Id = excepSeleccionada.HouseBL.Id;
            } else {
                IList<PaperlessUsuario1HousesBL> houses = LogicaNegocios.Paperless.Paperless.Usuario1ObtenerHousesBL(PaperlessAsignacionActual.Id);
                if (houses.Count > 0) {
                    excep.HouseBL.Id = houses[0].Id;
                }
            }
            excep.UsuarioCreador = 2;
            excepciones.Add(excep);

            GrdExcepMaster.DataSource = excepciones;
            GrdExcepMaster.RefreshDataSource();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e) {

        }

        private void btnAgregarExcepMaster_Click(object sender, EventArgs e) {
            IList<PaperlessExcepcionMaster> excepciones = (IList<PaperlessExcepcionMaster>)GrdExcepMaster.DataSource;
            var excepMaster = new PaperlessExcepcionMaster();
            excepMaster.IdAsignacion = _asignacion.Id;
            excepMaster.Index = excepciones.Count + 1;
            excepMaster.UsuarioCreador = 2;
            excepciones.Add(excepMaster);

            GrdExcepMaster.DataSource = excepciones;
            GrdExcepMaster.RefreshDataSource();
        }

        public void RegistrarExcepcionesMaster(PaperlessPasosEstado paso) {

            _pasoEstadoActual = paso;
            var excepciones = LogicaNegocios.Paperless.Paperless.Usuario1ObtenerExcepcionesMaster(PaperlessAsignacionActual.Id);

            if (excepciones.Count.Equals(0)) {
                var excepMaster = new PaperlessExcepcionMaster();
                excepMaster.IdAsignacion = _asignacion.Id;
                excepMaster.Index = 1;
                excepciones.Add(excepMaster);
            }

            GrdExcepMaster.DataSource = excepciones;
            GrdExcepMaster.RefreshDataSource();

            pnlExcepMaster.Visible = true;
            BtnEliminarExcepMaster.Visible = true;
            btnAgregarExcepMaster.Visible = true;
        }

        private void btnGuardarExcepMaster_Click(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            var pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla();

            if (!ValidarPermiteCambiarPasoEstado(pasoSeleccionado))
                return;

            pasoSeleccionado.Estado = true;
            IList<PaperlessExcepcionMaster> excepciones = (IList<PaperlessExcepcionMaster>)GrdExcepMaster.DataSource;
            foreach (var pExcepcionMaster in excepciones) {
                if (pExcepcionMaster.TieneExcepcion) {

                    if (pExcepcionMaster.TipoExcepcion == null ||
                        pExcepcionMaster.TipoExcepcion.ToString().Equals("")) {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show(@"Seleccione tipo Excepcion", "Paperless", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        return;
                    }
                    if (pExcepcionMaster.AgenteCausador == null ||
                        pExcepcionMaster.AgenteCausador.ToString().Equals("")) {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show(@"Seleccione Agente Causador", "Paperless", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        return;
                    }
                    if (pExcepcionMaster.Tiporesponsabilidad == null ||
                        pExcepcionMaster.Tiporesponsabilidad.ToString().Equals("")) {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show(@"Seleccione tipo Responsabilidad", "Paperless", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            ResultadoTransaccion resultado = LogicaNegocios.Paperless.Paperless.Usuario2IngresarExcepxionesMaster(excepciones, pasoSeleccionado);


            if (resultado.Estado == Enums.EstadoTransaccion.Rechazada) {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                CargarPasos();
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Excepciones han sido guardadas", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void grdExcepcionesMaster_ShownEditor(object sender, EventArgs e) {
            if (TiposDeExcepciones == null)
                TiposDeExcepciones = (List<PaperlessTipoExcepcion>)LogicaNegocios.Paperless.Paperless.ListarTiposExcepciones(PaperlessAsignacionActual.TipoCarga.Nombre);
            else
                if (TiposDeExcepciones.Count.Equals(0))
                    TiposDeExcepciones = (List<PaperlessTipoExcepcion>)LogicaNegocios.Paperless.Paperless.ListarTiposExcepciones(PaperlessAsignacionActual.TipoCarga.Nombre);
            if (TiposResponsabilidad == null)
                TiposResponsabilidad = LogicaNegocios.Paperless.Paperless.ListarTiposResponsabilidad(PaperlessAsignacionActual.TipoCarga.Nombre);

            if (TiposAgenteCausador == null)
                TiposAgenteCausador = LogicaNegocios.Paperless.Paperless.ListarTiposPaperlessAgenteCausador();


            var foo = sender as GridView;
            DataRow row = foo.GetDataRow(foo.FocusedRowHandle);
            var lista = foo.DataSource as IList<PaperlessExcepcionMaster>;
            var itemSelecccionado = lista[foo.FocusedRowHandle];
            if (!itemSelecccionado.TieneExcepcion) {
                itemSelecccionado.TipoExcepcion = null;
                itemSelecccionado.Tiporesponsabilidad = null;
                itemSelecccionado.Comentario = String.Empty;
            }

            if (foo.FocusedColumn.FieldName.Equals("TipoExcepcion")) {
                if (itemSelecccionado.TieneExcepcion) {
                    var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                    cbo.Properties.Items.Clear();
                    foreach (var tipos in TiposDeExcepciones) {
                        cbo.Properties.Items.Add(tipos);
                    }
                } else {
                    var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                    cbo.Properties.Items.Clear();
                    cbo.EditValue = null;
                    cbo.Properties.Items.Add(new PaperlessTipoExcepcion());
                }
            }

            if (foo.FocusedColumn.FieldName.Equals("Tiporesponsabilidad")) {
                if (itemSelecccionado.TieneExcepcion) {
                    var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                    cbo.Properties.Items.Clear();
                    foreach (var tipos in TiposResponsabilidad)
                        cbo.Properties.Items.Add(tipos);
                } else {
                    var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                    cbo.Properties.Items.Clear();
                    cbo.EditValue = null;
                    cbo.Properties.Items.Add(new PaperlessTipoResponsabilidad());
                }
            }
            if (foo.FocusedColumn.FieldName.Equals("AgenteCausador")) {
                if (itemSelecccionado.TieneExcepcion) {
                    var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                    cbo.Properties.Items.Clear();
                    foreach (var tipos in TiposAgenteCausador)
                        cbo.Properties.Items.Add(tipos);
                } else {
                    var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                    cbo.Properties.Items.Clear();
                    cbo.EditValue = null;
                    cbo.Properties.Items.Add(new PaperlessAgenteCausador());
                }
            }

        }

        private void BtnEliminarExcepMaster_Click(object sender, EventArgs e) {

            var excepAEliminar = Obtiene_ExcepcionMaster();
            if (excepAEliminar != null)
                LogicaNegocios.Paperless.Paperless.Usuario1EliminaExcepxionMaster(excepAEliminar, Base.Usuario.UsuarioConectado.Usuario.Id);

            var excepciones = LogicaNegocios.Paperless.Paperless.Usuario1ObtenerExcepcionesMaster(PaperlessAsignacionActual.Id);

            GrdExcepMaster.DataSource = excepciones;
            GrdExcepMaster.RefreshDataSource();
        }
        private PaperlessExcepcionMaster Obtiene_ExcepcionMaster() {
            var paso = (PaperlessExcepcionMaster)gridView6.GetRow(gridView6.FocusedRowHandle);//grdExcepciones
            return paso;
        }
        private PaperlessExcepcion Obtiene_Excepcion() {
            var paso = (PaperlessExcepcion)gridView1.GetRow(gridView1.FocusedRowHandle);//grdExcepciones
            return paso;
        }

        private void btnEliminarExcepcion_Click(object sender, EventArgs e) {

            var excepAEliminar = Obtiene_Excepcion();


            if (excepAEliminar != null)
                LogicaNegocios.Paperless.Paperless.Usuario1EliminaExcepxion(excepAEliminar, Base.Usuario.UsuarioConectado.Usuario.Id);

            var excepciones = LogicaNegocios.Paperless.Paperless.Usuario1ObtenerExcepciones(PaperlessAsignacionActual.Id);

            grdExcepciones.DataSource = excepciones;
            grdExcepciones.RefreshDataSource();
        }
        private bool validarCicloCompleto() {
            var excepciones = LogicaNegocios.Paperless.Paperless.Usuario1ObtenerExcepciones(PaperlessAsignacionActual.Id);
            var excepcionesActualizadas = LogicaNegocios.Paperless.Paperless.RefrescarExcepciones((List<PaperlessExcepcion>)excepciones);
            if (!validarPasoExcepciones((List<PaperlessExcepcion>)excepcionesActualizadas)) {
                MessageBox.Show("Falta información, debe ingresar al paso 'Excepciones'", "Paperless",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            var excepcionesMaster = LogicaNegocios.Paperless.Paperless.Usuario1ObtenerExcepcionesMaster(PaperlessAsignacionActual.Id);
            if (!validarPasoExcepcionesMaster((List<PaperlessExcepcionMaster>)excepcionesMaster)) {
                MessageBox.Show("Falta información, debe ingresar al paso 'Excepciones Master'", "Paperless",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }
        private bool validarPasoExcepcionesMaster(List<PaperlessExcepcionMaster> excepciones) {
            foreach (PaperlessExcepcionMaster excepcion in excepciones) {
                if (!IsBrasil) {
                    if (excepcion.TieneExcepcion && (excepcion.TipoExcepcion == null || excepcion.Tiporesponsabilidad == null))
                        return false;
                } else
                    if (excepcion.TieneExcepcion) {
                        if (!excepcion.Resuelto)
                            return false;
                    }
            }
            return true;
        }

        private void btnReenviarCorreoTermino_Click_1(object sender, EventArgs e) {
            long IdAsignacion = 0;
            try {
                var mail = new EnvioMailObject();
                ResultadoTransaccion resultado;
                var info = LogicaNegocios.Paperless.Paperless.Usuario1ObtenerHousesBLInfo(PaperlessAsignacionActual.Id);
                IdAsignacion = info.IdAsignacion;
                //LK 03-05 Diferencia la rutina de envia de correo de proceso finalizado dependiendo si es Brasil o Chile
                if (IsBrasil)
                {
                    resultado = mail.EnviarMailPaperlessUsuario2TerminaProcesoBrasil(PaperlessAsignacionActual, info);
                }
                else
                {
                    resultado = mail.EnviarMailPaperlessUsuario2TerminaProceso(PaperlessAsignacionActual, info);
                }
                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada) {
                    Log.Info("btnReenviarCorreoTermino_Click Rechazada");
                    MessageBox.Show("Error al enviar email de termino de proceso. \n" + resultado.Descripcion, "Paperless",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    Log.Info("btnReenviarCorreoTermino_Click Aceptada");
                    MessageBox.Show("Se ha renviado el mail de termino de proceso", "Paperless", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    Close();
                }
            } catch (Exception ex) {
                Log.Error("IdAsignacion " + IdAsignacion);
                Log.Error(ex);
                throw;
            }
        }

        private void grdPasos_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
