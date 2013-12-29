using System.Windows.Forms;

namespace ProyectoCraft.WinForm.Ventas.Actividades.Llamadas_Telefonicas
{
    partial class FrmLlamadaTelefonica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLlamadaTelefonica));
            this.toolStripBarraLlamada = new System.Windows.Forms.ToolStrip();
            this.MenuNuevo = new System.Windows.Forms.ToolStripButton();
            this.MenuGuardar = new System.Windows.Forms.ToolStripButton();
            this.MenuCrearOportunidad = new System.Windows.Forms.ToolStripButton();
            this.MenuBitacora = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSalir = new System.Windows.Forms.ToolStripButton();
            this.TxtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lblllamada = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.DtFechaHora = new DevExpress.XtraEditors.DateEdit();
            this.CboContactos = new DevExpress.XtraEditors.ComboBoxEdit();
            this.CboCliente = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gridOportunidadesCliente = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridTema = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridVendedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridSeleccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSel = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grpOportunidades = new System.Windows.Forms.GroupBox();
            this.ctrldxError = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.xtraTabActividades = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabLlamadas = new DevExpress.XtraTab.XtraTabPage();
            this.gridActividades = new DevExpress.XtraGrid.GridControl();
            this.gridViewLlamadas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColLlamada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.gridColContacto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUsuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabeMails = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabCasos = new DevExpress.XtraTab.XtraTabPage();
            this.checkListBoxTiposAsunto = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.groupBoxTipoLlamada = new System.Windows.Forms.GroupBox();
            this.radioButtonEntrante = new System.Windows.Forms.RadioButton();
            this.radioButtonSaliente = new System.Windows.Forms.RadioButton();
            this.checkBoxImportancia = new System.Windows.Forms.CheckBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxTipoProducto = new DevExpress.XtraEditors.ComboBoxEdit();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sButtonEliminarTrafico = new DevExpress.XtraEditors.SimpleButton();
            this.sButtonAgregarTrafico = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescripcionFollowUp = new DevExpress.XtraEditors.MemoEdit();
            this.cboActividadFollowUp = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dtFechaFollowUp = new DevExpress.XtraEditors.DateEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.toolStripBarraLlamada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtFechaHora.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtFechaHora.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboContactos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOportunidadesCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.grpOportunidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrldxError)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabActividades)).BeginInit();
            this.xtraTabActividades.SuspendLayout();
            this.xtraTabLlamadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridActividades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLlamadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkListBoxTiposAsunto)).BeginInit();
            this.groupBoxTipoLlamada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTipoProducto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFollowUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcionFollowUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboActividadFollowUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaFollowUp.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaFollowUp.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripBarraLlamada
            // 
            this.toolStripBarraLlamada.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNuevo,
            this.MenuGuardar,
            this.MenuCrearOportunidad,
            this.MenuBitacora,
            this.toolStripSeparator1,
            this.MenuSalir});
            this.toolStripBarraLlamada.Location = new System.Drawing.Point(0, 0);
            this.toolStripBarraLlamada.Name = "toolStripBarraLlamada";
            this.toolStripBarraLlamada.Size = new System.Drawing.Size(984, 38);
            this.toolStripBarraLlamada.TabIndex = 4;
            this.toolStripBarraLlamada.Text = "toolStrip1";
            // 
            // MenuNuevo
            // 
            this.MenuNuevo.Image = ((System.Drawing.Image)(resources.GetObject("MenuNuevo.Image")));
            this.MenuNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuNuevo.Name = "MenuNuevo";
            this.MenuNuevo.Size = new System.Drawing.Size(45, 35);
            this.MenuNuevo.Text = "Nueva";
            this.MenuNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuNuevo.ToolTipText = "Nueva Llamada";
            this.MenuNuevo.Click += new System.EventHandler(this.MenuNuevo_Click);
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
            // MenuCrearOportunidad
            // 
            this.MenuCrearOportunidad.Enabled = false;
            this.MenuCrearOportunidad.Image = ((System.Drawing.Image)(resources.GetObject("MenuCrearOportunidad.Image")));
            this.MenuCrearOportunidad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuCrearOportunidad.Name = "MenuCrearOportunidad";
            this.MenuCrearOportunidad.Size = new System.Drawing.Size(110, 35);
            this.MenuCrearOportunidad.Text = "Crear Oportunidad";
            this.MenuCrearOportunidad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuCrearOportunidad.Click += new System.EventHandler(this.MenuCrearOportunidad_Click);
            // 
            // MenuBitacora
            // 
            this.MenuBitacora.Enabled = false;
            this.MenuBitacora.Image = ((System.Drawing.Image)(resources.GetObject("MenuBitacora.Image")));
            this.MenuBitacora.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuBitacora.Name = "MenuBitacora";
            this.MenuBitacora.Size = new System.Drawing.Size(107, 35);
            this.MenuBitacora.Text = "Bitacora FollowUp";
            this.MenuBitacora.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuBitacora.Click += new System.EventHandler(this.MenuBitacora_Click);
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
            // TxtDescription
            // 
            this.TxtDescription.Location = new System.Drawing.Point(90, 317);
            this.TxtDescription.Name = "TxtDescription";
            this.TxtDescription.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescription.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.TxtDescription.Properties.Appearance.Options.UseFont = true;
            this.TxtDescription.Properties.Appearance.Options.UseForeColor = true;
            this.TxtDescription.Size = new System.Drawing.Size(339, 93);
            this.TxtDescription.TabIndex = 4;
            this.TxtDescription.EditValueChanged += new System.EventHandler(this.TxtDescription_EditValueChanged);
            this.TxtDescription.Enter += new System.EventHandler(this.TxtDescription_Enter);
            this.TxtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDescription_KeyPress);
            // 
            // labelControl5
            // 
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(12, 116);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(73, 31);
            this.labelControl5.TabIndex = 15;
            this.labelControl5.Text = "Cliente/Target:";
            // 
            // lblllamada
            // 
            this.lblllamada.Location = new System.Drawing.Point(12, 322);
            this.lblllamada.Name = "lblllamada";
            this.lblllamada.Size = new System.Drawing.Size(43, 13);
            this.lblllamada.TabIndex = 14;
            this.lblllamada.Text = "Llamada:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 205);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(30, 13);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Tema:";
            // 
            // labelControl3
            // 
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(12, 142);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(73, 31);
            this.labelControl3.TabIndex = 19;
            this.labelControl3.Text = "Contacto:";
            // 
            // labelControl4
            // 
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(12, 168);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(73, 31);
            this.labelControl4.TabIndex = 21;
            this.labelControl4.Text = "Fecha:";
            // 
            // DtFechaHora
            // 
            this.DtFechaHora.EditValue = new System.DateTime(((long)(0)));
            this.DtFechaHora.EnterMoveNextControl = true;
            this.DtFechaHora.Location = new System.Drawing.Point(91, 174);
            this.DtFechaHora.Name = "DtFechaHora";
            this.DtFechaHora.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DtFechaHora.Properties.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm";
            this.DtFechaHora.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DtFechaHora.Properties.EditFormat.FormatString = "dd-MM-yyyy HH:mm";
            this.DtFechaHora.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DtFechaHora.Properties.Mask.EditMask = "g";
            this.DtFechaHora.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DtFechaHora.Properties.VistaTimeProperties.DisplayFormat.FormatString = "d";
            this.DtFechaHora.Properties.VistaTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DtFechaHora.Properties.VistaTimeProperties.EditFormat.FormatString = "d";
            this.DtFechaHora.Properties.VistaTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DtFechaHora.Size = new System.Drawing.Size(135, 20);
            this.DtFechaHora.TabIndex = 3;
            this.DtFechaHora.EditValueChanged += new System.EventHandler(this.DtFechaHora_EditValueChanged);
            this.DtFechaHora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DtFechaHora_KeyPress);
            // 
            // CboContactos
            // 
            this.CboContactos.Location = new System.Drawing.Point(91, 148);
            this.CboContactos.Name = "CboContactos";
            this.CboContactos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CboContactos.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.CboContactos.Size = new System.Drawing.Size(338, 20);
            this.CboContactos.TabIndex = 1;
            this.CboContactos.Enter += new System.EventHandler(this.CboContactos_Enter);
            this.CboContactos.Leave += new System.EventHandler(this.CboContactos_Leave);
            this.CboContactos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboContactos_KeyPress);
            // 
            // CboCliente
            // 
            this.CboCliente.Location = new System.Drawing.Point(91, 122);
            this.CboCliente.Name = "CboCliente";
            this.CboCliente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CboCliente.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.CboCliente.Size = new System.Drawing.Size(338, 20);
            this.CboCliente.TabIndex = 0;
            this.CboCliente.SelectedIndexChanged += new System.EventHandler(this.CboCliente_SelectedIndexChanged);
            this.CboCliente.Enter += new System.EventHandler(this.CboCliente_Enter);
            this.CboCliente.Leave += new System.EventHandler(this.CboCliente_Leave);
            this.CboCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboCliente_KeyPress);
            // 
            // gridOportunidadesCliente
            // 
            this.gridOportunidadesCliente.Location = new System.Drawing.Point(7, 19);
            this.gridOportunidadesCliente.MainView = this.gridView1;
            this.gridOportunidadesCliente.Name = "gridOportunidadesCliente";
            this.gridOportunidadesCliente.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repSel,
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.gridOportunidadesCliente.Size = new System.Drawing.Size(521, 107);
            this.gridOportunidadesCliente.TabIndex = 6;
            this.gridOportunidadesCliente.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            this.gridOportunidadesCliente.Click += new System.EventHandler(this.gridOportunidadesCliente_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColCodigo,
            this.gridTema,
            this.gridVendedor,
            this.gridEstado,
            this.gridSeleccion});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(1062, 504, 208, 170);
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.gridOportunidadesCliente;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.CacheValuesOnRowUpdating = DevExpress.Data.CacheRowValuesMode.Disabled;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            // 
            // gridColCodigo
            // 
            this.gridColCodigo.Caption = "Código";
            this.gridColCodigo.FieldName = "ObjOportunidadPaso.Codigo";
            this.gridColCodigo.Name = "gridColCodigo";
            this.gridColCodigo.OptionsColumn.AllowEdit = false;
            this.gridColCodigo.OptionsColumn.ReadOnly = true;
            this.gridColCodigo.Visible = true;
            this.gridColCodigo.VisibleIndex = 0;
            this.gridColCodigo.Width = 60;
            // 
            // gridTema
            // 
            this.gridTema.AppearanceHeader.Options.UseTextOptions = true;
            this.gridTema.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridTema.Caption = "Tema";
            this.gridTema.FieldName = "ObjOportunidadPaso.Tema";
            this.gridTema.Name = "gridTema";
            this.gridTema.OptionsColumn.AllowEdit = false;
            this.gridTema.OptionsColumn.ReadOnly = true;
            this.gridTema.Visible = true;
            this.gridTema.VisibleIndex = 1;
            this.gridTema.Width = 204;
            // 
            // gridVendedor
            // 
            this.gridVendedor.AppearanceHeader.Options.UseTextOptions = true;
            this.gridVendedor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridVendedor.Caption = "Vendedor";
            this.gridVendedor.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridVendedor.FieldName = "ObjOportunidadPaso.IdVendedor";
            this.gridVendedor.Name = "gridVendedor";
            this.gridVendedor.OptionsColumn.ReadOnly = true;
            this.gridVendedor.Visible = true;
            this.gridVendedor.VisibleIndex = 2;
            this.gridVendedor.Width = 127;
            // 
            // gridEstado
            // 
            this.gridEstado.AppearanceHeader.Options.UseTextOptions = true;
            this.gridEstado.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridEstado.Caption = "Estado";
            this.gridEstado.FieldName = "ObjOportunidadPaso.IdEstado";
            this.gridEstado.Name = "gridEstado";
            this.gridEstado.OptionsColumn.ReadOnly = true;
            this.gridEstado.Visible = true;
            this.gridEstado.VisibleIndex = 3;
            this.gridEstado.Width = 59;
            // 
            // gridSeleccion
            // 
            this.gridSeleccion.AppearanceHeader.Options.UseTextOptions = true;
            this.gridSeleccion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridSeleccion.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridSeleccion.Caption = "Sel";
            this.gridSeleccion.ColumnEdit = this.repSel;
            this.gridSeleccion.FieldName = "MarcaOportunidad";
            this.gridSeleccion.Name = "gridSeleccion";
            this.gridSeleccion.Visible = true;
            this.gridSeleccion.VisibleIndex = 4;
            this.gridSeleccion.Width = 60;
            // 
            // repSel
            // 
            this.repSel.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("repSel.Appearance.Image")));
            this.repSel.Appearance.Options.UseImage = true;
            this.repSel.AutoHeight = false;
            this.repSel.Name = "repSel";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridOportunidadesCliente;
            this.gridView2.Name = "gridView2";
            // 
            // grpOportunidades
            // 
            this.grpOportunidades.Controls.Add(this.gridOportunidadesCliente);
            this.grpOportunidades.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOportunidades.ForeColor = System.Drawing.Color.DarkBlue;
            this.grpOportunidades.Location = new System.Drawing.Point(435, 42);
            this.grpOportunidades.Name = "grpOportunidades";
            this.grpOportunidades.Size = new System.Drawing.Size(534, 136);
            this.grpOportunidades.TabIndex = 30;
            this.grpOportunidades.TabStop = false;
            this.grpOportunidades.Text = "Oportunidades Abiertas del Cliente";
            this.grpOportunidades.Enter += new System.EventHandler(this.grpOportunidades_Enter);
            // 
            // ctrldxError
            // 
            this.ctrldxError.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.xtraTabActividades);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox1.Location = new System.Drawing.Point(435, 184);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 226);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actividades Recientes";
            // 
            // xtraTabActividades
            // 
            this.xtraTabActividades.Location = new System.Drawing.Point(7, 20);
            this.xtraTabActividades.Name = "xtraTabActividades";
            this.xtraTabActividades.SelectedTabPage = this.xtraTabLlamadas;
            this.xtraTabActividades.Size = new System.Drawing.Size(521, 206);
            this.xtraTabActividades.TabIndex = 0;
            this.xtraTabActividades.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabLlamadas,
            this.xtraTabeMails,
            this.xtraTabCasos});
            // 
            // xtraTabLlamadas
            // 
            this.xtraTabLlamadas.Appearance.Header.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabLlamadas.Appearance.Header.Image")));
            this.xtraTabLlamadas.Appearance.Header.Options.UseImage = true;
            this.xtraTabLlamadas.Appearance.Header.Options.UseTextOptions = true;
            this.xtraTabLlamadas.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.xtraTabLlamadas.Controls.Add(this.gridActividades);
            this.xtraTabLlamadas.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabLlamadas.Image")));
            this.xtraTabLlamadas.Name = "xtraTabLlamadas";
            this.xtraTabLlamadas.Size = new System.Drawing.Size(512, 173);
            // 
            // gridActividades
            // 
            this.gridActividades.Location = new System.Drawing.Point(3, 3);
            this.gridActividades.MainView = this.gridViewLlamadas;
            this.gridActividades.Name = "gridActividades";
            this.gridActividades.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit3,
            this.repositoryItemCheckEdit4,
            this.repositoryItemCheckEdit5,
            this.repositoryItemMemoEdit1,
            this.repositoryItemMemoExEdit1});
            this.gridActividades.Size = new System.Drawing.Size(506, 161);
            this.gridActividades.TabIndex = 7;
            this.gridActividades.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLlamadas,
            this.gridView4});
            this.gridActividades.Click += new System.EventHandler(this.gridActividades_Click);
            // 
            // gridViewLlamadas
            // 
            this.gridViewLlamadas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColFecha,
            this.gridColLlamada,
            this.gridColContacto,
            this.gridColUsuario});
            this.gridViewLlamadas.CustomizationFormBounds = new System.Drawing.Rectangle(1062, 504, 208, 170);
            this.gridViewLlamadas.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridViewLlamadas.GridControl = this.gridActividades;
            this.gridViewLlamadas.Name = "gridViewLlamadas";
            this.gridViewLlamadas.OptionsBehavior.CacheValuesOnRowUpdating = DevExpress.Data.CacheRowValuesMode.Disabled;
            this.gridViewLlamadas.OptionsView.ShowGroupPanel = false;
            // 
            // gridColFecha
            // 
            this.gridColFecha.Caption = "Fecha";
            this.gridColFecha.DisplayFormat.FormatString = "dd-MM-yyyy hh:mm";
            this.gridColFecha.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColFecha.FieldName = "FechaHora";
            this.gridColFecha.Name = "gridColFecha";
            this.gridColFecha.OptionsColumn.AllowEdit = false;
            this.gridColFecha.OptionsColumn.ReadOnly = true;
            this.gridColFecha.Visible = true;
            this.gridColFecha.VisibleIndex = 0;
            this.gridColFecha.Width = 207;
            // 
            // gridColLlamada
            // 
            this.gridColLlamada.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColLlamada.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColLlamada.Caption = "Llamada";
            this.gridColLlamada.ColumnEdit = this.repositoryItemMemoExEdit1;
            this.gridColLlamada.FieldName = "Descripcion";
            this.gridColLlamada.Name = "gridColLlamada";
            this.gridColLlamada.OptionsColumn.ReadOnly = true;
            this.gridColLlamada.Width = 586;
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            this.repositoryItemMemoExEdit1.ShowIcon = false;
            // 
            // gridColContacto
            // 
            this.gridColContacto.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColContacto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColContacto.Caption = "Contacto";
            this.gridColContacto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColContacto.FieldName = "ObjContacto.Nombre";
            this.gridColContacto.Name = "gridColContacto";
            this.gridColContacto.OptionsColumn.ReadOnly = true;
            this.gridColContacto.Visible = true;
            this.gridColContacto.VisibleIndex = 1;
            this.gridColContacto.Width = 185;
            // 
            // gridColUsuario
            // 
            this.gridColUsuario.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColUsuario.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColUsuario.Caption = "Usuario";
            this.gridColUsuario.FieldName = "ObjUsuario.Nombre";
            this.gridColUsuario.Name = "gridColUsuario";
            this.gridColUsuario.OptionsColumn.ReadOnly = true;
            this.gridColUsuario.Visible = true;
            this.gridColUsuario.VisibleIndex = 2;
            this.gridColUsuario.Width = 110;
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemCheckEdit3.Appearance.Image")));
            this.repositoryItemCheckEdit3.Appearance.Options.UseImage = true;
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // repositoryItemCheckEdit4
            // 
            this.repositoryItemCheckEdit4.AutoHeight = false;
            this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            // 
            // repositoryItemCheckEdit5
            // 
            this.repositoryItemCheckEdit5.AutoHeight = false;
            this.repositoryItemCheckEdit5.Name = "repositoryItemCheckEdit5";
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.gridActividades;
            this.gridView4.Name = "gridView4";
            // 
            // xtraTabeMails
            // 
            this.xtraTabeMails.Appearance.Header.Options.UseTextOptions = true;
            this.xtraTabeMails.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.xtraTabeMails.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabeMails.Image")));
            this.xtraTabeMails.Name = "xtraTabeMails";
            this.xtraTabeMails.Size = new System.Drawing.Size(512, 173);
            // 
            // xtraTabCasos
            // 
            this.xtraTabCasos.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabCasos.Image")));
            this.xtraTabCasos.Name = "xtraTabCasos";
            this.xtraTabCasos.Size = new System.Drawing.Size(512, 173);
            // 
            // checkListBoxTiposAsunto
            // 
            this.checkListBoxTiposAsunto.CheckOnClick = true;
            this.checkListBoxTiposAsunto.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Item1"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Item2"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Item3"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Item4"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Item5"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Item6"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Item7"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Item8")});
            this.checkListBoxTiposAsunto.Location = new System.Drawing.Point(90, 204);
            this.checkListBoxTiposAsunto.MultiColumn = true;
            this.checkListBoxTiposAsunto.Name = "checkListBoxTiposAsunto";
            this.checkListBoxTiposAsunto.Size = new System.Drawing.Size(324, 107);
            this.checkListBoxTiposAsunto.TabIndex = 32;
            // 
            // groupBoxTipoLlamada
            // 
            this.groupBoxTipoLlamada.Controls.Add(this.radioButtonEntrante);
            this.groupBoxTipoLlamada.Controls.Add(this.radioButtonSaliente);
            this.groupBoxTipoLlamada.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxTipoLlamada.ForeColor = System.Drawing.Color.Black;
            this.groupBoxTipoLlamada.Location = new System.Drawing.Point(12, 46);
            this.groupBoxTipoLlamada.Name = "groupBoxTipoLlamada";
            this.groupBoxTipoLlamada.Size = new System.Drawing.Size(248, 41);
            this.groupBoxTipoLlamada.TabIndex = 35;
            this.groupBoxTipoLlamada.TabStop = false;
            this.groupBoxTipoLlamada.Text = "Tipo Llamada";
            // 
            // radioButtonEntrante
            // 
            this.radioButtonEntrante.AutoSize = true;
            this.radioButtonEntrante.Location = new System.Drawing.Point(123, 15);
            this.radioButtonEntrante.Name = "radioButtonEntrante";
            this.radioButtonEntrante.Size = new System.Drawing.Size(67, 17);
            this.radioButtonEntrante.TabIndex = 35;
            this.radioButtonEntrante.Text = "Entrante";
            this.radioButtonEntrante.UseVisualStyleBackColor = true;
            this.radioButtonEntrante.CheckedChanged += new System.EventHandler(this.radioButtonEntrante_CheckedChanged);
            // 
            // radioButtonSaliente
            // 
            this.radioButtonSaliente.AutoSize = true;
            this.radioButtonSaliente.Checked = true;
            this.radioButtonSaliente.Location = new System.Drawing.Point(51, 15);
            this.radioButtonSaliente.Name = "radioButtonSaliente";
            this.radioButtonSaliente.Size = new System.Drawing.Size(63, 17);
            this.radioButtonSaliente.TabIndex = 34;
            this.radioButtonSaliente.TabStop = true;
            this.radioButtonSaliente.Text = "Saliente";
            this.radioButtonSaliente.UseVisualStyleBackColor = true;
            this.radioButtonSaliente.CheckedChanged += new System.EventHandler(this.radioButtonSaliente_CheckedChanged);
            // 
            // checkBoxImportancia
            // 
            this.checkBoxImportancia.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxImportancia.Image = ((System.Drawing.Image)(resources.GetObject("checkBoxImportancia.Image")));
            this.checkBoxImportancia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBoxImportancia.Location = new System.Drawing.Point(321, 49);
            this.checkBoxImportancia.Name = "checkBoxImportancia";
            this.checkBoxImportancia.Size = new System.Drawing.Size(107, 29);
            this.checkBoxImportancia.TabIndex = 36;
            this.checkBoxImportancia.Text = "Importancia Alta";
            this.checkBoxImportancia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxImportancia.UseVisualStyleBackColor = true;
            this.checkBoxImportancia.CheckedChanged += new System.EventHandler(this.checkBoxImportancia_CheckedChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Location = new System.Drawing.Point(12, 87);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(73, 31);
            this.labelControl6.TabIndex = 37;
            this.labelControl6.Text = "Tipo Producto:";
            // 
            // comboBoxTipoProducto
            // 
            this.comboBoxTipoProducto.Location = new System.Drawing.Point(91, 93);
            this.comboBoxTipoProducto.Name = "comboBoxTipoProducto";
            this.comboBoxTipoProducto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxTipoProducto.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxTipoProducto.Size = new System.Drawing.Size(338, 20);
            this.comboBoxTipoProducto.TabIndex = 38;
            this.comboBoxTipoProducto.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoProducto_SelectedIndexChanged);
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
            this.gridFollowUp.Size = new System.Drawing.Size(438, 126);
            this.gridFollowUp.TabIndex = 40;
            this.gridFollowUp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            this.gridFollowUp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridFollowUp_KeyDown);
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
            this.groupBox2.Location = new System.Drawing.Point(12, 416);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(894, 172);
            this.groupBox2.TabIndex = 32;
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
            this.sButtonEliminarTrafico.Click += new System.EventHandler(this.BtnBorrarFollowUp_Click);
            // 
            // sButtonAgregarTrafico
            // 
            this.sButtonAgregarTrafico.Image = ((System.Drawing.Image)(resources.GetObject("sButtonAgregarTrafico.Image")));
            this.sButtonAgregarTrafico.Location = new System.Drawing.Point(376, 79);
            this.sButtonAgregarTrafico.Name = "sButtonAgregarTrafico";
            this.sButtonAgregarTrafico.Size = new System.Drawing.Size(27, 24);
            this.sButtonAgregarTrafico.TabIndex = 45;
            this.sButtonAgregarTrafico.Click += new System.EventHandler(this.BtnAsignarFollowUp_Click);
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
            // FrmLlamadaTelefonica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 594);
            this.Controls.Add(this.comboBoxTipoProducto);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.checkBoxImportancia);
            this.Controls.Add(this.groupBoxTipoLlamada);
            this.Controls.Add(this.checkListBoxTiposAsunto);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpOportunidades);
            this.Controls.Add(this.CboCliente);
            this.Controls.Add(this.CboContactos);
            this.Controls.Add(this.DtFechaHora);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.TxtDescription);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.lblllamada);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.toolStripBarraLlamada);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLlamadaTelefonica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar Llamada Telefónica";
            this.Load += new System.EventHandler(this.FrmLlamadaTelefonica_Load);
            this.Activated += new System.EventHandler(this.FrmLlamadaTelefonica_Activated);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.FrmLlamadaTelefonica_Layout);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLlamadaTelefonica_FormClosed);
            this.toolStripBarraLlamada.ResumeLayout(false);
            this.toolStripBarraLlamada.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtFechaHora.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtFechaHora.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboContactos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOportunidadesCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.grpOportunidades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctrldxError)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabActividades)).EndInit();
            this.xtraTabActividades.ResumeLayout(false);
            this.xtraTabLlamadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridActividades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLlamadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkListBoxTiposAsunto)).EndInit();
            this.groupBoxTipoLlamada.ResumeLayout(false);
            this.groupBoxTipoLlamada.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTipoProducto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFollowUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcionFollowUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboActividadFollowUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaFollowUp.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaFollowUp.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripBarraLlamada;
        private System.Windows.Forms.ToolStripButton MenuGuardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton MenuSalir;
        private System.Windows.Forms.ToolStripButton MenuCrearOportunidad;
        private DevExpress.XtraEditors.MemoEdit TxtDescription;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl lblllamada;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit DtFechaHora;
        private DevExpress.XtraEditors.ComboBoxEdit CboContactos;
        private DevExpress.XtraEditors.ComboBoxEdit CboCliente;
        private System.Windows.Forms.ToolStripButton MenuNuevo;
        private DevExpress.XtraGrid.GridControl gridOportunidadesCliente;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gridTema;
        private DevExpress.XtraGrid.Columns.GridColumn gridVendedor;
        private DevExpress.XtraGrid.Columns.GridColumn gridEstado;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repSel;
        private System.Windows.Forms.GroupBox grpOportunidades;
        private DevExpress.XtraGrid.Columns.GridColumn gridSeleccion;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider ctrldxError;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraTab.XtraTabControl xtraTabActividades;
        private DevExpress.XtraTab.XtraTabPage xtraTabLlamadas;
        private DevExpress.XtraTab.XtraTabPage xtraTabeMails;
        private DevExpress.XtraGrid.GridControl gridActividades;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLlamadas;
        private DevExpress.XtraGrid.Columns.GridColumn gridColFecha;
        private DevExpress.XtraGrid.Columns.GridColumn gridColLlamada;
        private DevExpress.XtraGrid.Columns.GridColumn gridColContacto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUsuario;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit5;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraTab.XtraTabPage xtraTabCasos;
        private DevExpress.XtraEditors.CheckedListBoxControl checkListBoxTiposAsunto;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private System.Windows.Forms.GroupBox groupBoxTipoLlamada;
        private System.Windows.Forms.RadioButton radioButtonEntrante;
        private System.Windows.Forms.RadioButton radioButtonSaliente;
        private System.Windows.Forms.CheckBox checkBoxImportancia;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxTipoProducto;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private System.Windows.Forms.ToolStripButton MenuBitacora;
        private DevExpress.XtraGrid.GridControl gridFollowUp;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.MemoEdit txtDescripcionFollowUp;
        private DevExpress.XtraEditors.ComboBoxEdit cboActividadFollowUp;
        private DevExpress.XtraEditors.DateEdit dtFechaFollowUp;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraEditors.SimpleButton sButtonEliminarTrafico;
        private DevExpress.XtraEditors.SimpleButton sButtonAgregarTrafico;
    }
}