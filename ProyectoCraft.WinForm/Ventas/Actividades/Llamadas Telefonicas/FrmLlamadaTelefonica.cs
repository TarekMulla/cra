using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using ProyectoCraft.Entidades.Ventas.Actividades.Llamadas_Telefonicas;
using ProyectoCraft.Entidades.Ventas.Actividades;
using ProyectoCraft.Entidades.Ventas.Productos;
using ProyectoCraft.Entidades.Ventas.Oportunidades;
using ProyectoCraft.Entidades.Clientes.Contacto;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Usuarios;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using ProyectoCraft.LogicaNegocios.Clientes;
using ProyectoCraft.Entidades.Enums;


namespace ProyectoCraft.WinForm.Ventas.Actividades.Llamadas_Telefonicas
{
    public partial class FrmLlamadaTelefonica : Form
    {
        private long IdUsuario;
        private Int64 _idllamada;
        private static FrmLlamadaTelefonica _form = null;
        private static ClsLlamadaTelefonica _objLlamadaTelefonica;

        public static ClsLlamadaTelefonica ObjLlamadaTelefonica
        {
            get { return _objLlamadaTelefonica; }
            set { _objLlamadaTelefonica = value; }
        }

        public static FrmLlamadaTelefonica Instancia
        {
            get
            {
                if (_form == null)
                    _form = new FrmLlamadaTelefonica();

                return _form;
            }
            set { _form = value; }
        }

        private void CargarComboAsuntosTipo(int IdTipoActividad, string EntradaSalida)
        {
            Entidades.GlobalObject.ResultadoTransaccion res
                = LogicaNegocios.Ventas.Actividades.clsAsuntoTipoActividad.ListarAsuntosTipoActividad(IdTipoActividad,
                                                                                                      EntradaSalida);

            IList<clsAsuntoTipoActividad> ListAsuntosTipoActividad =
                (IList<clsAsuntoTipoActividad>)res.ObjetoTransaccion;

            this.checkListBoxTiposAsunto.DataSource = null;
            this.checkListBoxTiposAsunto.DataSource = ListAsuntosTipoActividad;

        }

        private void CargarComboTiposProductos(string ExpoImpo, string Activo)
        {
            Entidades.GlobalObject.ResultadoTransaccion res
                = LogicaNegocios.Ventas.Productos.clsTipoProducto.ListarTiposProducto(ExpoImpo, Activo);

            IList<clsTipoProducto> ListaTiposProductos = (IList<clsTipoProducto>)res.ObjetoTransaccion;

            ComboBoxItemCollection coll = comboBoxTipoProducto.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in ListaTiposProductos)
            {
                coll.Add(list);
            }

            comboBoxTipoProducto.SelectedIndex = 0;

            AutoCompleteStringCollection textoAutocompletar = new AutoCompleteStringCollection();
            textoAutocompletar = new AutoCompleteStringCollection();

            comboBoxTipoProducto.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxTipoProducto.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (var list in ListaTiposProductos)
            {
                textoAutocompletar.Add(list.Nombre);
            }
            comboBoxTipoProducto.MaskBox.AutoCompleteCustomSource = textoAutocompletar;

        }

        private void CargarListAsuntosActividad(long IdActividad)
        {
            Entidades.GlobalObject.ResultadoTransaccion res =
                LogicaNegocios.Ventas.Actividades.clsAsuntoTipoActividad.ListarAsuntosActividad(IdActividad);

            int i;
            int Id;
            clsAsuntoTipoActividad ObjPaso = new clsAsuntoTipoActividad();

            IList<clsAsuntoActividad> ListAsuntosActividad = (IList<clsAsuntoActividad>)res.ObjetoTransaccion;

            for (i = 0; i <= this.checkListBoxTiposAsunto.ItemCount - 1; i++)
            {
                ObjPaso = (clsAsuntoTipoActividad)checkListBoxTiposAsunto.GetItemValue(i);
                foreach (var list in ListAsuntosActividad)
                {
                    if (list.ObjAsuntoTipoActividad.Id == ObjPaso.Id)
                    {
                        this.checkListBoxTiposAsunto.SetItemChecked(i, true);
                        break;
                    }
                }
            }
            //ComboBoxItemCollection coll = CboTema.Properties.Items;
            //coll.Add(Utils.Utils.ObtenerPrimerItem());
            //foreach (var list in ListAsuntosTipoActividad)
            //{
            //    coll.Add(list);
            //}
            //CboTema.SelectedIndex = 0;
        }

        private IList<ClsObjetoPasoGrilla> TraspasaObjetosGrillaInicializaMarca(
            IList<clsOportunidad> ListaOportunidadaes)
        {
            ClsObjetoPasoGrilla ObjPasoGrilla;
            IList<ClsObjetoPasoGrilla> ListaSalida = new List<ClsObjetoPasoGrilla>();

            foreach (var list in ListaOportunidadaes)
            {
                ObjPasoGrilla = new ClsObjetoPasoGrilla();
                ObjPasoGrilla.ObjOportunidadPaso = list;
                ObjPasoGrilla.MarcaOportunidad = false;
                ListaSalida.Add(ObjPasoGrilla);
            }
            return ListaSalida;
        }

        private IList<ClsObjetoPasoGrilla> TraspasaObjetosGrillaAsignaMarca(IList<clsOportunidad> ListaOportunidadaes)
        {
            ClsObjetoPasoGrilla ObjPasoGrilla;
            IList<ClsObjetoPasoGrilla> ListaSalida = new List<ClsObjetoPasoGrilla>();

            for (int i = 0; i < this.gridView1.RowCount; i++)
            {
                ObjPasoGrilla = new ClsObjetoPasoGrilla();
                ObjPasoGrilla = (ClsObjetoPasoGrilla)gridView1.GetRow(i);
                foreach (var list in ListaOportunidadaes)
                {
                    if (ObjPasoGrilla.ObjOportunidadPaso.Id == list.Id)
                    {
                        ObjPasoGrilla.MarcaOportunidad = true;
                        ListaSalida.Add(ObjPasoGrilla);
                    }
                    //ObjPasoGrilla = new ClsObjetoPasoGrilla();
                }

            }
            return ListaSalida;
        }

        private void FrmLlamadaTelefonica_FormClosed(object sender, FormClosedEventArgs e)
        {
            ObjLlamadaTelefonica = null;
            Instancia = null;
        }

        private void CargarGrillaOportunidades(Int64 IdCliente)
        {
            IList<ClsObjetoPasoGrilla> ListaPaso;

            Entidades.GlobalObject.ResultadoTransaccion res =
                LogicaNegocios.Ventas.Oportunidades.clsOportunidad.ListarOportunidadesPorCliente(IdCliente);
            IList<clsOportunidad> ListaOportunidades = (IList<clsOportunidad>)res.ObjetoTransaccion;

            ListaPaso = TraspasaObjetosGrillaInicializaMarca(ListaOportunidades);

            this.gridOportunidadesCliente.DataSource = null;
            this.gridOportunidadesCliente.DataSource = ListaPaso;

        }

        private void CargarGrillaLlamadasRecientes(Int64 IdCliente)
        {

            Entidades.GlobalObject.ResultadoTransaccion res =
                LogicaNegocios.Ventas.Actividades.Llamadas_Telefonicas.ClsLlamataTelefonica.
                    ListarLlamadasTelefonicasRecientes(IdCliente);
            IList<ClsLlamadaTelefonica> ListaLlamadas = (IList<ClsLlamadaTelefonica>)res.ObjetoTransaccion;

            this.gridActividades.DataSource = null;
            this.gridActividades.DataSource = ListaLlamadas;

        }

        private void CargarGrillaOportunidadesActividad(long IdActividad, int IdTipoActividad)
        {
            IList<ClsObjetoPasoGrilla> ListaPaso;

            Entidades.GlobalObject.ResultadoTransaccion res =
                LogicaNegocios.Ventas.Oportunidades.clsOportunidad.ListarOportunidadesActividad(IdActividad,
                                                                                                IdTipoActividad);
            IList<clsOportunidad> ListaOportunidades = (IList<clsOportunidad>)res.ObjetoTransaccion;

            if (ListaOportunidades.Count > 0)
            {
                ListaPaso = TraspasaObjetosGrillaAsignaMarca(ListaOportunidades);

                this.gridOportunidadesCliente.DataSource = null;
                this.gridOportunidadesCliente.DataSource = ListaPaso;
            }

        }

        private void CargarComboTodosClientes(long IdUsuario, string Busqueda)
        {
            //Llena el combo con la lista de Targets
            CboCliente.ResetText();

            IList<clsClienteMaster> ListaClienteMaster =
                LogicaNegocios.Clientes.clsClientesMaster.ListarClienteMaster(Busqueda, Enums.TipoPersona.Comercial,
                                                                              Enums.Estado.Todos, true);

            ComboBoxItemCollection coll = CboCliente.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in ListaClienteMaster)
            {
                coll.Add(list);
            }

            CboCliente.SelectedIndex = 0;

            AutoCompleteStringCollection textoAutocompletar = new AutoCompleteStringCollection();
            textoAutocompletar = new AutoCompleteStringCollection();

            CboCliente.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboCliente.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (var list in ListaClienteMaster)
            {
                textoAutocompletar.Add(list.NombreCliente);
            }
            //foreach (var list in ListaTargets)
            //{
            //    textoAutocompletar.Add(list.Nombre); 
            //}
            CboCliente.MaskBox.AutoCompleteCustomSource = textoAutocompletar;

        }

        private void CargarComboClientesActivos(long IdUsuario, string Busqueda)
        {
            //Llena el combo con la lista de Targets
            CboCliente.ResetText();

            IList<clsClienteMaster> ListaClienteMaster =
                LogicaNegocios.Clientes.clsClientesMaster.ListarClienteMaster(Busqueda, Enums.TipoPersona.Comercial,
                                                                              Enums.Estado.Habilitado, true);

            ComboBoxItemCollection coll = CboCliente.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in ListaClienteMaster)
            {
                coll.Add(list);
            }

            CboCliente.SelectedIndex = 0;

            AutoCompleteStringCollection textoAutocompletar = new AutoCompleteStringCollection();
            textoAutocompletar = new AutoCompleteStringCollection();

            CboCliente.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboCliente.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (var list in ListaClienteMaster)
            {
                textoAutocompletar.Add(list.NombreCliente);
            }
            //foreach (var list in ListaTargets)
            //{
            //    textoAutocompletar.Add(list.Nombre); 
            //}
            CboCliente.MaskBox.AutoCompleteCustomSource = textoAutocompletar;
        }

        private void CargarComboContactos(int IdCliente, string Nombre, long IdPropietario, Int16 IdEstado)
        {
            //Llena el combo con la lista de Targets
            CboContactos.Properties.Items.Clear();
            //Entidades.GlobalObject.ResultadoTransaccion res = LogicaNegocios.Clientes.clsTarget.ListarContactoporClienteUsuario(IdUsuario, IdCliente);
            IList<clsContacto> ListaContactos = LogicaNegocios.Clientes.clsContactos.ListarContactos(Nombre, IdCliente,
                                                                                                     IdPropietario,
                                                                                                     IdEstado);

            ComboBoxItemCollection coll = CboContactos.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in ListaContactos)
            {
                coll.Add(list);
            }

            CboContactos.SelectedIndex = 0;

            AutoCompleteStringCollection textoAutocompletar = new AutoCompleteStringCollection();
            textoAutocompletar = new AutoCompleteStringCollection();

            //TxtContacto.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //TxtContacto.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (var list in ListaContactos)
            {
                textoAutocompletar.Add(list.Nombre);
            }
            foreach (var list in ListaContactos)
            {
                textoAutocompletar.Add(list.Nombre);
            }
            //TxtContacto.MaskBox.AutoCompleteCustomSource = textoAutocompletar;

        }

        private void MenuGuardar_Click(object sender, EventArgs e)
        {
            Boolean Seleccion;
            int IdTipoActividad;
            long IdOportunidad;
            long IdActividad;
            Entidades.GlobalObject.ResultadoTransaccion res;

            //Valida Datos Obligatorios
            if (this.comboBoxTipoProducto.SelectedItem == null || comboBoxTipoProducto.SelectedIndex <= 0)
            {
                ctrldxError.SetError(this.comboBoxTipoProducto, "Debe Seleccionar un Tipo de Producto",
                                     ErrorType.Critical);
                return;
            }
            else
            {
                ctrldxError.SetError(this.comboBoxTipoProducto, "", ErrorType.None);
            }
            if (CboContactos.SelectedItem == null || CboContactos.SelectedIndex <= 0)
            {
                ctrldxError.SetError(this.CboContactos, "Debe Seleccionar un Contacto", ErrorType.Critical);
                return;
            }
            else
            {
                ctrldxError.SetError(this.CboContactos, "", ErrorType.None);
            }

            if (checkListBoxTiposAsunto.CheckedItems.Count == 0)
            {
                ctrldxError.SetError(checkListBoxTiposAsunto,
                                     "Debe Seleccionar el asunto o tema de la llamada telefónica", ErrorType.Critical);
                return;
            }
            else
            {
                ctrldxError.SetError(this.checkListBoxTiposAsunto, "", ErrorType.None);
            }

            if (this.DtFechaHora.DateTime == null || this.DtFechaHora.DateTime.ToString().Trim() == "")
            {
                ctrldxError.SetError(this.DtFechaHora, "Debe Seleccionar una fecha/hora", ErrorType.Critical);
                return;
            }
            else
            {
                ctrldxError.SetError(this.DtFechaHora, "", ErrorType.None);
            }

            if (this.TxtDescription.Text == null || this.TxtDescription.Text.Trim() == "")
            {
                ctrldxError.SetError(this.TxtDescription,
                                     "Debe Ingresar un descripción relacionada a la llamada telefónica",
                                     ErrorType.Critical);
                return;
            }
            else
            {
                ctrldxError.SetError(this.TxtDescription, "", ErrorType.None);
            }

            ClsLlamadaTelefonica ObjLlamada = LlenarEntidadLlamada();
            ClsObjetoPasoGrilla ObjPaso;

            //LK Temporal: debo cambiar esto y dejarlo en un parametro archivo o lo que sea
            IdTipoActividad = 1;
            CboCliente.Focus();

            if (ObjLlamada.Id == 0)
            {
                res =
                    LogicaNegocios.Ventas.Actividades.Llamadas_Telefonicas.ClsLlamataTelefonica.GuardaLlamadaTelefonica(
                        ObjLlamada);
            }
            else
            {
                res =
                    LogicaNegocios.Ventas.Actividades.Llamadas_Telefonicas.ClsLlamataTelefonica.
                        ModificarLlamadaTelefonica(ObjLlamada);
            }

            // GRABA LOS ASUNTOS O TEMAS RELACIONADOS A LA ACTIVIDAD
            if (res.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                IdActividad = ObjLlamada.Id;
                clsAsuntoTipoActividad ObjPaso2 = new clsAsuntoTipoActividad();

                for (int i = 0; i <= this.checkListBoxTiposAsunto.ItemCount - 1; i++)
                {
                    ObjPaso2 = (clsAsuntoTipoActividad)checkListBoxTiposAsunto.GetItemValue(i);
                    if (checkListBoxTiposAsunto.GetItemCheckState(i) == CheckState.Checked)
                    {
                        Entidades.GlobalObject.ResultadoTransaccion res2 =
                            LogicaNegocios.Ventas.Actividades.clsAsuntoTipoActividad.AsociarAsuntoActividad(
                                ObjPaso2.Id, IdActividad);
                    }
                    else
                    {
                        Entidades.GlobalObject.ResultadoTransaccion res2 =
                            LogicaNegocios.Ventas.Actividades.clsAsuntoTipoActividad.EliminarAsuntoActividad(
                                ObjPaso2.Id, IdActividad);
                    }
                }

                MessageBox.Show(res.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                NuevaLlamada();
            }
            else
            {
                MessageBox.Show(res.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmLlamadaTelefonica_Load(object sender, EventArgs e)
        {
            IdUsuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario.Id;

            repositoryItemComboBox1.Items.Clear();

            int IdCliente = 0;
            clsContacto ObjContacto = new clsContacto();
            long IdActividad;
            string EntradaSalida;

            ListarTiposActividad();

            if (ObjLlamadaTelefonica != null)
            {
                CargarComboTodosClientes(IdUsuario, "");
                CargarComboContactos(-1, "-1", -1, -1);
                this.DtFechaHora.DateTime = ObjLlamadaTelefonica.FechaHora;
                if (ObjLlamadaTelefonica.ObjUsuario.Id.Equals(Base.Usuario.UsuarioConectado.Usuario.Id))
                {
                    TxtDescription.Enabled = true;
                    TxtDescription.Text = ObjLlamadaTelefonica.Descripcion;
                }else
                    TxtDescription.Enabled = false;
                
                
                //Posicionar el cliente en el combo
                this.CboCliente.SelectedItem = ObjLlamadaTelefonica.ObjContacto.ClienteMaster;
                // Posicionar el contacto
                this.CboContactos.SelectedItem = ObjLlamadaTelefonica.ObjContacto;
                if (CboContactos.Text.Trim() != "" && CboContactos.SelectedIndex > 0)
                {
                    ObjContacto = (clsContacto)CboContactos.SelectedItem;
                    //CargarGrillaOportunidades(ObjContacto.ClienteMaster.Id);
                    if (ObjLlamadaTelefonica != null)
                    {
                        IdActividad = ObjLlamadaTelefonica.Id;
                        CargarGrillaOportunidadesActividad(IdActividad, 1);
                    }
                    CargarGrillaLlamadasRecientes(ObjContacto.ClienteMaster.Id);
                }
                if (ObjLlamadaTelefonica.EntradaSalida == "S")
                {
                    this.radioButtonSaliente.Checked = true;
                }
                else
                {
                    this.radioButtonEntrante.Checked = true;
                }
                CargarComboAsuntosTipo(2, ObjLlamadaTelefonica.EntradaSalida);
                CargarListAsuntosActividad(ObjLlamadaTelefonica.Id);
                if (ObjLlamadaTelefonica.Importancia == "A")
                {
                    this.checkBoxImportancia.CheckState = CheckState.Checked;
                }
                else
                {
                    this.checkBoxImportancia.CheckState = CheckState.Unchecked;
                }
                CargarComboTiposProductos("", "");
                this.comboBoxTipoProducto.SelectedItem = ObjLlamadaTelefonica.ObjTipoProducto;


                IList<clsClienteFollowUp> followups =
                    clsClientesMaster.ObtenerFollowUpActivosClientePorLLamada(ObjLlamadaTelefonica.Id32);
                ObjLlamadaTelefonica.FollowUps = followups;
                gridFollowUp.DataSource = ObjLlamadaTelefonica.FollowUps;
            }
            else
            {
                this.DtFechaHora.DateTime = DateTime.Now;
                CargarComboClientesActivos(IdUsuario, "");
                CargarComboContactos(-1, "-1", -1, 1);
                if (this.radioButtonSaliente.Checked == true)
                {
                    EntradaSalida = "S";
                }
                else
                {
                    EntradaSalida = "E";
                }
                CargarComboAsuntosTipo(2, EntradaSalida);
                CargarComboTiposProductos("", "S");
            }
            LimpiaFormFollowUp();
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            ObjLlamadaTelefonica = null;
            Instancia = null;
            this.Close();
        }

        private void NuevaLlamada()
        {

            this.radioButtonSaliente.Checked = true;
            this.checkBoxImportancia.CheckState = CheckState.Unchecked;
            this.CboCliente.SelectedIndex = 0;
            this.CboContactos.SelectedIndex = 0;
            this.TxtDescription.Text = "";
            this.gridOportunidadesCliente.DataSource = null;
            CargarComboAsuntosTipo(2, "S");
            CargarComboTiposProductos("", "S");
            gridActividades.DataSource = null;
            gridFollowUp.DataSource = null;
            cboActividadFollowUp.SelectedIndex = 0;
            txtDescripcionFollowUp.Text = String.Empty;
            dtFechaFollowUp.DateTime = DateTime.Now;
        }

        public FrmLlamadaTelefonica()
        {
            InitializeComponent();
        }

        private ClsLlamadaTelefonica LlenarEntidadLlamada()
        {
            string TextoCliente = "";
            string TextoContacto = "";
            string TextoTipoProducto = "";

            ClsLlamadaTelefonica ObjLlamada = new ClsLlamadaTelefonica();
            ObjLlamada.ObjVendedor = new clsUsuario();
            ObjLlamada.ObjUsuario = new clsUsuario();
            ObjLlamada.ObjCustomer = new clsUsuario();
            ObjLlamada.ObjTipoProducto = new clsTipoProducto();

            if (ObjLlamadaTelefonica != null)
            {
                ObjLlamada.Id = ObjLlamadaTelefonica.Id;
                ObjLlamada.Codigo = ObjLlamadaTelefonica.Codigo;
            }
            else
            {
                ObjLlamada.Id = 0;
                ObjLlamada.Codigo = "CodPrueba";
            }

            ObjLlamada.Descripcion = this.TxtDescription.Text;
            ObjLlamada.FechaHora = this.DtFechaHora.DateTime;
            //TextoContacto = this.CboContactos.Text;  
            //Utils.Utils.SincronizaComboGlosa(CboContactos, TextoContacto);
            ObjLlamada.ObjContacto = (clsContacto)CboContactos.SelectedItem;
            TextoTipoProducto = this.comboBoxTipoProducto.Text;
            if (TextoTipoProducto.Trim() != "" && comboBoxTipoProducto.SelectedIndex > 0)
            {
                //Utils.Utils.SincronizaComboGlosa(this.comboBoxTipoProducto, TextoTipoProducto);
                ObjLlamada.ObjTipoProducto = (clsTipoProducto)comboBoxTipoProducto.SelectedItem;
            }
            else
            {
                ObjLlamada.ObjTipoProducto.Id = -1;
            }
            ObjLlamada.ObjVendedor.Id = 1;
            ObjLlamada.ObjUsuario.Id = IdUsuario;
            ObjLlamada.ObjCustomer.Id = 1;

            if (this.radioButtonEntrante.Checked == true)
            {
                ObjLlamada.EntradaSalida = "E";
            }
            else
            {
                ObjLlamada.EntradaSalida = "S";
            }

            if ((this.checkBoxImportancia.CheckState == CheckState.Checked))
            {
                ObjLlamada.Importancia = "A";
            }
            else
            {
                ObjLlamada.Importancia = "B";
            }


            ObjLlamada.FollowUps = ObtieneFollowUpsDesdeGrilla();

            foreach (var followup in ObjLlamada.FollowUps)
            {
                followup.IdInformeVisita = followup.IdTarget = -1;
                followup.IdLlamadaTelefonica = ObjLlamada.Id;
                followup.FechaCreacion = DateTime.Now;
                followup.Usuario = Base.Usuario.UsuarioConectado.Usuario;
                followup.Cliente = ObjLlamada.ObjContacto.ClienteMaster;
            }
            return ObjLlamada;
        }

        private void MenuNuevo_Click(object sender, EventArgs e)
        {
            NuevaLlamada();
        }

        private void CboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            MenuBitacora.Enabled = CboCliente.SelectedIndex != 0;
        }

        private void CboCliente_Leave(object sender, EventArgs e)
        {
            clsClienteMaster ObjClienteMaster = new clsClienteMaster(true);
            int IdCliente = -1;

            if (this.CboCliente.Text.Trim() != "" && this.CboCliente.SelectedIndex > 0)
            {
                CboContactos.Properties.Items.Clear();
                if (CboCliente.SelectedIndex >= 1)
                {
                    ObjClienteMaster = (clsClienteMaster)CboCliente.SelectedItem;
                    IdCliente = (int)ObjClienteMaster.Id;

                }
            }
            CargarComboContactos(IdCliente, "-1", -1, -1);
            // Posicionar el contacto
            if (ObjLlamadaTelefonica != null)
            {
                this.CboContactos.SelectedItem = ObjLlamadaTelefonica.ObjContacto;
            }
        }

        private void CboCliente_Enter(object sender, EventArgs e)
        {
            this.CboCliente.SelectionStart = 0;
            this.CboCliente.SelectionLength = this.CboCliente.Text.Length;

        }

        private void CboContactos_Enter(object sender, EventArgs e) { }

        private void TxtDescription_Enter(object sender, EventArgs e)
        {
            this.TxtDescription.SelectionStart = 0;
            this.TxtDescription.SelectionLength = this.TxtDescription.Text.Length;

        }

        private void TxtDescription_MouseEnter(object sender, EventArgs e)
        {
            this.TxtDescription.SelectionStart = 0;
            this.TxtDescription.SelectionLength = this.TxtDescription.Text.Length;
        }

        private void MenuCrearOportunidad_Click(object sender, EventArgs e)
        {
            Ventas.Oportunidades.FrmOportunidad form = Ventas.Oportunidades.FrmOportunidad.Instancia;
            form.Show();
        }

        private void sButton_Click(object sender, EventArgs e) { }

        private void CboContactos_Leave(object sender, EventArgs e)
        {
            clsContacto ObjContacto = new clsContacto();
            long IdActividad;

            if (CboContactos.Text.Trim() != "" && CboContactos.SelectedIndex > 0)
            {
                ObjContacto = (clsContacto)CboContactos.SelectedItem;
                //CargarGrillaOportunidades(ObjContacto.ClienteMaster.Id);
                if (ObjLlamadaTelefonica != null)
                {
                    IdActividad = ObjLlamadaTelefonica.Id;
                    //CargarGrillaOportunidadesActividad(IdActividad, 1);
                }
                CargarGrillaLlamadasRecientes(ObjContacto.ClienteMaster.Id);
            }
        }

        private void gridOportunidadesCliente_Click(object sender, EventArgs e) { }

        private void gridView1_CustomUnboundColumnData(object sender,
                                                       DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "gridSeleccion" && e.IsSetData)
            {
                //gridView1.SetRowCellValue(e.ListSourceRowIndex, gridView1.Columns.ColumnByFieldName("gridSeleccion"), e.Value);
                e.Value = true;
            }
            if (e.Column.FieldName == "gridSeleccion" && e.IsGetData)
            {
                //gridView1.SetRowCellValue(e.ListSourceRowIndex, gridView1.Columns.ColumnByFieldName("gridSeleccion"), e.Value);
                e.Value = true;
            }
        }

        private void gridView1_CellValueChanged(object sender,
                                                DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e) { }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e) { }

        private void gridView1_Click(object sender, EventArgs e) { }

        private void FrmLlamadaTelefonica_Layout(object sender, LayoutEventArgs e) { }

        private void FrmLlamadaTelefonica_Activated(object sender, EventArgs e) { }

        private void CboCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SelectNextControl(this.CboCliente, true, true, true, true);
            }
        }

        private void CboContactos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SelectNextControl(this.CboContactos, true, true, true, true);
            }
        }

        private void DtFechaHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SelectNextControl(this.DtFechaHora, true, true, true, true);
            }
        }

        private void TxtDescription_KeyPress(object sender, KeyPressEventArgs e) { }

        private void CboTema_SelectedIndexChanged(object sender, EventArgs e) { }

        private void DtFechaHora_EditValueChanged(object sender, EventArgs e) { }

        private void TxtDescription_EditValueChanged(object sender, EventArgs e) { }

        private void grpOportunidades_Enter(object sender, EventArgs e) { }

        private void radioButtonEntrante_CheckedChanged(object sender, EventArgs e)
        {
            string EntradaSalida;
            if (this.radioButtonSaliente.Checked == true)
            {
                EntradaSalida = "S";
            }
            else
            {
                EntradaSalida = "E";
            }
            CargarComboAsuntosTipo(2, EntradaSalida);
        }

        private void radioButtonSaliente_CheckedChanged(object sender, EventArgs e)
        {
            string EntradaSalida;
            if (this.radioButtonSaliente.Checked == true)
            {
                EntradaSalida = "S";
            }
            else
            {
                EntradaSalida = "E";
            }
            CargarComboAsuntosTipo(2, EntradaSalida);
        }

        private void checkBoxImportancia_CheckedChanged(object sender, EventArgs e) { }

        private void comboBoxTipoProducto_SelectedIndexChanged(object sender, EventArgs e) { }

        private void gridActividades_Click(object sender, EventArgs e) { }

        private void MenuBitacora_Click(object sender, EventArgs e)
        {
            Clientes.frmClienteFollowUp form = Clientes.frmClienteFollowUp.Instancia;
            var cliente = _form.CboCliente.SelectedItem as clsClienteMaster;
            form.Cliente = cliente;
            form.ShowDialog();
        }

        private void ListarTiposActividad()
        {
            var Tipos = LogicaNegocios.Ventas.Actividades.clsAsuntoTipoActividad.ListarTipoActividad();

            ComboBoxItemCollection coll = cboActividadFollowUp.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in Tipos)
            {
                coll.Add(list);
            }
            cboActividadFollowUp.SelectedIndex = 0;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var foo = gridFollowUp.DataSource as IList<clsClienteFollowUp>;
            if (foo != null)
            {
                foo.Add(new clsClienteFollowUp());
                gridFollowUp.DataSource = foo;
                gridFollowUp.Focus();
                gridView3.FocusedRowHandle = gridView3.RowCount - 1;
                gridView3.UpdateCurrentRow();
                gridView3.RefreshData();
            }
        }

        private IList<clsClienteFollowUp> ObtieneFollowUpsDesdeGrilla()
        {
            var list = gridFollowUp.DataSource as List<clsClienteFollowUp>;
            var retorno = new List<clsClienteFollowUp>();
            if (list != null)
                retorno = list.FindAll(foo => foo.FechaFollowUp.HasValue);
            return retorno;
        }

        private void gridFollowUp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var grid = sender as GridControl;
                var followUp = grid.FocusedView.GetRow(gridView3.FocusedRowHandle) as clsClienteFollowUp;
                if (followUp.FechaFollowUp.Value.Date <= DateTime.Now.Date)
                {
                    MessageBox.Show("No se puede Eliminar un follow up ya vencido", "Eliminacion", MessageBoxButtons.OK);
                    return;
                }

                if (MessageBox.Show("¿Esta seguro de eliminar?", "Confirmacion", MessageBoxButtons.YesNo) !=
                    DialogResult.Yes)
                    return;
                gridView3.DeleteRow(gridView3.FocusedRowHandle);
            }
        }

        private void BtnAsignarFollowUp_Click(object sender, EventArgs e)
        {
            if (ValidarFollowup())
            {
                var followup = new clsClienteFollowUp
                {
                    FechaFollowUp = dtFechaFollowUp.DateTime,
                    Descripcion = txtDescripcionFollowUp.Text,
                    TipoActividad =
                        (clsTipoActividad)cboActividadFollowUp.SelectedItem
                };
                AgregarFollowUpGrilla(followup);
                LimpiaFormFollowUp();
            }
        }

        private void LimpiaFormFollowUp()
        {
            dtFechaFollowUp.DateTime = DateTime.Now;
            txtDescripcionFollowUp.Text = String.Empty;
            cboActividadFollowUp.SelectedIndex = 0;
        }

        private void AgregarFollowUpGrilla(clsClienteFollowUp followup)
        {
            var list = ObtieneFollowUpsDesdeGrilla();
            list.Add(followup);
            gridFollowUp.DataSource = list;
        }

        private Boolean ValidarFollowup()
        {
            var retorno = true;
            if (cboActividadFollowUp.SelectedItem == null || cboActividadFollowUp.SelectedIndex <= 0)
            {
                ctrldxError.SetError(cboActividadFollowUp, "Debe ingresar la actividad", ErrorType.Critical);
                retorno = false;
            }
            else
            {
                ctrldxError.SetError(cboActividadFollowUp, "", ErrorType.None);
            }
            if (String.IsNullOrEmpty(dtFechaFollowUp.DateTime.ToString()))
            {
                ctrldxError.SetError(dtFechaFollowUp, "Debe ingresar la fecha", ErrorType.Critical);
                retorno = false;
            }
            else
            {
                ctrldxError.SetError(dtFechaFollowUp, "", ErrorType.None);
            }

            if (String.IsNullOrEmpty(txtDescripcionFollowUp.Text.Trim()))
            {
                ctrldxError.SetError(txtDescripcionFollowUp, "Debe ingresar la descripcion", ErrorType.Critical);
                retorno = false;
            }
            else
            {
                ctrldxError.SetError(txtDescripcionFollowUp, "", ErrorType.None);
            }
            return retorno;
        }

        private void BtnBorrarFollowUp_Click(object sender, EventArgs e)
        {
            foreach (var i in gridView3.GetSelectedRows())
            {
                var followUp = gridView3.GetRow(i) as clsClienteFollowUp;
                if (followUp.FechaFollowUp.Value.Date < DateTime.Now.Date)
                {
                    MessageBox.Show("No se puede Eliminar un follow up ya vencido", "Eliminacion", MessageBoxButtons.OK);
                }
                else
                {
                    if (MessageBox.Show("¿Esta seguro de eliminar?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        gridView3.DeleteRow(i);
                }
            }
        }
    }

    public class ClsObjetoPasoGrilla
    {
        public Boolean MarcaOportunidad { get; set; }
        public clsOportunidad ObjOportunidadPaso { get; set; }
    }

}
