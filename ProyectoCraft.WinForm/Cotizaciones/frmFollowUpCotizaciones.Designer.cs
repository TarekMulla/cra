using ProyectoCraft.WinForm.Clientes;


namespace SCCMultimodal.Cotizaciones
{
    partial class FrmFollowUpCotizaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmtargetFollowUP));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.MenuGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSalir = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sButtonEliminarTrafico = new DevExpress.XtraEditors.SimpleButton();
            this.sButtonAgregarTrafico = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescripcionFollowUp = new DevExpress.XtraEditors.MemoEdit();
            this.cboActividadFollowUp = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dtFechaFollowUp = new DevExpress.XtraEditors.DateEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.gridFollowUp = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemImageEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.ctrldxError = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcionFollowUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboActividadFollowUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaFollowUp.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaFollowUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFollowUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrldxError)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuGuardar,
            this.toolStripSeparator1,
            this.MenuSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(914, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // MenuGuardar
            // 
            this.MenuGuardar.Image = ((System.Drawing.Image)(resources.GetObject("MenuGuardar.Image")));
            this.MenuGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuGuardar.Name = "MenuGuardar";
            this.MenuGuardar.Size = new System.Drawing.Size(53, 35);
            this.MenuGuardar.Text = "Guardar";
            this.MenuGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuGuardar.Click += new System.EventHandler(this.MenuGuardar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // MenuSalir
            // 
            this.MenuSalir.Image = ((System.Drawing.Image)(resources.GetObject("MenuSalir.Image")));
            this.MenuSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuSalir.Name = "MenuSalir";
            this.MenuSalir.Size = new System.Drawing.Size(33, 35);
            this.MenuSalir.Text = "Salir";
            this.MenuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuSalir.Click += new System.EventHandler(this.MenuSalir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sButtonEliminarTrafico);
            this.groupBox2.Controls.Add(this.sButtonAgregarTrafico);
            this.groupBox2.Controls.Add(this.txtDescripcionFollowUp);
            this.groupBox2.Controls.Add(this.cboActividadFollowUp);
            this.groupBox2.Controls.Add(this.dtFechaFollowUp);
            this.groupBox2.Controls.Add(this.labelControl9);
            this.groupBox2.Controls.Add(this.labelControl8);
            this.groupBox2.Controls.Add(this.labelControl7);
            this.groupBox2.Controls.Add(this.gridFollowUp);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox2.Location = new System.Drawing.Point(10, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(895, 231);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FollowUp";
            // 
            // sButtonEliminarTrafico
            // 
            this.sButtonEliminarTrafico.AutoSizeInLayoutControl = true;
            this.sButtonEliminarTrafico.Image = ((System.Drawing.Image)(resources.GetObject("sButtonEliminarTrafico.Image")));
            this.sButtonEliminarTrafico.Location = new System.Drawing.Point(376, 55);
            this.sButtonEliminarTrafico.Name = "sButtonEliminarTrafico";
            this.sButtonEliminarTrafico.Size = new System.Drawing.Size(26, 24);
            this.sButtonEliminarTrafico.TabIndex = 46;
            this.sButtonEliminarTrafico.Click += new System.EventHandler(this.sButtonEliminarTrafico_Click);
            // 
            // sButtonAgregarTrafico
            // 
            this.sButtonAgregarTrafico.Image = ((System.Drawing.Image)(resources.GetObject("sButtonAgregarTrafico.Image")));
            this.sButtonAgregarTrafico.Location = new System.Drawing.Point(376, 79);
            this.sButtonAgregarTrafico.Name = "sButtonAgregarTrafico";
            this.sButtonAgregarTrafico.Size = new System.Drawing.Size(27, 24);
            this.sButtonAgregarTrafico.TabIndex = 45;
            this.sButtonAgregarTrafico.Click += new System.EventHandler(this.sButtonAgregarTrafico_Click);
            // 
            // txtDescripcionFollowUp
            // 
            this.txtDescripcionFollowUp.Location = new System.Drawing.Point(79, 76);
            this.txtDescripcionFollowUp.Name = "txtDescripcionFollowUp";
            this.txtDescripcionFollowUp.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionFollowUp.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtDescripcionFollowUp.Properties.Appearance.Options.UseFont = true;
            this.txtDescripcionFollowUp.Properties.Appearance.Options.UseForeColor = true;
            this.txtDescripcionFollowUp.Size = new System.Drawing.Size(273, 81);
            this.txtDescripcionFollowUp.TabIndex = 39;
            // 
            // cboActividadFollowUp
            // 
            this.cboActividadFollowUp.Location = new System.Drawing.Point(78, 50);
            this.cboActividadFollowUp.Name = "cboActividadFollowUp";
            this.cboActividadFollowUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboActividadFollowUp.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboActividadFollowUp.Size = new System.Drawing.Size(199, 20);
            this.cboActividadFollowUp.TabIndex = 39;
            // 
            // dtFechaFollowUp
            // 
            this.dtFechaFollowUp.EditValue = new System.DateTime(((long)(0)));
            this.dtFechaFollowUp.EnterMoveNextControl = true;
            this.dtFechaFollowUp.Location = new System.Drawing.Point(79, 24);
            this.dtFechaFollowUp.Name = "dtFechaFollowUp";
            this.dtFechaFollowUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFechaFollowUp.Properties.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm";
            this.dtFechaFollowUp.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFechaFollowUp.Properties.EditFormat.FormatString = "dd-MM-yyyy HH:mm";
            this.dtFechaFollowUp.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFechaFollowUp.Properties.Mask.EditMask = "g";
            this.dtFechaFollowUp.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtFechaFollowUp.Properties.VistaTimeProperties.DisplayFormat.FormatString = "d";
            this.dtFechaFollowUp.Properties.VistaTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFechaFollowUp.Properties.VistaTimeProperties.EditFormat.FormatString = "d";
            this.dtFechaFollowUp.Properties.VistaTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFechaFollowUp.Size = new System.Drawing.Size(198, 20);
            this.dtFechaFollowUp.TabIndex = 39;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(15, 83);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(58, 13);
            this.labelControl9.TabIndex = 42;
            this.labelControl9.Text = "Descripcion:";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(15, 55);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(48, 13);
            this.labelControl8.TabIndex = 41;
            this.labelControl8.Text = "Actividad:";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(15, 27);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(33, 13);
            this.labelControl7.TabIndex = 39;
            this.labelControl7.Text = "Fecha:";
            // 
            // gridFollowUp
            // 
            this.gridFollowUp.Location = new System.Drawing.Point(423, 31);
            this.gridFollowUp.MainView = this.gridView3;
            this.gridFollowUp.Name = "gridFollowUp";
            this.gridFollowUp.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemDateEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemImageEdit2,
            this.repositoryItemButtonEdit1,
            this.repositoryItemImageEdit1});
            this.gridFollowUp.Size = new System.Drawing.Size(438, 168);
            this.gridFollowUp.TabIndex = 40;
            this.gridFollowUp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView3.GridControl = this.gridFollowUp;
            this.gridView3.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView3.OptionsBehavior.CacheValuesOnRowUpdating = DevExpress.Data.CacheRowValuesMode.Disabled;
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Fecha";
            this.gridColumn1.ColumnEdit = this.repositoryItemComboBox1;
            this.gridColumn1.FieldName = "FechaFollowUp";
            this.gridColumn1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn1.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Date;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 78;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Actividad";
            this.gridColumn2.ColumnEdit = this.repositoryItemComboBox1;
            this.gridColumn2.FieldName = "TipoActividad";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 100;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Descripcion";
            this.gridColumn3.ColumnEdit = this.repositoryItemTextEdit1;
            this.gridColumn3.FieldName = "Descripcion";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 203;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // repositoryItemImageEdit2
            // 
            this.repositoryItemImageEdit2.AutoHeight = false;
            this.repositoryItemImageEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.repositoryItemImageEdit2.Name = "repositoryItemImageEdit2";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // ctrldxError
            // 
            this.ctrldxError.ContainerControl = this;
            // 
            // frmtargetFollowUP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 296);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.Name = "frmtargetFollowUP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FollowUp";
            this.Load += new System.EventHandler(this.frmClienteFollowUp_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmClienteFollowUp_FormClosed);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcionFollowUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboActividadFollowUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaFollowUp.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaFollowUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFollowUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrldxError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton MenuSalir;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.SimpleButton sButtonEliminarTrafico;
        private DevExpress.XtraEditors.SimpleButton sButtonAgregarTrafico;
        private DevExpress.XtraEditors.MemoEdit txtDescripcionFollowUp;
        private DevExpress.XtraEditors.ComboBoxEdit cboActividadFollowUp;
        private DevExpress.XtraEditors.DateEdit dtFechaFollowUp;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraGrid.GridControl gridFollowUp;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private System.Windows.Forms.ToolStripButton MenuGuardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider ctrldxError;
    }
}