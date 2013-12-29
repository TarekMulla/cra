using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Clientes.Contacto;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Ventas.Productos;
using ProyectoCraft.LogicaNegocios.Parametros;
using ProyectoCraft.Entidades.Clientes.Target;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Clientes.Direcciones;

namespace ProyectoCraft.WinForm.Clientes.Target
{
    public partial class frmTarget : Form
    {
        private static frmTarget _form = null;
        public static frmTarget Instancia
        {
            get
            {
                if (_form == null)
                    _form = new frmTarget();

                return _form;
            }
            set
            {
                _form = value;
            }
        }

        public frmTarget():base()
        {
            InitializeComponent();
        }


        #region "Form Events"

        internal void frmTarget_Load(object sender, EventArgs e)
        {            
            if(Accion == Enums.TipoAccionFormulario.Nuevo)
            {
                FormLoad();
            }

        }


        #endregion                             

        #region "Eventos"
        
        private bool ValidarCampos()
        {
            bool resultado = true;

            dxErrorProvider1.ClearErrors();

            if(cboTipoSaludo.SelectedIndex <= 0)
            {
                dxErrorProvider1.SetError(cboTipoSaludo, "Debe seleccionar un saludo", ErrorType.Critical);
                resultado = false;
            }

            if((txtNombreCompañia.Text == "") && (txtNombres.Text == ""))
            {
                dxErrorProvider1.SetError(txtNombreCompañia, "Debe ingresar algun nombre", ErrorType.Critical);
                dxErrorProvider1.SetError(txtNombres, "Debe ingresar algun nombre", ErrorType.Critical);
                resultado = false;
            }
            else if(txtNombres.Text != "")
            {
                if(txtApellidoPat.Text == "")
                {
                    dxErrorProvider1.SetError(txtNombres, "Debe ingresar Apellido Paterno", ErrorType.Critical);
                    resultado = false;
                }
                if(txtApellidoMat.Text == "")
                {
                    dxErrorProvider1.SetError(txtNombres, "Debe ingresar Apellido Materno", ErrorType.Critical);
                    resultado = false;
                }
            }

            if(txtRUT.Text == "")
            {
                dxErrorProvider1.SetError(txtRUT, "Debe ingresar RUT", ErrorType.Critical);
                resultado = false;
            }

            if(txtVendedor.Text == "")
            {
                dxErrorProvider1.SetError(txtVendedor, "Debe asignar un vendedor", ErrorType.Critical);
                resultado = false;
            }
            else
            {
                cboVendedores.SelectedIndex = 0;
                for (int i = 0; i < cboVendedores.Properties.Items.Count; i++)
                {
                    if (cboVendedores.Properties.Items[i].ToString().Trim() == txtVendedor.Text.Trim())
                        cboVendedores.SelectedIndex = i;
                }
                if(cboVendedores.SelectedIndex == 0)
                {
                    dxErrorProvider1.SetError(txtVendedor, "El vendedor no es valido", ErrorType.Critical);
                    resultado = false;
                }
            }
            

            bool seleccion = false;
            //foreach (var item in lstTipoRelacion.CheckedItems)
            //{
            //    seleccion = true;
            //}
            //if(!seleccion)
            //{
            //    dxErrorProvider1.SetError(lstTipoRelacion, "Debe seleccionar al menos una relación", ErrorType.Critical);
            //    resultado = false;
            //}

            if(cboOrigenCliente.SelectedIndex <= 0)
            {
                dxErrorProvider1.SetError(cboOrigenCliente, "Debe seleccionar origen del Cliente", ErrorType.Critical);
                resultado = false;
            }

            if(cboMotivoInteres.SelectedIndex <= 0)
            {
                dxErrorProvider1.SetError(cboMotivoInteres, "Debe seleccionar motivo de interes", ErrorType.Critical);
                resultado = false;
            }

            if(cboNivelInteres.SelectedIndex <= 0)
            {
                dxErrorProvider1.SetError(cboNivelInteres, "Debe seleccionar nivel de interes", ErrorType.Critical);
                resultado = false;
            }

            if(cboSecetorEconomico.SelectedIndex < 0)
            {
                dxErrorProvider1.SetError(cboSecetorEconomico, "Debe seleccionar un Sector economico valido", ErrorType.Critical);
                resultado = false;
            }

            if(cboMonedaVtaEst.SelectedIndex < 0)
            {
                dxErrorProvider1.SetError(cboMonedaVtaEst, "Debe seleccionar una moneda valida", ErrorType.Critical);
                resultado = false;
            }

            if (cboFormaContactoPref.SelectedIndex < 0)
            {
                dxErrorProvider1.SetError(cboFormaContactoPref, "Debe seleccionar una forma de contacto valida", ErrorType.Critical);
                resultado = false;
            }

            if (cboDiaPreferido.SelectedIndex < 0)
            {
                dxErrorProvider1.SetError(cboDiaPreferido, "Debe seleccionar un dia valida", ErrorType.Critical);
                resultado = false;
            }

            if (cboJornadaPreferida.SelectedIndex < 0)
            {
                dxErrorProvider1.SetError(cboJornadaPreferida, "Debe seleccionar una Jornada valida", ErrorType.Critical);
                resultado = false;
            }


            //else
            //{
            //    if(cboVendedores.SelectedIndex == 0)
            //    {
            //        dxErrorProvider1.SetError(txtVendedor, "Debe ingresar un vendedor valido", ErrorType.Critical);
            //        resultado = false;
            //    }
            //}

            return resultado;

            //ValidarCampoVacio(this.txtNombreCompañia);

            //Validate_LessThanMinRule(productsUnitPriceCalcEdit, Decimal.Zero);
            //Validate_LessThanMinRule(orderUnitPriceCalcEdit, Decimal.Zero);
            //Validate_LessThanMinRule(quantitySpinEdit, Decimal.Zero);
            //Validate_LessThanMinRule(unitsInStockSpinEdit, Decimal.Zero);
            //Validate_LessThanMinRule(reorderLevelSpinEdit, Decimal.Zero);
            //Validate_LessThanMinRule(unitsOnOrderSpinEdit, Decimal.Zero);
            //Validate_BetweenMinAndMaxRule(discountSpinEdit, Decimal.Zero, 0.5m);
        }

        private bool ValidarExisteRut()
        {
            bool valida = false;
            bool resultado = false;

            if (Accion == Enums.TipoAccionFormulario.Nuevo) valida = true;
            else
            {
                if (txtRUT.Text != TargetActual.ClienteMaster.RUT) valida = true;
            }

            if(valida)
            {
                if (LogicaNegocios.Clientes.clsClientesMaster.ValidarExisteRut(txtRUT.Text.Replace(".","") , Enums.TipoPersona.Target))
                {
                    MessageBox.Show("El Rut ingresado ya existe", "Target", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    resultado = true;
                }
                else 
                    resultado = false;
            }

            return resultado;
        }

        private void ValidarCampoVacio(BaseEdit control)
        {
            if (control.Text == null || control.Text.Trim().Length == 0) dxErrorProvider1.SetError(control, "Debe ingresar información en este campo", ErrorType.Critical);
            else dxErrorProvider1.SetError(control, "");
        }

        private void MenuGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;
            
            if (ValidarExisteRut())
                return;


            LlenarEntidadTarget();

            Entidades.GlobalObject.ResultadoTransaccion res = LogicaNegocios.Clientes.clsTarget.GuardaTarget(this.TargetActual);
            IdTarget = ((clsTarget) res.ObjetoTransaccion).Id;
            IdMaster= ((clsTarget)res.ObjetoTransaccion).ClienteMaster.Id;

            if(res.Estado == Enums.EstadoTransaccion.Rechazada)
            {
                MessageBox.Show(res.Descripcion, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmListarTarget formLista = frmListarTarget.Instancia;
                formLista.Listartarget();

                MDICraft mdi = MDICraft.Instancia;
                mdi.MensajeAccion(this.Accion);

                Instancia = null;                
                this.Close();
            }
                
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }
      

        #endregion

        #region "Properties"

        private Int64 _idtarget;
        public Int64 IdTarget
        {
            get { return _idtarget; }
            set { _idtarget = value; }
        }

        private Int64 _idmaster;
        private Int64 IdMaster
        {
            get { return _idmaster; }
            set { _idmaster = value; }
        }

        private clsTarget _targetactual;
        public clsTarget TargetActual
        {
            get
            {
                if(_targetactual == null)
                    _targetactual = new clsTarget();

                return _targetactual;
            }
            set { _targetactual = value; }
        }

        private Enums.TipoAccionFormulario _accion;
        public Enums.TipoAccionFormulario Accion
        {
            get { return _accion; }
            set { _accion = value; }
        }
        

        #endregion

        #region "Private"

        public void FormLoad()
        {
            CargarCbosParametros();
            CargarVendedores();
            CargarPaises();
            CargarTargetsExistentes();
        }

        private bool ValidarFormulario()
        {            
            return ValidarCampos();            
        }
        
        private void CargarCbosParametros()
        {
            try
            {
                clsParametrosInfo lstSaludos = clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.TipoSaludo);
                Utils.Utils.CargaComboBoxParametros(lstSaludos, this.cboTipoSaludo);
                /**************************************************/
                clsParametrosInfo lstSectores =
                    clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.SectorEconomico);
                Utils.Utils.CargaComboBoxParametros(lstSectores, this.cboSecetorEconomico);
                /**************************************************/
                IList<Entidades.Tarifado.clsTipoMoneda> lstMonedas = clsParametros.ListarMonedas();
                ComboBoxItemCollection coll = cboMonedaVtaEst.Properties.Items;
                coll.Add(Utils.Utils.ObtenerPrimerItem());
                foreach (var list in lstMonedas)
                {
                    coll.Add(list);
                }
                cboMonedaVtaEst.SelectedIndex = 0;

                //cboMonedaVtaEst.DisplayMember = "Codigo";
                //cboMonedaVtaEst.ValueMember = "Id";
                //cboMonedaVtaEst.Items.Add(Utils.Utils.ObtenerPrimerItem());
                //cboMonedaVtaEst.Items.AddRange(lstMonedas.ToArray());
                //cboMonedaVtaEst.DataSource = lstMonedas;
                //cboMonedaVtaEst.SelectedIndex = 0;
                /**************************************************/
                clsParametrosInfo lstOrigenCliente =
                    clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.OrigenClientePotencial);
                Utils.Utils.CargaComboBoxParametros(lstOrigenCliente, this.cboOrigenCliente);
                /**************************************************/
                clsParametrosInfo lstNivelInteres =
                    clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.NivelInteres);
                Utils.Utils.CargaComboBoxParametros(lstNivelInteres, cboNivelInteres);
                /**************************************************/
                clsParametrosInfo lstMotivoInteres =
                    clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.MotivoInteres);
                Utils.Utils.CargaComboBoxParametros(lstMotivoInteres, cboMotivoInteres);
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
                //Utils.Utils.CargaComboBoxEnumDias(this.cboDiaPreferido);
                clsParametrosInfo lstDias =
                    clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.Dias);
                Utils.Utils.CargaComboBoxParametros(lstDias, this.cboDiaPreferido);
                /**************************************************/
                //Utils.Utils.CargaComboBoxEnumJornada(this.cboJornadaPreferida);
                clsParametrosInfo lstJornadas =
                    clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.Jornada);
                Utils.Utils.CargaComboBoxParametros(lstJornadas, cboJornadaPreferida);
                /**************************************************/

                IList<clsTipoProducto> lstProductos =
                    clsParametros.ListarProductos("S");

                lstProductoPreferido.DisplayMember = "Nombre";
                lstProductoPreferido.ValueMember = "Id";
                foreach (var list in lstProductos)
                {                    
                    lstProductoPreferido.Items.Add(list);                 
                }                                
                /**************************************************/
                //Empresas Competencia
                IList<clsEmpresaCompetencia> listEmpresas = new List<clsEmpresaCompetencia>();
                    //LogicaNegocios.Clientes.clsTarget.ListarEmpresasCompetencia(cboEmpresaTrabaja.SelectedText);
                coll = cboEmpresaTrabaja.Properties.Items;
                coll.Add(Utils.Utils.ObtenerPrimerItem());
                foreach (var list in listEmpresas)
                {
                    coll.Add(list);
                }
                cboEmpresaTrabaja.SelectedIndex = 0;
                cboEmpresaTrabaja.Properties.AutoComplete = true;


                AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
                auto.Add(txtEmpresaTrabaja.Text);
                txtEmpresaTrabaja.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtEmpresaTrabaja.AutoCompleteSource = AutoCompleteSource.CustomSource;
                foreach (var list in listEmpresas)
                {
                    auto.Add(list.Nombre);
                }
                txtEmpresaTrabaja.AutoCompleteCustomSource = auto;

                /**************************************************/
                //Origen Carga
                IList<clsOrigenCarga> listOrigenCarga =
                    LogicaNegocios.Clientes.clsTarget.ListarOrigenCarga(this.txtOrigenCarga.Text);
                coll = cboOrigenCarga.Properties.Items;
                coll.Add(Utils.Utils.ObtenerPrimerItem());
                foreach (var list in listOrigenCarga)
                {
                    coll.Add(list);
                }
                cboOrigenCarga.SelectedIndex = 0;

                auto = new AutoCompleteStringCollection();
                auto.Add(txtOrigenCarga.Text);
                txtOrigenCarga.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtOrigenCarga.AutoCompleteSource = AutoCompleteSource.CustomSource;
                foreach (var list in listOrigenCarga)
                {
                    auto.Add(list.Nombre);
                }
                txtOrigenCarga.AutoCompleteCustomSource = auto;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CargarVendedores()
        {
            Entidades.GlobalObject.ResultadoTransaccion res = LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Entidades.Enums.Enums.Estado.Habilitado, Enums.CargosUsuarios.Vendedor);
            IList<Entidades.Usuarios.clsUsuario> listVendedores = (IList<Entidades.Usuarios.clsUsuario>)res.ObjetoTransaccion;

            ComboBoxItemCollection coll = cboVendedores.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listVendedores)
            {
                coll.Add(list);
            }
            cboVendedores.SelectedIndex = 0;
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();            
            auto.Add(txtVendedor.Text);
            
            foreach (var list in listVendedores)
            {
                auto.Add(list.Nombre + " " + list.ApellidoPaterno + " " + list.ApellidoMaterno);
            }
            
            txtVendedor.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtVendedor.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtVendedor.MaskBox.AutoCompleteCustomSource = auto;


            cboVendedores.SelectedItem = Base.Usuario.UsuarioConectado.Usuario;
            txtVendedor.Text = Base.Usuario.UsuarioConectado.Usuario.ToString();

        }

        private void CargarTargetsExistentes()
        {
            IList<clsClienteMaster> listTargets = LogicaNegocios.Clientes.clsClientesMaster.ListarClienteMaster("-1", Enums.TipoPersona.Target, Enums.Estado.Todos,true);

            ComboBoxItemCollection coll = cboNombresCompanias.Properties.Items;
            ComboBoxItemCollection coll2 = cboRUTs.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            coll2.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listTargets)
            {
                coll.Add(list.NombreCliente);
                coll2.Add(list.RUT);
            }
            cboNombresCompanias.SelectedIndex = 0;
            cboRUTs.SelectedIndex = 0;

            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            AutoCompleteStringCollection auto2 = new AutoCompleteStringCollection();

            auto.Add(txtNombreCompañia.Text);
            auto2.Add(txtRUT.Text);

            foreach (var list in listTargets)
            {
                auto.Add(list.NombreCliente);
                auto2.Add(list.RUT);
            }

            txtNombreCompañia.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtNombreCompañia.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtNombreCompañia.MaskBox.AutoCompleteCustomSource = auto;

            txtRUT.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtRUT.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtRUT.MaskBox.AutoCompleteCustomSource = auto2;

        }

        private void CargarPaises()
        {
            IList<clsPais> paises = LogicaNegocios.Parametros.clsParametros.ListarPaises();
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

        #region "Public"



        #endregion

        #region "VistaADominio"

        private void LlenarEntidadTarget()
        {
            clsTarget Target = this.TargetActual;

            try
            {                
                Target.Id = this.IdTarget;
                //Target.ClienteMaster = new clsClienteMaster();
                Target.ClienteMaster.Id = this.IdMaster;
                Target.ClienteMaster.NombreCompañia= this.txtNombreCompañia.Text.Trim();
                Target.ClienteMaster.Nombres = this.txtNombres.Text.Trim();
                Target.ClienteMaster.ApellidoPaterno = this.txtApellidoPat.Text.Trim();                        
                Target.ClienteMaster.ApellidoMaterno = this.txtApellidoMat.Text.Trim();
                Target.ClienteMaster.RUT = this.txtRUT.Text.Trim();

                if(Target.ClienteMaster.DireccionInfo != null)
                    if(Target.ClienteMaster.DireccionInfo.Items.Count == 0)
                        Target.ClienteMaster.DireccionInfo = null;

                Target.ClienteMaster.Tipo = Enums.TipoPersona.Target;

                if (cboTipoSaludo.SelectedIndex == 0)
                    Target.TipoSaludo = null;
                else
                    Target.TipoSaludo = (clsItemParametro)this.cboTipoSaludo.SelectedItem;

                Target.Cargo = this.txtCargo.Text.Trim();
                
                Target.VendedorAsignado = (Entidades.Usuarios.clsUsuario)this.cboVendedores.SelectedItem;    
                
                
                Target.Telefono = this.txtTelefono.Text.Trim();
                Target.CuentaSkype = this.txtCuentaSkype.Text.Trim();
                Target.SitioWeb = this.txtSitioWeb.Text.Trim();
                Target.Email = this.txtEmail.Text.Trim();
                Target.Estado = Enums.EstadoTarget.Habilitado;
                Target.Observacion = this.txtObservacion.Text.Trim();

                if (cboSecetorEconomico.SelectedIndex == 0)
                    Target.SectorEconomico = null;
                else 
                    Target.SectorEconomico =(clsItemParametro)this.cboSecetorEconomico.SelectedItem;

                if (cboMonedaVtaEst.SelectedIndex == 0)
                    Target.TipoMonedaVtaEstimada = null;
                else
                    Target.TipoMonedaVtaEstimada = (Entidades.Tarifado.clsTipoMoneda) this.cboMonedaVtaEst.SelectedItem;

                if(txtMontoVtaEst.Text == "")
                    Target.MontoVentaEstimada = 0;
                else
                    Target.MontoVentaEstimada = Convert.ToDecimal(this.txtMontoVtaEst.Text.Replace(".",""));

                if (txtNumEmpleados.Text == "")
                    Target.NumEmpleados = 0;
                else 
                    Target.NumEmpleados = Convert.ToInt64(this.txtNumEmpleados.Text.Replace(".",""));

                if (cboOrigenCliente.SelectedIndex == 0)
                    Target.OrigenCliente = null;
                else 
                    Target.OrigenCliente =(clsItemParametro)cboOrigenCliente.SelectedItem;

                if (cboMotivoInteres.SelectedIndex == 0)
                    Target.MotivoInteres = null;
                else 
                    Target.MotivoInteres = (clsItemParametro)this.cboMotivoInteres.SelectedItem;

                if (cboNivelInteres.SelectedIndex == 0)
                    Target.NivelInteres = null;
                else 
                    Target.NivelInteres = (clsItemParametro) this.cboNivelInteres.SelectedItem;


                if(txtEmpresaTrabaja.Text.Trim() == "")
                {
                    Target.EmpresaConQueTrabaja = null;
                }
                else
                {
                    for (int i = 0; i < cboEmpresaTrabaja.Properties.Items.Count; i++)
                    {
                        if (cboEmpresaTrabaja.Properties.Items[i].ToString() == txtEmpresaTrabaja.Text)
                            cboEmpresaTrabaja.SelectedIndex = i;
                    }

                    if (cboEmpresaTrabaja.SelectedIndex == 0)
                    {
                        Target.EmpresaConQueTrabaja = new clsEmpresaCompetencia(0, txtEmpresaTrabaja.Text);
                    }
                    else
                        Target.EmpresaConQueTrabaja = (clsEmpresaCompetencia)this.cboEmpresaTrabaja.SelectedItem;    
                }

                

                if(txtOrigenCarga.Text.Trim() == "")
                {
                    Target.OrigenCarga = null;
                }
                else
                {
                    for (int i = 0; i < cboOrigenCarga.Properties.Items.Count; i++)
                    {
                        if (cboOrigenCarga.Properties.Items[i].ToString() == txtOrigenCarga.Text)
                            cboOrigenCarga.SelectedIndex = i;
                    }
                    if (cboOrigenCarga.SelectedIndex == 0)
                    {
                        Target.OrigenCarga = new clsOrigenCarga(0, txtOrigenCarga.Text);
                    }
                    else
                        Target.OrigenCarga = (clsOrigenCarga)this.cboOrigenCarga.SelectedItem;
                }

                if (cboFormaContactoPref.SelectedIndex == 0)
                    Target.FormaContactoPreferida = null;
                else
                    Target.FormaContactoPreferida = (clsItemParametro) cboFormaContactoPref.SelectedItem;

                if (this.rgTelefonoOficina.SelectedIndex == 0)
                    Target.PermiteTelOficina = false;
                else
                    Target.PermiteTelOficina = true;

                if(this.rgTelefonoParticular.SelectedIndex == 0)
                    Target.PermiteTelParticular = false;
                else
                    Target.PermiteTelParticular = true;

                if (this.rgTelefonoMovil.SelectedIndex == 0)
                    Target.PermiteTelCelular = false;
                else
                    Target.PermiteTelCelular = true;

                if (rgCuentaSkype.SelectedIndex == 0)
                    Target.PermiteSkype = false;
                else
                    Target.PermiteSkype = true;

                if(this.rgEmail.SelectedIndex == 0)
                    Target.PermiteEmail = false;
                else
                    Target.PermiteEmail = true;

                if (this.rgEmailMasivo.SelectedIndex == 0)
                    Target.PermiteEmailMasivo = false;
                else
                    Target.PermiteEmailMasivo = true;

                if (cboDiaPreferido.SelectedIndex == 0)
                    Target.DiaPreferido = null;
                else 
                    Target.DiaPreferido = (clsItemParametro)cboDiaPreferido.SelectedItem;

                if (cboJornadaPreferida.SelectedIndex == 0)
                    Target.JornadaPreferida = null;
                else 
                    Target.JornadaPreferida = (clsItemParametro) cboJornadaPreferida.SelectedItem;

                Target.FechaCreacion = DateTime.Now;
                
                Target.ClienteMaster.ProductosPreferidos = new List<clsClientesProductos>();
                foreach (clsTipoProducto item in lstProductoPreferido.CheckedItems)
                {
                    clsClientesProductos itemCP = new clsClientesProductos();
                    itemCP.Producto = item;
                    Target.ClienteMaster.ProductosPreferidos.Add(itemCP);
                }

                Target.ClienteMaster.TiposRelaciones = new List<clsItemParametro>();
                foreach (clsItemParametro tipo in lstTipoRelacion.CheckedItems)
                {
                    Target.ClienteMaster.TiposRelaciones.Add(tipo);
                }

                this.TargetActual = Target;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Target", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        #endregion

        #region "DominioAVista"


        private clsTarget BuscaTargetPorId(Int64 IdTarget)
        {
            clsTarget target = new clsTarget();
            Entidades.GlobalObject.ResultadoTransaccion transaccion = LogicaNegocios.Clientes.clsTarget.ObtenerTargetPorId(IdTarget);

            if (transaccion.Estado == Enums.EstadoTransaccion.Rechazada)                            
                return null;
                        
            target = (clsTarget) transaccion.ObjetoTransaccion;

            this.IdTarget = target.Id;
            this.IdMaster = target.ClienteMaster.Id;
            this.TargetActual = target;
            return target;
        }

        public bool CargarFormulario()
        {
            clsTarget target = BuscaTargetPorId(this.IdTarget);

            if(target == null)
            {
                MessageBox.Show("No se pudo cargar el Target seleccionado", "Target", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            if (target.TipoSaludo != null)
                this.cboTipoSaludo.SelectedItem = target.TipoSaludo;

            this.txtNombreCompañia.Text = target.ClienteMaster.NombreCompañia;
            txtNombres.Text = target.ClienteMaster.Nombres;
            txtApellidoPat.Text = target.ClienteMaster.ApellidoPaterno;
            txtApellidoMat.Text = target.ClienteMaster.ApellidoMaterno;
            txtRUT.Text = target.ClienteMaster.RUT;

            cboVendedores.SelectedItem = target.VendedorAsignado;
            txtVendedor.Text = target.VendedorAsignado.ToString();

            txtObservacion.Text = target.Observacion;
            txtTelefono.Text = target.Telefono;
            txtCuentaSkype.Text = target.CuentaSkype;
            txtSitioWeb.Text = target.SitioWeb;
            txtEmail.Text = target.Email;
            lblEstado.Text = Convert.ToString(target.Estado);
            txtCargo.Text = target.Cargo;

            cboSecetorEconomico.SelectedItem = target.SectorEconomico;
            cboMonedaVtaEst.SelectedItem = target.TipoMonedaVtaEstimada;
            txtMontoVtaEst.Text = target.MontoVentaEstimada.ToString();
            txtNumEmpleados.Text = target.NumEmpleados.ToString();

            int contador = 0;
            IList<clsItemParametro> sourceRelacones = (IList<clsItemParametro>)lstTipoRelacion.DataSource;
            foreach (var source in sourceRelacones)
            {
                foreach (var item in target.ClienteMaster.TiposRelaciones)
                {
                    if(source.Id == item.Id)
                    {
                        lstTipoRelacion.SetItemChecked(contador,true);
                    }
                }
                contador++;
            }
            
            //for (int i = 0; i <= lstTipoRelacion.Items.Count-1; i++)
            //{
            //    clsItemParametro valor = (clsItemParametro)lstTipoRelacion.Items[i].Value;
            //    foreach (clsItemParametro relacion in target.ClienteMaster.TiposRelaciones)
            //    {
            //        if (valor.Id == relacion.Id)
            //        {
            //            lstTipoRelacion.SetItemChecked(i, true);
            //            break;
            //        }
            //    }                
            //}

            for (int i = 0; i <= lstProductoPreferido.Items.Count-1; i++)
            {
                clsTipoProducto valor = (clsTipoProducto) lstProductoPreferido.Items[i];
                foreach (clsClientesProductos producto in target.ClienteMaster.ProductosPreferidos)
                {
                    if(valor.Id == producto.Producto.Id)
                    {
                        lstProductoPreferido.SetItemChecked(i,true);
                        lblTipoCarga.Text += producto.Producto.Nombre + "/";
                        break;
                    }
                }
            }

            cboOrigenCliente.SelectedItem = target.OrigenCliente;
            cboMotivoInteres.SelectedItem = target.MotivoInteres;
            cboNivelInteres.SelectedItem = target.NivelInteres;

            if(target.EmpresaConQueTrabaja != null)
            {
                cboEmpresaTrabaja.SelectedItem = target.EmpresaConQueTrabaja;
                txtEmpresaTrabaja.Text = target.EmpresaConQueTrabaja.Nombre;    
            }
            if(target.OrigenCarga != null)
            {
                cboOrigenCarga.SelectedItem = target.OrigenCarga;
                txtOrigenCarga.Text = target.OrigenCarga.Nombre;    
            }
            

            cboFormaContactoPref.SelectedItem = target.FormaContactoPreferida;
            cboDiaPreferido.SelectedItem = target.DiaPreferido;
            cboJornadaPreferida.SelectedItem = target.JornadaPreferida;

            rgEmail.SelectedIndex = Convert.ToInt16(target.PermiteEmail);
            rgCuentaSkype.SelectedIndex = Convert.ToInt16(target.PermiteSkype);
            rgEmailMasivo.SelectedIndex = Convert.ToInt16(target.PermiteEmailMasivo);
            rgTelefonoMovil.SelectedIndex = Convert.ToInt16(target.PermiteTelCelular);
            rgTelefonoOficina.SelectedIndex = Convert.ToInt16(target.PermiteTelOficina);
            rgTelefonoParticular.SelectedIndex = Convert.ToInt16(target.PermiteTelParticular);

            if (target.Estado == Enums.EstadoTarget.Descalificado)
                MenuCalificar.Enabled = false;

            if(target.ClienteMaster.DireccionInfo != null)
                grdDirecciones.DataSource = target.ClienteMaster.DireccionInfo.Items;


            IList<Entidades.Clientes.Contacto.clsContacto> contactos = new List<clsContacto>();
            contactos = LogicaNegocios.Clientes.clsClientesMaster.ListrContactos(target.ClienteMaster);
            grdContactos.DataSource = contactos;
           

            return true;
        }

        

        #endregion

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboPais.SelectedIndex > 0 )
            {
                if((clsPais)cboPais.SelectedItem != null)
                    CargarCiudades(((clsPais)cboPais.SelectedItem).Id);
            }
            else 
                CargarCiudades(-9);
        }

        private void cboCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboPais.SelectedIndex > 0 && cboCiudad.SelectedIndex > 0)
            {
                if ((clsCiudad)cboCiudad.SelectedItem != null)
                    cargarComunas( ((clsCiudad)cboCiudad.SelectedItem).Id);
            }
            else 
                cargarComunas(-9);
        }

        private void btnAgregarDireccion_Click(object sender, EventArgs e)
        {
            GuardaDireccion();
            
        }

        private bool ValidarCamposDireccion()
        {
            bool valida = true;

            dxErrorProvider1.ClearErrors();

            if(cboTipoDireccion.SelectedIndex <= 0)
            {
                dxErrorProvider1.SetError(cboTipoDireccion, "Debe seleccionar un Tipo", ErrorType.Critical);
                valida = false;
            }

            if(txtDireccion.Text.Length.Equals(0))
            {
                dxErrorProvider1.SetError(txtDireccion, "Debe ingresar nombre de dirección", ErrorType.Critical);
                valida = false;
            }

            if(cboPais.SelectedIndex <= 0)
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
                    if(cboComuna.SelectedIndex <= 0)
                    {
                        dxErrorProvider1.SetError(cboComuna, "Debe seleccionar una Comuna", ErrorType.Critical);
                        valida = false;
                    }
                }
            }
            
            if(cboDestinoDireccion.SelectedIndex <= 0)
            {
                dxErrorProvider1.SetError(cboDestinoDireccion, "Debe seleccionar un tipo", ErrorType.Critical);
                valida = false;
            }

            if(txtNumero.Text.Length.Equals(0))
            {
                dxErrorProvider1.SetError(txtNumero, "Debe indicar número", ErrorType.Critical);
                valida = false;
            }
            
            if(cboSector.SelectedIndex < 0)
            {
                dxErrorProvider1.SetError(cboSector, "Debe seleccionar un sector valido", ErrorType.Critical);
                valida = false;
            }

          

            return valida;
        }

        private void GuardaDireccion()
        {
            if(!ValidarCamposDireccion())
                return;
            
            clsDireccion direccion = CargarObjetoDireccion();
            
            if(TargetActual.ClienteMaster.DireccionInfo == null) 
                TargetActual.ClienteMaster.DireccionInfo = new clsDireccionInfo();


            if(txtIdDireccion.Text != "0")
            {                                
                int count = 0;
                foreach (var dir in TargetActual.ClienteMaster.DireccionInfo.Items)
                {
                    if (dir.Id == Convert.ToInt64(txtIdDireccion.Text))
                    {
                        TargetActual.ClienteMaster.DireccionInfo.Items[count] = direccion;
                        break;
                    }                    
                    count++;
                }                
            }
            else                         
                this.TargetActual.ClienteMaster.DireccionInfo.Items.Add(direccion);

            grdDirecciones.DataSource = this.TargetActual.ClienteMaster.DireccionInfo.DireccionesActivas();
            grdDirecciones.RefreshDataSource();
            LimpiarCamposDireccion();
        }
             
        private clsDireccion CargarObjetoDireccion()
        {
            clsDireccion direccion = new clsDireccion();
            direccion.Id = Convert.ToInt64(this.txtIdDireccion.Text);
            direccion.TipoDireccion = (clsItemParametro)cboTipoDireccion.SelectedItem;
            direccion.NombreDireccion = txtDireccion.Text;
            direccion.Pais = (clsPais) cboPais.SelectedItem;
            direccion.Comuna = (clsComuna) cboComuna.SelectedItem;
            direccion.Ciudad = (clsCiudad) cboCiudad.SelectedItem;
            direccion.DestinoDireccion= (clsItemParametro) cboDestinoDireccion.SelectedItem;
            direccion.Numero = txtNumero.Text;
            direccion.OficinaDpto = txtOficina.Text;
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
            txtOficina.Text = "";
            txtBlock.Text = "";
            cboSector.SelectedIndex = 0;
            txtIdDireccion.Text = "0";
        }

        private void grdDirecciones_Click(object sender, EventArgs e)
        {
            var filaSelected = grdDirecciones.DefaultView.GetRow(gridView1.FocusedRowHandle);

            if(filaSelected != null)
            {
                clsDireccion direccion = (clsDireccion)filaSelected;
                if(direccion != null)
                {
                    cboTipoDireccion.SelectedItem = direccion.TipoDireccion;
                    txtDireccion.Text = direccion.NombreDireccion;
                    cboPais.SelectedItem = direccion.Pais;
                    cboCiudad.SelectedItem = direccion.Ciudad;
                    cboComuna.SelectedItem = direccion.Comuna;
                    cboDestinoDireccion.SelectedItem = direccion.DestinoDireccion;
                    txtNumero.Text = direccion.Numero;
                    txtOficina.Text = direccion.OficinaDpto;
                    txtBlock.Text = direccion.Block;
                    cboSector.SelectedItem = direccion.Sector;
                    txtIdDireccion.Text = direccion.Id.ToString();
                }
            }            
        }

        private void EliminarDireccion()
        {
            var filaSelected = grdDirecciones.DefaultView.GetRow(gridView1.FocusedRowHandle);

            if (txtIdDireccion.Text.Length > 0)
            {
                if (filaSelected == null)
                    MessageBox.Show("Seleccione la dirección a eliminar", "Target", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                else
                {
                    clsDireccion direccion = (clsDireccion)filaSelected;

                    int count = 0;
                    foreach (var dir in TargetActual.ClienteMaster.DireccionInfo.Items)
                    {
                        if (dir.Id == Convert.ToInt64(txtIdDireccion.Text))
                        {
                            direccion.IsDeleted = true;
                            TargetActual.ClienteMaster.DireccionInfo.Items[count] = direccion;
                            break;
                        }
                        count++;
                    }
                    this.grdDirecciones.DataSource = TargetActual.ClienteMaster.DireccionInfo.DireccionesActivas();
                    grdDirecciones.RefreshDataSource();
                }
            } 
        }
              
        private void btnNuevaDireccion_Click(object sender, EventArgs e)
        {
            LimpiarCamposDireccion();
        }

        private void btnEliminarDireccion_Click(object sender, EventArgs e)
        {
            EliminarDireccion();
        }

        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resdialogo = MessageBox.Show("¿Está seguro de eliminar el Target", "Target", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resdialogo == DialogResult.Yes)
            {
                ResultadoTransaccion res = LogicaNegocios.Clientes.clsTarget.ObtenerTargetPorId(this.TargetActual.Id);
                if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                {
                    clsTarget target = (clsTarget)res.ObjetoTransaccion;

                    res = new ResultadoTransaccion();
                    res = LogicaNegocios.Clientes.clsTarget.EliminarTarget(target);

                    if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                    {
                        frmListarTarget form = frmListarTarget.Instancia;
                        form.Listartarget();

                        MDICraft mdi = MDICraft.Instancia;
                        mdi.MensajeAccion(Accion);

                        Instancia = null;
                        this.Close();
                    }
                    else
                        MessageBox.Show(res.Descripcion, "Target", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }            
        }

        private void txtRUT_EditValueChanged(object sender, EventArgs e)
        {
            //string digito = Utils.Utils.digitoVerificador( Convert.ToInt16(txtRUT.Text));
            //string rut = txtRUT.Text.ToString() + "-" + digito;
            //txtRUT.Text = rut;
        }

        private void MenuCalificar_Click(object sender, EventArgs e)
        {
            if (TargetActual.IsNew) return;
            
            frmDescalificar form = frmDescalificar.Instancia;
            form.IdTarget = TargetActual.Id;
            form.ShowDialog();
        }

        private void cboTipoSaludo_Click(object sender, EventArgs e)
        {
            cboTipoSaludo.SelectAll();
        }

        private void cboSecetorEconomico_Click(object sender, EventArgs e)
        {
            cboSecetorEconomico.SelectAll();
        }

        private void cboMonedaVtaEst_Click(object sender, EventArgs e)
        {
            cboMonedaVtaEst.SelectAll();
        }

        private void cboOrigenCliente_Click(object sender, EventArgs e)
        {
            cboOrigenCliente.SelectAll();
        }

        private void cboMotivoInteres_Click(object sender, EventArgs e)
        {
            cboMotivoInteres.SelectAll();
        }

        private void cboNivelInteres_Click(object sender, EventArgs e)
        {
            cboNivelInteres.SelectAll();
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

        private void cboDiaPreferido_Click(object sender, EventArgs e)
        {
            cboDiaPreferido.SelectAll();
        }

        private void cboJornadaPreferida_Click(object sender, EventArgs e)
        {
            cboJornadaPreferida.SelectAll();
        }

        private void btnComunas_Click(object sender, EventArgs e)
        {
            frmComunas form = new frmComunas();
            //form.InstanciaContacto = Instancia;
            form.Show();
        }

      

        
        

      
    }
}
