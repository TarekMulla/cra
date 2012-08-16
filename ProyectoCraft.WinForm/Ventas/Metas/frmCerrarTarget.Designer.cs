namespace ProyectoCraft.WinForm.Ventas.Metas
{
    partial class frmCerrarTarget
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCerrarTarget));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblVendedorAsignado = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbTarget = new System.Windows.Forms.RadioButton();
            this.rbCuenta = new System.Windows.Forms.RadioButton();
            this.cboVendedores = new DevExpress.XtraEditors.ComboBoxEdit();
            this.DateCierre = new DevExpress.XtraEditors.DateEdit();
            this.MemoObservaciones = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.TxtShippingInstruction = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.sButtonSalir = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.sButtonGrabarObs = new DevExpress.XtraEditors.SimpleButton();
            this.lblProspecto = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateCierre.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateCierre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemoObservaciones.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtShippingInstruction.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblVendedorAsignado);
            this.groupBox1.Controls.Add(this.labelControl4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cboVendedores);
            this.groupBox1.Controls.Add(this.DateCierre);
            this.groupBox1.Controls.Add(this.MemoObservaciones);
            this.groupBox1.Controls.Add(this.labelControl3);
            this.groupBox1.Controls.Add(this.TxtShippingInstruction);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.sButtonSalir);
            this.groupBox1.Controls.Add(this.labelControl5);
            this.groupBox1.Controls.Add(this.sButtonGrabarObs);
            this.groupBox1.Controls.Add(this.lblProspecto);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Controls.Add(this.labelControl6);
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 376);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblVendedorAsignado
            // 
            this.lblVendedorAsignado.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblVendedorAsignado.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.lblVendedorAsignado.Location = new System.Drawing.Point(131, 90);
            this.lblVendedorAsignado.Name = "lblVendedorAsignado";
            this.lblVendedorAsignado.Size = new System.Drawing.Size(266, 25);
            this.lblVendedorAsignado.TabIndex = 81;
            this.lblVendedorAsignado.Text = "labelControl2";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Options.UseTextOptions = true;
            this.labelControl4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(13, 124);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(97, 17);
            this.labelControl4.TabIndex = 80;
            this.labelControl4.Text = "Vendedor Cierra:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbTarget);
            this.groupBox2.Controls.Add(this.rbCuenta);
            this.groupBox2.Location = new System.Drawing.Point(10, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(197, 43);
            this.groupBox2.TabIndex = 79;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo Target";
            // 
            // rbTarget
            // 
            this.rbTarget.AutoSize = true;
            this.rbTarget.Enabled = false;
            this.rbTarget.Location = new System.Drawing.Point(101, 19);
            this.rbTarget.Name = "rbTarget";
            this.rbTarget.Size = new System.Drawing.Size(90, 17);
            this.rbTarget.TabIndex = 1;
            this.rbTarget.Text = "NuevoTráfico";
            this.rbTarget.UseVisualStyleBackColor = true;
            // 
            // rbCuenta
            // 
            this.rbCuenta.AutoSize = true;
            this.rbCuenta.Checked = true;
            this.rbCuenta.Enabled = false;
            this.rbCuenta.Location = new System.Drawing.Point(6, 18);
            this.rbCuenta.Name = "rbCuenta";
            this.rbCuenta.Size = new System.Drawing.Size(94, 17);
            this.rbCuenta.TabIndex = 0;
            this.rbCuenta.TabStop = true;
            this.rbCuenta.Text = "Nueva Cuenta";
            this.rbCuenta.UseVisualStyleBackColor = true;
            // 
            // cboVendedores
            // 
            this.cboVendedores.Location = new System.Drawing.Point(131, 121);
            this.cboVendedores.Name = "cboVendedores";
            this.cboVendedores.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboVendedores.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboVendedores.Size = new System.Drawing.Size(142, 20);
            this.cboVendedores.TabIndex = 0;
            this.cboVendedores.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
            // 
            // DateCierre
            // 
            this.DateCierre.EditValue = null;
            this.DateCierre.Location = new System.Drawing.Point(131, 147);
            this.DateCierre.Name = "DateCierre";
            this.DateCierre.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateCierre.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DateCierre.Size = new System.Drawing.Size(99, 20);
            this.DateCierre.TabIndex = 1;
            // 
            // MemoObservaciones
            // 
            this.MemoObservaciones.Location = new System.Drawing.Point(13, 221);
            this.MemoObservaciones.Name = "MemoObservaciones";
            this.MemoObservaciones.Size = new System.Drawing.Size(386, 111);
            this.MemoObservaciones.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl3.Location = new System.Drawing.Point(13, 202);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 13);
            this.labelControl3.TabIndex = 75;
            this.labelControl3.Text = "Observaciones:";
            // 
            // TxtShippingInstruction
            // 
            this.TxtShippingInstruction.Location = new System.Drawing.Point(131, 173);
            this.TxtShippingInstruction.Name = "TxtShippingInstruction";
            this.TxtShippingInstruction.Size = new System.Drawing.Size(186, 20);
            this.TxtShippingInstruction.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl2.Location = new System.Drawing.Point(13, 176);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(99, 13);
            this.labelControl2.TabIndex = 73;
            this.labelControl2.Text = "Shipping Instruction:";
            // 
            // sButtonSalir
            // 
            this.sButtonSalir.Image = ((System.Drawing.Image)(resources.GetObject("sButtonSalir.Image")));
            this.sButtonSalir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.sButtonSalir.Location = new System.Drawing.Point(329, 338);
            this.sButtonSalir.Name = "sButtonSalir";
            this.sButtonSalir.Size = new System.Drawing.Size(32, 29);
            this.sButtonSalir.TabIndex = 72;
            this.sButtonSalir.ToolTip = "Salir";
            this.sButtonSalir.Click += new System.EventHandler(this.sButtonSalir_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Options.UseTextOptions = true;
            this.labelControl5.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(13, 96);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(97, 17);
            this.labelControl5.TabIndex = 71;
            this.labelControl5.Text = "Vendedor Asignado:";
            // 
            // sButtonGrabarObs
            // 
            this.sButtonGrabarObs.Image = ((System.Drawing.Image)(resources.GetObject("sButtonGrabarObs.Image")));
            this.sButtonGrabarObs.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.sButtonGrabarObs.Location = new System.Drawing.Point(367, 338);
            this.sButtonGrabarObs.Name = "sButtonGrabarObs";
            this.sButtonGrabarObs.Size = new System.Drawing.Size(32, 29);
            this.sButtonGrabarObs.TabIndex = 68;
            this.sButtonGrabarObs.ToolTip = "Grabar";
            this.sButtonGrabarObs.Click += new System.EventHandler(this.sButtonGrabarObs_Click);
            // 
            // lblProspecto
            // 
            this.lblProspecto.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblProspecto.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.lblProspecto.Location = new System.Drawing.Point(131, 58);
            this.lblProspecto.Name = "lblProspecto";
            this.lblProspecto.Size = new System.Drawing.Size(266, 25);
            this.lblProspecto.TabIndex = 35;
            this.lblProspecto.Text = "labelControl2";
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl1.Location = new System.Drawing.Point(13, 64);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "Prospecto:";
            // 
            // labelControl6
            // 
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl6.Location = new System.Drawing.Point(13, 150);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(65, 13);
            this.labelControl6.TabIndex = 32;
            this.labelControl6.Text = "Fecha Cierre:";
            // 
            // frmCerrarTarget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 382);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCerrarTarget";
            this.Text = "Cerrar Target";
            this.Load += new System.EventHandler(this.frmCerrarTarget_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateCierre.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateCierre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemoObservaciones.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtShippingInstruction.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton sButtonSalir;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton sButtonGrabarObs;
        private DevExpress.XtraEditors.LabelControl lblProspecto;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit TxtShippingInstruction;
        private DevExpress.XtraEditors.ComboBoxEdit cboVendedores;
        private DevExpress.XtraEditors.DateEdit DateCierre;
        private DevExpress.XtraEditors.MemoEdit MemoObservaciones;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbTarget;
        private System.Windows.Forms.RadioButton rbCuenta;
        private DevExpress.XtraEditors.LabelControl lblVendedorAsignado;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}