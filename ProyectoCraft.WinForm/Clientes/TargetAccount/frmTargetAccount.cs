using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Clientes.Direcciones;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Ventas.Productos;
using ProyectoCraft.Entidades.Ventas.Traficos;
using ProyectoCraft.LogicaNegocios.Parametros;
using ProyectoCraft.Entidades.Clientes.TargetAccount;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.WinForm.Clientes.TargetAccount
{
    public partial class frmTargetAccount : Form
    {
        public frmTargetAccount()
        {
            InitializeComponent();
        }

        #region "Singleton"
        private static frmTargetAccount _instance = null;
        public static frmTargetAccount Instancia
        {
            get
            {
                if (_instance == null) _instance = new frmTargetAccount();

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }        
        #endregion

        #region "Public Properties"

        private Enums.TipoAccionFormulario _accion;
        public Enums.TipoAccionFormulario Accion
        {
            get { return _accion; }
            set { _accion = value; }
        }

        private Int64 _idTargetSource;
        public Int64 IdTargetSource
        {
            get { return _idTargetSource; }
            set { _idTargetSource = value; }
        }


        #endregion

        #region "Private Properties"

        private clsTargetAccount _targetaccount = null;
        private clsTargetAccount TargetAccount
        {
            get { return _targetaccount; }
            set { _targetaccount = value; }

        }


        #endregion

        #region "Eventos"

            #region Formulario

            private void frmTargetAccount_Load(object sender, EventArgs e)
            {
                TargetAccount = new clsTargetAccount();
                LimpiarLabelsResumen();
                //METODO QUE USARA LEO PARA CREAR EL TARGET ACCOUNT
                //FORMA 1: PARAMETROS POR OBJETO TARGETACCOUNT
                //TargetAccount = new clsTargetAccount("PRUEBAAAAA", 1);
                //LogicaNegocios.Clientes.clsTargetAccount.CreatTargetAccount(TargetAccount);

                //FORMA 2: PARAMETROS POR PARAMETROS EN EL METODO
                //LogicaNegocios.Clientes.clsTargetAccount.CreatTargetAccount("PRUEBA 7", 7);
                //LogicaNegocios.Clientes.clsTargetAccount.CreatTargetAccount("PRUEBA 8", 8);
                //LogicaNegocios.Clientes.clsTargetAccount.CreatTargetAccount("PRUEBA 9", 9);
                //LogicaNegocios.Clientes.clsTargetAccount.CreatTargetAccount("PRUEBA 10", 10);
                //LogicaNegocios.Clientes.clsTargetAccount.CreatTargetAccount("PRUEBA 11", 11);
                //LogicaNegocios.Clientes.clsTargetAccount.CreatTargetAccount("PRUEBA 12", 12);
                //LogicaNegocios.Clientes.clsTargetAccount.CreatTargetAccount("PRUEBA 13", 13);
                //LogicaNegocios.Clientes.clsTargetAccount.CreatTargetAccount("PRUEBA 14", 14);
                //LogicaNegocios.Clientes.clsTargetAccount.CreatTargetAccount("PRUEBA 15", 15);


                CargarPaises();
                CargarProductos();
                CargarTraficos();
                CargarOrigenesCarga();
                CargarDestinosCarga();
                CargarTraficosExistentes();
                CargarUnidadesDeMedida();
                CargarTerminoCompra();
                CargarIncoTerms();
                CargarEmpresasCompetencia();
                CargarServiciosCoplementarios();
                CargarObjeciones();
                //CargarAccionesTomar();
                
                BuscarTargetAccount();

                ValidarAcciones();


            }

            private void frmTargetAccount_FormClosing(object sender, FormClosingEventArgs e)
            {
                Instancia = null;
            }

            #endregion
        
            #region Menu

                private void MenuGuardar_Click(object sender, EventArgs e)
                {
                    Guardar();
                }

                private void MenuSalir_Click(object sender, EventArgs e)
                {
                    Instancia = null;
                    this.Close();
                }

            #endregion

            #region Eventos

            #region Paso1

                private void btnSiguienteP2_Click(object sender, EventArgs e)
            {
                Guardar();
                //tabTelefonico.PageEnabled = true;
                //tabTargetaccount.SelectedTabPage = tabTelefonico;
            }

                private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cboPais.SelectedIndex > 0)
                {
                    if ((clsPais)cboPais.SelectedItem != null)
                        CargarCiudades(((clsPais)cboPais.SelectedItem).Id);
                }
                else
                    CargarCiudades(-9);
            }

                private void cboRegion_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cboPais.SelectedIndex > 0 && cboRegion.SelectedIndex > 0)
                {
                    if ((clsCiudad)cboRegion.SelectedItem != null)
                        cargarComunas(((clsCiudad)cboRegion.SelectedItem).Id);
                }
                else
                    cargarComunas(-9);
            }

                private void btnAgregarOrigen_Click(object sender, EventArgs e)
            {
                if (txtBusquedaOrigenes.Text == "")
                {
                    dxErrorProvider1.SetError(txtBusquedaOrigenes, "Debe ingresar un Origen", ErrorType.Critical);
                    return;
                }

                AgregarOrigenCarga();

            }

                private void btnQuitarOrigen_Click(object sender, EventArgs e)
            {
                if (lstOrigenes.SelectedIndex < 0)
                {
                    dxErrorProvider1.SetError(lstOrigenes, "Debe seleccionar un Origen", ErrorType.Critical);
                    return;
                }

                QuitarOrigenCarga();
            }

                private void btnAgregarDestino_Click(object sender, EventArgs e)
            {
                if (txtBusquedaDestinos.Text == "")
                {
                    dxErrorProvider1.SetError(txtBusquedaDestinos, "Debe ingresar un Destino", ErrorType.Critical);
                    return;
                }

                AgregarDestinoCarga();
            }

                private void btnQuitarDestino_Click(object sender, EventArgs e)
            {
                if (lstDestinos.SelectedIndex < 0)
                {
                    dxErrorProvider1.SetError(lstDestinos, "Debe seleccionar un Destino", ErrorType.Critical);
                    return;
                }

                QuitarDestinoCarga();
            }

                private void txtRUT_Leave(object sender, EventArgs e)
                {
                    bool error = false;
                    if (txtRUT.Text.Trim() != "")
                    {
                        error = Utils.Utils.ValidaRut(txtRUT.Text.Trim());
                    }
                    if (error)
                    {
                        dxErrorProvider1.SetError(txtRUT, "El Rut no es valido", ErrorType.Critical);
                        MenuGuardar.Enabled = false;
                    }
                    else
                    {
                        dxErrorProvider1.SetError(txtRUT, "");
                        MenuGuardar.Enabled = true;
                    }
                }

            #endregion

            #region Paso2

                private void btnSiguienteP3_Click(object sender, EventArgs e)
            {
                Guardar();
            }

                private void btnAgregarCompetencia_Click(object sender, EventArgs e)
                {
                    if (txtConQuienEmbarca.Text.Length.Equals(0))
                    {
                        dxErrorProvider1.SetError(txtConQuienEmbarca, "Debe ingresar una Descripcion", ErrorType.Critical);
                        return;
                    }

                    AgregarEmpresaCompetencia();
                }

                private void btnQuitarCompetencia_Click(object sender, EventArgs e)
                {
                    if (lstConQuienEmbarcan.SelectedIndex < 0)
                    {
                        dxErrorProvider1.SetError(lstOrigenes, "Debe seleccionar una Empresa", ErrorType.Critical);
                        return;
                    }

                    QuitarEmbarcaCon();
                }

                private void btnAgregarTomaDesiciones_Click(object sender, EventArgs e)
                {
                    if (txtNombreTomaDesiciones.Text.Length.Equals(0))
                    {
                        dxErrorProvider1.SetError(txtNombreTomaDesiciones, "Debe ingresar un Nombre", ErrorType.Critical);
                        return;
                    }

                    AgregarTomaDesiciones();
                }

                private void btnQuitarTomaDesiciones_Click(object sender, EventArgs e)
                {
                    if (lstTomanDesiciones.SelectedIndex < 0)
                    {
                        dxErrorProvider1.SetError(lstOrigenes, "Debe seleccionar un Nombre", ErrorType.Critical);
                        return;
                    }
                    QuitarTomaDesiciones();
                }
              
            #endregion

            #region Paso3

                private void btnAgregarPersonales_Click(object sender, EventArgs e)
                {
                    if (txtPersonal.Text.Length.Equals(0))
                    {
                        dxErrorProvider1.SetError(txtPersonal, "Debe ingresar una Descripcion", ErrorType.Critical);
                        return;
                    }

                    AgregarPersonal();
                }

                private void btnQuitarPersonales_Click(object sender, EventArgs e)
                {
                    if (lstPersonales.SelectedIndex < 0)
                    {
                        dxErrorProvider1.SetError(lstPersonales, "Debe seleccionar una Descripcion", ErrorType.Critical);
                        return;
                    }

                    QuitarPersonal();
                }

            #endregion

            #endregion

        #endregion

        #region "Metodos"

            #region General

                private void BuscarTargetAccount()
                {
                    ResultadoTransaccion resultado = new ResultadoTransaccion();

                    resultado = LogicaNegocios.Clientes.clsTargetAccount.ObtenerTargetAccountPorIdSource(IdTargetSource);
                    if (resultado.Estado == Enums.EstadoTransaccion.Aceptada)
                    {
                        TargetAccount = new clsTargetAccount();
                        TargetAccount = (clsTargetAccount)resultado.ObjetoTransaccion;

                        if(TargetAccount == null)
                        {
                            MessageBox.Show("El Target buscado no existe.", "Target Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tabTargetAccount.Enabled = false;

                            return;
                        }

                        CargarFormulario();
                    }
                    else
                    {
                        MessageBox.Show(resultado.Descripcion, "Target Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                private void CargarFormulario()
                {

                    if(TargetAccount == null) return;

                    //Paso 1
                    txtNombreTarget.Text = TargetAccount.ClienteMaster.NombreCompañia;
                    lblEstado.Text = "Estado: " + Convert.ToString(TargetAccount.Estado).Replace("_", " ");
                    this.Text = "Target Account - Estado: " + Convert.ToString(TargetAccount.Estado).Replace("_", " ");

                    txtRUT.Text = TargetAccount.ClienteMaster.RUT;

                    if (TargetAccount.ClienteMaster.DireccionInfo != null && TargetAccount.ClienteMaster.DireccionInfo.Items.Count > 0)
                    {
                        txtDireccion.Text = TargetAccount.ClienteMaster.DireccionInfo.Items[0].NombreDireccion;
                        txtNumero.Text = TargetAccount.ClienteMaster.DireccionInfo.Items[0].Numero;
                        txtOficinaDpto.Text = TargetAccount.ClienteMaster.DireccionInfo.Items[0].OficinaDpto;
                        cboPais.SelectedItem = TargetAccount.ClienteMaster.DireccionInfo.Items[0].Pais;
                        cboRegion.SelectedItem = TargetAccount.ClienteMaster.DireccionInfo.Items[0].Ciudad;
                        cboComuna.SelectedItem = TargetAccount.ClienteMaster.DireccionInfo.Items[0].Comuna;
                    }


                    txtTelefonoEmpresa.Text = TargetAccount.TelefonoEmpresa;
                    txtTelefonoDirecto.Text = TargetAccount.TelefonoDirecto;

                    //for (int i = 0; i <= lstTraficos.Items.Count - 1; i++)
                    //{
                    //    Entidades.Ventas.Traficos.clsTrafico valor = (Entidades.Ventas.Traficos.clsTrafico)lstTraficos.Items[i];
                    //    foreach (Entidades.Ventas.Traficos.clsTrafico trafico in TargetAccount.Traficos)
                    //    {
                    //        if (valor.Id == trafico.Id)
                    //        {
                    //            lstTraficos.SetItemChecked(i, true);
                    //            break;
                    //        }
                    //    }
                    //}
                    lstTraficos.DataSource = TargetAccount.Traficos;
                    lstTraficos.Refresh();

                    txtEmbarquesMes.Text = TargetAccount.EmbarquesPorMes.ToString();
                    txtCantidadLCL.Text = TargetAccount.CantidadLCL.ToString();
                    if (TargetAccount.UMLCL == null)
                        cboUMLCL.SelectedIndex = 0;
                    else
                        cboUMLCL.SelectedItem = TargetAccount.UMLCL;

                    txtCantidadFCL.Text = TargetAccount.CantidadFCL.ToString();
                    if (TargetAccount.UMFCL == null)
                        cboUMFCL.SelectedIndex = 0;
                    else
                        cboUMFCL.SelectedItem = TargetAccount.UMFCL;

                    txtCantidadAereo.Text = TargetAccount.CantidadAereo.ToString();
                    if (TargetAccount.UMAereo == null)
                        cboUMAereo.SelectedIndex = 0;
                    else
                        cboUMAereo.SelectedItem = TargetAccount.UMAereo;

                    if (TargetAccount.TerminoCompra == null)
                        cboTerminoCompra.SelectedIndex = 0;
                    else
                        cboTerminoCompra.SelectedItem = TargetAccount.TerminoCompra;

                    if (TargetAccount.IncoTerm == null)
                        cboIncoTerms.SelectedIndex = 0;
                    else
                        cboIncoTerms.SelectedItem = TargetAccount.IncoTerm;

                    lstOrigenes.DataSource = TargetAccount.OrigenesCarga;
                    lstDestinos.DataSource = TargetAccount.DestinosCarga;

                    txtObservacionGeneral.Text = TargetAccount.ObservacionInfGeneral;

                    //Paso 2
                    txtNombreContacto.Text = TargetAccount.ContactoNombre;
                    txtMailContacto.Text = TargetAccount.ContactoEmail;
                    txtCargoContacto.Text = TargetAccount.ContactoCargo;
                    txtObservacionLlamada.Text = TargetAccount.ObservacionLlamadaTelefonica;
                    lstConQuienEmbarcan.DataSource = TargetAccount.EmbarcaCon;
                    lstTomanDesiciones.DataSource = TargetAccount.TomaDesiciones;

                    //Paso 3                
                    for (int i = 0; i <= lstProductos.Items.Count - 1; i++)
                    {
                        clsTipoProducto valor = (clsTipoProducto)lstProductos.Items[i];
                        foreach (clsClientesProductos producto in TargetAccount.ClienteMaster.ProductosPreferidos)
                        {
                            if (valor.Id == producto.Producto.Id)
                            {
                                lstProductos.SetItemChecked(i, true);
                                break;
                            }
                        }
                    }

                    for (int i = 0; i <= lstServiciosComplementarios.Items.Count - 1; i++)
                    {
                        clsTipoServicioComplementario valor = (clsTipoServicioComplementario)lstServiciosComplementarios.Items[i];
                        foreach (clsTipoServicioComplementario servicio in TargetAccount.ServiciosComplementarios)
                        {
                            if (valor.Id == servicio.Id)
                            {
                                lstServiciosComplementarios.SetItemChecked(i, true);
                                break;
                            }
                        }
                    }

                    lstPersonales.DataSource = TargetAccount.Personales;

                    for (int i = 0; i <= lstObjeciones.Items.Count - 1; i++)
                    {
                        clsTipoObjeciones valor = (clsTipoObjeciones)lstObjeciones.Items[i];
                        foreach (clsTipoObjeciones objecion in TargetAccount.Objeciones)
                        {
                            if (valor.Id == objecion.Id)
                            {
                                lstObjeciones.SetItemChecked(i, true);
                                break;
                            }
                        }
                    }

                    if(TargetAccount.AccionTomar != null)
                    {
                        txtQueNecesita.Text = TargetAccount.AccionTomar.QueNecesita;
                        if(TargetAccount.AccionTomar.ProximaOrden.HasValue)
                            txtProximaOrgen.Text = TargetAccount.AccionTomar.ProximaOrden.Value.ToShortDateString();

                        txtComoComunicara.Text = TargetAccount.AccionTomar.ComoComunicara;
                    }
                        

                    //for (int i = 0; i <= lstAccionesATomar.Items.Count - 1; i++)
                    //{
                    //    clsTipoAccionesTomar valor = (clsTipoAccionesTomar)lstAccionesATomar.Items[i];
                    //    foreach (clsTipoAccionesTomar accion in TargetAccount.AccionesTomar)
                    //    {
                    //        if (valor.Id == accion.Id)
                    //        {
                    //            lstAccionesATomar.SetItemChecked(i, true);
                    //            break;
                    //        }
                    //    }
                    //}

                    txtObservacionVisita.Text = TargetAccount.ObservacionVisita;


                }
                
                private void ValidarAcciones()
                {
                    if (TargetAccount == null) return;

                    if (TargetAccount.Estado == Enums.EstadosMetas.Asignado)
                    {
                        TabInfGeneral.PageEnabled = true;
                        TabInfGeneral.Appearance.Header.ForeColor = Color.DodgerBlue;

                        tabTelefonico.PageEnabled = false;
                        tabTelefonico.Appearance.Header.ForeColor = Color.Black;

                        tabVisita.PageEnabled = false;
                        tabVisita.Appearance.Header.ForeColor = Color.Black;

                        tabTargetAccount.SelectedTabPage = TabInfGeneral;
                        lblPasoActual.Text = "Paso Actual: Información General";

                        DevExpress.Utils.ToolTipItem a = TabInfGeneral.SuperTip.Items[1].Container.Items[1] as DevExpress.Utils.ToolTipItem;
                        a.Text = "Ud se encuentra en este paso";

                        DevExpress.Utils.ToolTipItem b = tabTelefonico.SuperTip.Items[1].Container.Items[1] as DevExpress.Utils.ToolTipItem;
                        b.Text = "Debe completar el Primer Paso acceder a este";

                        DevExpress.Utils.ToolTipItem c = tabVisita.SuperTip.Items[1].Container.Items[1] as DevExpress.Utils.ToolTipItem;
                        c.Text = "Debe completar el Primer Paso acceder a este";
                    }

                    if (TargetAccount.Estado == Enums.EstadosMetas.Informacion_General)
                    {
                        TabInfGeneral.PageEnabled = true;
                        TabInfGeneral.Appearance.Header.ForeColor = Color.SeaGreen;

                        tabTelefonico.PageEnabled = true;
                        tabTelefonico.Appearance.Header.ForeColor = Color.DodgerBlue;

                        tabVisita.PageEnabled = false;

                        tabTargetAccount.SelectedTabPage = tabTelefonico;
                        lblPasoActual.Text = "Paso Actual: Contacto Telefónico";

                        DevExpress.Utils.ToolTipItem a = TabInfGeneral.SuperTip.Items[1].Container.Items[1] as DevExpress.Utils.ToolTipItem;
                        a.Text = "Este paso ya esta listo";

                        DevExpress.Utils.ToolTipItem b = tabTelefonico.SuperTip.Items[1].Container.Items[1] as DevExpress.Utils.ToolTipItem;
                        b.Text = "Ud se encuentra en este paso";

                        DevExpress.Utils.ToolTipItem c = tabVisita.SuperTip.Items[1].Container.Items[1] as DevExpress.Utils.ToolTipItem;
                        c.Text = "Debe completar el Primer Paso acceder a este";
                    }

                    if (TargetAccount.Estado == Enums.EstadosMetas.Contacto_Telefonico)
                    {
                        TabInfGeneral.PageEnabled = true;
                        TabInfGeneral.Appearance.Header.ForeColor = Color.SeaGreen;

                        tabTelefonico.PageEnabled = true;
                        tabTelefonico.Appearance.Header.ForeColor = Color.SeaGreen;

                        tabVisita.PageEnabled = true;
                        tabVisita.Appearance.Header.ForeColor = Color.DodgerBlue;

                        tabTargetAccount.SelectedTabPage = tabVisita;
                        lblPasoActual.Text = "Paso Actual: Visita";

                        DevExpress.Utils.ToolTipItem a = TabInfGeneral.SuperTip.Items[1].Container.Items[1] as DevExpress.Utils.ToolTipItem;
                        a.Text = "Este paso ya esta listo";

                        DevExpress.Utils.ToolTipItem b = tabTelefonico.SuperTip.Items[1].Container.Items[1] as DevExpress.Utils.ToolTipItem;
                        b.Text = "Este paso ya esta listo";

                        DevExpress.Utils.ToolTipItem c = tabVisita.SuperTip.Items[1].Container.Items[1] as DevExpress.Utils.ToolTipItem;
                        c.Text = "Ud se encuentra en este paso";
                    }

                    if (TargetAccount.Estado == Enums.EstadosMetas.Visita || 
                        TargetAccount.Estado == Enums.EstadosMetas.Cierre || 
                        TargetAccount.Estado == Enums.EstadosMetas.Cancelado)
                    {
                        TabInfGeneral.PageEnabled = true;
                        TabInfGeneral.Appearance.Header.ForeColor = Color.SeaGreen;

                        tabTelefonico.PageEnabled = true;
                        tabTelefonico.Appearance.Header.ForeColor = Color.SeaGreen;

                        tabVisita.PageEnabled = true;
                        tabVisita.Appearance.Header.ForeColor = Color.SeaGreen;

                        //tabResumen.PageEnabled = true;

                        tabTargetAccount.SelectedTabPage = tabResumen;
                        lblPasoActual.Text = "Resumen Target Account";
                        CargarResumen();
                        //lblPasoActual.Text = "";

                        DevExpress.Utils.ToolTipItem a = TabInfGeneral.SuperTip.Items[1].Container.Items[1] as DevExpress.Utils.ToolTipItem;
                        a.Text = "Este paso ya esta listo";

                        DevExpress.Utils.ToolTipItem b = tabTelefonico.SuperTip.Items[1].Container.Items[1] as DevExpress.Utils.ToolTipItem;
                        b.Text = "Este paso ya esta listo";
                        
                        DevExpress.Utils.ToolTipItem c = tabVisita.SuperTip.Items[1].Container.Items[1] as DevExpress.Utils.ToolTipItem;
                        c.Text = "Este paso ya esta listo";
                    }
                }

                private void LimpiarLabelsResumen()
                {
                    //Paso 1
                    lblNombreTarget.Text = "";
                    lblRUT.Text = "";
                    lblDireccion.Text = "";
                    lblTelefonoEmpresa.Text = "";
                    lblTelefonoDirecto.Text = "";
                    lblTerminoCompra.Text = "";
                    lblIncoterm.Text = "";
                    lblTraficos.Text = "";                    
                    lblOrigenes.Text = "";                    
                    lblDestino.Text = "";
                    
                    //Paso 2
                    lblNombreContacto.Text = "";
                    lblEmailContacto.Text = "";
                    lblCargoContacto.Text = "";

                    lblCompetencia.Text = "";                    
                    lbltomaDesiciones.Text = "";
                    
                    //Paso 3
                    lblProductos.Text = "";
                    
                    lblServiciosComplementarios.Text = "";
                    
                    lblPersonales.Text = "";
                    
                    lblObjeciones.Text = "";
                    
                    lblAccionesTomar.Text = "";
                                                                                
                    lblMetaNombre.Text = "";
                    lblMetaCommodity.Text = "";
                    lblMetaContenedor.Text = "";
                    lblMetaFollowup.Text = "";
                    lblMetavendedor.Text = "";
                    lblMetaFechaApertura.Text = "";
                    lblMetaShipper.Text = "";

                    lblVendedorCierre.Text = "";
                    lblFechaCierre.Text = "";
                    lblInstruction.Text = "";
                    lblObservacion.Text = "";
                    
                }

                private void CargarResumen()
                {
                    LimpiarLabelsResumen();

                    //Paso 1
                    lblNombreTarget.Text = TargetAccount.ClienteMaster.NombreCompañia;
                    lblRUT.Text = TargetAccount.ClienteMaster.RUT;
                    if(TargetAccount.ClienteMaster.DireccionInfo != null && TargetAccount.ClienteMaster.DireccionInfo.Items.Count > 0)
                        lblDireccion.Text = TargetAccount.ClienteMaster.DireccionInfo.Items[0].NombreDireccion + " " + 
                                        TargetAccount.ClienteMaster.DireccionInfo.Items[0].Numero + " " + 
                                        TargetAccount.ClienteMaster.DireccionInfo.Items[0].Comuna.Nombre + " - " +
                                        TargetAccount.ClienteMaster.DireccionInfo.Items[0].Ciudad.Nombre + " - " +
                                        TargetAccount.ClienteMaster.DireccionInfo.Items[0].Comuna.Nombre;
                    lblTelefonoEmpresa.Text = TargetAccount.TelefonoEmpresa;
                    lblTelefonoDirecto.Text = TargetAccount.TelefonoDirecto;
                    lblTerminoCompra.Text = TargetAccount.TerminoCompra.Nombre;
                    lblIncoterm.Text = TargetAccount.IncoTerm.Descripcion;

                    lblTraficos.Text = "";
                    foreach (var trafico in TargetAccount.Traficos)
                    {
                        lblTraficos.Text += trafico.Nombre + " / ";
                    }
                    lblOrigenes.Text = "";
                    foreach (var origen in TargetAccount.OrigenesCarga)
                    {
                        lblOrigenes.Text += origen.Nombre + " / ";
                    }
                    lblDestino.Text = "";
                    foreach (var destino in TargetAccount.DestinosCarga)
                    {
                        lblDestino.Text += destino.Nombre;
                    }

                    //Paso 2
                    lblNombreContacto.Text = TargetAccount.ContactoNombre;
                    lblEmailContacto.Text = TargetAccount.ContactoEmail;
                    lblCargoContacto.Text = TargetAccount.ContactoCargo;

                    lblCompetencia.Text = "";
                    foreach (var embarca in TargetAccount.EmbarcaCon)
                    {
                        lblCompetencia.Text += embarca + " / ";
                    }
                    lbltomaDesiciones.Text = "";
                    foreach (var desicion in TargetAccount.TomaDesiciones)
                    {
                        lbltomaDesiciones.Text += desicion.Nombre + " / ";
                    }

                    //Paso 3
                    lblProductos.Text = "";
                    foreach (var producto in TargetAccount.ClienteMaster.ProductosPreferidos)
                    {
                        lblProductos.Text += producto.Producto.Nombre + " / ";
                    }
                    lblServiciosComplementarios.Text = "";
                    foreach (var servicio in TargetAccount.ServiciosComplementarios)
                    {
                        lblServiciosComplementarios.Text += servicio.Nombre + " / ";
                    }
                    lblPersonales.Text = "";
                    foreach (var personal in TargetAccount.Personales)
                    {
                        lblPersonales.Text += personal.Nombre + " / ";
                    }
                    lblObjeciones.Text = "";
                    foreach (var objecion in TargetAccount.Objeciones)
                    {
                        lblObjeciones.Text += objecion.Nombre + " / ";
                    }
                    lblAccionesTomar.Text = "";

                    if (TargetAccount.AccionTomar != null)
                    {
                        string proximaOrden = "";
                        if (TargetAccount.AccionTomar.ProximaOrden.HasValue)
                            proximaOrden = TargetAccount.AccionTomar.ProximaOrden.Value.ToShortDateString();

                        lblAccionesTomar.Text = "Como Comunicara: " + TargetAccount.AccionTomar.ComoComunicara +
                                                " - Próxima Orden: " + proximaOrden +
                                                " - Como comunicara: " + TargetAccount.AccionTomar.ComoComunicara;
                    }
                        
                    
                    //foreach (var accion in TargetAccount.AccionesTomar)
                    //{
                    //    lblAccionesTomar.Text += accion.Nombre + " / ";
                    //}

                    Entidades.Direccion.Metas.clsMeta Meta = null;
                    ResultadoTransaccion res =
                        LogicaNegocios.Direccion.Metas.clsMetaNegocio.ObtenerMetaPorId(TargetAccount.IdTargetSource);
                    if(res.Estado == Enums.EstadoTransaccion.Aceptada)
                    {
                        Meta = (Entidades.Direccion.Metas.clsMeta) res.ObjetoTransaccion;
                    }
                    else
                    {
                        MessageBox.Show(res.Descripcion, "Target Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if(Meta != null)
                    {
                        lblMetaNombre.Text = Meta.GlosaClienteTarget;
                        lblMetaCommodity.Text = Meta.GlosaCommodity;
                        lblMetaContenedor.Text = Meta.ObjTipoContenedor.Nombre;
                        lblMetaFollowup.Text = Meta.FechaRevision.ToShortDateString();
                        lblMetavendedor.Text = Meta.ObjMetaAsignacion.ObjVendedorAsignado.NombreCompleto;
                        lblMetaFechaApertura.Text = Meta.FechaApertura.ToShortDateString();
                        lblMetaShipper.Text = Meta.Shipper;

                        lblVendedorCierre.Text = Meta.NombreUsuarioCierra;
                        lblFechaCierre.Text = Meta.FechaCierre.ToString();
                        lblInstruction.Text = Meta.Instruction;
                        lblObservacion.Text = Meta.ObjMetaObservaciones.Observacion;

                        lblFechaCancelacion.Text = Meta.FechaCancelacion.ToString();
                        lblObservacionMeta.Text = Meta.ObjMetaObservaciones.Observacion;
                    }

                    groupCancelado.Visible = false;
                    groupCierre.Visible = false;
                    if(TargetAccount.Estado == Enums.EstadosMetas.Cierre)
                        groupCierre.Visible = true;

                    if (TargetAccount.Estado == Enums.EstadosMetas.Cancelado)
                        groupCancelado.Visible = true;


                }
            #endregion

            #region Menu

                private void Guardar()
                {
                    string mensaje = "";
                    string mensajeOk = "";
                    string mensajeError = "";

                    dxErrorProvider1.ClearErrors();

                    if (TargetAccount.Estado == Enums.EstadosMetas.Asignado)
                    {
                        if (GuardarPaso1())
                        {
                            mensajeOk += "- Informacion General \n";
                        }
                        else
                        {
                            mensajeError += "- Informacion General \n";
                        }

                        //MessageBox.Show("Información General guardada correctamente", "Target Account", MessageBoxButtons.OK,
                        //                    MessageBoxIcon.Information);
                    }
                    else if (TargetAccount.Estado == Enums.EstadosMetas.Informacion_General)
                    {
                        if (GuardarPaso1())
                        {
                            mensajeOk += "- Informacion General \n";
                        }
                        else
                        {
                            mensajeError += "- Informacion General \n";
                        }

                        if (GuardarPaso2())
                        {
                            mensajeOk += "- Llamada Telefonica \n";
                        }
                        else
                        {
                            mensajeError += "- Llamada Telefonica \n";
                        }

                        //if(GuardarPaso1() && GuardarPaso2())
                        //{
                        //    MessageBox.Show("Información General y de Contacto Telefonico guardada correctamente", "Target Account", MessageBoxButtons.OK,
                        //                    MessageBoxIcon.Information);
                        //}
                    }
                    else if (TargetAccount.Estado == Enums.EstadosMetas.Contacto_Telefonico ||
                             TargetAccount.Estado == Enums.EstadosMetas.Visita)
                    {
                        if (GuardarPaso1())
                        {
                            mensajeOk += "- Informacion General \n";
                        }
                        else
                        {
                            mensajeError += "- Informacion General \n";
                        }

                        if (GuardarPaso2())
                        {
                            mensajeOk += "- Llamada Telefonica \n";
                        }
                        else
                        {
                            mensajeError += "- Llamada Telefonica \n";
                        }

                        if (GuardaPaso3())
                        {
                            mensajeOk += "- Visita \n";
                        }
                        else
                        {
                            mensajeError += "- visita \n";
                        }

                    }

                    if (mensajeOk.Trim().Length > 0)
                    {
                        mensaje = "Los siguientes pasos fueron guardados correctamente: \n" + mensajeOk + "\n";
                    }

                    if (mensajeError.Trim().Length > 0)
                    {
                        mensaje += "Los siguientes pasos presentan problemas: \n" + mensajeError;

                    }

                    if(mensaje.Length > 0)
                        MessageBox.Show(mensaje, "Target Account", MessageBoxButtons.OK,MessageBoxIcon.Information);


                    if(mensajeError.Length.Equals(0))
                    {
                        BuscarTargetAccount();
                        ValidarAcciones();    
                    }

                    
                }

            #endregion

            #region Paso1

                #region Direccion

                private void CargarPaises()
                {
                    IList<clsPais> paises = clsParametros.ListarPaises();
                    ComboBoxItemCollection coll = cboPais.Properties.Items;
                    coll.Add(Utils.Utils.ObtenerPrimerItem());
                    foreach (var list in paises)
                    {
                        coll.Add(list);
                    }
                    cboPais.SelectedIndex = 0;
                }

                    private void CargarCiudades(Int64 idPais)
                {
                    IList<clsCiudad> ciudades = clsParametros.ListarCiudades(idPais);

                    ComboBoxItemCollection coll = cboRegion.Properties.Items;
                    coll.Clear();
                    coll.Add(Utils.Utils.ObtenerPrimerItem());
                    foreach (var list in ciudades)
                    {
                        coll.Add(list);
                    }
                    cboRegion.SelectedIndex = 0;

                }

                    private void cargarComunas(Int64 idCiudad)
                {
                    IList<clsComuna> comunas = clsParametros.ListarComunas(idCiudad);

                    ComboBoxItemCollection coll = cboComuna.Properties.Items;
                    coll.Clear();
                    coll.Add(Utils.Utils.ObtenerPrimerItem());
                    foreach (var list in comunas)
                    {
                        coll.Add(list);
                    }
                    cboComuna.SelectedIndex = 0;
                }

                #endregion

                #region Guardar

                    private bool GuardarPaso1()
                    {
                        if (!ValidarCamposPaso1()) return false;

                        VistaADominioPaso1();

                        ResultadoTransaccion res = new ResultadoTransaccion();

                        res = LogicaNegocios.Clientes.clsTargetAccount.ActualizarPaso1(TargetAccount);

                        if (res.Estado == Enums.EstadoTransaccion.Rechazada)
                        {
                            MessageBox.Show(res.Descripcion, "Target Account Paso 1", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        return true;
                    }

                    private bool ValidarCamposPaso1()
                    {
                        bool FormOk = true;

                        if (txtNombreTarget.Text.Trim().Length.Equals(0))
                        {
                            dxErrorProvider1.SetError(txtNombreTarget, "Debe ingresar nombre del Target", ErrorType.Critical);
                            FormOk = false;
                        }

                        if (txtRUT.Text.Trim().Length.Equals(0))
                        {
                            dxErrorProvider1.SetError(txtRUT, "Debe ingresar Rut del Target", ErrorType.Critical);
                            FormOk = false;
                        }

                        if (txtDireccion.Text.Trim().Length.Equals(0))
                        {
                            dxErrorProvider1.SetError(txtDireccion, "Debe ingresar Dirección del Target", ErrorType.Critical);
                            FormOk = false;
                        }

                        if (txtNumero.Text.Trim().Length.Equals(0))
                        {
                            dxErrorProvider1.SetError(txtNumero, "Debe ingresar Número de Direccion", ErrorType.Critical);
                            FormOk = false;
                        }

                        if (cboPais.SelectedIndex.Equals(0))
                        {
                            dxErrorProvider1.SetError(cboPais, "Debe seleccionar País", ErrorType.Critical);
                            FormOk = false;
                        }

                        if (cboRegion.SelectedIndex.Equals(0))
                        {
                            dxErrorProvider1.SetError(cboRegion, "Debe seleccionar Region", ErrorType.Critical);
                            FormOk = false;
                        }

                        if (cboComuna.SelectedIndex.Equals(0))
                        {
                            dxErrorProvider1.SetError(cboComuna, "Debe seleccionar Comuna", ErrorType.Critical);
                            FormOk = false;
                        }

                        if (txtTelefonoEmpresa.Text.Trim().Length.Equals(0))
                        {
                            dxErrorProvider1.SetError(txtTelefonoEmpresa, "Debe ingresar Telefono Empresa", ErrorType.Critical);
                            FormOk = false;
                        }

                        if (txtTelefonoDirecto.Text.Trim().Length.Equals(0))
                        {
                            dxErrorProvider1.SetError(txtTelefonoDirecto, "Debe ingresar Telefono Directo", ErrorType.Critical);
                            FormOk = false;
                        }

                        if (cboTerminoCompra.SelectedIndex.Equals(0))
                        {
                            dxErrorProvider1.SetError(cboTerminoCompra, "Debe seleccionar Termino de Compra", ErrorType.Critical);
                            FormOk = false;
                        }

                        if (cboIncoTerms.SelectedIndex.Equals(0))
                        {
                            dxErrorProvider1.SetError(cboIncoTerms, "Debe seleccionar IncoTerm", ErrorType.Critical);
                            FormOk = false;
                        }

                        lblErrorOrigenes.Visible = false;
                        if (TargetAccount.OrigenesCarga.Count.Equals(0))
                        {
                            lblErrorOrigenes.Visible = true;
                            FormOk = false;
                        }

                        lblErrorDestinos.Visible = false;
                        if (TargetAccount.DestinosCarga.Count.Equals(0))
                        {
                            lblErrorDestinos.Visible = true;
                            FormOk = false;
                        }

                        return FormOk;
                    }

                    private void VistaADominioPaso1()
                    {
                        //Paso 1
                        TargetAccount.ClienteMaster.NombreCompañia = txtNombreTarget.Text;
                        TargetAccount.ClienteMaster.RUT = txtRUT.Text.Trim();

                        clsDireccion direccion = new clsDireccion();
                        direccion.NombreDireccion = txtDireccion.Text;
                        direccion.Numero = txtNumero.Text;
                        direccion.OficinaDpto = txtOficinaDpto.Text;
                        direccion.Pais = (clsPais) cboPais.SelectedItem;
                        direccion.Ciudad = (clsCiudad) cboRegion.SelectedItem;
                        direccion.Comuna = (clsComuna) cboComuna.SelectedItem;
                        direccion.Block = "-1";
                        direccion.Sector.Id = -1;
                        direccion.DestinoDireccion.Id = -1;

                        TargetAccount.ClienteMaster.DireccionInfo = new clsDireccionInfo();
                        TargetAccount.ClienteMaster.DireccionInfo.Items.Add(direccion);
                        TargetAccount.TelefonoEmpresa = txtTelefonoEmpresa.Text;
                        TargetAccount.TelefonoDirecto = txtTelefonoDirecto.Text;

                        //TargetAccount.Traficos = new List<clsTrafico>();
                        //foreach (Entidades.Ventas.Traficos.clsTrafico item in lstTraficos.CheckedItems)
                        //{
                        //    TargetAccount.Traficos.Add(item);
                        //}


                        if (txtEmbarquesMes.Text.Trim().Length.Equals(0))
                            TargetAccount.EmbarquesPorMes = -1;
                        else
                            TargetAccount.EmbarquesPorMes = Convert.ToInt16(txtEmbarquesMes.Text);


                        if (txtCantidadLCL.Text.Trim().Length.Equals(0))
                            TargetAccount.CantidadLCL = null;
                        else
                            TargetAccount.CantidadLCL = Convert.ToInt16(txtCantidadLCL.Text);

                        if (cboUMLCL.SelectedIndex == 0)
                            TargetAccount.UMLCL.Id = -1;
                        else
                            TargetAccount.UMLCL = (clsItemParametro) cboUMLCL.SelectedItem;

                        if (txtCantidadFCL.Text.Trim().Length.Equals(0))
                            TargetAccount.CantidadFCL = null;
                        else
                            TargetAccount.CantidadFCL = Convert.ToInt16(txtCantidadFCL.Text);

                        if (cboUMFCL.SelectedIndex == 0)
                            TargetAccount.UMFCL.Id = -1;
                        else
                            TargetAccount.UMFCL = (clsItemParametro) cboUMFCL.SelectedItem;

                        if (txtCantidadAereo.Text.Trim().Length.Equals(0))
                            TargetAccount.CantidadAereo = null;
                        else
                            TargetAccount.CantidadAereo = Convert.ToInt16(txtCantidadAereo.Text);

                        if (cboUMAereo.SelectedIndex == 0)
                            TargetAccount.UMAereo.Id = -1;
                        else
                            TargetAccount.UMAereo = (clsItemParametro) cboUMAereo.SelectedItem;

                        TargetAccount.TerminoCompra = (clsItemParametro) cboTerminoCompra.SelectedItem;
                        TargetAccount.IncoTerm = (clsIncoTerm) cboIncoTerms.SelectedItem;


                        TargetAccount.ObservacionInfGeneral = txtObservacionGeneral.Text;

                        TargetAccount.Estado = Enums.EstadosMetas.Informacion_General;
                    

    ;
                    }

                #endregion

                #region Producto/Trafico

                    private void CargarProductos()
                {
                    IList<clsTipoProducto> productos =
                          clsParametros.ListarProductos("S");

                    lstProductos.DataSource = productos;
                }

                    private void CargarTraficos()
            {
                ResultadoTransaccion res = LogicaNegocios.Ventas.Productos.clsTipoProducto.ListarTiposTraficos();
                if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                {
                    IList<clsTrafico> traficos = (IList<clsTrafico>)res.ObjetoTransaccion;

                    lstTraficos.DataSource = traficos;

                }
            }
                
                    private void CargarUnidadesDeMedida()
                    {
                        clsParametrosInfo UMLCL =
                            clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.UnidadMedidaLCL);
                        Utils.Utils.CargaComboBoxParametros(UMLCL,cboUMLCL);

                        clsParametrosInfo UMFCL =
                                            clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.UnidadMedidaFCL);
                        Utils.Utils.CargaComboBoxParametros(UMFCL, cboUMFCL);

                        clsParametrosInfo UMAereo =
                            clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.UnidadMedidaAereo);
                        Utils.Utils.CargaComboBoxParametros(UMAereo, cboUMAereo);

                    }           

                #endregion

                #region Potencial del Cliente

                    private void CargarTerminoCompra()
                    {
                        clsParametrosInfo TerminosCompra =
                            clsParametros.ListarParametrosPorTipo(Enums.TipoParametro.TerminioCompra);
                        Utils.Utils.CargaComboBoxParametros(TerminosCompra, cboTerminoCompra);
                    }

                    public void CargarIncoTerms()
                    {
                        IList<clsIncoTerm> Incoterms = clsParametrosClientes.ListarIncoTerms(true);

                        ComboBoxItemCollection coll2 = cboIncoTerms.Properties.Items;
                        coll2.Add(Utils.Utils.ObtenerPrimerItem());
                        foreach (var list in Incoterms)
                        {
                            coll2.Add(list);
                        }
                        cboIncoTerms.SelectedIndex = 0;


                    }


                #endregion

                #region Origen/Destino Carga

                    private void CargarOrigenesCarga()
                    {
                        IList<clsTipoOrigenCarga> listOrigenCarga = clsParametros.ListarTiposOrigenCarga("-1");
                        ComboBoxItemCollection coll = cboOrigenBusqueda.Properties.Items;
                        coll.Add(Utils.Utils.ObtenerPrimerItem());
                        foreach (var list in listOrigenCarga)
                        {
                            coll.Add(list);
                        }
                        cboOrigenBusqueda.SelectedIndex = 0;

                        AutoCompleteStringCollection auto = new AutoCompleteStringCollection();

                        auto.Add(txtBusquedaOrigenes.Text);
                        txtBusquedaOrigenes.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtBusquedaOrigenes.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        foreach (var list in listOrigenCarga)
                        {
                            auto.Add(list.Nombre);
                        }
                        txtBusquedaOrigenes.MaskBox.AutoCompleteCustomSource = auto;


                    }

                    private void CargarDestinosCarga()
                    {
                        IList<clsTipoDestinoCarga> listDestinoCarga = clsParametros.ListarTiposDestinoCarga("-1");
                        ComboBoxItemCollection coll = cboDestinoBusqueda.Properties.Items;
                        coll.Add(Utils.Utils.ObtenerPrimerItem());
                        foreach (var list in listDestinoCarga)
                        {
                            coll.Add(list);
                        }
                        cboDestinoBusqueda.SelectedIndex = 0;

                        AutoCompleteStringCollection auto = new AutoCompleteStringCollection();

                        auto.Add(txtBusquedaDestinos.Text);
                        txtBusquedaDestinos.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtBusquedaDestinos.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        foreach (var list in listDestinoCarga)
                        {
                            auto.Add(list.Nombre);
                        }
                        txtBusquedaDestinos.MaskBox.AutoCompleteCustomSource = auto;

                    }

                    private void AgregarOrigenCarga()
                    {
                        clsTipoOrigenCarga origen = null;


                        cboOrigenBusqueda.SelectedIndex = 0;
                        if (txtBusquedaOrigenes.Text.Trim() == "")
                        {
                            origen = null;
                        }
                        else
                        {
                            for (int i = 0; i < cboOrigenBusqueda.Properties.Items.Count; i++)
                            {
                                if (cboOrigenBusqueda.Properties.Items[i].ToString() == txtBusquedaOrigenes.Text)
                                    cboOrigenBusqueda.SelectedIndex = i;
                            }

                            if (cboOrigenBusqueda.SelectedIndex != 0)
                            {
                                origen = (clsTipoOrigenCarga)this.cboOrigenBusqueda.SelectedItem;
                            }
                        }

                        if (origen == null)
                        {
                            origen = new clsTipoOrigenCarga();
                            origen.Nombre = txtBusquedaOrigenes.Text;
                            origen.Usuario = Base.Usuario.UsuarioConectado.Usuario;
                        }



                        List<clsTipoOrigenCarga> origeneslist = new List<clsTipoOrigenCarga>(TargetAccount.OrigenesCarga);
                        clsTipoOrigenCarga foo = origeneslist.Find(delegate(clsTipoOrigenCarga var)
                        {
                            return var.Nombre.ToUpper().Trim() ==
                                   origen.Nombre.ToUpper().Trim();
                        });

                        if (foo != null)
                        {
                            dxErrorProvider1.SetError(txtBusquedaOrigenes, "El Origen '" + origen.Nombre + "' ya esta ingresado", ErrorType.Critical);
                            return;
                        }


                        TargetAccount.OrigenesCarga.Add(origen);

                        lstOrigenes.ValueMember = "Id";
                        lstOrigenes.DisplayMember = "Nombre";
                        lstOrigenes.DataSource = TargetAccount.OrigenesCarga;
                        lstOrigenes.Refresh();

                        txtBusquedaOrigenes.Text = "";
                        dxErrorProvider1.ClearErrors();

                    }

                    private void QuitarOrigenCarga()
                    {
                        clsTipoOrigenCarga itemQuitar = (clsTipoOrigenCarga)lstOrigenes.SelectedItem;

                        TargetAccount.OrigenesCarga.Remove(itemQuitar);

                        lstOrigenes.ValueMember = "Id";
                        lstOrigenes.DisplayMember = "Nombre";
                        lstOrigenes.DataSource = TargetAccount.OrigenesCarga;
                        lstOrigenes.Refresh();
                    }

                    private void QuitarTrafico()
                    {
                        clsTrafico itemQuitar = (clsTrafico)lstTraficos.SelectedItem;

                        TargetAccount.Traficos.Remove(itemQuitar);

                        lstTraficos.ValueMember = "Id";
                        lstTraficos.DisplayMember = "Nombre";
                        lstTraficos.DataSource = TargetAccount.Traficos;
                        lstTraficos.Refresh();
                    }            

                    private void AgregarDestinoCarga()
                    {
                        clsTipoDestinoCarga destino = null;
                        cboDestinoBusqueda.SelectedIndex = 0;

                        if (txtBusquedaDestinos.Text.Trim() == "")
                        {
                            destino = null;
                        }
                        else
                        {
                            for (int i = 0; i < cboDestinoBusqueda.Properties.Items.Count; i++)
                            {
                                if (cboDestinoBusqueda.Properties.Items[i].ToString() == txtBusquedaDestinos.Text)
                                    cboDestinoBusqueda.SelectedIndex = i;
                            }

                            if (cboDestinoBusqueda.SelectedIndex != 0)
                            {
                                destino = (clsTipoDestinoCarga)this.cboDestinoBusqueda.SelectedItem;
                            }
                        }

                        if (destino == null)
                        {
                            destino = new clsTipoDestinoCarga();
                            destino.Nombre = txtBusquedaDestinos.Text;
                            destino.Usuario = Base.Usuario.UsuarioConectado.Usuario;
                        }



                        List<clsTipoDestinoCarga> destinolist = new List<clsTipoDestinoCarga>(TargetAccount.DestinosCarga);
                        clsTipoDestinoCarga foo = destinolist.Find(delegate(clsTipoDestinoCarga var)
                        {
                            return var.Nombre.ToUpper().Trim() ==
                                   destino.Nombre.ToUpper().Trim();
                        });

                        if (foo != null)
                        {
                            dxErrorProvider1.SetError(txtBusquedaDestinos, "El Destino '" + destino.Nombre + "' ya esta ingresado", ErrorType.Critical);
                            return;
                        }

                        TargetAccount.DestinosCarga.Add(destino);

                        lstDestinos.ValueMember = "Id";
                        lstDestinos.DisplayMember = "Nombre";
                        lstDestinos.DataSource = TargetAccount.DestinosCarga;
                        lstDestinos.Refresh();

                        txtBusquedaDestinos.Text = "";
                        dxErrorProvider1.ClearErrors();

                    }

                    private void QuitarDestinoCarga()
                    {
                        clsTipoDestinoCarga itemQuitar = (clsTipoDestinoCarga)lstDestinos.SelectedItem;

                        TargetAccount.DestinosCarga.Remove(itemQuitar);

                        lstDestinos.ValueMember = "Id";
                        lstDestinos.DisplayMember = "Nombre";
                        lstDestinos.DataSource = TargetAccount.DestinosCarga;
                        lstDestinos.Refresh();
                    }

                    private void CargarTraficosExistentes()
                    {
                        IList<clsTrafico> listTraficos = new List<clsTrafico>();
                        ResultadoTransaccion res = LogicaNegocios.Ventas.Productos.clsTipoProducto.ListarTiposTraficos();
                        if(res.Estado == Enums.EstadoTransaccion.Aceptada)
                        {
                            listTraficos = (IList<clsTrafico>) res.ObjetoTransaccion;
                        }


                        ComboBoxItemCollection coll = cboTraficos.Properties.Items;
                        coll.Add(Utils.Utils.ObtenerPrimerItem());
                        foreach (var list in listTraficos)
                        {
                            coll.Add(list);
                        }
                        cboTraficos.SelectedIndex = 0;

                        AutoCompleteStringCollection auto = new AutoCompleteStringCollection();

                        auto.Add(txtBusquedaTraficos.Text);
                        txtBusquedaTraficos.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtBusquedaTraficos.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        foreach (var list in listTraficos)
                        {
                            auto.Add(list.Nombre);
                        }
                        txtBusquedaTraficos.MaskBox.AutoCompleteCustomSource = auto;
                    }

                #endregion

            #endregion

            #region Paso2

                #region Guardar

                    private bool GuardarPaso2()
                    {
                        if (!ValidarCamposPaso2()) return false;

                        VistaADominioPaso2();

                        ResultadoTransaccion res = new ResultadoTransaccion();

                        res = LogicaNegocios.Clientes.clsTargetAccount.ActualizarPaso2(TargetAccount);

                        if (res.Estado == Enums.EstadoTransaccion.Rechazada)
                        {
                            MessageBox.Show(res.Descripcion, "Target Account Paso 2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        return true;
                    }

                    private bool ValidarCamposPaso2()
                    {
                        bool FormOk = true;

                        if (txtNombreContacto.Text.Trim().Length.Equals(0))
                        {
                            dxErrorProvider1.SetError(txtNombreContacto, "Debe ingresar Nombre del Contacto", ErrorType.Critical);
                            FormOk = false;
                        }

                        if (txtMailContacto.Text.Trim().Length.Equals(0))
                        {
                            dxErrorProvider1.SetError(txtMailContacto, "Debe ingresar Email de Contacto", ErrorType.Critical);
                            FormOk = false;
                        }

                        if (txtCargoContacto.Text.Trim().Length.Equals(0))
                        {
                            dxErrorProvider1.SetError(txtCargoContacto, "Debe ingresar Cargo del Contacto", ErrorType.Critical);
                            FormOk = false;
                        }

                        lblErrorEmbarcaCon.Visible = false;
                        if (TargetAccount.EmbarcaCon.Count.Equals(0))
                        {
                            lblErrorEmbarcaCon.Visible = true;
                            FormOk = false;
                        }

                        lblErrorTomaDesiciones.Visible = false;
                        if (TargetAccount.TomaDesiciones.Count.Equals(0))
                        {
                            lblErrorTomaDesiciones.Visible = true;
                            FormOk = false;
                        }


                        return FormOk;
                    }

                    private void VistaADominioPaso2()
                    {
                        //Paso 2
                        TargetAccount.ContactoNombre = txtNombreContacto.Text;
                        TargetAccount.ContactoEmail = txtMailContacto.Text;
                        TargetAccount.ContactoCargo = txtCargoContacto.Text;

                        TargetAccount.Estado = Enums.EstadosMetas.Contacto_Telefonico;

                        TargetAccount.ObservacionLlamadaTelefonica = txtObservacionLlamada.Text;
                    }

                #endregion

                private void AgregarEmpresaCompetencia()
                    {
                        clsTargetAccountCompetencia competencia = null;


                        cboCompetencia.SelectedIndex = 0;
                        if (txtConQuienEmbarca.Text.Trim() == "")
                        {
                            competencia = null;
                        }
                        else
                        {
                            for (int i = 0; i < cboCompetencia.Properties.Items.Count; i++)
                            {
                                if (cboCompetencia.Properties.Items[i].ToString() == txtConQuienEmbarca.Text)
                                    cboCompetencia.SelectedIndex = i;
                            }

                            if (cboCompetencia.SelectedIndex != 0)
                            {
                                competencia = (clsTargetAccountCompetencia)this.cboCompetencia.SelectedItem;
                            }
                        }

                        if (competencia == null)
                        {
                            competencia = new clsTargetAccountCompetencia();
                            competencia.Nombre = txtConQuienEmbarca.Text;
                        }



                        competencia.FechaCreacion = DateTime.Now;

                        List<clsTargetAccountCompetencia> competencialista = new List<clsTargetAccountCompetencia>(TargetAccount.EmbarcaCon);
                        clsTargetAccountCompetencia foo = competencialista.Find(delegate(clsTargetAccountCompetencia var)
                        {
                            return var.Nombre.ToUpper().Trim() ==
                                   competencia.Nombre.ToUpper().Trim();
                        });

                        if (foo != null)
                        {
                            dxErrorProvider1.SetError(txtConQuienEmbarca, "La Empresa '" + competencia.Nombre + "' ya esta ingresada", ErrorType.Critical);
                            return;
                        }


                        TargetAccount.EmbarcaCon.Add(competencia);


                        lstConQuienEmbarcan.ValueMember = "Id";
                        lstConQuienEmbarcan.DisplayMember = "Nombre";
                        lstConQuienEmbarcan.DataSource = TargetAccount.EmbarcaCon;
                        lstConQuienEmbarcan.Refresh();

                        txtConQuienEmbarca.Text = "";
                        dxErrorProvider1.ClearErrors();
                    }

                private void AgregarTomaDesiciones()
                    {
                        clsTargetAccountTomaDesiciones desicion = new clsTargetAccountTomaDesiciones();

                        desicion.Nombre = txtNombreTomaDesiciones.Text.Trim();

                        List<clsTargetAccountTomaDesiciones> desicioneslista = new List<clsTargetAccountTomaDesiciones>(TargetAccount.TomaDesiciones);
                        clsTargetAccountTomaDesiciones foo = desicioneslista.Find(delegate(clsTargetAccountTomaDesiciones var)
                        {
                            return var.Nombre.ToUpper().Trim() ==
                                   desicion.Nombre.ToUpper().Trim();
                        });

                        if (foo != null)
                        {
                            dxErrorProvider1.SetError(txtNombreTomaDesiciones, "El Nombre '" + desicion.Nombre + "' ya esta ingresado", ErrorType.Critical);
                            return;
                        }


                        TargetAccount.TomaDesiciones.Add(desicion);


                        lstTomanDesiciones.ValueMember = "Id";
                        lstTomanDesiciones.DisplayMember = "Nombre";
                        lstTomanDesiciones.DataSource = TargetAccount.TomaDesiciones;
                        lstTomanDesiciones.Refresh();

                        txtNombreTomaDesiciones.Text = "";
                        dxErrorProvider1.ClearErrors();
                    }

                private void QuitarEmbarcaCon()
                    {
                        clsTargetAccountCompetencia itemQuitar = (clsTargetAccountCompetencia)lstConQuienEmbarcan.SelectedItem;

                        TargetAccount.EmbarcaCon.Remove(itemQuitar);

                        lstConQuienEmbarcan.ValueMember = "Id";
                        lstConQuienEmbarcan.DisplayMember = "Nombre";
                        lstConQuienEmbarcan.DataSource = TargetAccount.EmbarcaCon;
                        lstConQuienEmbarcan.Refresh();
                    }

                private void QuitarTomaDesiciones()
                    {
                        clsTargetAccountTomaDesiciones itemQuitar = (clsTargetAccountTomaDesiciones)lstTomanDesiciones.SelectedItem;

                        TargetAccount.TomaDesiciones.Remove(itemQuitar);

                        lstTomanDesiciones.ValueMember = "Id";
                        lstTomanDesiciones.DisplayMember = "Nombre";
                        lstTomanDesiciones.DataSource = TargetAccount.TomaDesiciones;
                        lstTomanDesiciones.Refresh();
                    }

                private void CargarEmpresasCompetencia()
                {
                    IList<clsTargetAccountCompetencia> listEmpresas =
                        LogicaNegocios.Clientes.clsTarget.ListarEmpresasCompetencia(cboCompetencia.SelectedText);
                    ComboBoxItemCollection coll = cboCompetencia.Properties.Items;

                    coll.Add(Utils.Utils.ObtenerPrimerItem());
                    foreach (var list in listEmpresas)
                    {
                        coll.Add(list);
                    }
                    cboCompetencia.SelectedIndex = 0;
                    cboCompetencia.Properties.AutoComplete = true;


                    AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
                    auto.Add(txtConQuienEmbarca.Text);

                    txtConQuienEmbarca.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtConQuienEmbarca.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    foreach (var list in listEmpresas)
                    {
                        auto.Add(list.Nombre);
                    }

                    txtConQuienEmbarca.MaskBox.AutoCompleteCustomSource = auto;

                }
        

            #endregion

            #region Paso3

                #region Guardar

                    private bool GuardaPaso3()
                {
                    VistaADominioPaso3();

                    if (!ValidarCamposPaso3()) return false;

                    ResultadoTransaccion res = new ResultadoTransaccion();

                    res = LogicaNegocios.Clientes.clsTargetAccount.ActualizarPaso3(TargetAccount);

                    if (res.Estado == Enums.EstadoTransaccion.Rechazada)
                    {
                        MessageBox.Show(res.Descripcion, "Target Account Paso 3", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    return true;
                }

                    private bool ValidarCamposPaso3()
                {
                    bool FormOk = true;

                    lblErrorProducto.Visible = false;
                    if (TargetAccount.ClienteMaster.ProductosPreferidos.Count.Equals(0))
                    {
                        lblErrorProducto.Visible = true;
                        FormOk = false;
                    }

                    lblErrorServiciosComp.Visible = false;
                    if (TargetAccount.ServiciosComplementarios.Count.Equals(0))
                    {
                        lblErrorServiciosComp.Visible = true;
                        FormOk = false;
                    }

                    return FormOk;
                }

                    private void VistaADominioPaso3()
                {
                    //Paso 3
                    foreach (clsTipoProducto producto in lstProductos.CheckedItems)
                    {
                        clsClientesProductos productoMaster = new clsClientesProductos();
                        productoMaster.Customer.Id = -1;
                        productoMaster.Producto = producto;
                        TargetAccount.ClienteMaster.ProductosPreferidos = new List<clsClientesProductos>();
                        TargetAccount.ClienteMaster.ProductosPreferidos.Add(productoMaster);
                    }

                    TargetAccount.ServiciosComplementarios = new List<clsTipoServicioComplementario>();
                    foreach (clsTipoServicioComplementario servicio in lstServiciosComplementarios.CheckedItems)
                    {
                        TargetAccount.ServiciosComplementarios.Add(servicio);
                    }

                    TargetAccount.Objeciones = new List<clsTipoObjeciones>();
                    foreach (clsTipoObjeciones objecion in lstObjeciones.CheckedItems)
                    {
                        TargetAccount.Objeciones.Add(objecion);
                    }
                   
                    TargetAccount.AccionTomar = new clsTipoAccionesTomar();

                    TargetAccount.AccionTomar.IdTargetAccount = TargetAccount.Id;
                        TargetAccount.AccionTomar.QueNecesita = txtQueNecesita.Text.Trim();

                        if (txtProximaOrgen.Text.Trim().Length.Equals(0))
                            TargetAccount.AccionTomar.ProximaOrden = new DateTime(9999,1,1);
                        else 
                            TargetAccount.AccionTomar.ProximaOrden = txtProximaOrgen.DateTime;

                        TargetAccount.AccionTomar.ComoComunicara = txtComoComunicara.Text.Trim();

                    //foreach (clsTipoAccionesTomar accion in lstAccionesATomar.CheckedItems)
                    //{
                    //    TargetAccount.AccionesTomar.Add(accion);
                    //}


                    TargetAccount.ObservacionVisita = txtObservacionVisita.Text;

                        TargetAccount.Estado = Enums.EstadosMetas.Visita;
                }

                #endregion

                private void AgregarPersonal()
                {
                    clsTargetAccountPersonales personal = new clsTargetAccountPersonales();

                    personal.Nombre = txtPersonal.Text.Trim();

                    List<clsTargetAccountPersonales> personallista = new List<clsTargetAccountPersonales>(TargetAccount.Personales);
                    clsTargetAccountPersonales foo = personallista.Find(delegate(clsTargetAccountPersonales var)
                    {
                        return var.Nombre.ToUpper().Trim() ==
                               personal.Nombre.ToUpper().Trim();
                    });

                    if (foo != null)
                    {
                        dxErrorProvider1.SetError(txtPersonal, "La Descripcion '" + personal.Nombre + "' ya esta ingresada", ErrorType.Critical);
                        return;
                    }


                    TargetAccount.Personales.Add(personal);


                    lstPersonales.ValueMember = "Id";
                    lstPersonales.DisplayMember = "Nombre";
                    lstPersonales.DataSource = TargetAccount.Personales;
                    lstPersonales.Refresh();

                    txtPersonal.Text = "";
                    dxErrorProvider1.ClearErrors();
                }

                private void QuitarPersonal()
                {
                    clsTargetAccountPersonales itemQuitar = (clsTargetAccountPersonales)lstPersonales.SelectedItem;

                    TargetAccount.Personales.Remove(itemQuitar);

                    lstPersonales.ValueMember = "Id";
                    lstPersonales.DisplayMember = "Nombre";
                    lstPersonales.DataSource = TargetAccount.Personales;
                    lstPersonales.Refresh();
                }

                private void CargarServiciosCoplementarios()
                {
                    IList<clsTipoServicioComplementario> servicios = clsParametrosClientes.ListarServiciosComplementarios(true);

                    lstServiciosComplementarios.DataSource = servicios;

                }

                private void CargarObjeciones()
                {
                    IList<clsTipoObjeciones> objeciones = clsParametrosClientes.ListarTipoObjeciones(true);
                    lstObjeciones.DataSource = objeciones;
                }

                //private void CargarAccionesTomar()
                //{
                //    IList<clsTipoAccionesTomar> acciones = clsParametrosClientes.ListarTipoAccionTomar(true);
                //    lstAccionesATomar.DataSource = acciones;
                //}

            #endregion

                private void btnAgregarTraficos_Click(object sender, EventArgs e)
                {
                    if (txtBusquedaTraficos.Text == "")
                    {
                        dxErrorProvider1.SetError(txtBusquedaTraficos, "Debe ingresar un Trafico", ErrorType.Critical);
                        return;
                    }

                    AgregarTrafico();

                }


                private void AgregarTrafico()
                {
                    Entidades.Ventas.Traficos.clsTrafico trafico = null;
                    
                    cboTraficos.SelectedIndex = 0;
                    if (txtBusquedaTraficos.Text.Trim() == "")
                    {
                        trafico = null;
                    }
                    else
                    {                        
                        for (int i = 0; i < cboTraficos.Properties.Items.Count; i++)
                        {
                            if (cboTraficos.Properties.Items[i].ToString() == txtBusquedaTraficos.Text)
                                cboTraficos.SelectedIndex = i;
                        }

                        if (cboTraficos.SelectedIndex != 0)
                        {
                            trafico = (clsTrafico)this.cboTraficos.SelectedItem;
                        }
                    }

                    if (trafico == null)
                    {
                        trafico = new clsTrafico();
                        trafico.Nombre = txtBusquedaTraficos.Text;
                        trafico.VigenciaDesde = DateTime.Now;
                        trafico.VigenciaHasta = trafico.VigenciaDesde.AddYears(50);
                        
                    }

                    List<clsTrafico> traficoslist = new List<clsTrafico>(TargetAccount.Traficos);
                    clsTrafico foo = traficoslist.Find(delegate(clsTrafico var)
                    {
                        return var.Nombre.ToUpper().Replace("-","").Replace(".","").Replace("/","").Trim() ==
                               trafico.Nombre.ToUpper().Replace("-","").Replace(".","").Replace("/","").Trim();
                    });

                    if (foo != null)
                    {
                        dxErrorProvider1.SetError(txtBusquedaTraficos, "El Trafico '" + trafico.Nombre + "' ya esta ingresado", ErrorType.Critical);
                        return;
                    }


                    TargetAccount.Traficos.Add(trafico);

                    lstTraficos.ValueMember = "Id";
                    lstTraficos.DisplayMember = "Nombre";
                    lstTraficos.DataSource = TargetAccount.Traficos;
                    lstTraficos.Refresh();

                    txtBusquedaTraficos.Text = "";
                    dxErrorProvider1.ClearErrors();

                }
           

                
                                                                                                                                                          
        #endregion

                private void btnQuitarTrafico_Click(object sender, EventArgs e)
                {
                    if (lstTraficos.SelectedIndex < 0)
                    {
                        dxErrorProvider1.SetError(lstTraficos, "Debe seleccionar un Trafico", ErrorType.Critical);
                        return;
                    }

                    QuitarTrafico();
                }

                private void tabTargetAccount_Selecting(object sender, DevExpress.XtraTab.TabPageCancelEventArgs e)
                {
                    if (e.PageIndex == 4) CargarResumen();
                }

              
        



    }
}
