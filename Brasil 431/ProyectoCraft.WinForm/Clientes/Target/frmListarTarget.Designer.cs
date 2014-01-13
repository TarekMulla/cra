namespace ProyectoCraft.WinForm.Clientes.Target
{
    partial class frmListarTarget
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListarTarget));
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboVendedores = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnBuscarTargets = new DevExpress.XtraEditors.SimpleButton();
            this.txtVendedor = new DevExpress.XtraEditors.TextEdit();
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lstTipoBusqueda = new DevExpress.XtraEditors.ListBoxControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.grdListaTarget = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstTipoBusqueda)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdListaTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(215)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(842, 39);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listado de Targets";
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
            this.toolStrip1.Size = new System.Drawing.Size(842, 52);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // MenuNuevoTarget
            // 
            this.MenuNuevoTarget.Image = ((System.Drawing.Image)(resources.GetObject("MenuNuevoTarget.Image")));
            this.MenuNuevoTarget.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuNuevoTarget.Name = "MenuNuevoTarget";
            this.MenuNuevoTarget.Size = new System.Drawing.Size(77, 49);
            this.MenuNuevoTarget.Text = "Nuevo Target";
            this.MenuNuevoTarget.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuNuevoTarget.Click += new System.EventHandler(this.MenuNuevoTarget_Click);
            // 
            // MenuVerDatos
            // 
            this.MenuVerDatos.Image = ((System.Drawing.Image)(resources.GetObject("MenuVerDatos.Image")));
            this.MenuVerDatos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuVerDatos.Name = "MenuVerDatos";
            this.MenuVerDatos.Size = new System.Drawing.Size(57, 49);
            this.MenuVerDatos.Text = "Ver datos";
            this.MenuVerDatos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuVerDatos.Click += new System.EventHandler(this.MenuVerDatos_Click);
            // 
            // MenuEliminar
            // 
            this.MenuEliminar.Image = ((System.Drawing.Image)(resources.GetObject("MenuEliminar.Image")));
            this.MenuEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuEliminar.Name = "MenuEliminar";
            this.MenuEliminar.Size = new System.Drawing.Size(82, 49);
            this.MenuEliminar.Text = "Eliminar Target";
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
            this.groupControl1.Controls.Add(this.cboVendedores);
            this.groupControl1.Controls.Add(this.btnBuscarTargets);
            this.groupControl1.Controls.Add(this.txtVendedor);
            this.groupControl1.Controls.Add(this.txtNombre);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.LookAndFeel.SkinName = "Glass Oceans";
            this.groupControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(415, 103);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Busqueda";
            // 
            // cboVendedores
            // 
            this.cboVendedores.Location = new System.Drawing.Point(341, 47);
            this.cboVendedores.Name = "cboVendedores";
            this.cboVendedores.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboVendedores.Size = new System.Drawing.Size(48, 20);
            this.cboVendedores.TabIndex = 4;
            this.cboVendedores.Visible = false;
            // 
            // btnBuscarTargets
            // 
            this.btnBuscarTargets.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscarTargets.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarTargets.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnBuscarTargets.Appearance.Options.UseFont = true;
            this.btnBuscarTargets.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarTargets.Image")));
            this.btnBuscarTargets.Location = new System.Drawing.Point(313, 73);
            this.btnBuscarTargets.Name = "btnBuscarTargets";
            this.btnBuscarTargets.Size = new System.Drawing.Size(91, 22);
            this.btnBuscarTargets.TabIndex = 3;
            this.btnBuscarTargets.Text = "Buscar";
            this.btnBuscarTargets.Click += new System.EventHandler(this.btnBuscarTargets_Click);
            // 
            // txtVendedor
            // 
            this.txtVendedor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtVendedor.Location = new System.Drawing.Point(135, 49);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendedor.Properties.Appearance.Options.UseFont = true;
            this.txtVendedor.Size = new System.Drawing.Size(200, 20);
            this.txtVendedor.TabIndex = 2;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(135, 26);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Properties.Appearance.Options.UseFont = true;
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(5, 33);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Nombre";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(5, 56);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(111, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Vendedor Asignado";
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.lstTipoBusqueda);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(424, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(415, 103);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Busquedas Predeterminadas";
            // 
            // lstTipoBusqueda
            // 
            this.lstTipoBusqueda.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTipoBusqueda.Appearance.Options.UseFont = true;
            this.lstTipoBusqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTipoBusqueda.Items.AddRange(new object[] {
            "Todos",
            "Targets Habilitados",
            "Targets Calificados",
            "Targets Descalificados",
            "Mis Targets"});
            this.lstTipoBusqueda.Location = new System.Drawing.Point(2, 20);
            this.lstTipoBusqueda.Name = "lstTipoBusqueda";
            this.lstTipoBusqueda.Size = new System.Drawing.Size(411, 81);
            this.lstTipoBusqueda.TabIndex = 0;
            this.lstTipoBusqueda.SelectedIndexChanged += new System.EventHandler(this.lstTipoBusqueda_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 91);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(842, 109);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // groupControl3
            // 
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.Controls.Add(this.grdListaTarget);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 200);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(842, 296);
            this.groupControl3.TabIndex = 5;
            this.groupControl3.Text = "Resultado de busqueda";
            // 
            // grdListaTarget
            // 
            this.grdListaTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdListaTarget.EmbeddedNavigator.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.grdListaTarget.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grdListaTarget.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.grdListaTarget.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grdListaTarget.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.grdListaTarget.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grdListaTarget.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.grdListaTarget.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grdListaTarget.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.grdListaTarget.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grdListaTarget.Location = new System.Drawing.Point(2, 20);
            this.grdListaTarget.MainView = this.gridView1;
            this.grdListaTarget.Name = "grdListaTarget";
            this.grdListaTarget.Size = new System.Drawing.Size(838, 274);
            this.grdListaTarget.TabIndex = 0;
            this.grdListaTarget.UseEmbeddedNavigator = true;
            this.grdListaTarget.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn13});
            this.gridView1.GridControl = this.grdListaTarget;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", this.gridColumn1, "")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Nombre Compañia";
            this.gridColumn1.FieldName = "ClienteMaster.NombreCompañia";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 102;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Nombres";
            this.gridColumn10.FieldName = "ClienteMaster.Nombres";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            this.gridColumn10.Width = 78;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Ap. Paterno";
            this.gridColumn11.FieldName = "ClienteMaster.ApellidoPaterno";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            this.gridColumn11.Width = 78;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Ap. Materno";
            this.gridColumn12.FieldName = "ClienteMaster.ApellidoMaterno";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 3;
            this.gridColumn12.Width = 78;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Telefono";
            this.gridColumn2.FieldName = "Telefono";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 78;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Email";
            this.gridColumn3.FieldName = "Email";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 78;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Vendedor";
            this.gridColumn4.FieldName = "VendedorAsignado";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            this.gridColumn4.Width = 78;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Contacto";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Width = 78;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Empresa Actual";
            this.gridColumn6.FieldName = "EmpresaConQueTrabaja.Nombre";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            this.gridColumn6.Width = 78;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Origen carga";
            this.gridColumn7.FieldName = "OrigenCarga.Nombre";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 8;
            this.gridColumn7.Width = 91;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "IdMaster";
            this.gridColumn8.FieldName = "IdMaster";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "IdTarget";
            this.gridColumn9.FieldName = "Id";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Estado";
            this.gridColumn13.FieldName = "Estado";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 9;
            // 
            // frmListarTarget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(842, 496);
            this.ControlBox = false;
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "frmListarTarget";
            this.Load += new System.EventHandler(this.frmListarTarget_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstTipoBusqueda)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdListaTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtVendedor;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraEditors.SimpleButton btnBuscarTargets;
        private DevExpress.XtraEditors.ListBoxControl lstTipoBusqueda;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl grdListaTarget;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.ComboBoxEdit cboVendedores;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;

    }
}