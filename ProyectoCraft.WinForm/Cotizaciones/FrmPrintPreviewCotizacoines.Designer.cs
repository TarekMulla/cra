namespace SCCMultimodal.Cotizaciones
{
    partial class FrmPrintPreviewCotizacoines
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrintPreviewCotizacoines));
            this.GrdGrilla = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Numero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NombreCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EstadoDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Tipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStripBarraLlamada = new System.Windows.Forms.ToolStrip();
            this.MenuEnviarAlCliente = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSalir = new System.Windows.Forms.ToolStripButton();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.GrdGrilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.toolStripBarraLlamada.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrdGrilla
            // 
            this.GrdGrilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GrdGrilla.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GrdGrilla.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.GrdGrilla.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GrdGrilla.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.GrdGrilla.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GrdGrilla.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.GrdGrilla.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GrdGrilla.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.GrdGrilla.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.GrdGrilla.Location = new System.Drawing.Point(13, 41);
            this.GrdGrilla.MainView = this.gridView1;
            this.GrdGrilla.Name = "GrdGrilla";
            this.GrdGrilla.ShowOnlyPredefinedDetails = true;
            this.GrdGrilla.Size = new System.Drawing.Size(435, 520);
            this.GrdGrilla.TabIndex = 5;
            this.GrdGrilla.UseEmbeddedNavigator = true;
            this.GrdGrilla.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Numero,
            this.NombreCliente,
            this.EstadoDescripcion,
            this.Tipo});
            this.gridView1.GridControl = this.GrdGrilla;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", this.Numero, "")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.SmartDetailExpand = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PaintStyleName = "(Default)";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // Numero
            // 
            this.Numero.Caption = "Numero";
            this.Numero.FieldName = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.Visible = true;
            this.Numero.VisibleIndex = 0;
            this.Numero.Width = 60;
            // 
            // NombreCliente
            // 
            this.NombreCliente.Caption = "NombreCliente";
            this.NombreCliente.FieldName = "Cliente.NombreCliente";
            this.NombreCliente.Name = "NombreCliente";
            this.NombreCliente.Visible = true;
            this.NombreCliente.VisibleIndex = 1;
            this.NombreCliente.Width = 209;
            // 
            // EstadoDescripcion
            // 
            this.EstadoDescripcion.Caption = "Estado";
            this.EstadoDescripcion.FieldName = "EstadoDescripcion";
            this.EstadoDescripcion.Name = "EstadoDescripcion";
            this.EstadoDescripcion.Visible = true;
            this.EstadoDescripcion.VisibleIndex = 2;
            this.EstadoDescripcion.Width = 115;
            // 
            // Tipo
            // 
            this.Tipo.Caption = "Tipo";
            this.Tipo.FieldName = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.Visible = true;
            this.Tipo.VisibleIndex = 3;
            this.Tipo.Width = 104;
            // 
            // toolStripBarraLlamada
            // 
            this.toolStripBarraLlamada.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEnviarAlCliente,
            this.toolStripSeparator4,
            this.MenuSalir});
            this.toolStripBarraLlamada.Location = new System.Drawing.Point(0, 0);
            this.toolStripBarraLlamada.Name = "toolStripBarraLlamada";
            this.toolStripBarraLlamada.Size = new System.Drawing.Size(1264, 36);
            this.toolStripBarraLlamada.TabIndex = 86;
            this.toolStripBarraLlamada.Text = "toolStrip1";
            // 
            // MenuEnviarAlCliente
            // 
            this.MenuEnviarAlCliente.Image = ((System.Drawing.Image)(resources.GetObject("MenuEnviarAlCliente.Image")));
            this.MenuEnviarAlCliente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuEnviarAlCliente.Name = "MenuEnviarAlCliente";
            this.MenuEnviarAlCliente.Size = new System.Drawing.Size(86, 33);
            this.MenuEnviarAlCliente.Text = "Enviar al cliente";
            this.MenuEnviarAlCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuEnviarAlCliente.Click += new System.EventHandler(this.MenuEnviarAlCliente_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 36);
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
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(454, 41);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(798, 520);
            this.webBrowser1.TabIndex = 87;
            // 
            // FrmPrintPreviewCotizacoines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 573);
            this.Controls.Add(this.toolStripBarraLlamada);
            this.Controls.Add(this.GrdGrilla);
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FrmPrintPreviewCotizacoines";
            this.Text = "Preview Cotizaciones";
            ((System.ComponentModel.ISupportInitialize)(this.GrdGrilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.toolStripBarraLlamada.ResumeLayout(false);
            this.toolStripBarraLlamada.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GrdGrilla;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Numero;
        private DevExpress.XtraGrid.Columns.GridColumn NombreCliente;
        private DevExpress.XtraGrid.Columns.GridColumn EstadoDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn Tipo;
        private System.Windows.Forms.ToolStrip toolStripBarraLlamada;
        private System.Windows.Forms.ToolStripButton MenuEnviarAlCliente;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton MenuSalir;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}