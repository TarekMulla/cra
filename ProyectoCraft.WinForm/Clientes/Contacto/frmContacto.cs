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
using ProyectoCraft.Entidades.Clientes.Contacto;
using ProyectoCraft.Entidades.Clientes.Direcciones;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.LogicaNegocios.Parametros;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Clientes.Target;
using ProyectoCraft.Entidades.Clientes.Cuenta;
using System.Collections;

namespace ProyectoCraft.WinForm.Clientes.Contacto
{
    public partial class frmContacto : Form
    {
        public frmContacto()
        {
            InitializeComponent();
        }

        private static frmContacto _form = null;
        public static frmContacto Instancia
        {
            get
            {
                if (_form == null)
                    _form = new frmContacto();

                return _form;
            }
            set
            {
                _form = value;
            }
        }
        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        #region "Properties"

        private clsContacto _contactoactual;
        public clsContacto ContactoActual
        {
            get
            {
                if (_contactoactual == null)
                    _contactoactual = new clsContacto();

                return _contactoactual;
            }
            set { _contactoactual = value; }
        }

        private Enums.TipoAccionFormulario _accion;
        public Enums.TipoAccionFormulario Accion
        {
            get { return _accion; }
            set { _accion = value; }
        }

        #endregion

        private void frmContacto_Load(object sender, EventArgs e)
        {
            if (Accion == Enums.TipoAccionFormulario.Nuevo)
                FormLoad();
        }

        public void FormLoad()
        {
            CargarClientes();
            CargarCbosParametros();
            CargarPropietarios();         
            CargarPaises();
        }
        
        private void CargarClientes()
        {
            IList<clsClienteMaster> listclientes =
                LogicaNegocios.Clientes.clsClientesMaster.ListarClienteMaster(this.cboCuentaProspecto.Text,
                                                                              Enums.TipoPersona.Comercial, Enums.Estado.Habilitado,true);

            ComboBoxItemCollection coll = cboCuentaProspecto.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listclientes)
            {
                coll.Add(list);
                //ClientesParaContacto cliente = new ClientesParaContacto(list);
                //if(cliente.NombreCliente.Trim() != "")
                //    coll.Add(cliente);
            }
            cboCuentaProspecto.SelectedIndex = 0;
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(cboCuentaProspecto.Text);

            foreach (var list in listclientes)
            {
                auto.Add(list.ToString());
                //ClientesParaContacto cliente = new ClientesParaContacto(list);
                //if(cliente.NombreCliente.Trim() != "")
                //    auto.Add(cliente.NombreCliente);
            }

            cboCuentaProspecto.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCuentaProspecto.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboCuentaProspecto.MaskBox.AutoCompleteCustomSource = auto;
        }

        private void CargarCbosParametros()
        {
            try
            {
                clsParametrosInfo lstSaludos = clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.TipoSaludo);
                Utils.Utils.CargaComboBoxParametros(lstSaludos, this.cboSaludo);
                /**************************************************/
                clsParametrosInfo lstEstadoCivil = clsParametros.ListarParametrosPorTipo(Enums.TipoParametro.EstadoCivil);
                Utils.Utils.CargaComboBoxParametros(lstEstadoCivil,cboEstadoCivil);
                /**************************************************/
                clsParametrosInfo lstSexos = clsParametros.ListarParametrosPorTipo(Enums.TipoParametro.Sexo);
                Utils.Utils.CargaComboBoxParametros(lstSexos, cboSexo);
                /**************************************************/
                clsParametrosInfo lstRoles = clsParametros.ListarParametrosPorTipo(Enums.TipoParametro.TiposRol);
                Utils.Utils.CargaComboBoxParametros(lstRoles,cboRol);
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
                Utils.Utils.CargaComboBoxParametros(lstSectoresDireccion, cboTipoZona);
                /**************************************************/
                clsParametrosInfo lstFormaContPref =
                    clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.FormasContacto);
                Utils.Utils.CargaComboBoxParametros(lstFormaContPref, this.cboFormaContactoPref);
                /**************************************************/
                //Utils.Utils.CargaComboBoxEnumDias(this.cboDiaPreferido);
                clsParametrosInfo lstDias =
                    clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.Dias);
                Utils.Utils.CargaComboBoxParametros(lstDias, this.cboDiaPref);
                /**************************************************/
                //Utils.Utils.CargaComboBoxEnumJornada(this.cboJornadaPreferida);
                clsParametrosInfo lstJornadas =
                    clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.Jornada);
                Utils.Utils.CargaComboBoxParametros(lstJornadas, cboJornadaPref);
                /**************************************************/
                clsParametrosInfo lstDepartamentos =
                    clsParametros.ListarParametrosPorTipo(Enums.TipoParametro.TipoDepartamentoContacto);
                Utils.Utils.CargaComboBoxParametros(lstDepartamentos,cboDepartamento);
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CargarPropietarios()
        {
            Entidades.GlobalObject.ResultadoTransaccion res = LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Enums.Estado.Habilitado, Enums.CargosUsuarios.Todos);
            IList<Entidades.Usuarios.clsUsuario> listPropietarios = (IList<Entidades.Usuarios.clsUsuario>)res.ObjetoTransaccion;

            ComboBoxItemCollection coll = cboPropietario.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listPropietarios)
            {
                coll.Add(list);
            }
            cboPropietario.SelectedIndex = 0;
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(txtPropietario.Text);

            foreach (var list in listPropietarios)
            {
                auto.Add(list.Nombre + " " + list.ApellidoPaterno + " " + list.ApellidoMaterno);
            }

            txtPropietario.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtPropietario.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPropietario.MaskBox.AutoCompleteCustomSource = auto;

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

        private void MenuGuardar_Click(object sender, EventArgs e)
        {
            if(!ValidarFormulario())
                return;
            
            CargarObjetoContacto();

            ResultadoTransaccion resultado = LogicaNegocios.Clientes.clsContactos.GuardarContacto(ContactoActual, ((clsClienteMaster)cboCuentaProspecto.SelectedItem).Id);
            
            if(resultado.Estado == Enums.EstadoTransaccion.Rechazada)
            {
                MessageBox.Show(resultado.Descripcion, "Contacto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmListarContacto form = frmListarContacto.Instancia;
                form.ListarContactos();

                MDICraft mdi = MDICraft.Instancia;
                mdi.MensajeAccion(Accion);

                Instancia = null;
                this.Close();
            }


        }

        private bool ValidarFormulario()
        {
            bool validar = true;

            dxErrorProvider1.ClearErrors();

            if(cboCuentaProspecto.SelectedIndex == -1 || cboCuentaProspecto.SelectedIndex == 0)
            {
                dxErrorProvider1.SetError(cboCuentaProspecto, "Debe seleccionar un Cliente", ErrorType.Critical);
                validar = false;
            }

            if(cboSaludo.SelectedIndex <= 0)
            {
                dxErrorProvider1.SetError(cboSaludo,"Debe seleccionar un saludo",ErrorType.Critical);
                validar = false;
            }

            if(txtNombres.Text == "")
            {
                dxErrorProvider1.SetError(txtNombres, "Debe ingresar Nombres", ErrorType.Critical);
                validar = false;
            }

            if(txtApellidoPaterno.Text == "")
            {
                dxErrorProvider1.SetError(txtApellidoPaterno, "Debe ingresar Apellido Paterno", ErrorType.Critical);
                validar = false;
            }

            //if (txtApellidoMaterno.Text == "")
            //{
            //    dxErrorProvider1.SetError(txtApellidoMaterno, "Debe ingresar Apellido Materno", ErrorType.Critical);
            //    validar = false;
            //}

            if(txtCargo.Text == "")
            {                
                dxErrorProvider1.SetError(txtCargo, "Debe ingresar Cargo", ErrorType.Critical);
                validar = false;                
            }

            if(txtPropietario.Text == "")
            {
                dxErrorProvider1.SetError(txtPropietario, "Debe ingresar Propietario", ErrorType.Critical);
                validar = false;                
            }
            else
            {
                cboPropietario.SelectedIndex = 0;
                for (int i = 0; i < cboPropietario.Properties.Items.Count; i++)
                {
                    if (cboPropietario.Properties.Items[i].ToString().Trim().ToUpper() == txtPropietario.Text.Trim().ToUpper())
                        cboPropietario.SelectedIndex = i;
                }
                if (cboPropietario.SelectedIndex == 0)
                {
                    dxErrorProvider1.SetError(txtPropietario, "El Propietario no es valido", ErrorType.Critical);
                    validar = false;
                }
            }

            //if(txtTelefonoParticular.Text == "")
            //{
            //    dxErrorProvider1.SetError(txtTelefonoParticular, "Debe ingresar Telefono Particular", ErrorType.Critical);
            //    validar = false;                
            //}

            if(txtTelefonoOficina.Text == "")
            {
                dxErrorProvider1.SetError(txtTelefonoOficina, "Debe ingresar Telefono Oficina", ErrorType.Critical);
                validar = false;                
            }

            //if(txtTelefonoMovil.Text =="")
            //{
            //    dxErrorProvider1.SetError(txtTelefonoMovil, "Debe ingresar Telefono Movil", ErrorType.Critical);
            //    validar = false;                
            //}

            if(txtEmail.Text == "")
            {
                dxErrorProvider1.SetError(txtEmail, "Debe ingresar Email", ErrorType.Critical);
                validar = false;                
            }

            //if(txtCumpeaños.Text == "")
            //{
            //    dxErrorProvider1.SetError(txtCumpeaños, "Debe ingresar Cumpleaños", ErrorType.Critical);
            //    validar = false;                
            //}

            if(cboEstadoCivil.SelectedIndex <= 0)
            {
                dxErrorProvider1.SetError(cboEstadoCivil, "Debe seleccionar Estado Civil", ErrorType.Critical);
                validar = false;                
            }

            if(cboSexo.SelectedIndex <= 0)
            {
                dxErrorProvider1.SetError(cboSexo, "Debe seleccionar Sexo", ErrorType.Critical);
                validar = false;                
            }

            if(cboFormaContactoPref.SelectedIndex<= 0)
            {
                dxErrorProvider1.SetError(cboFormaContactoPref, "Debe seleccionar Forma de Contacto Preferida", ErrorType.Critical);
                validar = false;                
            }


            if(cboRol.SelectedIndex < 0)
            {
                dxErrorProvider1.SetError(cboRol, "Debe seleccionar un Rol Valido", ErrorType.Critical);
                validar = false;                
            }

            if(cboDiaPref.SelectedIndex < 0)
            {
                dxErrorProvider1.SetError(cboDiaPref, "Debe seleccionar un dia valido", ErrorType.Critical);
                validar = false;                
            }

            if(cboJornadaPref.SelectedIndex < 0)
            {
                dxErrorProvider1.SetError(cboRol, "Debe seleccionar una jornada valida", ErrorType.Critical);
                validar = false;                
            }

            if(cboDepartamento.SelectedIndex < 0)
            {
                dxErrorProvider1.SetError(cboDepartamento, "Debe seleccionar un departamento valido", ErrorType.Critical);
                validar = false;                
            }


            return validar;
        }

        private void CargarObjetoContacto()
        {
            ContactoActual.ClienteMaster = ((clsClienteMaster)cboCuentaProspecto.SelectedItem);
               
            if (cboSaludo.SelectedIndex == 0)
                ContactoActual.TipoSaludo = null;
            else 
                ContactoActual.TipoSaludo =(clsItemParametro)cboSaludo.SelectedItem;

            ContactoActual.Nombre = txtNombres.Text;
            ContactoActual.ApellidoPaterno = txtApellidoPaterno.Text;
            ContactoActual.ApellidoMaterno = txtApellidoMaterno.Text;
            ContactoActual.Cargo = txtCargo.Text;

            int contador = 0;
            foreach (object item in cboPropietario.Properties.Items)
            {
                if(item is Entidades.Usuarios.clsUsuario)
                {
                    if (item.ToString().Trim().ToUpper() == txtPropietario.Text.Trim().ToUpper())
                    {
                        cboPropietario.SelectedIndex = contador;
                        ContactoActual.Propietario = (Entidades.Usuarios.clsUsuario)cboPropietario.SelectedItem;
                        break;
                    }    
                }
                contador++;
            }

            ContactoActual.Observacion = txtObservacion.Text;
            ContactoActual.TelefonoParticular = txtTelefonoParticular.Text;
            ContactoActual.TelefonoOficina = txtTelefonoOficina.Text;
            ContactoActual.TelefonoCelular = txtTelefonoMovil.Text;
            ContactoActual.CuentaSkype = txtCuentaSkype.Text;
            ContactoActual.Email = txtEmail.Text;
            ContactoActual.EsPrincipal = chkEsPrincipal.Checked;

            if (cboDepartamento.SelectedIndex == 0)
                ContactoActual.Departamento = null;
            else 
                ContactoActual.Departamento = (clsItemParametro)cboDepartamento.SelectedItem;

            ContactoActual.NombreJefe = txtNombreJefe.Text;
            ContactoActual.TelefonoJefe = txtTelefonoJefe.Text;
            ContactoActual.NombreAyudante = txtNombreAyudante.Text;
            ContactoActual.TelefonoAyudante = txtTelefonoAyudante.Text;

            if (cboRol.SelectedIndex == 0)
                ContactoActual.TipoRol = null;
            else
                ContactoActual.TipoRol = (clsItemParametro)cboRol.SelectedItem;

            ContactoActual.Cumpleaños = txtCumpeaños.Text;
            if (cboEstadoCivil.SelectedIndex == 0)
                ContactoActual.EstadoCivil = null;
            else
                ContactoActual.EstadoCivil =(clsItemParametro)cboEstadoCivil.SelectedItem;

            if (cboSexo.SelectedIndex == 0)
                ContactoActual.Sexo = null;
            else
                ContactoActual.Sexo = (clsItemParametro) cboSexo.SelectedItem;

            ContactoActual.NombrePareja = txtNombrePareja.Text;
            ContactoActual.FechaAniversario = txtAniversario.Text;
            ContactoActual.RegaloPreferido = txtRegaloPreferido.Text;

            ContactoActual.Estado = Enums.Estado.Habilitado;

            if (cboFormaContactoPref.SelectedIndex == 0)
                ContactoActual.FormaContactoPreferida = null;
            else
                ContactoActual.FormaContactoPreferida = (clsItemParametro)cboFormaContactoPref.SelectedItem;

            if (this.rgTelefonoOficina.SelectedIndex == 0)
                ContactoActual.PermiteTelOficina = false;
            else
                ContactoActual.PermiteTelOficina = true;

            if (this.rgTelefonoParticular.SelectedIndex == 0)
                ContactoActual.PermiteTelParticular = false;
            else
                ContactoActual.PermiteTelParticular = true;

            if (this.rgTelefonoMovil.SelectedIndex == 0)
                ContactoActual.PermiteTelCelular = false;
            else
                ContactoActual.PermiteTelCelular = true;

            if (rgCuentaSkype.SelectedIndex == 0)
                ContactoActual.PermiteSkype = false;
            else
                ContactoActual.PermiteSkype = true;

            if (this.rgEmail.SelectedIndex == 0)
                ContactoActual.PermiteEmail = false;
            else
                ContactoActual.PermiteEmail = true;

            if (this.rgEmailMasivo.SelectedIndex == 0)
                ContactoActual.PermiteEmailMasivo = false;
            else
                ContactoActual.PermiteEmailMasivo = true;

            if (cboDiaPref.SelectedIndex == 0)
                ContactoActual.DiaPreferido = null;
            else
                ContactoActual.DiaPreferido = (clsItemParametro)cboDiaPref.SelectedItem;

            if (cboJornadaPref.SelectedIndex == 0)
                ContactoActual.JornadaPreferida = null;
            else
                ContactoActual.JornadaPreferida = (clsItemParametro)cboJornadaPref.SelectedItem;

        }

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

            if(cboTipoZona.SelectedIndex < 0 )
            {
                dxErrorProvider1.SetError(cboTipoZona, "Debe seleccionar una Zona valida", ErrorType.Critical);
                valida = false;
            }

            return valida;
        }

        private void GuardaDireccion()
        {
            if (!ValidarCamposDireccion())
                return;

            clsDireccion direccion = CargarObjetoDireccion();

            if (ContactoActual.DireccionInfo == null)
                ContactoActual.DireccionInfo = new clsDireccionInfo();


            if (txtIdDireccion.Text != "0")
            {
                int count = 0;
                bool existe = false;
                foreach (var dir in ContactoActual.DireccionInfo.Items)
                {
                    if (dir.Id == Convert.ToInt64(txtIdDireccion.Text))
                    {
                        ContactoActual.DireccionInfo.Items[count] = direccion;
                        existe = true;
                        break;
                    }
                    count++;
                }
                if(!existe)
                    this.ContactoActual.DireccionInfo.Items.Add(direccion);
            }
            else
                this.ContactoActual.DireccionInfo.Items.Add(direccion);

            grdDirecciones.DataSource = this.ContactoActual.DireccionInfo.DireccionesActivas();
            grdDirecciones.RefreshDataSource();

            LimpiarCamposDireccion();

            CargarDireccionesCliente();

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
            direccion.Sector = (clsItemParametro)cboTipoZona.SelectedItem;
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
            cboTipoZona.SelectedIndex = 0;
            txtIdDireccion.Text = "0";
        }

     
        private clsContacto BuscaContactoPorId(Int64 IdContacto)
        {
            clsContacto contacto = new clsContacto();
            Entidades.GlobalObject.ResultadoTransaccion transaccion =
                LogicaNegocios.Clientes.clsContactos.ObtenerContactoPorIdTransaccion(this.ContactoActual.Id);

            if (transaccion.Estado == Enums.EstadoTransaccion.Rechazada)                            
                return null;
                        
            contacto = (clsContacto) transaccion.ObjetoTransaccion;


            this.ContactoActual = contacto;
            return contacto;
        }

        public bool CargarFormulario()
        {
            clsContacto contacto = BuscaContactoPorId(this.ContactoActual.Id);

            if (contacto == null)
            {
                MessageBox.Show("No se pudo cargar el Contacto seleccionado", "Contacto", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }
            
            //ResultadoTransaccion resCliente = new ResultadoTransaccion();
            //if(ContactoActual.ClienteMaster.Tipo == Enums.TipoPersona.Cuenta)
            //{
            //     resCliente =
            //        LogicaNegocios.Clientes.clsCuentas.ObtenerCuentaPorIdMaster(ContactoActual.ClienteMaster.Id);
            //}
            

            ////ClientesParaContacto cliente = new ClientesParaContacto();
            //clsClienteMaster cliente = new clsClienteMaster(true);
            //if(resCliente.Estado == Enums.EstadoTransaccion.Aceptada && ContactoActual.ClienteMaster.Tipo == Enums.TipoPersona.Cuenta)
            //{
            //    clsCuenta cuenta = (clsCuenta)resCliente.ObjetoTransaccion;
            //    ContactoActual.ClienteMaster.Cuenta = cuenta;
            //    //cliente = new ClientesParaContacto(ContactoActual.ClienteMaster);
            //}
            ////else 
            ////    cliente = new ClientesParaContacto(ContactoActual.ClienteMaster);

            int count = 0;
            foreach (var cbo in cboCuentaProspecto.Properties.Items)
            {
                if (cbo is clsClienteMaster)
                {
                    if (cbo.ToString() == contacto.ClienteMaster.ToString())
                    {
                        cboCuentaProspecto.SelectedIndex = count;
                        break;
                    }                        
                }
                count++;
            }

            //this.cboCuentaProspecto.SelectedItem = cliente; //ContactoActual.ClienteMaster;

            if(ContactoActual.TipoSaludo != null)
                this.cboSaludo.SelectedItem = ContactoActual.TipoSaludo;

            txtNombres.Text = ContactoActual.Nombre;
            txtApellidoPaterno.Text = ContactoActual.ApellidoPaterno;
            txtApellidoMaterno.Text = ContactoActual.ApellidoMaterno;
            txtCargo.Text = ContactoActual.Cargo;
            txtPropietario.Text = ContactoActual.Propietario.ToString();

            if(ContactoActual.Propietario != null)
                cboPropietario.SelectedItem = ContactoActual.Propietario;

            txtObservacion.Text = ContactoActual.Observacion;
            txtTelefonoOficina.Text = ContactoActual.TelefonoOficina;
            txtTelefonoParticular.Text = ContactoActual.TelefonoParticular;
            txtTelefonoMovil.Text = ContactoActual.TelefonoCelular;
            txtCuentaSkype.Text = ContactoActual.CuentaSkype;
            txtEmail.Text = ContactoActual.Email;
            chkEsPrincipal.Checked = ContactoActual.EsPrincipal;
            lblEstado.Text = Convert.ToString(ContactoActual.Estado);

            if(ContactoActual.Departamento != null)
                cboDepartamento.SelectedItem = ContactoActual.Departamento;

            txtNombreJefe.Text = ContactoActual.NombreJefe;
            txtTelefonoJefe.Text = ContactoActual.TelefonoJefe;

            if(ContactoActual.TipoRol != null)
                cboRol.SelectedItem = ContactoActual.TipoRol;

            txtNombreAyudante.Text = ContactoActual.NombreAyudante;
            txtTelefonoAyudante.Text = ContactoActual.TelefonoAyudante;

            txtCumpeaños.Text = ContactoActual.Cumpleaños;
            txtNombrePareja.Text = ContactoActual.NombrePareja;

            if(ContactoActual.EstadoCivil != null)
                cboEstadoCivil.SelectedItem = ContactoActual.EstadoCivil;

            txtAniversario.Text = ContactoActual.FechaAniversario;

            if(ContactoActual.Sexo != null)
                cboSexo.SelectedItem = ContactoActual.Sexo;

            txtRegaloPreferido.Text = ContactoActual.RegaloPreferido;

            if(contacto.FormaContactoPreferida != null)
                cboFormaContactoPref.SelectedItem = ContactoActual.FormaContactoPreferida;

            rgTelefonoOficina.SelectedIndex = Convert.ToInt16(ContactoActual.PermiteTelOficina);
            rgTelefonoParticular.SelectedIndex = Convert.ToInt16(ContactoActual.PermiteTelParticular);
            rgTelefonoMovil.SelectedIndex = Convert.ToInt16(ContactoActual.PermiteTelCelular);
            rgCuentaSkype.SelectedIndex = Convert.ToInt16(ContactoActual.PermiteSkype);
            rgEmail.SelectedIndex = Convert.ToInt16(ContactoActual.PermiteEmail);
            rgEmailMasivo.SelectedIndex = Convert.ToInt16(ContactoActual.PermiteEmailMasivo);

            if(ContactoActual.DiaPreferido != null)
                cboDiaPref.SelectedItem = ContactoActual.DiaPreferido;

            if(ContactoActual.JornadaPreferida != null)
                cboJornadaPref.SelectedItem = ContactoActual.JornadaPreferida;

            if (ContactoActual.DireccionInfo != null)
                grdDirecciones.DataSource = this.ContactoActual.DireccionInfo.Items;

            if (ContactoActual.Estado == Enums.Estado.Habilitado)
                MenuDesactivar.Text = "Deshabilitar";
            if (ContactoActual.Estado == Enums.Estado.Deshabilitado)
                MenuDesactivar.Text = "Habilitar";

            return true;
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
                    cboTipoZona.SelectedItem = direccion.Sector;
                    txtIdDireccion.Text = direccion.Id.ToString();
                }
            }   
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
                    MessageBox.Show("Seleccione la dirección a eliminar", "Contacto", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                else
                {
                    clsDireccion direccion = (clsDireccion)filaSelected;

                    int count = 0;
                    foreach (var dir in ContactoActual.DireccionInfo.Items)
                    {
                        if (dir.Id == Convert.ToInt64(txtIdDireccion.Text))
                        {
                            direccion.IsDeleted = true;
                            ContactoActual.DireccionInfo.Items[count] = direccion;
                            break;
                        }
                        count++;
                    }
                    this.grdDirecciones.DataSource = ContactoActual.DireccionInfo.DireccionesActivas();
                    grdDirecciones.RefreshDataSource();

                    CargarDireccionesCliente();
                }
            }
        }

        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resdialogo = MessageBox.Show("¿Está seguro de eliminar el Contacto", "Target", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resdialogo == DialogResult.Yes)
            {
                ResultadoTransaccion res =
                    LogicaNegocios.Clientes.clsContactos.ObtenerContactoPorIdTransaccion(ContactoActual.Id);
                if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                {
                    clsContacto contacto = (clsContacto)res.ObjetoTransaccion;

                    res = new ResultadoTransaccion();
                    res = LogicaNegocios.Clientes.clsContactos.EliminarContacto(contacto);

                    if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                    {
                        frmListarContacto form = frmListarContacto.Instancia;
                        form.ListarContactos();

                        MDICraft mdi = MDICraft.Instancia;
                        mdi.MensajeAccion(Enums.TipoAccionFormulario.Eliminar);

                        Instancia = null;
                        this.Close();
                    }
                    else
                        MessageBox.Show(res.Descripcion, "Contactos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }            
        }

        private void MenuDesactivar_Click(object sender, EventArgs e)
        {
            DialogResult resdialogo = new DialogResult();
            Enums.Estado estado = new Enums.Estado();

            if (ContactoActual.Estado == Enums.Estado.Habilitado)
            {
                resdialogo = MessageBox.Show("¿Está seguro de deshabilitar el Contacto?", "Contacto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                estado = Enums.Estado.Deshabilitado;
            }
            else
            {
                resdialogo = MessageBox.Show("¿Está seguro de habilitar el Contacto", "Contacto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                estado = Enums.Estado.Habilitado;
            }

            if (resdialogo == DialogResult.Yes)
            {                                
                ContactoActual.Estado = estado;

                ResultadoTransaccion res = new ResultadoTransaccion();
                res = LogicaNegocios.Clientes.clsContactos.CambiaEstado(ContactoActual);

                if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                {
                    frmListarContacto form = frmListarContacto.Instancia;
                    form.ListarContactos();

                    MDICraft mdi = MDICraft.Instancia;
                    mdi.MensajeAccion(Enums.TipoAccionFormulario.CambiarEstado);

                    Instancia = null;
                    this.Close();
                }
                else
                    MessageBox.Show(res.Descripcion, "Contactos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }            
        }

        private void cboCuentaProspecto_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == 13)
            {
                cboSaludo.Focus();
            }
        }

        private void cboCuentaProspecto_Click(object sender, EventArgs e)
        {            
            cboCuentaProspecto.SelectAll();
        }

        private void cboCuentaProspecto_Enter(object sender, EventArgs e)
        {
            cboCuentaProspecto.SelectAll();
        }

        private void cboSaludo_Click(object sender, EventArgs e)
        {
            cboSaludo.SelectAll();
        }

        private void cboEstadoCivil_Click(object sender, EventArgs e)
        {
            cboEstadoCivil.SelectAll();
        }

        private void cboSexo_Click(object sender, EventArgs e)
        {
            cboSexo.SelectAll();
        }

        private void cboRol_Click(object sender, EventArgs e)
        {
            cboRol.SelectAll();
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

        private void cboFormaContactoPref_Click(object sender, EventArgs e)
        {
            cboFormaContactoPref.SelectAll();
        }

        private void cboDiaPref_Click(object sender, EventArgs e)
        {
            cboDiaPref.SelectAll();
        }

        private void cboJornadaPref_Click(object sender, EventArgs e)
        {
            cboJornadaPref.SelectAll();
        }

        private void cboDepartamento_Click(object sender, EventArgs e)
        {
            cboDepartamento.SelectAll();
        }

        private void cboCuentaProspecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboCuentaProspecto.SelectedIndex > 0)
            {
                CargarDireccionesCliente();
                CargarDatosUltimoContacto();
            }
                
        }

        private void CargarDatosUltimoContacto()
        {
            if(Accion == Enums.TipoAccionFormulario.Nuevo)
            {
                txtNombreAyudante.Text = "";
                txtTelefonoAyudante.Text = "";
                txtNombreJefe.Text = "";
                txtTelefonoJefe.Text = "";
                clsClienteMaster master = ((clsClienteMaster)cboCuentaProspecto.SelectedItem);
                IList<clsContacto> contactos = LogicaNegocios.Clientes.clsClientesMaster.ListrContactos(master);
                if(contactos.Count>0)
                {
                    txtNombreAyudante.Text = contactos[contactos.Count - 1].NombreAyudante;
                    txtTelefonoAyudante.Text = contactos[contactos.Count - 1].TelefonoAyudante;
                    txtNombreJefe.Text = contactos[contactos.Count - 1].NombreJefe;
                    txtTelefonoJefe.Text = contactos[contactos.Count - 1].TelefonoJefe;        
                }                
            }            
        }

        private void CargarDireccionesCliente()
        {
            clsClienteMaster master = ((clsClienteMaster)cboCuentaProspecto.SelectedItem);
            Int64 idInfo = 0;
            ResultadoTransaccion resultado = new ResultadoTransaccion();
            IList<clsDireccion> direccionesCargar = new List<clsDireccion>();

            if(master != null)
            {
                master = LogicaNegocios.Clientes.clsClientesMaster.ObtenerClienteMasterPorId(master.Id);
               
                if(master.DireccionInfo != null && master.DireccionInfo.IdInfo > 0)
                {
                    clsDireccionInfo direccion =
                        LogicaNegocios.Clientes.clsDirecciones.ListarDireccionesPorIdInfo(master.DireccionInfo.IdInfo);

                    if(direccion != null)
                    {
                        //Cargar solo direcciones que no esten en el contacto
                        foreach (var dirCliente in direccion.Items)
                        {
                            if(ContactoActual.DireccionInfo != null && ContactoActual.DireccionInfo.Items.Count > 0)
                            {
                                bool existe = false;
                                foreach (var dirContacto in this.ContactoActual.DireccionInfo.Items)
                                {
                                    if(!dirContacto.IsDeleted)
                                    {
                                        if ((dirCliente.TipoDireccion.Id == dirContacto.TipoDireccion.Id &&
                                        dirCliente.NombreDireccion == dirContacto.NombreDireccion &&
                                        dirCliente.Numero == dirContacto.Numero &&
                                        dirCliente.OficinaDpto == dirContacto.OficinaDpto &&
                                        dirCliente.Block == dirContacto.Block &&
                                        dirCliente.Pais.Id == dirContacto.Pais.Id &&
                                        dirCliente.Ciudad.Id32 == dirContacto.Ciudad.Id &&
                                        dirCliente.Comuna.Id == dirContacto.Comuna.Id &&
                                        dirCliente.DestinoDireccion.Id == dirContacto.DestinoDireccion.Id))
                                        {
                                            existe = true;
                                            break;
                                        }   
                                    }                                                                     
                                }    
                                if(!existe)
                                {                                    
                                    direccionesCargar.Add(dirCliente);                                    
                                }
                            }
                            else
                            {                                                                
                                direccionesCargar.Add(dirCliente);
                            }
                            

                        }

                        grdDireccionesCliente.DataSource = direccionesCargar;                 
                    }
                }
            }

           
        }

        private void grdDireccionesCliente_Click(object sender, EventArgs e)
        {
            var filaSelected = grdDireccionesCliente.DefaultView.GetRow(gridView1.FocusedRowHandle);

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
                    cboTipoZona.SelectedItem = direccion.Sector;
                    txtIdDireccion.Text = "0"; // direccion.Id.ToString();
                }
            }   
        }

        private void txtPropietario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtObservacion.Focus();
        }

       
        
                                     

    }

    //public class ClientesParaContacto
    //{

    //    public ClientesParaContacto(){}

    //    public ClientesParaContacto(clsClienteMaster master)
    //    {
    //        Master = master;
    //        if (master.Tipo == Enums.TipoPersona.Cuenta)
    //        {
    //            NombreCliente = master.NombreFantasia;
    //        }
    //        else NombreCliente = master.NombreCliente;
    //    }

    //    public clsClienteMaster Master { get; set; }

    //    private string _nombreCliente;
    //    public string NombreCliente
    //    {
    //        get
    //        {
    //            return _nombreCliente;
    //        }
    //        set { _nombreCliente = value; }
    //    }

    //    public override string ToString()
    //    {
    //        return NombreCliente + "(" + Master.Tipo + ")";
    //    }

    //}
}
