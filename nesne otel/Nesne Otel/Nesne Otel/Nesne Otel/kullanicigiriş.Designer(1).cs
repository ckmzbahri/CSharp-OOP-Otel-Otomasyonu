namespace Nesne_Otel
{
    partial class kullanicigiriş
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bgiris = new System.Windows.Forms.Button();
            this.kullanicisifre = new System.Windows.Forms.TextBox();
            this.kullaniciadi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(159, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Şifre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(110, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Kullanıcı Adı:";
            // 
            // bgiris
            // 
            this.bgiris.BackColor = System.Drawing.Color.LightGray;
            this.bgiris.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bgiris.Location = new System.Drawing.Point(209, 200);
            this.bgiris.Name = "bgiris";
            this.bgiris.Size = new System.Drawing.Size(116, 23);
            this.bgiris.TabIndex = 17;
            this.bgiris.Text = "GİRİŞ YAP";
            this.bgiris.UseVisualStyleBackColor = false;
            this.bgiris.Click += new System.EventHandler(this.bgiris_Click);
            // 
            // kullanicisifre
            // 
            this.kullanicisifre.Location = new System.Drawing.Point(209, 174);
            this.kullanicisifre.Name = "kullanicisifre";
            this.kullanicisifre.PasswordChar = '*';
            this.kullanicisifre.Size = new System.Drawing.Size(116, 20);
            this.kullanicisifre.TabIndex = 16;
            // 
            // kullaniciadi
            // 
            this.kullaniciadi.Location = new System.Drawing.Point(209, 148);
            this.kullaniciadi.Name = "kullaniciadi";
            this.kullaniciadi.Size = new System.Drawing.Size(116, 20);
            this.kullaniciadi.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MV Boli", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 34);
            this.label1.TabIndex = 14;
            this.label1.Text = "       HOŞGELDİNİZ";
            // 
            // kullanicigiriş
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Nesne_Otel.Properties.Resources.arkaplan;
            this.ClientSize = new System.Drawing.Size(530, 360);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bgiris);
            this.Controls.Add(this.kullanicisifre);
            this.Controls.Add(this.kullaniciadi);
            this.Controls.Add(this.label1);
            this.Name = "kullanicigiriş";
            this.Text = "kullanicigiriş";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bgiris;
        private System.Windows.Forms.TextBox kullanicisifre;
        private System.Windows.Forms.TextBox kullaniciadi;
        private System.Windows.Forms.Label label1;
    }
}