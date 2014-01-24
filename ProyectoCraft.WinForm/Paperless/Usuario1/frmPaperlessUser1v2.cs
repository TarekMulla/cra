using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Clientes.Cuenta;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Integracion;
using ProyectoCraft.Entidades.Paperless;
using ProyectoCraft.WinForm.Controles;
using SCCMultimodal.Paperless.Usuario1;
using SCCMultimodal.Utils;

namespace ProyectoCraft.WinForm.Paperless.Usuario1
{
    public partial class frmPaperlessUser1v2 : Form, IFrmPaperlessUser1
    {
        public frmPaperlessUser1v2()
        {
            InitializeComponent();
        }

        private IList<clsClienteMaster> listTargets = null;
        private IList<clsClienteMaster> listClientesPaperless = null;
        private List<clsClienteMaster> clientes = null;
        private List<PaperlessTipoTransito> TiposTransitoTransbordo = null;
        private List<PaperlessTipoExcepcion> TiposDeExcepciones;
        private List<PaperlessTipoResponsabilidad> TiposResponsabilidad;
        private List<PaperlessAgenteCausador> TiposAgenteCausador;
        private List<PaperlessTipoDisputa> TiposDisputas;
        private int reglasAplicadas;
        private int reglasConError;
        private PaperlessAsignacion _asignacion;

        private PaperlessPasosEstado _pasoEstadoActual;
        private bool _mensajemostrado;
        private bool IsBrasil { get; set; }
        private IList<IntegracionNetShip> netShips;

        private static frmPaperlessUser1v2 _instancia;

        public static frmPaperlessUser1v2 Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmPaperlessUser1v2();

                return _instancia;
            }
            set { _instancia = value; }
        }


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

        private void loadGeneralInfo()
        {
            TiposTransitoTransbordo =
                (List<PaperlessTipoTransito>)LogicaNegocios.Paperless.Paperless.ListarTiposTransitoTransbordo();



        }

        private void frmPaperlessUser1_Load(object sender, EventArgs e)
        {

            var configuracion = Base.Configuracion.Configuracion.Instance();
            var opcion = configuracion.GetValue("Paperless_ParcialBrasil"); //puede retornar un true, false o null
            if (opcion.HasValue && opcion.Value.Equals(true))
            {
                LoadConfBrasil();
                IsBrasil = true;
            }

            else
            {
                LoadConfChile();
                IsBrasil = false;
            }


            EstadoPaperless control = new EstadoPaperless();
            panel1.Controls.Add(control);
            loadGeneralInfo();
            CargarPasos();
            CargarClientesExistentesHousesBl();

            gridView4.CustomRowCellEditForEditing += new CustomRowCellEditEventHandler(MarcarPaso);

            CargarPaso1HousesBL();
            //CargarPaso11IngresoExcepciones();
            ValidarAccion();

            if (Accion == Enums.TipoAccionFormulario.Consultar)
                RepositoryCheckPasos.CheckStateChanged += RecargarPasos;
            else
                RepositoryCheckPasos.CheckStateChanged += MarcarCambioEstadoPaso;

            //Control Tiempo
            control.AsignacionActual = PaperlessAsignacionActual;
            control.ObtenerTiempoEstimadoProcesoUsuario1();
            control.ConfigurarIniciarTiempo(false);
            control.ObtenerTiemposProcesoUsuario1();
        }
        private void LoadConfBrasil()
        {
            ValidaBtnNetShip();
            gridView1.Columns.View.Columns[6].Visible = true;
            MailExcepcion.Visible = true;
            AgregarExcepcionManual.Visible = true;
            DdlEmpresa.Visible = true;
            DdlEmpresa.Properties.Items.Add("Craft");
            DdlEmpresa.Properties.Items.Add("Contact");
            DdlEmpresa.Properties.Items.Add("Slotlog");
            DdlEmpresa.Properties.Items.Add("Neutral");
        }
        private void LoadConfChile()
        {
            ValidaBtnNetShip();
            gridView1.Columns.View.Columns[6].Visible = false;
            MailExcepcion.Visible = false;
            DdlEmpresa.Visible = false;
        }
        private void ValidaBtnNetShip()
        {
            var configuracion = Base.Configuracion.Configuracion.Instance();
            var opcion = configuracion.GetValue("Paperless_Btn_NetShip"); //puede retornar un true, false o null
            if (opcion.HasValue && opcion.Value.Equals(true))
            {
                TxtActualizarNetShip.Visible = true;
                txtLogCarga.Visible = true;
            }
            else
            {
                TxtActualizarNetShip.Visible = false;
                txtLogCarga.Visible = false;
            }
        }

        private void ValidarAccion()
        {
            if (Accion == Enums.TipoAccionFormulario.Consultar)
            {
                btnP1GuardarHousesBL.Visible = false;
                btnP2GuardarHousesRuteados.Visible = false;
                btnP11Excepciones.Visible = false;
                btnP13EnviarAviso.Visible = false;
                btnGuardarDisputas.Visible = false;
                txtLogCarga.Visible = false;
                TxtActualizarNetShip.Visible = false;
            }
        }

        protected void RecargarPasos(object sender, EventArgs e)
        {
            PaperlessPasosEstado paso = ObtenerPasoSeleccionado();
            if (paso.Paso.NumPaso == 11)
            {
                if (PaperlessAsignacionActual.Estado == Enums.EstadoPaperless.EnviadoUsuario2 ||
                    PaperlessAsignacionActual.Estado == Enums.EstadoPaperless.EnProcesoUsuario2 ||
                    PaperlessAsignacionActual.Estado == Enums.EstadoPaperless.ProcesoTerminado)
                    btnReenviarAvisoUsuario2.Visible = true;
            }

            CargarPasos();
        }

        protected void MarcarCambioEstadoPaso(object sender, EventArgs e)
        {
            var check = sender as DevExpress.XtraEditors.CheckEdit;
            if (check == null) return;

            PaperlessPasosEstado paso = ObtenerPasoSeleccionado();

            if (!ValidarPermiteCambiarPasoEstado(paso))
            {
                paso.Estado = false;
                CargarPasos();
                return;
            }

            if (!String.IsNullOrEmpty(paso.Pantalla))
            {
                //if (paso.Paso.NumPaso == 1 || paso.Paso.NumPaso == 2 || paso.Paso.NumPaso == 6 || paso.Paso.NumPaso == 11) {
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
            Entidades.GlobalObject.ResultadoTransaccion resultado = LogicaNegocios.Paperless.Paperless.Usuario1CambiarEstadoPaso(paso);
            if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
            {
                MessageBox.Show("Error al cambiar estado del paso. \n" + resultado.Descripcion, "Paperless",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CargarPasos();
            }
        }

        //private void MarcarCambioEstadoPasoChile(object sender, EventArgs e)
        //{
        //    DevExpress.XtraEditors.CheckEdit check = sender as DevExpress.XtraEditors.CheckEdit;
        //    if (check == null) return;

        //    PaperlessPasosEstado paso = ObtenerPasoSeleccionado();

        //    if (!ValidarPermiteCambiarPasoEstado(paso))
        //    {
        //        paso.Estado = false;
        //        CargarPasos();
        //        return;
        //    }

        //    if (!String.IsNullOrEmpty(paso.Pantalla))
        //    {
        //        //if (paso.Paso.NumPaso == 1 || paso.Paso.NumPaso == 2 || paso.Paso.NumPaso == 6 || paso.Paso.NumPaso == 11) {
        //        paso.Estado = false;
        //        CargarPasos();
        //        return;
        //    }


        //    if (paso.Estado)
        //    {
        //        CargarPasos();
        //        return;
        //    }

        //    paso.Estado = check.Checked;
        //    Entidades.GlobalObject.ResultadoTransaccion resultado =
        //        LogicaNegocios.Paperless.Paperless.Usuario1CambiarEstadoPaso(paso);
        //    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
        //    {
        //        MessageBox.Show("Error al cambiar estado del paso. \n" + resultado.Descripcion, "Paperless",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    else
        //    {
        //        CargarPasos();
        //    }
        //}

        //private void MarcarCambioEstadoPasoBrasil(object sender, EventArgs e)
        //{
        //    DevExpress.XtraEditors.CheckEdit check = sender as DevExpress.XtraEditors.CheckEdit;
        //    if (check == null) return;
        //}

        public void LimpiarFormulario()
        {
            LimparFormularioPaso1();
        }

        private void LimparFormularioPaso1()
        {
            txtP1CantHouses.Text = "";
            txtP1NumConsolidado.Text = "";
            ddlP1Cliente.SelectedIndex = 0;
            grdP1DigitarHousesBL.DataSource = null;
            grdP1DigitarHousesBL.RefreshDataSource();

            pnlPaso1.Visible = false;
            pnlPaso3.Visible = false;
            pnlEnviarAviso.Visible = false;
            pnlExcepciones.Visible = false;
            panelDisputas.Visible = false;

        }

        private void CargarClientesExistentesHousesBl()
        {
            CargaClientes();
            ComboBoxItemCollection coll = ddlP1Cliente.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            if (clientes != null)
                foreach (var list in clientes)
                {
                    coll.Add(list);
                }
            ddlP1Cliente.SelectedIndex = 0;
        }


        protected void QuitaTodosPaneles()
        {
            pnlPaso1.Visible = false;
            pnlPaso3.Visible = false;
            pnlExcepciones.Visible = false;
            pnlEnviarAviso.Visible = false;
            panelDisputas.Visible = false;
            PanelExcepMaster.Visible = false;

        }

        #region pasosConPaneles

        public void IngresoDeDatos(PaperlessPasosEstado paso)
        {//revisar
            _pasoEstadoActual = paso;
            pnlPaso1.Visible = true;

            grdP1DigitarHousesBL.Visible = true;

        }

        public void CrearManifiesto(PaperlessPasosEstado paso)
        {
            _pasoEstadoActual = paso;
            var houses =
                LogicaNegocios.Paperless.Paperless.RefrescarTiposTransitoTransbordo(
                    (List<PaperlessUsuario1HousesBL>)PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL);
            grdP3HousesRuteados.DataSource = houses;
            grdP3HousesRuteados.RefreshDataSource();
            pnlPaso3.Visible = true;
        }

        public void RegistrarExcepciones(PaperlessPasosEstado paso)
        {
            _pasoEstadoActual = paso;
            var excepciones = LogicaNegocios.Paperless.Paperless.Usuario1ObtenerExcepciones(PaperlessAsignacionActual.Id);
            var excepcionesActualizadas =
                LogicaNegocios.Paperless.Paperless.RefrescarExcepciones((List<PaperlessExcepcion>)excepciones);
            grdExcepciones.DataSource = excepcionesActualizadas;
            grdP3HousesRuteados.RefreshDataSource();
            pnlExcepciones.Visible = true;
        }

        public void EnvioDisputa(PaperlessPasosEstado paso)
        {
            _pasoEstadoActual = paso;
            panelDisputas.Visible = true;
            var disputas = LogicaNegocios.Paperless.Paperless.ObtieneDisputas(PaperlessAsignacionActual);
            GridDisputas.DataSource = disputas;
            GridDisputas.RefreshDataSource();
        }

        public void EnviarAvisoUsuario2(PaperlessPasosEstado paso)
        {
            _pasoEstadoActual = paso;
            pnlEnviarAviso.Visible = true;
        }

        #endregion

        public void CallDinamicMethod(PaperlessPasosEstado paso)
        {
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

        protected void MarcarPaso(object sender, CustomRowCellEditEventArgs e)
        {
            var paso = (PaperlessPasosEstado)((GridView)sender).GetRow(e.RowHandle);
            if (!ValidarPermiteCambiarPasoEstado(paso))
                return;

            var foo = LogicaNegocios.Paperless.Paperless.ListarPasosEstadoUsuario1V2(PaperlessAsignacionActual.Id);
            QuitaTodosPaneles();
            CallDinamicMethod(paso);
            return;
        }

        //private void CargarPasoDisputa()
        //{
        //    panelDisputas.Visible = true;
        //    var disputas = LogicaNegocios.Paperless.Paperless.ObtieneDisputas(PaperlessAsignacionActual);
        //    GridDisputas.DataSource = disputas;
        //    GridDisputas.RefreshDataSource();
        //}

        //private void CargarPaso2TransitoTransbordo()
        //{
        //    var houses =
        //        LogicaNegocios.Paperless.Paperless.RefrescarTiposTransitoTransbordo(
        //            (List<PaperlessUsuario1HousesBL>)PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL);
        //    grdP3HousesRuteados.DataSource = houses;
        //    grdP3HousesRuteados.RefreshDataSource();
        //}

        //private void CargarPaso6Excepciones()
        //{
        //    var excepciones = LogicaNegocios.Paperless.Paperless.Usuario1ObtenerExcepciones(PaperlessAsignacionActual.Id);
        //    var excepcionesActualizadas =
        //        LogicaNegocios.Paperless.Paperless.RefrescarExcepciones((List<PaperlessExcepcion>)excepciones);
        //    grdExcepciones.DataSource = excepcionesActualizadas;
        //    grdP3HousesRuteados.RefreshDataSource();
        //}

        private void CargarPasos()
        {

            var pasos = LogicaNegocios.Paperless.Paperless.ListarPasosEstadoUsuario1V2(PaperlessAsignacionActual.Id);
            grdPasos.DataSource = pasos;
        }

        private bool ValidarPermiteCambiarPasoEstado(PaperlessPasosEstado pasoactual)
        {
            IList<PaperlessPasosEstado> pasos = (IList<PaperlessPasosEstado>)grdPasos.DataSource;

            foreach (var paso in pasos)
            {
                if (paso.Paso.NumPaso < pasoactual.Paso.NumPaso && !paso.Estado)
                {
                    MessageBox.Show(
                        "Hay pasos previos pendientes de realizar. Debe marcarlos como realizados para continuar",
                        "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        public Entidades.GlobalObject.ResultadoTransaccion PrepararPasos()
        {
            PaperlessProcesoRegistroTiempo inicio = new PaperlessProcesoRegistroTiempo();
            inicio.IdAsignacion = PaperlessAsignacionActual.Id;
            inicio.ComienzoUsuario1 = DateTime.Now;


            Entidades.GlobalObject.ResultadoTransaccion resultado =
                LogicaNegocios.Paperless.Paperless.PreparaPasosUsuario1V2(PaperlessAsignacionActual, inicio);

            if (resultado.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                PaperlessAsignacionActual.Estado = Enums.EstadoPaperless.EnProcesoUsuario1;
                resultado = LogicaNegocios.Paperless.Paperless.CambiaEstadoAsignacion(PaperlessAsignacionActual);
            }

            return resultado;
        }

        public void CargarInformacionAsignacionInicial()
        {
            txtP1CantHouses.Text = PaperlessAsignacionActual.NumHousesBL.ToString();
        }

        public void MyShowDialog()
        {
            ShowDialog();
        }

        private void frmPaperlessUser1_Leave(object sender, EventArgs e)
        {
            Instancia = null;
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            frmListarUsuario1 form = frmListarUsuario1.Instancia;
            form.ObtenerAsignaciones();

            Instancia = null;
            Close();
        }

        private void CargarPaso1HousesBL()
        {
            IList<PaperlessUsuario1HousesBL> housesnew = new List<PaperlessUsuario1HousesBL>();

            IList<PaperlessUsuario1HousesBL> houses =
                LogicaNegocios.Paperless.Paperless.Usuario1ObtenerHousesBL(PaperlessAsignacionActual.Id);

            if (houses == null || houses.Count == 0)
            {
                //generar items para houses

                for (int i = 1; i <= int.Parse(txtP1CantHouses.Text); i++)
                {
                    PaperlessUsuario1HousesBL house = new PaperlessUsuario1HousesBL();
                    house.Index = i;
                    house.IdAsignacion = PaperlessAsignacionActual.Id;
                    house.Freehand = false;
                    house.HouseBL = "";
                    house.ExcepcionRecargoCollect = new PaperlessExcepcion() { RecargoCollect = false };
                    housesnew.Add(house);
                }
            }
            else
            {
                housesnew = houses;
            }
            if (int.Parse(txtP1CantHouses.Text) > housesnew.Count)
            {
                for (int i = housesnew.Count + 1; i <= int.Parse(txtP1CantHouses.Text); i++)
                {
                    PaperlessUsuario1HousesBL house = new PaperlessUsuario1HousesBL();
                    house.Index = i;
                    house.IdAsignacion = PaperlessAsignacionActual.Id;
                    house.Freehand = false;
                    house.HouseBL = "";
                    house.ExcepcionRecargoCollect = new PaperlessExcepcion() { RecargoCollect = false };
                    housesnew.Add(house);
                }
            }

            grdP1DigitarHousesBL.DataSource = housesnew;
            grdP1DigitarHousesBL.RefreshDataSource();


            //Cargar Info Houses BL
            PaperlessUsuario1HouseBLInfo info =
                LogicaNegocios.Paperless.Paperless.Usuario1ObtenerHousesBLInfo(PaperlessAsignacionActual.Id);
            if (info != null)
            {
                txtP1CantHouses.Text = PaperlessAsignacionActual.NumHousesBL.ToString();
                txtP1NumConsolidado.Text = info.NumConsolidado;
            }
            PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL = housesnew;
            PaperlessAsignacionActual.DataUsuario1.Paso1HousesBLInfo = info;

        }

        private void grdP1DigitarHousesBL_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {

            }
        }

        private PaperlessPasosEstado ObtenerPasoSeleccionado()
        {
            var paso = (PaperlessPasosEstado)gridView4.GetRow(gridView4.FocusedRowHandle);
            return paso;
        }

        private bool ValidarHousesBLInfo()
        {
            //Cargamos la configuracion
            var configuracion = Base.Configuracion.Configuracion.Instance();
            var opcion = configuracion.GetValue("Paperless_ParcialBrasil"); //puede retornar un true, false o null
            if (opcion.HasValue && opcion.Value.Equals(true))
                return ValidarHousesBLInfoBrasil();
            return ValidarHousesBLInfoChile();
        }

        private bool ValidarHousesBLInfoChile()
        {
            bool valida = true;

            dxErrorProvider1.ClearErrors();
            if (txtP1CantHouses.Text.Length.Equals(0))
            {
                dxErrorProvider1.SetError(txtP1CantHouses, "Debe ingresar Cantidad de Houses", ErrorType.Critical);
                valida = false;
            }

            if (txtP1NumConsolidado.Text.Length.Equals(0))
            {
                dxErrorProvider1.SetError(txtP1NumConsolidado, "Debe ingresar numero de consolidado", ErrorType.Critical);
                valida = false;
            }
            else
            {
                var configuracion = Base.Configuracion.Configuracion.Instance();
                var opcion = configuracion.GetValue("Paperless_Usuario1_Valida_Num_Consolidado"); //puede retornar un true, false o null
                if (opcion.HasValue && opcion.Value.Equals(true))
                {
                    if (LogicaNegocios.Paperless.Paperless.ValidaNumConsolidado(txtP1NumConsolidado.Text, PaperlessAsignacionActual.Id32.ToString()).Equals(true))
                    {
                        dxErrorProvider1.SetError(txtP1NumConsolidado, "Ya existe el numero de consolidado", ErrorType.Critical);
                        return false;
                    }
                    dxErrorProvider1.ClearErrors();
                }

            }



            IList<PaperlessUsuario1HousesBL> listhouses = (IList<PaperlessUsuario1HousesBL>)grdP1DigitarHousesBL.DataSource;
            foreach (var house in listhouses)
            {
                if (house.HouseBL.Trim().Length.Equals(0) || house.Cliente == null || house.TipoCliente == null || house.TipoCliente.Id.Equals(0))
                {
                    lblP1errorHouses.Visible = true;
                    valida = false;
                    break;
                }
            }

            return valida;

        }
        private bool ValidarHousesBLInfoBrasil()
        {
            bool valida = true;

            dxErrorProvider1.ClearErrors();
            if (txtP1CantHouses.Text.Length.Equals(0))
            {
                dxErrorProvider1.SetError(txtP1CantHouses, "Debe ingresar Cantidad de Houses", ErrorType.Critical);
                valida = false;
            }

            if (txtP1NumConsolidado.Text.Length.Equals(0))
            {
                dxErrorProvider1.SetError(txtP1NumConsolidado, "Debe ingresar numero de consolidado", ErrorType.Critical);
                valida = false;
            }
            else
            {
                var configuracion = Base.Configuracion.Configuracion.Instance();
                var opcion = configuracion.GetValue("Paperless_Usuario1_Valida_Num_Consolidado"); //puede retornar un true, false o null
                if (opcion.HasValue && opcion.Value.Equals(true))
                {
                    if (LogicaNegocios.Paperless.Paperless.ValidaNumConsolidado(txtP1NumConsolidado.Text, PaperlessAsignacionActual.Id32.ToString()).Equals(true))
                    {
                        dxErrorProvider1.SetError(txtP1NumConsolidado, "Ya existe el numero de consolidado",
                                                  ErrorType.Critical);
                        return false;
                    }
                    dxErrorProvider1.ClearErrors();
                }
            }
            int cont = 1;
            //cambio guillermo, se quita validacion de hbls
            IList<PaperlessUsuario1HousesBL> listhouses = (IList<PaperlessUsuario1HousesBL>)grdP1DigitarHousesBL.DataSource;
            foreach (var house in listhouses)
            {
                cont++;
                if (house.HouseBL == null || house.TipoCliente == null)
                {
                    lblP1errorHouses.Visible = true;
                    valida = false;
                    break;
                }
                if (house.HouseBL.Trim().Length.Equals(0) || house.Cliente == null || house.TipoCliente == null || house.TipoCliente.Id.Equals(0))
                {
                    //GeneraDummy(house, cont);
                    lblP1errorHouses.Visible = true;
                    valida = false;
                    break;
                }
            }

            return valida;
        }
        private void GeneraDummy(PaperlessUsuario1HousesBL house, int i)
        {
            var item = new IntegracionNetShip();
            item.HouseBl = "hblsDummy" + i;
            item.Rut = i.ToString();
            item.Cliente = "ClienteDummy";
            item.TipoCliente = "Directo";
            item.Ruteado = true;
            item.ShippingInstruction = "";
            item.Puerto = "";
            return;
        }

        private PaperlessUsuario1HouseBLInfo Usuario1ObtenerHousesBLInfo()
        {
            PaperlessUsuario1HouseBLInfo info = new PaperlessUsuario1HouseBLInfo();

            info.CantHouses = Convert.ToInt16(txtP1CantHouses.Text);
            info.IdAsignacion = PaperlessAsignacionActual.Id;
            info.NumConsolidado = txtP1NumConsolidado.Text;
            return info;
        }

        private PaperlessPasosEstado ObtenerPasoSelccionadoDesdeGrilla()
        {
            return _pasoEstadoActual;
        }

        private void btnP1GuardarHousesBL_Click(object sender, EventArgs e)
        {
            if (!ValidarHousesBLInfo()) return;

            Cursor.Current = Cursors.WaitCursor;
            IList<PaperlessUsuario1HousesBL> listhouses = (IList<PaperlessUsuario1HousesBL>)grdP1DigitarHousesBL.DataSource;
            //PaperlessPasosEstado pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla(1);
            var pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla();
            pasoSeleccionado.Estado = true;
            PaperlessUsuario1HouseBLInfo info = Usuario1ObtenerHousesBLInfo();
            var resultado = LogicaNegocios.Paperless.Paperless.Usuario1GuardaHousesBL(listhouses, info, pasoSeleccionado);
            PaperlessAsignacionActual.DataUsuario1.Paso1HousesBLInfo = info;
            PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL = listhouses;

            try
            {
                LogicaNegocios.Paperless.Paperless.Usuario1GuardaEmpresa(DdlEmpresa.SelectedText, PaperlessAsignacionActual.Id);
            }
            catch (Exception ex)
            {
                Log.log.Error(ex);
            }



            if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LogicaNegocios.Paperless.Paperless.Usuario1MarcarHousesRuteados(listhouses, pasoSeleccionado);

                CargarPasos();
                Cursor.Current = Cursors.Default;
                lblP1errorHouses.Visible = false;
                MessageBox.Show("Houses han sido guardados", "Paperless", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                //btnP1GuardarHousesBL.Enabled = false;

            }
        }

        private void btnP2GuardarHousesRuteados_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            lblErrorPaso2.Hide();
            IList<PaperlessUsuario1HousesBL> listhouses =
                (IList<PaperlessUsuario1HousesBL>)grdP3HousesRuteados.DataSource;
            //PaperlessPasosEstado pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla(2);
            var pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla();

            if (!ValidarPermiteCambiarPasoEstado(pasoSeleccionado))
                return;

            //Validacion para que se ingresen todos los tipo de transbordos
            /*if (listhouses.Any(house => house.TransbordoTransito == null || house.TransbordoTransito.Id == 0)) {
                lblErrorPaso2.Show();
                return;
            }*/

            pasoSeleccionado.Estado = true;

            //Entidades.GlobalObject.ResultadoTransaccion resultado = LogicaNegocios.Paperless.Paperless.Usuario1MarcarHousesRuteados(listhouses, pasoSeleccionado);
            Entidades.GlobalObject.ResultadoTransaccion resultado =
                LogicaNegocios.Paperless.Paperless.Usuario1GuardarTipoTransito(listhouses, pasoSeleccionado);


            PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL = listhouses;

            if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CargarPasos();
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Transbordos y transistos han sido guardados", "Paperless", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                //btnP2GuardarHousesRuteados.Enabled = false;
            }

        }

        private void gridView5_ShownEditor(object sender, EventArgs e)
        {
            var foo = sender as GridView;

            if (foo.FocusedColumn.FieldName.Equals("Cliente.NombreFantasia"))
            {
                DevExpress.XtraEditors.TextEdit txt =
                    (sender as DevExpress.XtraGrid.Views.Base.BaseView).ActiveEditor as DevExpress.XtraEditors.TextEdit;

                if (txt.MaskBox.AutoCompleteCustomSource.Count == 0)
                {
                    txt.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txt.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txt.MaskBox.AutoCompleteCustomSource = GetClientes(txt);
                }
            }

            if (foo.FocusedColumn.FieldName.Equals("TipoCliente.Nombre"))
            {
                DevExpress.XtraEditors.ComboBoxEdit cbo =
                    (sender as DevExpress.XtraGrid.Views.Base.BaseView).ActiveEditor as
                    DevExpress.XtraEditors.ComboBoxEdit;
                ComboBoxItemCollection coll = cbo.Properties.Items;

                foreach (var tipo in Paso1CargarClientes())
                {
                    coll.Add(tipo);
                }
            }
            if (foo.FocusedColumn.FieldName.Equals("TransbordoTransito"))
            {
                DevExpress.XtraEditors.ComboBoxEdit cbo =
                    (sender as DevExpress.XtraGrid.Views.Base.BaseView).ActiveEditor as
                    DevExpress.XtraEditors.ComboBoxEdit;
                ComboBoxItemCollection coll = cbo.Properties.Items;
                foreach (var tipo in TiposTransitoTransbordo)
                {
                    coll.Add(tipo);
                }
            }


        }

        private IList<PaperlessTipoCliente> Paso1CargarClientes()
        {

            IList<PaperlessTipoCliente> tipos =
                LogicaNegocios.Paperless.Paperless.ListarTiposCliente(Enums.Estado.Habilitado);

            return tipos;
        }

        private AutoCompleteStringCollection GetClientes(DevExpress.XtraEditors.TextEdit txt)
        {
            CargaClientes();
            ddlP1Cliente.Properties.Items.Clear();
            ComboBoxItemCollection coll = ddlP1Cliente.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in clientes)
                coll.Add(list);

            ddlP1Cliente.SelectedIndex = 0;
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (var list in clientes)
                auto.Add(list.ToString());

            return auto;
        }

        private void gridView5_CellValueChanged(object sender,
                                                DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DevExpress.XtraGrid.Views.Base.ColumnView columna = sender as DevExpress.XtraGrid.Views.Base.ColumnView;
            string nomcliente = "";
            clsCuenta cuenta = new clsCuenta();
            clsClienteMaster clienteselecccionado = new clsClienteMaster(false);


            if (e.Column.FieldName == "Cliente.NombreFantasia")
            {
                nomcliente = columna.EditingValue.ToString();

                //Console.WriteLine("nomCliente--->"+nomcliente);
                if (nomcliente.Trim() != "")
                {
                    ddlP1Cliente.SelectedIndex = 0;
                    for (int i = 0; i < ddlP1Cliente.Properties.Items.Count; i++)
                    {
                        if (ddlP1Cliente.Properties.Items[i].ToString().Trim() == nomcliente.Trim())
                        {
                            ddlP1Cliente.SelectedIndex = i;
                            break;
                        }
                    }
                    //Console.WriteLine("index seleccionado--->" + ddlP1Cliente.SelectedIndex);

                    if (ddlP1Cliente.SelectedIndex == 0)
                    {
                        clienteselecccionado = new clsClienteMaster(true)
                                                   {
                                                       NombreFantasia = columna.EditingValue.ToString(),
                                                       NombreCompañia = columna.EditingValue.ToString(),
                                                       Tipo = Enums.TipoPersona.CuentaPaperless,
                                                       EstadoCuenta = Enums.Estado.Habilitado
                                                   };
                        PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL[e.RowHandle].TipoCliente = null;
                    }
                    else
                    {
                        clienteselecccionado = (clsClienteMaster)this.ddlP1Cliente.SelectedItem;
                        if (clienteselecccionado.Id != 0)
                        {
                            PaperlessTipoCliente ptc = new PaperlessTipoCliente();

                            var transaccion =
                                LogicaNegocios.Clientes.clsCuentas.BuscarCuentaPorId(clienteselecccionado.Id);
                            if (transaccion != null)
                            {
                                cuenta = (clsCuenta)transaccion.ObjetoTransaccion;
                                if (cuenta != null && cuenta.ClienteMaster.ClienteMasterTipoCliente != null)
                                {
                                    if (cuenta.ClienteMaster.ClienteMasterTipoCliente.Count.Equals(0) ||
                                        cuenta.ClienteMaster.ClienteMasterTipoCliente.Count > 1)
                                    {
                                        PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL[e.RowHandle].TipoCliente =
                                            null;
                                    }
                                    else
                                    {
                                        ptc.Nombre = cuenta.ClienteMaster.ClienteMasterTipoCliente[0].Nombre;
                                        ptc.Id = cuenta.ClienteMaster.ClienteMasterTipoCliente[0].Id;
                                        PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL[e.RowHandle].TipoCliente =
                                            ptc;
                                    }
                                }
                                else
                                {
                                    PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL[e.RowHandle].TipoCliente = null;
                                }

                            }
                        }
                        if (clienteselecccionado.NombreFantasia.Length.Equals(0))
                            clienteselecccionado.NombreFantasia = clienteselecccionado.NombreCompañia;
                    }
                }

                PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL[e.RowHandle].Cliente = clienteselecccionado;
            }

            if (e.Column.FieldName == "TipoCliente.Nombre")
            {
                PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL[e.RowHandle].TipoCliente =
                    (PaperlessTipoCliente)columna.EditingValue;
            }
        }

        private bool validarPasoExcepciones(List<PaperlessExcepcion> excepciones)
        {
            foreach (PaperlessExcepcion excepcion in excepciones)
            {
                if (!IsBrasil)
                {
                    if (excepcion.TieneExcepcion && (excepcion.TipoExcepcion == null || excepcion.Responsabilidad == null))
                        return false;
                }
                else
                    if (excepcion.TieneExcepcion)
                    {
                        if (excepcion.Responsabilidad.Nombre.Equals("Usuario 1") && !excepcion.Resuelto)
                        {
                            MessageBox.Show(@"Las Excepciones de Responsabilidad Usuario 1 deben quedar Resueltas", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                    }
            }
            return true;
        }

        private void btnP11Excepciones_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla();
                if (!ValidarPermiteCambiarPasoEstado(pasoSeleccionado))
                    return;

                IList<PaperlessExcepcion> excepciones = (IList<PaperlessExcepcion>)grdExcepciones.DataSource;

                PaperlessAsignacionActual.DataUsuario1.Excepciones = excepciones;


                foreach (var pExcep in excepciones)
                {
                    if (pExcep.TieneExcepcion)
                    {
                        if (pExcep.TipoExcepcion == null || pExcep.TipoExcepcion.ToString().Equals(""))
                        {
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show(@"Seleccione tipo Excepcion", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (pExcep.Causador == null || pExcep.Causador.ToString() == null || pExcep.Causador.ToString().Equals(""))
                        {
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show(@"Seleccione Agente Causador", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (pExcep.Responsabilidad == null || pExcep.Responsabilidad.ToString().Equals(""))
                        {
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show(@"Seleccione tipo Responsabilidad", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (pExcep.Responsabilidad != null && pExcep.Responsabilidad.ToString().Equals("Usuario 2") && pExcep.Resuelto)
                        {
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show(@"El Usuario 1 no puede resolver excepciones del Usuario 2", @"Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                }
                pasoSeleccionado.Estado = true;
                IList<PaperlessUsuario1HousesBL> listhouses = (IList<PaperlessUsuario1HousesBL>)grdP1DigitarHousesBL.DataSource;
                LogicaNegocios.Paperless.Paperless.Usuario1GuardaHousesBL(listhouses, Usuario1ObtenerHousesBLInfo(), pasoSeleccionado);

                Entidades.GlobalObject.ResultadoTransaccion resultado = LogicaNegocios.Paperless.Paperless.Usuario1IngresarExcepxionesV2(excepciones, pasoSeleccionado);

                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CargarPasos();
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Excepciones han sido guardadas", "Paperless", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    //btnP11Excepciones.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Log.log.Error(ex);
                throw ex;
            }


        }

        private void gridView4_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;

            if (e.RowHandle >= 0)
            {
                var estado2 = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["Estado"]));
                e.Appearance.ForeColor = estado2 ? Color.Green : Color.Red;
            }
        }

        private void btnP13EnviarAviso_Click(object sender, EventArgs e)
        {
            if (!validarCicloCompleto())
                return;
            var mail = new EnvioMailObject();
            Cursor.Current = Cursors.WaitCursor;

            //PaperlessPasosEstado pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla(11);
            var pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla();

            if (!ValidarPermiteCambiarPasoEstado(pasoSeleccionado))
                return;

            pasoSeleccionado.Estado = true;
            PaperlessAsignacionActual.Estado = Enums.EstadoPaperless.EnviadoUsuario2;

            PaperlessProcesoRegistroTiempo tiempotermino = new PaperlessProcesoRegistroTiempo()
                                                               {
                                                                   IdAsignacion = PaperlessAsignacionActual.Id,
                                                                   TerminoUsuario1 = DateTime.Now
                                                               };

            PaperlessProcesoRegistroTiempo iniciousuario2 = new PaperlessProcesoRegistroTiempo()
                                                                {
                                                                    IdAsignacion = PaperlessAsignacionActual.Id,
                                                                    ComienzoUsuario2 = DateTime.Now
                                                                };

            Entidades.GlobalObject.ResultadoTransaccion resultado =
                LogicaNegocios.Paperless.Paperless.Usuario1CambiarEstadoPaso_CambiarEstadoAsignacion(pasoSeleccionado,
                                                                                                     PaperlessAsignacionActual,
                                                                                                     tiempotermino,
                                                                                                     iniciousuario2);
            if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
            {
                Cursor.Current = Cursors.Default;

                MessageBox.Show("Error al cambiar estado del paso. \n" + resultado.Descripcion, "Paperless",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                resultado = mail.EnviarMailPaperlessUsuario2ConfirmacionUsuario1(PaperlessAsignacionActual);
                //resultado = Utils.EnvioEmail.EnviarMailPaperlessUsuario2ConfirmacionUsuario1(PaperlessAsignacionActual);

                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Ocurrio un problema al intentar enviar el email. \n" + resultado.Descripcion,
                                    "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Se ha enviado la confirmacion al Usuario de la segunda Etapa", "Paperless",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    frmListarUsuario1 form = frmListarUsuario1.Instancia;
                    form.ObtenerAsignaciones();
                }

                CargarPasos();
            }
            Cursor.Current = Cursors.Default;
        }

        private bool validarCicloCompleto()
        {
            var numHouses = PaperlessAsignacionActual.NumHousesBL;
            //se quita, con la nueva mejora  siempre habrá diferencia de Houses Bls
            //if (LogicaNegocios.Paperless.Paperless.Usuario1ObtenerHousesBL(PaperlessAsignacionActual.Id).Count !=
            //    numHouses)
            //{
            //    MessageBox.Show("Falta informacion, debe ingresar al paso 'ingreso de datos'");
            //    return false;
            //}

            /*var houses = LogicaNegocios.Paperless.Paperless.RefrescarTiposTransitoTransbordo((List<PaperlessUsuario1HousesBL>)PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL);
            if (houses.Any(house => house.TransbordoTransito == null || house.TransbordoTransito.Id == 0)) {
                MessageBox.Show("Falta informacion, debe ingresar al paso 'crear Manifiesto'");
                return false;
            }*/

            var excepciones = LogicaNegocios.Paperless.Paperless.Usuario1ObtenerExcepciones(PaperlessAsignacionActual.Id);
            var excepcionesActualizadas =
                LogicaNegocios.Paperless.Paperless.RefrescarExcepciones((List<PaperlessExcepcion>)excepciones);
            if (!validarPasoExcepciones((List<PaperlessExcepcion>)excepcionesActualizadas))
            {
                MessageBox.Show("Falta informacion, debe ingresar al paso 'Excepciones'");
                return false;
            }
            var excepcionesMaster = LogicaNegocios.Paperless.Paperless.Usuario1ObtenerExcepcionesMaster(PaperlessAsignacionActual.Id);
            if (!validarPasoExcepcionesMaster((List<PaperlessExcepcionMaster>)excepcionesMaster))
            {
                MessageBox.Show("Falta informacion, debe ingresar al paso 'Excepciones Master'");
                return false;
            }


            return true;
        }

        private void frmPaperlessUser1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
            frmListarUsuario1 form = frmListarUsuario1.Instancia;
            form.ObtenerAsignaciones();
        }

        private void btnReenviarAvisoUsuario2_Click(object sender, EventArgs e)
        {
            var mail = new EnvioMailObject();

            Entidades.GlobalObject.ResultadoTransaccion resultado =
                mail.EnviarMailPaperlessUsuario2ConfirmacionUsuario1(PaperlessAsignacionActual);
            //Entidades.GlobalObject.ResultadoTransaccion resultado = Utils.EnvioEmail.EnviarMailPaperlessUsuario2ConfirmacionUsuario1(PaperlessAsignacionActual);

            if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Ocurrio un problema al intentar enviar el email. \n" + resultado.Descripcion,
                                "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Se ha enviado la confirmacion al Usuario de la segunda Etapa", "Paperless",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                frmListarUsuario1 form = frmListarUsuario1.Instancia;
                form.ObtenerAsignaciones();
            }
        }

        private void CargaClientes()
        {
            var configuracion = Base.Configuracion.Configuracion.Instance();
            var opcion = configuracion.GetValue("Paperless_ExcepcionesBrasil_Usuario1"); //puede retornar un true, false o null
            if (opcion.HasValue && opcion.Value.Equals(true))
            {
                if (listTargets == null)
                    listTargets = LogicaNegocios.Clientes.clsClientesMaster.ListarClienteMaster("-1", Enums.TipoPersona.Cuenta, Enums.Estado.Todos, true);
                if (listClientesPaperless == null)
                    listClientesPaperless = LogicaNegocios.Clientes.clsClientesMaster.ListarClienteMaster("-1", Enums.TipoPersona.CuentaPaperless,
                                                                                      Enums.Estado.Todos, true);
                if (clientes == null)
                    clientes = new List<clsClienteMaster>();
                if (clientes.Count.Equals(0))
                {
                    clientes.AddRange(listTargets);
                    clientes.AddRange(listClientesPaperless);
                }
            }
            else//para chile
            {
                if (listTargets == null)
                    listTargets = LogicaNegocios.Clientes.clsClientesMaster.ListarClienteMaster("-1", Enums.TipoPersona.Cuenta, Enums.Estado.Todos, true);
                if (listClientesPaperless == null)
                    listClientesPaperless = LogicaNegocios.Clientes.clsClientesMaster.ListarClienteMaster("-1", Enums.TipoPersona.CuentaPaperless,
                                                                                      Enums.Estado.Todos, true);
                if (clientes == null)
                    clientes = new List<clsClienteMaster>();
                if (clientes.Count.Equals(0))
                {
                    clientes.AddRange(listTargets);
                    clientes.AddRange(listClientesPaperless);
                }
            }
        }



        private void grdExcepciones_ShownEditor(object sender, EventArgs e)
        {
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
            var lista = foo.DataSource as IList<PaperlessExcepcion>;
            var itemSelecccionado = lista[foo.FocusedRowHandle];
            if (!itemSelecccionado.TieneExcepcion)
            {
                itemSelecccionado.TipoExcepcion = null;
                itemSelecccionado.Responsabilidad = null;
                itemSelecccionado.Comentario = String.Empty;
            }

            if (foo.FocusedColumn.FieldName.Equals("TipoExcepcion"))
            {
                if (itemSelecccionado.TieneExcepcion)
                {
                    var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                    cbo.Properties.Items.Clear();
                    foreach (var tipos in TiposDeExcepciones)
                    {
                        cbo.Properties.Items.Add(tipos);
                    }
                }
                else
                {
                    var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                    cbo.Properties.Items.Clear();
                    cbo.EditValue = null;
                    cbo.Properties.Items.Add(new PaperlessTipoExcepcion());
                }
            }

            if (foo.FocusedColumn.FieldName.Equals("Responsabilidad"))
            {
                if (itemSelecccionado.TieneExcepcion)
                {
                    var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                    cbo.Properties.Items.Clear();
                    foreach (var tipos in TiposResponsabilidad)
                        cbo.Properties.Items.Add(tipos);
                }
                else
                {
                    var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                    cbo.Properties.Items.Clear();
                    cbo.EditValue = null;
                    cbo.Properties.Items.Add(new PaperlessTipoResponsabilidad());
                }
            }
            if (foo.FocusedColumn.FieldName.Equals("Causador"))
            {
                if (itemSelecccionado.TieneExcepcion)
                {
                    var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                    cbo.Properties.Items.Clear();
                    foreach (var tipos in TiposAgenteCausador)
                        cbo.Properties.Items.Add(tipos);
                }
                else
                {
                    var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                    cbo.Properties.Items.Clear();
                    cbo.EditValue = null;
                    cbo.Properties.Items.Add(new PaperlessAgenteCausador());
                }
            }

        }


        private void sButtonAgregarDisputa_Click(object sender, EventArgs e)
        {
            var disputas = new List<PaperlessUsuario1Disputas>();
            if (GridDisputas.DataSource != null)
                disputas = GridDisputas.DataSource as List<PaperlessUsuario1Disputas>;

            disputas.Add(new PaperlessUsuario1Disputas());
            GridDisputas.DataSource = null;
            GridDisputas.DataSource = disputas;
            GridDisputas.RefreshDataSource();


        }

        private void sButtonEliminarDisputa_Click(object sender, EventArgs e)
        {
            //clsMetaObservaciones ObjObservacion = new clsMetaObservaciones();
            PaperlessUsuario1Disputas disputa;
            int fila_sel = 0;
            if (this.gridViewDisputas.DataSource != null)
            {
                if (MessageBox.Show("¿Está seguro que desea ELIMINAR la disputa?", "Sistema Comercial Craft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    fila_sel = this.gridViewDisputas.GetSelectedRows()[0];
                    disputa = (PaperlessUsuario1Disputas)this.gridViewDisputas.GetRow(fila_sel);
                    var disputas = GridDisputas.DataSource as List<PaperlessUsuario1Disputas>;
                    disputas.Remove(disputa);
                    GridDisputas.DataSource = disputas;
                    GridDisputas.RefreshDataSource();
                }
            }
        }

        private void gridViewDisputas_ShownEditor(object sender, EventArgs e)
        {
            if (TiposDisputas == null)
                TiposDisputas = (List<PaperlessTipoDisputa>)LogicaNegocios.Paperless.Paperless.ListarTiposDisputa();

            var foo = sender as GridView;
            if (foo.FocusedColumn.FieldName.Equals("TipoDisputa"))
            {
                DevExpress.XtraEditors.ComboBoxEdit cbo = (sender as DevExpress.XtraGrid.Views.Base.BaseView).ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                ComboBoxItemCollection coll = cbo.Properties.Items;
                foreach (var tipo in TiposDisputas)
                    coll.Add(tipo);
            }
        }

        private Boolean ValidateDisputas()
        {
            var disputas = new List<PaperlessUsuario1Disputas>();
            if (gridViewDisputas.DataSource != null)
                disputas = (List<PaperlessUsuario1Disputas>)gridViewDisputas.DataSource;

            foreach (var disputa in disputas)
            {
                if (String.IsNullOrEmpty(disputa.Descripcion) || disputa.Numero == null || disputa.TipoDisputa == null)
                    return false;
            }
            return true;
        }

        private void btnGuardarDisputas_Click(object sender, EventArgs e)
        {
            LabelErrorDisputa.Visible = false;
            var val = ValidateDisputas();
            if (!val)
            {
                LabelErrorDisputa.Visible = true;
            }
            else
            {
                //Guardar las disputas
                Cursor.Current = Cursors.WaitCursor;
                IList<PaperlessUsuario1Disputas> disputas = (IList<PaperlessUsuario1Disputas>)GridDisputas.DataSource;
                //PaperlessPasosEstado pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla(11);
                var pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla();
                pasoSeleccionado.Estado = true;
                var resultado = LogicaNegocios.Paperless.Paperless.Usuario1GuardaDisputas(disputas, PaperlessAsignacionActual, pasoSeleccionado);


                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CargarPasos();
                    Cursor.Current = Cursors.Default;
                    lblP1errorHouses.Visible = false;
                    MessageBox.Show("Las Disputas han sido guardadss", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //btnP1GuardarHousesBL.Enabled = false;
                }

            }
        }

        private void gridView1_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var foo = sender as GridView;
            DataRow row = foo.GetDataRow(foo.FocusedRowHandle);
            var lista = foo.DataSource as IList<PaperlessExcepcion>;
            var itemSelecccionado = lista[foo.FocusedRowHandle];

            if (foo.FocusedColumn.FieldName.Equals("Comentario"))
            {
                if (IsBrasil)
                    e.Cancel = false;
                else
                    if (itemSelecccionado.TieneExcepcion)
                    {
                        if (itemSelecccionado.TipoExcepcion != null && itemSelecccionado.TipoExcepcion.Nombre.Equals("Otros"))
                        {
                            e.Cancel = false;
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                    }
            }
        }

        private void TxtActualizarNetShip_Click_1(object sender, EventArgs e)
        {
            _mensajemostrado = false;
            IList<PaperlessUsuario1HousesBL> housesnew = new List<PaperlessUsuario1HousesBL>();

            IList<PaperlessUsuario1HousesBL> houses =
                LogicaNegocios.Paperless.Paperless.Usuario1ObtenerHousesBL(PaperlessAsignacionActual.Id);


            if (houses == null || houses.Count == 0)
            {

                for (int i = 1; i <= int.Parse(txtP1CantHouses.Text); i++)
                {
                    PaperlessUsuario1HousesBL house = new PaperlessUsuario1HousesBL();
                    house.Index = i;
                    house.IdAsignacion = PaperlessAsignacionActual.Id;
                    house.Freehand = false;
                    house.ExcepcionRecargoCollect = new PaperlessExcepcion() { RecargoCollect = false };
                    //house = IntegracionNetShip(house, i, "sp_SCC_HouseBLs");
                    house = IntegracionNetShip(house, i, "sp_SCC_HouseBLs" + "_" + DdlEmpresa.SelectedText);


                    housesnew.Add(house);
                }
            }
            else
            {
                housesnew = houses;
            }
            if (int.Parse(txtP1CantHouses.Text) > housesnew.Count)
            {
                for (int i = housesnew.Count + 1; i <= int.Parse(txtP1CantHouses.Text); i++)
                {
                    PaperlessUsuario1HousesBL house = new PaperlessUsuario1HousesBL();
                    house.Index = i;
                    house.IdAsignacion = PaperlessAsignacionActual.Id;
                    house.Freehand = false;
                    house.HouseBL = "";
                    house.ExcepcionRecargoCollect = new PaperlessExcepcion() { RecargoCollect = false };
                    housesnew.Add(house);
                }
            }

            grdP1DigitarHousesBL.DataSource = housesnew;
            grdP1DigitarHousesBL.RefreshDataSource();


            //Cargar Info Houses BL
            PaperlessUsuario1HouseBLInfo info =
                LogicaNegocios.Paperless.Paperless.Usuario1ObtenerHousesBLInfo(PaperlessAsignacionActual.Id);
            if (info != null)
            {
                txtP1CantHouses.Text = PaperlessAsignacionActual.NumHousesBL.ToString();
                txtP1NumConsolidado.Text = info.NumConsolidado;
            }
            PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL = housesnew;
            PaperlessAsignacionActual.DataUsuario1.Paso1HousesBLInfo = info;


            //if (info != null)
            //    GuardaRegLogCarga(PaperlessAsignacionActual.Id32, (info.CantHouses - _regError).ToString(), "", "Registros OK: " + (info.CantHouses - _regError));
            //GuardaRegLogCarga(PaperlessAsignacionActual.Id32, "", _regError.ToString(), "Reglas Procesadas :" + _regError);
        }

        private void GuardaRegLogCarga(Int32 idPaperless, string valorPaperless, string valorNetShip, string mensaje, Int32 idPaperlessTipoError)
        {
            IntegracionNetShip logCarga = new IntegracionNetShip();
            logCarga.IdPaperless = idPaperless;
            logCarga.ValorPaperless = valorPaperless;
            logCarga.ValorNetShip = valorNetShip;
            logCarga.Mensaje = mensaje;
            logCarga.IdPaperlessTipoError = idPaperlessTipoError;
            LogicaNegocios.Integracion.Integracion.GuardaLogProceso(logCarga);
        }

        private void txtLogCarga_Click_1(object sender, EventArgs e)
        {
            FrmPopupLogPaperlessIntegracion form = new FrmPopupLogPaperlessIntegracion(LogicaNegocios.Integracion.Integracion.ObtieneLogPaperlessNetShip(PaperlessAsignacionActual.Id32));
            if (form.ListaLogIntegracionNetShip != null)
                form.ShowDialog();
            else
                MessageBox.Show("Hubo un error al presentar el log de carga", "Sistema Comercial Craft",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private PaperlessUsuario1HousesBL IntegracionNetShip(PaperlessUsuario1HousesBL house, int i, string storeProcedureName)
        {
            try
            {
                Int32 regVarios = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("regVarios"));

                if (netShips == null || netShips.Equals(0))
                    netShips = LogicaNegocios.Integracion.Integracion.ObtenerHousesBlDesdeNetShip(PaperlessAsignacionActual.NumMaster, storeProcedureName);
                //clsClienteMaster clienteNuevo = null;

                //-debe enviar un mensaje cuando la cantidad de hoses BL sea distinta
                if (_mensajemostrado != true)
                    if (Convert.ToInt32(txtP1CantHouses.Text) != netShips.Count)
                    {

                        MessageBox.Show(@"La cantidad de Hbls :" + txtP1CantHouses.Text + @" ingresadas es distinta a la de NetShip :"
                            + netShips.Count, @"Paperless", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//@" ,Favor modifique el valor de la asignacion para no ver este mensaje"

                        GuardaRegLogCarga(PaperlessAsignacionActual.Id32, txtP1CantHouses.Text, netShips.Count.ToString(),
                            @"Existe una diferencia entre los valores de hbls", (Int32)PaperlessTipoErrorLog.PaperlessTipoError.DifValoresBls);
                        reglasAplicadas++;
                        _mensajemostrado = true;
                    }


                if (netShips.Count > 0)
                {
                    try
                    {
                        house.HouseBL = netShips[i - 1].HouseBl;//-Número BL
                        var rut = netShips[i - 1].Rut; //-Rut del Cliente.

                        var shippingInstruction = netShips[i - 1].ShippingInstruction;
                        if (shippingInstruction != null)
                            house.ShippingInstruction = shippingInstruction;

                        var port = netShips[i - 1].Puerto;
                        if (port != null)
                            house.Puerto = port;

                        if (rut != null && !string.IsNullOrEmpty(rut))
                        {
                            var cliente = netShips[i - 1].Cliente;
                            //-Si el Rut existe el sistema debe buscar en la base de datos y cargarlo con la información 
                            //que existe en el sistema para que este cliente se muestre en la pantalla de ingreso de Bls
                            house.Cliente = LogicaNegocios.Clientes.clsClientesMaster.ObtenerClienteMasterPorRut(rut);

                            #region si el rut no existe debe crear un nuevo cliente, pero de tipo paperless  con la información que actualmente está enviando NetShip
                            if (cliente != null && house.Cliente == null && !string.IsNullOrEmpty(cliente))
                            {
                                house.Cliente = CargaClientePaperlessNuevo(cliente, rut);
                                GuardaRegLogCarga(PaperlessAsignacionActual.Id32, "", rut, " Se creo el Cliente " + house.Cliente.Id32 + " con Rut :" + rut, (Int32)PaperlessTipoErrorLog.PaperlessTipoError.RutNoExiste);
                                reglasAplicadas++;
                            }

                            #endregion
                        }
                        else//-colocar el "varios" cuando el cliente no esté creado en el sistema,-si no viene rut , registro debe ser varios. 
                        {
                            house.Cliente = LogicaNegocios.Clientes.clsClientesMaster.ObtenerClienteMasterPorId(regVarios);
                            GuardaRegLogCarga(PaperlessAsignacionActual.Id32, "", "", "No viene Rut desde NetShip", (Int32)PaperlessTipoErrorLog.PaperlessTipoError.RegVarios);
                            reglasAplicadas++;
                        }


                        house.Ruteado = netShips[i - 1].Ruteado;//-Indicar si es Ruteado o no
                        var consolidada = netShips[i - 1].Consolidada;
                        if (consolidada != null)
                            txtP1NumConsolidado.Text = consolidada;//- Número Consolidado
                        else
                        {
                            GuardaRegLogCarga(PaperlessAsignacionActual.Id32, "", "", "No viene Numero de Consolidada", (Int32)PaperlessTipoErrorLog.PaperlessTipoError.SinNumeroConsolidada);
                            reglasAplicadas++;
                        }


                        #region-va a prevalecer el tipo de cliente que tenga paperless, al momento de la carga.
                        PaperlessTipoCliente ptc = ObtieneTipodeCliente(house);//-Tipo de Cliente

                        #region Agrega Tipo Cliente de la integracion si desde el ClienteMaster retorna null
                        if (ptc == null)
                        {
                            ptc = new PaperlessTipoCliente();
                            if (netShips[i - 1].TipoCliente.Equals("Directo"))
                            {
                                ptc.Nombre = "Directo";
                                ptc.Id = 2;
                            }
                            else
                            {
                                ptc.Nombre = "Embarcador";
                                ptc.Id = 1;
                            }
                        }
                        GuardaRegLogCarga(PaperlessAsignacionActual.Id32, "", ptc.Nombre, " Tipo de Cliente NetShip", (Int32)PaperlessTipoErrorLog.PaperlessTipoError.DobleDefinicionPpValorNetShip);
                        reglasConError++;
                        house.TipoCliente = ptc;
                        #endregion
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        Log.EscribirLog(ex.Message);
                    }
                }
                else
                {
                    GuardaRegLogCarga(PaperlessAsignacionActual.Id32, PaperlessAsignacionActual.NumMaster, "", "No se encontro Numero Master", (Int32)PaperlessTipoErrorLog.PaperlessTipoError.SinNumeroMaster);
                    reglasAplicadas++;
                }


            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);
            }


            return house;
        }

        private PaperlessTipoCliente ObtieneTipodeCliente(PaperlessUsuario1HousesBL house)
        {
            clsCuenta cuenta = new clsCuenta();
            PaperlessTipoCliente ptc = new PaperlessTipoCliente();
            if (house.Cliente != null)
            {
                var transaccion = LogicaNegocios.Clientes.clsCuentas.BuscarCuentaPorId(house.Cliente.Id);
                if (transaccion != null)
                {
                    cuenta = (clsCuenta)transaccion.ObjetoTransaccion;
                    if (cuenta != null && cuenta.ClienteMaster.ClienteMasterTipoCliente != null)
                    {
                        if (cuenta.ClienteMaster.ClienteMasterTipoCliente.Count.Equals(0) ||
                            cuenta.ClienteMaster.ClienteMasterTipoCliente.Count > 1)
                        {
                            house.TipoCliente = null;
                        }
                        else
                        {
                            ptc.Nombre = cuenta.ClienteMaster.ClienteMasterTipoCliente[0].Nombre;
                            ptc.Id = cuenta.ClienteMaster.ClienteMasterTipoCliente[0].Id;
                            house.TipoCliente = ptc;
                        }
                    }
                }
            }
            return house.TipoCliente;
        }

        private clsClienteMaster CargaClientePaperlessNuevo(string cliente, string rut)
        {
            clsClienteMaster ClienteNuevo = new clsClienteMaster(true)
            {
                NombreFantasia = cliente,
                NombreCompañia = cliente,
                RUT = rut,
                Tipo = Enums.TipoPersona.CuentaPaperless,
                EstadoCuenta = Enums.Estado.Habilitado
            };
            return ClienteNuevo;
        }

        private void TxtActualizarNetShipClick(object sender, EventArgs e)
        {
            if (IsBrasil)
            {
                if (DdlEmpresa.SelectedItem != null && !string.IsNullOrEmpty(DdlEmpresa.SelectedItem.ToString()))
                {
                    _mensajemostrado = false;
                    IList<PaperlessUsuario1HousesBL> housesnew = new List<PaperlessUsuario1HousesBL>();

                    IList<PaperlessUsuario1HousesBL> houses = LogicaNegocios.Paperless.Paperless.Usuario1ObtenerHousesBL(PaperlessAsignacionActual.Id);

                    if (houses == null || houses.Count == 0)
                    {
                        for (int i = 1; i <= int.Parse(txtP1CantHouses.Text); i++)
                        {
                            PaperlessUsuario1HousesBL house = new PaperlessUsuario1HousesBL();
                            house.Index = i;
                            house.IdAsignacion = PaperlessAsignacionActual.Id;
                            house.Freehand = false;
                            house.ExcepcionRecargoCollect = new PaperlessExcepcion() { RecargoCollect = false };
                            house = IntegracionNetShip(house, i, "sp_SCC_HouseBLs" + "_" + DdlEmpresa.SelectedText);

                            housesnew.Add(house);
                        }
                    }
                    else
                    {
                        housesnew = houses;
                    }
                    if (int.Parse(txtP1CantHouses.Text) > housesnew.Count)
                    {
                        for (int i = housesnew.Count + 1; i <= int.Parse(txtP1CantHouses.Text); i++)
                        {
                            PaperlessUsuario1HousesBL house = new PaperlessUsuario1HousesBL();
                            house.Index = i;
                            house.IdAsignacion = PaperlessAsignacionActual.Id;
                            house.Freehand = false;
                            house.HouseBL = "";
                            house.ExcepcionRecargoCollect = new PaperlessExcepcion() { RecargoCollect = false };
                            housesnew.Add(house);
                        }
                    }

                    grdP1DigitarHousesBL.DataSource = housesnew;
                    grdP1DigitarHousesBL.RefreshDataSource();


                    //Cargar Info Houses BL
                    PaperlessUsuario1HouseBLInfo info =
                        LogicaNegocios.Paperless.Paperless.Usuario1ObtenerHousesBLInfo(PaperlessAsignacionActual.Id);
                    if (info != null)
                    {
                        txtP1CantHouses.Text = PaperlessAsignacionActual.NumHousesBL.ToString();
                        txtP1NumConsolidado.Text = info.NumConsolidado;
                    }
                    PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL = housesnew;
                    PaperlessAsignacionActual.DataUsuario1.Paso1HousesBLInfo = info;

                    GuardaRegLogCarga(PaperlessAsignacionActual.Id32, reglasAplicadas.ToString(), reglasConError.ToString(), "Resumen Reglas Aplicadas:" + reglasAplicadas + " Error :" + reglasConError, (Int32)PaperlessTipoErrorLog.PaperlessTipoError.Resumen);
                }
            }
            else
            {
                _mensajemostrado = false;
                IList<PaperlessUsuario1HousesBL> housesnew = new List<PaperlessUsuario1HousesBL>();

                IList<PaperlessUsuario1HousesBL> houses = LogicaNegocios.Paperless.Paperless.Usuario1ObtenerHousesBL(PaperlessAsignacionActual.Id);

                if (houses == null || houses.Count == 0)
                {
                    for (int i = 1; i <= int.Parse(txtP1CantHouses.Text); i++)
                    {
                        PaperlessUsuario1HousesBL house = new PaperlessUsuario1HousesBL();
                        house.Index = i;
                        house.IdAsignacion = PaperlessAsignacionActual.Id;
                        house.Freehand = false;
                        house.ExcepcionRecargoCollect = new PaperlessExcepcion() { RecargoCollect = false };
                        //house = IntegracionNetShip(house, i, "sp_SCC_HouseBLs");
                        house = IntegracionNetShip(house, i, "sp_SCC_HouseBLs" + "_" + DdlEmpresa.SelectedText);

                        housesnew.Add(house);
                    }
                }
                else
                {
                    housesnew = houses;
                }
                if (int.Parse(txtP1CantHouses.Text) > housesnew.Count)
                {
                    for (int i = housesnew.Count + 1; i <= int.Parse(txtP1CantHouses.Text); i++)
                    {
                        PaperlessUsuario1HousesBL house = new PaperlessUsuario1HousesBL();
                        house.Index = i;
                        house.IdAsignacion = PaperlessAsignacionActual.Id;
                        house.Freehand = false;
                        house.HouseBL = "";
                        house.ExcepcionRecargoCollect = new PaperlessExcepcion() { RecargoCollect = false };
                        housesnew.Add(house);
                    }
                }

                grdP1DigitarHousesBL.DataSource = housesnew;
                grdP1DigitarHousesBL.RefreshDataSource();


                //Cargar Info Houses BL
                PaperlessUsuario1HouseBLInfo info =
                    LogicaNegocios.Paperless.Paperless.Usuario1ObtenerHousesBLInfo(PaperlessAsignacionActual.Id);
                if (info != null)
                {
                    txtP1CantHouses.Text = PaperlessAsignacionActual.NumHousesBL.ToString();
                    txtP1NumConsolidado.Text = info.NumConsolidado;
                }
                PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL = housesnew;
                PaperlessAsignacionActual.DataUsuario1.Paso1HousesBLInfo = info;

                GuardaRegLogCarga(PaperlessAsignacionActual.Id32, reglasAplicadas.ToString(), reglasConError.ToString(), "Resumen Reglas Aplicadas:" + reglasAplicadas + " Error :" + reglasConError, (Int32)PaperlessTipoErrorLog.PaperlessTipoError.Resumen);
            }

        }

        private void txtLogCarga_Click(object sender, EventArgs e)
        {
            FrmPopupLogPaperlessIntegracion form = new FrmPopupLogPaperlessIntegracion(LogicaNegocios.Integracion.Integracion.ObtieneLogPaperlessNetShip(PaperlessAsignacionActual.Id32));
            if (form.ListaLogIntegracionNetShip != null)
                form.ShowDialog();
            else
                MessageBox.Show("Hubo un error al presentar el log de carga", "Sistema Comercial Craft",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CargarExcepcionesBrasil()
        {
            var configuracion = Base.Configuracion.Configuracion.Instance();
            var opcion = configuracion.GetValue("Paperless_ExcepcionesBrasil_Usuario1"); //puede retornar un true, false o null
            if (opcion.HasValue && opcion.Value.Equals(true))
            {
                pnlExcepciones.Visible = true;
                var excepciones = LogicaNegocios.Paperless.Paperless.Usuario1ObtenerExcepciones(PaperlessAsignacionActual.Id);
                var excepcionesActualizadas = LogicaNegocios.Paperless.Paperless.RefrescarExcepciones((List<PaperlessExcepcion>)excepciones);
                grdExcepciones.DataSource = excepcionesActualizadas;
                grdP3HousesRuteados.RefreshDataSource();
            }
        }
        private void grdExcepciones_Click(object sender, EventArgs e)
        {

        }

        private void MailExcepcion_Click(object sender, EventArgs e)
        {
            var filaSelected = grdExcepciones.DefaultView.GetRow(gridView1.FocusedRowHandle);

            var x = (List<PaperlessExcepcion>)grdExcepciones.DefaultView.DataSource;
            foreach (var paperlessExcepcion in x)
            {
                if (paperlessExcepcion.TieneExcepcion)
                {
                    var mail = new EnvioMailObject();
                    Cursor.Current = Cursors.WaitCursor;

                    mail.MailEnBorrador("none@none.com", "Paperless Usuario 1 Excepciones", paperlessExcepcion.TipoExcepcion.ToString());
                }
            }
            /*
                
             if (filaSelected == null)
            {
                return null;
            }
            Entidades.Paperless.PaperlessFlujo asignacion = (Entidades.Paperless.PaperlessFlujo)filaSelected;

            return asignacion;
             */
            //  var paso = (PaperlessPasosEstado)gridView4.GetRow(gridView4.FocusedRowHandle);
            //// return paso;

            // var pasos = (IList<PaperlessPasosEstado>)grdPasos.DataSource;5

            // return pasos[numpaso - 1];

        }

        private void AgregarDetalle_Click(object sender, EventArgs e)
        {
            IList<PaperlessExcepcion> excepciones = (IList<PaperlessExcepcion>)grdExcepciones.DataSource;
            var item = new PaperlessExcepcion() { RecargoCollect = false, IdUsuarioUltimaModificacion = Base.Usuario.UsuarioConectado.Usuario.Id };

            IList<PaperlessUsuario1HousesBL> listhouses = (IList<PaperlessUsuario1HousesBL>)grdP1DigitarHousesBL.DataSource;

            //emulamos la excepcion como un house a mostrar 
            PaperlessUsuario1HousesBL house = new PaperlessUsuario1HousesBL();
            house.Index = excepciones.Count + 1;
            house.IdAsignacion = PaperlessAsignacionActual.Id;
            item.IdAsignacion = PaperlessAsignacionActual.Id;
            house.Freehand = false;
            var pasoexcepcion = Obtiene_Excepcion();
            if (pasoexcepcion != null)
            {
                house.HouseBL = pasoexcepcion.HouseBL.HouseBL;// (excObtiene_Excepcionepciones.Count + 1).ToString();

            }
            house.Id = listhouses[0].Id;
            house.ExcepcionRecargoCollect = new PaperlessExcepcion() { HouseBL = house, RecargoCollect = false, IdAsignacion = PaperlessAsignacionActual.Id };
            house.TipoCliente = new PaperlessTipoCliente { Id = 1 };


            item.HouseBL = house;
            excepciones.Add(item);

            PaperlessPasosEstado paso = ObtenerPasoSeleccionado();
            Entidades.GlobalObject.ResultadoTransaccion resultado = LogicaNegocios.Paperless.Paperless.Usuario1IngresarExcepxiones(excepciones, paso);

            grdExcepciones.DataSource = excepciones;
            grdExcepciones.RefreshDataSource();

        }

        private void sButtonEliminarTrafico_Click(object sender, EventArgs e)
        {
            LogicaNegocios.Paperless.Paperless.Usuario1EliminaExcepxion(Obtiene_Excepcion(), Base.Usuario.UsuarioConectado.Usuario.Id);
            var excepciones = LogicaNegocios.Paperless.Paperless.Usuario1ObtenerExcepciones(PaperlessAsignacionActual.Id);
            var excepcionesActualizadas = LogicaNegocios.Paperless.Paperless.RefrescarExcepciones((List<PaperlessExcepcion>)excepciones);
            grdExcepciones.DataSource = excepcionesActualizadas;
            grdP3HousesRuteados.RefreshDataSource();
        }

        private void pnlExcepciones_Paint(object sender, PaintEventArgs e)
        {

        }

        private PaperlessExcepcion Obtiene_Excepcion()
        {
            var paso = (PaperlessExcepcion)gridView1.GetRow(gridView1.FocusedRowHandle);//grdExcepciones
            return paso;
        }
        private void LimpiaColumnasGrdExepciones(object sender)
        {
            var foo = sender as GridView;
            DataRow row = foo.GetDataRow(foo.FocusedRowHandle);
            var lista = foo.DataSource as IList<PaperlessExcepcionMaster>;
            var itemSelecccionado = lista[foo.FocusedRowHandle];
            if (!itemSelecccionado.TieneExcepcion)
            {
                itemSelecccionado.TipoExcepcion = null;
                itemSelecccionado.Tiporesponsabilidad = null;
                itemSelecccionado.Comentario = String.Empty;
            }

        }

        private void grdExcepcionesMaster_ShownEditor(object sender, EventArgs e)
        {
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
            if (!itemSelecccionado.TieneExcepcion)
            {
                itemSelecccionado.TipoExcepcion = null;
                itemSelecccionado.Tiporesponsabilidad = null;
                itemSelecccionado.Comentario = String.Empty;
            }



            if (foo.FocusedColumn.FieldName.Equals("TipoExcepcion"))
            {
                if (itemSelecccionado.TieneExcepcion)
                {
                    var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                    cbo.Properties.Items.Clear();
                    foreach (var tipos in TiposDeExcepciones)
                    {
                        cbo.Properties.Items.Add(tipos);
                    }

                }
                else
                {
                    var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                    cbo.Properties.Items.Clear();
                    cbo.EditValue = null;
                    cbo.Properties.Items.Add(new PaperlessTipoExcepcion());
                }
            }

            if (foo.FocusedColumn.FieldName.Equals("Tiporesponsabilidad"))
            {
                if (itemSelecccionado.TieneExcepcion)
                {
                    var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                    cbo.Properties.Items.Clear();
                    foreach (var tipos in TiposResponsabilidad)
                        cbo.Properties.Items.Add(tipos);
                }
                else
                {
                    var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                    cbo.Properties.Items.Clear();
                    cbo.EditValue = null;
                    cbo.Properties.Items.Add(new PaperlessTipoResponsabilidad());
                }
            }
            if (foo.FocusedColumn.FieldName.Equals("AgenteCausador"))
            {
                if (itemSelecccionado.TieneExcepcion)
                {
                    var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                    cbo.Properties.Items.Clear();
                    foreach (var tipos in TiposAgenteCausador)
                        cbo.Properties.Items.Add(tipos);
                }
                else
                {
                    var cbo = foo.ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                    cbo.Properties.Items.Clear();
                    cbo.EditValue = null;
                    cbo.Properties.Items.Add(new PaperlessAgenteCausador());
                }
            }

        }


        private bool validarPasoExcepcionesMaster(List<PaperlessExcepcionMaster> excepciones)
        {
            foreach (PaperlessExcepcionMaster excepcion in excepciones)
            {
                if (!IsBrasil)
                {
                    if (excepcion.TieneExcepcion && (excepcion.TipoExcepcion == null || excepcion.Tiporesponsabilidad == null))
                        return false;
                }
                else
                    if (excepcion.TieneExcepcion)
                    {
                        //if (excepcion.Tiporesponsabilidad.Nombre.Equals("Usuario 1") && !excepcion.Resuelto)
                        //{
                        //    MessageBox.Show(@"Las Excepciones de Responsabilidad Usuario 1 deben quedar Resueltas", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    return false;
                        //}

                    }
            }
            return true;
        }
        public void RegistrarExcepcionesMaster(PaperlessPasosEstado paso)
        {
            _pasoEstadoActual = paso;
            var excepciones = LogicaNegocios.Paperless.Paperless.Usuario1ObtenerExcepcionesMaster(PaperlessAsignacionActual.Id);
            //var excepcionesActualizadas = LogicaNegocios.Paperless.Paperless.RefrescarExcepciones((List<PaperlessExcepcion>)excepciones);
            if (excepciones.Count.Equals(0))
            {
                var excepMaster = new PaperlessExcepcionMaster();
                excepMaster.IdAsignacion = _asignacion.Id;
                excepMaster.Index = 1;
                excepciones.Add(excepMaster);
            }

            GrdExcepcionMaster.DataSource = excepciones;
            GrdExcepcionMaster.RefreshDataSource();

            PanelExcepMaster.Visible = true;
            BtnEliminarExcepMaster.Visible = true;
            BtnAgregarExcepMaster.Visible = true;
        }

        private PaperlessExcepcionMaster Obtiene_ExcepcionMaster()
        {
            var paso = (PaperlessExcepcionMaster)gridView8.GetRow(gridView8.FocusedRowHandle);//grdExcepciones
            return paso;
        }

        private void BtnAgregarExcepMaster_Click_1(object sender, EventArgs e)
        {
            IList<PaperlessExcepcionMaster> excepciones = (IList<PaperlessExcepcionMaster>)GrdExcepcionMaster.DataSource;
            var excepMaster = new PaperlessExcepcionMaster();
            excepMaster.IdAsignacion = _asignacion.Id;
            excepMaster.Index = excepciones.Count + 1;
            excepciones.Add(excepMaster);

            GrdExcepcionMaster.DataSource = excepciones;
            GrdExcepcionMaster.RefreshDataSource();
        }

        private void BtnEliminarExcepMaster_Click_1(object sender, EventArgs e)
        {
            var excepA_Eliminar = Obtiene_ExcepcionMaster();
            if (excepA_Eliminar != null)
                LogicaNegocios.Paperless.Paperless.Usuario1EliminaExcepxionMaster(excepA_Eliminar, Base.Usuario.UsuarioConectado.Usuario.Id);
            var excepciones = LogicaNegocios.Paperless.Paperless.Usuario1ObtenerExcepcionesMaster(PaperlessAsignacionActual.Id);

            GrdExcepcionMaster.DataSource = excepciones;
            GrdExcepcionMaster.RefreshDataSource();
        }

        private void btnGuardarExcepcionMaster_Click_1(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla();

                if (!ValidarPermiteCambiarPasoEstado(pasoSeleccionado))
                    return;

                IList<PaperlessExcepcionMaster> excepciones = (IList<PaperlessExcepcionMaster>)GrdExcepcionMaster.DataSource;

                foreach (var pExcepcionMaster in excepciones)
                {
                    if (pExcepcionMaster.TieneExcepcion)
                    {

                        if (pExcepcionMaster.TipoExcepcion == null || pExcepcionMaster.TipoExcepcion.ToString().Equals(""))
                        {
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show(@"Seleccione tipo Excepcion", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (pExcepcionMaster.AgenteCausador == null || pExcepcionMaster.AgenteCausador.ToString().Equals(""))
                        {
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show(@"Seleccione Agente Causador", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (pExcepcionMaster.Tiporesponsabilidad == null || pExcepcionMaster.Tiporesponsabilidad.ToString().Equals(""))
                        {
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show(@"Seleccione tipo Responsabilidad", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (pExcepcionMaster.Tiporesponsabilidad != null && pExcepcionMaster.Tiporesponsabilidad.ToString().Equals("Usuario 2") && pExcepcionMaster.Resuelto)
                        {
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show(@"El Usuario 1 no puede resolver excepciones del Usuario 2", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                pasoSeleccionado.Estado = true;
                Entidades.GlobalObject.ResultadoTransaccion resultado = LogicaNegocios.Paperless.Paperless.Usuario1IngresarExcepxionesMaster(excepciones, pasoSeleccionado);

                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CargarPasos();
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Excepciones han sido guardadas", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //btnP11Excepciones.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Log.log.Error(ex);
                throw ex;
            }
        }
    }
}