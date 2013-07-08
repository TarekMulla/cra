using System.Globalization;


namespace SCCMultimodal.Cotizaciones {
    partial class FrmCotizacionDirecta {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCotizacionDirecta));
            this.repositoryItemComboBox23 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemMemoExEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.grpOportunidad = new System.Windows.Forms.GroupBox();
            this.LblEstado = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.TxtObservaciones = new DevExpress.XtraEditors.MemoEdit();
            this.LblGastosLocales = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RemovePod = new DevExpress.XtraEditors.SimpleButton();
            this.AddPod = new DevExpress.XtraEditors.SimpleButton();
            this.ListPodSeleccionado = new DevExpress.XtraEditors.ListBoxControl();
            this.ListPod = new DevExpress.XtraEditors.ListBoxControl();
            this.ListPolSeleccionado = new DevExpress.XtraEditors.ListBoxControl();
            this.RemovePol = new DevExpress.XtraEditors.SimpleButton();
            this.AddPol = new DevExpress.XtraEditors.SimpleButton();
            this.ListPol = new DevExpress.XtraEditors.ListBoxControl();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TxtTiempoTransito = new DevExpress.XtraEditors.TextEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtFechaValidezFin = new DevExpress.XtraEditors.DateEdit();
            this.txtFechaValidezIni = new DevExpress.XtraEditors.DateEdit();
            this.CboNaviera = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.AgregarDetalle = new DevExpress.XtraEditors.SimpleButton();
            this.EliminarDetalle = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.GridOpcionDetalle = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemFontEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemFontEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.chkincoterm = new System.Windows.Forms.RadioButton();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.CboCliente = new DevExpress.XtraEditors.ComboBoxEdit();
            this.TxtFecha = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtCommodity = new DevExpress.XtraEditors.TextEdit();
            this.txtEjecutivo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.TxtGastosLocales = new DevExpress.XtraEditors.TextEdit();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSalir = new System.Windows.Forms.ToolStripButton();
            this.ctrldxError = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).BeginInit();
            this.grpOportunidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtObservaciones.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListPodSeleccionado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPolSeleccionado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTiempoTransito.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaValidezFin.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaValidezFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaValidezIni.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaValidezIni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboNaviera.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridOpcionDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFecha.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCommodity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEjecutivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtGastosLocales.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrldxError)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemComboBox23
            // 
            this.repositoryItemComboBox23.AutoHeight = false;
            this.repositoryItemComboBox23.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox23.Name = "repositoryItemComboBox23";
            this.repositoryItemComboBox23.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // repositoryItemMemoExEdit2
            // 
            this.repositoryItemMemoExEdit2.AutoHeight = false;
            this.repositoryItemMemoExEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit2.Name = "repositoryItemMemoExEdit2";
            this.repositoryItemMemoExEdit2.ShowIcon = false;
            // 
            // grpOportunidad
            // 
            this.grpOportunidad.Controls.Add(this.LblEstado);
            this.grpOportunidad.Controls.Add(this.labelControl11);
            this.grpOportunidad.Controls.Add(this.TxtObservaciones);
            this.grpOportunidad.Controls.Add(this.LblGastosLocales);
            this.grpOportunidad.Controls.Add(this.comboBoxEdit1);
            this.grpOportunidad.Controls.Add(this.labelControl16);
            this.grpOportunidad.Controls.Add(this.groupBox1);
            this.grpOportunidad.Controls.Add(this.chkincoterm);
            this.grpOportunidad.Controls.Add(this.labelControl12);
            this.grpOportunidad.Controls.Add(this.labelControl13);
            this.grpOportunidad.Controls.Add(this.CboCliente);
            this.grpOportunidad.Controls.Add(this.TxtFecha);
            this.grpOportunidad.Controls.Add(this.labelControl3);
            this.grpOportunidad.Controls.Add(this.txtCommodity);
            this.grpOportunidad.Controls.Add(this.txtEjecutivo);
            this.grpOportunidad.Controls.Add(this.labelControl9);
            this.grpOportunidad.Controls.Add(this.labelControl1);
            this.grpOportunidad.Controls.Add(this.labelControl2);
            this.grpOportunidad.Controls.Add(this.labelControl4);
            this.grpOportunidad.Controls.Add(this.TxtGastosLocales);
            this.grpOportunidad.Location = new System.Drawing.Point(3, 43);
            this.grpOportunidad.Name = "grpOportunidad";
            this.grpOportunidad.Size = new System.Drawing.Size(711, 614);
            this.grpOportunidad.TabIndex = 34;
            this.grpOportunidad.TabStop = false;
            this.grpOportunidad.Text = "General";
            // 
            // LblEstado
            // 
            this.LblEstado.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.LblEstado.Appearance.Options.UseBorderColor = true;
            this.LblEstado.Appearance.Options.UseFont = true;
            this.LblEstado.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LblEstado.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.LblEstado.Location = new System.Drawing.Point(125, 182);
            this.LblEstado.Name = "LblEstado";
            this.LblEstado.Size = new System.Drawing.Size(117, 25);
            this.LblEstado.TabIndex = 117;
            this.LblEstado.Text = "labelControl17";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(9, 188);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(33, 13);
            this.labelControl11.TabIndex = 116;
            this.labelControl11.Text = "Estado";
            // 
            // TxtObservaciones
            // 
            this.TxtObservaciones.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.TxtObservaciones.EditValue = "";
            this.TxtObservaciones.Location = new System.Drawing.Point(435, 56);
            this.TxtObservaciones.Name = "TxtObservaciones";
            this.TxtObservaciones.Properties.Appearance.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtObservaciones.Properties.Appearance.Options.UseFont = true;
            this.TxtObservaciones.Size = new System.Drawing.Size(239, 135);
            this.TxtObservaciones.TabIndex = 12;
            // 
            // LblGastosLocales
            // 
            this.LblGastosLocales.Location = new System.Drawing.Point(601, 29);
            this.LblGastosLocales.Name = "LblGastosLocales";
            this.LblGastosLocales.Size = new System.Drawing.Size(0, 13);
            this.LblGastosLocales.TabIndex = 115;
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.EditValue = "FCL Importacion";
            this.comboBoxEdit1.Location = new System.Drawing.Point(125, 52);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.Items.AddRange(new object[] {
            "FCL Importacion"});
            this.comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit1.Size = new System.Drawing.Size(135, 20);
            this.comboBoxEdit1.TabIndex = 114;
            this.comboBoxEdit1.UseWaitCursor = true;
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(9, 55);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(43, 13);
            this.labelControl16.TabIndex = 113;
            this.labelControl16.Text = "Producto";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RemovePod);
            this.groupBox1.Controls.Add(this.AddPod);
            this.groupBox1.Controls.Add(this.ListPodSeleccionado);
            this.groupBox1.Controls.Add(this.ListPod);
            this.groupBox1.Controls.Add(this.ListPolSeleccionado);
            this.groupBox1.Controls.Add(this.RemovePol);
            this.groupBox1.Controls.Add(this.AddPol);
            this.groupBox1.Controls.Add(this.ListPol);
            this.groupBox1.Controls.Add(this.bindingNavigator1);
            this.groupBox1.Controls.Add(this.TxtTiempoTransito);
            this.groupBox1.Controls.Add(this.labelControl15);
            this.groupBox1.Controls.Add(this.labelControl8);
            this.groupBox1.Controls.Add(this.labelControl10);
            this.groupBox1.Controls.Add(this.txtFechaValidezFin);
            this.groupBox1.Controls.Add(this.txtFechaValidezIni);
            this.groupBox1.Controls.Add(this.CboNaviera);
            this.groupBox1.Controls.Add(this.labelControl14);
            this.groupBox1.Controls.Add(this.AgregarDetalle);
            this.groupBox1.Controls.Add(this.EliminarDetalle);
            this.groupBox1.Controls.Add(this.labelControl6);
            this.groupBox1.Controls.Add(this.GridOpcionDetalle);
            this.groupBox1.Controls.Add(this.labelControl7);
            this.groupBox1.Controls.Add(this.labelControl5);
            this.groupBox1.Location = new System.Drawing.Point(9, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(687, 407);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            // 
            // RemovePod
            // 
            this.RemovePod.Location = new System.Drawing.Point(470, 166);
            this.RemovePod.Name = "RemovePod";
            this.RemovePod.Size = new System.Drawing.Size(40, 23);
            this.RemovePod.TabIndex = 127;
            this.RemovePod.Text = "<<";
            this.RemovePod.Click += new System.EventHandler(this.RemovePod_Click);
            // 
            // AddPod
            // 
            this.AddPod.Location = new System.Drawing.Point(470, 122);
            this.AddPod.Name = "AddPod";
            this.AddPod.Size = new System.Drawing.Size(40, 23);
            this.AddPod.TabIndex = 126;
            this.AddPod.Text = ">>";
            this.AddPod.Click += new System.EventHandler(this.AddPod_Click);
            // 
            // ListPodSeleccionado
            // 
            this.ListPodSeleccionado.Location = new System.Drawing.Point(536, 105);
            this.ListPodSeleccionado.Name = "ListPodSeleccionado";
            this.ListPodSeleccionado.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListPodSeleccionado.Size = new System.Drawing.Size(104, 95);
            this.ListPodSeleccionado.TabIndex = 125;
            // 
            // ListPod
            // 
            this.ListPod.Location = new System.Drawing.Point(349, 105);
            this.ListPod.Name = "ListPod";
            this.ListPod.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListPod.Size = new System.Drawing.Size(104, 95);
            this.ListPod.TabIndex = 122;
            // 
            // ListPolSeleccionado
            // 
            this.ListPolSeleccionado.Location = new System.Drawing.Point(208, 108);
            this.ListPolSeleccionado.Name = "ListPolSeleccionado";
            this.ListPolSeleccionado.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListPolSeleccionado.Size = new System.Drawing.Size(104, 95);
            this.ListPolSeleccionado.TabIndex = 121;
            // 
            // RemovePol
            // 
            this.RemovePol.Location = new System.Drawing.Point(152, 164);
            this.RemovePol.Name = "RemovePol";
            this.RemovePol.Size = new System.Drawing.Size(40, 23);
            this.RemovePol.TabIndex = 120;
            this.RemovePol.Text = "<<";
            this.RemovePol.Click += new System.EventHandler(this.RemovePol_Click);
            // 
            // AddPol
            // 
            this.AddPol.Location = new System.Drawing.Point(152, 120);
            this.AddPol.Name = "AddPol";
            this.AddPol.Size = new System.Drawing.Size(40, 23);
            this.AddPol.TabIndex = 119;
            this.AddPol.Text = ">>";
            this.AddPol.Click += new System.EventHandler(this.AddPol_Click);
            // 
            // ListPol
            // 
            this.ListPol.Appearance.ForeColor = System.Drawing.Color.Black;
            this.ListPol.Appearance.Options.UseForeColor = true;
            this.ListPol.Location = new System.Drawing.Point(38, 108);
            this.ListPol.Name = "ListPol";
            this.ListPol.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListPol.Size = new System.Drawing.Size(104, 95);
            this.ListPol.TabIndex = 117;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(3, 16);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(681, 25);
            this.bindingNavigator1.TabIndex = 114;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(36, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // TxtTiempoTransito
            // 
            this.TxtTiempoTransito.Location = new System.Drawing.Point(140, 238);
            this.TxtTiempoTransito.Name = "TxtTiempoTransito";
            this.TxtTiempoTransito.Size = new System.Drawing.Size(371, 20);
            this.TxtTiempoTransito.TabIndex = 112;
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(16, 245);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(89, 13);
            this.labelControl15.TabIndex = 113;
            this.labelControl15.Text = "Tiempo en transito";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(19, 58);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(37, 13);
            this.labelControl8.TabIndex = 111;
            this.labelControl8.Text = "Naviera";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(326, 216);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(82, 13);
            this.labelControl10.TabIndex = 109;
            this.labelControl10.Text = "Fecha validez Fin";
            // 
            // txtFechaValidezFin
            // 
            this.txtFechaValidezFin.EditValue = null;
            this.txtFechaValidezFin.Location = new System.Drawing.Point(425, 209);
            this.txtFechaValidezFin.Name = "txtFechaValidezFin";
            this.txtFechaValidezFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFechaValidezFin.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtFechaValidezFin.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtFechaValidezFin.Size = new System.Drawing.Size(171, 20);
            this.txtFechaValidezFin.TabIndex = 108;
            // 
            // txtFechaValidezIni
            // 
            this.txtFechaValidezIni.EditValue = null;
            this.txtFechaValidezIni.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtFechaValidezIni.Location = new System.Drawing.Point(140, 209);
            this.txtFechaValidezIni.Name = "txtFechaValidezIni";
            this.txtFechaValidezIni.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFechaValidezIni.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtFechaValidezIni.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtFechaValidezIni.Size = new System.Drawing.Size(148, 20);
            this.txtFechaValidezIni.TabIndex = 106;
            // 
            // CboNaviera
            // 
            this.CboNaviera.EditValue = "";
            this.CboNaviera.Location = new System.Drawing.Point(140, 55);
            this.CboNaviera.Name = "CboNaviera";
            this.CboNaviera.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CboNaviera.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.CboNaviera.Size = new System.Drawing.Size(158, 20);
            this.CboNaviera.TabIndex = 17;
            this.CboNaviera.SelectedIndexChanged += new System.EventHandler(this.CboNaviera_SelectedIndexChanged);
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(16, 216);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(93, 13);
            this.labelControl14.TabIndex = 107;
            this.labelControl14.Text = "Fecha validez Inicio";
            // 
            // AgregarDetalle
            // 
            this.AgregarDetalle.Image = ((System.Drawing.Image)(resources.GetObject("AgregarDetalle.Image")));
            this.AgregarDetalle.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.AgregarDetalle.Location = new System.Drawing.Point(643, 312);
            this.AgregarDetalle.Name = "AgregarDetalle";
            this.AgregarDetalle.Size = new System.Drawing.Size(32, 24);
            this.AgregarDetalle.TabIndex = 7;
            this.AgregarDetalle.Click += new System.EventHandler(this.AgregarDetalle_Click);
            // 
            // EliminarDetalle
            // 
            this.EliminarDetalle.AutoSizeInLayoutControl = true;
            this.EliminarDetalle.Image = ((System.Drawing.Image)(resources.GetObject("EliminarDetalle.Image")));
            this.EliminarDetalle.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.EliminarDetalle.Location = new System.Drawing.Point(643, 269);
            this.EliminarDetalle.Name = "EliminarDetalle";
            this.EliminarDetalle.Size = new System.Drawing.Size(32, 24);
            this.EliminarDetalle.TabIndex = 6;
            this.EliminarDetalle.Click += new System.EventHandler(this.sButtonEliminarUnidad_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(326, 82);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(21, 13);
            this.labelControl6.TabIndex = 6;
            this.labelControl6.Text = "POD";
            // 
            // GridOpcionDetalle
            // 
            this.GridOpcionDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GridOpcionDetalle.Location = new System.Drawing.Point(126, 266);
            this.GridOpcionDetalle.MainView = this.gridView1;
            this.GridOpcionDetalle.Name = "GridOpcionDetalle";
            this.GridOpcionDetalle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox23,
            this.repositoryItemComboBox1,
            this.repositoryItemComboBox2,
            this.repositoryItemFontEdit1,
            this.repositoryItemTextEdit1});
            this.GridOpcionDetalle.Size = new System.Drawing.Size(503, 135);
            this.GridOpcionDetalle.TabIndex = 5;
            this.GridOpcionDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn4});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(592, 334, 208, 170);
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.GridOpcionDetalle;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.CacheValuesOnRowUpdating = DevExpress.Data.CacheRowValuesMode.Disabled;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Unidad";
            this.gridColumn2.ColumnEdit = this.repositoryItemComboBox23;
            this.gridColumn2.FieldName = "Unidad";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Moneda";
            this.gridColumn3.ColumnEdit = this.repositoryItemComboBox2;
            this.gridColumn3.FieldName = "Moneda";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            this.repositoryItemComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tarifa";
            this.gridColumn1.ColumnEdit = this.repositoryItemTextEdit1;
            this.gridColumn1.DisplayFormat.FormatString = "N2";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "Venta";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.DisplayFormat.FormatString = "N2";
            this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.EditFormat.FormatString = "N2";
            this.repositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = " ";
            this.gridColumn4.ColumnEdit = this.repositoryItemComboBox1;
            this.gridColumn4.FieldName = "Concepto";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // repositoryItemFontEdit1
            // 
            this.repositoryItemFontEdit1.AutoHeight = false;
            this.repositoryItemFontEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemFontEdit1.Name = "repositoryItemFontEdit1";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.GridOpcionDetalle;
            this.gridView2.Name = "gridView2";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(18, 269);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(49, 13);
            this.labelControl7.TabIndex = 16;
            this.labelControl7.Text = "Cotización";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(19, 82);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(19, 13);
            this.labelControl5.TabIndex = 15;
            this.labelControl5.Text = "POL";
            // 
            // chkincoterm
            // 
            this.chkincoterm.AutoSize = true;
            this.chkincoterm.Checked = true;
            this.chkincoterm.Location = new System.Drawing.Point(125, 78);
            this.chkincoterm.Name = "chkincoterm";
            this.chkincoterm.Size = new System.Drawing.Size(43, 17);
            this.chkincoterm.TabIndex = 97;
            this.chkincoterm.TabStop = true;
            this.chkincoterm.Text = "Fob";
            this.chkincoterm.UseVisualStyleBackColor = true;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(343, 59);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(71, 13);
            this.labelControl12.TabIndex = 26;
            this.labelControl12.Text = "Observaciones";
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(343, 29);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(71, 13);
            this.labelControl13.TabIndex = 98;
            this.labelControl13.Text = "Gastos Locales";
            // 
            // CboCliente
            // 
            this.CboCliente.EditValue = "";
            this.CboCliente.Location = new System.Drawing.Point(125, 127);
            this.CboCliente.Name = "CboCliente";
            this.CboCliente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CboCliente.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.CboCliente.Size = new System.Drawing.Size(196, 20);
            this.CboCliente.TabIndex = 15;
            // 
            // TxtFecha
            // 
            this.TxtFecha.EditValue = null;
            this.TxtFecha.Enabled = false;
            this.TxtFecha.Location = new System.Drawing.Point(125, 101);
            this.TxtFecha.Name = "TxtFecha";
            this.TxtFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TxtFecha.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TxtFecha.Size = new System.Drawing.Size(135, 20);
            this.TxtFecha.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 104);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(85, 13);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "Fecha de solicitud";
            // 
            // txtCommodity
            // 
            this.txtCommodity.Location = new System.Drawing.Point(125, 156);
            this.txtCommodity.Name = "txtCommodity";
            this.txtCommodity.Size = new System.Drawing.Size(196, 20);
            this.txtCommodity.TabIndex = 9;
            // 
            // txtEjecutivo
            // 
            this.txtEjecutivo.Enabled = false;
            this.txtEjecutivo.Location = new System.Drawing.Point(125, 22);
            this.txtEjecutivo.Name = "txtEjecutivo";
            this.txtEjecutivo.Size = new System.Drawing.Size(196, 20);
            this.txtEjecutivo.TabIndex = 0;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(9, 159);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(53, 13);
            this.labelControl9.TabIndex = 20;
            this.labelControl9.Text = "Commodity";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(102, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Ejecutivo de Cuentas";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 129);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(33, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Cliente";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(9, 78);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(43, 13);
            this.labelControl4.TabIndex = 13;
            this.labelControl4.Text = "Incoterm";
            // 
            // TxtGastosLocales
            // 
            this.TxtGastosLocales.EditValue = "";
            this.TxtGastosLocales.Location = new System.Drawing.Point(436, 26);
            this.TxtGastosLocales.Name = "TxtGastosLocales";
            this.TxtGastosLocales.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TxtGastosLocales.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TxtGastosLocales.Properties.Mask.EditMask = "c0";
            this.TxtGastosLocales.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.TxtGastosLocales.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.TxtGastosLocales.Size = new System.Drawing.Size(152, 20);
            this.TxtGastosLocales.TabIndex = 10;
            this.TxtGastosLocales.EditValueChanged += new System.EventHandler(this.TxtGastosLocales_EditValueChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.MenuSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(721, 36);
            this.toolStrip1.TabIndex = 35;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(50, 33);
            this.toolStripButton1.Text = "Guardar";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
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
            this.MenuSalir.Click += new System.EventHandler(this.MenuSalir_Click);
            // 
            // ctrldxError
            // 
            this.ctrldxError.ContainerControl = this;
            // 
            // FrmCotizacionDirecta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 669);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.grpOportunidad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCotizacionDirecta";
            this.Text = "Ingreso de Cotizacion Directa";
            this.Load += new System.EventHandler(this.SolicitarTarifa_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCotizacionDirecta_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).EndInit();
            this.grpOportunidad.ResumeLayout(false);
            this.grpOportunidad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtObservaciones.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListPodSeleccionado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPolSeleccionado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTiempoTransito.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaValidezFin.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaValidezFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaValidezIni.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaValidezIni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboNaviera.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridOpcionDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFecha.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCommodity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEjecutivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtGastosLocales.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrldxError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpOportunidad;
        private DevExpress.XtraEditors.TextEdit txtEjecutivo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton MenuSalir;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit txtCommodity;
        private DevExpress.XtraEditors.MemoEdit TxtObservaciones;
        private DevExpress.XtraEditors.DateEdit TxtFecha;
        private DevExpress.XtraEditors.ComboBoxEdit CboCliente;
        private DevExpress.XtraEditors.ComboBoxEdit CboNaviera;
        private System.Windows.Forms.RadioButton chkincoterm;
        private DevExpress.XtraGrid.GridControl GridOpcionDetalle;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.SimpleButton AgregarDetalle;
        private DevExpress.XtraEditors.SimpleButton EliminarDetalle;
        private DevExpress.XtraEditors.TextEdit TxtGastosLocales;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.TextEdit TxtTiempoTransito;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.DateEdit txtFechaValidezFin;
        private DevExpress.XtraEditors.DateEdit txtFechaValidezIni;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LabelControl LblGastosLocales;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraEditors.ListBoxControl ListPodSeleccionado;
        private DevExpress.XtraEditors.ListBoxControl ListPod;
        private DevExpress.XtraEditors.ListBoxControl ListPolSeleccionado;
        private DevExpress.XtraEditors.SimpleButton RemovePol;
        private DevExpress.XtraEditors.SimpleButton AddPol;
        private DevExpress.XtraEditors.ListBoxControl ListPol;
        private DevExpress.XtraEditors.SimpleButton RemovePod;
        private DevExpress.XtraEditors.SimpleButton AddPod;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider ctrldxError;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemFontEdit repositoryItemFontEdit1;
        private DevExpress.XtraEditors.LabelControl LblEstado;
        private DevExpress.XtraEditors.LabelControl labelControl11;
    }
}