namespace ProyectoCraft.WinForm.Calendarios
{
    partial class frmConsultarVisitas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultarVisitas));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.MenuVerVisita = new System.Windows.Forms.ToolStripButton();
            this.MenuVerInforme = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSalir = new System.Windows.Forms.ToolStripButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboCliente = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboVendedor = new DevExpress.XtraEditors.ComboBoxEdit();
            this.CboEstado = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.txtHasta = new DevExpress.XtraEditors.DateEdit();
            this.txtDesde = new DevExpress.XtraEditors.DateEdit();
            this.txtCliente = new DevExpress.XtraEditors.TextEdit();
            this.txtVendedor = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grdVisitas = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboEstado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHasta.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesde.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVisitas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuVerVisita,
            this.MenuVerInforme,
            this.toolStripSeparator2,
            this.MenuExcel,
            this.toolStripSeparator1,
            this.MenuSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(941, 54);
            this.toolStrip1.TabIndex = 0;
            // 
            // MenuVerVisita
            // 
            this.MenuVerVisita.Image = ((System.Drawing.Image)(resources.GetObject("MenuVerVisita.Image")));
            this.MenuVerVisita.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuVerVisita.Name = "MenuVerVisita";
            this.MenuVerVisita.Size = new System.Drawing.Size(59, 51);
            this.MenuVerVisita.Text = "Ver Visita";
            this.MenuVerVisita.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuVerVisita.Click += new System.EventHandler(this.MenuVerVisita_Click);
            // 
            // MenuVerInforme
            // 
            this.MenuVerInforme.Image = ((System.Drawing.Image)(resources.GetObject("MenuVerInforme.Image")));
            this.MenuVerInforme.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuVerInforme.Name = "MenuVerInforme";
            this.MenuVerInforme.Size = new System.Drawing.Size(73, 51);
            this.MenuVerInforme.Text = "Ver Informe";
            this.MenuVerInforme.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuVerInforme.Click += new System.EventHandler(this.MenuVerInforme_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 54);
            // 
            // MenuExcel
            // 
            this.MenuExcel.Image = ((System.Drawing.Image)(resources.GetObject("MenuExcel.Image")));
            this.MenuExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuExcel.Name = "MenuExcel";
            this.MenuExcel.Size = new System.Drawing.Size(37, 51);
            this.MenuExcel.Text = "Excel";
            this.MenuExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuExcel.Click += new System.EventHandler(this.MenuExcel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // MenuSalir
            // 
            this.MenuSalir.Image = ((System.Drawing.Image)(resources.GetObject("MenuSalir.Image")));
            this.MenuSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuSalir.Name = "MenuSalir";
            this.MenuSalir.Size = new System.Drawing.Size(36, 51);
            this.MenuSalir.Text = "Salir";
            this.MenuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuSalir.Click += new System.EventHandler(this.MenuSalir_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cboCliente);
            this.groupControl1.Controls.Add(this.cboVendedor);
            this.groupControl1.Controls.Add(this.CboEstado);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.btnBuscar);
            this.groupControl1.Controls.Add(this.txtHasta);
            this.groupControl1.Controls.Add(this.txtDesde);
            this.groupControl1.Controls.Add(this.txtCliente);
            this.groupControl1.Controls.Add(this.txtVendedor);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 54);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(941, 125);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Busqueda";
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // cboCliente
            // 
            this.cboCliente.Location = new System.Drawing.Point(388, 62);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCliente.Size = new System.Drawing.Size(37, 20);
            this.cboCliente.TabIndex = 12;
            this.cboCliente.Visible = false;
            // 
            // cboVendedor
            // 
            this.cboVendedor.Location = new System.Drawing.Point(387, 35);
            this.cboVendedor.Name = "cboVendedor";
            this.cboVendedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboVendedor.Size = new System.Drawing.Size(38, 20);
            this.cboVendedor.TabIndex = 11;
            this.cboVendedor.Visible = false;
            // 
            // CboEstado
            // 
            this.CboEstado.Location = new System.Drawing.Point(75, 81);
            this.CboEstado.Name = "CboEstado";
            this.CboEstado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CboEstado.Size = new System.Drawing.Size(156, 20);
            this.CboEstado.TabIndex = 10;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(13, 85);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(33, 13);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Estado";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(584, 94);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtHasta
            // 
            this.txtHasta.EditValue = null;
            this.txtHasta.Location = new System.Drawing.Point(548, 57);
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtHasta.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtHasta.Size = new System.Drawing.Size(111, 20);
            this.txtHasta.TabIndex = 7;
            // 
            // txtDesde
            // 
            this.txtDesde.EditValue = null;
            this.txtDesde.Location = new System.Drawing.Point(548, 35);
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDesde.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDesde.Size = new System.Drawing.Size(112, 20);
            this.txtDesde.TabIndex = 6;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(75, 58);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(306, 20);
            this.txtCliente.TabIndex = 5;
            // 
            // txtVendedor
            // 
            this.txtVendedor.Location = new System.Drawing.Point(75, 35);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Size = new System.Drawing.Size(306, 20);
            this.txtVendedor.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(13, 61);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(33, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Cliente";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 35);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Vendedor";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(465, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Fecha Termino";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(465, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Fecha Inicio";
            // 
            // grdVisitas
            // 
            this.grdVisitas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdVisitas.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grdVisitas.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grdVisitas.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grdVisitas.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grdVisitas.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grdVisitas.Location = new System.Drawing.Point(0, 179);
            this.grdVisitas.MainView = this.gridView1;
            this.grdVisitas.Name = "grdVisitas";
            this.grdVisitas.Size = new System.Drawing.Size(941, 267);
            this.grdVisitas.TabIndex = 2;
            this.grdVisitas.UseEmbeddedNavigator = true;
            this.grdVisitas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdVisitas.DoubleClick += new System.EventHandler(this.grdVisitas_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn7,
            this.gridColumn5,
            this.gridColumn11,
            this.gridColumn12});
            this.gridView1.GridControl = this.grdVisitas;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Organizador";
            this.gridColumn10.FieldName = "UsuarioOrganizador.NombreCompleto";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdVisita";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Vendedor";
            this.gridColumn2.FieldName = "Vendedor.NombreCompleto";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 115;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Cliente";
            this.gridColumn3.FieldName = "Cliente.NombreFantasia";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 115;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Inicio";
            this.gridColumn4.FieldName = "FechaHoraComienzo";
            this.gridColumn4.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 95;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Estado";
            this.gridColumn6.FieldName = "EstadoVistaDescripcion";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 123;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Asunto";
            this.gridColumn8.FieldName = "Asunto";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 143;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Ubicación";
            this.gridColumn9.FieldName = "Ubicacion";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 146;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Reprogramada";
            this.gridColumn7.FieldName = "EsReplanificada";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 82;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "FollowUp";
            this.gridColumn5.FieldName = "Informvisita.FollowUp";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Nivel Importancia";
            this.gridColumn11.FieldName = "NivelImportancia.Nombre";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 5;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Informe Visita";
            this.gridColumn12.FieldName = "Informvisita.ResumenVisita";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 10;
            // 
            // frmConsultarVisitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 446);
            this.ControlBox = false;
            this.Controls.Add(this.grdVisitas);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmConsultarVisitas";
            this.Load += new System.EventHandler(this.frmConsultarVisitas_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboEstado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHasta.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesde.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVisitas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton MenuSalir;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtCliente;
        private DevExpress.XtraEditors.TextEdit txtVendedor;
        private DevExpress.XtraEditors.DateEdit txtHasta;
        private DevExpress.XtraEditors.DateEdit txtDesde;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ComboBoxEdit CboEstado;
        private DevExpress.XtraGrid.GridControl grdVisitas;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.ComboBoxEdit cboCliente;
        private DevExpress.XtraEditors.ComboBoxEdit cboVendedor;
        private System.Windows.Forms.ToolStripButton MenuExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private System.Windows.Forms.ToolStripButton MenuVerVisita;
        private System.Windows.Forms.ToolStripButton MenuVerInforme;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}