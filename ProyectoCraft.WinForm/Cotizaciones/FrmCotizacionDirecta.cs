using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using DevExpress.Utils;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.LogicaNegocios.Clientes;
using ProyectoCraft.LogicaNegocios.Cotizaciones;
using ProyectoCraft.LogicaNegocios.Cotizaciones.Directa;
using ProyectoCraft.LogicaNegocios.Mantenedores;
using ProyectoCraft.LogicaNegocios.Parametros;


namespace SCCMultimodal.Cotizaciones {
    public partial class FrmCotizacionDirecta : Form {
        private List<clsClienteMaster> _clientes = new List<clsClienteMaster>();
        private List<Moneda> _monedas = new List<Moneda>();
        private List<ClsNaviera> _navieras = new List<ClsNaviera>();
        private List<Concepto> _conceptos = new List<Concepto>();
        private List<Unidad> _unidades = new List<Unidad>();
        public CotizacionDirecta CotizacionDirecta = new CotizacionDirecta();
        private List<TiposServicio> _tiposServicios;
        private List<TiposVia> _tiposVias;

        public String mode = "Nueva";

        private void AddDataBindings() {
            bindingSource1.DataSource = CotizacionDirecta.Opciones;
            CboNaviera.DataBindings.Clear();
            cboServicio.DataBindings.Clear();
            cboVia.DataBindings.Clear();
            TxtTiempoTransito.DataBindings.Clear();
            txtFechaValidezIni.DataBindings.Clear();
            txtFechaValidezIni.DataBindings.Clear();
            txtFechaValidezIni.DataBindings.Clear();
            txtFechaValidezFin.DataBindings.Clear();
            txtFechaValidezFin.DataBindings.Clear();
            txtFechaValidezFin.DataBindings.Clear();
            GridOpcionDetalle.DataBindings.Clear();

            CboNaviera.DataBindings.Add("SelectedItem", bindingSource1, "Naviera");
            cboServicio.DataBindings.Add("SelectedItem", bindingSource1, "TiposServicio");
            cboVia.DataBindings.Add("SelectedItem", bindingSource1, "TipoVia");

            TxtTiempoTransito.DataBindings.Add("Text", bindingSource1, "TiempoTransito");

            txtFechaValidezIni.DataBindings.Add("Text", bindingSource1, "FechaValidezInicio");
            txtFechaValidezIni.DataBindings.Add("DateTime", bindingSource1, "FechaValidezInicio");
            txtFechaValidezIni.DataBindings.Add("EditValue", bindingSource1, "FechaValidezInicio");
            txtFechaValidezFin.DataBindings.Add("Text", bindingSource1, "FechaValidezFin");
            txtFechaValidezFin.DataBindings.Add("DateTime", bindingSource1, "FechaValidezFin");
            txtFechaValidezFin.DataBindings.Add("EditValue", bindingSource1, "FechaValidezFin");
            GridOpcionDetalle.DataBindings.Add("DataSource", bindingSource1, "Detalles");
        }


        public void BeginForm() {

            CboNaviera.Properties.AutoComplete = true;
            _clientes = clsClientesMaster.ListarCuentasYTarget(ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario.Id32);
            _clientes.Sort((foo, bar) => foo.ToString().CompareTo(bar.ToString()));
            _monedas = ClsMonedas.ObtieneTodasLasMonedas().ObjetoTransaccion as List<Moneda>;
            _navieras = (List<ClsNaviera>)ClsNavieras.ListarNavieras(true);
            _conceptos = ClsConceptos.ObtieneTodosLosConceptos().ObjetoTransaccion as List<Concepto>;
            _unidades = ClsUnidad.ObtieneTodasLasUnidades().ObjetoTransaccion as List<Unidad>;
            _tiposServicios = ClsTipoServicio.ObtieneTiposServicios().ObjetoTransaccion as List<TiposServicio>;

            _tiposVias = ClsTipoVia.ObtieneTiposVias().ObjetoTransaccion as List<TiposVia>;
            _tiposVias.Add(new TiposVia { Nombre = "" });
            _tiposVias.Sort((foo, bar) => foo.ToString().CompareTo(bar.ToString()));

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

            cboServicio.Properties.Items.Clear();

            cboServicio.Properties.Items.Add(new TiposServicio());

            foreach (var s in _tiposServicios)
                cboServicio.Properties.Items.Add(s);

            cboVia.Properties.Items.Clear();
            foreach (var v in _tiposVias)
                cboVia.Properties.Items.Add(v);


            if (mode == "Nueva")
                NuevaCotizacion();
            else
                CargarCotizacionDirecta();

            AddDataBindings();

            if ((CotizacionDirecta.Opciones != null && CotizacionDirecta.Opciones.Count > 0))
                Cargaopcion(CotizacionDirecta.Opciones[0]);
        }

        private void CargarCotizacionDirecta() {
            if (mode != "borrador") {
                CotizacionDirecta =
                    ClsCotizacionDirecta.ObtieneCotizacionDirecta(CotizacionDirecta.Id32).ObjetoTransaccion as
                    CotizacionDirecta;
                Text = "Ingreso de cotización ";
            } else {
                Text = "Copia de cotización ";
                LblEstado.Visible = labelControl11.Visible = false;
            }
            txtEjecutivo.Text = CotizacionDirecta.Usuario.NombreCompleto;
            TxtFecha.DateTime = CotizacionDirecta.FechaSolicitud;

            var encontrado_cliente = _clientes.Find(foo => CotizacionDirecta.Cliente.Id32 == foo.Id32);
            if (encontrado_cliente == null) {
                _clientes.Add(CotizacionDirecta.Cliente);
                CboCliente.Properties.Items.Add(CotizacionDirecta.Cliente);
            }

            CboCliente.SelectedItem = CotizacionDirecta.Cliente;

            txtCommodity.Text = CotizacionDirecta.Commodity;
            TxtObservaciones.Text = CotizacionDirecta.Observaciones;
            LblEstado.Text = CotizacionDirecta.EstadoDescripcion;
            GridGastosLocales.DataSource = CotizacionDirecta.GastosLocalesList;

            if (mode != "borrador")
                if (CotizacionDirecta.Estado.Id32 == (Int32)Enums.EstadosCotizacion.Cerrado ||
                    CotizacionDirecta.Estado.Id32 == (Int32)Enums.EstadosCotizacion.PerdidoOtros ||
                    CotizacionDirecta.Estado.Id32 == (Int32)Enums.EstadosCotizacion.PerdidoTarifa ||
                    CotizacionDirecta.Estado.Id32 == (Int32)Enums.EstadosCotizacion.CerradoLCL) {
                    toolStripButton1.Enabled = false;
                    toolStripButton1.ToolTipText = "Imposible modificar cotización en el Estado actual";
                }
            if (CotizacionDirecta.Estado.Id32 == (Int32)Enums.EstadosCotizacion.Eliminado) {
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
            Text = "Ingreso de cotización";

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
            GridColumnGastoLocal.DisplayFormat.Format = new CultureInfo("es-CL");
            repositoryItemTextEdit2.Mask.Culture = new CultureInfo("es-CL");
            repositoryItemTextEdit2.DisplayFormat.FormatType = FormatType.Custom;
            repositoryItemTextEdit2.DisplayFormat.Format = new CultureInfo("es-CL").NumberFormat;
            repositoryItemTextEdit2.DisplayFormat.FormatString = "c0";
            GridColumnGastoLocal.DisplayFormat.FormatType = FormatType.Custom;
            GridColumnGastoLocal.DisplayFormat.Format = new CultureInfo("es-CL").NumberFormat;
            GridColumnGastoLocal.DisplayFormat.FormatString = "c0";

            //GridGastosLocales.s
            /*GridColumnGastoLocal.DisplayFormat.FormatType = FormatType.Numeric;
            GridColumnGastoLocal.DisplayFormat.FormatString = "c0";

            DevExpress.Utils.FormatInfo fi = new DevExpress.Utils.FormatInfo();
            fi.FormatType = DevExpress.Utils.FormatType.Numeric;
            fi.FormatString = "c0";
            */
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

            cboServicio.SelectedIndex = 0;
            cboVia.SelectedIndex = 0;

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
            cboServicio.SelectedIndex = 0;
            cboServicio.Enabled = enabled;
            cboVia.SelectedIndex = 0;
            cboVia.Enabled = enabled;
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
            var logCot = CreaLog(CotizacionDirecta, EnumTipoLogCotizacionDirecta.Modificacion);
            ClsLogCotizacionesDirecta.Guardar(logCot);
            MessageBox.Show(resultado.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CrearCotizacion() {
            var resultado = ClsCotizacionDirecta.Crear(CotizacionDirecta);
            var logCot = CreaLog(CotizacionDirecta, EnumTipoLogCotizacionDirecta.IngresoCotizacion);
            ClsLogCotizacionesDirecta.Guardar(logCot);
            MessageBox.Show(resultado.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static LogCotizacionesDirecta CreaLog(CotizacionDirecta cotizacionDirecta, EnumTipoLogCotizacionDirecta tipo) {
            var logCot = new LogCotizacionesDirecta {
                CotizacionDirecta = cotizacionDirecta,
                Usuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario,
                Fecha = DateTime.Now,
                Tipo = tipo
            };
            return logCot;
        }

        private void CargaDatosDelFormulario() {
            CotizacionDirecta.Producto = "FCL Importacion";

            var xmldoc = new XmlDocument();
            xmldoc.Load(Path.Combine(Application.StartupPath, @"Cotizaciones\CotizacionSetting.xml"));
            //CotizacionDirecta.ObservacionesFijas = xmldoc.SelectSingleNode("/setting/cotizacionDirecta/observacionFija").InnerText;
            CotizacionDirecta.ObservacionesFijas =
                clsParametros.ListarParametrosPorTipo(Enums.TipoParametro.CotizacionDirectaObsertvacionFija).Items[0].Nombre;

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
            CotizacionDirecta.Observaciones = TxtObservaciones.Text;
            CotizacionDirecta.GastosLocalesList = GridGastosLocales.DataSource as List<GastoLocal>;

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
                if (o.TiposServicio == null || o.TiposServicio.Id32 == 0) {
                    ctrldxError.SetError(cboServicio, "Debe ingresar el tipo de servicio", ErrorType.Critical);
                    encontroErrorOpcion = true;
                }



                if ((o.TiposServicio != null && o.TiposServicio.Id32 == 2) && (o.TipoVia == null || o.TipoVia.Id32 == 0)) {
                    ctrldxError.SetError(cboVia, "Debe ingresar un valor para Via", ErrorType.Critical);
                    encontroErrorOpcion = true;
                }

                if (o.Pol.Count == 0) {
                    ctrldxError.SetError(ListPolSeleccionado, "Debe seleccionar al menos un POL", ErrorType.Critical);
                    errorTexto += "Debe seleccionar al menos un POL" + Environment.NewLine;
                    encontroErrorOpcion = true;
                }

                if (o.Pod.Count == 0) {
                    ctrldxError.SetError(ListPod, "Debe seleccionar al menos un POD", ErrorType.Critical);
                    errorTexto += "Debe seleccionar al menos un POD" + Environment.NewLine;
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



                var errorCotizacion = false;
                GridView view = gridView1 as GridView;
                for (int j = 0; j < view.RowCount; j++) {
                    var row = view.GetDataRow(j);

                    foreach (GridColumn column in view.Columns) {

                        var foo = view.GetRowCellValue(j, column) as IIdentifiableObject;
                        if (foo != null && foo.Id32 == 0) {
                            errorCotizacion = true;
                            encontroErrorOpcion = true;
                        }


                    }
                }

                if (errorCotizacion)
                    errorTexto += "Debe ingresar todo el detalle de la cotización" + Environment.NewLine;

                if (!String.IsNullOrEmpty(errorTexto))
                    MessageBox.Show("Se han encontrado los siguientes problemas: " + Environment.NewLine + errorTexto,
                                     "Sistema Comercial Craft", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (encontroErrorOpcion)
                    return true;
                bindingNavigator1.BindingSource.MoveNext();
            }
            return ctrldxError.HasErrors;
        }

        private void CboNaviera_KeyPress(object sender, KeyPressEventArgs e) {

        }

        private void cboServicio_KeyPress(object sender, KeyPressEventArgs e) {

        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e) {

        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e) {

        }

        private void AddGastosLocales_Click(object sender, EventArgs e) {
            var list = GridGastosLocales.DataSource as List<GastoLocal>;
            if (list == null)
                list = new List<GastoLocal>();
            list.Add(new GastoLocal());

            GridGastosLocales.DataSource = list;
            GridGastosLocales.RefreshDataSource();

        }

        private void DeleteGastosLocales_Click(object sender, EventArgs e) {
            gridView3.DeleteSelectedRows();
        }

        private void TxtObservaciones_KeyPress(object sender, KeyPressEventArgs e){
            if (e.KeyChar == '&' || e.KeyChar == '>' || e.KeyChar == '<'){
                e.Handled = true;
            } else{
                e.Handled = false;
            }
        }

    }
}

