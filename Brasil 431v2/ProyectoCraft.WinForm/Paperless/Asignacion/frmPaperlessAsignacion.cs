using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Log;
using ProyectoCraft.Entidades.Paperless;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.LogicaNegocios.Log;
using ProyectoCraft.LogicaNegocios.Parametros;
using SCCMultimodal.Utils;
using ProyectoCraft.Base.Log;

namespace ProyectoCraft.WinForm.Paperless.Asignacion
{
    public partial class frmPaperlessAsignacion : Form
    {
        public frmPaperlessAsignacion()
        {
            InitializeComponent();
        }

        private static frmPaperlessAsignacion _instancia;
        public static frmPaperlessAsignacion Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmPaperlessAsignacion();

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

        private IList<PaperlessTipoCarga> Cargas { get; set; }
        private bool IsBrasil { get; set; }
        IList<PaperlessTipoCarga> CargasDesclarga { get; set; }

        private void frmPaperless_Load(object sender, EventArgs e)
        {

            var conf = Base.Configuracion.Configuracion.Instance();
            var op = conf.GetValue("Paperless_ParcialBrasil"); //puede retornar un true, false o null
            if (op.HasValue && op.Value.Equals(true))
                IsBrasil = true;


            //Cargamos la configuracion
            var configuracion = Base.Configuracion.Configuracion.Instance();
            var opcion = configuracion.GetValue("Paperless_BtnMantNavieras_Enabled"); //puede retornar un true, false o null
            if (opcion.HasValue && opcion.Value.Equals(true))
                foreach (var clsPerfil in Base.Usuario.UsuarioConectado.Usuario.Perfiles)
                {
                    if (clsPerfil.Nombre.ToString().Equals(Enums.UsuariosCargo.AdministradorDatosMaestros.ToString()))
                        MenuMantNavieras.Visible = true;
                }

            if (Accion == Enums.TipoAccionFormulario.Nuevo)
                FormLoad();

            if (Accion == Enums.TipoAccionFormulario.Consultar)
                BloquearFormulario();
        }

        private void BloquearFormulario()
        {
            btnAsignar.Enabled = false;
            btnSiguienteP2.Enabled = false;
            btnSiguienteP3.Enabled = false;
            radioCourierDestino.Enabled = false;
            chkConfirmacionMaster.Enabled = false;
            txtfechaMasterConfirmado.Properties.ReadOnly = true;
            txtfechaMasterConfirmado.Enabled = true;
            txtCourier.Enabled = false;
        }

        public void FormLoad()
        {
            CargarProductos();
            CargarTipoServicios();
            CargarUsuarios();
            CargarNavierasExistentes();
            CargarAgentesExistentes();
            CargarNavesExistentes();
            CargarImportancia();
            HabilitarOpcionesPorFlags();
            ValidarEstados();
        }
        private void HabilitarOpcionesPorFlags()
        {
            CargarGraficos();// IdUsuario,FechaDesde,FechaHasta
            var configuracion = Base.Configuracion.Configuracion.Instance();
            var opcion = configuracion.GetValue("paperless_txtfechaMaximaVinculacion_Enabled");//puede retornar un true, false o null
            if (opcion.HasValue && opcion.Value.Equals(true))
            {
                txtAperturaNavieras.Enabled = false;
                lblasteriscofechaMaximaVinculacion.Visible = true;
                txtFechaMaximaVinculacion.Visible = true;
                lblFechaMaximaVinculacion.Visible = true;
                lblLeyendaFechaMaximaVinculacion.Visible = true;
            }
            else
            {
                txtAperturaNavieras.Enabled = true;
                lblasteriscofechaMaximaVinculacion.Visible = false;
                txtFechaMaximaVinculacion.Visible = false;
                lblFechaMaximaVinculacion.Visible = false;
                lblLeyendaFechaMaximaVinculacion.Visible = false;
            }
        }
        private void CargaFechaMaximaVinculacion()
        {
            try
            {
                //Cargamos la configuracion
                var configuracion = Base.Configuracion.Configuracion.Instance();
                var opcion = configuracion.GetValue("paperless_txtfechaMaximaVinculacion_Enabled");//puede retornar un true, false o null
                if (opcion.HasValue && opcion.Value.Equals(true))
                {
                    /*2 fechas de control 10 y 7 dias, el sistema controlará y mostrara una fecha precalculada en 2 ocaciones 
                         * cuando el eta - la fecha actual sea menor a 7 o 10 dias, si eso no se cumple se debe enviar un  aviso q debe decir 
                         "se ha superado el plazo que el sistema asigna automaticamente y usted debe ingresar la vinculacion, 
                         * ademas se manejará un log minimo que indicará cual fue la opcion tomada, 10, 7 o manipulado por el usuario, 
                         * la fecha de apertura se oculta para brasil.*/
                    int dif = 0; //(txtFechaETA.DateTime - DateTime.Now).Days;
                    if (!string.IsNullOrEmpty(txtFechaETA.Text))
                    {
                        if (txtFechaETA.DateTime.AddDays(-10) >= Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                        {
                            txtFechaMaximaVinculacion.Text = txtFechaETA.DateTime.AddDays(-10).ToShortDateString();
                            dif = 10;
                            lblAvisoFechaMaximaVinculacion.Visible = false;
                        }
                        else if (txtFechaETA.DateTime.AddDays(-7) >= Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                        {
                            txtFechaMaximaVinculacion.Text = txtFechaETA.DateTime.AddDays(-7).ToShortDateString();
                            dif = 7;
                            lblAvisoFechaMaximaVinculacion.Visible = false;
                        }
                        else if (txtFechaETA.DateTime.AddDays(-7) <=
                                 Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                        {
                            lblAvisoFechaMaximaVinculacion.Visible = true;
                            dif = (txtFechaETA.DateTime - DateTime.Now).Days;
                            txtFechaMaximaVinculacion.Text = "";
                        }
                        else if (txtFechaETA.DateTime.AddDays(-10) > DateTime.Now)
                        {
                            txtFechaMaximaVinculacion.Text =
                                txtFechaETA.DateTime.AddDays(-10).ToShortDateString();
                            dif = (txtFechaETA.DateTime - DateTime.Now).Days;
                            lblAvisoFechaMaximaVinculacion.Visible = false;
                        }
                        PaperlessAsignacionActual.FechaMaximaVinculacionDiff = dif;
                        if (!txtFechaMaximaVinculacion.Text.Length.Equals(0))
                            PaperlessAsignacionActual.FechaMaximaVinculacion =
                                Convert.ToDateTime(txtFechaMaximaVinculacion.Text);
                    }
                }
                else
                {
                    txtAperturaNavieras.Enabled = true;
                    txtFechaMaximaVinculacion.Visible = false;
                    lblFechaMaximaVinculacion.Visible = false;
                }
            }
            catch (Exception e)
            {
                Log.log.Error(e);
            }
        }

        public void CargarFormulario()
        {
            FormLoad();

            PaperlessAsignacion Asignacion =
                LogicaNegocios.Paperless.Paperless.ObtenerAsignacionPorId(PaperlessAsignacionActual.Id);

            if (Asignacion != null)
            {
                PaperlessAsignacionActual = Asignacion;

                txtNumMaster.Text = Asignacion.NumMaster;
                txtFechaMaster.Text = Asignacion.FechaMaster.ToShortDateString();
                ddlAgente.SelectedItem = Asignacion.Agente;
                txtAgente.Text = Asignacion.Agente.Nombre;
                ddlNaviera.SelectedItem = Asignacion.Naviera;
                txtNaviera.Text = Asignacion.Nave.Nombre;
                ddlNave.SelectedItem = Asignacion.Nave;
                ddlNaveTransbordo.SelectedItem = Asignacion.NaveTransbordo;
                txtNave.Text = Asignacion.Nave.Nombre;
                if (Asignacion.NaveTransbordo != null)
                    txtNaveTransbordo.Text = Asignacion.NaveTransbordo.Nombre;
                txtViaje.Text = Asignacion.Viaje;
                txtNumHousesBL.Text = Asignacion.NumHousesBL.ToString();
                if (IsBrasil)
                {try
                    {
                        if (Asignacion.TipoCarga.Nombre.Equals("FCL"))
                        {
                            if (Asignacion.TipoCarga.Id > 3)
                            {
                                foreach (var paperlessTipoCarga in Cargas)
                                {
                                    if (paperlessTipoCarga.Nombre.Equals("FCL"))
                                    {
                                        ddlTipoCarga.SelectedItem = paperlessTipoCarga;
                                        ddlTipoCargaDescLarga.Visible = true;
                                        foreach (var descLarga in CargasDesclarga)
                                        {
                                            if (descLarga.Id.Equals(Asignacion.TipoCarga.Id))
                                                ddlTipoCargaDescLarga.SelectedItem = descLarga;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ddlTipoCarga.SelectedItem = Asignacion.TipoCarga;

                                if (Asignacion.TipoCarga.Nombre.Equals("FCL"))
                                {
                                    foreach (var paperlessTipoCarga in Cargas)
                                    {
                                        if (paperlessTipoCarga.Nombre.Equals("FCL"))
                                        {
                                            ddlTipoCarga.SelectedItem = paperlessTipoCarga;
                                            ddlTipoCargaDescLarga.Visible = true;
                                            foreach (var descLarga in CargasDesclarga)
                                            {
                                                if (descLarga.Id.Equals(Asignacion.TipoCarga.Id))
                                                    ddlTipoCargaDescLarga.SelectedItem = descLarga;
                                            }
                                        }
                                    }
                                }

                            }

                        }
                        else
                            ddlTipoCarga.SelectedItem = Asignacion.TipoCarga;
                    }
                    catch (Exception e)
                    {

                    }
                }
                else
                    ddlTipoCarga.SelectedItem = Asignacion.TipoCarga;
     


                if (!Asignacion.TipoCarga.EsFAK && (Asignacion.TipoServicio != null && Asignacion.TipoServicio.Nombre.Equals("Transbordo")))
                {
                    lblAlertaPlazoembarcadores.Visible = false;
                }

                if (Asignacion.TipoServicio == null)
                    ddlTipoServicio.SelectedIndex = 0;
                else
                    ddlTipoServicio.SelectedItem = Asignacion.TipoServicio;

                if (Asignacion.FechaETA.HasValue)
                    txtFechaETA.Text = Asignacion.FechaETA.Value.ToShortDateString();
                if (Asignacion.AperturaNavieras.HasValue)
                    txtAperturaNavieras.Text = Asignacion.AperturaNavieras.Value.ToShortDateString();
                if (Asignacion.PlazoEmbarcadores.HasValue)
                    txtPlazoEmbarcadores.Text = Asignacion.PlazoEmbarcadores.Value.ToShortDateString();

                if (Asignacion.Usuario1 == null)
                    ddlUsuario1.SelectedIndex = 0;
                else
                    ddlUsuario1.SelectedItem = Asignacion.Usuario1;

                txtObsercacionU1.Text = Asignacion.ObservacionUsuario1;
                if (Asignacion.ImportanciaUsuario1 == null)
                    ddlImportanciaU1.SelectedIndex = 0;
                else
                    ddlImportanciaU1.SelectedItem = Asignacion.ImportanciaUsuario1;

                if (Asignacion.Usuario2 == null)
                    ddlUsuario2.SelectedIndex = 0;
                else
                    ddlUsuario2.SelectedItem = Asignacion.Usuario2;

                txtObservacionU2.Text = Asignacion.ObservacionUsuario2;

                //if (Asignacion.TipoServicio.Nombre.Equals("Transbordo"))
                if (Asignacion.TipoServicio != null && (Asignacion.TipoServicio.Nombre != null && Asignacion.TipoServicio.Nombre.Equals("Transbordo")))
                {
                    lblNaveTransbordo.Visible = true;
                    txtNaveTransbordo.Visible = true;
                    txtNaveTransbordo.Text = Asignacion.NaveTransbordo.Nombre;
                    ddlNaveTransbordo.SelectedItem = Asignacion.NaveTransbordo;
                }
                else
                {
                    lblNaveTransbordo.Visible = txtNaveTransbordo.Visible = false;
                    txtNaveTransbordo.Text = String.Empty;
                    ddlNaveTransbordo.SelectedItem = null;
                }
                CargaMasterConfirmado();
                CargaShippingPuerto();
                ValidarEstados();
            }
        }

        private void ValidarEstados()
        {
            if (PaperlessAsignacionActual.Estado == Enums.EstadoPaperless.Nuevo)
            {
                tabInfGeneral.PageEnabled = true;
                tabFechas.PageEnabled = false;
                tabPrealerta.PageEnabled = false;
                tabAsignacion.SelectedTabPage = tabInfGeneral;
            }
            else if (PaperlessAsignacionActual.Estado == Enums.EstadoPaperless.EnAsignacion && PaperlessAsignacionActual.NumMaster != null && !PaperlessAsignacionActual.FechaETA.HasValue)
            {
                tabInfGeneral.PageEnabled = true;
                tabFechas.PageEnabled = true;
                tabPrealerta.PageEnabled = false;
                tabAsignacion.SelectedTabPage = tabFechas;
            }
            else if (PaperlessAsignacionActual.Estado == Enums.EstadoPaperless.EnAsignacion && PaperlessAsignacionActual.FechaETA.HasValue && (PaperlessAsignacionActual.Usuario1 == null || PaperlessAsignacionActual.Usuario1.Id <= 0))
            {
                tabInfGeneral.PageEnabled = true;
                tabFechas.PageEnabled = true;
                tabPrealerta.PageEnabled = true;
                btnAsignar.Enabled = true;
                tabAsignacion.SelectedTabPage = tabPrealerta;
                //} else if (PaperlessAsignacionActual.Estado == Enums.EstadoPaperless.AsignadoUsuario1) {
                //    tabInfGeneral.PageEnabled = true;
                //    tabFechas.PageEnabled = true;
                //    tabPrealerta.PageEnabled = true;
                //    btnAsignar.Enabled = true;
                //    tabAsignacion.SelectedTabPage = tabPrealerta;
                //    btnAsignar.Enabled = true;               
            }
            else if (PaperlessAsignacionActual.Estado == Enums.EstadoPaperless.AsignadoUsuario1
                || PaperlessAsignacionActual.Estado == Enums.EstadoPaperless.AceptadoUsuario1
                || PaperlessAsignacionActual.Estado == Enums.EstadoPaperless.EnProcesoUsuario1
                || PaperlessAsignacionActual.Estado == Enums.EstadoPaperless.EnProcesoUsuario1
                || PaperlessAsignacionActual.Estado == Enums.EstadoPaperless.EnviadoUsuario2
                || PaperlessAsignacionActual.Estado == Enums.EstadoPaperless.EnProcesoUsuario2)
            {
                btnEditar.Visible = true;
                btnEditarFechas.Visible = true;
                btnGrabarBl.Visible = true;
                btnGrabarFechas.Visible = true;
                if (ddlTipoServicio.SelectedItem.ToString().Equals("Transbordo"))
                {
                    btnEditarTransbordo.Visible = true;
                    btnGrabarTransbordo.Visible = true;
                }
                BloqueaBotonesTabInfGeneral();
                BloqueaTabFechas();
                BloquearFormulario();
            }
            else
            {
                tabInfGeneral.PageEnabled = true;
                tabFechas.PageEnabled = true;
                tabPrealerta.PageEnabled = true;
                btnAsignar.Enabled = true;
                tabAsignacion.SelectedTabPage = tabPrealerta;
                btnAsignar.Enabled = true;

            }

        }

        private void BloqueaBotonesTabInfGeneral()
        {
            txtNumMaster.Properties.ReadOnly = true;
            txtFechaMaster.Properties.ReadOnly = true;
            ddlAgente.Properties.ReadOnly = true;
            ddlNaviera.Properties.ReadOnly = true;
            txtNave.Enabled = false;
            txtNaveTransbordo.Enabled = false;
            txtViaje.Properties.ReadOnly = true;
            txtNumHousesBL.Enabled = false;
            ddlTipoCarga.Properties.ReadOnly = true;
            ddlTipoServicio.Properties.ReadOnly = true;
        }


        public void CargarNavierasExistentes()
        {
            ddlNaviera.Properties.Items.Clear();
            ComboBoxItemCollection coll = ddlNaviera.Properties.Items;
            IList<Entidades.Paperless.PaperlessNaviera> listNavieras = new List<Entidades.Paperless.PaperlessNaviera>();

            listNavieras = LogicaNegocios.Paperless.Paperless.ObtenerNavieras(Entidades.Enums.Enums.Estado.Habilitado);

            coll = ddlNaviera.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listNavieras)
            {
                coll.Add(list);
            }
            ddlNaviera.SelectedIndex = 0;
            ddlNaviera.Properties.AutoComplete = true;


            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(txtNaviera.Text);
            txtNaviera.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtNaviera.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (var list in listNavieras)
            {
                auto.Add(list.Nombre);
            }
            txtNaviera.AutoCompleteCustomSource = auto;
        }

        private void CargarAgentesExistentes()
        {
            ComboBoxItemCollection coll = ddlAgente.Properties.Items;
            IList<Entidades.Paperless.PaperlessAgente> listAgentes = new List<Entidades.Paperless.PaperlessAgente>();

            listAgentes = LogicaNegocios.Paperless.Paperless.ObtenerAgentes(Entidades.Enums.Enums.Estado.Habilitado);

            coll = ddlAgente.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listAgentes)
            {
                coll.Add(list);
            }
            ddlAgente.SelectedIndex = 0;
            ddlAgente.Properties.AutoComplete = true;

            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(txtAgente.Text);
            txtAgente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtAgente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (var list in listAgentes)
            {
                auto.Add(list.Nombre);
            }
            txtAgente.AutoCompleteCustomSource = auto;
        }

        private void CargarNavesExistentes()
        {
            ComboBoxItemCollection coll = ddlNave.Properties.Items;
            ComboBoxItemCollection col2 = ddlNaveTransbordo.Properties.Items;

            IList<Entidades.Paperless.PaperlessNave> listNaves = new List<Entidades.Paperless.PaperlessNave>();

            listNaves = LogicaNegocios.Paperless.Paperless.ObtenerNaves(Entidades.Enums.Enums.Estado.Habilitado);

            coll = ddlNave.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            col2 = ddlNaveTransbordo.Properties.Items;
            col2.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listNaves)
            {
                coll.Add(list);
                col2.Add(list);
            }
            ddlNave.SelectedIndex = 0;
            ddlNave.Properties.AutoComplete = true;
            ddlNaveTransbordo.SelectedIndex = 0;
            ddlNaveTransbordo.Properties.AutoComplete = true;

            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(txtNave.Text);
            var autoCompleteNaveTrasbordo = new AutoCompleteStringCollection();
            autoCompleteNaveTrasbordo.Add(txtNaveTransbordo.Text);
            txtNave.AutoCompleteMode = txtNaveTransbordo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtNave.AutoCompleteSource = txtNaveTransbordo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (var list in listNaves)
            {
                auto.Add(list.Nombre);
                autoCompleteNaveTrasbordo.Add(list.Nombre);
            }
            txtNave.AutoCompleteCustomSource = auto;
            txtNaveTransbordo.AutoCompleteCustomSource = autoCompleteNaveTrasbordo;
        }

        private void CargarProductos()
        {
            bool cargofcl = false;
            Cargas = LogicaNegocios.Paperless.Paperless.ListarTipoCarga(Enums.Estado.Habilitado);
            //CargasDesclarga = LogicaNegocios.Paperless.Paperless.ListarTipoCargaDescripcionLarga(Enums.Estado.Habilitado);

            ComboBoxItemCollection coll = ddlTipoCarga.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in Cargas)
            {
                if (cargofcl.Equals(false))
                {
                    if (list.Nombre.Equals("FCL"))
                        cargofcl = true;
                    coll.Add(list);
                }
                else if (!list.Nombre.Equals("FCL"))
                    coll.Add(list);
            }
            ddlTipoCarga.SelectedIndex = 0;

            //ComboBoxItemCollection collTipoDescLarga = ddlTipoCargaDescLarga.Properties.Items;
            //collTipoDescLarga.Add(Utils.Utils.ObtenerPrimerItem());
            //foreach (var list in CargasDesclarga)
            //{
            //    if (list.EsFCL)
            //    {
            //        list.Nombre = list.DescripcionLarga;
            //        collTipoDescLarga.Add(list);
            //    }

            //}
            //ddlTipoCargaDescLarga.SelectedIndex = 0;
        }

        private void CargarTipoServicios()
        {
            IList<PaperlessTipoServicio> servicios =
                LogicaNegocios.Paperless.Paperless.ListarTipoServicios(Enums.Estado.Habilitado);

            ddlTipoServicio.Properties.Items.Clear();

            ComboBoxItemCollection coll = ddlTipoServicio.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in servicios)
            {
                coll.Add(list);
            }
            ddlTipoServicio.SelectedIndex = 0;
        }

        private void CargarUsuarios()
        {
            Entidades.GlobalObject.ResultadoTransaccion resultado = ProyectoCraft.LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Entidades.Enums.Enums.Estado.Habilitado,
                                                                             Entidades.Enums.Enums.CargosUsuarios.EncargadoDocumental1raEtapa);
            if (resultado.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                ComboBoxItemCollection coll = ddlUsuario1.Properties.Items;
                coll.Add(Utils.Utils.ObtenerPrimerItem());
                IList<Entidades.Usuarios.clsUsuario> usuarios = (IList<Entidades.Usuarios.clsUsuario>)resultado.ObjetoTransaccion;
                foreach (var list in usuarios)
                {
                    coll.Add(list);
                }
                ddlUsuario1.SelectedIndex = 0;
            }

            resultado = ProyectoCraft.LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Entidades.Enums.Enums.Estado.Habilitado,
                                                                             Entidades.Enums.Enums.CargosUsuarios.EncargadoDocumental2daEtapa);
            if (resultado.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                ComboBoxItemCollection coll2 = ddlUsuario2.Properties.Items;
                coll2.Add(Utils.Utils.ObtenerPrimerItem());
                IList<Entidades.Usuarios.clsUsuario> usuarios = (IList<Entidades.Usuarios.clsUsuario>)resultado.ObjetoTransaccion;
                foreach (var list in usuarios)
                {
                    coll2.Add(list);
                }
                ddlUsuario2.SelectedIndex = 0;
            }
        }
        private void CargarGraficos()
        {
            try
            {
                //Cargamos la configuracion
                var configuracion = Base.Configuracion.Configuracion.Instance();
                var opcion = configuracion.GetValue("paperless_GraficosAsignacionUsuario1y2_Enabled"); //puede retornar un true, false o null
                if (opcion.HasValue && opcion.Value.Equals(true))
                {
                    DataTable resUsuario1 = LogicaNegocios.Paperless.Paperless.ObtenerCantidadAsignacionesGrafico("Usuario1", DateTime.Now.AddDays(-30), DateTime.Now);
                    ChartUsuario1.Series.Clear();
                    ChartUsuario1.SeriesDataMember = "Estado";
                    ChartUsuario1.SeriesTemplate.ArgumentDataMember = "Vendedor";
                    ChartUsuario1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Value" });
                    ChartUsuario1.DataSource = (DataTable)resUsuario1;

                    DataTable resUsuario2 = LogicaNegocios.Paperless.Paperless.ObtenerCantidadAsignacionesGrafico("Usuario2", DateTime.Now.AddDays(-30), DateTime.Now);
                    Chartusuario2.Series.Clear();
                    Chartusuario2.SeriesDataMember = "Estado";
                    Chartusuario2.SeriesTemplate.ArgumentDataMember = "Vendedor";
                    Chartusuario2.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Value" });
                    Chartusuario2.DataSource = (DataTable)resUsuario2;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CargarImportancia()
        {
            clsParametrosInfo lstDestinoDireccion =
                    clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.PaperlessImportanciaUsuario1);
            Utils.Utils.CargaComboBoxParametros(lstDestinoDireccion, this.ddlImportanciaU1);
        }



        private void frmPaperlessAsignacion_Leave(object sender, EventArgs e)
        {
            Instancia = null;
        }

        private void btnSiguienteP2_Click(object sender, EventArgs e)
        {
            GuardarPaso1();
            tabAsignacion.SelectedTabPage = tabFechas;
        }

        private void GuardarPaso1()
        {
            if (!ValidarPaso1()) return;

            VistaADominioPaso1();

            ResultadoTransaccion resultado = new ResultadoTransaccion();
            resultado = LogicaNegocios.Paperless.Paperless.GuardaPaso1(PaperlessAsignacionActual);
            if (resultado.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                ValidarEstados();
                PaperlessAsignacionActual.Id = Convert.ToInt64(resultado.ObjetoTransaccion);
                tabAsignacion.SelectedTabPage = tabFechas;
                if (PaperlessAsignacionActual.IdResultado.Equals(1))
                    MessageBox.Show(PaperlessAsignacionActual.GlosaResultado, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool ValidarPaso1()
        {
            bool valida = true;

            dxErrorProvider1.ClearErrors();

            if (txtNumMaster.Text.Length.Equals(0))
            {
                dxErrorProvider1.SetError(txtNumMaster, "Debe ingresar Número de Master", ErrorType.Critical);
                valida = false;
            }
            else
            {
                if (LogicaNegocios.Paperless.Paperless.ValidaNumMaster(txtNumMaster.Text).Equals(true))
                {
                    dxErrorProvider1.SetError(txtNumMaster, "El Número de Master ya existe:" + txtNumMaster.Text, ErrorType.Critical);
                    valida = false;
                }
            }

            if (txtFechaMaster.Text.Length.Equals(0))
            {
                dxErrorProvider1.SetError(txtFechaMaster, "Debe selecionar Fecha de Master", ErrorType.Critical);
                valida = false;
            }

            if (txtNumHousesBL.Text.Length.Equals(0))
            {
                dxErrorProvider1.SetError(txtNumHousesBL, "Debe ingresar número de Houses", ErrorType.Critical);
                valida = false;
            }

            lblAlertaPlazoembarcadores.Visible = true;
            if (ddlTipoCarga.SelectedIndex == 0)
            {
                dxErrorProvider1.SetError(ddlTipoCarga, "Debe seleccionar Tipo de Carga", ErrorType.Critical);
                valida = false;
            }
            else
            {
                if (!((PaperlessTipoCarga)ddlTipoCarga.SelectedItem).EsFAK)
                {
                    lblAlertaPlazoembarcadores.Visible = false;
                }
            }

            if (ddlTipoServicio.SelectedIndex > 0)
            {
                if (((PaperlessTipoServicio)ddlTipoServicio.SelectedItem).Nombre.Equals("Transbordo"))
                {
                    lblAlertaPlazoembarcadores.Visible = false;
                    if ((String.IsNullOrEmpty(txtNaveTransbordo.Text)))
                    {
                        dxErrorProvider1.SetError(txtNave, "Debe seleccionar una nave de transbordo", ErrorType.Critical);
                        valida = false;
                        return false;
                    }

                }
            }

            if (ddlAgente.SelectedIndex == -1)
            {
                dxErrorProvider1.SetError(ddlAgente, "Debe seleccionar un Agente valido", ErrorType.Critical);
                valida = false;
            }
            if (ddlNaviera.SelectedIndex == -1)
            {
                dxErrorProvider1.SetError(ddlNaviera, "Debe seleccionar una Naviera valida", ErrorType.Critical);
                valida = false;
            }

            return valida;
        }
        private void VistaADominioPaso1Update()
        {
            PaperlessAsignacionActual.NumMaster = txtNumMaster.Text;
            PaperlessAsignacionActual.FechaMaster = Convert.ToDateTime(txtFechaMaster.Text);
            PaperlessAsignacionActual.Naviera = (PaperlessNaviera)ddlNaviera.SelectedItem;
            if (txtNave.Text.Trim() == "")
            {
                PaperlessAsignacionActual.Nave = null;
            }
            else
            {
                for (int i = 0; i < ddlNave.Properties.Items.Count; i++)
                {
                    if (ddlNave.Properties.Items[i].ToString() == txtNave.Text)
                        ddlNave.SelectedIndex = i;
                }

                if (ddlNave.SelectedIndex == 0)
                {
                    PaperlessAsignacionActual.Nave = new PaperlessNave() { Nombre = txtNave.Text, Id = 0, Activo = true };
                }
                else
                    PaperlessAsignacionActual.Nave = (PaperlessNave)this.ddlNave.SelectedItem;
            }

            if (txtNaveTransbordo.Text.Trim() == "")
            {
                PaperlessAsignacionActual.NaveTransbordo = null;
            }
            else
            {
                for (int i = 0; i < ddlNaveTransbordo.Properties.Items.Count; i++)
                {
                    if (ddlNaveTransbordo.Properties.Items[i].ToString() == txtNaveTransbordo.Text)
                        ddlNaveTransbordo.SelectedIndex = i;
                }

                if (ddlNaveTransbordo.SelectedIndex == 0)
                {
                    PaperlessAsignacionActual.NaveTransbordo = new PaperlessNave() { Nombre = txtNaveTransbordo.Text, Id = 0, Activo = true };
                }
                else
                    PaperlessAsignacionActual.NaveTransbordo = (PaperlessNave)this.ddlNaveTransbordo.SelectedItem;
            }



            PaperlessAsignacionActual.Viaje = txtViaje.Text;
            PaperlessAsignacionActual.NumHousesBL = Convert.ToInt16(txtNumHousesBL.Text);
            PaperlessAsignacionActual.TipoCarga = (PaperlessTipoCarga)ddlTipoCarga.SelectedItem;

            if (ddlTipoServicio.SelectedIndex <= 0)
                PaperlessAsignacionActual.TipoServicio = null;
            else
                PaperlessAsignacionActual.TipoServicio = (PaperlessTipoServicio)ddlTipoServicio.SelectedItem;

        }

        private void VistaADominioPaso1()
        {
            PaperlessAsignacionActual.NumMaster = txtNumMaster.Text;
            PaperlessAsignacionActual.FechaMaster = Convert.ToDateTime(txtFechaMaster.Text);
            PaperlessAsignacionActual.Estado = Enums.EstadoPaperless.EnAsignacion;

            PaperlessAsignacionActual.Agente = (PaperlessAgente)ddlAgente.SelectedItem;


            PaperlessAsignacionActual.Naviera = (PaperlessNaviera)ddlNaviera.SelectedItem;

            if (txtNave.Text.Trim() == "")
            {
                PaperlessAsignacionActual.Nave = null;
            }
            else
            {
                for (int i = 0; i < ddlNave.Properties.Items.Count; i++)
                {
                    if (ddlNave.Properties.Items[i].ToString() == txtNave.Text)
                        ddlNave.SelectedIndex = i;
                }

                if (ddlNave.SelectedIndex == 0)
                {
                    PaperlessAsignacionActual.Nave = new PaperlessNave() { Nombre = txtNave.Text, Id = 0, Activo = true };
                }
                else
                    PaperlessAsignacionActual.Nave = (PaperlessNave)this.ddlNave.SelectedItem;
            }

            if (txtNaveTransbordo.Text.Trim() == "")
            {
                PaperlessAsignacionActual.NaveTransbordo = null;
            }
            else
            {
                for (int i = 0; i < ddlNaveTransbordo.Properties.Items.Count; i++)
                {
                    if (ddlNaveTransbordo.Properties.Items[i].ToString() == txtNaveTransbordo.Text)
                        ddlNaveTransbordo.SelectedIndex = i;
                }

                if (ddlNaveTransbordo.SelectedIndex == 0)
                {
                    PaperlessAsignacionActual.NaveTransbordo = new PaperlessNave() { Nombre = txtNaveTransbordo.Text, Id = 0, Activo = true };
                }
                else
                    PaperlessAsignacionActual.NaveTransbordo = (PaperlessNave)this.ddlNaveTransbordo.SelectedItem;
            }



            PaperlessAsignacionActual.Viaje = txtViaje.Text;
            PaperlessAsignacionActual.NumHousesBL = Convert.ToInt16(txtNumHousesBL.Text);
            PaperlessAsignacionActual.TipoCarga = (PaperlessTipoCarga)ddlTipoCarga.SelectedItem;
            if (ddlTipoCargaDescLarga.Visible.Equals(true))
            {
                PaperlessAsignacionActual.TipoCarga = (PaperlessTipoCarga)ddlTipoCargaDescLarga.SelectedItem;
            }

            if (ddlTipoServicio.SelectedIndex <= 0)
                PaperlessAsignacionActual.TipoServicio = null;
            else
                PaperlessAsignacionActual.TipoServicio = (PaperlessTipoServicio)ddlTipoServicio.SelectedItem;


        }

        private void btnSiguienteP3_Click(object sender, EventArgs e)
        {
            if (PaperlessAsignacionActual.Estado == Enums.EstadoPaperless.EnAsignacion)
                GuardarPaso2();
            else
                tabAsignacion.SelectedTabPage = tabPrealerta;


            if (PaperlessAsignacionActual.Estado != Enums.EstadoPaperless.Nuevo &&
                PaperlessAsignacionActual.Estado != Enums.EstadoPaperless.EnAsignacion && !PaperlessAsignacionActual.AperturaNavieras.HasValue)
            {
                GuardarFechaAperturaEmbarcadadores();
            }

        }

        private void GuardarFechaAperturaEmbarcadadores()
        {
            if (!ValidarPaso2()) return;
            PaperlessLogAperturaNavieras LogApertura = PrepararLogAperturaNavieras();

            PaperlessAsignacionActual.FechaETA = Convert.ToDateTime(txtFechaETA.Text);

            if (txtAperturaNavieras.Text.Length.Equals(0))
                PaperlessAsignacionActual.AperturaNavieras = null;
            else
                PaperlessAsignacionActual.AperturaNavieras = Convert.ToDateTime(txtAperturaNavieras.Text);

            if (txtPlazoEmbarcadores.Text.Length.Equals(0))
                PaperlessAsignacionActual.PlazoEmbarcadores = null;
            else
                PaperlessAsignacionActual.PlazoEmbarcadores = Convert.ToDateTime(txtPlazoEmbarcadores.Text);

            ResultadoTransaccion resultado = new ResultadoTransaccion();
            resultado = LogicaNegocios.Paperless.Paperless.GuardaPaso2(PaperlessAsignacionActual, LogApertura);
            if (resultado.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                ValidarEstados();
                tabAsignacion.SelectedTabPage = tabPrealerta;
            }
            else
            {
                MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (PaperlessAsignacionActual.IdResultado.Equals(1))
                MessageBox.Show(PaperlessAsignacionActual.GlosaResultado, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void GuardarPaso2()
        {
            if (!ValidarPaso2()) return;

            PaperlessLogAperturaNavieras LogApertura = PrepararLogAperturaNavieras();

            VistaADominioPaso2();

            ResultadoTransaccion resultado = new ResultadoTransaccion();
            resultado = LogicaNegocios.Paperless.Paperless.GuardaPaso2(PaperlessAsignacionActual, LogApertura);
            if (resultado.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                ValidarEstados();
                tabAsignacion.SelectedTabPage = tabPrealerta;
            }
            else
            {
                MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (PaperlessAsignacionActual.IdResultado.Equals(1))
                MessageBox.Show(PaperlessAsignacionActual.GlosaResultado, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private PaperlessLogAperturaNavieras PrepararLogAperturaNavieras()
        {
            PaperlessLogAperturaNavieras log = new PaperlessLogAperturaNavieras();
            log.IdAsignacion = PaperlessAsignacionActual.Id;

            if (!PaperlessAsignacionActual.AperturaNavieras.HasValue)
                log.Accion = Enums.TipoActividadUsuario.Creo;
            else
                log.Accion = Enums.TipoActividadUsuario.Edito;

            log.IdUsuario = Base.Usuario.UsuarioConectado.Usuario.Id;
            log.ValorAnterior = PaperlessAsignacionActual.AperturaNavieras;

            if (!log.ValorAnterior.HasValue)
                log.ValorAnterior = new DateTime(9999, 1, 1);

            if (txtAperturaNavieras.Text.Length.Equals(0))
                log.ValorNuevo = new DateTime(9999, 1, 1);
            else
                log.ValorNuevo = Convert.ToDateTime(txtAperturaNavieras.Text);

            return log;
        }

        private bool ValidarPaso2()
        {
            bool valida = true;

            dxErrorProvider1.ClearErrors();

            if (txtFechaETA.Text.Length.Equals(0))
            {
                valida = false;
                dxErrorProvider1.SetError(txtFechaETA, "Debe seleccionar fecha ETA", ErrorType.Critical);
            }

            //if(txtAperturaNavieras.Text.Length.Equals(0))
            //{
            //    valida = false;
            //    dxErrorProvider1.SetError(txtAperturaNavieras, "Debe seleccionar fecha apertua navieras", ErrorType.Critical);
            //}

            if (((PaperlessTipoCarga)ddlTipoCarga.SelectedItem).EsFAK && (ddlTipoServicio.SelectedIndex > 0 && !((PaperlessTipoServicio)ddlTipoServicio.SelectedItem).Nombre.Equals("Transbordo")))
            {
                if (txtPlazoEmbarcadores.Text.Length.Equals(0))
                {
                    valida = false;
                    dxErrorProvider1.SetError(txtPlazoEmbarcadores, "Debe seleccionar fecha plazo a embarcadores", ErrorType.Critical);
                }
            }
            var configuracion = Base.Configuracion.Configuracion.Instance();
            var opcion = configuracion.GetValue("paperless_txtfechaMaximaVinculacion_Enabled");//puede retornar un true, false o null
            if (opcion.HasValue && opcion.Value.Equals(true))
            {
                if (txtFechaMaximaVinculacion.Text.Length.Equals(0))
                {
                    MessageBox.Show("Debe completar Fecha Maxima de Vinculación", "Paperless", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    valida = false;
                }
            }
            return valida;
        }

        private void VistaADominioPaso2()
        {
            PaperlessAsignacionActual.FechaETA = Convert.ToDateTime(txtFechaETA.Text);

            if (txtAperturaNavieras.Text.Length.Equals(0))
                PaperlessAsignacionActual.AperturaNavieras = null;
            else
            {
                PaperlessAsignacionActual.AperturaNavieras = Convert.ToDateTime(txtAperturaNavieras.Text);
                PaperlessAsignacionActual.AperturaNavieras = new DateTime(PaperlessAsignacionActual.AperturaNavieras.Value.Year,
                    PaperlessAsignacionActual.AperturaNavieras.Value.Month,
                    PaperlessAsignacionActual.AperturaNavieras.Value.Day,
                    23, 59, 59
                    );
            }

            if (txtPlazoEmbarcadores.Text.Length.Equals(0))
                PaperlessAsignacionActual.PlazoEmbarcadores = null;
            else
                PaperlessAsignacionActual.PlazoEmbarcadores = Convert.ToDateTime(txtPlazoEmbarcadores.Text);

            PaperlessAsignacionActual.Estado = Enums.EstadoPaperless.EnAsignacion;
            if (radioCourierDestino.SelectedIndex.Equals(0))
            {
                PaperlessAsignacionActual.ChkCourier = true;
                PaperlessAsignacionActual.ChkEnDestino = false;
            }
            else if (radioCourierDestino.SelectedIndex.Equals(1))
            {
                PaperlessAsignacionActual.ChkEnDestino = true;
                PaperlessAsignacionActual.ChkCourier = false;
            }
            PaperlessAsignacionActual.ChkMasterConfirmado = chkConfirmacionMaster.Checked.Equals(true);
            if (!string.IsNullOrEmpty(txtfechaMasterConfirmado.Text))
                PaperlessAsignacionActual.FechaMasterConfirmado = Convert.ToDateTime(txtfechaMasterConfirmado.Text);
            else
                PaperlessAsignacionActual.FechaMasterConfirmado = null;

            if (!string.IsNullOrEmpty(txtCourier.Text))
                PaperlessAsignacionActual.TxtCourier = txtCourier.Text;
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            GuardarPaso3();
        }

        private void GuardarPaso3()
        {
            var mail = new EnvioMailObject();
            if (!ValidarPaso3()) return;

            Cursor.Current = Cursors.WaitCursor;

            VistaADominioPaso3();

            ResultadoTransaccion resultado = new ResultadoTransaccion();
            resultado = LogicaNegocios.Paperless.Paperless.GuardaPaso3(PaperlessAsignacionActual);
            if (resultado.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                resultado = mail.EnviarMailPaperlessAsignacionUsuario1(PaperlessAsignacionActual);
                //resultado = Utils.EnvioEmail.EnviarMailPaperlessAsignacionUsuario1(PaperlessAsignacionActual);
                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Ocurrio un problema al intentar enviar el email. \n" + resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Cursor.Current = Cursors.Default;
                //ValidarEstados();
                //tabAsignacion.SelectedTabPage = tabPrealerta;
                MessageBox.Show("Asignación realizada correctamente", "Paperless", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                if (MessageBox.Show("¿Desea realizar una nueva asignación?", "Paperless Asignacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LimpiarFormulario();
                    tabAsignacion.SelectedTabPage = tabInfGeneral;
                }
                else
                {
                    Paperless.Asignacion.frmListaAsignaciones form = frmListaAsignaciones.Instancia;
                    form.ListarAsignaciones();

                    Instancia = null;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (PaperlessAsignacionActual.IdResultado.Equals(1))
                MessageBox.Show(PaperlessAsignacionActual.GlosaResultado, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool ValidarPaso3()
        {
            bool valida = true;

            if (ddlUsuario1.SelectedIndex == 0)
            {
                dxErrorProvider1.SetError(ddlUsuario1, "Debe seleccionar Usuario 1", ErrorType.Critical);
                valida = false;
            }

            if (ddlImportanciaU1.SelectedIndex.Equals(0))
            {
                dxErrorProvider1.SetError(ddlImportanciaU1, "Debe seleccionar Importancia", ErrorType.Critical);
                valida = false;
            }

            if (ddlUsuario2.SelectedIndex == 0)
            {
                dxErrorProvider1.SetError(ddlUsuario2, "Debe seleccionar Usuario 2", ErrorType.Critical);
                valida = false;
            }
            return valida;
        }

        private void VistaADominioPaso3()
        {
            PaperlessAsignacionActual.Usuario1 = (clsUsuario)ddlUsuario1.SelectedItem;
            PaperlessAsignacionActual.ObservacionUsuario1 = txtObsercacionU1.Text.Trim();
            PaperlessAsignacionActual.ImportanciaUsuario1 = (clsItemParametro)ddlImportanciaU1.SelectedItem;

            PaperlessAsignacionActual.Usuario2 = (clsUsuario)ddlUsuario2.SelectedItem;
            PaperlessAsignacionActual.ObservacionUsuario2 = txtObservacionU2.Text.Trim();

            PaperlessAsignacionActual.Estado = Enums.EstadoPaperless.AsignadoUsuario1;

            PaperlessAsignacionActual.FechaCreacion = DateTime.Now;

        }

        private void frmPaperlessAsignacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }

        private void LimpiarFormulario()
        {
            txtAgente.Text = "";
            txtAperturaNavieras.Text = "";
            txtFechaETA.Text = "";
            txtFechaMaster.Text = "";
            txtNave.Text = "";
            txtNaviera.Text = "";
            txtNumHousesBL.Text = "";
            txtNumMaster.Text = "";
            txtObsercacionU1.Text = "";
            txtObservacionU2.Text = "";
            txtPlazoEmbarcadores.Text = "";
            txtViaje.Text = "";
            ddlAgente.SelectedIndex = 0;
            ddlImportanciaU1.SelectedIndex = 0;
            ddlNave.SelectedIndex = 0;
            ddlNaveTransbordo.SelectedIndex = 0;
            ddlNaviera.SelectedIndex = 0;
            ddlTipoCarga.SelectedIndex = 0;
            ddlUsuario1.SelectedIndex = 0;
            ddlUsuario2.SelectedIndex = 0;
            PaperlessAsignacionActual = null;
        }

        private void txtNumHousesBL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtNumHousesBL.Enabled = true;
            lvlMotivo.Visible = true;
            txtMotivo.Visible = true;
            txtfechaMasterConfirmado.Enabled = true;
            chkConfirmacionMaster.Enabled = true;

        }
        private void btnEditarFechas_Click(object sender, EventArgs e)
        {
            txtFechaETA.Properties.ReadOnly = false;
            txtAperturaNavieras.Properties.ReadOnly = false;
            txtPlazoEmbarcadores.Properties.ReadOnly = false;

            txtFechaETA.Enabled = true;
            txtAperturaNavieras.Enabled = true;
            txtPlazoEmbarcadores.Enabled = true;
            chkConfirmacionMaster.Enabled = true;
            radioCourierDestino.Enabled = true;
            txtfechaMasterConfirmado.Properties.ReadOnly = false;
            txtfechaMasterConfirmado.Enabled = true;
            txtCourier.Enabled = true;

        }

        private void btnGrabarBl_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMotivo.Text.Trim()))
            {
                MessageBox.Show("Ingrese Motivo Modificacion N° Houses/BL");
            }
            else
            {
                txtNumHousesBL.Enabled = false;
                lvlMotivo.Visible = false;
                txtMotivo.Visible = false;
                VistaADominioPaso1Update();
                PaperlessAsignacionActual.MotivoModificacion = txtMotivo.Text;
                ResultadoTransaccion resultado = new ResultadoTransaccion();
                resultado = LogicaNegocios.Paperless.Paperless.GuardaPaso1(PaperlessAsignacionActual);
                if (PaperlessAsignacionActual.IdResultado.Equals(1))
                    MessageBox.Show(PaperlessAsignacionActual.GlosaResultado, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BloqueaTabFechas()
        {
            txtFechaETA.Properties.ReadOnly = true;
            txtAperturaNavieras.Properties.ReadOnly = true;
            txtPlazoEmbarcadores.Properties.ReadOnly = true;
        }
        private void btnGrabarFechas_Click(object sender, EventArgs e)
        {
            if (!ValidarPaso2BtnEditar()) return;

            PaperlessLogAperturaNavieras LogApertura = PrepararLogAperturaNavieras();

            PaperlessAsignacionActual.FechaETA = Convert.ToDateTime(txtFechaETA.Text);

            if (txtAperturaNavieras.Text.Length.Equals(0))
                PaperlessAsignacionActual.AperturaNavieras = null;
            else
                PaperlessAsignacionActual.AperturaNavieras = Convert.ToDateTime(txtAperturaNavieras.Text);

            if (txtPlazoEmbarcadores.Text.Length.Equals(0))
                PaperlessAsignacionActual.PlazoEmbarcadores = null;
            else
                PaperlessAsignacionActual.PlazoEmbarcadores = Convert.ToDateTime(txtPlazoEmbarcadores.Text);

            if (radioCourierDestino.SelectedIndex.Equals(0))
            {
                PaperlessAsignacionActual.ChkCourier = true;
                PaperlessAsignacionActual.ChkEnDestino = false;
            }
            else if (radioCourierDestino.SelectedIndex.Equals(1))
            {
                PaperlessAsignacionActual.ChkEnDestino = true;
                PaperlessAsignacionActual.ChkCourier = false;
            }
            PaperlessAsignacionActual.ChkMasterConfirmado = chkConfirmacionMaster.Checked.Equals(true);
            if (!string.IsNullOrEmpty(txtfechaMasterConfirmado.Text))
                PaperlessAsignacionActual.FechaMasterConfirmado = Convert.ToDateTime(txtfechaMasterConfirmado.Text);

            if (!string.IsNullOrEmpty(txtCourier.Text))
                PaperlessAsignacionActual.TxtCourier = txtCourier.Text;


            ResultadoTransaccion resultado = new ResultadoTransaccion();
            resultado = LogicaNegocios.Paperless.Paperless.GuardaPaso2(PaperlessAsignacionActual, LogApertura);
            if (resultado.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                ValidarEstados();
                MessageBox.Show("Se han Grabado las fechas Correctamente", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (PaperlessAsignacionActual.IdResultado.Equals(1))
                MessageBox.Show(PaperlessAsignacionActual.GlosaResultado, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private bool ValidarPaso2BtnEditar()
        {
            bool valida = true;

            dxErrorProvider1.ClearErrors();

            if (txtFechaETA.Text.Length.Equals(0))
            {
                valida = false;
                dxErrorProvider1.SetError(txtFechaETA, "Debe seleccionar fecha ETA", ErrorType.Critical);
            }

            if (((PaperlessTipoCarga)ddlTipoCarga.SelectedItem).EsFAK &&
                (ddlTipoServicio.SelectedIndex > 0 && !((PaperlessTipoServicio)ddlTipoServicio.SelectedItem).Nombre.Equals("Transbordo")))
            {
                if (txtPlazoEmbarcadores.Text.Length.Equals(0))
                {
                    valida = false;
                    dxErrorProvider1.SetError(txtPlazoEmbarcadores, "Debe seleccionar fecha plazo a embarcadores", ErrorType.Critical);
                }
            }
            return valida;
        }

        private void ddlTipoServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((ddlTipoServicio.SelectedIndex == 0 || !((PaperlessTipoServicio)ddlTipoServicio.SelectedItem).Nombre.Equals("Transbordo")))
                {
                    lblNaveTransbordo.Visible = txtNaveTransbordo.Visible = false;
                    txtNaveTransbordo.Text = "";
                }
                else
                {
                    lblNaveTransbordo.Visible = txtNaveTransbordo.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnEditarTransbordo_Click(object sender, EventArgs e)
        {
            txtNaveTransbordo.Enabled = true;
        }

        private void btnGrabarTransbordo_Click(object sender, EventArgs e)
        {
            VistaADominioPaso1Update();
            ResultadoTransaccion resultado = new ResultadoTransaccion();
            resultado = LogicaNegocios.Paperless.Paperless.GuardaPaso1(PaperlessAsignacionActual);
            if (resultado.Estado.ToString().Equals("Aceptada"))
                MessageBox.Show("Nave Transbordo Modificada exitosamente", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (PaperlessAsignacionActual.IdResultado.Equals(1))
                MessageBox.Show(PaperlessAsignacionActual.GlosaResultado, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tabInfGeneral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMantNaviera_Click(object sender, EventArgs e)
        {
            Clientes.frmNavieras form = Clientes.frmNavieras.Instancia;
            form.fromPaperless = true;
            form.InstanciaPaperless = Instancia;
            form.Show();
        }
        private void ChkCourierDestino(int valor)
        {
            if (valor.Equals(0))
            {
                PaperlessAsignacionActual.ChkCourier = true;
                PaperlessAsignacionActual.ChkEnDestino = false;
            }
            else if (valor.Equals(1))
            {
                PaperlessAsignacionActual.ChkEnDestino = true;
                PaperlessAsignacionActual.ChkCourier = false;
            }
        }

        private void txtFechaETA_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFechaETA.Text))
                txtfechaMasterConfirmado.Text = Convert.ToDateTime(txtFechaETA.Text).AddDays(-15).ToString();

            CargaFechaMaximaVinculacion();

        }

        private void chkConfirmacionMaster_CheckedChanged(object sender, EventArgs e)
        {
            PaperlessAsignacionActual.ChkMasterConfirmado = true;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChkCourierDestino(radioCourierDestino.SelectedIndex);
        }
        private void CargaMasterConfirmado()
        {
            chkConfirmacionMaster.Checked = PaperlessAsignacionActual.ChkMasterConfirmado;
            if (PaperlessAsignacionActual.ChkEnDestino)
                radioCourierDestino.SelectedIndex = 1;
            else if (PaperlessAsignacionActual.ChkCourier)
                radioCourierDestino.SelectedIndex = 0;
            else
                radioCourierDestino.SelectedIndex = 0;

            txtCourier.Text = PaperlessAsignacionActual.TxtCourier;
            txtfechaMasterConfirmado.Text = PaperlessAsignacionActual.FechaMasterConfirmado.HasValue ? PaperlessAsignacionActual.FechaMasterConfirmado.Value.ToString() : "";
        }
        private void CargaShippingPuerto()
        {
            try
            {
                var hbls = LogicaNegocios.Paperless.Paperless.Usuario1ObtenerHousesBL(PaperlessAsignacionActual.Id32);
                if (hbls != null)
                    if (hbls.Count != 0 && hbls.Count < 2)
                    {
                        if (!string.IsNullOrEmpty(hbls[0].ShippingInstruction))
                            txtShippingInstruction.Text = hbls[0].ShippingInstruction;
                        if (!string.IsNullOrEmpty(hbls[0].Puerto))
                            txtPuerto.Text = hbls[0].Puerto;
                    }
            }
            catch (Exception ex)
            {
            }
        }

        private void MenuMantNavieras_Click(object sender, EventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            Clientes.frmNavieras form = Clientes.frmNavieras.Instancia;
            form.fromPaperless = true;
            form.InstanciaPaperless = Instancia;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmListaAsignaciones form = frmListaAsignaciones.Instancia;
            form.ListarAsignaciones();
            Instancia = null;
            Close();
        }

        private void tabFechas_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtFechaMaximaVinculacion_EditValueChanged(object sender, EventArgs e)
        {
            if (!txtFechaMaximaVinculacion.Text.Length.Equals(0))
                PaperlessAsignacionActual.FechaMaximaVinculacion = Convert.ToDateTime(txtFechaMaximaVinculacion.Text);
        }

        private void ddlTipoCarga_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (IsBrasil)
               // ddlTipoCargaDescLarga.Visible = ddlTipoCarga.SelectedItem.ToString().Equals("FCL");
        }
    }
}
