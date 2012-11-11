using System.Diagnostics;
using ProyectoCraft.Entidades.Log;
using ProyectoCraft.LogicaNegocios.Log;

namespace ProyectoCraft.WinForm.Ventas.Actividades.Llamadas_Telefonicas
{
    partial class FrmListarLlamadas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListarLlamadas));
            this.toolStripBarraListarLlamada = new System.Windows.Forms.ToolStrip();
            this.MenuCrearLlamada = new System.Windows.Forms.ToolStripButton();
            this.MenuEditarLlamada = new System.Windows.Forms.ToolStripButton();
            this.MenuEliminar = new System.Windows.Forms.ToolStripButton();
            this.MenuImprimirListado = new System.Windows.Forms.ToolStripButton();
            this.MenuExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSalir = new System.Windows.Forms.ToolStripButton();
            this.grpBusquedasPredeterminadas = new DevExpress.XtraEditors.GroupControl();
            this.lstTipoBusqueda = new DevExpress.XtraEditors.ListBoxControl();
            this.grpFiltros = new DevExpress.XtraEditors.GroupControl();
            this.CboCliente = new DevExpress.XtraEditors.ComboBoxEdit();
            this.CboContactos = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateHasta = new DevExpress.XtraEditors.DateEdit();
            this.dateInicio = new DevExpress.XtraEditors.DateEdit();
            this.lblCliente = new DevExpress.XtraEditors.LabelControl();
            this.sButtonBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.lblContacto = new DevExpress.XtraEditors.LabelControl();
            this.grpResultado = new DevExpress.XtraEditors.GroupControl();
            this.gridLlamadas = new DevExpress.XtraGrid.GridControl();
            this.gridViewLlamadas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridContacto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridTema = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.gridVendedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridUsuarioCrea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridEntradaSalida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridImportancia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridTipoProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStripBarraListarLlamada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpBusquedasPredeterminadas)).BeginInit();
            this.grpBusquedasPredeterminadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstTipoBusqueda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpFiltros)).BeginInit();
            this.grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboContactos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateHasta.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateInicio.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpResultado)).BeginInit();
            this.grpResultado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLlamadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLlamadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripBarraListarLlamada
            // 
            this.toolStripBarraListarLlamada.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCrearLlamada,
            this.MenuEditarLlamada,
            this.MenuEliminar,
            this.MenuImprimirListado,
            this.MenuExcel,
            this.toolStripSeparator1,
            this.MenuSalir});
            this.toolStripBarraListarLlamada.Location = new System.Drawing.Point(0, 0);
            this.toolStripBarraListarLlamada.Name = "toolStripBarraListarLlamada";
            this.toolStripBarraListarLlamada.Size = new System.Drawing.Size(974, 38);
            this.toolStripBarraListarLlamada.TabIndex = 5;
            this.toolStripBarraListarLlamada.Text = "toolStrip1";
            // 
            // MenuCrearLlamada
            // 
            this.MenuCrearLlamada.Image = ((System.Drawing.Image)(resources.GetObject("MenuCrearLlamada.Image")));
            this.MenuCrearLlamada.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuCrearLlamada.Name = "MenuCrearLlamada";
            this.MenuCrearLlamada.Size = new System.Drawing.Size(39, 35);
            this.MenuCrearLlamada.Text = "Crear";
            this.MenuCrearLlamada.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuCrearLlamada.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuCrearLlamada.ToolTipText = "Crear";
            this.MenuCrearLlamada.Click += new System.EventHandler(this.MenuCrearLlamada_Click);
            // 
            // MenuEditarLlamada
            // 
            this.MenuEditarLlamada.Image = ((System.Drawing.Image)(resources.GetObject("MenuEditarLlamada.Image")));
            this.MenuEditarLlamada.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuEditarLlamada.Name = "MenuEditarLlamada";
            this.MenuEditarLlamada.Size = new System.Drawing.Size(41, 35);
            this.MenuEditarLlamada.Text = "Editar";
            this.MenuEditarLlamada.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuEditarLlamada.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuEditarLlamada.ToolTipText = "Editar";
            this.MenuEditarLlamada.Click += new System.EventHandler(this.MenuEditarLlamada_Click);
            // 
            // MenuEliminar
            // 
            this.MenuEliminar.Image = ((System.Drawing.Image)(resources.GetObject("MenuEliminar.Image")));
            this.MenuEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuEliminar.Name = "MenuEliminar";
            this.MenuEliminar.Size = new System.Drawing.Size(54, 35);
            this.MenuEliminar.Text = "Eliminar";
            this.MenuEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuEliminar.ToolTipText = "Eliminar";
            this.MenuEliminar.Click += new System.EventHandler(this.MenuEliminar_Click);
            // 
            // MenuImprimirListado
            // 
            this.MenuImprimirListado.Enabled = false;
            this.MenuImprimirListado.Image = ((System.Drawing.Image)(resources.GetObject("MenuImprimirListado.Image")));
            this.MenuImprimirListado.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.MenuImprimirListado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuImprimirListado.Name = "MenuImprimirListado";
            this.MenuImprimirListado.Size = new System.Drawing.Size(98, 35);
            this.MenuImprimirListado.Text = "Imprimir Listado";
            this.MenuImprimirListado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuImprimirListado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // MenuExcel
            // 
            this.MenuExcel.Image = ((System.Drawing.Image)(resources.GetObject("MenuExcel.Image")));
            this.MenuExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.MenuExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuExcel.Name = "MenuExcel";
            this.MenuExcel.Size = new System.Drawing.Size(37, 35);
            this.MenuExcel.Text = "Excel";
            this.MenuExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuExcel.ToolTipText = "Exportar Excel";
            this.MenuExcel.Click += new System.EventHandler(this.MenuExcel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // MenuSalir
            // 
            this.MenuSalir.Image = ((System.Drawing.Image)(resources.GetObject("MenuSalir.Image")));
            this.MenuSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuSalir.Name = "MenuSalir";
            this.MenuSalir.Size = new System.Drawing.Size(33, 35);
            this.MenuSalir.Text = "Salir";
            this.MenuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuSalir.Click += new System.EventHandler(this.MenuSalir_Click);
            // 
            // grpBusquedasPredeterminadas
            // 
            this.grpBusquedasPredeterminadas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBusquedasPredeterminadas.AppearanceCaption.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBusquedasPredeterminadas.AppearanceCaption.Options.UseFont = true;
            this.grpBusquedasPredeterminadas.Controls.Add(this.lstTipoBusqueda);
            this.grpBusquedasPredeterminadas.Location = new System.Drawing.Point(554, 39);
            this.grpBusquedasPredeterminadas.Name = "grpBusquedasPredeterminadas";
            this.grpBusquedasPredeterminadas.Size = new System.Drawing.Size(419, 114);
            this.grpBusquedasPredeterminadas.TabIndex = 10;
            this.grpBusquedasPredeterminadas.Text = "Búsquedas Predeterminadas";
            // 
            // lstTipoBusqueda
            // 
            this.lstTipoBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTipoBusqueda.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTipoBusqueda.Appearance.Options.UseFont = true;
            this.lstTipoBusqueda.Items.AddRange(new object[] {
            "Todas",
            "Mis Llamadas",
            "Mis Cuentas"});
            this.lstTipoBusqueda.Location = new System.Drawing.Point(5, 23);
            this.lstTipoBusqueda.Name = "lstTipoBusqueda";
            this.lstTipoBusqueda.Size = new System.Drawing.Size(409, 86);
            this.lstTipoBusqueda.TabIndex = 0;
            this.lstTipoBusqueda.SelectedIndexChanged += new System.EventHandler(this.listBoxConsultasRapidas_SelectedIndexChanged);
            // 
            // grpFiltros
            // 
            this.grpFiltros.Appearance.BackColor = System.Drawing.Color.White;
            this.grpFiltros.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFiltros.Appearance.Options.UseBackColor = true;
            this.grpFiltros.Appearance.Options.UseFont = true;
            this.grpFiltros.AppearanceCaption.BackColor = System.Drawing.Color.White;
            this.grpFiltros.AppearanceCaption.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFiltros.AppearanceCaption.Options.UseBackColor = true;
            this.grpFiltros.AppearanceCaption.Options.UseFont = true;
            this.grpFiltros.Controls.Add(this.CboCliente);
            this.grpFiltros.Controls.Add(this.CboContactos);
            this.grpFiltros.Controls.Add(this.labelControl1);
            this.grpFiltros.Controls.Add(this.dateHasta);
            this.grpFiltros.Controls.Add(this.dateInicio);
            this.grpFiltros.Controls.Add(this.lblCliente);
            this.grpFiltros.Controls.Add(this.sButtonBuscar);
            this.grpFiltros.Controls.Add(this.lblFecha);
            this.grpFiltros.Controls.Add(this.lblContacto);
            this.grpFiltros.Location = new System.Drawing.Point(5, 39);
            this.grpFiltros.LookAndFeel.SkinName = "Glass Oceans";
            this.grpFiltros.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(543, 114);
            this.grpFiltros.TabIndex = 9;
            this.grpFiltros.Text = "Busqueda";
            this.grpFiltros.Paint += new System.Windows.Forms.PaintEventHandler(this.grpFiltros_Paint);
            // 
            // CboCliente
            // 
            this.CboCliente.Location = new System.Drawing.Point(84, 56);
            this.CboCliente.Name = "CboCliente";
            this.CboCliente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CboCliente.Size = new System.Drawing.Size(357, 20);
            this.CboCliente.TabIndex = 10;
            this.CboCliente.SelectedIndexChanged += new System.EventHandler(this.CboCliente_SelectedIndexChanged);
            // 
            // CboContactos
            // 
            this.CboContactos.Location = new System.Drawing.Point(84, 82);
            this.CboContactos.Name = "CboContactos";
            this.CboContactos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CboContactos.Size = new System.Drawing.Size(357, 20);
            this.CboContactos.TabIndex = 9;
            this.CboContactos.Leave += new System.EventHandler(this.CboContactos_Leave);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(211, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(27, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "hasta";
            // 
            // dateHasta
            // 
            this.dateHasta.EditValue = null;
            this.dateHasta.Location = new System.Drawing.Point(244, 30);
            this.dateHasta.Name = "dateHasta";
            this.dateHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateHasta.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.dateHasta.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateHasta.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.dateHasta.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateHasta.Properties.Mask.EditMask = "g";
            this.dateHasta.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateHasta.Size = new System.Drawing.Size(111, 20);
            this.dateHasta.TabIndex = 3;
            // 
            // dateInicio
            // 
            this.dateInicio.EditValue = null;
            this.dateInicio.Location = new System.Drawing.Point(84, 32);
            this.dateInicio.Name = "dateInicio";
            this.dateInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateInicio.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.dateInicio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateInicio.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.dateInicio.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateInicio.Properties.Mask.EditMask = "g";
            this.dateInicio.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateInicio.Size = new System.Drawing.Size(121, 20);
            this.dateInicio.TabIndex = 2;
            // 
            // lblCliente
            // 
            this.lblCliente.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Appearance.Options.UseFont = true;
            this.lblCliente.Location = new System.Drawing.Point(5, 59);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(73, 13);
            this.lblCliente.TabIndex = 4;
            this.lblCliente.Text = "Cliente/Target:";
            // 
            // sButtonBuscar
            // 
            this.sButtonBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sButtonBuscar.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sButtonBuscar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.sButtonBuscar.Appearance.Options.UseFont = true;
            this.sButtonBuscar.Image = ((System.Drawing.Image)(resources.GetObject("sButtonBuscar.Image")));
            this.sButtonBuscar.Location = new System.Drawing.Point(447, 80);
            this.sButtonBuscar.Name = "sButtonBuscar";
            this.sButtonBuscar.Size = new System.Drawing.Size(91, 22);
            this.sButtonBuscar.TabIndex = 1;
            this.sButtonBuscar.Text = "Buscar";
            this.sButtonBuscar.Click += new System.EventHandler(this.sButtonBuscar_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Appearance.Options.UseFont = true;
            this.lblFecha.Location = new System.Drawing.Point(7, 33);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(33, 13);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblContacto
            // 
            this.lblContacto.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContacto.Appearance.Options.UseFont = true;
            this.lblContacto.Location = new System.Drawing.Point(5, 85);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(48, 13);
            this.lblContacto.TabIndex = 0;
            this.lblContacto.Text = "Contacto:";
            // 
            // grpResultado
            // 
            this.grpResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResultado.AppearanceCaption.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpResultado.AppearanceCaption.Options.UseFont = true;
            this.grpResultado.Controls.Add(this.gridLlamadas);
            this.grpResultado.Location = new System.Drawing.Point(5, 154);
            this.grpResultado.Name = "grpResultado";
            this.grpResultado.Size = new System.Drawing.Size(968, 346);
            this.grpResultado.TabIndex = 11;
            this.grpResultado.Text = "Resultado de busqueda (Doble Click sobre la fila para Editar)";
            // 
            // gridLlamadas
            // 
            this.gridLlamadas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLlamadas.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.gridLlamadas.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridLlamadas.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.gridLlamadas.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridLlamadas.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.gridLlamadas.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridLlamadas.Location = new System.Drawing.Point(2, 20);
            this.gridLlamadas.MainView = this.gridViewLlamadas;
            this.gridLlamadas.Name = "gridLlamadas";
            this.gridLlamadas.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoExEdit1});
            this.gridLlamadas.Size = new System.Drawing.Size(961, 305);
            this.gridLlamadas.TabIndex = 6;
            this.gridLlamadas.UseEmbeddedNavigator = true;
            this.gridLlamadas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLlamadas});
            this.gridLlamadas.DoubleClick += new System.EventHandler(this.gridLlamadas_DoubleClick);
            this.gridLlamadas.Click += new System.EventHandler(this.gridLlamadas_Click);
            // 
            // gridViewLlamadas
            // 
            this.gridViewLlamadas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridFecha,
            this.gridContacto,
            this.gridCliente,
            this.gridTema,
            this.gridDescripcion,
            this.gridVendedor,
            this.gridCustomer,
            this.gridUsuarioCrea,
            this.gridEntradaSalida,
            this.gridImportancia,
            this.gridTipoProducto});
            this.gridViewLlamadas.GridControl = this.gridLlamadas;
            this.gridViewLlamadas.Name = "gridViewLlamadas";
            this.gridViewLlamadas.OptionsView.ShowAutoFilterRow = true;
            // 
            // gridFecha
            // 
            this.gridFecha.Caption = "Fecha";
            this.gridFecha.DisplayFormat.FormatString = "dd-MM-yyyy hh:mm";
            this.gridFecha.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridFecha.FieldName = "FechaHora";
            this.gridFecha.Name = "gridFecha";
            this.gridFecha.OptionsColumn.AllowEdit = false;
            this.gridFecha.OptionsColumn.ReadOnly = true;
            this.gridFecha.Visible = true;
            this.gridFecha.VisibleIndex = 0;
            this.gridFecha.Width = 55;
            // 
            // gridContacto
            // 
            this.gridContacto.Caption = "Contacto";
            this.gridContacto.FieldName = "ObjContacto.Nombre";
            this.gridContacto.Name = "gridContacto";
            this.gridContacto.OptionsColumn.AllowEdit = false;
            this.gridContacto.OptionsColumn.ReadOnly = true;
            this.gridContacto.Visible = true;
            this.gridContacto.VisibleIndex = 4;
            this.gridContacto.Width = 125;
            // 
            // gridCliente
            // 
            this.gridCliente.Caption = "Cliente/Target";
            this.gridCliente.FieldName = "ObjContacto.ClienteMaster.Nombres";
            this.gridCliente.Name = "gridCliente";
            this.gridCliente.OptionsColumn.AllowEdit = false;
            this.gridCliente.OptionsColumn.ReadOnly = true;
            this.gridCliente.Visible = true;
            this.gridCliente.VisibleIndex = 2;
            this.gridCliente.Width = 159;
            // 
            // gridTema
            // 
            this.gridTema.Caption = "Tema";
            this.gridTema.FieldName = "ObjTipoActividadAsunto.Nombre";
            this.gridTema.Name = "gridTema";
            this.gridTema.OptionsColumn.ReadOnly = true;
            this.gridTema.Width = 181;
            // 
            // gridDescripcion
            // 
            this.gridDescripcion.Caption = "Descripción";
            this.gridDescripcion.ColumnEdit = this.repositoryItemMemoExEdit1;
            this.gridDescripcion.FieldName = "Descripcion";
            this.gridDescripcion.Name = "gridDescripcion";
            this.gridDescripcion.OptionsColumn.ReadOnly = true;
            this.gridDescripcion.Visible = true;
            this.gridDescripcion.VisibleIndex = 3;
            this.gridDescripcion.Width = 120;
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            this.repositoryItemMemoExEdit1.ShowIcon = false;
            // 
            // gridVendedor
            // 
            this.gridVendedor.Caption = "Vendedor";
            this.gridVendedor.FieldName = "ObjVendedor.Nombre";
            this.gridVendedor.Name = "gridVendedor";
            this.gridVendedor.OptionsColumn.AllowEdit = false;
            this.gridVendedor.OptionsColumn.ReadOnly = true;
            this.gridVendedor.Visible = true;
            this.gridVendedor.VisibleIndex = 5;
            this.gridVendedor.Width = 69;
            // 
            // gridCustomer
            // 
            this.gridCustomer.Caption = "Customer";
            this.gridCustomer.FieldName = "ObjCustomer.Nombre";
            this.gridCustomer.Name = "gridCustomer";
            this.gridCustomer.OptionsColumn.AllowEdit = false;
            this.gridCustomer.Visible = true;
            this.gridCustomer.VisibleIndex = 6;
            this.gridCustomer.Width = 69;
            // 
            // gridUsuarioCrea
            // 
            this.gridUsuarioCrea.Caption = "Usuario";
            this.gridUsuarioCrea.FieldName = "ObjUsuario.Nombre";
            this.gridUsuarioCrea.Name = "gridUsuarioCrea";
            this.gridUsuarioCrea.OptionsColumn.AllowEdit = false;
            this.gridUsuarioCrea.OptionsColumn.ReadOnly = true;
            this.gridUsuarioCrea.Visible = true;
            this.gridUsuarioCrea.VisibleIndex = 7;
            this.gridUsuarioCrea.Width = 87;
            // 
            // gridEntradaSalida
            // 
            this.gridEntradaSalida.Caption = "Tipo Llamada";
            this.gridEntradaSalida.FieldName = "EntradaSalida";
            this.gridEntradaSalida.Name = "gridEntradaSalida";
            this.gridEntradaSalida.OptionsColumn.AllowEdit = false;
            this.gridEntradaSalida.OptionsColumn.ReadOnly = true;
            this.gridEntradaSalida.Visible = true;
            this.gridEntradaSalida.VisibleIndex = 8;
            this.gridEntradaSalida.Width = 59;
            // 
            // gridImportancia
            // 
            this.gridImportancia.Caption = "Importancia";
            this.gridImportancia.FieldName = "Importancia";
            this.gridImportancia.Name = "gridImportancia";
            this.gridImportancia.OptionsColumn.AllowEdit = false;
            this.gridImportancia.OptionsColumn.ReadOnly = true;
            this.gridImportancia.Visible = true;
            this.gridImportancia.VisibleIndex = 9;
            this.gridImportancia.Width = 66;
            // 
            // gridTipoProducto
            // 
            this.gridTipoProducto.Caption = "Tipo Producto";
            this.gridTipoProducto.FieldName = "ObjTipoProducto.Nombre";
            this.gridTipoProducto.Name = "gridTipoProducto";
            this.gridTipoProducto.OptionsColumn.AllowEdit = false;
            this.gridTipoProducto.OptionsColumn.ReadOnly = true;
            this.gridTipoProducto.Visible = true;
            this.gridTipoProducto.VisibleIndex = 1;
            this.gridTipoProducto.Width = 98;
            // 
            // FrmListarLlamadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 501);
            this.Controls.Add(this.grpResultado);
            this.Controls.Add(this.grpBusquedasPredeterminadas);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.toolStripBarraListarLlamada);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmListarLlamadas";
            this.Text = "Lista de Llamadas Telefónicas";
            this.Load += new System.EventHandler(this.FrmListarLlamadas_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmListarLlamadas_FormClosed);
            this.toolStripBarraListarLlamada.ResumeLayout(false);
            this.toolStripBarraListarLlamada.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpBusquedasPredeterminadas)).EndInit();
            this.grpBusquedasPredeterminadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstTipoBusqueda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpFiltros)).EndInit();
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboContactos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateHasta.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateInicio.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpResultado)).EndInit();
            this.grpResultado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLlamadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLlamadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripBarraListarLlamada;
        private System.Windows.Forms.ToolStripButton MenuCrearLlamada;
        private System.Windows.Forms.ToolStripButton MenuEditarLlamada;
        private System.Windows.Forms.ToolStripButton MenuEliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton MenuSalir;
        private System.Windows.Forms.ToolStripButton MenuImprimirListado;
        private DevExpress.XtraEditors.GroupControl grpBusquedasPredeterminadas;
        private DevExpress.XtraEditors.ListBoxControl lstTipoBusqueda;
        private DevExpress.XtraEditors.GroupControl grpFiltros;
        private DevExpress.XtraEditors.LabelControl lblCliente;
        private DevExpress.XtraEditors.SimpleButton sButtonBuscar;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.LabelControl lblContacto;
        private DevExpress.XtraEditors.GroupControl grpResultado;
        private DevExpress.XtraGrid.GridControl gridLlamadas;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLlamadas;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dateHasta;
        private DevExpress.XtraEditors.DateEdit dateInicio;
        private DevExpress.XtraGrid.Columns.GridColumn gridFecha;
        private DevExpress.XtraGrid.Columns.GridColumn gridContacto;
        private DevExpress.XtraGrid.Columns.GridColumn gridCliente;
        private DevExpress.XtraGrid.Columns.GridColumn gridTema;
        private DevExpress.XtraGrid.Columns.GridColumn gridDescripcion;
        private DevExpress.XtraEditors.ComboBoxEdit CboContactos;
        private DevExpress.XtraEditors.ComboBoxEdit CboCliente;
        private DevExpress.XtraGrid.Columns.GridColumn gridVendedor;
        private DevExpress.XtraGrid.Columns.GridColumn gridCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn gridUsuarioCrea;
        private System.Windows.Forms.ToolStripButton MenuExcel;
        private DevExpress.XtraGrid.Columns.GridColumn gridEntradaSalida;
        private DevExpress.XtraGrid.Columns.GridColumn gridImportancia;
        private DevExpress.XtraGrid.Columns.GridColumn gridTipoProducto;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;

    }
}