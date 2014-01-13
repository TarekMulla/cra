namespace ProyectoCraft.WinForm.Direccion.Metas
{
    partial class frmUsuarioProspecto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarioProspecto));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sButtonSalir = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lblFechaAsignacion = new DevExpress.XtraEditors.LabelControl();
            this.lblVendedorA = new DevExpress.XtraEditors.LabelControl();
            this.sButtonGrabarObs = new DevExpress.XtraEditors.SimpleButton();
            this.lblProspecto = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboVendedores = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedores.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sButtonSalir);
            this.groupBox1.Controls.Add(this.labelControl5);
            this.groupBox1.Controls.Add(this.lblFechaAsignacion);
            this.groupBox1.Controls.Add(this.lblVendedorA);
            this.groupBox1.Controls.Add(this.sButtonGrabarObs);
            this.groupBox1.Controls.Add(this.lblProspecto);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Controls.Add(this.cboVendedores);
            this.groupBox1.Controls.Add(this.labelControl7);
            this.groupBox1.Controls.Add(this.labelControl6);
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 156);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // sButtonSalir
            // 
            this.sButtonSalir.Image = ((System.Drawing.Image)(resources.GetObject("sButtonSalir.Image")));
            this.sButtonSalir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.sButtonSalir.Location = new System.Drawing.Point(320, 121);
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
            this.labelControl5.Location = new System.Drawing.Point(11, 56);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(93, 17);
            this.labelControl5.TabIndex = 71;
            this.labelControl5.Text = "Vendedor actual:";
            // 
            // lblFechaAsignacion
            // 
            this.lblFechaAsignacion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblFechaAsignacion.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.lblFechaAsignacion.Location = new System.Drawing.Point(110, 77);
            this.lblFechaAsignacion.Name = "lblFechaAsignacion";
            this.lblFechaAsignacion.Size = new System.Drawing.Size(115, 25);
            this.lblFechaAsignacion.TabIndex = 70;
            this.lblFechaAsignacion.Text = "labelControl4";
            // 
            // lblVendedorA
            // 
            this.lblVendedorA.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblVendedorA.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.lblVendedorA.Location = new System.Drawing.Point(110, 48);
            this.lblVendedorA.Name = "lblVendedorA";
            this.lblVendedorA.Size = new System.Drawing.Size(115, 25);
            this.lblVendedorA.TabIndex = 69;
            this.lblVendedorA.Text = "labelControl3";
            // 
            // sButtonGrabarObs
            // 
            this.sButtonGrabarObs.Image = ((System.Drawing.Image)(resources.GetObject("sButtonGrabarObs.Image")));
            this.sButtonGrabarObs.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.sButtonGrabarObs.Location = new System.Drawing.Point(358, 121);
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
            this.lblProspecto.Location = new System.Drawing.Point(110, 19);
            this.lblProspecto.Name = "lblProspecto";
            this.lblProspecto.Size = new System.Drawing.Size(266, 25);
            this.lblProspecto.TabIndex = 35;
            this.lblProspecto.Text = "labelControl2";
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl1.Location = new System.Drawing.Point(11, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "Prospecto:";
            // 
            // cboVendedores
            // 
            this.cboVendedores.Location = new System.Drawing.Point(110, 108);
            this.cboVendedores.Name = "cboVendedores";
            this.cboVendedores.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboVendedores.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboVendedores.Size = new System.Drawing.Size(201, 20);
            this.cboVendedores.TabIndex = 31;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Options.UseTextOptions = true;
            this.labelControl7.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.Location = new System.Drawing.Point(11, 111);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(104, 17);
            this.labelControl7.TabIndex = 33;
            this.labelControl7.Text = "Vendedor asignado:";
            // 
            // labelControl6
            // 
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl6.Location = new System.Drawing.Point(11, 83);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(33, 13);
            this.labelControl6.TabIndex = 32;
            this.labelControl6.Text = "Fecha:";
            // 
            // frmUsuarioProspecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 162);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUsuarioProspecto";
            this.Text = "Re-Asignar Vendedor";
            this.Load += new System.EventHandler(this.frmUsuarioProspecto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedores.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.ComboBoxEdit cboVendedores;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lblProspecto;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton sButtonGrabarObs;
        private DevExpress.XtraEditors.LabelControl lblFechaAsignacion;
        private DevExpress.XtraEditors.LabelControl lblVendedorA;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton sButtonSalir;
    }
}