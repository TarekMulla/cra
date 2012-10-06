using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Clientes.Cuenta;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Paperless;
using ProyectoCraft.WinForm.Controles;
using SCCMultimodal.Paperless.Usuario1;
using SCCMultimodal.Utils;

namespace ProyectoCraft.WinForm.Paperless.Usuario1 {
    public partial class frmPaperlessUser1v2 : Form, IFrmPaperlessUser1 {
        public frmPaperlessUser1v2() {
            InitializeComponent();
        }
        private IList<clsClienteMaster> listTargets = null;
        private IList<clsClienteMaster> listClientesPaperless = null;
        private List<clsClienteMaster> clientes = null;
        private List<PaperlessTipoTransito> TiposTransitoTransbordo = null;
        private List<PaperlessTipoExcepcion> TiposDeExcepciones;
        private List<PaperlessTipoResponsabilidad> TiposResponsabilidad;
        private List<PaperlessTipoDisputa> TiposDisputas;

        private static frmPaperlessUser1v2 _instancia;
        public static frmPaperlessUser1v2 Instancia {
            get {
                if (_instancia == null)
                    _instancia = new frmPaperlessUser1v2();

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


        private void loadGeneralInfo() {
            TiposTransitoTransbordo = (List<PaperlessTipoTransito>)LogicaNegocios.Paperless.Paperless.ListarTiposTransitoTransbordo();
            TiposDeExcepciones = (List<PaperlessTipoExcepcion>)LogicaNegocios.Paperless.Paperless.ListarTiposExcepciones();
            TiposResponsabilidad = LogicaNegocios.Paperless.Paperless.ListarTiposResponsabilidad();
            TiposDisputas = (List<PaperlessTipoDisputa>)LogicaNegocios.Paperless.Paperless.ListarTiposDisputa();
        }

        private void frmPaperlessUser1_Load(object sender, EventArgs e) {
            EstadoPaperless control = new EstadoPaperless();
            panel1.Controls.Add(control);
            loadGeneralInfo();
            CargarPasos();
            CargarClientesExistentesHousesBL();

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

        private void ValidarAccion() {
            if (Accion == Enums.TipoAccionFormulario.Consultar) {
                btnP1GuardarHousesBL.Visible = false;
                btnP2GuardarHousesRuteados.Visible = false;
                btnP11Excepciones.Visible = false;
                btnP13EnviarAviso.Visible = false;
                btnGuardarDisputas.Visible = false;

            }
        }

        protected void RecargarPasos(object sender, EventArgs e) {
            PaperlessPasosEstado paso = ObtenerPasoSeleccionado();
            if (paso.Paso.NumPaso == 11) {
                if (PaperlessAsignacionActual.Estado == Enums.EstadoPaperless.EnviadoUsuario2 ||
                    PaperlessAsignacionActual.Estado == Enums.EstadoPaperless.EnProcesoUsuario2 ||
                    PaperlessAsignacionActual.Estado == Enums.EstadoPaperless.ProcesoTerminado)
                    btnReenviarAvisoUsuario2.Visible = true;
            }

            CargarPasos();
        }

        protected void MarcarCambioEstadoPaso(object sender, EventArgs e) {
            DevExpress.XtraEditors.CheckEdit check = sender as DevExpress.XtraEditors.CheckEdit;
            if (check == null) return;

            PaperlessPasosEstado paso = ObtenerPasoSeleccionado();

            if (paso.Paso.NumPaso == 1 || paso.Paso.NumPaso == 2 || paso.Paso.NumPaso == 6 || paso.Paso.NumPaso == 11) {
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
            Entidades.GlobalObject.ResultadoTransaccion resultado = LogicaNegocios.Paperless.Paperless.Usuario1CambiarEstadoPaso(paso);
            if (resultado.Estado == Enums.EstadoTransaccion.Rechazada) {
                MessageBox.Show("Error al cambiar estado del paso. \n" + resultado.Descripcion, "Paperless",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                CargarPasos();
            }
        }

        public void LimpiarFormulario() {
            LimparFormularioPaso1();
        }

        private void LimparFormularioPaso1() {
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

        private void CargarClientesExistentesHousesBL() {
            CargaClientes();
            ComboBoxItemCollection coll = ddlP1Cliente.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in clientes) {
                coll.Add(list);
            }
            ddlP1Cliente.SelectedIndex = 0;
        }

        protected void MarcarPaso(object sender, CustomRowCellEditEventArgs e) {
            pnlPaso1.Visible = false;
            pnlPaso3.Visible = false;
            pnlExcepciones.Visible = false;
            pnlEnviarAviso.Visible = false;
            panelDisputas.Visible = false;
            var foo = LogicaNegocios.Paperless.Paperless.ListarPasosEstadoUsuario1V2(PaperlessAsignacionActual.Id);


            if (e.RowHandle == 0) {
                pnlPaso1.Visible = true;
                /*if (foo[0].Estado) {
                    btnP1GuardarHousesBL.Enabled = false;
                    gridView5.OptionsBehavior.Editable = false;
                }*/
            }

            if (e.RowHandle == 1) {
                /*if (foo[1].Estado) {
                    btnP2GuardarHousesRuteados.Enabled = false;
                    gridView3.OptionsBehavior.Editable = false;
                }*/
                if (foo[0].Estado) {
                    CargarPaso2TransitoTransbordo();
                    pnlPaso3.Visible = true;
                }
            }
            if (e.RowHandle == 5) {
                /*if (foo[5].Estado) {
                    btnP11Excepciones.Enabled = false;
                    gridView1.OptionsBehavior.Editable = false;
                } else {
                    gridView1.OptionsBehavior.Editable = true;
                    btnP11Excepciones.Enabled = true;
                }*/

                if (foo[4].Estado) {
                    CargarPaso6Excepciones();
                    pnlExcepciones.Visible = true;
                }
            }

            if (e.RowHandle == 9)
                if (foo[8].Estado) {
                    CargarPasoDisputa();
                }

            if (e.RowHandle == 10)
                if (foo[9].Estado) {
                    pnlEnviarAviso.Visible = true;
                }
        }

        private void CargarPasoDisputa() {
            panelDisputas.Visible = true;
            var disputas = LogicaNegocios.Paperless.Paperless.ObtieneDisputas(PaperlessAsignacionActual);
            GridDisputas.DataSource = disputas;
            GridDisputas.RefreshDataSource();   
        }

        private void CargarPaso2TransitoTransbordo() {
            var houses = LogicaNegocios.Paperless.Paperless.RefrescarTiposTransitoTransbordo((List<PaperlessUsuario1HousesBL>)PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL);
            grdP3HousesRuteados.DataSource = houses;
            grdP3HousesRuteados.RefreshDataSource();
        }

        private void CargarPaso6Excepciones() {
            var excepciones = LogicaNegocios.Paperless.Paperless.Usuario1ObtenerExcepciones(PaperlessAsignacionActual.Id);
            var excepcionesActualizadas = LogicaNegocios.Paperless.Paperless.RefrescarExcepciones((List<PaperlessExcepcion>)excepciones);
            grdExcepciones.DataSource = excepcionesActualizadas;
            grdP3HousesRuteados.RefreshDataSource();
        }

        private void CargarPasos() {
            var pasos =
                LogicaNegocios.Paperless.Paperless.ListarPasosEstadoUsuario1V2(PaperlessAsignacionActual.Id);
            grdPasos.DataSource = pasos;
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

        public Entidades.GlobalObject.ResultadoTransaccion PrepararPasos() {
            PaperlessProcesoRegistroTiempo inicio = new PaperlessProcesoRegistroTiempo();
            inicio.IdAsignacion = PaperlessAsignacionActual.Id;
            inicio.ComienzoUsuario1 = DateTime.Now;


            Entidades.GlobalObject.ResultadoTransaccion resultado =
                LogicaNegocios.Paperless.Paperless.PreparaPasosUsuario1(PaperlessAsignacionActual, inicio);

            if (resultado.Estado == Enums.EstadoTransaccion.Aceptada) {
                PaperlessAsignacionActual.Estado = Enums.EstadoPaperless.EnProcesoUsuario1;
                resultado = LogicaNegocios.Paperless.Paperless.CambiaEstadoAsignacion(PaperlessAsignacionActual);
            }

            return resultado;
        }

        public void CargarInformacionAsignacionInicial() {
            txtP1CantHouses.Text = PaperlessAsignacionActual.NumHousesBL.ToString();
        }

        public void MyShowDialog() {
            ShowDialog();
        }

        private void frmPaperlessUser1_Leave(object sender, EventArgs e) {
            Instancia = null;
        }

        private void MenuSalir_Click(object sender, EventArgs e) {
            frmListarUsuario1 form = frmListarUsuario1.Instancia;
            form.ObtenerAsignaciones();

            Instancia = null;
            Close();
        }

        private void CargarPaso1HousesBL() {
            IList<PaperlessUsuario1HousesBL> housesnew = new List<PaperlessUsuario1HousesBL>();

            IList<PaperlessUsuario1HousesBL> houses =
                LogicaNegocios.Paperless.Paperless.Usuario1ObtenerHousesBL(PaperlessAsignacionActual.Id);

            if (houses == null || houses.Count == 0) {
                //generar items para houses

                for (int i = 1; i <= int.Parse(txtP1CantHouses.Text); i++) {
                    PaperlessUsuario1HousesBL house = new PaperlessUsuario1HousesBL();
                    house.Index = i;
                    house.IdAsignacion = PaperlessAsignacionActual.Id;
                    house.Freehand = false;
                    house.HouseBL = "";
                    house.ExcepcionRecargoCollect = new PaperlessExcepcion() { RecargoCollect = false };
                    housesnew.Add(house);
                }
            } else {
                housesnew = houses;
            }
            if (int.Parse(txtP1CantHouses.Text) > housesnew.Count) {
                for (int i = housesnew.Count + 1; i <= int.Parse(txtP1CantHouses.Text); i++) {
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
            if (info != null) {
                txtP1CantHouses.Text = PaperlessAsignacionActual.NumHousesBL.ToString();
                txtP1NumConsolidado.Text = info.NumConsolidado;
            }
            PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL = housesnew;
            PaperlessAsignacionActual.DataUsuario1.Paso1HousesBLInfo = info;

        }

        private void grdP1DigitarHousesBL_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyValue == 13) {

            }
        }

        private PaperlessPasosEstado ObtenerPasoSeleccionado() {
            var filaSelected = grdPasos.DefaultView.GetRow(gridView4.FocusedRowHandle);

            if (filaSelected == null) {
                return null;
            }

            PaperlessPasosEstado housesbl = (PaperlessPasosEstado)filaSelected;

            return housesbl;
        }

        private bool ValidarHousesBLInfo() {
            bool valida = true;

            dxErrorProvider1.ClearErrors();
            if (txtP1CantHouses.Text.Length.Equals(0)) {
                dxErrorProvider1.SetError(txtP1CantHouses, "Debe ingresar Cantidad de Houses", ErrorType.Critical);
                valida = false;
            }

            if (txtP1NumConsolidado.Text.Length.Equals(0)) {
                dxErrorProvider1.SetError(txtP1NumConsolidado, "Debe ingresar numero de consolidado", ErrorType.Critical);
                valida = false;
            } else {
                if (LogicaNegocios.Paperless.Paperless.ValidaNumConsolidado(txtP1NumConsolidado.Text).Equals(true)) {
                    dxErrorProvider1.SetError(txtP1NumConsolidado, "Ya existe el numero de consolidado", ErrorType.Critical);
                    return false;
                }
                dxErrorProvider1.ClearErrors();
            }

            IList<PaperlessUsuario1HousesBL> listhouses = (IList<PaperlessUsuario1HousesBL>)grdP1DigitarHousesBL.DataSource;
            foreach (var house in listhouses) {
                if (house.HouseBL.Trim().Length.Equals(0) || house.Cliente == null || house.TipoCliente == null || house.TipoCliente.Id.Equals(0)) {
                    lblP1errorHouses.Visible = true;
                    valida = false;
                    break;
                }
            }

            return valida;
        }

        private PaperlessUsuario1HouseBLInfo Usuario1ObtenerHousesBLInfo() {
            PaperlessUsuario1HouseBLInfo info = new PaperlessUsuario1HouseBLInfo();

            info.CantHouses = Convert.ToInt16(txtP1CantHouses.Text);
            info.IdAsignacion = PaperlessAsignacionActual.Id;
            info.NumConsolidado = txtP1NumConsolidado.Text;
            return info;
        }

        private PaperlessPasosEstado ObtenerPasoSelccionadoDesdeGrilla(int numpaso) {
            IList<PaperlessPasosEstado> pasos = (IList<PaperlessPasosEstado>)grdPasos.DataSource;

            return pasos[numpaso - 1];

        }

        private void btnP1GuardarHousesBL_Click(object sender, EventArgs e) {
            if (!ValidarHousesBLInfo()) return;

            Cursor.Current = Cursors.WaitCursor;
            IList<PaperlessUsuario1HousesBL> listhouses = (IList<PaperlessUsuario1HousesBL>)grdP1DigitarHousesBL.DataSource;
            PaperlessPasosEstado pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla(1);
            pasoSeleccionado.Estado = true;
            PaperlessUsuario1HouseBLInfo info = Usuario1ObtenerHousesBLInfo();
            var resultado = LogicaNegocios.Paperless.Paperless.Usuario1GuardaHousesBL(listhouses, info, pasoSeleccionado);
            PaperlessAsignacionActual.DataUsuario1.Paso1HousesBLInfo = info;
            PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL = listhouses;

            if (resultado.Estado == Enums.EstadoTransaccion.Rechazada) {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                LogicaNegocios.Paperless.Paperless.Usuario1MarcarHousesRuteados(listhouses, pasoSeleccionado);

                CargarPasos();
                Cursor.Current = Cursors.Default;
                lblP1errorHouses.Visible = false;
                MessageBox.Show("Houses han sido guardados", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnP1GuardarHousesBL.Enabled = false;

            }
        }

        private void btnP2GuardarHousesRuteados_Click(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            lblErrorPaso2.Hide();
            IList<PaperlessUsuario1HousesBL> listhouses = (IList<PaperlessUsuario1HousesBL>)grdP3HousesRuteados.DataSource;
            PaperlessPasosEstado pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla(2);

            if (!ValidarPermiteCambiarPasoEstado(pasoSeleccionado))
                return;

            //Validacion para que se ingresen todos los tipo de transbordos
            /*if (listhouses.Any(house => house.TransbordoTransito == null || house.TransbordoTransito.Id == 0)) {
                lblErrorPaso2.Show();
                return;
            }*/

            pasoSeleccionado.Estado = true;

            //Entidades.GlobalObject.ResultadoTransaccion resultado = LogicaNegocios.Paperless.Paperless.Usuario1MarcarHousesRuteados(listhouses, pasoSeleccionado);
            Entidades.GlobalObject.ResultadoTransaccion resultado = LogicaNegocios.Paperless.Paperless.Usuario1GuardarTipoTransito(listhouses, pasoSeleccionado);


            PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL = listhouses;

            if (resultado.Estado == Enums.EstadoTransaccion.Rechazada) {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                CargarPasos();
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Transbordos y transistos han sido guardados", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnP2GuardarHousesRuteados.Enabled = false;
            }

        }

        private void gridView5_ShownEditor(object sender, EventArgs e) {
            var foo = sender as GridView;

            if (foo.FocusedColumn.FieldName.Equals("Cliente.NombreFantasia")) {
                DevExpress.XtraEditors.TextEdit txt = (sender as DevExpress.XtraGrid.Views.Base.BaseView).ActiveEditor as DevExpress.XtraEditors.TextEdit;

                if (txt.MaskBox.AutoCompleteCustomSource.Count == 0) {
                    txt.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txt.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txt.MaskBox.AutoCompleteCustomSource = GetClientes(txt);
                }
            }

            if (foo.FocusedColumn.FieldName.Equals("TipoCliente.Nombre")) {
                DevExpress.XtraEditors.ComboBoxEdit cbo = (sender as DevExpress.XtraGrid.Views.Base.BaseView).ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                ComboBoxItemCollection coll = cbo.Properties.Items;

                foreach (var tipo in Paso1CargarClientes()) {
                    coll.Add(tipo);
                }
            }
            if (foo.FocusedColumn.FieldName.Equals("TransbordoTransito")) {
                DevExpress.XtraEditors.ComboBoxEdit cbo = (sender as DevExpress.XtraGrid.Views.Base.BaseView).ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                ComboBoxItemCollection coll = cbo.Properties.Items;
                foreach (var tipo in TiposTransitoTransbordo) {
                    coll.Add(tipo);
                }
            }


        }

        private IList<PaperlessTipoCliente> Paso1CargarClientes() {

            IList<PaperlessTipoCliente> tipos =
                LogicaNegocios.Paperless.Paperless.ListarTiposCliente(Enums.Estado.Habilitado);

            return tipos;
        }

        private AutoCompleteStringCollection GetClientes(DevExpress.XtraEditors.TextEdit txt) {
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

        private void gridView5_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e) {
            DevExpress.XtraGrid.Views.Base.ColumnView columna = sender as DevExpress.XtraGrid.Views.Base.ColumnView;
            string nomcliente = "";
            clsCuenta cuenta = new clsCuenta();
            clsClienteMaster clienteselecccionado = new clsClienteMaster(false);


            if (e.Column.FieldName == "Cliente.NombreFantasia") {
                nomcliente = columna.EditingValue.ToString();

                //Console.WriteLine("nomCliente--->"+nomcliente);
                if (nomcliente.Trim() != "") {
                    ddlP1Cliente.SelectedIndex = 0;
                    for (int i = 0; i < ddlP1Cliente.Properties.Items.Count; i++) {
                        if (ddlP1Cliente.Properties.Items[i].ToString().Trim() == nomcliente.Trim()) {
                            ddlP1Cliente.SelectedIndex = i;
                            break;
                        }
                    }
                    //Console.WriteLine("index seleccionado--->" + ddlP1Cliente.SelectedIndex);

                    if (ddlP1Cliente.SelectedIndex == 0) {
                        clienteselecccionado = new clsClienteMaster(true)
                                                   {
                                                       NombreFantasia = columna.EditingValue.ToString(),
                                                       NombreCompañia = columna.EditingValue.ToString(),
                                                       Tipo = Enums.TipoPersona.CuentaPaperless,
                                                       EstadoCuenta = Enums.Estado.Habilitado
                                                   };
                        PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL[e.RowHandle].TipoCliente = null;
                    } else {
                        clienteselecccionado = (clsClienteMaster)this.ddlP1Cliente.SelectedItem;
                        if (clienteselecccionado.Id != 0) {
                            PaperlessTipoCliente ptc = new PaperlessTipoCliente();

                            var transaccion = LogicaNegocios.Clientes.clsCuentas.BuscarCuentaPorId(clienteselecccionado.Id);
                            if (transaccion != null) {
                                cuenta = (clsCuenta)transaccion.ObjetoTransaccion;
                                if (cuenta != null && cuenta.ClienteMaster.ClienteMasterTipoCliente != null) {
                                    if (cuenta.ClienteMaster.ClienteMasterTipoCliente.Count.Equals(0) ||
                                        cuenta.ClienteMaster.ClienteMasterTipoCliente.Count > 1) {
                                        PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL[e.RowHandle].TipoCliente = null;
                                    } else {
                                        ptc.Nombre = cuenta.ClienteMaster.ClienteMasterTipoCliente[0].Nombre;
                                        ptc.Id = cuenta.ClienteMaster.ClienteMasterTipoCliente[0].Id;
                                        PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL[e.RowHandle].TipoCliente = ptc;
                                    }
                                } else {
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

            if (e.Column.FieldName == "TipoCliente.Nombre") {
                PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL[e.RowHandle].TipoCliente =
                    (PaperlessTipoCliente)columna.EditingValue;
            }
        }


        private bool validarPasoExcepciones(List<PaperlessExcepcion> excepciones) {
            foreach (PaperlessExcepcion excepcion in excepciones)
                if (excepcion.TieneExcepcion && (excepcion.TipoExcepcion == null || excepcion.Responsabilidad == null))
                    return false;
            return true;
        }

        private void btnP11Excepciones_Click(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;

            PaperlessPasosEstado pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla(6);

            if (!ValidarPermiteCambiarPasoEstado(pasoSeleccionado))
                return;

            pasoSeleccionado.Estado = true;

            IList<PaperlessExcepcion> excepciones = (IList<PaperlessExcepcion>)grdExcepciones.DataSource;
            if (!validarPasoExcepciones((List<PaperlessExcepcion>)excepciones)) {
                lblP11ErrorExcepcion.Visible = true;
                return;
            } else {
                lblP11ErrorExcepcion.Visible = false;
            }

            //lblP11ErrorExcepcion

            Entidades.GlobalObject.ResultadoTransaccion resultado =
                LogicaNegocios.Paperless.Paperless.Usuario1IngresarExcepxionesV2(excepciones, pasoSeleccionado);


            PaperlessAsignacionActual.DataUsuario1.Excepciones = excepciones;

            if (resultado.Estado == Enums.EstadoTransaccion.Rechazada) {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                CargarPasos();
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Excepciones han sido guardadas", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnP11Excepciones.Enabled = false;
            }
        }

        private void gridView4_RowStyle(object sender, RowStyleEventArgs e) {
            GridView View = sender as GridView;

            if (e.RowHandle >= 0) {
                var estado2 = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["Estado"]));
                e.Appearance.ForeColor = estado2 ? Color.Green : Color.Red;
            }
        }

        private void btnP13EnviarAviso_Click(object sender, EventArgs e) {
            if (!validarCicloCompleto())
                return;
            var mail = new EnvioMailObject();
            Cursor.Current = Cursors.WaitCursor;

            PaperlessPasosEstado pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla(11);

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

            Entidades.GlobalObject.ResultadoTransaccion resultado = LogicaNegocios.Paperless.Paperless.Usuario1CambiarEstadoPaso_CambiarEstadoAsignacion(pasoSeleccionado, PaperlessAsignacionActual, tiempotermino, iniciousuario2);
            if (resultado.Estado == Enums.EstadoTransaccion.Rechazada) {
                Cursor.Current = Cursors.Default;

                MessageBox.Show("Error al cambiar estado del paso. \n" + resultado.Descripcion, "Paperless",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                resultado = mail.EnviarMailPaperlessUsuario2ConfirmacionUsuario1(PaperlessAsignacionActual);
                //resultado = Utils.EnvioEmail.EnviarMailPaperlessUsuario2ConfirmacionUsuario1(PaperlessAsignacionActual);

                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada) {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Ocurrio un problema al intentar enviar el email. \n" + resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Se ha enviado la confirmacion al Usuario de la segunda Etapa", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    frmListarUsuario1 form = frmListarUsuario1.Instancia;
                    form.ObtenerAsignaciones();
                }

                CargarPasos();
            }
            Cursor.Current = Cursors.Default;
        }

        private bool validarCicloCompleto() {
            var numHouses = PaperlessAsignacionActual.NumHousesBL;
            if (LogicaNegocios.Paperless.Paperless.Usuario1ObtenerHousesBL(PaperlessAsignacionActual.Id).Count != numHouses) {
                MessageBox.Show("Falta informacion, debe ingresar al paso 'ingreso de datos'");
                return false;
            }

            var houses = LogicaNegocios.Paperless.Paperless.RefrescarTiposTransitoTransbordo((List<PaperlessUsuario1HousesBL>)PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL);
            if (houses.Any(house => house.TransbordoTransito == null || house.TransbordoTransito.Id == 0)) {
                MessageBox.Show("Falta informacion, debe ingresar al paso 'crear Manifiesto'");
                return false;
            }

            var excepciones = LogicaNegocios.Paperless.Paperless.Usuario1ObtenerExcepciones(PaperlessAsignacionActual.Id);
            var excepcionesActualizadas = LogicaNegocios.Paperless.Paperless.RefrescarExcepciones((List<PaperlessExcepcion>)excepciones);
            if (!validarPasoExcepciones((List<PaperlessExcepcion>)excepcionesActualizadas)) {
                MessageBox.Show("Falta informacion, debe ingresar al paso 'crear Manifiesto'");
                return false;
            }


            return true;
        }

        private void frmPaperlessUser1_FormClosed(object sender, FormClosedEventArgs e) {
            Instancia = null;
            frmListarUsuario1 form = frmListarUsuario1.Instancia;
            form.ObtenerAsignaciones();
        }

        private void btnReenviarAvisoUsuario2_Click(object sender, EventArgs e) {
            var mail = new EnvioMailObject();

            Entidades.GlobalObject.ResultadoTransaccion resultado = mail.EnviarMailPaperlessUsuario2ConfirmacionUsuario1(PaperlessAsignacionActual);
            //Entidades.GlobalObject.ResultadoTransaccion resultado = Utils.EnvioEmail.EnviarMailPaperlessUsuario2ConfirmacionUsuario1(PaperlessAsignacionActual);

            if (resultado.Estado == Enums.EstadoTransaccion.Rechazada) {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Ocurrio un problema al intentar enviar el email. \n" + resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Se ha enviado la confirmacion al Usuario de la segunda Etapa", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                frmListarUsuario1 form = frmListarUsuario1.Instancia;
                form.ObtenerAsignaciones();
            }
        }

        private void CargaClientes() {
            if (listTargets == null)
                listTargets = LogicaNegocios.Clientes.clsClientesMaster.ListarClienteMaster("-1", Enums.TipoPersona.Cuenta, Enums.Estado.Todos, true);
            if (listClientesPaperless == null)
                listClientesPaperless = LogicaNegocios.Clientes.clsClientesMaster.ListarClienteMaster("-1", Enums.TipoPersona.CuentaPaperless,
                                                                                  Enums.Estado.Todos, true);
            if (clientes == null)
                clientes = new List<clsClienteMaster>();
            if (clientes.Count.Equals(0)) {
                clientes.AddRange(listTargets);
                clientes.AddRange(listClientesPaperless);
            }
        }

        private void grdExcepciones_Click(object sender, EventArgs e) {

        }

        private void grdExcepciones_ShownEditor(object sender, EventArgs e) {
            var foo = sender as GridView;
            DataRow row = foo.GetDataRow(foo.FocusedRowHandle);
            var lista = foo.DataSource as IList<PaperlessExcepcion>;
            var itemSelecccionado = lista[foo.FocusedRowHandle];
            if (!itemSelecccionado.TieneExcepcion) {
                itemSelecccionado.TipoExcepcion = null;
                itemSelecccionado.Responsabilidad = null;
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

            if (foo.FocusedColumn.FieldName.Equals("Responsabilidad")) {
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
        }

        private void sButtonAgregarDisputa_Click(object sender, EventArgs e) {
            var disputas = new List<PaperlessUsuario1Disputas>();
            if (GridDisputas.DataSource != null)
                disputas = GridDisputas.DataSource as List<PaperlessUsuario1Disputas>;

            disputas.Add(new PaperlessUsuario1Disputas());
            GridDisputas.DataSource = null;
            GridDisputas.DataSource = disputas;
            GridDisputas.RefreshDataSource();


        }

        private void sButtonEliminarDisputa_Click(object sender, EventArgs e) {
            //clsMetaObservaciones ObjObservacion = new clsMetaObservaciones();
            PaperlessUsuario1Disputas disputa;
            int fila_sel = 0;
            if (this.gridViewDisputas.DataSource != null) {
                if (MessageBox.Show("¿Está seguro que desea ELIMINAR la disputa?", "Sistema Comercial Craft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    fila_sel = this.gridViewDisputas.GetSelectedRows()[0];
                    disputa = (PaperlessUsuario1Disputas)this.gridViewDisputas.GetRow(fila_sel);
                    var disputas = GridDisputas.DataSource as List<PaperlessUsuario1Disputas>;
                    disputas.Remove(disputa);
                    GridDisputas.DataSource = disputas;
                    GridDisputas.RefreshDataSource();
                }
            }
        }

        private void gridViewDisputas_ShownEditor(object sender, EventArgs e) {
            var foo = sender as GridView;
            if (foo.FocusedColumn.FieldName.Equals("TipoDisputa")) {
                DevExpress.XtraEditors.ComboBoxEdit cbo = (sender as DevExpress.XtraGrid.Views.Base.BaseView).ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                ComboBoxItemCollection coll = cbo.Properties.Items;
                foreach (var tipo in TiposDisputas)
                    coll.Add(tipo);
            }
        }

        private Boolean ValidateDisputas() {
            var disputas = new List<PaperlessUsuario1Disputas>();
            if (gridViewDisputas.DataSource != null)
                disputas = (List<PaperlessUsuario1Disputas>)gridViewDisputas.DataSource;

            foreach (var disputa in disputas) {
                if (String.IsNullOrEmpty(disputa.Descripcion) || disputa.Numero == null || disputa.TipoDisputa == null)
                    return false;
            }
            return true;
        }

        private void btnGuardarDisputas_Click(object sender, EventArgs e) {
            LabelErrorDisputa.Visible = false;
            var val = ValidateDisputas();
            if (!val) {
                LabelErrorDisputa.Visible = true;
            }else {
                //Guardar las disputas
                Cursor.Current = Cursors.WaitCursor;
                IList<PaperlessUsuario1Disputas> disputas = (IList<PaperlessUsuario1Disputas>)GridDisputas.DataSource;
                PaperlessPasosEstado pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla(11);
                pasoSeleccionado.Estado = true;
                var resultado = LogicaNegocios.Paperless.Paperless.Usuario1GuardaDisputas(disputas, PaperlessAsignacionActual, pasoSeleccionado);
                
                
                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada) {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    CargarPasos();
                    Cursor.Current = Cursors.Default;
                    lblP1errorHouses.Visible = false;
                    MessageBox.Show("Las Disputas han sido guardadss", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnP1GuardarHousesBL.Enabled = false;

                }

            }
        }

    }
}