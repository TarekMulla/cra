using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Clientes.Cuenta;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Paperless;
using ProyectoCraft.WinForm.Controles;
using System.Data;
using ProyectoCraft.WinForm.Paperless.Usuario2;
using SCCMultimodal.Paperless.Usuario1;
using SCCMultimodal.Utils;
using log4net;

namespace ProyectoCraft.WinForm.Paperless.Usuario1
{
    public partial class FrmPaperlessUser1 : Form, IFrmPaperlessUser1
    {
        private static readonly ILog Log = LogManager.GetLogger("Paperless");
        public FrmPaperlessUser1()
        {
            InitializeComponent();
        }

        private static FrmPaperlessUser1 _instancia;
        public static FrmPaperlessUser1 Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new FrmPaperlessUser1();

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

        private IList<clsClienteMaster> listTargets = null;
        private IList<clsClienteMaster> listClientesPaperless = null;
        private List<clsClienteMaster> clientes = null;

        private void frmPaperlessUser1_Load(object sender, EventArgs e)
        {
            ProyectoCraft.WinForm.Controles.EstadoPaperless control = new EstadoPaperless();
            panel1.Controls.Add(control);

            CargarPasos();
            CargarClientesExistentesHousesBL();
            //Paso1CargarClientes();

            gridView4.CustomRowCellEditForEditing += new CustomRowCellEditEventHandler(MarcarPaso);


            CargarPaso1HousesBL();
            CargarPaso3HousesRuteados();
            CargarPaso11IngresoExcepciones();
            ValidarAccion();
            //IngresarHousesBL();
            //MarcarHouseRuteado();
            //RegistrarExcepciones();

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

        private void ValidarAccion()
        {
            if (Accion == Enums.TipoAccionFormulario.Consultar)
            {
                btnP1GuardarHousesBL.Visible = false;
                btnP2GuardarHousesRuteados.Visible = false;
                btnP11Excepciones.Visible = false;
                btnP13EnviarAviso.Visible = false;
            }
        }

        protected void RecargarPasos(object sender, EventArgs e)
        {
            PaperlessPasosEstado paso = ObtenerPasoSeleccionado();
            if (paso.Paso.NumPaso == 13)
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
            DevExpress.XtraEditors.CheckEdit check = sender as DevExpress.XtraEditors.CheckEdit;
            if (check == null) return;

            PaperlessPasosEstado paso = ObtenerPasoSeleccionado();

            if (paso.Paso.NumPaso == 1 || paso.Paso.NumPaso == 3 || paso.Paso.NumPaso == 12 || paso.Paso.NumPaso == 13)
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
        }

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

        }

        private void CargarClientesExistentesHousesBL()
        {
            CargaClientes();
            //IList<clsClienteMaster> listTargets = LogicaNegocios.Clientes.clsClientesMaster.ListarClienteMaster("-1", Enums.TipoPersona.Cuenta, Enums.Estado.Todos, true);
            //IList<clsClienteMaster> listClientesPaperless =
            //    LogicaNegocios.Clientes.clsClientesMaster.ListarClienteMaster("-1", Enums.TipoPersona.CuentaPaperless, Enums.Estado.Todos, true);

            //List<clsClienteMaster> clientes = new List<clsClienteMaster>();
            //clientes.AddRange(listTargets);
            //clientes.AddRange(listClientesPaperless);



            ComboBoxItemCollection coll = ddlP1Cliente.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in clientes)
            {
                coll.Add(list);
            }
            ddlP1Cliente.SelectedIndex = 0;

            //AutoCompleteStringCollection auto = new AutoCompleteStringCollection();

            //auto.Add(txtP1Cliente.Text);

            //foreach (var list in listTargets)
            //{
            //    auto.Add(list.ToString());
            //}

            //txtP1Cliente.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //txtP1Cliente.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //txtP1Cliente.MaskBox.AutoCompleteCustomSource = auto;                    
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

        private void MarcarHouseRuteado()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Num"));
            dt.Columns.Add(new DataColumn("House"));
            dt.Columns.Add(new DataColumn("Ruteado"));

            DataRow dr = dt.NewRow();
            dr["Num"] = "1";
            dr["House"] = "111111";
            dr["Ruteado"] = "false";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Num"] = "2";
            dr["House"] = "22222";
            dr["Ruteado"] = "false";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Num"] = "3";
            dr["House"] = "333333";
            dr["Ruteado"] = "true";
            dt.Rows.Add(dr);

            grdP3HousesRuteados.DataSource = dt;
        }

        private void IngresarHousesBL()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Num"));
            dt.Columns.Add(new DataColumn("House"));
            dt.Columns.Add(new DataColumn("Freehand"));

            DataRow dr = dt.NewRow();
            dr["Num"] = "1";
            dr["House"] = "";
            dr["Freehand"] = "";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Num"] = "2";
            dr["House"] = "";
            dr["Freehand"] = "";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Num"] = "3";
            dr["House"] = "";
            dr["Freehand"] = "";
            dt.Rows.Add(dr);

            grdP1DigitarHousesBL.DataSource = dt;

        }

        protected void MarcarPaso(object sender, CustomRowCellEditEventArgs e)
        {
            pnlPaso1.Visible = false;
            pnlPaso3.Visible = false;
            pnlExcepciones.Visible = false;
            pnlEnviarAviso.Visible = false;

            //if(e.Column.FieldName == "Estado")
            //{
            if (e.RowHandle == 0)
            {
                //CargarPaso1HousesBL();
                pnlPaso1.Visible = true;
            }
            if (e.RowHandle == 2)
            {
                //CargarPaso3HousesRuteados();
                pnlPaso3.Visible = true;
            }
            if (e.RowHandle == 11)
            {
                CargarPaso11IngresoExcepciones();
                pnlExcepciones.Visible = true;
            }
            if (e.RowHandle == 12)
            {
                pnlEnviarAviso.Visible = true;
            }

            //}

            //if(e.Column.FieldName == "Estado")
            //{
            //    GridView View = sender as GridView;
            //    bool estado2 = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["Estado"]));

            //    if(estado2)
            //    {
            //        PaperlessPasosEstado paso = ObtenerPasoSeleccionado();
            //        if (paso != null)
            //        {
            //            Entidades.GlobalObject.ResultadoTransaccion resultado = LogicaNegocios.Paperless.Paperless.Usuario1CambiarEstadoPaso(paso);
            //            if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
            //            {
            //                MessageBox.Show("Error al cambiar estado del paso. \n" + resultado.Descripcion, "Paperless",
            //                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }    
            //    }                
            //}            
        }

        private void CargarPaso3HousesRuteados()
        {
            grdP3HousesRuteados.DataSource = PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL;
            grdP3HousesRuteados.RefreshDataSource();
        }

        private void CargarPaso11IngresoExcepciones()
        {
            IList<PaperlessExcepcion> excepciones =
                LogicaNegocios.Paperless.Paperless.Usuario1ObtenerExcepciones(PaperlessAsignacionActual.Id);

            if (excepciones == null || excepciones.Count == 0)// || excepciones.Count < PaperlessAsignacionActual.NumHousesBL)
            {
                PrepararPaso11Excepciones();
            }
            else
            {
                PaperlessAsignacionActual.DataUsuario1.Excepciones = excepciones;
            }

            grdExcepciones.DataSource = PaperlessAsignacionActual.DataUsuario1.Excepciones;
            grdExcepciones.RefreshDataSource();
        }

        private void PrepararPaso11Excepciones()
        {
            IList<PaperlessExcepcion> excepciones = new List<PaperlessExcepcion>();

            foreach (var house in PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL)
            {
                PaperlessExcepcion excepcion = new PaperlessExcepcion();
                excepcion.IdAsignacion = PaperlessAsignacionActual.Id;
                excepcion.HouseBL.Id = house.Id;
                excepcion.HouseBL.Cliente = house.Cliente;
                excepcion.HouseBL.TipoCliente = house.TipoCliente;
                excepcion.RecargoCollect = false;
                excepcion.RecargoCollectResuelto = false;
                excepcion.SobreValorPendiente = false;
                excepcion.SobreValorPendienteResuelto = false;
                excepcion.AvisoNoEnviado = false;
                excepcion.AvisoNoEnviadoResuelto = false;
                excepciones.Add(excepcion);
            }

            PaperlessAsignacionActual.DataUsuario1.Excepciones = excepciones;
        }

        private void CargarPasos()
        {
            IList<PaperlessPasosEstado> pasos =
                LogicaNegocios.Paperless.Paperless.ListarPasosEstadoUsuario1(PaperlessAsignacionActual.Id);

            grdPasos.DataSource = pasos;

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
            Entidades.Paperless.PaperlessProcesoRegistroTiempo inicio = new PaperlessProcesoRegistroTiempo();
            inicio.IdAsignacion = PaperlessAsignacionActual.Id;
            inicio.ComienzoUsuario1 = DateTime.Now;


            Entidades.GlobalObject.ResultadoTransaccion resultado =
                LogicaNegocios.Paperless.Paperless.PreparaPasosUsuario1V2(PaperlessAsignacionActual, inicio);

            if (resultado.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                PaperlessAsignacionActual.Estado = Enums.EstadoPaperless.EnProcesoUsuario1;
                resultado = LogicaNegocios.Paperless.Paperless.CambiaEstadoAsignacion(PaperlessAsignacionActual);
            }
            if (PaperlessAsignacionActual.IdResultado.Equals(1))
                MessageBox.Show(PaperlessAsignacionActual.GlosaResultado, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return resultado;
        }

        public void CargarInformacionAsignacionInicial()
        {
            txtP1CantHouses.Text = PaperlessAsignacionActual.NumHousesBL.ToString();
        }

        public void MyShowDialog() {
            this.ShowDialog();
        }

        private void simpleButton17_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            Usuario2.frmPaperlessUser2 form = new frmPaperlessUser2();
            form.Show();
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void frmPaperlessUser1_Leave(object sender, EventArgs e)
        {
            Instancia = null;
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Paperless.Usuario1.frmListarUsuario1 form = Paperless.Usuario1.frmListarUsuario1.Instancia;
            form.ObtenerAsignaciones();

            Instancia = null;
            this.Close();
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
                txtP1CantHouses.Text = info.CantHouses.ToString();
                txtP1NumConsolidado.Text = info.NumConsolidado.ToString();
                //txtP1NumHouse.Text = info.NumHouse.ToString();
                //ddlP1Cliente.SelectedItem = info.Cliente;
                //txtP1Cliente.Text = info.Cliente.ToString();
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
            var filaSelected = grdPasos.DefaultView.GetRow(gridView4.FocusedRowHandle);

            if (filaSelected == null)
            {
                return null;
            }

            PaperlessPasosEstado housesbl = (PaperlessPasosEstado)filaSelected;

            return housesbl;
        }

        private bool ValidarHousesBLInfo()
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
                if (LogicaNegocios.Paperless.Paperless.ValidaNumConsolidado(txtP1NumConsolidado.Text, PaperlessAsignacionActual.Id32.ToString()).Equals(true))
                {
                    dxErrorProvider1.SetError(txtP1NumConsolidado, "Ya existe el numero de consolidado", ErrorType.Critical);
                    return false;
                }
                dxErrorProvider1.ClearErrors();
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

        private PaperlessUsuario1HouseBLInfo Usuario1ObtenerHousesBLInfo()
        {
            PaperlessUsuario1HouseBLInfo info = new PaperlessUsuario1HouseBLInfo();

            info.CantHouses = Convert.ToInt16(txtP1CantHouses.Text);
            info.IdAsignacion = PaperlessAsignacionActual.Id;
            info.NumConsolidado = txtP1NumConsolidado.Text;
            //info.NumHouse = Convert.ToInt16(txtP1NumHouse.Text);

            //if (txtP1Cliente.Text.Trim() == "")
            //{
            //    info.Cliente = null;
            //}
            //else
            //{
            //    for (int i = 0; i < ddlP1Cliente.Properties.Items.Count; i++)
            //    {
            //        if (ddlP1Cliente.Properties.Items[i].ToString() == txtP1Cliente.Text)
            //            ddlP1Cliente.SelectedIndex = i;
            //    }

            //    if (ddlP1Cliente.SelectedIndex == 0)
            //    {
            //        info.Cliente = new clsClienteMaster(true);
            //    }
            //    else
            //        info.Cliente = (clsClienteMaster)this.ddlP1Cliente.SelectedItem;
            //}

            return info;
        }

        private PaperlessPasosEstado ObtenerPasoSelccionadoDesdeGrilla(int numpaso)
        {
            IList<PaperlessPasosEstado> pasos = (IList<PaperlessPasosEstado>)grdPasos.DataSource;

            return pasos[numpaso - 1];

        }

        private void btnP1GuardarHousesBL_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarHousesBLInfo()) return;

                Cursor.Current = Cursors.WaitCursor;

                IList<PaperlessUsuario1HousesBL> listhouses = (IList<PaperlessUsuario1HousesBL>)grdP1DigitarHousesBL.DataSource;


                //PaperlessPasosEstado pasoSeleccionado = ObtenerPasoSeleccionado();
                PaperlessPasosEstado pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla(1);

                pasoSeleccionado.Estado = true;

                PaperlessUsuario1HouseBLInfo info = Usuario1ObtenerHousesBLInfo();

                Entidades.GlobalObject.ResultadoTransaccion resultado =
                    LogicaNegocios.Paperless.Paperless.Usuario1GuardaHousesBL(listhouses, info, pasoSeleccionado);

                PaperlessAsignacionActual.DataUsuario1.Paso1HousesBLInfo = info;
                PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL = listhouses;

                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                {
                    Log.Info("btnP1GuardarHousesBL_Click Rechazada");
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Log.Info("btnP1GuardarHousesBL_Click Aceptada");
                    CargarPasos();
                    Cursor.Current = Cursors.Default;
                    lblP1errorHouses.Visible = false;
                    MessageBox.Show("Houses han sido guardados", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }            
        }

        private void btnP2GuardarHousesRuteados_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                IList<PaperlessUsuario1HousesBL> listhouses = (IList<PaperlessUsuario1HousesBL>)grdP3HousesRuteados.DataSource;

                //PaperlessPasosEstado pasoSeleccionado = ObtenerPasoSeleccionado();
                PaperlessPasosEstado pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla(3);

                if (!ValidarPermiteCambiarPasoEstado(pasoSeleccionado))
                {
                    return;
                }

                pasoSeleccionado.Estado = true;

                Entidades.GlobalObject.ResultadoTransaccion resultado =
                    LogicaNegocios.Paperless.Paperless.Usuario1MarcarHousesRuteados(listhouses, pasoSeleccionado);


                PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL = listhouses;

                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                {
                    Log.Info("btnP2GuardarHousesRuteados_Click Rechazada");
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Log.Info("btnP2GuardarHousesRuteados_Click Aceptada");
                    CargarPasos();
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Houses Ruteados han sido guardados", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
              Log.Error(ex);  
                throw;
            }

            

        }

        private void gridView5_ShownEditor(object sender, EventArgs e)
        {
            if (this.gridView5.FocusedColumn.FieldName.Equals("Cliente.NombreFantasia"))
            {
                DevExpress.XtraEditors.TextEdit txt = (sender as DevExpress.XtraGrid.Views.Base.BaseView).ActiveEditor as DevExpress.XtraEditors.TextEdit;

                if (txt.MaskBox.AutoCompleteCustomSource.Count == 0)
                {
                    txt.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txt.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txt.MaskBox.AutoCompleteCustomSource = GetClientes(txt);
                }
            }

            if (this.gridView5.FocusedColumn.FieldName.Equals("TipoCliente.Nombre"))
            {
                DevExpress.XtraEditors.ComboBoxEdit cbo = (sender as DevExpress.XtraGrid.Views.Base.BaseView).ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                ComboBoxItemCollection coll = cbo.Properties.Items;

                foreach (var tipo in Paso1CargarClientes())
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
            //foreach (var tipo in tipos)
            //{
            //    cborep.Items.Add(tipo);
            //}
            //P1colTipoCliente.FieldName = "Nombre";
            //P1colTipoCliente.ColumnEdit = cborep;
        }


        private AutoCompleteStringCollection GetClientes(DevExpress.XtraEditors.TextEdit txt)
        {
            CargaClientes();
            //CLIENTES
            //IList<clsClienteMaster> listTargets = LogicaNegocios.Clientes.clsClientesMaster.ListarClienteMaster("-1", Enums.TipoPersona.Cuenta, Enums.Estado.Todos, true);
            //IList<clsClienteMaster> listClientesPaperless =
            //LogicaNegocios.Clientes.clsClientesMaster.ListarClienteMaster("-1", Enums.TipoPersona.CuentaPaperless,Enums.Estado.Todos, true);

            //List<clsClienteMaster> clientes = new List<clsClienteMaster>();
            //clientes.AddRange(listTargets);
            //clientes.AddRange(listClientesPaperless);

            ddlP1Cliente.Properties.Items.Clear();
            ComboBoxItemCollection coll = ddlP1Cliente.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in clientes)
            {
                coll.Add(list);
            }
            ddlP1Cliente.SelectedIndex = 0;

            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();

            //RepositoryItemTextEdit txtrep = new RepositoryItemTextEdit();


            //auto.Add(txt.Text);

            foreach (var list in clientes)
            {
                auto.Add(list.ToString());
            }

            //txtP1Cliente.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //txtP1Cliente.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //txtP1Cliente.MaskBox.AutoCompleteCustomSource = auto;

            return auto;
        }

        private void gridView5_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DevExpress.XtraGrid.Views.Base.ColumnView columna = sender as DevExpress.XtraGrid.Views.Base.ColumnView;
            string nomcliente = "";
            Int64 IdCliente = 0;
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

                            var transaccion = LogicaNegocios.Clientes.clsCuentas.BuscarCuentaPorId(clienteselecccionado.Id);
                            if (transaccion != null)
                            {
                                cuenta = (clsCuenta)transaccion.ObjetoTransaccion;
                                if (cuenta != null && cuenta.ClienteMaster.ClienteMasterTipoCliente != null)
                                {
                                    if (cuenta.ClienteMaster.ClienteMasterTipoCliente.Count.Equals(0) ||
                                        cuenta.ClienteMaster.ClienteMasterTipoCliente.Count > 1)
                                    {
                                        PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL[e.RowHandle].TipoCliente = null;
                                    }
                                    else
                                    {
                                        ptc.Nombre = cuenta.ClienteMaster.ClienteMasterTipoCliente[0].Nombre;
                                        ptc.Id = cuenta.ClienteMaster.ClienteMasterTipoCliente[0].Id;
                                        PaperlessAsignacionActual.DataUsuario1.Paso1HousesBL[e.RowHandle].TipoCliente = ptc;
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

        private bool ValidarP11Excepciones()
        {
            //IList<PaperlessExcepcion> excepciones = (IList<PaperlessExcepcion>) grdExcepciones.DataSource;
            bool valida = true;

            //foreach (var excepcion in excepciones)
            //{                
            //    if (excepcion.HBLS.Length.Equals(0))
            //    {
            //        lblP11ErrorExcepcion.Visible = true;
            //        valida = false;
            //    }                    
            //}
            return valida;
        }

        private void btnP11Excepciones_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                PaperlessPasosEstado pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla(12);

                if (!ValidarPermiteCambiarPasoEstado(pasoSeleccionado))
                    return;

                pasoSeleccionado.Estado = true;

                if (!ValidarP11Excepciones()) return;

                IList<PaperlessExcepcion> excepciones = (IList<PaperlessExcepcion>)grdExcepciones.DataSource;

                Entidades.GlobalObject.ResultadoTransaccion resultado =
                    LogicaNegocios.Paperless.Paperless.Usuario1IngresarExcepxiones(excepciones, pasoSeleccionado);


                PaperlessAsignacionActual.DataUsuario1.Excepciones = excepciones;

                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                {
                    Log.Info("btnP11Excepciones_Click Rechazada");
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Log.Info("btnP11Excepciones_Click Aceptada");
                    CargarPasos();
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Excepciones han sido guardadas", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }            
        }

        private void gridView4_RowStyle(object sender, RowStyleEventArgs e)
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

        private void btnP13EnviarAviso_Click(object sender, EventArgs e)
        {
            try
            {
                var mail = new EnvioMailObject();
                Cursor.Current = Cursors.WaitCursor;

                PaperlessPasosEstado pasoSeleccionado = ObtenerPasoSelccionadoDesdeGrilla(13);

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

                if (PaperlessAsignacionActual.IdResultado.Equals(1))
                    MessageBox.Show(PaperlessAsignacionActual.GlosaResultado, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                        Log.Info("btnP13EnviarAviso_Click Rechazada");
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Ocurrio un problema al intentar enviar el email. \n" + resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Log.Info("btnP13EnviarAviso_Click Aceptada");
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
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }            
        }

        private void frmPaperlessUser1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
            frmListarUsuario1 form = frmListarUsuario1.Instancia;
            form.ObtenerAsignaciones();
        }

        private void btnReenviarAvisoUsuario2_Click(object sender, EventArgs e)
        {
            try
            {
                var mail = new EnvioMailObject();

                Entidades.GlobalObject.ResultadoTransaccion resultado = mail.EnviarMailPaperlessUsuario2ConfirmacionUsuario1(PaperlessAsignacionActual);
                //Entidades.GlobalObject.ResultadoTransaccion resultado = Utils.EnvioEmail.EnviarMailPaperlessUsuario2ConfirmacionUsuario1(PaperlessAsignacionActual);

                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                {
                    Log.Info("btnReenviarAvisoUsuario2_Click Rechazada");
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Ocurrio un problema al intentar enviar el email. \n" + resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Log.Info("btnReenviarAvisoUsuario2_Click Aceptada");
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Se ha enviado la confirmacion al Usuario de la segunda Etapa", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    frmListarUsuario1 form = frmListarUsuario1.Instancia;
                    form.ObtenerAsignaciones();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }            
        }

        private void CargaClientes()
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

    public class PasosPaperless
    {
        public PasosPaperless() { }
        public PasosPaperless(string num, string descripcion, bool estado)
        {
            NumPaso = num;
            Descripcion = descripcion;
            Estado = estado;
        }

        public string NumPaso { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

    }

}
