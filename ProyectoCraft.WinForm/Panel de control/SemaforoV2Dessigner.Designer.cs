namespace SCCMultimodal.Panel_de_control {
    partial class SemaforoV2Dessigner {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SemaforoV2Dessigner));
            this.TitleLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rojo = new System.Windows.Forms.PictureBox();
            this.naranjo = new System.Windows.Forms.PictureBox();
            this.verde = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rojo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.naranjo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verde)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.TitleLbl.Location = new System.Drawing.Point(56, 16);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(42, 12);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "TitleLbl";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(45, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 213);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // rojo
            // 
            this.rojo.Image = ((System.Drawing.Image)(resources.GetObject("rojo.Image")));
            this.rojo.Location = new System.Drawing.Point(66, 44);
            this.rojo.Name = "rojo";
            this.rojo.Size = new System.Drawing.Size(64, 59);
            this.rojo.TabIndex = 2;
            this.rojo.TabStop = false;
            this.rojo.Visible = false;
            // 
            // naranjo
            // 
            this.naranjo.Image = ((System.Drawing.Image)(resources.GetObject("naranjo.Image")));
            this.naranjo.Location = new System.Drawing.Point(64, 109);
            this.naranjo.Name = "naranjo";
            this.naranjo.Size = new System.Drawing.Size(64, 59);
            this.naranjo.TabIndex = 3;
            this.naranjo.TabStop = false;
            this.naranjo.Visible = false;
            // 
            // verde
            // 
            this.verde.Image = ((System.Drawing.Image)(resources.GetObject("verde.Image")));
            this.verde.Location = new System.Drawing.Point(66, 170);
            this.verde.Name = "verde";
            this.verde.Size = new System.Drawing.Size(64, 59);
            this.verde.TabIndex = 4;
            this.verde.TabStop = false;
            this.verde.Visible = false;
            // 
            // SemaforoV2Dessigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.verde);
            this.Controls.Add(this.naranjo);
            this.Controls.Add(this.rojo);
            this.Controls.Add(this.TitleLbl);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SemaforoV2Dessigner";
            this.Size = new System.Drawing.Size(164, 258);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rojo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.naranjo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verde)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox rojo;
        private System.Windows.Forms.PictureBox naranjo;
        private System.Windows.Forms.PictureBox verde;
    }
}
