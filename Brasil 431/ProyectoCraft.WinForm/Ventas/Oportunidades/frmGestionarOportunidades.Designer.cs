namespace ProyectoCraft.WinForm.Ventas.Oportunidades
{
    partial class frmGestionarOportunidades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionarOportunidades));
            this.toolStripBarraListarLlamada = new System.Windows.Forms.ToolStrip();
            this.MenuCrearLlamada = new System.Windows.Forms.ToolStripButton();
            this.MenuEditarLlamada = new System.Windows.Forms.ToolStripButton();
            this.MenuEliminar = new System.Windows.Forms.ToolStripButton();
            this.MenuImprimirListado = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSalir = new System.Windows.Forms.ToolStripButton();
            this.grpResultado = new DevExpress.XtraEditors.GroupControl();
            this.gridLlamadas = new DevExpress.XtraGrid.GridControl();
            this.gridViewLlamadas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridContacto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridTema = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpBusquedasPredeterminadas = new DevExpress.XtraEditors.GroupControl();
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
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
            this.toolStripBarraListarLlamada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpResultado)).BeginInit();
            this.grpResultado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLlamadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLlamadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpBusquedasPredeterminadas)).BeginInit();
            this.grpBusquedasPredeterminadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpFiltros)).BeginInit();
            this.grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboContactos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateHasta.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateInicio.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateInicio.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripBarraListarLlamada
            // 
            this.toolStripBarraListarLlamada.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCrearLlamada,
            this.MenuEditarLlamada,
            this.MenuEliminar,
            this.MenuImprimirListado,
            this.toolStripSeparator1,
            this.MenuSalir});
            this.toolStripBarraListarLlamada.Location = new System.Drawing.Point(0, 0);
            this.toolStripBarraListarLlamada.Name = "toolStripBarraListarLlamada";
            this.toolStripBarraListarLlamada.Size = new System.Drawing.Size(1010, 36);
            this.toolStripBarraListarLlamada.TabIndex = 6;
            this.toolStripBarraListarLlamada.Text = "toolStrip1";
            // 
            // MenuCrearLlamada
            // 
            this.MenuCrearLlamada.Image = ((System.Drawing.Image)(resources.GetObject("MenuCrearLlamada.Image")));
            this.MenuCrearLlamada.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuCrearLlamada.Name = "MenuCrearLlamada";
            this.MenuCrearLlamada.Size = new System.Drawing.Size(38, 33);
            this.MenuCrearLlamada.Text = "Crear";
            this.MenuCrearLlamada.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuCrearLlamada.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuCrearLlamada.ToolTipText = "Crear";
            // 
            // MenuEditarLlamada
            // 
            this.MenuEditarLlamada.Image = ((System.Drawing.Image)(resources.GetObject("MenuEditarLlamada.Image")));
            this.MenuEditarLlamada.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuEditarLlamada.Name = "MenuEditarLlamada";
            this.MenuEditarLlamada.Size = new System.Drawing.Size(39, 33);
            this.MenuEditarLlamada.Text = "Editar";
            this.MenuEditarLlamada.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuEditarLlamada.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuEditarLlamada.ToolTipText = "Editar";
            // 
            // MenuEliminar
            // 
            this.MenuEliminar.Image = ((System.Drawing.Image)(resources.GetObject("MenuEliminar.Image")));
            this.MenuEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuEliminar.Name = "MenuEliminar";
            this.MenuEliminar.Size = new System.Drawing.Size(47, 33);
            this.MenuEliminar.Text = "Eliminar";
            this.MenuEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuEliminar.ToolTipText = "Eliminar";
            // 
            // MenuImprimirListado
            // 
            this.MenuImprimirListado.Enabled = false;
            this.MenuImprimirListado.Image = global::ProyectoCraft.WinForm.Properties.Resources.fileprint;
            this.MenuImprimirListado.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.MenuImprimirListado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuImprimirListado.Name = "MenuImprimirListado";
            this.MenuImprimirListado.Size = new System.Drawing.Size(86, 33);
            this.MenuImprimirListado.Text = "Imprimir Listado";
            this.MenuImprimirListado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuImprimirListado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            // 
            // grpResultado
            // 
            this.grpResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResultado.AppearanceCaption.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpResultado.AppearanceCaption.Options.UseFont = true;
            this.grpResultado.Controls.Add(this.gridLlamadas);
            this.grpResultado.Location = new System.Drawing.Point(5, 155);
            this.grpResultado.Name = "grpResultado";
            this.grpResultado.Size = new System.Drawing.Size(1000, 331);
            this.grpResultado.TabIndex = 14;
            this.grpResultado.Text = "Resultado de busqueda";
            // 
            // gridLlamadas
            // 
            this.gridLlamadas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLlamadas.Location = new System.Drawing.Point(5, 20);
            this.gridLlamadas.MainView = this.gridViewLlamadas;
            this.gridLlamadas.Name = "gridLlamadas";
            this.gridLlamadas.Size = new System.Drawing.Size(988, 306);
            this.gridLlamadas.TabIndex = 6;
            this.gridLlamadas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLlamadas});
            // 
            // gridViewLlamadas
            // 
            this.gridViewLlamadas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridFecha,
            this.gridContacto,
            this.gridCliente,
            this.gridTema,
            this.gridDescripcion});
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
            this.gridFecha.Width = 108;
            // 
            // gridContacto
            // 
            this.gridContacto.Caption = "Contacto";
            this.gridContacto.FieldName = "ObjContacto.Nombre";
            this.gridContacto.Name = "gridContacto";
            this.gridContacto.OptionsColumn.ReadOnly = true;
            this.gridContacto.Visible = true;
            this.gridContacto.VisibleIndex = 1;
            this.gridContacto.Width = 185;
            // 
            // gridCliente
            // 
            this.gridCliente.Caption = "Cliente/Target";
            this.gridCliente.FieldName = "ObjContacto.ClienteMaster.Nombre";
            this.gridCliente.Name = "gridCliente";
            this.gridCliente.OptionsColumn.ReadOnly = true;
            this.gridCliente.Visible = true;
            this.gridCliente.VisibleIndex = 2;
            this.gridCliente.Width = 198;
            // 
            // gridTema
            // 
            this.gridTema.Caption = "Tema";
            this.gridTema.FieldName = "ObjTipoActividadAsunto.Nombre";
            this.gridTema.Name = "gridTema";
            this.gridTema.OptionsColumn.ReadOnly = true;
            this.gridTema.Visible = true;
            this.gridTema.VisibleIndex = 3;
            this.gridTema.Width = 265;
            // 
            // gridDescripcion
            // 
            this.gridDescripcion.Caption = "Descripción";
            this.gridDescripcion.FieldName = "Descripcion";
            this.gridDescripcion.Name = "gridDescripcion";
            this.gridDescripcion.OptionsColumn.ReadOnly = true;
            this.gridDescripcion.Visible = true;
            this.gridDescripcion.VisibleIndex = 4;
            this.gridDescripcion.Width = 154;
            // 
            // grpBusquedasPredeterminadas
            // 
            this.grpBusquedasPredeterminadas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBusquedasPredeterminadas.AppearanceCaption.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBusquedasPredeterminadas.AppearanceCaption.Options.UseFont = true;
            this.grpBusquedasPredeterminadas.Controls.Add(this.listBoxControl1);
            this.grpBusquedasPredeterminadas.Location = new System.Drawing.Point(549, 39);
            this.grpBusquedasPredeterminadas.Name = "grpBusquedasPredeterminadas";
            this.grpBusquedasPredeterminadas.Size = new System.Drawing.Size(456, 114);
            this.grpBusquedasPredeterminadas.TabIndex = 13;
            this.grpBusquedasPredeterminadas.Text = "Busquedas Predeterminadas";
            // 
            // listBoxControl1
            // 
            this.listBoxControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxControl1.Appearance.Options.UseFont = true;
            this.listBoxControl1.Items.AddRange(new object[] {
            "Todas",
            "Mis Llamadas",
            "Llamadas Importancia Alta",
            "Llamadas Asociadas Oportunidad",
            "Llamadas Último Mes"});
            this.listBoxControl1.Location = new System.Drawing.Point(5, 23);
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new System.Drawing.Size(444, 86);
            this.listBoxControl1.TabIndex = 0;
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
            this.grpFiltros.Size = new System.Drawing.Size(543, 110);
            this.grpFiltros.TabIndex = 12;
            this.grpFiltros.Text = "Busqueda";
            // 
            // CboCliente
            // 
            this.CboCliente.Location = new System.Drawing.Point(84, 56);
            this.CboCliente.Name = "CboCliente";
            this.CboCliente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CboCliente.Size = new System.Drawing.Size(357, 20);
            this.CboCliente.TabIndex = 10;
            // 
            // CboContactos
            // 
            this.CboContactos.Location = new System.Drawing.Point(84, 82);
            this.CboContactos.Name = "CboContactos";
            this.CboContactos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CboContactos.Size = new System.Drawing.Size(357, 20);
            this.CboContactos.TabIndex = 9;
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
            this.sButtonBuscar.Location = new System.Drawing.Point(447, 78);
            this.sButtonBuscar.Name = "sButtonBuscar";
            this.sButtonBuscar.Size = new System.Drawing.Size(91, 22);
            this.sButtonBuscar.TabIndex = 1;
            this.sButtonBuscar.Text = "Buscar";
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
            // frmGestionarOportunidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 498);
            this.Controls.Add(this.grpResultado);
            this.Controls.Add(this.grpBusquedasPredeterminadas);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.toolStripBarraListarLlamada);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGestionarOportunidades";
            this.Text = "Gestionar Oportunidades";
            this.toolStripBarraListarLlamada.ResumeLayout(false);
            this.toolStripBarraListarLlamada.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpResultado)).EndInit();
            this.grpResultado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLlamadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLlamadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpBusquedasPredeterminadas)).EndInit();
            this.grpBusquedasPredeterminadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpFiltros)).EndInit();
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboContactos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateHasta.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateInicio.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateInicio.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripBarraListarLlamada;
        private System.Windows.Forms.ToolStripButton MenuCrearLlamada;
        private System.Windows.Forms.ToolStripButton MenuEditarLlamada;
        private System.Windows.Forms.ToolStripButton MenuEliminar;
        private System.Windows.Forms.ToolStripButton MenuImprimirListado;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton MenuSalir;
        private DevExpress.XtraEditors.GroupControl grpResultado;
        private DevExpress.XtraGrid.GridControl gridLlamadas;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLlamadas;
        private DevExpress.XtraGrid.Columns.GridColumn gridFecha;
        private DevExpress.XtraGrid.Columns.GridColumn gridContacto;
        private DevExpress.XtraGrid.Columns.GridColumn gridCliente;
        private DevExpress.XtraGrid.Columns.GridColumn gridTema;
        private DevExpress.XtraGrid.Columns.GridColumn gridDescripcion;
        private DevExpress.XtraEditors.GroupControl grpBusquedasPredeterminadas;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
        private DevExpress.XtraEditors.GroupControl grpFiltros;
        private DevExpress.XtraEditors.ComboBoxEdit CboCliente;
        private DevExpress.XtraEditors.ComboBoxEdit CboContactos;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dateHasta;
        private DevExpress.XtraEditors.DateEdit dateInicio;
        private DevExpress.XtraEditors.LabelControl lblCliente;
        private DevExpress.XtraEditors.SimpleButton sButtonBuscar;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.LabelControl lblContacto;
    }
}