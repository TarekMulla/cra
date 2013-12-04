namespace ProyectoCraft.WinForm.Ventas.Metas
{
    partial class frmCerrarSLead
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCerrarSLead));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAgente = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.lblSLead = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.DateCierre = new DevExpress.XtraEditors.DateEdit();
            this.MemoObservaciones = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.sButtonSalir = new DevExpress.XtraEditors.SimpleButton();
            this.sButtonGrabarObs = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DateCierre.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateCierre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemoObservaciones.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAgente);
            this.groupBox1.Controls.Add(this.labelControl7);
            this.groupBox1.Controls.Add(this.lblSLead);
            this.groupBox1.Controls.Add(this.labelControl8);
            this.groupBox1.Controls.Add(this.DateCierre);
            this.groupBox1.Controls.Add(this.MemoObservaciones);
            this.groupBox1.Controls.Add(this.labelControl3);
            this.groupBox1.Controls.Add(this.sButtonSalir);
            this.groupBox1.Controls.Add(this.sButtonGrabarObs);
            this.groupBox1.Controls.Add(this.labelControl6);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 286);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblAgente
            // 
            this.lblAgente.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAgente.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.lblAgente.Location = new System.Drawing.Point(131, 45);
            this.lblAgente.Name = "lblAgente";
            this.lblAgente.Size = new System.Drawing.Size(266, 25);
            this.lblAgente.TabIndex = 85;
            this.lblAgente.Text = "labelControl2";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Options.UseTextOptions = true;
            this.labelControl7.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.Location = new System.Drawing.Point(15, 51);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(97, 17);
            this.labelControl7.TabIndex = 84;
            this.labelControl7.Text = "Agente:";
            // 
            // lblSLead
            // 
            this.lblSLead.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSLead.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.lblSLead.Location = new System.Drawing.Point(131, 14);
            this.lblSLead.Name = "lblSLead";
            this.lblSLead.Size = new System.Drawing.Size(266, 25);
            this.lblSLead.TabIndex = 83;
            this.lblSLead.Text = "labelControl2";
            // 
            // labelControl8
            // 
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl8.Location = new System.Drawing.Point(15, 20);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(55, 13);
            this.labelControl8.TabIndex = 82;
            this.labelControl8.Text = "Sales Lead:";
            // 
            // DateCierre
            // 
            this.DateCierre.EditValue = null;
            this.DateCierre.Location = new System.Drawing.Point(131, 76);
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
            this.MemoObservaciones.Location = new System.Drawing.Point(14, 131);
            this.MemoObservaciones.Name = "MemoObservaciones";
            this.MemoObservaciones.Size = new System.Drawing.Size(386, 111);
            this.MemoObservaciones.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl3.Location = new System.Drawing.Point(15, 112);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 13);
            this.labelControl3.TabIndex = 75;
            this.labelControl3.Text = "Observaciones:";
            // 
            // sButtonSalir
            // 
            this.sButtonSalir.Image = ((System.Drawing.Image)(resources.GetObject("sButtonSalir.Image")));
            this.sButtonSalir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.sButtonSalir.Location = new System.Drawing.Point(324, 248);
            this.sButtonSalir.Name = "sButtonSalir";
            this.sButtonSalir.Size = new System.Drawing.Size(32, 29);
            this.sButtonSalir.TabIndex = 72;
            this.sButtonSalir.ToolTip = "Salir";
            this.sButtonSalir.Click += new System.EventHandler(this.sButtonSalir_Click);
            // 
            // sButtonGrabarObs
            // 
            this.sButtonGrabarObs.Image = ((System.Drawing.Image)(resources.GetObject("sButtonGrabarObs.Image")));
            this.sButtonGrabarObs.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.sButtonGrabarObs.Location = new System.Drawing.Point(362, 248);
            this.sButtonGrabarObs.Name = "sButtonGrabarObs";
            this.sButtonGrabarObs.Size = new System.Drawing.Size(32, 29);
            this.sButtonGrabarObs.TabIndex = 68;
            this.sButtonGrabarObs.ToolTip = "Grabar";
            this.sButtonGrabarObs.Click += new System.EventHandler(this.sButtonGrabarObs_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl6.Location = new System.Drawing.Point(15, 79);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(65, 13);
            this.labelControl6.TabIndex = 32;
            this.labelControl6.Text = "Fecha Cierre:";
            // 
            // frmCerrarSLead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 291);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCerrarSLead";
            this.Text = "Cerrar Sales Lead";
            this.Load += new System.EventHandler(this.frmCerrarSLead_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCerrarSLead_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DateCierre.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateCierre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemoObservaciones.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.DateEdit DateCierre;
        private DevExpress.XtraEditors.MemoEdit MemoObservaciones;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton sButtonSalir;
        private DevExpress.XtraEditors.SimpleButton sButtonGrabarObs;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lblAgente;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl lblSLead;
        private DevExpress.XtraEditors.LabelControl labelControl8;
    }
}