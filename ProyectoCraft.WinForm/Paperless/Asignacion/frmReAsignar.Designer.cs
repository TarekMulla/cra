namespace ProyectoCraft.WinForm.Paperless.Asignacion
{
    partial class frmReAsignar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReAsignar));
            this.toolStripBarraMantenedor = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.MenuGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.grpReAsignar = new DevExpress.XtraEditors.GroupControl();
            this.grdAsignaciones = new DevExpress.XtraGrid.GridControl();
            this.ViewAsignaciones = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sBActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.txtMaster = new DevExpress.XtraEditors.TextEdit();
            this.lblMaster = new DevExpress.XtraEditors.LabelControl();
            this.grpReAsignacion = new DevExpress.XtraEditors.GroupControl();
            this.txtObsercacion = new DevExpress.XtraEditors.MemoEdit();
            this.CboUsuario2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.CboUsuario1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.toolStripBarraMantenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpReAsignar)).BeginInit();
            this.grpReAsignar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAsignaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewAsignaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaster.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpReAsignacion)).BeginInit();
            this.grpReAsignacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtObsercacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboUsuario2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboUsuario1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripBarraMantenedor
            // 
            this.toolStripBarraMantenedor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.MenuGuardar,
            this.toolStripSeparator2,
            this.toolStripBtnSalir});
            this.toolStripBarraMantenedor.Location = new System.Drawing.Point(0, 0);
            this.toolStripBarraMantenedor.Name = "toolStripBarraMantenedor";
            this.toolStripBarraMantenedor.Size = new System.Drawing.Size(690, 38);
            this.toolStripBarraMantenedor.TabIndex = 10;
            this.toolStripBarraMantenedor.Text = "toolStrip1";
            this.toolStripBarraMantenedor.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripBarraMantenedor_ItemClicked);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(46, 35);
            this.toolStripButton2.Text = "Nuevo";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // MenuGuardar
            // 
            this.MenuGuardar.Image = ((System.Drawing.Image)(resources.GetObject("MenuGuardar.Image")));
            this.MenuGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuGuardar.Name = "MenuGuardar";
            this.MenuGuardar.Size = new System.Drawing.Size(53, 35);
            this.MenuGuardar.Text = "Guardar";
            this.MenuGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripBtnSalir
            // 
            this.toolStripBtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnSalir.Image")));
            this.toolStripBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSalir.Name = "toolStripBtnSalir";
            this.toolStripBtnSalir.Size = new System.Drawing.Size(33, 35);
            this.toolStripBtnSalir.Text = "Salir";
            this.toolStripBtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnSalir.Click += new System.EventHandler(this.toolStripBtnSalir_Click);
            // 
            // grpReAsignar
            // 
            this.grpReAsignar.Appearance.BackColor = System.Drawing.Color.White;
            this.grpReAsignar.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReAsignar.Appearance.Options.UseBackColor = true;
            this.grpReAsignar.Appearance.Options.UseFont = true;
            this.grpReAsignar.AppearanceCaption.BackColor = System.Drawing.Color.White;
            this.grpReAsignar.AppearanceCaption.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReAsignar.AppearanceCaption.Options.UseBackColor = true;
            this.grpReAsignar.AppearanceCaption.Options.UseFont = true;
            this.grpReAsignar.Controls.Add(this.grdAsignaciones);
            this.grpReAsignar.Controls.Add(this.sBActualizar);
            this.grpReAsignar.Controls.Add(this.txtMaster);
            this.grpReAsignar.Controls.Add(this.lblMaster);
            this.grpReAsignar.Location = new System.Drawing.Point(4, 41);
            this.grpReAsignar.LookAndFeel.SkinName = "Glass Oceans";
            this.grpReAsignar.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.grpReAsignar.Name = "grpReAsignar";
            this.grpReAsignar.Size = new System.Drawing.Size(686, 234);
            this.grpReAsignar.TabIndex = 12;
            this.grpReAsignar.Text = "Buscar Master";
            this.grpReAsignar.Paint += new System.Windows.Forms.PaintEventHandler(this.grpReAsignar_Paint);
            // 
            // grdAsignaciones
            // 
            this.grdAsignaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAsignaciones.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grdAsignaciones.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.grdAsignaciones.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grdAsignaciones.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.grdAsignaciones.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grdAsignaciones.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.grdAsignaciones.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grdAsignaciones.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.grdAsignaciones.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grdAsignaciones.Location = new System.Drawing.Point(8, 76);
            this.grdAsignaciones.MainView = this.ViewAsignaciones;
            this.grdAsignaciones.Name = "grdAsignaciones";
            this.grdAsignaciones.Size = new System.Drawing.Size(673, 153);
            this.grdAsignaciones.TabIndex = 82;
            this.grdAsignaciones.UseEmbeddedNavigator = true;
            this.grdAsignaciones.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ViewAsignaciones});
            // 
            // ViewAsignaciones
            // 
            this.ViewAsignaciones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ViewAsignaciones.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn2,
            this.gridColumn3});
            this.ViewAsignaciones.GridControl = this.grdAsignaciones;
            this.ViewAsignaciones.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", this.gridColumn1, "")});
            this.ViewAsignaciones.Name = "ViewAsignaciones";
            this.ViewAsignaciones.OptionsBehavior.Editable = false;
            this.ViewAsignaciones.OptionsView.ShowAutoFilterRow = true;
            this.ViewAsignaciones.OptionsView.ShowGroupedColumns = true;
            this.ViewAsignaciones.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Width = 49;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Master";
            this.gridColumn5.FieldName = "Master";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 371;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Asignador";
            this.gridColumn7.FieldName = "Usuario1";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 123;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Usuario1";
            this.gridColumn2.FieldName = "Ciudad.Pais.Nombre";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 108;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Usuario2";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // sBActualizar
            // 
            this.sBActualizar.Image = ((System.Drawing.Image)(resources.GetObject("sBActualizar.Image")));
            this.sBActualizar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.sBActualizar.Location = new System.Drawing.Point(298, 30);
            this.sBActualizar.Name = "sBActualizar";
            this.sBActualizar.Size = new System.Drawing.Size(41, 20);
            this.sBActualizar.TabIndex = 81;
            this.sBActualizar.ToolTip = "Actualizar Gráfico";
            // 
            // txtMaster
            // 
            this.txtMaster.Location = new System.Drawing.Point(70, 30);
            this.txtMaster.Name = "txtMaster";
            this.txtMaster.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaster.Properties.Appearance.Options.UseFont = true;
            this.txtMaster.Size = new System.Drawing.Size(222, 20);
            this.txtMaster.TabIndex = 1;
            // 
            // lblMaster
            // 
            this.lblMaster.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaster.Appearance.Options.UseFont = true;
            this.lblMaster.Location = new System.Drawing.Point(5, 33);
            this.lblMaster.Name = "lblMaster";
            this.lblMaster.Size = new System.Drawing.Size(59, 13);
            this.lblMaster.TabIndex = 0;
            this.lblMaster.Text = "Master Id:";
            // 
            // grpReAsignacion
            // 
            this.grpReAsignacion.Appearance.BackColor = System.Drawing.Color.White;
            this.grpReAsignacion.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReAsignacion.Appearance.Options.UseBackColor = true;
            this.grpReAsignacion.Appearance.Options.UseFont = true;
            this.grpReAsignacion.AppearanceCaption.BackColor = System.Drawing.Color.White;
            this.grpReAsignacion.AppearanceCaption.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReAsignacion.AppearanceCaption.Options.UseBackColor = true;
            this.grpReAsignacion.AppearanceCaption.Options.UseFont = true;
            this.grpReAsignacion.Controls.Add(this.txtObsercacion);
            this.grpReAsignacion.Controls.Add(this.CboUsuario2);
            this.grpReAsignacion.Controls.Add(this.CboUsuario1);
            this.grpReAsignacion.Controls.Add(this.labelControl2);
            this.grpReAsignacion.Controls.Add(this.labelControl1);
            this.grpReAsignacion.Location = new System.Drawing.Point(2, 281);
            this.grpReAsignacion.LookAndFeel.SkinName = "Glass Oceans";
            this.grpReAsignacion.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.grpReAsignacion.Name = "grpReAsignacion";
            this.grpReAsignacion.Size = new System.Drawing.Size(686, 159);
            this.grpReAsignacion.TabIndex = 84;
            this.grpReAsignacion.Text = "Re-Asignar";
            this.grpReAsignacion.Paint += new System.Windows.Forms.PaintEventHandler(this.grpReAsignacion_Paint);
            // 
            // txtObsercacion
            // 
            this.txtObsercacion.Location = new System.Drawing.Point(89, 82);
            this.txtObsercacion.Name = "txtObsercacion";
            this.txtObsercacion.Size = new System.Drawing.Size(360, 70);
            this.txtObsercacion.TabIndex = 14;
            // 
            // CboUsuario2
            // 
            this.CboUsuario2.Location = new System.Drawing.Point(89, 56);
            this.CboUsuario2.Name = "CboUsuario2";
            this.CboUsuario2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CboUsuario2.Size = new System.Drawing.Size(235, 20);
            this.CboUsuario2.TabIndex = 13;
            // 
            // CboUsuario1
            // 
            this.CboUsuario1.Location = new System.Drawing.Point(89, 30);
            this.CboUsuario1.Name = "CboUsuario1";
            this.CboUsuario1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CboUsuario1.Size = new System.Drawing.Size(235, 20);
            this.CboUsuario1.TabIndex = 12;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(5, 59);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(55, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Usuario2:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(5, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Usuario1:";
            // 
            // frmReAsignar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 445);
            this.Controls.Add(this.grpReAsignacion);
            this.Controls.Add(this.grpReAsignar);
            this.Controls.Add(this.toolStripBarraMantenedor);
            this.Name = "frmReAsignar";
            this.Text = "Re-Asignar";
            this.Load += new System.EventHandler(this.frmReAsignar_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReAsignar_FormClosed);
            this.toolStripBarraMantenedor.ResumeLayout(false);
            this.toolStripBarraMantenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpReAsignar)).EndInit();
            this.grpReAsignar.ResumeLayout(false);
            this.grpReAsignar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAsignaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewAsignaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaster.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpReAsignacion)).EndInit();
            this.grpReAsignacion.ResumeLayout(false);
            this.grpReAsignacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtObsercacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboUsuario2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboUsuario1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripBarraMantenedor;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton MenuGuardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripBtnSalir;
        private DevExpress.XtraEditors.GroupControl grpReAsignar;
        private DevExpress.XtraEditors.TextEdit txtMaster;
        private DevExpress.XtraEditors.LabelControl lblMaster;
        private DevExpress.XtraEditors.SimpleButton sBActualizar;
        private DevExpress.XtraGrid.GridControl grdAsignaciones;
        private DevExpress.XtraGrid.Views.Grid.GridView ViewAsignaciones;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.GroupControl grpReAsignacion;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit CboUsuario2;
        private DevExpress.XtraEditors.ComboBoxEdit CboUsuario1;
        private DevExpress.XtraEditors.MemoEdit txtObsercacion;
    }
}