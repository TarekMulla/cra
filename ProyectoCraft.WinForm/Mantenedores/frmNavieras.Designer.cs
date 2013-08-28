namespace ProyectoCraft.WinForm.Clientes
{
    partial class frmNavieras
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNavieras));
            this.grdNavieras = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.toolStripBarraListarLlamada = new System.Windows.Forms.ToolStrip();
            this.Menu_Nuevo = new System.Windows.Forms.ToolStripButton();
            this.MenuGuardar = new System.Windows.Forms.ToolStripButton();
            this.MenuVerDatos = new System.Windows.Forms.ToolStripButton();
            this.MenuEliminar = new System.Windows.Forms.ToolStripButton();
            this.MenuImprimirListado = new System.Windows.Forms.ToolStripButton();
            this.MenuExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSalir = new System.Windows.Forms.ToolStripButton();
            this.ListPuertoSeleccionado = new DevExpress.XtraEditors.ListBoxControl();
            this.ListaPuertos = new DevExpress.XtraEditors.ListBoxControl();
            this.RemovePol = new DevExpress.XtraEditors.SimpleButton();
            this.AddPuertoSeleccionado = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdNavieras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            this.toolStripBarraListarLlamada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListPuertoSeleccionado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListaPuertos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdNavieras
            // 
            this.grdNavieras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdNavieras.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grdNavieras.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.grdNavieras.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grdNavieras.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.grdNavieras.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grdNavieras.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.grdNavieras.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grdNavieras.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.grdNavieras.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gridLevelNode1.RelationName = "Level1";
            this.grdNavieras.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdNavieras.Location = new System.Drawing.Point(0, 139);
            this.grdNavieras.MainView = this.gridView1;
            this.grdNavieras.Name = "grdNavieras";
            this.grdNavieras.Size = new System.Drawing.Size(413, 364);
            this.grdNavieras.TabIndex = 4;
            this.grdNavieras.UseEmbeddedNavigator = true;
            this.grdNavieras.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn2});
            this.gridView1.GridControl = this.grdNavieras;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", this.gridColumn1, "")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 32;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Nombre";
            this.gridColumn5.FieldName = "Nombre";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 197;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Estado";
            this.gridColumn7.FieldName = "Activo";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 67;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Fecha Creacion";
            this.gridColumn2.FieldName = "FechaCreacion";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 96;
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
            this.groupControl1.Controls.Add(this.txtId);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.btnBuscar);
            this.groupControl1.Controls.Add(this.txtNombre);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Location = new System.Drawing.Point(0, 41);
            this.groupControl1.LookAndFeel.SkinName = "Glass Oceans";
            this.groupControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(612, 92);
            this.groupControl1.TabIndex = 8;
            this.groupControl1.Text = "Busqueda";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(135, 58);
            this.txtId.Name = "txtId";
            this.txtId.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Properties.Appearance.Options.UseFont = true;
            this.txtId.Size = new System.Drawing.Size(198, 20);
            this.txtId.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(5, 61);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(12, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Id";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscar.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnBuscar.Appearance.Options.UseFont = true;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(360, 28);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(91, 22);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(135, 30);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Properties.Appearance.Options.UseFont = true;
            this.txtNombre.Size = new System.Drawing.Size(198, 20);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.EditValueChanged += new System.EventHandler(this.txtNombre_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(5, 33);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(93, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Nombre Naviera";
            // 
            // toolStripBarraListarLlamada
            // 
            this.toolStripBarraListarLlamada.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Nuevo,
            this.MenuGuardar,
            this.MenuVerDatos,
            this.MenuEliminar,
            this.MenuImprimirListado,
            this.MenuExcel,
            this.toolStripSeparator2,
            this.MenuSalir});
            this.toolStripBarraListarLlamada.Location = new System.Drawing.Point(0, 0);
            this.toolStripBarraListarLlamada.Name = "toolStripBarraListarLlamada";
            this.toolStripBarraListarLlamada.Size = new System.Drawing.Size(832, 38);
            this.toolStripBarraListarLlamada.TabIndex = 10;
            this.toolStripBarraListarLlamada.Text = "toolStrip1";
            // 
            // Menu_Nuevo
            // 
            this.Menu_Nuevo.Image = ((System.Drawing.Image)(resources.GetObject("Menu_Nuevo.Image")));
            this.Menu_Nuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Menu_Nuevo.Name = "Menu_Nuevo";
            this.Menu_Nuevo.Size = new System.Drawing.Size(46, 35);
            this.Menu_Nuevo.Text = "Nuevo";
            this.Menu_Nuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Menu_Nuevo.Click += new System.EventHandler(this.Menu_Nuevo_Click_1);
            // 
            // MenuGuardar
            // 
            this.MenuGuardar.Image = ((System.Drawing.Image)(resources.GetObject("MenuGuardar.Image")));
            this.MenuGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuGuardar.Name = "MenuGuardar";
            this.MenuGuardar.Size = new System.Drawing.Size(53, 35);
            this.MenuGuardar.Text = "Guardar";
            this.MenuGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuGuardar.Click += new System.EventHandler(this.MenuGuardar_Click_1);
            // 
            // MenuVerDatos
            // 
            this.MenuVerDatos.Image = ((System.Drawing.Image)(resources.GetObject("MenuVerDatos.Image")));
            this.MenuVerDatos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuVerDatos.Name = "MenuVerDatos";
            this.MenuVerDatos.Size = new System.Drawing.Size(41, 35);
            this.MenuVerDatos.Text = "Editar";
            this.MenuVerDatos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuVerDatos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuVerDatos.ToolTipText = "Editar";
            this.MenuVerDatos.Click += new System.EventHandler(this.MenuVerDatos_Click_1);
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
            this.MenuEliminar.Click += new System.EventHandler(this.MenuEliminar_Click_1);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // MenuSalir
            // 
            this.MenuSalir.Image = ((System.Drawing.Image)(resources.GetObject("MenuSalir.Image")));
            this.MenuSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuSalir.Name = "MenuSalir";
            this.MenuSalir.Size = new System.Drawing.Size(33, 35);
            this.MenuSalir.Text = "Salir";
            this.MenuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuSalir.Click += new System.EventHandler(this.MenuSalir_Click_1);
            // 
            // ListPuertoSeleccionado
            // 
            this.ListPuertoSeleccionado.Location = new System.Drawing.Point(188, 37);
            this.ListPuertoSeleccionado.Name = "ListPuertoSeleccionado";
            this.ListPuertoSeleccionado.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListPuertoSeleccionado.Size = new System.Drawing.Size(104, 324);
            this.ListPuertoSeleccionado.TabIndex = 129;
            // 
            // ListaPuertos
            // 
            this.ListaPuertos.Appearance.ForeColor = System.Drawing.Color.Black;
            this.ListaPuertos.Appearance.Options.UseForeColor = true;
            this.ListaPuertos.Location = new System.Drawing.Point(13, 37);
            this.ListaPuertos.Name = "ListaPuertos";
            this.ListaPuertos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListaPuertos.Size = new System.Drawing.Size(104, 324);
            this.ListaPuertos.TabIndex = 128;
            // 
            // RemovePol
            // 
            this.RemovePol.Location = new System.Drawing.Point(134, 229);
            this.RemovePol.Name = "RemovePol";
            this.RemovePol.Size = new System.Drawing.Size(40, 23);
            this.RemovePol.TabIndex = 131;
            this.RemovePol.Text = "<<";
            this.RemovePol.Click += new System.EventHandler(this.RemovePol_Click_1);
            // 
            // AddPuertoSeleccionado
            // 
            this.AddPuertoSeleccionado.Location = new System.Drawing.Point(134, 185);
            this.AddPuertoSeleccionado.Name = "AddPuertoSeleccionado";
            this.AddPuertoSeleccionado.Size = new System.Drawing.Size(40, 23);
            this.AddPuertoSeleccionado.TabIndex = 130;
            this.AddPuertoSeleccionado.Text = ">>";
            this.AddPuertoSeleccionado.Click += new System.EventHandler(this.AddPolClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ListaPuertos);
            this.panel1.Controls.Add(this.RemovePol);
            this.panel1.Controls.Add(this.ListPuertoSeleccionado);
            this.panel1.Controls.Add(this.AddPuertoSeleccionado);
            this.panel1.Location = new System.Drawing.Point(419, 139);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 364);
            this.panel1.TabIndex = 133;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 132;
            this.label1.Text = "Puertos No seleccionados";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 133;
            this.label2.Text = "Puertos Seleccionados";
            // 
            // frmNavieras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(832, 506);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStripBarraListarLlamada);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.grdNavieras);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNavieras";
            this.Text = "Mantenedor Navieras";
            this.Load += new System.EventHandler(this.frmNavieras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdNavieras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
            this.toolStripBarraListarLlamada.ResumeLayout(false);
            this.toolStripBarraListarLlamada.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListPuertoSeleccionado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListaPuertos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdNavieras;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtId;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ToolStrip toolStripBarraListarLlamada;
        private System.Windows.Forms.ToolStripButton Menu_Nuevo;
        private System.Windows.Forms.ToolStripButton MenuGuardar;
        private System.Windows.Forms.ToolStripButton MenuVerDatos;
        private System.Windows.Forms.ToolStripButton MenuEliminar;
        private System.Windows.Forms.ToolStripButton MenuImprimirListado;
        private System.Windows.Forms.ToolStripButton MenuExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton MenuSalir;
        private DevExpress.XtraEditors.ListBoxControl ListPuertoSeleccionado;
        private DevExpress.XtraEditors.ListBoxControl ListaPuertos;
        private DevExpress.XtraEditors.SimpleButton RemovePol;
        private DevExpress.XtraEditors.SimpleButton AddPuertoSeleccionado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

    }
}