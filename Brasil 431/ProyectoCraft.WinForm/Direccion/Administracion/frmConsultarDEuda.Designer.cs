namespace ProyectoCraft.WinForm.Direccion.Administracion
{
    partial class frmConsultarDEuda
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultarDEuda));
            this.GridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Moneda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MontoDeudaMoneda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MontoDocumentadoMoneda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MontoFacturarMoneda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MontoDeudaMonBase = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MontoDeudaUSD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MontoDocumentadoMonBase = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MontoDocumentadoUSD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MontoFacturarMonBase = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MontoFacturarUSD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridConsultaDeuda = new DevExpress.XtraGrid.GridControl();
            this.clsArrRegistrosGrillaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColTipoRegistro = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColCliente = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColRut = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColTipoCliente = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColDeudaTotalMB = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColDeudaTotalUSD = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColDeudaDocMB = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColDeudaDocUSD = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColDeudaFacturarMB = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColDeudaFacturarUSD = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColLineaCredito = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColTotalDeudaTotal = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand8 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColRiesgo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridViewDesgloseMoneda = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColMoneda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ChildList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColApellido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStripBarraConsultarDeuda = new System.Windows.Forms.ToolStrip();
            this.MenuExportar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSalir = new System.Windows.Forms.ToolStripButton();
            this.grpFiltros = new DevExpress.XtraEditors.GroupControl();
            this.Date = new DevExpress.XtraEditors.DateEdit();
            this.sButtonBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.grpResultado = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridConsultaDeuda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsArrRegistrosGrillaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDesgloseMoneda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChildList)).BeginInit();
            this.toolStripBarraConsultarDeuda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpFiltros)).BeginInit();
            this.grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Date.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpResultado)).BeginInit();
            this.grpResultado.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridView1
            // 
            this.GridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Moneda,
            this.MontoDeudaMoneda,
            this.MontoDocumentadoMoneda,
            this.MontoFacturarMoneda,
            this.MontoDeudaMonBase,
            this.MontoDeudaUSD,
            this.MontoDocumentadoMonBase,
            this.MontoDocumentadoUSD,
            this.MontoFacturarMonBase,
            this.MontoFacturarUSD,
            this.gridColumn1});
            this.GridView1.CustomizationFormBounds = new System.Drawing.Rectangle(1062, 504, 208, 170);
            this.GridView1.DetailHeight = 200;
            this.GridView1.GridControl = this.gridConsultaDeuda;
            this.GridView1.Name = "GridView1";
            this.GridView1.OptionsDetail.ShowDetailTabs = false;
            this.GridView1.OptionsView.ShowGroupPanel = false;
            // 
            // Moneda
            // 
            this.Moneda.Caption = "Moneda Servicio";
            this.Moneda.FieldName = "Moneda";
            this.Moneda.Name = "Moneda";
            this.Moneda.OptionsColumn.AllowEdit = false;
            this.Moneda.OptionsColumn.AllowSize = false;
            this.Moneda.Visible = true;
            this.Moneda.VisibleIndex = 0;
            this.Moneda.Width = 99;
            // 
            // MontoDeudaMoneda
            // 
            this.MontoDeudaMoneda.Caption = "Deuda";
            this.MontoDeudaMoneda.DisplayFormat.FormatString = "#,##0.00";
            this.MontoDeudaMoneda.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.MontoDeudaMoneda.FieldName = "MontoDeuda";
            this.MontoDeudaMoneda.Name = "MontoDeudaMoneda";
            this.MontoDeudaMoneda.OptionsColumn.AllowEdit = false;
            this.MontoDeudaMoneda.OptionsColumn.AllowSize = false;
            this.MontoDeudaMoneda.Visible = true;
            this.MontoDeudaMoneda.VisibleIndex = 1;
            this.MontoDeudaMoneda.Width = 112;
            // 
            // MontoDocumentadoMoneda
            // 
            this.MontoDocumentadoMoneda.Caption = "Documentos";
            this.MontoDocumentadoMoneda.DisplayFormat.FormatString = "#,##0.00";
            this.MontoDocumentadoMoneda.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.MontoDocumentadoMoneda.FieldName = "MontoDocumentos";
            this.MontoDocumentadoMoneda.Name = "MontoDocumentadoMoneda";
            this.MontoDocumentadoMoneda.OptionsColumn.AllowEdit = false;
            this.MontoDocumentadoMoneda.OptionsColumn.AllowSize = false;
            this.MontoDocumentadoMoneda.Visible = true;
            this.MontoDocumentadoMoneda.VisibleIndex = 2;
            this.MontoDocumentadoMoneda.Width = 109;
            // 
            // MontoFacturarMoneda
            // 
            this.MontoFacturarMoneda.Caption = "x Facturar";
            this.MontoFacturarMoneda.DisplayFormat.FormatString = "#,##0.00";
            this.MontoFacturarMoneda.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.MontoFacturarMoneda.FieldName = "MontoFacturar";
            this.MontoFacturarMoneda.Name = "MontoFacturarMoneda";
            this.MontoFacturarMoneda.OptionsColumn.AllowEdit = false;
            this.MontoFacturarMoneda.OptionsColumn.AllowSize = false;
            this.MontoFacturarMoneda.Visible = true;
            this.MontoFacturarMoneda.VisibleIndex = 3;
            this.MontoFacturarMoneda.Width = 106;
            // 
            // MontoDeudaMonBase
            // 
            this.MontoDeudaMonBase.AppearanceHeader.Options.UseTextOptions = true;
            this.MontoDeudaMonBase.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.MontoDeudaMonBase.Caption = "$";
            this.MontoDeudaMonBase.DisplayFormat.FormatString = "#,##0";
            this.MontoDeudaMonBase.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.MontoDeudaMonBase.FieldName = "MDeudaMB";
            this.MontoDeudaMonBase.Name = "MontoDeudaMonBase";
            this.MontoDeudaMonBase.OptionsColumn.AllowEdit = false;
            this.MontoDeudaMonBase.Visible = true;
            this.MontoDeudaMonBase.VisibleIndex = 4;
            this.MontoDeudaMonBase.Width = 57;
            // 
            // MontoDeudaUSD
            // 
            this.MontoDeudaUSD.AppearanceHeader.Options.UseTextOptions = true;
            this.MontoDeudaUSD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.MontoDeudaUSD.Caption = "USD";
            this.MontoDeudaUSD.DisplayFormat.FormatString = "#,##0.00";
            this.MontoDeudaUSD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.MontoDeudaUSD.FieldName = "MDeudaUSD";
            this.MontoDeudaUSD.Name = "MontoDeudaUSD";
            this.MontoDeudaUSD.OptionsColumn.AllowEdit = false;
            this.MontoDeudaUSD.OptionsColumn.AllowSize = false;
            this.MontoDeudaUSD.Visible = true;
            this.MontoDeudaUSD.VisibleIndex = 5;
            this.MontoDeudaUSD.Width = 85;
            // 
            // MontoDocumentadoMonBase
            // 
            this.MontoDocumentadoMonBase.AppearanceHeader.Options.UseTextOptions = true;
            this.MontoDocumentadoMonBase.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.MontoDocumentadoMonBase.Caption = "$";
            this.MontoDocumentadoMonBase.DisplayFormat.FormatString = "#,##0";
            this.MontoDocumentadoMonBase.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.MontoDocumentadoMonBase.FieldName = "MDocuMB";
            this.MontoDocumentadoMonBase.Name = "MontoDocumentadoMonBase";
            this.MontoDocumentadoMonBase.OptionsColumn.AllowEdit = false;
            this.MontoDocumentadoMonBase.Visible = true;
            this.MontoDocumentadoMonBase.VisibleIndex = 6;
            this.MontoDocumentadoMonBase.Width = 68;
            // 
            // MontoDocumentadoUSD
            // 
            this.MontoDocumentadoUSD.AppearanceHeader.Options.UseTextOptions = true;
            this.MontoDocumentadoUSD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.MontoDocumentadoUSD.Caption = "USD";
            this.MontoDocumentadoUSD.DisplayFormat.FormatString = "#,##0.00";
            this.MontoDocumentadoUSD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.MontoDocumentadoUSD.FieldName = "MDocuUSD";
            this.MontoDocumentadoUSD.Name = "MontoDocumentadoUSD";
            this.MontoDocumentadoUSD.OptionsColumn.AllowEdit = false;
            this.MontoDocumentadoUSD.Visible = true;
            this.MontoDocumentadoUSD.VisibleIndex = 7;
            this.MontoDocumentadoUSD.Width = 83;
            // 
            // MontoFacturarMonBase
            // 
            this.MontoFacturarMonBase.AppearanceHeader.Options.UseTextOptions = true;
            this.MontoFacturarMonBase.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.MontoFacturarMonBase.Caption = "$";
            this.MontoFacturarMonBase.DisplayFormat.FormatString = "#,##0";
            this.MontoFacturarMonBase.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.MontoFacturarMonBase.FieldName = "MFacMB";
            this.MontoFacturarMonBase.Name = "MontoFacturarMonBase";
            this.MontoFacturarMonBase.OptionsColumn.AllowEdit = false;
            this.MontoFacturarMonBase.Visible = true;
            this.MontoFacturarMonBase.VisibleIndex = 8;
            this.MontoFacturarMonBase.Width = 77;
            // 
            // MontoFacturarUSD
            // 
            this.MontoFacturarUSD.AppearanceHeader.Options.UseTextOptions = true;
            this.MontoFacturarUSD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.MontoFacturarUSD.Caption = "USD";
            this.MontoFacturarUSD.DisplayFormat.FormatString = "#,##0.00";
            this.MontoFacturarUSD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.MontoFacturarUSD.FieldName = "MFacUSD";
            this.MontoFacturarUSD.Name = "MontoFacturarUSD";
            this.MontoFacturarUSD.OptionsColumn.AllowEdit = false;
            this.MontoFacturarUSD.Visible = true;
            this.MontoFacturarUSD.VisibleIndex = 9;
            this.MontoFacturarUSD.Width = 87;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 10;
            this.gridColumn1.Width = 205;
            // 
            // gridConsultaDeuda
            // 
            this.gridConsultaDeuda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridConsultaDeuda.DataSource = this.clsArrRegistrosGrillaBindingSource;
            this.gridConsultaDeuda.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.gridConsultaDeuda.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridConsultaDeuda.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.gridConsultaDeuda.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridConsultaDeuda.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.gridConsultaDeuda.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridConsultaDeuda.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.gridConsultaDeuda.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gridLevelNode1.LevelTemplate = this.GridView1;
            gridLevelNode1.RelationName = "ArregloDetalle";
            this.gridConsultaDeuda.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridConsultaDeuda.Location = new System.Drawing.Point(2, 20);
            this.gridConsultaDeuda.MainView = this.bandedGridView1;
            this.gridConsultaDeuda.Name = "gridConsultaDeuda";
            this.gridConsultaDeuda.ShowOnlyPredefinedDetails = true;
            this.gridConsultaDeuda.Size = new System.Drawing.Size(1117, 385);
            this.gridConsultaDeuda.TabIndex = 6;
            this.gridConsultaDeuda.UseEmbeddedNavigator = true;
            this.gridConsultaDeuda.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1,
            this.gridViewDesgloseMoneda,
            this.ChildList,
            this.GridView1});
            this.gridConsultaDeuda.Click += new System.EventHandler(this.gridConsultaDeuda_Click);
            // 
            // clsArrRegistrosGrillaBindingSource
            // 
            this.clsArrRegistrosGrillaBindingSource.DataSource = typeof(ProyectoCraft.Entidades.Direccion.Administracion.ClsArrRegistrosGrilla);
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand6,
            this.gridBand7,
            this.gridBand8});
            this.bandedGridView1.ColumnPanelRowHeight = 2;
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridColCliente,
            this.gridColRut,
            this.gridColTipoCliente,
            this.gridColDeudaTotalMB,
            this.gridColDeudaTotalUSD,
            this.gridColDeudaDocMB,
            this.gridColDeudaDocUSD,
            this.gridColDeudaFacturarMB,
            this.gridColDeudaFacturarUSD,
            this.gridColTotalDeudaTotal,
            this.gridColLineaCredito,
            this.gridColRiesgo,
            this.gridColTipoRegistro});
            this.bandedGridView1.GridControl = this.gridConsultaDeuda;
            this.bandedGridView1.GroupCount = 1;
            this.bandedGridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "TipoRegistro", null, "")});
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsView.ShowAutoFilterRow = true;
            this.bandedGridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColTipoRegistro, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.bandedGridView1.DataSourceChanged += new System.EventHandler(this.bandedGridView1_DataSourceChanged);
            this.bandedGridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.bandedGridView1_CustomDrawCell);
            this.bandedGridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.bandedGridView1_RowCellStyle);
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand1.Caption = "Cliente";
            this.gridBand1.Columns.Add(this.gridColTipoRegistro);
            this.gridBand1.Columns.Add(this.gridColCliente);
            this.gridBand1.Columns.Add(this.gridColRut);
            this.gridBand1.Columns.Add(this.gridColTipoCliente);
            this.gridBand1.MinWidth = 20;
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 483;
            // 
            // gridColTipoRegistro
            // 
            this.gridColTipoRegistro.Caption = "Tipo Registro";
            this.gridColTipoRegistro.FieldName = "TipoRegistro";
            this.gridColTipoRegistro.Name = "gridColTipoRegistro";
            this.gridColTipoRegistro.OptionsColumn.AllowEdit = false;
            this.gridColTipoRegistro.Visible = true;
            // 
            // gridColCliente
            // 
            this.gridColCliente.Caption = "Cliente";
            this.gridColCliente.FieldName = "Cliente";
            this.gridColCliente.Name = "gridColCliente";
            this.gridColCliente.OptionsColumn.AllowEdit = false;
            this.gridColCliente.OptionsColumn.ReadOnly = true;
            this.gridColCliente.Visible = true;
            this.gridColCliente.Width = 258;
            // 
            // gridColRut
            // 
            this.gridColRut.Caption = "Rut";
            this.gridColRut.FieldName = "Rut";
            this.gridColRut.Name = "gridColRut";
            this.gridColRut.OptionsColumn.AllowEdit = false;
            this.gridColRut.OptionsColumn.ReadOnly = true;
            this.gridColRut.Visible = true;
            this.gridColRut.Width = 82;
            // 
            // gridColTipoCliente
            // 
            this.gridColTipoCliente.Caption = "Tipo Cliente";
            this.gridColTipoCliente.FieldName = "TipoCliente";
            this.gridColTipoCliente.Name = "gridColTipoCliente";
            this.gridColTipoCliente.OptionsColumn.AllowEdit = false;
            this.gridColTipoCliente.OptionsColumn.ReadOnly = true;
            this.gridColTipoCliente.Visible = true;
            this.gridColTipoCliente.Width = 68;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "Deuda";
            this.gridBand2.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand3,
            this.gridBand4,
            this.gridBand5});
            this.gridBand2.MinWidth = 20;
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 459;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "Deuda";
            this.gridBand3.Columns.Add(this.gridColDeudaTotalMB);
            this.gridBand3.Columns.Add(this.gridColDeudaTotalUSD);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 143;
            // 
            // gridColDeudaTotalMB
            // 
            this.gridColDeudaTotalMB.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColDeudaTotalMB.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColDeudaTotalMB.Caption = "$";
            this.gridColDeudaTotalMB.DisplayFormat.FormatString = "$ #,##0";
            this.gridColDeudaTotalMB.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColDeudaTotalMB.FieldName = "DeudaMB";
            this.gridColDeudaTotalMB.Name = "gridColDeudaTotalMB";
            this.gridColDeudaTotalMB.OptionsColumn.AllowEdit = false;
            this.gridColDeudaTotalMB.OptionsColumn.ReadOnly = true;
            this.gridColDeudaTotalMB.Visible = true;
            this.gridColDeudaTotalMB.Width = 60;
            // 
            // gridColDeudaTotalUSD
            // 
            this.gridColDeudaTotalUSD.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColDeudaTotalUSD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColDeudaTotalUSD.Caption = "USD";
            this.gridColDeudaTotalUSD.DisplayFormat.FormatString = "US$ #,##0.00";
            this.gridColDeudaTotalUSD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColDeudaTotalUSD.FieldName = "DeudaOM";
            this.gridColDeudaTotalUSD.Name = "gridColDeudaTotalUSD";
            this.gridColDeudaTotalUSD.OptionsColumn.AllowEdit = false;
            this.gridColDeudaTotalUSD.OptionsColumn.ReadOnly = true;
            this.gridColDeudaTotalUSD.Visible = true;
            this.gridColDeudaTotalUSD.Width = 83;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "Documentos";
            this.gridBand4.Columns.Add(this.gridColDeudaDocMB);
            this.gridBand4.Columns.Add(this.gridColDeudaDocUSD);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.Width = 153;
            // 
            // gridColDeudaDocMB
            // 
            this.gridColDeudaDocMB.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColDeudaDocMB.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColDeudaDocMB.Caption = "$ ";
            this.gridColDeudaDocMB.DisplayFormat.FormatString = "$ #,##0";
            this.gridColDeudaDocMB.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColDeudaDocMB.FieldName = "DocuMB";
            this.gridColDeudaDocMB.Name = "gridColDeudaDocMB";
            this.gridColDeudaDocMB.OptionsColumn.AllowEdit = false;
            this.gridColDeudaDocMB.OptionsColumn.ReadOnly = true;
            this.gridColDeudaDocMB.Visible = true;
            this.gridColDeudaDocMB.Width = 70;
            // 
            // gridColDeudaDocUSD
            // 
            this.gridColDeudaDocUSD.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColDeudaDocUSD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColDeudaDocUSD.Caption = "USD";
            this.gridColDeudaDocUSD.DisplayFormat.FormatString = "US$ #,##0.00";
            this.gridColDeudaDocUSD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColDeudaDocUSD.FieldName = "DocuOM";
            this.gridColDeudaDocUSD.Name = "gridColDeudaDocUSD";
            this.gridColDeudaDocUSD.OptionsColumn.AllowEdit = false;
            this.gridColDeudaDocUSD.OptionsColumn.ReadOnly = true;
            this.gridColDeudaDocUSD.Visible = true;
            this.gridColDeudaDocUSD.Width = 83;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.Caption = "Pendiente Facturar";
            this.gridBand5.Columns.Add(this.gridColDeudaFacturarMB);
            this.gridBand5.Columns.Add(this.gridColDeudaFacturarUSD);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.Width = 163;
            // 
            // gridColDeudaFacturarMB
            // 
            this.gridColDeudaFacturarMB.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColDeudaFacturarMB.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColDeudaFacturarMB.Caption = "$";
            this.gridColDeudaFacturarMB.DisplayFormat.FormatString = "$ #,##0";
            this.gridColDeudaFacturarMB.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColDeudaFacturarMB.FieldName = "FacturarMB";
            this.gridColDeudaFacturarMB.Name = "gridColDeudaFacturarMB";
            this.gridColDeudaFacturarMB.OptionsColumn.AllowEdit = false;
            this.gridColDeudaFacturarMB.OptionsColumn.ReadOnly = true;
            this.gridColDeudaFacturarMB.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColDeudaFacturarMB.Visible = true;
            this.gridColDeudaFacturarMB.Width = 71;
            // 
            // gridColDeudaFacturarUSD
            // 
            this.gridColDeudaFacturarUSD.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColDeudaFacturarUSD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColDeudaFacturarUSD.Caption = "USD";
            this.gridColDeudaFacturarUSD.DisplayFormat.FormatString = "US$ #,##0.00";
            this.gridColDeudaFacturarUSD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColDeudaFacturarUSD.FieldName = "FacturarOM";
            this.gridColDeudaFacturarUSD.Name = "gridColDeudaFacturarUSD";
            this.gridColDeudaFacturarUSD.OptionsColumn.AllowEdit = false;
            this.gridColDeudaFacturarUSD.OptionsColumn.ReadOnly = true;
            this.gridColDeudaFacturarUSD.Visible = true;
            this.gridColDeudaFacturarUSD.Width = 92;
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand6.Caption = "Deuda Total";
            this.gridBand6.Columns.Add(this.gridColLineaCredito);
            this.gridBand6.MinWidth = 20;
            this.gridBand6.Name = "gridBand6";
            // 
            // gridColLineaCredito
            // 
            this.gridColLineaCredito.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColLineaCredito.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColLineaCredito.Caption = "USD";
            this.gridColLineaCredito.DisplayFormat.FormatString = "US$ #,##0.00";
            this.gridColLineaCredito.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColLineaCredito.FieldName = "TotalDeudaUS";
            this.gridColLineaCredito.Name = "gridColLineaCredito";
            this.gridColLineaCredito.OptionsColumn.AllowEdit = false;
            this.gridColLineaCredito.OptionsColumn.ReadOnly = true;
            this.gridColLineaCredito.Visible = true;
            this.gridColLineaCredito.Width = 70;
            // 
            // gridBand7
            // 
            this.gridBand7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand7.Caption = "Línea Crédito";
            this.gridBand7.Columns.Add(this.gridColTotalDeudaTotal);
            this.gridBand7.MinWidth = 20;
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.Width = 79;
            // 
            // gridColTotalDeudaTotal
            // 
            this.gridColTotalDeudaTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColTotalDeudaTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColTotalDeudaTotal.Caption = "USD";
            this.gridColTotalDeudaTotal.DisplayFormat.FormatString = "US$ #,##0.00";
            this.gridColTotalDeudaTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColTotalDeudaTotal.FieldName = "TotalCreditoUS";
            this.gridColTotalDeudaTotal.Name = "gridColTotalDeudaTotal";
            this.gridColTotalDeudaTotal.OptionsColumn.AllowEdit = false;
            this.gridColTotalDeudaTotal.OptionsColumn.ReadOnly = true;
            this.gridColTotalDeudaTotal.Visible = true;
            this.gridColTotalDeudaTotal.Width = 79;
            // 
            // gridBand8
            // 
            this.gridBand8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand8.Caption = "Clasificación";
            this.gridBand8.Columns.Add(this.gridColRiesgo);
            this.gridBand8.MinWidth = 20;
            this.gridBand8.Name = "gridBand8";
            this.gridBand8.Width = 72;
            // 
            // gridColRiesgo
            // 
            this.gridColRiesgo.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColRiesgo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColRiesgo.Caption = "Riesgo";
            this.gridColRiesgo.DisplayFormat.FormatString = "#,##0.00";
            this.gridColRiesgo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColRiesgo.FieldName = "Riesgo";
            this.gridColRiesgo.Name = "gridColRiesgo";
            this.gridColRiesgo.OptionsColumn.AllowEdit = false;
            this.gridColRiesgo.OptionsColumn.ReadOnly = true;
            this.gridColRiesgo.Visible = true;
            this.gridColRiesgo.Width = 72;
            // 
            // gridViewDesgloseMoneda
            // 
            this.gridViewDesgloseMoneda.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColMoneda});
            this.gridViewDesgloseMoneda.GridControl = this.gridConsultaDeuda;
            this.gridViewDesgloseMoneda.Name = "gridViewDesgloseMoneda";
            // 
            // gridColMoneda
            // 
            this.gridColMoneda.Caption = "Moneda";
            this.gridColMoneda.FieldName = "Detalle";
            this.gridColMoneda.Name = "gridColMoneda";
            this.gridColMoneda.Visible = true;
            this.gridColMoneda.VisibleIndex = 0;
            // 
            // ChildList
            // 
            this.ChildList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColNombre,
            this.gridColApellido});
            this.ChildList.DetailTabHeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.ChildList.GridControl = this.gridConsultaDeuda;
            this.ChildList.Name = "ChildList";
            this.ChildList.OptionsDetail.ShowDetailTabs = false;
            // 
            // gridColNombre
            // 
            this.gridColNombre.Caption = "Nombre";
            this.gridColNombre.FieldName = "ChildList";
            this.gridColNombre.Name = "gridColNombre";
            this.gridColNombre.Visible = true;
            this.gridColNombre.VisibleIndex = 0;
            // 
            // gridColApellido
            // 
            this.gridColApellido.Caption = "Apellido";
            this.gridColApellido.Name = "gridColApellido";
            this.gridColApellido.Visible = true;
            this.gridColApellido.VisibleIndex = 1;
            // 
            // toolStripBarraConsultarDeuda
            // 
            this.toolStripBarraConsultarDeuda.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuExportar,
            this.toolStripSeparator1,
            this.MenuSalir});
            this.toolStripBarraConsultarDeuda.Location = new System.Drawing.Point(0, 0);
            this.toolStripBarraConsultarDeuda.Name = "toolStripBarraConsultarDeuda";
            this.toolStripBarraConsultarDeuda.Size = new System.Drawing.Size(1130, 36);
            this.toolStripBarraConsultarDeuda.TabIndex = 6;
            this.toolStripBarraConsultarDeuda.Text = "toolStrip1";
            // 
            // MenuExportar
            // 
            this.MenuExportar.Image = ((System.Drawing.Image)(resources.GetObject("MenuExportar.Image")));
            this.MenuExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuExportar.Name = "MenuExportar";
            this.MenuExportar.Size = new System.Drawing.Size(53, 33);
            this.MenuExportar.Text = "Exportar";
            this.MenuExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuExportar.ToolTipText = "Exportar";
            this.MenuExportar.Click += new System.EventHandler(this.MenuExportar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 36);
            // 
            // MenuSalir
            // 
            this.MenuSalir.Image = ((System.Drawing.Image)(resources.GetObject("MenuSalir.Image")));
            this.MenuSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuSalir.Name = "MenuSalir";
            this.MenuSalir.Size = new System.Drawing.Size(31, 33);
            this.MenuSalir.Text = "Salir";
            this.MenuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuSalir.Click += new System.EventHandler(this.MenuSalir_Click);
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
            this.grpFiltros.Controls.Add(this.Date);
            this.grpFiltros.Controls.Add(this.sButtonBuscar);
            this.grpFiltros.Controls.Add(this.lblFecha);
            this.grpFiltros.Location = new System.Drawing.Point(2, 39);
            this.grpFiltros.LookAndFeel.SkinName = "Glass Oceans";
            this.grpFiltros.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(1126, 59);
            this.grpFiltros.TabIndex = 10;
            this.grpFiltros.Text = "Busqueda";
            // 
            // Date
            // 
            this.Date.EditValue = null;
            this.Date.Location = new System.Drawing.Point(49, 26);
            this.Date.Name = "Date";
            this.Date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Date.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.Date.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Date.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.Date.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Date.Properties.Mask.EditMask = "G";
            this.Date.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Date.Size = new System.Drawing.Size(121, 20);
            this.Date.TabIndex = 0;
            // 
            // sButtonBuscar
            // 
            this.sButtonBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sButtonBuscar.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sButtonBuscar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.sButtonBuscar.Appearance.Options.UseFont = true;
            this.sButtonBuscar.Image = ((System.Drawing.Image)(resources.GetObject("sButtonBuscar.Image")));
            this.sButtonBuscar.Location = new System.Drawing.Point(190, 24);
            this.sButtonBuscar.Name = "sButtonBuscar";
            this.sButtonBuscar.Size = new System.Drawing.Size(91, 22);
            this.sButtonBuscar.TabIndex = 2;
            this.sButtonBuscar.Text = "Buscar";
            this.sButtonBuscar.Click += new System.EventHandler(this.sButtonBuscar_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Appearance.Options.UseFont = true;
            this.lblFecha.Location = new System.Drawing.Point(10, 29);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(33, 13);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha:";
            // 
            // grpResultado
            // 
            this.grpResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResultado.AppearanceCaption.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpResultado.AppearanceCaption.Options.UseFont = true;
            this.grpResultado.Controls.Add(this.gridConsultaDeuda);
            this.grpResultado.Location = new System.Drawing.Point(2, 104);
            this.grpResultado.Name = "grpResultado";
            this.grpResultado.Size = new System.Drawing.Size(1124, 415);
            this.grpResultado.TabIndex = 12;
            this.grpResultado.Text = "Detalle Clientes con Deuda (Doble Click sobre la fila para Editar)";
            // 
            // frmConsultarDEuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 521);
            this.Controls.Add(this.grpResultado);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.toolStripBarraConsultarDeuda);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsultarDEuda";
            this.Text = "Consultar Deuda Vigente";
            this.Load += new System.EventHandler(this.frmConsultarDEuda_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmConsultarDEuda_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridConsultaDeuda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsArrRegistrosGrillaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDesgloseMoneda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChildList)).EndInit();
            this.toolStripBarraConsultarDeuda.ResumeLayout(false);
            this.toolStripBarraConsultarDeuda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpFiltros)).EndInit();
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Date.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpResultado)).EndInit();
            this.grpResultado.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripBarraConsultarDeuda;
        private System.Windows.Forms.ToolStripButton MenuExportar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton MenuSalir;
        private DevExpress.XtraEditors.GroupControl grpFiltros;
        private DevExpress.XtraEditors.DateEdit Date;
        private DevExpress.XtraEditors.SimpleButton sButtonBuscar;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.GroupControl grpResultado;
        private DevExpress.XtraGrid.GridControl gridConsultaDeuda;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDesgloseMoneda;
        private DevExpress.XtraGrid.Columns.GridColumn gridColMoneda;
        private DevExpress.XtraGrid.Views.Grid.GridView ChildList;
        public DevExpress.XtraGrid.Columns.GridColumn gridColNombre;
        private DevExpress.XtraGrid.Columns.GridColumn gridColApellido;
        private DevExpress.XtraGrid.Views.Grid.GridView GridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Moneda;
        private DevExpress.XtraGrid.Columns.GridColumn MontoDeudaMoneda;
        private DevExpress.XtraGrid.Columns.GridColumn MontoDocumentadoMoneda;
        private DevExpress.XtraGrid.Columns.GridColumn MontoFacturarMoneda;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColCliente;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColRut;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColDeudaTotalMB;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColDeudaTotalUSD;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColDeudaDocMB;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColDeudaDocUSD;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColDeudaFacturarMB;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColDeudaFacturarUSD;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColTipoCliente;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private System.Windows.Forms.BindingSource clsArrRegistrosGrillaBindingSource;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColTotalDeudaTotal;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColLineaCredito;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColRiesgo;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand8;
        private DevExpress.XtraGrid.Columns.GridColumn MontoDeudaMonBase;
        private DevExpress.XtraGrid.Columns.GridColumn MontoDeudaUSD;
        private DevExpress.XtraGrid.Columns.GridColumn MontoDocumentadoMonBase;
        private DevExpress.XtraGrid.Columns.GridColumn MontoDocumentadoUSD;
        private DevExpress.XtraGrid.Columns.GridColumn MontoFacturarMonBase;
        private DevExpress.XtraGrid.Columns.GridColumn MontoFacturarUSD;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColTipoRegistro;
    }
}