namespace SCCMultimodal.Paperless.Usuario1
{
    partial class FrmPopupLogPaperlessIntegracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPopupLogPaperlessIntegracion));
            this.toobar = new System.Windows.Forms.ToolStrip();
            this.MenuSalir = new System.Windows.Forms.ToolStripButton();
            this.GrdLog = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryCheckPasos = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.toobar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryCheckPasos)).BeginInit();
            this.SuspendLayout();
            // 
            // toobar
            // 
            this.toobar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuSalir});
            this.toobar.Location = new System.Drawing.Point(0, 0);
            this.toobar.Name = "toobar";
            this.toobar.Size = new System.Drawing.Size(777, 38);
            this.toobar.TabIndex = 8;
            this.toobar.Text = "toolStrip1";
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
            // GrdLog
            // 
            this.GrdLog.Location = new System.Drawing.Point(0, 41);
            this.GrdLog.MainView = this.gridView4;
            this.GrdLog.Name = "GrdLog";
            this.GrdLog.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryCheckPasos});
            this.GrdLog.Size = new System.Drawing.Size(777, 386);
            this.GrdLog.TabIndex = 9;
            this.GrdLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView4.GridControl = this.GrdLog;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsBehavior.Editable = false;
            this.gridView4.OptionsCustomization.AllowFilter = false;
            this.gridView4.OptionsCustomization.AllowGroup = false;
            this.gridView4.OptionsCustomization.AllowRowSizing = true;
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView4.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridView4.OptionsSelection.UseIndicatorForSelection = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "N° Paperless";
            this.gridColumn4.FieldName = "IdPaperless";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 61;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "ValorPaperless";
            this.gridColumn5.FieldName = "ValorPaperless";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 104;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ValorNetShip";
            this.gridColumn1.FieldName = "ValorNetship";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 120;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Mensaje";
            this.gridColumn2.FieldName = "Mensaje";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 294;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "CreateDate";
            this.gridColumn3.DisplayFormat.FormatString = "dd/MM/yyyy h:mm:ss";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "CreateDate";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 177;
            // 
            // RepositoryCheckPasos
            // 
            this.RepositoryCheckPasos.AutoHeight = false;
            this.RepositoryCheckPasos.Name = "RepositoryCheckPasos";
            // 
            // FrmPopupLogPaperlessIntegracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 422);
            this.Controls.Add(this.GrdLog);
            this.Controls.Add(this.toobar);
            this.Name = "FrmPopupLogPaperlessIntegracion";
            this.Text = "FrmPopupLogPaperlessIntegracion";
            this.toobar.ResumeLayout(false);
            this.toobar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryCheckPasos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toobar;
        private System.Windows.Forms.ToolStripButton MenuSalir;
        private DevExpress.XtraGrid.GridControl GrdLog;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit RepositoryCheckPasos;
    }
}