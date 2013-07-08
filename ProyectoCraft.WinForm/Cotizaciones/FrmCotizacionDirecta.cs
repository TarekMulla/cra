using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraEditors.DXErrorProvider;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.LogicaNegocios.Clientes;
using ProyectoCraft.LogicaNegocios.Cotizaciones;
using ProyectoCraft.LogicaNegocios.Cotizaciones.Directa;
using ProyectoCraft.LogicaNegocios.Mantenedores;
using ProyectoCraft.LogicaNegocios.Parametros;
using clsTarget = ProyectoCraft.Entidades.Clientes.Target.clsTarget;

namespace SCCMultimodal.Cotizaciones {
    public partial class FrmCotizacionDirecta : Form {
        private List<clsClienteMaster> _clientes = new List<clsClienteMaster>();
        private List<clsTarget> _targets = new List<clsTarget>();
        private List<Moneda> _monedas = new List<Moneda>();
        private List<ClsNaviera> _navieras = new List<ClsNaviera>();
        private List<Concepto> _conceptos = new List<Concepto>();
        private List<Unidad> _unidades = new List<Unidad>();
        public CotizacionDirecta CotizacionDirecta = new CotizacionDirecta();

        public String mode = "Nueva";

        private void AddDataBindings() {
            bindingSource1.DataSource = CotizacionDirecta.Opciones;
            CboNaviera.DataBindings.Add("SelectedItem", bindingSource1, "Naviera");
            TxtTiempoTransito.DataBindings.Add("Text", bindingSource1, "TiempoTransito");
            txtFechaValidezIni.DataBindings.Add("Text", bindingSource1, "FechaValidezInicio");
            txtFechaValidezFin.DataBindings.Add("Text", bindingSource1, "FechaValidezFin");

            GridOpcionDetalle.DataBindings.Add("DataSource", bindingSource1, "Detalles");


        }


        public void BeginForm() {
            _clientes = clsClientesMaster.ListarClienteMaster
                            (String.Empty, Enums.TipoPersona.Comercial, Enums.Estado.Todos, true) as
                        List<clsClienteMaster>;
            _targets = (List<clsTarget>)ProyectoCraft.LogicaNegocios.Clientes.clsTarget.ListarTarget(String.Empty, 0, 0);
            _monedas = ClsMonedas.ObtieneTodasLasMonedas().ObjetoTransaccion as List<Moneda>;
            _navieras = (List<ClsNaviera>)ClsNavieras.ListarNavieras(true);
            _conceptos = ClsConceptos.ObtieneTodosLosConceptos().ObjetoTransaccion as List<Concepto>;
            _unidades = ClsUnidad.ObtieneTodasLasUnidades().ObjetoTransaccion as List<Unidad>;


            CboCliente.Properties.Items.Clear();
            foreach (var c in _clientes)
                CboCliente.Properties.Items.Add(c);

            CboNaviera.Properties.Items.Clear();
            CboNaviera.Properties.Items.Add(new ClsNaviera());
            foreach (var n in _navieras)
                CboNaviera.Properties.Items.Add(n);

            repositoryItemComboBox1.Items.Clear();
            if (_conceptos != null)
                foreach (var concepto in _conceptos)
                    repositoryItemComboBox1.Items.Add(concepto);

            repositoryItemComboBox23.Items.Clear();
            if (_unidades != null)
                foreach (var u in _unidades)
                    repositoryItemComboBox23.Items.Add(u);

            repositoryItemComboBox2.Items.Clear();
            if (_monedas != null)
                foreach (var m in _monedas)
                    repositoryItemComboBox2.Items.Add(m);


            if (mode == "Nueva")
                NuevaCotizacion();
            else
                CargarCotizacionDirecta();

            AddDataBindings();

            if ((CotizacionDirecta.Opciones != null && CotizacionDirecta.Opciones.Count > 0))
                Cargaopcion(CotizacionDirecta.Opciones[0]);
        }

        private void CargarCotizacionDirecta() {
            CotizacionDirecta = ClsCotizacionDirecta.ObtieneCotizacionDirecta(CotizacionDirecta.Id32).ObjetoTransaccion as CotizacionDirecta;
            txtEjecutivo.Text = CotizacionDirecta.Usuario.NombreCompleto;
            TxtFecha.DateTime = CotizacionDirecta.FechaSolicitud;
            CboCliente.SelectedItem = CotizacionDirecta.Cliente;

            txtCommodity.Text = CotizacionDirecta.Commodity;
            TxtGastosLocales.Text = CotizacionDirecta.GastosLocales.ToString();
            TxtObservaciones.Text = CotizacionDirecta.Observaciones;
            LblEstado.Text = CotizacionDirecta.EstadoDescripcion;
            if (CotizacionDirecta.Estado.Id32 == (Int32)Enums.EstadosCotizacion.Cerrado ||
                CotizacionDirecta.Estado.Id32 == (Int32)Enums.EstadosCotizacion.PerdidoOtros ||
                CotizacionDirecta.Estado.Id32 == (Int32)Enums.EstadosCotizacion.PerdidoTarifa ||
                CotizacionDirecta.Estado.Id32 == (Int32)Enums.EstadosCotizacion.Enviadacliente) {
                toolStripButton1.Enabled = false;
                toolStripButton1.ToolTipText = "Imposible modificar cotización en el Estado actual";
            }
        }

        private void NuevaCotizacion() {
            TxtFecha.DateTime = DateTime.Now;
            txtEjecutivo.Text = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario.NombreCompleto;
            LblEstado.Visible = labelControl11.Visible = false;
            LblGastosLocales.Visible = true;
            LblGastosLocales.Text = "Sin Gastos Locales";
            ActivarDesactivarDetalle(false);

        }

        public FrmCotizacionDirecta() {
            InitializeComponent();

        }

        private static FrmCotizacionDirecta _form = null;
        public static FrmCotizacionDirecta Instancia {
            get { return _form ?? (_form = new FrmCotizacionDirecta()); }
            set {
                _form = value;
            }
        }

        private void SolicitarTarifa_Load(object sender, EventArgs e) {
            TxtGastosLocales.Properties.Mask.Culture = new CultureInfo("es-CL");
            BeginForm();
        }

        private void MenuSalir_Click(object sender, EventArgs e) {
            Instancia = null;
            Close();
        }

        private void FrmCotizacionDirecta_FormClosed(object sender, FormClosedEventArgs e) {
            Instancia = null;
        }

        private void sButtonEliminarUnidad_Click(object sender, EventArgs e) {
            gridView1.DeleteSelectedRows();
        }

        private void TxtGastosLocales_EditValueChanged(object sender, EventArgs e) {
            if (!String.IsNullOrEmpty(TxtGastosLocales.Text)) {
                if (Convert.ToDecimal(TxtGastosLocales.EditValue) == 0)
                    LblGastosLocales.Text = "Sin Gastos Locales";
                else
                    LblGastosLocales.Text = "+ IVA";

            } else {
                LblGastosLocales.Text = String.Empty;
            }
        }

        private void CboNaviera_SelectedIndexChanged(object sender, EventArgs e) {
            var naviera = CboNaviera.SelectedItem as ClsNaviera;
            var puertos = ClsPuertos.ObtienePuertosPorNaviera(naviera).ObjetoTransaccion as List<Puerto>;

            ListPod.Items.Clear();
            ListPol.Items.Clear();
            foreach (var puerto in puertos) {
                ListPod.Items.Add(puerto);
                ListPol.Items.Add(puerto);
            }
            ListPodSeleccionado.Items.Clear();
            ListPolSeleccionado.Items.Clear();
        }

        private void AddPol_Click(object sender, EventArgs e) {
            var seleccionados = ListPol.SelectedItems;
            var list = new List<int>();
            foreach (var seleccionado in seleccionados) {
                ListPolSeleccionado.Items.Add(seleccionado);
                list.Add(ListPol.Items.IndexOf(seleccionado));

                var op = bindingNavigator1.BindingSource.Current as Opcion;
                op.Pol.Add(seleccionado as Puerto); //Agregamos el puerto al objeto en memoria

            }
            list.Reverse();
            foreach (var i in list)
                ListPol.Items.RemoveAt(i);
            ListPodSeleccionado.Refresh();
        }

        private void RemovePol_Click(object sender, EventArgs e) {
            var seleccionados = ListPolSeleccionado.SelectedItems;
            var list = new List<int>();
            foreach (var seleccionado in seleccionados) {
                ListPol.Items.Add(seleccionado);
                list.Add(ListPolSeleccionado.Items.IndexOf(seleccionado));


                var op = bindingNavigator1.BindingSource.Current as Opcion;
                op.Pol.Remove(seleccionado as Puerto); //Quitamos el puerto al objeto en memoria
            }
            list.Reverse();
            foreach (var i in list)
                ListPolSeleccionado.Items.RemoveAt(i);
        }

        private void AddPod_Click(object sender, EventArgs e) {
            var seleccionados = ListPod.SelectedItems;
            var list = new List<int>();
            foreach (var seleccionado in seleccionados) {
                ListPodSeleccionado.Items.Add(seleccionado);
                list.Add(ListPod.Items.IndexOf(seleccionado));

                var op = bindingNavigator1.BindingSource.Current as Opcion;
                op.Pod.Add(seleccionado as Puerto); //Agregamos el puerto al objeto en memoria
            }
            list.Reverse();
            foreach (var i in list)
                ListPod.Items.RemoveAt(i);
        }

        private void RemovePod_Click(object sender, EventArgs e) {
            var seleccionados = ListPodSeleccionado.SelectedItems;
            var list = new List<int>();
            foreach (var seleccionado in seleccionados) {
                ListPod.Items.Add(seleccionado);
                list.Add(ListPodSeleccionado.Items.IndexOf(seleccionado));

                var op = bindingNavigator1.BindingSource.Current as Opcion;
                op.Pol.Remove(seleccionado as Puerto); //Quitamos el puerto al objeto en memoria
            }
            list.Reverse();
            foreach (var i in list)
                ListPodSeleccionado.Items.RemoveAt(i);
        }

        private void AgregarDetalle_Click(object sender, EventArgs e) {
            var list = GridOpcionDetalle.DataSource as List<DetalleOpcion>;
            list.Add(new DetalleOpcion());

            GridOpcionDetalle.DataSource = list;
            GridOpcionDetalle.RefreshDataSource();
        }


        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e) {
            var op = bindingNavigator1.BindingSource.Current as Opcion;
            Cargaopcion(op);

        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e) {
            var op = bindingNavigator1.BindingSource.Current as Opcion;
            Cargaopcion(op);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e) {
            //ActiveControl = CboNaviera;
            if (!CboNaviera.Enabled)
                ActivarDesactivarDetalle(true);
            CboNaviera.SelectedIndex = 0;

        }

        public void Cargaopcion(Opcion op) {
            ListPodSeleccionado.Items.Clear();
            foreach (var puerto in op.Pod)
                ListPodSeleccionado.Items.Add(puerto);

            ListPolSeleccionado.Items.Clear();
            foreach (var puerto in op.Pol)
                ListPolSeleccionado.Items.Add(puerto);

            GridOpcionDetalle.DataSource = op.Detalles;
            GridOpcionDetalle.RefreshDataSource();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e) {
            var op = bindingNavigator1.BindingSource.Current as Opcion;
            Cargaopcion(op);
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e) {
            var op = bindingNavigator1.BindingSource.Current as Opcion;
            Cargaopcion(op);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e) {
            var foo = bindingNavigator1.BindingSource.Current;
            if (foo == null)
                ActivarDesactivarDetalle(false);
        }

        private void ActivarDesactivarDetalle(Boolean enabled) {
            ListPol.Items.Clear();
            ListPolSeleccionado.Items.Clear();
            ListPod.Items.Clear();
            ListPolSeleccionado.Items.Clear();
            ListPod.Enabled = ListPodSeleccionado.Enabled = enabled;
            ListPol.Enabled = ListPolSeleccionado.Enabled = enabled;
            CboNaviera.SelectedIndex = 0;
            CboNaviera.Enabled = enabled;
            txtFechaValidezIni.Enabled = txtFechaValidezFin.Enabled = enabled;
            gridView1.OptionsBehavior.Editable = enabled;
            EliminarDetalle.Enabled = AgregarDetalle.Enabled = enabled;
            TxtTiempoTransito.Enabled = enabled;
            AddPod.Enabled = RemovePod.Enabled = enabled;
            AddPol.Enabled = RemovePol.Enabled = enabled;
        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            ActiveControl = txtEjecutivo;
            if (ElFormularioTieneErrores())
                return;

            CargaDatosDelFormulario();
            if (CotizacionDirecta.IsNew)
                CrearCotizacion();
            else
                ActualizarCotizacion();
            Instancia = null;
            Close();
        }

        private void ActualizarCotizacion() {
            var resultado = ClsCotizacionDirecta.Modificar(CotizacionDirecta);
            MessageBox.Show(resultado.Descripcion);
        }

        private void CrearCotizacion() {
            var resultado = ClsCotizacionDirecta.Crear(CotizacionDirecta);
            MessageBox.Show(resultado.Descripcion);
        }

        private void CargaDatosDelFormulario() {
            CotizacionDirecta.Producto = "FCL Importacion";

            var xmldoc = new XmlDocument();
            xmldoc.Load(Path.Combine(Application.StartupPath, @"Cotizaciones\CotizacionSetting.xml"));
            CotizacionDirecta.ObservacionesFijas = xmldoc.SelectSingleNode("/setting/cotizacionDirecta/observacionFija").InnerText;

            var list = (List<clsIncoTerm>)clsParametrosClientes.ListarIncoTerms(true);
            var incoTerm = list.Find(foo => foo.Codigo.ToUpper().Equals("FOB"));
            if (CotizacionDirecta.IsNew) {
                CotizacionDirecta.FechaSolicitud = TxtFecha.DateTime;
                CotizacionDirecta.Usuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario;
            }
            CotizacionDirecta.IncoTerm = incoTerm;
            CotizacionDirecta.Cliente = CboCliente.SelectedItem as clsClienteMaster;
            CotizacionDirecta.NombreCliente = CotizacionDirecta.Cliente.ToString();
            CotizacionDirecta.Commodity = txtCommodity.Text;
            if (!String.IsNullOrEmpty(TxtGastosLocales.Text))
                CotizacionDirecta.GastosLocales = Convert.ToDecimal(TxtGastosLocales.Text);
            CotizacionDirecta.Observaciones = TxtObservaciones.Text;

            foreach (var o in CotizacionDirecta.Opciones) {
                if (o.IsNew) {
                    o.Usuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario;
                }
            }
        }

        public Boolean ElFormularioTieneErrores() {
            ActiveControl = txtEjecutivo;
            var errorTexto = String.Empty;
            ctrldxError.ClearErrors();

            if (CboCliente.SelectedIndex == -1)
                ctrldxError.SetError(CboCliente, "Debe seleccionar un cliente", ErrorType.Critical);
            if (String.IsNullOrEmpty(txtCommodity.Text))
                ctrldxError.SetError(txtCommodity, "Debe ingresar Commodity", ErrorType.Critical);
            if (String.IsNullOrEmpty(TxtGastosLocales.Text))
                ctrldxError.SetError(TxtGastosLocales, "Debe ingresar los gastos locales", ErrorType.Critical);
            if (String.IsNullOrEmpty(TxtObservaciones.Text))
                ctrldxError.SetError(TxtObservaciones, "Debe ingresar las observaciones", ErrorType.Critical);
            if (String.IsNullOrEmpty(TxtObservaciones.Text))
                ctrldxError.SetError(TxtObservaciones, "Debe ingresar las observaciones", ErrorType.Critical);

            if (CotizacionDirecta.Opciones.Count == 0)
                ctrldxError.SetError(CboNaviera, "Debe ingresar al menos una opcion", ErrorType.Critical);

            bindingNavigator1.BindingSource.MoveFirst();
            var encontroErrorOpcion = false;
            for (var i = 0; i < CotizacionDirecta.Opciones.Count; i++) {

                var o = CotizacionDirecta.Opciones[i];
                if (o.Naviera == null) {
                    ctrldxError.SetError(CboNaviera, "Debe ingresar una naviera", ErrorType.Critical);
                    encontroErrorOpcion = true;
                }
                if (o.Pol.Count == 0) {
                    ctrldxError.SetError(ListPolSeleccionado, "Debe seleccionar al menos un POL", ErrorType.Critical);
                    errorTexto += "Debe seleccionar al menos un POL" + Environment.NewLine;
                    encontroErrorOpcion = true;
                }

                if (o.Pod.Count == 0) {
                    ctrldxError.SetError(ListPod, "Debe seleccionar al menos un POD", ErrorType.Critical);
                    errorTexto += "Debe seleccionar al menos un Pod" + Environment.NewLine;
                    encontroErrorOpcion = true;
                }

                if (String.IsNullOrEmpty(o.TiempoTransito)) {
                    ctrldxError.SetError(TxtTiempoTransito, "Debe ingresar Tiempo en Transito", ErrorType.Critical);
                    encontroErrorOpcion = true;
                }
                if (o.Detalles.Count == 0) {
                    ctrldxError.SetError(new Control(), "Debe ingresar al menos un detalle de la cotizacion", ErrorType.Critical);
                    errorTexto += "Debe ingresar al menos un detalle de la cotizacion" + Environment.NewLine;
                    encontroErrorOpcion = true;
                }

                if (o.FechaValidezInicio == DateTime.MinValue) {
                    ctrldxError.SetError(txtFechaValidezIni, "La fecha no es valida", ErrorType.Critical);
                    encontroErrorOpcion = true;
                }

                if (o.FechaValidezFin == DateTime.MinValue) {
                    ctrldxError.SetError(txtFechaValidezFin, "La fecha no es valida", ErrorType.Critical);
                    encontroErrorOpcion = true;
                }

                if (o.FechaValidezFin < o.FechaValidezInicio) {
                    ctrldxError.SetError(txtFechaValidezFin, "La fecha de fin no puede ser menor a la de inicio", ErrorType.Critical);
                    encontroErrorOpcion = true;
                }

                if (!String.IsNullOrEmpty(errorTexto))
                    MessageBox.Show("Se han encontrado los siguientes problemas: " + Environment.NewLine + errorTexto,
                                    "validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (encontroErrorOpcion)
                    return true;
                bindingNavigator1.BindingSource.MoveNext();
            }
            return ctrldxError.HasErrors;
        }
    }
}

