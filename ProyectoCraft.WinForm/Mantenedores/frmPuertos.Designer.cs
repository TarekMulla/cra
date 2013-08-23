namespace SCCMultimodal.Mantenedores {
    partial class frmPuertos {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPuertos));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.MenuGuardar = new System.Windows.Forms.ToolStripButton();
            this.grdComunas = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.MenuVerDatos = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.MenuEliminar = new System.Windows.Forms.ToolStripButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuExcel = new System.Windows.Forms.ToolStripButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.MenuImprimirListado = new System.Windows.Forms.ToolStripButton();
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            this.toolStripBarraListarLlamada = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPais = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdComunas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            this.toolStripBarraListarLlamada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPais.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuGuardar
            // 
            this.MenuGuardar.Image = ((System.Drawing.Image)(resources.GetObject("MenuGuardar.Image")));
            this.MenuGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuGuardar.Name = "MenuGuardar";
            this.MenuGuardar.Size = new System.Drawing.Size(53, 35);
            this.MenuGuardar.Text = "Guardar";
            this.MenuGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuGuardar.Click += new System.EventHandler(this.MenuGuardar_Click);
            // 
            // grdComunas
            // 
            this.grdComunas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdComunas.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grdComunas.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.grdComunas.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grdComunas.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.grdComunas.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grdComunas.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.grdComunas.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grdComunas.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.grdComunas.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gridLevelNode2.RelationName = "Level1";
            this.grdComunas.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.grdComunas.Location = new System.Drawing.Point(0, 170);
            this.grdComunas.MainView = this.gridView1;
            this.grdComunas.Name = "grdComunas";
            this.grdComunas.Size = new System.Drawing.Size(476, 297);
            this.grdComunas.TabIndex = 10;
            this.grdComunas.UseEmbeddedNavigator = true;
            this.grdComunas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn2});
            this.gridView1.GridControl = this.grdComunas;
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
            this.gridColumn1.Width = 49;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Nombre";
            this.gridColumn5.FieldName = "Nombre";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 371;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Ciudad";
            this.gridColumn7.FieldName = "Ciudad";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 123;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Pais";
            this.gridColumn2.FieldName = "Ciudad.Pais.Nombre";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 108;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(75, 30);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Properties.Appearance.Options.UseFont = true;
            this.txtCodigo.Size = new System.Drawing.Size(231, 20);
            this.txtCodigo.TabIndex = 36;
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
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(46, 35);
            this.toolStripButton2.Text = "Nuevo";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click_1);
            // 
            // MenuEliminar
            // 
            this.MenuEliminar.Enabled = false;
            this.MenuEliminar.Image = ((System.Drawing.Image)(resources.GetObject("MenuEliminar.Image")));
            this.MenuEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuEliminar.Name = "MenuEliminar";
            this.MenuEliminar.Size = new System.Drawing.Size(54, 35);
            this.MenuEliminar.Text = "Eliminar";
            this.MenuEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuEliminar.ToolTipText = "Eliminar";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(5, 84);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(19, 13);
            this.labelControl3.TabIndex = 35;
            this.labelControl3.Text = "Pais";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
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
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 59);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "Nombre";
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
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(75, 55);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Properties.Appearance.Options.UseFont = true;
            this.txtNombre.Size = new System.Drawing.Size(231, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // toolStripBarraListarLlamada
            // 
            this.toolStripBarraListarLlamada.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.MenuGuardar,
            this.MenuVerDatos,
            this.MenuEliminar,
            this.MenuImprimirListado,
            this.MenuExcel,
            this.toolStripSeparator2,
            this.toolStripButton1});
            this.toolStripBarraListarLlamada.Location = new System.Drawing.Point(0, 0);
            this.toolStripBarraListarLlamada.Name = "toolStripBarraListarLlamada";
            this.toolStripBarraListarLlamada.Size = new System.Drawing.Size(533, 38);
            this.toolStripBarraListarLlamada.TabIndex = 12;
            this.toolStripBarraListarLlamada.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(33, 35);
            this.toolStripButton1.Text = "Salir";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscar.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnBuscar.Appearance.Options.UseFont = true;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(375, 85);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(91, 22);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
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
            this.groupControl1.Controls.Add(this.txtPais);
            this.groupControl1.Controls.Add(this.txtCodigo);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtNombre);
            this.groupControl1.Controls.Add(this.btnBuscar);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Location = new System.Drawing.Point(0, 33);
            this.groupControl1.LookAndFeel.SkinName = "Glass Oceans";
            this.groupControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(476, 131);
            this.groupControl1.TabIndex = 11;
            this.groupControl1.Text = "Busqueda";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(5, 33);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Codigo";
            // 
            // txtPais
            // 
            this.txtPais.Enabled = false;
            this.txtPais.Location = new System.Drawing.Point(75, 77);
            this.txtPais.Name = "txtPais";
            this.txtPais.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPais.Properties.Appearance.Options.UseFont = true;
            this.txtPais.Size = new System.Drawing.Size(231, 20);
            this.txtPais.TabIndex = 37;
            // 
            // frmPuertos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 458);
            this.Controls.Add(this.grdComunas);
            this.Controls.Add(this.toolStripBarraListarLlamada);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmPuertos";
            this.Text = "Mantenedor de Puertos";
            ((System.ComponentModel.ISupportInitialize)(this.grdComunas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
            this.toolStripBarraListarLlamada.ResumeLayout(false);
            this.toolStripBarraListarLlamada.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPais.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton MenuGuardar;
        private DevExpress.XtraGrid.GridControl grdComunas;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private System.Windows.Forms.ToolStripButton MenuVerDatos;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton MenuEliminar;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton MenuExcel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ToolStripButton MenuImprimirListado;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private System.Windows.Forms.ToolStrip toolStripBarraListarLlamada;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtPais;

    }
}