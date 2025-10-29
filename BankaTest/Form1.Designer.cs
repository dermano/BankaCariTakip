namespace BankaTest
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MskHesapno = new System.Windows.Forms.MaskedTextBox();
            this.TxtSifre = new System.Windows.Forms.TextBox();
            this.BtnGirisyap = new System.Windows.Forms.Button();
            this.LnkKayitol = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hesap No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Şifre:";
            // 
            // MskHesapno
            // 
            this.MskHesapno.Location = new System.Drawing.Point(148, 28);
            this.MskHesapno.Mask = "000000";
            this.MskHesapno.Name = "MskHesapno";
            this.MskHesapno.Size = new System.Drawing.Size(100, 26);
            this.MskHesapno.TabIndex = 1;
            this.MskHesapno.ValidatingType = typeof(int);
            // 
            // TxtSifre
            // 
            this.TxtSifre.Location = new System.Drawing.Point(148, 60);
            this.TxtSifre.Name = "TxtSifre";
            this.TxtSifre.PasswordChar = '*';
            this.TxtSifre.Size = new System.Drawing.Size(100, 26);
            this.TxtSifre.TabIndex = 2;
            // 
            // BtnGirisyap
            // 
            this.BtnGirisyap.Location = new System.Drawing.Point(148, 92);
            this.BtnGirisyap.Name = "BtnGirisyap";
            this.BtnGirisyap.Size = new System.Drawing.Size(100, 29);
            this.BtnGirisyap.TabIndex = 3;
            this.BtnGirisyap.Text = "GİRİŞ YAP";
            this.BtnGirisyap.UseVisualStyleBackColor = true;
            this.BtnGirisyap.Click += new System.EventHandler(this.BtnGirisyap_Click);
            // 
            // LnkKayitol
            // 
            this.LnkKayitol.AutoSize = true;
            this.LnkKayitol.Location = new System.Drawing.Point(254, 68);
            this.LnkKayitol.Name = "LnkKayitol";
            this.LnkKayitol.Size = new System.Drawing.Size(66, 18);
            this.LnkKayitol.TabIndex = 4;
            this.LnkKayitol.TabStop = true;
            this.LnkKayitol.Text = "Kayıt Ol";
            this.LnkKayitol.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkKayitol_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(169)))), ((int)(((byte)(166)))));
            this.ClientSize = new System.Drawing.Size(393, 165);
            this.Controls.Add(this.LnkKayitol);
            this.Controls.Add(this.BtnGirisyap);
            this.Controls.Add(this.TxtSifre);
            this.Controls.Add(this.MskHesapno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox MskHesapno;
        private System.Windows.Forms.TextBox TxtSifre;
        private System.Windows.Forms.Button BtnGirisyap;
        private System.Windows.Forms.LinkLabel LnkKayitol;
    }
}

