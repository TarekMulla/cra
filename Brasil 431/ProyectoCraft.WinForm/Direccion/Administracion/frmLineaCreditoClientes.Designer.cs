namespace ProyectoCraft.WinForm.Direccion.Administracion
{
    partial class frmLineaCreditoClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLineaCreditoClientes));
            this.toolStripBarraConsultarDeuda = new System.Windows.Forms.ToolStrip();
            this.MenuExportar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSalir = new System.Windows.Forms.ToolStripButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.sButtonBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateHasta = new DevExpress.XtraEditors.DateEdit();
            this.dateInicio = new DevExpress.XtraEditors.DateEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.grpResultado = new DevExpress.XtraEditors.GroupControl();
            this.gridLineaCredito = new DevExpress.XtraGrid.GridControl();
            this.gridViewLineaCredito = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColRut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColTipoCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColVendedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColConFlete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColGastosLocales = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColLineaCredito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStripBarraConsultarDeuda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateHasta.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateInicio.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpResultado)).BeginInit();
            this.grpResultado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLineaCredito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLineaCredito)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripBarraConsultarDeuda
            // 
            this.toolStripBarraConsultarDeuda.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuExportar,
            this.toolStripSeparator1,
            this.MenuSalir});
            this.toolStripBarraConsultarDeuda.Location = new System.Drawing.Point(0, 0);
            this.toolStripBarraConsultarDeuda.Name = "toolStripBarraConsultarDeuda";
            this.toolStripBarraConsultarDeuda.Size = new System.Drawing.Size(1019, 36);
            this.toolStripBarraConsultarDeuda.TabIndex = 8;
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
            this.MenuSalir.Click += new System.EventHandler(this.MenuSalir_Click_1);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.sButtonBuscar);
            this.groupControl3.Controls.Add(this.labelControl1);
            this.groupControl3.Controls.Add(this.dateHasta);
            this.groupControl3.Controls.Add(this.dateInicio);
            this.groupControl3.Controls.Add(this.lblFecha);
            this.groupControl3.Location = new System.Drawing.Point(5, 39);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(1007, 63);
            this.groupControl3.TabIndex = 15;
            this.groupControl3.Text = "Búsqueda";
            this.groupControl3.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl3_Paint);
            // 
            // sButtonBuscar
            // 
            this.sButtonBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sButtonBuscar.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sButtonBuscar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.sButtonBuscar.Appearance.Options.UseFont = true;
            this.sButtonBuscar.Image = ((System.Drawing.Image)(resources.GetObject("sButtonBuscar.Image")));
            this.sButtonBuscar.Location = new System.Drawing.Point(343, 30);
            this.sButtonBuscar.Name = "sButtonBuscar";
            this.sButtonBuscar.Size = new System.Drawing.Size(91, 22);
            this.sButtonBuscar.TabIndex = 13;
            this.sButtonBuscar.Text = "Buscar";
            this.sButtonBuscar.Click += new System.EventHandler(this.sButtonBuscar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(173, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(27, 13);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "hasta";
            // 
            // dateHasta
            // 
            this.dateHasta.EditValue = null;
            this.dateHasta.Location = new System.Drawing.Point(206, 32);
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
            this.dateHasta.TabIndex = 11;
            // 
            // dateInicio
            // 
            this.dateInicio.EditValue = null;
            this.dateInicio.Location = new System.Drawing.Point(46, 32);
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
            this.dateInicio.TabIndex = 10;
            // 
            // lblFecha
            // 
            this.lblFecha.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Appearance.Options.UseFont = true;
            this.lblFecha.Location = new System.Drawing.Point(7, 35);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(33, 13);
            this.lblFecha.TabIndex = 9;
            this.lblFecha.Text = "Fecha:";
            // 
            // grpResultado
            // 
            this.grpResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResultado.AppearanceCaption.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpResultado.AppearanceCaption.Options.UseFont = true;
            this.grpResultado.Controls.Add(this.gridLineaCredito);
            this.grpResultado.Location = new System.Drawing.Point(5, 108);
            this.grpResultado.Name = "grpResultado";
            this.grpResultado.Size = new System.Drawing.Size(1007, 411);
            this.grpResultado.TabIndex = 16;
            this.grpResultado.Text = "Líneas de Crédito";
            // 
            // gridLineaCredito
            // 
            this.gridLineaCredito.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLineaCredito.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.gridLineaCredito.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridLineaCredito.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.gridLineaCredito.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridLineaCredito.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.gridLineaCredito.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridLineaCredito.Location = new System.Drawing.Point(2, 20);
            this.gridLineaCredito.MainView = this.gridViewLineaCredito;
            this.gridLineaCredito.Name = "gridLineaCredito";
            this.gridLineaCredito.Size = new System.Drawing.Size(1000, 386);
            this.gridLineaCredito.TabIndex = 6;
            this.gridLineaCredito.UseEmbeddedNavigator = true;
            this.gridLineaCredito.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLineaCredito});
            // 
            // gridViewLineaCredito
            // 
            this.gridViewLineaCredito.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColCuenta,
            this.ColRut,
            this.ColTipoCliente,
            this.ColVendedor,
            this.ColConFlete,
            this.ColGastosLocales,
            this.ColLineaCredito});
            this.gridViewLineaCredito.GridControl = this.gridLineaCredito;
            this.gridViewLineaCredito.GroupCount = 1;
            this.gridViewLineaCredito.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", this.ColTipoCliente, "")});
            this.gridViewLineaCredito.Name = "gridViewLineaCredito";
            this.gridViewLineaCredito.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridViewLineaCredito.OptionsBehavior.Editable = false;
            this.gridViewLineaCredito.OptionsView.ShowAutoFilterRow = true;
            this.gridViewLineaCredito.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.ColTipoCliente, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // ColCuenta
            // 
            this.ColCuenta.Caption = "Cuenta";
            this.ColCuenta.FieldName = "ObjCuenta.Cuenta.NombreFantasia";
            this.ColCuenta.Name = "ColCuenta";
            this.ColCuenta.OptionsColumn.AllowEdit = false;
            this.ColCuenta.OptionsColumn.ReadOnly = true;
            this.ColCuenta.Visible = true;
            this.ColCuenta.VisibleIndex = 0;
            this.ColCuenta.Width = 256;
            // 
            // ColRut
            // 
            this.ColRut.Caption = "Rut";
            this.ColRut.FieldName = "ObjCuenta.RUT";
            this.ColRut.Name = "ColRut";
            this.ColRut.OptionsColumn.AllowEdit = false;
            this.ColRut.Visible = true;
            this.ColRut.VisibleIndex = 1;
            this.ColRut.Width = 82;
            // 
            // ColTipoCliente
            // 
            this.ColTipoCliente.Caption = "(FF/Directo)";
            this.ColTipoCliente.FieldName = "TipoCliente";
            this.ColTipoCliente.Name = "ColTipoCliente";
            this.ColTipoCliente.Visible = true;
            this.ColTipoCliente.VisibleIndex = 2;
            this.ColTipoCliente.Width = 144;
            // 
            // ColVendedor
            // 
            this.ColVendedor.Caption = "Vendedor";
            this.ColVendedor.FieldName = "Vendedor";
            this.ColVendedor.Name = "ColVendedor";
            this.ColVendedor.OptionsColumn.AllowEdit = false;
            this.ColVendedor.OptionsColumn.ReadOnly = true;
            this.ColVendedor.Visible = true;
            this.ColVendedor.VisibleIndex = 2;
            this.ColVendedor.Width = 223;
            // 
            // ColConFlete
            // 
            this.ColConFlete.AppearanceCell.Options.UseTextOptions = true;
            this.ColConFlete.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ColConFlete.AppearanceHeader.Options.UseTextOptions = true;
            this.ColConFlete.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ColConFlete.Caption = "Condiciones Flete";
            this.ColConFlete.Name = "ColConFlete";
            this.ColConFlete.OptionsColumn.AllowEdit = false;
            this.ColConFlete.OptionsColumn.ReadOnly = true;
            this.ColConFlete.Visible = true;
            this.ColConFlete.VisibleIndex = 3;
            this.ColConFlete.Width = 140;
            // 
            // ColGastosLocales
            // 
            this.ColGastosLocales.AppearanceCell.Options.UseTextOptions = true;
            this.ColGastosLocales.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ColGastosLocales.AppearanceHeader.Options.UseTextOptions = true;
            this.ColGastosLocales.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ColGastosLocales.Caption = "Gastos Locales";
            this.ColGastosLocales.DisplayFormat.FormatString = "#,##0.00";
            this.ColGastosLocales.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ColGastosLocales.Name = "ColGastosLocales";
            this.ColGastosLocales.OptionsColumn.AllowEdit = false;
            this.ColGastosLocales.OptionsColumn.ReadOnly = true;
            this.ColGastosLocales.Visible = true;
            this.ColGastosLocales.VisibleIndex = 4;
            this.ColGastosLocales.Width = 117;
            // 
            // ColLineaCredito
            // 
            this.ColLineaCredito.AppearanceCell.Options.UseTextOptions = true;
            this.ColLineaCredito.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ColLineaCredito.AppearanceHeader.Options.UseTextOptions = true;
            this.ColLineaCredito.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ColLineaCredito.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.ColLineaCredito.Caption = "Línea Credito US$";
            this.ColLineaCredito.DisplayFormat.FormatString = "US$ #,##0.00";
            this.ColLineaCredito.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ColLineaCredito.FieldName = "MontoLineaCredito";
            this.ColLineaCredito.Name = "ColLineaCredito";
            this.ColLineaCredito.Visible = true;
            this.ColLineaCredito.VisibleIndex = 5;
            this.ColLineaCredito.Width = 126;
            // 
            // frmLineaCreditoClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 521);
            this.Controls.Add(this.grpResultado);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.toolStripBarraConsultarDeuda);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLineaCreditoClientes";
            this.Text = "Línea Crédito Clientes";
            this.Load += new System.EventHandler(this.frmLineaCreditoClientes_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLineaCreditoClientes_FormClosed);
            this.toolStripBarraConsultarDeuda.ResumeLayout(false);
            this.toolStripBarraConsultarDeuda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateHasta.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateInicio.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpResultado)).EndInit();
            this.grpResultado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLineaCredito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLineaCredito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripBarraConsultarDeuda;
        private System.Windows.Forms.ToolStripButton MenuExportar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton MenuSalir;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl grpResultado;
        private DevExpress.XtraGrid.GridControl gridLineaCredito;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLineaCredito;
        private DevExpress.XtraGrid.Columns.GridColumn ColCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn ColRut;
        private DevExpress.XtraGrid.Columns.GridColumn ColVendedor;
        private DevExpress.XtraGrid.Columns.GridColumn ColConFlete;
        private DevExpress.XtraGrid.Columns.GridColumn ColGastosLocales;
        private DevExpress.XtraGrid.Columns.GridColumn ColLineaCredito;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dateHasta;
        private DevExpress.XtraEditors.DateEdit dateInicio;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.SimpleButton sButtonBuscar;
        private DevExpress.XtraGrid.Columns.GridColumn ColTipoCliente;
    }
}