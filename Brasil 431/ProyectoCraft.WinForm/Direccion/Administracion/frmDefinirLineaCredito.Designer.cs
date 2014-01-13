namespace ProyectoCraft.WinForm.Direccion.Administracion
{
    partial class frmDefinirLineaCredito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDefinirLineaCredito));
            this.toolStripBarraLlamada = new System.Windows.Forms.ToolStrip();
            this.MenuSalir = new System.Windows.Forms.ToolStripButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.btnNueva = new DevExpress.XtraEditors.SimpleButton();
            this.cboCategoria = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboMoneda = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnAgregar = new DevExpress.XtraEditors.SimpleButton();
            this.txtMonto = new DevExpress.XtraEditors.TextEdit();
            this.cboCuenta = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl33 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl29 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl28 = new DevExpress.XtraEditors.LabelControl();
            this.grpResultado = new DevExpress.XtraEditors.GroupControl();
            this.gridLineaCredito = new DevExpress.XtraGrid.GridControl();
            this.gridViewLineaCredito = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCategoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridMoneda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridMontoCredito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ctrldxError = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.toolStripBarraLlamada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCategoria.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCuenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpResultado)).BeginInit();
            this.grpResultado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLineaCredito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLineaCredito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrldxError)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripBarraLlamada
            // 
            this.toolStripBarraLlamada.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuSalir});
            this.toolStripBarraLlamada.Location = new System.Drawing.Point(0, 0);
            this.toolStripBarraLlamada.Name = "toolStripBarraLlamada";
            this.toolStripBarraLlamada.Size = new System.Drawing.Size(1019, 36);
            this.toolStripBarraLlamada.TabIndex = 5;
            this.toolStripBarraLlamada.Text = "toolStrip1";
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
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.txtId);
            this.groupControl3.Controls.Add(this.btnNueva);
            this.groupControl3.Controls.Add(this.cboCategoria);
            this.groupControl3.Controls.Add(this.labelControl1);
            this.groupControl3.Controls.Add(this.cboMoneda);
            this.groupControl3.Controls.Add(this.btnAgregar);
            this.groupControl3.Controls.Add(this.txtMonto);
            this.groupControl3.Controls.Add(this.cboCuenta);
            this.groupControl3.Controls.Add(this.labelControl33);
            this.groupControl3.Controls.Add(this.labelControl29);
            this.groupControl3.Controls.Add(this.labelControl28);
            this.groupControl3.Location = new System.Drawing.Point(6, 39);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(1007, 60);
            this.groupControl3.TabIndex = 6;
            this.groupControl3.Text = "Datos Línea Crédito";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(968, 27);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(29, 20);
            this.txtId.TabIndex = 35;
            this.txtId.Visible = false;
            // 
            // btnNueva
            // 
            this.btnNueva.Image = ((System.Drawing.Image)(resources.GetObject("btnNueva.Image")));
            this.btnNueva.Location = new System.Drawing.Point(890, 26);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(72, 24);
            this.btnNueva.TabIndex = 5;
            this.btnNueva.Text = "Nueva";
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // cboCategoria
            // 
            this.cboCategoria.Enabled = false;
            this.cboCategoria.Location = new System.Drawing.Point(364, 27);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCategoria.Size = new System.Drawing.Size(85, 20);
            this.cboCategoria.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(307, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 13);
            this.labelControl1.TabIndex = 33;
            this.labelControl1.Text = "Categoría:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.EnterMoveNextControl = true;
            this.cboMoneda.Location = new System.Drawing.Point(503, 27);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMoneda.Size = new System.Drawing.Size(85, 20);
            this.cboMoneda.TabIndex = 2;
            this.cboMoneda.SelectedIndexChanged += new System.EventHandler(this.cboMoneda_SelectedIndexChanged);
            this.cboMoneda.Enter += new System.EventHandler(this.cboMoneda_Enter);
            this.cboMoneda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMoneda_KeyPress);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(812, 26);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(72, 24);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtMonto
            // 
            this.txtMonto.EnterMoveNextControl = true;
            this.txtMonto.Location = new System.Drawing.Point(672, 27);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Properties.Appearance.Options.UseTextOptions = true;
            this.txtMonto.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtMonto.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txtMonto.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMonto.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMonto.Properties.HideSelection = false;
            this.txtMonto.Properties.Mask.EditMask = "######,##0.00";
            this.txtMonto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMonto.Size = new System.Drawing.Size(91, 20);
            this.txtMonto.TabIndex = 3;
            this.txtMonto.EditValueChanged += new System.EventHandler(this.txtMonto_EditValueChanged);
            this.txtMonto.Enter += new System.EventHandler(this.txtMonto_Enter);
            // 
            // cboCuenta
            // 
            this.cboCuenta.EnterMoveNextControl = true;
            this.cboCuenta.Location = new System.Drawing.Point(50, 27);
            this.cboCuenta.Name = "cboCuenta";
            this.cboCuenta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCuenta.Size = new System.Drawing.Size(251, 20);
            this.cboCuenta.TabIndex = 0;
            this.cboCuenta.SelectedIndexChanged += new System.EventHandler(this.cboCuenta_SelectedIndexChanged);
            this.cboCuenta.Enter += new System.EventHandler(this.cboCuenta_Enter);
            this.cboCuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboCuenta_KeyPress);
            // 
            // labelControl33
            // 
            this.labelControl33.Location = new System.Drawing.Point(594, 30);
            this.labelControl33.Name = "labelControl33";
            this.labelControl33.Size = new System.Drawing.Size(72, 13);
            this.labelControl33.TabIndex = 5;
            this.labelControl33.Text = "Monto Crédito:";
            // 
            // labelControl29
            // 
            this.labelControl29.Location = new System.Drawing.Point(455, 30);
            this.labelControl29.Name = "labelControl29";
            this.labelControl29.Size = new System.Drawing.Size(42, 13);
            this.labelControl29.TabIndex = 1;
            this.labelControl29.Text = "Moneda:";
            // 
            // labelControl28
            // 
            this.labelControl28.Location = new System.Drawing.Point(5, 30);
            this.labelControl28.Name = "labelControl28";
            this.labelControl28.Size = new System.Drawing.Size(39, 13);
            this.labelControl28.TabIndex = 0;
            this.labelControl28.Text = "Cuenta:";
            // 
            // grpResultado
            // 
            this.grpResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResultado.AppearanceCaption.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpResultado.AppearanceCaption.Options.UseFont = true;
            this.grpResultado.Controls.Add(this.gridLineaCredito);
            this.grpResultado.Location = new System.Drawing.Point(6, 105);
            this.grpResultado.Name = "grpResultado";
            this.grpResultado.Size = new System.Drawing.Size(1007, 411);
            this.grpResultado.TabIndex = 12;
            this.grpResultado.Text = "Línea Crédito Cuentas";
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
            this.gridLineaCredito.DoubleClick += new System.EventHandler(this.gridLineaCredito_DoubleClick);
            this.gridLineaCredito.Click += new System.EventHandler(this.gridLineaCredito_Click);
            // 
            // gridViewLineaCredito
            // 
            this.gridViewLineaCredito.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridId,
            this.gridCategoria,
            this.gridCuenta,
            this.gridMoneda,
            this.gridMontoCredito});
            this.gridViewLineaCredito.GridControl = this.gridLineaCredito;
            this.gridViewLineaCredito.Name = "gridViewLineaCredito";
            this.gridViewLineaCredito.OptionsBehavior.Editable = false;
            this.gridViewLineaCredito.OptionsView.ShowAutoFilterRow = true;
            // 
            // gridId
            // 
            this.gridId.Caption = "Id";
            this.gridId.FieldName = "Id";
            this.gridId.Name = "gridId";
            this.gridId.OptionsColumn.AllowEdit = false;
            this.gridId.OptionsColumn.ReadOnly = true;
            this.gridId.Visible = true;
            this.gridId.VisibleIndex = 0;
            this.gridId.Width = 99;
            // 
            // gridCategoria
            // 
            this.gridCategoria.Caption = "Categoría";
            this.gridCategoria.FieldName = "ObjCuentaClasificacion.Nombre";
            this.gridCategoria.Name = "gridCategoria";
            this.gridCategoria.OptionsColumn.AllowEdit = false;
            this.gridCategoria.Visible = true;
            this.gridCategoria.VisibleIndex = 1;
            this.gridCategoria.Width = 148;
            // 
            // gridCuenta
            // 
            this.gridCuenta.Caption = "Cuenta";
            this.gridCuenta.FieldName = "ObjCuenta.NombreCompañia";
            this.gridCuenta.Name = "gridCuenta";
            this.gridCuenta.OptionsColumn.AllowEdit = false;
            this.gridCuenta.OptionsColumn.ReadOnly = true;
            this.gridCuenta.Visible = true;
            this.gridCuenta.VisibleIndex = 2;
            this.gridCuenta.Width = 470;
            // 
            // gridMoneda
            // 
            this.gridMoneda.Caption = "Moneda";
            this.gridMoneda.FieldName = "ObjMoneda.Codigo";
            this.gridMoneda.Name = "gridMoneda";
            this.gridMoneda.OptionsColumn.AllowEdit = false;
            this.gridMoneda.OptionsColumn.ReadOnly = true;
            this.gridMoneda.Visible = true;
            this.gridMoneda.VisibleIndex = 3;
            this.gridMoneda.Width = 197;
            // 
            // gridMontoCredito
            // 
            this.gridMontoCredito.AppearanceHeader.Options.UseTextOptions = true;
            this.gridMontoCredito.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridMontoCredito.Caption = "Monto Crédito";
            this.gridMontoCredito.DisplayFormat.FormatString = "#,##0.00";
            this.gridMontoCredito.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridMontoCredito.FieldName = "MontoLineaCredito";
            this.gridMontoCredito.Name = "gridMontoCredito";
            this.gridMontoCredito.OptionsColumn.AllowEdit = false;
            this.gridMontoCredito.OptionsColumn.ReadOnly = true;
            this.gridMontoCredito.Visible = true;
            this.gridMontoCredito.VisibleIndex = 4;
            this.gridMontoCredito.Width = 174;
            // 
            // ctrldxError
            // 
            this.ctrldxError.ContainerControl = this;
            // 
            // frmDefinirLineaCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 521);
            this.Controls.Add(this.grpResultado);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.toolStripBarraLlamada);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDefinirLineaCredito";
            this.Text = "Definir Línea de Crédito";
            this.Load += new System.EventHandler(this.frmDefinirLineaCredito_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDefinirLineaCredito_FormClosed);
            this.toolStripBarraLlamada.ResumeLayout(false);
            this.toolStripBarraLlamada.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCategoria.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCuenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpResultado)).EndInit();
            this.grpResultado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLineaCredito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLineaCredito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrldxError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripBarraLlamada;
        private System.Windows.Forms.ToolStripButton MenuSalir;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton btnAgregar;
        private DevExpress.XtraEditors.TextEdit txtMonto;
        private DevExpress.XtraEditors.ComboBoxEdit cboCuenta;
        private DevExpress.XtraEditors.LabelControl labelControl33;
        private DevExpress.XtraEditors.LabelControl labelControl29;
        private DevExpress.XtraEditors.LabelControl labelControl28;
        private DevExpress.XtraEditors.GroupControl grpResultado;
        private DevExpress.XtraGrid.GridControl gridLineaCredito;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLineaCredito;
        private DevExpress.XtraGrid.Columns.GridColumn gridId;
        private DevExpress.XtraGrid.Columns.GridColumn gridMontoCredito;
        private DevExpress.XtraGrid.Columns.GridColumn gridMoneda;
        private DevExpress.XtraGrid.Columns.GridColumn gridCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn gridCategoria;
        private DevExpress.XtraEditors.ComboBoxEdit cboMoneda;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboCategoria;
        private DevExpress.XtraEditors.SimpleButton btnNueva;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider ctrldxError;
        private DevExpress.XtraEditors.TextEdit txtId;

    }
}