namespace ResimEditor
{
    partial class Form3
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
            this.normalResim = new System.Windows.Forms.PictureBox();
            this.kırpılmısResim = new System.Windows.Forms.PictureBox();
            this.btnDosyadan = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.normalResim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kırpılmısResim)).BeginInit();
            this.SuspendLayout();
            // 
            // normalResim
            // 
            this.normalResim.Location = new System.Drawing.Point(1, 45);
            this.normalResim.Name = "normalResim";
            this.normalResim.Size = new System.Drawing.Size(391, 361);
            this.normalResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.normalResim.TabIndex = 0;
            this.normalResim.TabStop = false;
            this.normalResim.Click += new System.EventHandler(this.normalResim_Click);
            this.normalResim.Paint += new System.Windows.Forms.PaintEventHandler(this.normalResim_Paint);
            this.normalResim.MouseDown += new System.Windows.Forms.MouseEventHandler(this.normalResim_MouseDown);
            this.normalResim.MouseMove += new System.Windows.Forms.MouseEventHandler(this.normalResim_MouseMove);
            this.normalResim.MouseUp += new System.Windows.Forms.MouseEventHandler(this.normalResim_MouseUp);
            // 
            // kırpılmısResim
            // 
            this.kırpılmısResim.Location = new System.Drawing.Point(408, 45);
            this.kırpılmısResim.Name = "kırpılmısResim";
            this.kırpılmısResim.Size = new System.Drawing.Size(391, 254);
            this.kırpılmısResim.TabIndex = 1;
            this.kırpılmısResim.TabStop = false;
            this.kırpılmısResim.Click += new System.EventHandler(this.kırpılmısResim_Click);
            // 
            // btnDosyadan
            // 
            this.btnDosyadan.BackColor = System.Drawing.SystemColors.Window;
            this.btnDosyadan.Location = new System.Drawing.Point(72, 16);
            this.btnDosyadan.Name = "btnDosyadan";
            this.btnDosyadan.Size = new System.Drawing.Size(264, 23);
            this.btnDosyadan.TabIndex = 2;
            this.btnDosyadan.Text = "Dosyadan Seç";
            this.btnDosyadan.UseVisualStyleBackColor = false;
            this.btnDosyadan.Click += new System.EventHandler(this.btnDosyadan_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.SystemColors.Window;
            this.btnKaydet.Location = new System.Drawing.Point(505, 328);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(182, 62);
            this.btnKaydet.TabIndex = 3;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnDosyadan);
            this.Controls.Add(this.kırpılmısResim);
            this.Controls.Add(this.normalResim);
            this.Name = "Form3";
            this.Text = "          Kırpma";
            ((System.ComponentModel.ISupportInitialize)(this.normalResim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kırpılmısResim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox normalResim;
        private System.Windows.Forms.PictureBox kırpılmısResim;
        private System.Windows.Forms.Button btnDosyadan;
        private System.Windows.Forms.Button btnKaydet;
    }
}