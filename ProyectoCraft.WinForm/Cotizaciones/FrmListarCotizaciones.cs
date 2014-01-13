using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.DXErrorProvider;
using ProyectoCraft.Entidades.Cotizaciones;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.Cotizaciones.Indirecta;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.LogicaNegocios.Cotizaciones;
using ProyectoCraft.LogicaNegocios.Cotizaciones.Directa;
using ProyectoCraft.LogicaNegocios.Cotizaciones.Indirecta;
using SCCMultimodal.Cotizaciones;


namespace ProyectoCraft.WinForm.Cotizaciones {
    public partial class FrmListarCotizaciones : Form {

        private List<Estado> EstadosCotizaciones { set; get; }
        private List<Estado> EstadosCotizacionIndirectas { set; get; }
        private List<Estado> EstadosOpciones { set; get; }
        /// <summary>
        /// Sirva para determinar si se esta seleccionando la grilla de Cotizaciones o opciones
        /// </summary>
        private String Seleccion { set; get; }

        private Opcion OpcionSeleccionada { set; get; }

        public IList<ITableable> ListCotizaciones { set; get; }

        public IList<ITableable> ListCotizacionesSeleccionadas { set; get; }

        private IList<ITableableOpcion> HijosSeleccionados { set; get; }

        private static FrmListarCotizaciones _form = null;

        public static FrmListarCotizaciones Instancia {
            get {
                if (_form == null)
                    _form = new FrmListarCotizaciones();

                return _form;
            }
            set { _form = value; }
        }

        public FrmListarCotizaciones() {
            InitializeComponent();
        }

        private void FrmListarTarifas_Load(object sender, System.EventArgs e) {
            Dock = DockStyle.Fill;
            var toolTip1 = new ToolTip();
            toolTip1.SetToolTip(gridSLeads, "Presione doble click para ver información detallada");

            EstadosCotizaciones = new List<Estado>();
            EstadosOpciones = new List<Estado>();

            var estadosDB = CotizacionDirectaEstado.ListarEstadosCotizacionDirecta().ObjetoTransaccion as List<Estado>;
            estadosDB = estadosDB.FindAll(foo => foo.Id32 >= 5);
            var estados = new List<Estado> { new Estado { Activo = false, Id = 0, Id32 = 0, Nombre = "Mensaje" } };


            EstadosCotizaciones.AddRange(estados);
            EstadosCotizaciones.AddRange(estadosDB);
            EstadosOpciones.AddRange(estados);
            EstadosOpciones.AddRange(estadosDB);

            EstadosCotizacionIndirectas = new List<Estado> { new Estado { Activo = false, Id = 0, Id32 = 0, Nombre = "Mensaje" } };
            CargarGrillaCotizaciones();
        }

        private void CargarEstado(ITableable tableable) {
            cboEstado.Properties.Items.Clear();
            if (tableable is CotizacionDirecta) {
                if (Seleccion == "cot") {
                    foreach (var es in EstadosCotizaciones)
                        cboEstado.Properties.Items.Add(es);
                }
                if (Seleccion == "op") {
                    foreach (var es in EstadosOpciones)
                        cboEstado.Properties.Items.Add(es);
                }
            }
            if (tableable is CotizacionIndirecta) {
                foreach (var es in EstadosCotizacionIndirectas)
                    cboEstado.Properties.Items.Add(es);
            }
            cboEstado.SelectedIndex = 0;
        }

        public void CargarGrillaCotizaciones() {
            ListCotizaciones =
                ClsCotizacionDirecta.ListarTodasLasCotizacionesPorUsuario(
                    Base.Usuario.UsuarioConectado.Usuario);
            foreach (var cotizacion in ListCotizaciones) {
                cotizacion.Seleccionado = false;
                if (cotizacion.OpcionesView != null)
                    foreach (var op in cotizacion.OpcionesView)
                        if (op != null)
                            op.Seleccionado = false;

            }
            gridSLeads.DataSource = ListCotizaciones;
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e) {

            var formulario = FrmCotizacionDirecta.Instancia;
            //formulario.FrmListarCotizaciones = this;
            formulario.ShowDialog();
        }

        private void MenuEnviarAlCliente_Click(object sender, EventArgs e) {
            ActiveControl = txtComentario;

            var listCotizaciones = gridSLeads.DataSource as List<ITableable>;
            var seleccionadas = listCotizaciones.FindAll(foo => foo.Seleccionado);
            if (seleccionadas.Count == 0) {
                MessageBox.Show("Debe seleccionar al menos una cotizacion", "Sistema Comercial Craft", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            } else {
                var bar = seleccionadas.FindAll(foo => foo.PermiteEnviarPorCorreo.Equals(false));
                if (bar.Count > 0) {
                    MessageBox.Show("Existe una cotizacion seleccionada que no se permite ser enviada", "Sistema Comercial Craft", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                } else {
                    var frm = new FrmPrintPreviewCotizacoines(seleccionadas);
                    frm.ShowDialog();
                }
            }
        }

        private void menuNuevaTarifa_Click(object sender, EventArgs e) {
            var formulario = FrmSolicitarTarifa.Instancia;
            //formulario.FrmListarCotizaciones = this;
            formulario.ShowDialog();
        }

        private void FrmListarCotizaciones_FormClosed(object sender, FormClosedEventArgs e) {
            Instancia = null;
        }

        private void MenuSalir_Click_1(object sender, EventArgs e) {
            Instancia = null;
            Close();
        }

        private void gridSLeads_DoubleClick(object sender, EventArgs e) {
        }

        private void GridViewOpcionesCellValueChanging(object sender,
                                                       DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e) {
            var val = sender as GridView;
            if (val != null) gridSLeads.DefaultView.GetRow(val.FocusedRowHandle);
        }



        private void GridViewSLeadsCellValueChanging(object sender,
                                                     DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e) {
            var val = sender as GridView;
            if (val != null) gridSLeads.DefaultView.GetRow(val.FocusedRowHandle);
        }

        private void gridViewSLeads_DoubleClick(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            var tableble = GetSelectedRow((GridView)sender);

            if (tableble is CotizacionDirecta) {
                var formulario = FrmCotizacionDirecta.Instancia;
                formulario.mode = "Ver/Editar";
                formulario.CotizacionDirecta = tableble as CotizacionDirecta;
                //formulario.FrmListarCotizaciones = this;
                formulario.ShowDialog();
                Cursor.Current = Cursors.Default;
            }

            if (tableble is CotizacionIndirecta) {
                var formulario = FrmSolicitarTarifa.Instancia;
                formulario.mode = "Ver/Editar";
                formulario.CotizacionIndirecta = tableble as CotizacionIndirecta;
                formulario.ShowDialog();
                Cursor.Current = Cursors.Default;
            }
        }

        private ITableable GetSelectedRow(GridView view) {
            return (ITableable)view.GetRow(view.FocusedRowHandle);
        }

        private void MenuActualizar_Click(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            CargarGrillaCotizaciones();
            Cursor.Current = Cursors.Default;
        }

        private void LimpiarFormularioMensaje() {
            cboEstado.SelectedIndex = 0;
            txtComentario.Text = String.Empty;
        }

        private void btnGuardarComentario_Click(object sender, EventArgs e) {

            Estado Estado = new Estado();

            //Valida Datos Obligatorios
            if (this.cboEstado.SelectedItem == null || this.cboEstado.SelectedIndex < 0) {
                ctrldxError.SetError(this.cboEstado, "Debe Seleccionar un Tipo de Comentario",
                                     ErrorType.Critical);
                return;
            } else {
                ctrldxError.SetError(cboEstado, "", ErrorType.None);
            }
            if (this.txtComentario.Text == "") {
                ctrldxError.SetError(txtComentario, "Debe Ingresar un Comentario", ErrorType.Critical);
                return;
            } else {
                ctrldxError.SetError(txtComentario, "", ErrorType.None);
            }

            Cursor.Current = Cursors.WaitCursor;
            var resultado = new ResultadoTransaccion();

            var comentario = new Comentario {
                EsHistorial = false,
                Observacion = txtComentario.Text,
                Usuario = Base.Usuario.UsuarioConectado.Usuario
            };
            var cotizacion = GetSelectedRow(gridViewSLeads);
            resultado = ClsComentario.GuardarMensaje(cotizacion, comentario);

            if (cboEstado.SelectedIndex != 0) {
                Estado = (Estado)cboEstado.SelectedItem;
                resultado = CotizacionDirectaEstado.ModificarEstado(cotizacion, Estado.Id32, Base.Usuario.UsuarioConectado.Usuario);
                if (resultado.Estado == Enums.EstadoTransaccion.Aceptada) {
                    LimpiarFormularioMensaje();
                    CargarGrillaCotizaciones();
                    MessageBox.Show(resultado.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                } else {
                    MessageBox.Show(resultado.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            txtComentario.Text = String.Empty;
            Cursor.Current = Cursors.Default;
            if (Seleccion == "cot")
                FocusCotizacion();
            if (Seleccion == "op")
                FocusOpcion(OpcionSeleccionada);
        }

        private void FocusOpcion(Opcion opcion) {
            /*   OpcionSeleccionada = opcion;
               var cotizacion = GetSelectedRow(gridViewSLeads);
               var comentarios = new List<Comentario>();
               if (cotizacion is CotizacionDirecta)
                   comentarios = ClsComentario.ObtieneTodosLosMensajes(cotizacion as CotizacionDirecta).ObjetoTransaccion as List<Comentario>;
               gridComentarios.DataSource = comentarios;
               gridComentarios.RefreshDataSource();
               Seleccion = "op";
               CargarEstado(tableble);
   */
        }

        private void gridViewSLeads_MasterRowExpanded(object sender, CustomMasterRowEventArgs e) {
            var masterView = sender as GridView;
            var detail = masterView.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            detail.FocusedRowChanged += gridViewOpciones_FocusedRowChanged;

            detail.BeginUpdate();
            detail.OptionsBehavior.Editable = true;
            detail.OptionsSelection.EnableAppearanceFocusedCell = false;
            detail.OptionsSelection.MultiSelect = true;
            detail.OptionsSelection.EnableAppearanceFocusedRow = true;
            detail.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;

            foreach (GridColumn column in detail.Columns)
                column.OptionsColumn.AllowEdit = false;

            detail.EndUpdate();

            detail.Focus();
            detail.SelectRow(0);
            detail.FocusedRowHandle = 0;
            var opcion = detail.GetRow(detail.FocusedRowHandle) as Opcion;

            FocusOpcion(opcion);
        }

        private void gridViewSLeads_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            FocusCotizacion();
        }

        private void FocusCotizacion() {
            var tableable = GetSelectedRow(gridViewSLeads);
            var comentarios = ClsComentario.ObtieneTodosLosMensajes(tableable).ObjetoTransaccion as List<Comentario>;
            gridComentarios.DataSource = comentarios;
            gridComentarios.RefreshDataSource();

            MenuCopiar.Enabled = tableable.PermiteCopiar;

            Seleccion = "cot";
            CargarEstado(tableable);
        }

        private void gridViewOpciones_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            var grid = sender as GridView;
            var opcion = grid.GetRow(e.FocusedRowHandle) as Opcion;
            OpcionSeleccionada = opcion;
            FocusOpcion(opcion);
        }

        private void MenuCopiar_Click(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            var tableable = GetSelectedRow((GridView)gridViewSLeads);
            if (tableable is CotizacionIndirecta) {
                var cot = ClsCotizacionIndirecta.ObtieneCotizacionIndirecta(tableable.Id32).ObjetoTransaccion as CotizacionIndirecta;
                cot.Id = cot.Id32 = 0;

                foreach (var d in cot.Detalles)
                    d.Id = d.Id32 = 0;

                var formulario = FrmSolicitarTarifa.Instancia;
                formulario.mode = "borrador";
                formulario.CotizacionIndirecta = cot;
                formulario.ShowDialog();
            }

            if (tableable is CotizacionDirecta) {
                var cot = ClsCotizacionDirecta.ObtieneCotizacionDirecta(tableable.Id32).ObjetoTransaccion as CotizacionDirecta;

                cot.Id = cot.Id32 = 0;
                foreach (var opcion in cot.Opciones)
                    opcion.Id = opcion.Id32 = 0;

                var formulario = FrmCotizacionDirecta.Instancia;
                formulario.mode = "borrador";
                formulario.CotizacionDirecta = cot;
                formulario.ShowDialog();

            }
            Cursor.Current = Cursors.Default;

        }
    }
}