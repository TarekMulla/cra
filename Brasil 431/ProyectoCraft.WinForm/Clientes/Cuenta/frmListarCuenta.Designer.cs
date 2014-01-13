namespace ProyectoCraft.WinForm.Clientes.Cuenta
{
    partial class frmListarCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListarCuenta));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.MenuNuevoTarget = new System.Windows.Forms.ToolStripButton();
            this.MenuVerDatos = new System.Windows.Forms.ToolStripButton();
            this.MenuEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuImprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSalir = new System.Windows.Forms.ToolStripButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.grdCuentas = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lstTipoBusqueda = new DevExpress.XtraEditors.ListBoxControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboCustomers = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboVendedores = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtCustomer = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.txtVendedor = new DevExpress.XtraEditors.TextEdit();
            this.txtNombreCompania = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCuentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstTipoBusqueda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCustomers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreCompania.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(215)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1011, 39);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lista de Cuentas";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNuevoTarget,
            this.MenuVerDatos,
            this.MenuEliminar,
            this.toolStripSeparator1,
            this.MenuImprimir,
            this.toolStripSeparator2,
            this.MenuSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 39);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1011, 52);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // MenuNuevoTarget
            // 
            this.MenuNuevoTarget.Image = ((System.Drawing.Image)(resources.GetObject("MenuNuevoTarget.Image")));
            this.MenuNuevoTarget.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuNuevoTarget.Name = "MenuNuevoTarget";
            this.MenuNuevoTarget.Size = new System.Drawing.Size(76, 49);
            this.MenuNuevoTarget.Text = "Crear Cuenta";
            this.MenuNuevoTarget.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuNuevoTarget.Click += new System.EventHandler(this.MenuNuevoTarget_Click);
            // 
            // MenuVerDatos
            // 
            this.MenuVerDatos.Image = ((System.Drawing.Image)(resources.GetObject("MenuVerDatos.Image")));
            this.MenuVerDatos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuVerDatos.Name = "MenuVerDatos";
            this.MenuVerDatos.Size = new System.Drawing.Size(65, 49);
            this.MenuVerDatos.Text = "Ver Cuenta";
            this.MenuVerDatos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuVerDatos.Click += new System.EventHandler(this.MenuVerDatos_Click);
            // 
            // MenuEliminar
            // 
            this.MenuEliminar.Image = ((System.Drawing.Image)(resources.GetObject("MenuEliminar.Image")));
            this.MenuEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuEliminar.Name = "MenuEliminar";
            this.MenuEliminar.Size = new System.Drawing.Size(85, 49);
            this.MenuEliminar.Text = "Eliminar Cuenta";
            this.MenuEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuEliminar.Click += new System.EventHandler(this.MenuEliminar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 52);
            // 
            // MenuImprimir
            // 
            this.MenuImprimir.Enabled = false;
            this.MenuImprimir.Image = ((System.Drawing.Image)(resources.GetObject("MenuImprimir.Image")));
            this.MenuImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuImprimir.Name = "MenuImprimir";
            this.MenuImprimir.Size = new System.Drawing.Size(83, 49);
            this.MenuImprimir.Text = "Imprimir listado";
            this.MenuImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 52);
            // 
            // MenuSalir
            // 
            this.MenuSalir.Image = ((System.Drawing.Image)(resources.GetObject("MenuSalir.Image")));
            this.MenuSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuSalir.Name = "MenuSalir";
            this.MenuSalir.Size = new System.Drawing.Size(36, 49);
            this.MenuSalir.Text = "Salir";
            this.MenuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuSalir.Click += new System.EventHandler(this.MenuSalir_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.Controls.Add(this.grdCuentas);
            this.groupControl3.Location = new System.Drawing.Point(3, 226);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(1006, 277);
            this.groupControl3.TabIndex = 6;
            this.groupControl3.Text = "Resultado de busqueda";
            // 
            // grdCuentas
            // 
            this.grdCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCuentas.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grdCuentas.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.grdCuentas.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grdCuentas.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.grdCuentas.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grdCuentas.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.grdCuentas.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grdCuentas.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.grdCuentas.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gridLevelNode1.RelationName = "Level1";
            this.grdCuentas.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdCuentas.Location = new System.Drawing.Point(2, 20);
            this.grdCuentas.MainView = this.gridView1;
            this.grdCuentas.Name = "grdCuentas";
            this.grdCuentas.Size = new System.Drawing.Size(999, 236);
            this.grdCuentas.TabIndex = 0;
            this.grdCuentas.UseEmbeddedNavigator = true;
            this.grdCuentas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn10,
            this.gridColumn8,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn9,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn7});
            this.gridView1.GridControl = this.grdCuentas;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", this.gridColumn1, "")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Nombre Compañia";
            this.gridColumn1.FieldName = "ClienteMaster.NombreCompañia";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 180;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Nombre Fantasia";
            this.gridColumn10.FieldName = "ClienteMaster.NombreFantasia";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            this.gridColumn10.Width = 96;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "RUT";
            this.gridColumn8.FieldName = "ClienteMaster.RUT";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 2;
            this.gridColumn8.Width = 77;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Telefono";
            this.gridColumn2.FieldName = "Telefono";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Cuenta Skype";
            this.gridColumn3.FieldName = "CuentaSkype";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Width = 116;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Email";
            this.gridColumn9.FieldName = "Email";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            this.gridColumn9.Width = 136;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Sitio Web";
            this.gridColumn4.FieldName = "SitioWeb";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Width = 110;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Vendedor Asignado";
            this.gridColumn5.FieldName = "VendedorAsignado.NombreCompleto";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 157;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Estado";
            this.gridColumn7.FieldName = "Estado";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 105;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.lstTipoBusqueda);
            this.groupControl2.Location = new System.Drawing.Point(546, 95);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(463, 130);
            this.groupControl2.TabIndex = 8;
            this.groupControl2.Text = "Busquedas Predeterminadas";
            // 
            // lstTipoBusqueda
            // 
            this.lstTipoBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTipoBusqueda.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTipoBusqueda.Appearance.Options.UseFont = true;
            this.lstTipoBusqueda.Items.AddRange(new object[] {
            "Todos",
            "Cuentas Habilitadas",
            "Cuentas Deshabilitadas",
            "Mis Cuentas"});
            this.lstTipoBusqueda.Location = new System.Drawing.Point(5, 23);
            this.lstTipoBusqueda.Name = "lstTipoBusqueda";
            this.lstTipoBusqueda.Size = new System.Drawing.Size(453, 101);
            this.lstTipoBusqueda.TabIndex = 0;
            this.lstTipoBusqueda.Click += new System.EventHandler(this.lstTipoBusqueda_Click);
            this.lstTipoBusqueda.SelectedIndexChanged += new System.EventHandler(this.lstTipoBusqueda_SelectedIndexChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl1.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.BackColor = System.Drawing.Color.White;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseBackColor = true;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.cboCustomers);
            this.groupControl1.Controls.Add(this.cboVendedores);
            this.groupControl1.Controls.Add(this.txtCustomer);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.btnBuscar);
            this.groupControl1.Controls.Add(this.txtVendedor);
            this.groupControl1.Controls.Add(this.txtNombreCompania);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(3, 94);
            this.groupControl1.LookAndFeel.SkinName = "Glass Oceans";
            this.groupControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(542, 131);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "Busqueda";
            // 
            // cboCustomers
            // 
            this.cboCustomers.Location = new System.Drawing.Point(498, 77);
            this.cboCustomers.Name = "cboCustomers";
            this.cboCustomers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCustomers.Size = new System.Drawing.Size(44, 20);
            this.cboCustomers.TabIndex = 6;
            this.cboCustomers.Visible = false;
            // 
            // cboVendedores
            // 
            this.cboVendedores.Location = new System.Drawing.Point(498, 51);
            this.cboVendedores.Name = "cboVendedores";
            this.cboVendedores.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboVendedores.Size = new System.Drawing.Size(44, 20);
            this.cboVendedores.TabIndex = 6;
            this.cboVendedores.Visible = false;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCustomer.Location = new System.Drawing.Point(135, 79);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.Properties.Appearance.Options.UseFont = true;
            this.txtCustomer.Size = new System.Drawing.Size(357, 20);
            this.txtCustomer.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(5, 85);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(112, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Customer Asignado";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscar.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnBuscar.Appearance.Options.UseFont = true;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(430, 103);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(91, 22);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtVendedor
            // 
            this.txtVendedor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtVendedor.Location = new System.Drawing.Point(135, 55);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendedor.Properties.Appearance.Options.UseFont = true;
            this.txtVendedor.Size = new System.Drawing.Size(357, 20);
            this.txtVendedor.TabIndex = 2;
            // 
            // txtNombreCompania
            // 
            this.txtNombreCompania.Location = new System.Drawing.Point(135, 30);
            this.txtNombreCompania.Name = "txtNombreCompania";
            this.txtNombreCompania.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCompania.Properties.Appearance.Options.UseFont = true;
            this.txtNombreCompania.Size = new System.Drawing.Size(357, 20);
            this.txtNombreCompania.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(5, 33);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(107, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Nombre Compañia";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(5, 61);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(111, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Vendedor Asignado";
            // 
            // frmListarCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1011, 488);
            this.ControlBox = false;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "frmListarCuenta";
            this.Load += new System.EventHandler(this.frmListarCuenta_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListarCuenta_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCuentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstTipoBusqueda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCustomers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreCompania.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton MenuNuevoTarget;
        private System.Windows.Forms.ToolStripButton MenuVerDatos;
        private System.Windows.Forms.ToolStripButton MenuEliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton MenuImprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton MenuSalir;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl grdCuentas;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.ListBoxControl lstTipoBusqueda;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtVendedor;
        private DevExpress.XtraEditors.TextEdit txtNombreCompania;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.TextEdit txtCustomer;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cboCustomers;
        private DevExpress.XtraEditors.ComboBoxEdit cboVendedores;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
    }
}