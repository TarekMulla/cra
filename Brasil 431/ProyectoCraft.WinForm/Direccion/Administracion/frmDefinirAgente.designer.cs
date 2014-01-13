namespace ProyectoCraft.WinForm.Direccion.Administracion
{
    partial class frmDefinirAgente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDefinirAgente));
            this.toolStripBarraLlamada = new System.Windows.Forms.ToolStrip();
            this.MenuNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSalir = new System.Windows.Forms.ToolStripButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.txtAlias = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnEliminar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl29 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtContacto = new DevExpress.XtraEditors.TextEdit();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl28 = new DevExpress.XtraEditors.LabelControl();
            this.grpResultado = new DevExpress.XtraEditors.GroupControl();
            this.gridAgentes = new DevExpress.XtraGrid.GridControl();
            this.gridViewLineaCredito = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ctrldxError = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.toolStripBarraLlamada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlias.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContacto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpResultado)).BeginInit();
            this.grpResultado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAgentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLineaCredito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrldxError)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripBarraLlamada
            // 
            this.toolStripBarraLlamada.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNuevo,
            this.toolStripSeparator1,
            this.MenuSalir});
            this.toolStripBarraLlamada.Location = new System.Drawing.Point(0, 0);
            this.toolStripBarraLlamada.Name = "toolStripBarraLlamada";
            this.toolStripBarraLlamada.Size = new System.Drawing.Size(1019, 38);
            this.toolStripBarraLlamada.TabIndex = 5;
            this.toolStripBarraLlamada.Text = "toolStrip1";
            // 
            // MenuNuevo
            // 
            this.MenuNuevo.Image = ((System.Drawing.Image)(resources.GetObject("MenuNuevo.Image")));
            this.MenuNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuNuevo.Name = "MenuNuevo";
            this.MenuNuevo.Size = new System.Drawing.Size(46, 35);
            this.MenuNuevo.Text = "Nuevo";
            this.MenuNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuNuevo.ToolTipText = "Nueva Llamada";
            this.MenuNuevo.Click += new System.EventHandler(this.MenuNuevo_Click);
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
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.txtAlias);
            this.groupControl3.Controls.Add(this.labelControl2);
            this.groupControl3.Controls.Add(this.btnEliminar);
            this.groupControl3.Controls.Add(this.labelControl29);
            this.groupControl3.Controls.Add(this.txtEmail);
            this.groupControl3.Controls.Add(this.txtContacto);
            this.groupControl3.Controls.Add(this.txtId);
            this.groupControl3.Controls.Add(this.labelControl1);
            this.groupControl3.Controls.Add(this.btnGuardar);
            this.groupControl3.Controls.Add(this.txtNombre);
            this.groupControl3.Controls.Add(this.labelControl28);
            this.groupControl3.Location = new System.Drawing.Point(6, 39);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(1007, 60);
            this.groupControl3.TabIndex = 6;
            this.groupControl3.Text = "Datos Agente";
            // 
            // txtAlias
            // 
            this.txtAlias.EnterMoveNextControl = true;
            this.txtAlias.Location = new System.Drawing.Point(287, 27);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txtAlias.Properties.HideSelection = false;
            this.txtAlias.Size = new System.Drawing.Size(116, 20);
            this.txtAlias.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(242, 31);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(26, 13);
            this.labelControl2.TabIndex = 37;
            this.labelControl2.Text = "Alias:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(899, 26);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(104, 24);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // labelControl29
            // 
            this.labelControl29.Location = new System.Drawing.Point(613, 31);
            this.labelControl29.Name = "labelControl29";
            this.labelControl29.Size = new System.Drawing.Size(28, 13);
            this.labelControl29.TabIndex = 1;
            this.labelControl29.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.EnterMoveNextControl = true;
            this.txtEmail.Location = new System.Drawing.Point(660, 27);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txtEmail.Properties.HideSelection = false;
            this.txtEmail.Size = new System.Drawing.Size(105, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // txtContacto
            // 
            this.txtContacto.EnterMoveNextControl = true;
            this.txtContacto.Location = new System.Drawing.Point(489, 27);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txtContacto.Properties.HideSelection = false;
            this.txtContacto.Size = new System.Drawing.Size(105, 20);
            this.txtContacto.TabIndex = 3;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(548, 40);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(29, 20);
            this.txtId.TabIndex = 35;
            this.txtId.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(422, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 33;
            this.labelControl1.Text = "Contacto:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(789, 26);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(104, 24);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.EnterMoveNextControl = true;
            this.txtNombre.Location = new System.Drawing.Point(75, 27);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txtNombre.Properties.HideSelection = false;
            this.txtNombre.Size = new System.Drawing.Size(148, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // labelControl28
            // 
            this.labelControl28.Location = new System.Drawing.Point(15, 31);
            this.labelControl28.Name = "labelControl28";
            this.labelControl28.Size = new System.Drawing.Size(41, 13);
            this.labelControl28.TabIndex = 0;
            this.labelControl28.Text = "Nombre:";
            // 
            // grpResultado
            // 
            this.grpResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResultado.AppearanceCaption.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpResultado.AppearanceCaption.Options.UseFont = true;
            this.grpResultado.Controls.Add(this.gridAgentes);
            this.grpResultado.Location = new System.Drawing.Point(6, 105);
            this.grpResultado.Name = "grpResultado";
            this.grpResultado.Size = new System.Drawing.Size(1007, 411);
            this.grpResultado.TabIndex = 12;
            this.grpResultado.Text = "Agentes";
            // 
            // gridAgentes
            // 
            this.gridAgentes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridAgentes.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.gridAgentes.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridAgentes.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.gridAgentes.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridAgentes.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.gridAgentes.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridAgentes.Location = new System.Drawing.Point(2, 20);
            this.gridAgentes.MainView = this.gridViewLineaCredito;
            this.gridAgentes.Name = "gridAgentes";
            this.gridAgentes.Size = new System.Drawing.Size(1000, 386);
            this.gridAgentes.TabIndex = 6;
            this.gridAgentes.UseEmbeddedNavigator = true;
            this.gridAgentes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLineaCredito});
            // 
            // gridViewLineaCredito
            // 
            this.gridViewLineaCredito.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridId,
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn2,
            this.gridColumn3});
            this.gridViewLineaCredito.GridControl = this.gridAgentes;
            this.gridViewLineaCredito.Name = "gridViewLineaCredito";
            this.gridViewLineaCredito.OptionsBehavior.Editable = false;
            this.gridViewLineaCredito.OptionsView.ShowAutoFilterRow = true;
            this.gridViewLineaCredito.OptionsView.ShowGroupPanel = false;
            this.gridViewLineaCredito.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridviewLineaCredito_row_changed);
            // 
            // gridId
            // 
            this.gridId.Caption = "Id";
            this.gridId.FieldName = "Id";
            this.gridId.Name = "gridId";
            this.gridId.OptionsColumn.AllowEdit = false;
            this.gridId.OptionsColumn.ReadOnly = true;
            this.gridId.Visible = true;
            this.gridId.VisibleIndex = 0;
            this.gridId.Width = 37;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Nombre";
            this.gridColumn1.FieldName = "Nombre";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 243;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Alias";
            this.gridColumn4.FieldName = "Alias";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 107;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Contacto";
            this.gridColumn2.FieldName = "Contacto";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 290;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Email";
            this.gridColumn3.FieldName = "Email";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 302;
            // 
            // ctrldxError
            // 
            this.ctrldxError.ContainerControl = this;
            // 
            // frmDefinirAgente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 521);
            this.Controls.Add(this.grpResultado);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.toolStripBarraLlamada);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDefinirAgente";
            this.Text = "Definir Agentes";
            this.Load += new System.EventHandler(this.frmDefinirAgente_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDefinirAgente_Closed);
            this.toolStripBarraLlamada.ResumeLayout(false);
            this.toolStripBarraLlamada.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlias.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContacto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpResultado)).EndInit();
            this.grpResultado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAgentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLineaCredito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrldxError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripBarraLlamada;
        private System.Windows.Forms.ToolStripButton MenuSalir;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton btnGuardar;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraEditors.LabelControl labelControl29;
        private DevExpress.XtraEditors.LabelControl labelControl28;
        private DevExpress.XtraEditors.GroupControl grpResultado;
        private DevExpress.XtraGrid.GridControl gridAgentes;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLineaCredito;
        private DevExpress.XtraGrid.Columns.GridColumn gridId;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider ctrldxError;
        private DevExpress.XtraEditors.TextEdit txtId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtContacto;
        private System.Windows.Forms.ToolStripButton MenuNuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DevExpress.XtraEditors.SimpleButton btnEliminar;
        private DevExpress.XtraEditors.TextEdit txtAlias;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;

    }
}