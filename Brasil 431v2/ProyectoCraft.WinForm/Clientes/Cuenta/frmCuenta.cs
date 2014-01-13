using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Repository;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Clientes.CondicionesComerciales;
using ProyectoCraft.Entidades.Clientes.Contacto;
using ProyectoCraft.Entidades.Clientes.Direcciones;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.Entidades.Ventas.Productos;
using ProyectoCraft.LogicaNegocios.Parametros;
using ProyectoCraft.Entidades.Clientes.Cuenta;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.WinForm.Clientes.Cuenta
{
    public partial class frmCuenta : Form
    {
        private static frmCuenta _form = null;
        public static frmCuenta Instancia
        {
            get
            {
                if (_form == null)
                    _form = new frmCuenta();

                return _form;
            }
            set
            {
                _form = value;
            }
        }

        public frmCuenta():base()
        {
            InitializeComponent();
        }


        #region "Eventos Form"

        private void frmTarget_Load(object sender, EventArgs e)
        {
            
            if(Accion == Enums.TipoAccionFormulario.Nuevo)
                FormLoad();
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        #endregion

        #region "Private"

        public void FormLoad()
        {
            CargarCbosParametros();
            CargarVendedores();
            CargarCustomers();
            CargarPaises();
            CargarCondicionesComerciales();
            CargarCuentasExistentes();
            CargarClasificaciones();
        }

        private void CargarClasificaciones()
        {
            IList<clsCuentaclasificacion> clasificaciones =
                LogicaNegocios.Clientes.clsCuentas.ListarClasificaciones(Enums.Estado.Habilitado);

            ComboBoxItemCollection coll = cboClasificacion.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in clasificaciones)
            {
                coll.Add(list);
            }
            cboClasificacion.SelectedIndex = 0;
        }

        private void CargarCuentasExistentes()
        {
            IList<clsClienteMaster> listTargets = LogicaNegocios.Clientes.clsClientesMaster.ListarClienteMaster("-1", Enums.TipoPersona.Cuenta, Enums.Estado.Todos,true);

            ComboBoxItemCollection coll = cboNombreCuentas.Properties.Items;
            ComboBoxItemCollection coll2 = cboRUTs.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            coll2.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listTargets)
            {
                coll.Add(list.NombreCliente);
                coll2.Add(list.RUT);
            }
            cboNombreCuentas.SelectedIndex = 0;
            cboRUTs.SelectedIndex = 0;

            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            AutoCompleteStringCollection auto2 = new AutoCompleteStringCollection();

            auto.Add(txtNombreCompania.Text);
            auto2.Add(txtRUT.Text);

            foreach (var list in listTargets)
            {
                auto.Add(list.NombreCliente);
                auto2.Add(list.RUT);
            }

            txtNombreCompania.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtNombreCompania.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtNombreCompania.MaskBox.AutoCompleteCustomSource = auto;

            txtRUT.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtRUT.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtRUT.MaskBox.AutoCompleteCustomSource = auto2;

        }

        private void CargarCondicionesComerciales()
        {
            IList<clsTipoCondicionComercial> condicionesFlete =
                LogicaNegocios.Clientes.clsCondicionesComerciales.ListarCondicionesComercialesPorTipo(
                    Enums.TipoCondicionComercial.Flete);
            ComboBoxItemCollection collFletes = cboCondicionFlete.Properties.Items;
            collFletes.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in condicionesFlete)
            {
                collFletes.Add(list);
            }
            cboCondicionFlete.SelectedIndex = 0;  


            IList<clsTipoCondicionComercial> condicionesGastos =
                LogicaNegocios.Clientes.clsCondicionesComerciales.ListarCondicionesComercialesPorTipo(
                    Enums.TipoCondicionComercial.GastosLocales);
            ComboBoxItemCollection collGastos = cboCondicionGastoLocal.Properties.Items;
            collGastos.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in condicionesGastos)
            {
                collGastos.Add(list);
            }
            cboCondicionGastoLocal.SelectedIndex = 0;


            txtSolicitadoPor.Text = Base.Usuario.UsuarioConectado.Usuario.ToString();
        }

        private void CargarCbosParametros()
        {
            try
            {                
                clsParametrosInfo lstSectores =
                    clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.SectorEconomico);
                Utils.Utils.CargaComboBoxParametros(lstSectores, this.cboSectorEconomico);
                /**************************************************/
                IList<Entidades.Tarifado.clsTipoMoneda> lstMonedas = clsParametros.ListarMonedas();
                ComboBoxItemCollection coll = cboTipoMonedaVtaEst.Properties.Items;
                coll.Add(Utils.Utils.ObtenerPrimerItem());
                foreach (var list in lstMonedas)
                {
                    coll.Add(list);
                }
                cboTipoMonedaVtaEst.SelectedIndex = 0;
                /**************************************************/                
                clsParametrosInfo lstRelaciones =
                    clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.TipoRelacion);
                lstTipoRelacion.DataSource = lstRelaciones.Items;
                /**************************************************/
                clsParametrosInfo lstTipoDireccion =
                    clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.TipoDireccion);
                Utils.Utils.CargaComboBoxParametros(lstTipoDireccion, this.cboTipoDireccion);
                /**************************************************/
                clsParametrosInfo lstDestinoDireccion =
                    clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.DestinoDireccion);
                Utils.Utils.CargaComboBoxParametros(lstDestinoDireccion, this.cboDestinoDireccion);
                /**************************************************/
                clsParametrosInfo lstSectoresDireccion =
                    clsParametros.ListarParametrosPorTipo(Enums.TipoParametro.SectorDireccion);
                Utils.Utils.CargaComboBoxParametros(lstSectoresDireccion, cboSector);
                /**************************************************/
                clsParametrosInfo lstFormaContPref =
                    clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.FormasContacto);
                Utils.Utils.CargaComboBoxParametros(lstFormaContPref, this.cboFormaContactoPref);
                /**************************************************/                
                clsParametrosInfo lstDias =
                    clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.Dias);
                Utils.Utils.CargaComboBoxParametros(lstDias, this.cboDiaPrefer);
                /**************************************************/                
                clsParametrosInfo lstJornadas =
                    clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.Jornada);
                Utils.Utils.CargaComboBoxParametros(lstJornadas, cboJornadaPref);
                /**************************************************/
                IList<clsTipoProducto> lstProductos =
                    clsParametros.ListarProductos("S");

                ComboBoxItemCollection coll2 = cboProductoPreferido.Properties.Items;
                coll2.Add(Utils.Utils.ObtenerPrimerItem());
                foreach (var list in lstProductos)
                {
                    coll2.Add(list);
                }
                cboProductoPreferido.SelectedIndex = 0;    
                                
                /**************************************************/
                clsParametrosInfo lstZonaVentas = clsParametros.ListarParametrosPorTipo(Enums.TipoParametro.ZonaVentas);
                Utils.Utils.CargaComboBoxParametros(lstZonaVentas, cboZonaVentas);
                /**************************************************/
                clsParametrosInfo lstCategorias =
                    clsParametros.ListarParametrosPorTipo(Enums.TipoParametro.CategoriaCliente);
                Utils.Utils.CargaComboBoxParametros(lstCategorias,cboCategoria);
                /**************************************************/
                clsParametrosInfo lstUMVolumen =
                    clsParametros.ListarParametrosPorTipo(Enums.TipoParametro.UnidadMedidaVolumen);
                Utils.Utils.CargaComboBoxParametros(lstUMVolumen,cboUMVOlumenMvto);

                cboTipoRecibo.Properties.Items.Add(Enums.PaperlessTipoReciboAperturaEmbarcador.Mail);
                cboTipoRecibo.Properties.Items.Add(Enums.PaperlessTipoReciboAperturaEmbarcador.Papel);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CargarVendedores()
        {
            ResultadoTransaccion res = LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Enums.Estado.Habilitado, Enums.CargosUsuarios.Vendedor);
            IList<clsUsuario> listVendedores = (IList<clsUsuario>)res.ObjetoTransaccion;

            ComboBoxItemCollection coll = cboVendedores.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listVendedores)
            {
                coll.Add(list);
            }
            cboVendedores.SelectedIndex = 0;
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(txtVendedorAsignado.Text);

            foreach (var list in listVendedores)
            {
                auto.Add(list.Nombre + " " + list.ApellidoPaterno + " " + list.ApellidoMaterno);
            }

            txtVendedorAsignado.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtVendedorAsignado.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtVendedorAsignado.MaskBox.AutoCompleteCustomSource = auto;

        }

        private void CargarCustomers()
        {
            ResultadoTransaccion res = LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Enums.Estado.Habilitado, Enums.CargosUsuarios.CustomerService);
            IList<clsUsuario> listCustomers = (IList<clsUsuario>)res.ObjetoTransaccion;

            ComboBoxItemCollection coll = cboCustomers.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listCustomers)
            {
                coll.Add(list);
            }
            cboCustomers.SelectedIndex = 0;
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(txtCustomer.Text);

            foreach (var list in listCustomers)
            {
                auto.Add(list.Nombre + " " + list.ApellidoPaterno + " " + list.ApellidoMaterno);
            }

            txtCustomer.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCustomer.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCustomer.MaskBox.AutoCompleteCustomSource = auto;

        }

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

            ComboBoxItemCollection coll = cboCiudad.Properties.Items;
            coll.Clear();
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in ciudades)
            {
                coll.Add(list);
            }
            cboCiudad.SelectedIndex = 0;

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


        #region "Properties"
        
        private clsCuenta _cuentaactual;
        public clsCuenta CuentaActual
        {
            get
            {
                if (_cuentaactual == null)
                    _cuentaactual = new clsCuenta();

                return _cuentaactual;
            }
            set { _cuentaactual = value; }
        }

        private Enums.TipoAccionFormulario _accion;
        public Enums.TipoAccionFormulario Accion
        {
            get { return _accion; }
            set { _accion = value; }
        }

        

        #endregion


        private bool ValidarFormulario()
        {
            bool resultado = true;

            dxErrorProvider1.ClearErrors();
            
            if ((txtNombreCompania.Text == "") )
            {
                dxErrorProvider1.SetError(txtNombreCompania, "Debe ingresar algun nombre", ErrorType.Critical);                
                resultado = false;
            }

            if ((txtNombreFantasia.Text == ""))
            {
                dxErrorProvider1.SetError(txtNombreFantasia, "Debe ingresar nombre de fantasia", ErrorType.Critical);
                resultado = false;
            }

            if (txtRUT.Text == "")
            {
                dxErrorProvider1.SetError(txtRUT, "Debe ingresar RUT", ErrorType.Critical);
                resultado = false;
            }

            if (txtVendedorAsignado.Text == "")
            {
                dxErrorProvider1.SetError(txtVendedorAsignado, "Debe asignar un vendedor", ErrorType.Critical);
                resultado = false;
            }
            else
            {
                cboVendedores.SelectedIndex = 0;
                for (int i = 0; i < cboVendedores.Properties.Items.Count; i++)
                {
                    if (cboVendedores.Properties.Items[i].ToString().ToUpper() == txtVendedorAsignado.Text.ToUpper())
                        cboVendedores.SelectedIndex = i;
                }

                if (cboVendedores.SelectedIndex == 0)
                {
                    dxErrorProvider1.SetError(txtVendedorAsignado, "El Vendedor no es valido", ErrorType.Critical);
                    resultado = false;
                }                
            }
                     
            if(txtTelefono.Text == "")
            {
                dxErrorProvider1.SetError(txtTelefono, "Debe ingresar Telefono", ErrorType.Critical);
                resultado = false;
            }

            if(cboSectorEconomico.SelectedIndex <= 0)
            {
                dxErrorProvider1.SetError(cboSectorEconomico, "Debe seleccionar Sector Economico", ErrorType.Critical);
                resultado = false;
            }

            if(cboZonaVentas.SelectedIndex <= 0)
            {
                dxErrorProvider1.SetError(cboZonaVentas, "Debe seleccionar Zona de Ventas", ErrorType.Critical);
                resultado = false;
            }

            if(cboCategoria.SelectedIndex <= 0)
            {
                dxErrorProvider1.SetError(cboCategoria, "Debe seleccionar Categoria", ErrorType.Critical);
                resultado = false;
            }

            //if(cboFormaContactoPref.SelectedIndex <= 0)
            //{
            //    dxErrorProvider1.SetError(cboFormaContactoPref, "Debe seleccionar forma de Contacto", ErrorType.Critical);
            //    resultado = false;
            //}

            if(cboTipoMonedaVtaEst.SelectedIndex < 0)
            {
                dxErrorProvider1.SetError(cboFormaContactoPref, "Debe seleccionar una moneda valida", ErrorType.Critical);
                resultado = false;
            }

            if(cboUMVOlumenMvto.SelectedIndex < 0 )
            {
                dxErrorProvider1.SetError(cboUMVOlumenMvto, "Debe seleccionar una unidad valida", ErrorType.Critical);
                resultado = false;
            }

            //if(cboDiaPrefer.SelectedIndex < 0 )
            //{
            //    dxErrorProvider1.SetError(cboDiaPrefer, "Debe seleccionar un dia valida", ErrorType.Critical);
            //    resultado = false;
            //}

            //if (cboJornadaPref.SelectedIndex < 0)
            //{
            //    dxErrorProvider1.SetError(cboJornadaPref, "Debe seleccionar una jornada valida", ErrorType.Critical);
            //    resultado = false;
            //}

            return resultado;
        }

        private bool ValidarExisteRut()
        {
            bool valida = false;
            bool resultado = false;

            if (Accion == Enums.TipoAccionFormulario.Nuevo) valida = true;
            else
            {
                if (txtRUT.Text != CuentaActual.ClienteMaster.RUT) valida = true;
            }

            if (valida)
            {
                if (LogicaNegocios.Clientes.clsClientesMaster.ValidarExisteRut(txtRUT.Text.Replace(".",""), Enums.TipoPersona.Cuenta))
                {
                    MessageBox.Show("El Rut ingresado ya existe", "Target", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    resultado = true;
                }
                else
                    resultado = false;
            }

            return resultado;
        }

        private void MenuGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            if(ValidarExisteRut())
                return;

            LlenaObjetoCuenta();
            ResultadoTransaccion resultado = LogicaNegocios.Clientes.clsCuentas.GuardarCuenta(this.CuentaActual);
            if(resultado.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                frmListarCuenta form = frmListarCuenta.Instancia;
                form.ListarCuentas();

                MDICraft mdi = MDICraft.Instancia;
                mdi.MensajeAccion(Accion);

                Instancia = null;
                this.Close();
            }
            else
            {
                MessageBox.Show(resultado.Descripcion, "Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        #region "Vista a Dominio"
            
            private void LlenaObjetoCuenta()
            {
                CuentaActual.ClienteMaster.NombreCompañia = txtNombreCompania.Text.Trim();
                CuentaActual.ClienteMaster.NombreFantasia = txtNombreFantasia.Text.Trim();
                CuentaActual.ClienteMaster.RUT = txtRUT.Text.Replace(".", "").Trim();
                CuentaActual.ClienteMaster.Tipo = Enums.TipoPersona.Cuenta;
                CuentaActual.Estado = Enums.Estado.Habilitado;
                CuentaActual.AutorizadoAduana = chkAutorizadoAduana.Checked;
                if (txtVendedorAsignado.Text.Trim() == "")
                {
                    CuentaActual.VendedorAsignado = null;
                }
                else
                {
                    for (int i = 0; i < cboVendedores.Properties.Items.Count; i++)
                    {
                        if (cboVendedores.Properties.Items[i].ToString() == txtVendedorAsignado.Text)
                            cboVendedores.SelectedIndex = i;
                    }

                    if (cboVendedores.SelectedIndex != 0)
                    {
                        CuentaActual.VendedorAsignado = (clsUsuario)this.cboVendedores.SelectedItem;
                    }
                }
                                
                CuentaActual.Observacion = txtObservacion.Text;
                CuentaActual.Telefono = txtTelefono.Text;
                CuentaActual.CuentaSkype = txtCuentaSkype.Text;
                CuentaActual.SitioWeb = txtSitioWeb.Text;
                CuentaActual.Email = txtEmail.Text;

                if (cboSectorEconomico.SelectedIndex == 0)
                    CuentaActual.SectorEconomico = null;
                else
                    CuentaActual.SectorEconomico = (clsItemParametro)this.cboSectorEconomico.SelectedItem;

                if (cboTipoMonedaVtaEst.SelectedIndex == 0)
                    CuentaActual.TipoMonedaVtaEstimada = null;
                else
                    CuentaActual.TipoMonedaVtaEstimada = (Entidades.Tarifado.clsTipoMoneda)this.cboTipoMonedaVtaEst.SelectedItem;

                if (txtVentaEst.Text == "")
                    CuentaActual.MontoVentaEstimada = -1;
                else
                    CuentaActual.MontoVentaEstimada= Convert.ToDecimal(this.txtVentaEst.Text.Replace(".",""));

                if (txtNumEmpleados.Text == "")
                    CuentaActual.NumEmpleados = 0;
                else
                    CuentaActual.NumEmpleados = Convert.ToInt64(this.txtNumEmpleados.Text.Replace(".",""));

                if (cboZonaVentas.SelectedIndex == 0)
                    CuentaActual.ZonaVentas = null;
                else
                    CuentaActual.ZonaVentas = (clsItemParametro) cboZonaVentas.SelectedItem;

                if (cboCategoria.SelectedIndex == 0)
                    CuentaActual.CategoriaCliente = null;
                else
                    CuentaActual.CategoriaCliente = (clsItemParametro) cboCategoria.SelectedItem;

                if (cboClasificacion.SelectedIndex == 0)
                    CuentaActual.Clasificacion = null;
                else
                    CuentaActual.Clasificacion = (clsCuentaclasificacion) cboClasificacion.SelectedItem;

                if (cboUMVOlumenMvto.SelectedIndex == 0)
                    CuentaActual.UMMovimientoEstimado = null;
                else
                    CuentaActual.UMMovimientoEstimado = (clsItemParametro) cboUMVOlumenMvto.SelectedItem;

                if (txtVolumenMovimiento.Text == "")
                    CuentaActual.MontoMovimientoEstimado = -1;
                else
                    CuentaActual.MontoMovimientoEstimado = Convert.ToDecimal(txtVolumenMovimiento.Text.Replace(".",""));

                if (cboFormaContactoPref.SelectedIndex == 0)
                    CuentaActual.FormaContactoPreferida = null;
                else
                    CuentaActual.FormaContactoPreferida = (clsItemParametro)cboFormaContactoPref.SelectedItem;

                if (this.rgPermiteTelOficina.SelectedIndex == 0)
                    CuentaActual.PermiteTelOficina = false;
                else
                    CuentaActual.PermiteTelOficina = true;

                if (this.rgPermiteTelParticular.SelectedIndex == 0)
                    CuentaActual.PermiteTelParticular = false;
                else
                    CuentaActual.PermiteTelParticular = true;

                if (this.rgPermiteTelMovil.SelectedIndex == 0)
                    CuentaActual.PermiteTelCelular = false;
                else
                    CuentaActual.PermiteTelCelular = true;

                if (rgPermiteSkype.SelectedIndex == 0)
                    CuentaActual.PermiteSkype = false;
                else
                    CuentaActual.PermiteSkype = true;

                if (this.rgPermiteEmail.SelectedIndex == 0)
                    CuentaActual.PermiteEmail = false;
                else
                    CuentaActual.PermiteEmail = true;

                if (this.rgPermiteEmailMasivo.SelectedIndex == 0)
                    CuentaActual.PermiteEmailMasivo = false;
                else
                    CuentaActual.PermiteEmailMasivo = true;

                if (cboDiaPrefer.SelectedIndex == 0)
                    CuentaActual.DiaPreferido = null;
                else
                    CuentaActual.DiaPreferido = (clsItemParametro)cboDiaPrefer.SelectedItem;

                if (cboJornadaPref.SelectedIndex == 0)
                    CuentaActual.JornadaPreferida = null;
                else
                    CuentaActual.JornadaPreferida = (clsItemParametro)cboJornadaPref.SelectedItem;

                CuentaActual.FechaCreacion = DateTime.Now;
                                                   
                CuentaActual.ClienteMaster.TiposRelaciones = new List<clsItemParametro>();
                foreach (clsItemParametro tipo in lstTipoRelacion.CheckedItems)
                {
                    CuentaActual.ClienteMaster.TiposRelaciones.Add(tipo);
                }

                //CuentaActual.ClienteMaster.CondicionComercial = new clsCondicionComercial();
                //CuentaActual.ClienteMaster.CondicionComercial.Id = Convert.ToInt64(this.txtIdCondicionCredito.Text);
                //CuentaActual.ClienteMaster.CondicionComercial.Cliente = CuentaActual.ClienteMaster;
                //CuentaActual.ClienteMaster.CondicionComercial.CondicionComercialFlete = (clsTipoCondicionComercial) cboCondicionFlete.SelectedItem;
                //CuentaActual.ClienteMaster.CondicionComercial.CondicionComercialGastosLocales = (clsTipoCondicionComercial)cboCondicionGastoLocal.SelectedItem;
                //CuentaActual.ClienteMaster.CondicionComercial.Estado = Enums.EstadoCondicionComercial.Guardado;
                //CuentaActual.ClienteMaster.CondicionComercial.FechaSolicita = DateTime.Now;
                //CuentaActual.ClienteMaster.CondicionComercial.FechaAutoriza = DateTime.Now;
                //CuentaActual.ClienteMaster.CondicionComercial.MontoLineaCredito = Convert.ToDecimal(txtMontoLineaCredito.Text);
                //CuentaActual.ClienteMaster.CondicionComercial.UsuarioSolicita = Base.Usuario.UsuarioConectado.Usuario;
                //CuentaActual.ClienteMaster.CondicionComercial.VigenciaDesde = Convert.ToDateTime(txtVigenciaCreditoDesde.Text);
                //CuentaActual.ClienteMaster.CondicionComercial.VigenciaHasta = Convert.ToDateTime(txtVigenciaCreditoHasta.Text);
                                     
            }

        #endregion

            private void BuscaCuentaPorId(Int64 IdCuenta)
            {
                clsCuenta cuenta = new clsCuenta();
                ResultadoTransaccion transaccion =
                    LogicaNegocios.Clientes.clsCuentas.BuscarCuentaPorId(IdCuenta);

                if (transaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                {
                    this.CuentaActual = null;
                    //MessageBox.Show("No se pudo cargar la Cuenta", "Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cuenta = (clsCuenta)transaccion.ObjetoTransaccion;

                this.CuentaActual = cuenta;                
            }

        #region "Dominio a Vista"

            public bool CargarFormulario()
            {
                BuscaCuentaPorId(this.CuentaActual.Id);

                if (CuentaActual == null || CuentaActual.Id == 0 )
                {
                    MessageBox.Show("No se pudo cargar la cuenta seleccionada", "Cuentas", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return false;
                }
                
                this.txtNombreCompania.Text = CuentaActual.ClienteMaster.NombreCompañia;
                txtNombreFantasia.Text = CuentaActual.ClienteMaster.NombreFantasia;
                txtRUT.Text = CuentaActual.ClienteMaster.RUT;

                cboVendedores.SelectedItem = CuentaActual.VendedorAsignado;
                txtVendedorAsignado.Text = CuentaActual.VendedorAsignado.ToString();
                chkAutorizadoAduana.Checked = CuentaActual.AutorizadoAduana;
             
                txtObservacion.Text = CuentaActual.Observacion;
                txtTelefono.Text = CuentaActual.Telefono;
                txtCuentaSkype.Text = CuentaActual.CuentaSkype;
                txtSitioWeb.Text = CuentaActual.SitioWeb;
                txtEmail.Text = CuentaActual.Email;
                lblEstado.Text = Convert.ToString(CuentaActual.Estado);

                cboSectorEconomico.SelectedItem = CuentaActual.SectorEconomico;
                cboTipoMonedaVtaEst.SelectedItem = CuentaActual.TipoMonedaVtaEstimada;
                txtVentaEst.Text = CuentaActual.MontoVentaEstimada.ToString();
                txtNumEmpleados.Text = CuentaActual.NumEmpleados.ToString();

                txtVolumenMovimiento.Text = CuentaActual.MontoMovimientoEstimado.ToString();
                cboUMVOlumenMvto.SelectedItem = CuentaActual.UMMovimientoEstimado;
                cboZonaVentas.SelectedItem = CuentaActual.ZonaVentas;
                cboCategoria.SelectedItem = CuentaActual.CategoriaCliente;
                cboClasificacion.SelectedItem = CuentaActual.Clasificacion;
                cboTipoRecibo.SelectedItem = CuentaActual.TipoReciboAperturaEmbarcador;

                for (int i = 0; i <= lstTipoRelacion.Items.Count - 1; i++)
                {
                    clsItemParametro valor = (clsItemParametro)lstTipoRelacion.Items[i];
                    foreach (clsItemParametro relacion in CuentaActual.ClienteMaster.TiposRelaciones)
                    {
                        if (valor.Id == relacion.Id)
                        {
                            lstTipoRelacion.SetItemChecked(i, true);
                            break;
                        }
                    }
                }

                grdProductosPreferidos.DataSource = ProductosCustomerActivos();
                grdCustomerProductoSeleccionados.DataSource = ProductosCustomerActivos();
             
                cboFormaContactoPref.SelectedItem = CuentaActual.FormaContactoPreferida;
                cboDiaPrefer.SelectedItem = CuentaActual.DiaPreferido;
                cboJornadaPref.SelectedItem = CuentaActual.JornadaPreferida;

                rgPermiteEmail.SelectedIndex = Convert.ToInt16(CuentaActual.PermiteEmail);
                rgPermiteSkype.SelectedIndex = Convert.ToInt16(CuentaActual.PermiteSkype);
                rgPermiteEmailMasivo.SelectedIndex = Convert.ToInt16(CuentaActual.PermiteEmailMasivo);
                rgPermiteTelMovil.SelectedIndex = Convert.ToInt16(CuentaActual.PermiteTelCelular);
                rgPermiteTelOficina.SelectedIndex = Convert.ToInt16(CuentaActual.PermiteTelOficina);
                rgPermiteTelParticular.SelectedIndex = Convert.ToInt16(CuentaActual.PermiteTelParticular);

                if (CuentaActual.ClienteMaster.DireccionInfo != null)
                    grdDirecciones.DataSource = CuentaActual.ClienteMaster.DireccionInfo.Items;

                IList<clsContacto> contactos = new List<clsContacto>();
                contactos = LogicaNegocios.Clientes.clsClientesMaster.ListrContactos(CuentaActual.ClienteMaster);
                grdContactos.DataSource = contactos;


                if (CuentaActual.Estado == Enums.Estado.Habilitado)
                    MenuCambiaEstado.Text = "Deshabilitar";
                if (CuentaActual.Estado == Enums.Estado.Deshabilitado)
                    MenuCambiaEstado.Text = "Habilitar";
                
                return true;
            }

        #endregion

            private void btnAgregarDireccion_Click(object sender, EventArgs e)
            {
                GuardaDireccion();
                
            }

            private bool ValidarCamposDireccion()
            {
                bool valida = true;

                dxErrorProvider1.ClearErrors();

                if (cboTipoDireccion.SelectedIndex <= 0)
                {
                    dxErrorProvider1.SetError(cboTipoDireccion, "Debe seleccionar un Tipo", ErrorType.Critical);
                    valida = false;
                }

                if (txtDireccion.Text.Length.Equals(0))
                {
                    dxErrorProvider1.SetError(txtDireccion, "Debe ingresar nombre de dirección", ErrorType.Critical);
                    valida = false;
                }

                if (cboPais.SelectedIndex <= 0)
                {
                    dxErrorProvider1.SetError(cboPais, "Debe seleccionar un Pais", ErrorType.Critical);
                    valida = false;
                }
                else
                {
                    if (cboCiudad.SelectedIndex <= 0)
                    {
                        dxErrorProvider1.SetError(cboCiudad, "Debe seleccionar una Ciudad", ErrorType.Critical);
                        valida = false;
                    }
                    else
                    {
                        if (cboComuna.SelectedIndex <= 0)
                        {
                            dxErrorProvider1.SetError(cboComuna, "Debe seleccionar una Comuna", ErrorType.Critical);
                            valida = false;
                        }
                    }
                }

                if (cboDestinoDireccion.SelectedIndex <= 0)
                {
                    dxErrorProvider1.SetError(cboDestinoDireccion, "Debe seleccionar un tipo", ErrorType.Critical);
                    valida = false;
                }

                if (txtNumero.Text.Length.Equals(0))
                {
                    dxErrorProvider1.SetError(txtNumero, "Debe indicar número", ErrorType.Critical);
                    valida = false;
                }

                if(cboSector.SelectedIndex < 0)
                {
                    dxErrorProvider1.SetError(cboSector, "Debe selecciona un sector valido", ErrorType.Critical);
                    valida = false;
                }

                return valida;
            }

            private void GuardaDireccion()
            {
                if (!ValidarCamposDireccion())
                    return;

                clsDireccion direccion = CargarObjetoDireccion();

                if (CuentaActual.ClienteMaster.DireccionInfo == null)
                    CuentaActual.ClienteMaster.DireccionInfo = new clsDireccionInfo();


                if (txtIdDireccion.Text != "0")
                {
                    int count = 0;
                    foreach (var dir in CuentaActual.ClienteMaster.DireccionInfo.Items)
                    {
                        if (dir.Id == Convert.ToInt64(txtIdDireccion.Text))
                        {
                            CuentaActual.ClienteMaster.DireccionInfo.Items[count] = direccion;
                            break;
                        }
                        count++;
                    }
                }
                else
                    this.CuentaActual.ClienteMaster.DireccionInfo.Items.Add(direccion);

                grdDirecciones.DataSource = this.CuentaActual.ClienteMaster.DireccionInfo.DireccionesActivas();
                grdDirecciones.RefreshDataSource();

                LimpiarCamposDireccion();

            }

            private clsDireccion CargarObjetoDireccion()
            {
                clsDireccion direccion = new clsDireccion();
                direccion.Id = Convert.ToInt64(this.txtIdDireccion.Text);
                direccion.TipoDireccion = (clsItemParametro)cboTipoDireccion.SelectedItem;
                direccion.NombreDireccion = txtDireccion.Text;
                direccion.Pais = (clsPais)cboPais.SelectedItem;
                direccion.Comuna = (clsComuna)cboComuna.SelectedItem;
                direccion.Ciudad = (clsCiudad)cboCiudad.SelectedItem;
                direccion.DestinoDireccion = (clsItemParametro)cboDestinoDireccion.SelectedItem;
                direccion.Numero = txtNumero.Text;
                direccion.OficinaDpto = txtOficinaDpto.Text;
                direccion.Block = txtBlock.Text;
                direccion.Sector = (clsItemParametro)cboSector.SelectedItem;
                return direccion;
            }

            private void LimpiarCamposDireccion()
            {
                cboTipoDireccion.SelectedIndex = 0;
                cboPais.SelectedIndex = 0;
                cboCiudad.SelectedIndex = 0;
                cboComuna.SelectedIndex = 0;
                txtDireccion.Text = "";
                cboDestinoDireccion.SelectedIndex = 0;
                txtNumero.Text = "";
                txtOficinaDpto.Text = "";
                txtBlock.Text = "";
                cboSector.SelectedIndex = 0;
                txtIdDireccion.Text = "0";
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

            private void cboCiudad_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cboPais.SelectedIndex > 0 && cboCiudad.SelectedIndex > 0)
                {
                    if ((clsCiudad)cboCiudad.SelectedItem != null)
                        cargarComunas(((clsCiudad)cboCiudad.SelectedItem).Id);
                }
                else
                    cargarComunas(-9);
            }

            private void btnNuevaDireccion_Click(object sender, EventArgs e)
            {
                LimpiarCamposDireccion();
            }

            private void btnSolicitarGastoLocal_Click(object sender, EventArgs e)
            {

            }

            private void btnSolicitadCondicioinCredito_Click(object sender, EventArgs e)
            {

            }

            private void MenuEliminar_Click(object sender, EventArgs e)
            {
                DialogResult resdialogo = MessageBox.Show("¿Está seguro de eliminar la Cuenta", "Cuenta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resdialogo == DialogResult.Yes)
                {
                    ResultadoTransaccion res = LogicaNegocios.Clientes.clsCuentas.BuscarCuentaPorId(this.CuentaActual.Id);
                    if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                    {
                        clsCuenta cuenta = (clsCuenta)res.ObjetoTransaccion;

                        res = new ResultadoTransaccion();
                        res = LogicaNegocios.Clientes.clsCuentas.EliminarCuenta(cuenta);

                        if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                        {
                            frmListarCuenta form = frmListarCuenta.Instancia;
                            form.ListarCuentas();

                            MDICraft mdi = MDICraft.Instancia;
                            mdi.MensajeAccion(Accion);

                            Instancia = null;
                            this.Close();
                        }
                        else
                            MessageBox.Show(res.Descripcion, "Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }            
            }

            private void btnEliminarDireccion_Click(object sender, EventArgs e)
            {
               EliminarDireccion();
            }

            private void EliminarDireccion()
            {
                var filaSelected = grdDirecciones.DefaultView.GetRow(gridView4.FocusedRowHandle);

                if (txtIdDireccion.Text.Length > 0)
                {
                    if (filaSelected == null)
                        MessageBox.Show("Seleccione la dirección a eliminar", "Cuenta", MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    else
                    {
                        clsDireccion direccion = (clsDireccion)filaSelected;

                        int count = 0;
                        foreach (var dir in CuentaActual.ClienteMaster.DireccionInfo.Items)
                        {
                            if (dir.Id == Convert.ToInt64(txtIdDireccion.Text))
                            {
                                direccion.IsDeleted = true;
                                CuentaActual.ClienteMaster.DireccionInfo.Items[count] = direccion;
                                break;
                            }
                            count++;
                        }
                        this.grdDirecciones.DataSource = CuentaActual.ClienteMaster.DireccionInfo.DireccionesActivas();
                        grdDirecciones.RefreshDataSource();
                    }
                }
            }

            private void grdDirecciones_Click(object sender, EventArgs e)
            {
                var filaSelected = grdDirecciones.DefaultView.GetRow(gridView4.FocusedRowHandle);

                if (filaSelected != null)
                {
                    clsDireccion direccion = (clsDireccion)filaSelected;
                    if (direccion != null)
                    {
                        cboTipoDireccion.SelectedItem = direccion.TipoDireccion;
                        txtDireccion.Text = direccion.NombreDireccion;
                        cboPais.SelectedItem = direccion.Pais;
                        cboCiudad.SelectedItem = direccion.Ciudad;
                        cboComuna.SelectedItem = direccion.Comuna;
                        cboDestinoDireccion.SelectedItem = direccion.DestinoDireccion;
                        txtNumero.Text = direccion.Numero;
                        txtOficinaDpto.Text = direccion.OficinaDpto;
                        txtBlock.Text = direccion.Block;
                        cboSector.SelectedItem = direccion.Sector;
                        txtIdDireccion.Text = direccion.Id.ToString();
                    }
                }            
            }

            private void MenuCambiaEstado_Click(object sender, EventArgs e)
            {
                DialogResult resdialogo = new DialogResult();
                Enums.Estado estado = new Enums.Estado();

                if(CuentaActual.Estado == Enums.Estado.Habilitado)
                {
                    resdialogo = MessageBox.Show("¿Está seguro de deshabilitar la Cuenta", "Cuenta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    estado = Enums.Estado.Deshabilitado;
                }                    
                else
                {
                    resdialogo = MessageBox.Show("¿Está seguro de habilitar la Cuenta", "Cuenta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    estado = Enums.Estado.Habilitado;
                }

                if (resdialogo == DialogResult.Yes)
                {                    
                    CuentaActual.Estado = estado;

                    ResultadoTransaccion res = new ResultadoTransaccion();
                    res = LogicaNegocios.Clientes.clsCuentas.CambiaEstado(CuentaActual);

                    if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                    {
                        frmListarCuenta form = frmListarCuenta.Instancia;
                        form.ListarCuentas();

                        MDICraft mdi = MDICraft.Instancia;
                        mdi.MensajeAccion(Enums.TipoAccionFormulario.CambiarEstado);

                        Instancia = null;
                        this.Close();
                    }
                    else
                        MessageBox.Show(res.Descripcion, "Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }            
            }

            private void cboSectorEconomico_Click(object sender, EventArgs e)
            {
                cboSectorEconomico.SelectAll();
            }

            private void cboTipoMonedaVtaEst_Click(object sender, EventArgs e)
            {
                cboTipoMonedaVtaEst.SelectAll();
            }

            private void cboZonaVentas_Click(object sender, EventArgs e)
            {
                cboZonaVentas.SelectAll();
            }

            private void cboCategoria_Click(object sender, EventArgs e)
            {
                cboCategoria.SelectAll();
            }

            private void cboTipoDireccion_Click(object sender, EventArgs e)
            {
                cboTipoDireccion.SelectAll();
            }

            private void cboPais_Click(object sender, EventArgs e)
            {
                cboPais.SelectAll();
            }

            private void cboCiudad_Click(object sender, EventArgs e)
            {
                cboCiudad.SelectAll();
            }

            private void cboComuna_Click(object sender, EventArgs e)
            {
                cboComuna.SelectAll();
            }

            private void cboDestinoDireccion_Click(object sender, EventArgs e)
            {
                cboDestinoDireccion.SelectAll();
            }

            private void cboSector_Click(object sender, EventArgs e)
            {
                cboSector.SelectAll();
            }

            private void cboFormaContactoPref_Click(object sender, EventArgs e)
            {
                cboFormaContactoPref.SelectAll();
            }

            private void cboDiaPrefer_Click(object sender, EventArgs e)
            {
                cboDiaPrefer.SelectAll();
            }

            private void cboJornadaPref_Click(object sender, EventArgs e)
            {
                cboJornadaPref.SelectAll();
            }

            private void txtRUT_Leave(object sender, EventArgs e)
            {
                bool error = false;
                if(txtRUT.Text.Trim() != "")
                {
                    error = Utils.Utils.ValidaRut(txtRUT.Text.Trim());
                    //txtRUT.Text = txtRUT.Text.ToUpper();
                    //txtRUT.Text = txtRUT.Text.Replace(".", "");
                    //if(!txtRUT.Text.Contains("-"))
                    //{
                    //    error = true;
                    //}
                    //else
                    //{
                    //    string[] ruts = txtRUT.Text.Split('-');
                    //    if (ruts[0].Length > 0)
                    //    {
                    //        string digito = Utils.Utils.digitoVerificador(Convert.ToInt64(ruts[0]));
                    //        string rutFull = ruts[0] + "-" + digito;

                    //        if (rutFull != txtRUT.Text.Trim())
                    //        {
                    //            error = true;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        error = true;
                    //    }
                    //}                                                                
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
                                          
            private void btnAgregarProducto_Click(object sender, EventArgs e)
            {
                dxErrorProvider1.ClearErrors();
                if(cboProductoPreferido.SelectedIndex <= 0)
                {
                    dxErrorProvider1.SetError(cboProductoPreferido, "Seleccione un producto", ErrorType.Critical);
                    return;                    
                }

                if(txtCustomer.Text == "")
                {
                    dxErrorProvider1.SetError(txtCustomer, "Debe ingresar un customer valido", ErrorType.Critical);
                    return;
                }
                else
                {
                    for (int i = 0; i < cboCustomers.Properties.Items.Count; i++)
                    {
                        if (cboCustomers.Properties.Items[i].ToString().Trim().ToUpper() == txtCustomer.Text.Trim().ToUpper())
                        {
                            cboCustomers.SelectedIndex = i;
                            break;
                        }                            
                    }

                    if (cboCustomers.SelectedIndex == 0)
                    {
                        return;                        
                    }
                }

                if(txtIdProductoCust.Text != "0")
                {
                    foreach (var item in CuentaActual.ClienteMaster.ProductosPreferidos)
                    {
                        if(item.Id.ToString() == txtIdProductoCust.Text)
                        {
                            item.Customer = (clsUsuario)cboCustomers.SelectedItem;
                            item.Producto = (clsTipoProducto)cboProductoPreferido.SelectedItem;
                        }
                    }
                }
                else
                {
                    foreach (var item in CuentaActual.ClienteMaster.ProductosPreferidos)
                    {
                        if (item.Producto.Id == ((clsTipoProducto)cboProductoPreferido.SelectedItem).Id && !item.IsDeleted)
                        {
                            dxErrorProvider1.SetError(cboProductoPreferido, "El producto ya existe", ErrorType.Critical);
                            return;                    
                        }
                    }



                    clsClientesProductos producto = new clsClientesProductos();
                    producto.Customer = (clsUsuario)cboCustomers.SelectedItem;
                    producto.Producto = (clsTipoProducto)cboProductoPreferido.SelectedItem;
                    producto.Id = Convert.ToInt64(txtIdProductoCust.Text);
                    CuentaActual.ClienteMaster.ProductosPreferidos.Add(producto);
                }
                
                grdProductosPreferidos.DataSource = ProductosCustomerActivos();
                grdProductosPreferidos.RefreshDataSource();

                txtIdProductoCust.Text = "0";
                txtCustomer.Text = "";
                cboCustomers.SelectedIndex = 0;
                cboProductoPreferido.SelectedIndex = 0;
            }

            private IList<clsClientesProductos> ProductosCustomerActivos()
            {
                IList<clsClientesProductos> list = new List<clsClientesProductos>();

                foreach (var productos in CuentaActual.ClienteMaster.ProductosPreferidos)
                {
                    if(!productos.IsDeleted)
                        list.Add(productos);
                }

                return list;
            }
            
            private void grdProductosPreferidos_Click(object sender, EventArgs e)
            {
                var filaSelected = grdProductosPreferidos.DefaultView.GetRow(gridView3.FocusedRowHandle);

                if (filaSelected != null)
                {
                    clsClientesProductos producto = (clsClientesProductos)filaSelected;
                    if (producto != null)
                    {
                        cboProductoPreferido.SelectedItem = producto.Producto;
                        txtCustomer.Text = producto.Customer.NombreCompleto.Trim();
                        cboCustomers.SelectedItem = producto.Customer;
                        txtIdProductoCust.Text = producto.Id.ToString();
                    }
                }   
            }

            private void btnEliminarProducto_Click(object sender, EventArgs e)
            {
                //item ya guardado
                if (txtIdProductoCust.Text != "0")
                {
                    foreach (var item in CuentaActual.ClienteMaster.ProductosPreferidos)
                    {
                        if (item.Id.ToString() == txtIdProductoCust.Text)
                        {
                            item.IsDeleted = true;
                        }
                    }                    
                }
                else
                {
                    foreach (var item in CuentaActual.ClienteMaster.ProductosPreferidos)
                    {
                        if (item.Producto.Nombre == ((clsTipoProducto)cboProductoPreferido.SelectedItem).Nombre)
                        {
                            item.IsDeleted = true;
                        }
                    }

                }
                txtIdProductoCust.Text = "0";

                grdProductosPreferidos.DataSource = ProductosCustomerActivos();
                grdProductosPreferidos.RefreshDataSource();
            }

            private void cboTipoRecibo_SelectedIndexChanged(object sender, EventArgs e)
            {
                this.CuentaActual.TipoReciboAperturaEmbarcador = (Enums.PaperlessTipoReciboAperturaEmbarcador)cboTipoRecibo.SelectedItem;
            }

            private void btnComunas_Click(object sender, EventArgs e)
            {
                frmComunas form = new frmComunas();
                //form.InstanciaContacto = Instancia;
                form.Show();
            }
                                                                              
    }
}
