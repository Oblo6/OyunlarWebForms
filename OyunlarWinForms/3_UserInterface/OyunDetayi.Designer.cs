
namespace OyunlarWinForms._3_UserInterface
{
    partial class OyunDetayi
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
            this.btnKapat = new System.Windows.Forms.Button();
            this.lbTurleri = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbYili = new System.Windows.Forms.ComboBox();
            this.txtMaliyeti = new System.Windows.Forms.TextBox();
            this.txtKazanci = new System.Windows.Forms.TextBox();
            this.txtAdi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblKazanci = new System.Windows.Forms.Label();
            this.lblAdi = new System.Windows.Forms.Label();
            this.lblMaliyeti = new System.Windows.Forms.Label();
            this.lblYili = new System.Windows.Forms.Label();
            this.lblTurleri = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnKapat
            // 
            this.btnKapat.Location = new System.Drawing.Point(101, 225);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(67, 23);
            this.btnKapat.TabIndex = 24;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = true;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // lbTurleri
            // 
            this.lbTurleri.Enabled = false;
            this.lbTurleri.FormattingEnabled = true;
            this.lbTurleri.Location = new System.Drawing.Point(101, 111);
            this.lbTurleri.Name = "lbTurleri";
            this.lbTurleri.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbTurleri.Size = new System.Drawing.Size(213, 108);
            this.lbTurleri.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Türleri :";
            // 
            // cbYili
            // 
            this.cbYili.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYili.Enabled = false;
            this.cbYili.FormattingEnabled = true;
            this.cbYili.Location = new System.Drawing.Point(100, 84);
            this.cbYili.Name = "cbYili";
            this.cbYili.Size = new System.Drawing.Size(121, 21);
            this.cbYili.TabIndex = 21;
            // 
            // txtMaliyeti
            // 
            this.txtMaliyeti.Location = new System.Drawing.Point(100, 58);
            this.txtMaliyeti.Name = "txtMaliyeti";
            this.txtMaliyeti.ReadOnly = true;
            this.txtMaliyeti.Size = new System.Drawing.Size(214, 20);
            this.txtMaliyeti.TabIndex = 20;
            // 
            // txtKazanci
            // 
            this.txtKazanci.Location = new System.Drawing.Point(100, 32);
            this.txtKazanci.Name = "txtKazanci";
            this.txtKazanci.ReadOnly = true;
            this.txtKazanci.Size = new System.Drawing.Size(214, 20);
            this.txtKazanci.TabIndex = 19;
            // 
            // txtAdi
            // 
            this.txtAdi.Location = new System.Drawing.Point(100, 6);
            this.txtAdi.Name = "txtAdi";
            this.txtAdi.ReadOnly = true;
            this.txtAdi.Size = new System.Drawing.Size(214, 20);
            this.txtAdi.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Yılı( * ) :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Maliyeti :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Kazancı :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Adı( * ) :";
            // 
            // lblKazanci
            // 
            this.lblKazanci.AutoSize = true;
            this.lblKazanci.Location = new System.Drawing.Point(337, 35);
            this.lblKazanci.Name = "lblKazanci";
            this.lblKazanci.Size = new System.Drawing.Size(55, 13);
            this.lblKazanci.TabIndex = 27;
            this.lblKazanci.Text = "lblKazanci";
            // 
            // lblAdi
            // 
            this.lblAdi.AutoSize = true;
            this.lblAdi.Location = new System.Drawing.Point(337, 9);
            this.lblAdi.Name = "lblAdi";
            this.lblAdi.Size = new System.Drawing.Size(32, 13);
            this.lblAdi.TabIndex = 28;
            this.lblAdi.Text = "lblAdi";
            // 
            // lblMaliyeti
            // 
            this.lblMaliyeti.AutoSize = true;
            this.lblMaliyeti.Location = new System.Drawing.Point(337, 61);
            this.lblMaliyeti.Name = "lblMaliyeti";
            this.lblMaliyeti.Size = new System.Drawing.Size(52, 13);
            this.lblMaliyeti.TabIndex = 29;
            this.lblMaliyeti.Text = "lblMaliyeti";
            // 
            // lblYili
            // 
            this.lblYili.AutoSize = true;
            this.lblYili.Location = new System.Drawing.Point(337, 87);
            this.lblYili.Name = "lblYili";
            this.lblYili.Size = new System.Drawing.Size(30, 13);
            this.lblYili.TabIndex = 30;
            this.lblYili.Text = "lblYili";
            // 
            // lblTurleri
            // 
            this.lblTurleri.AutoSize = true;
            this.lblTurleri.Location = new System.Drawing.Point(337, 111);
            this.lblTurleri.Name = "lblTurleri";
            this.lblTurleri.Size = new System.Drawing.Size(46, 13);
            this.lblTurleri.TabIndex = 31;
            this.lblTurleri.Text = "lblTurleri";
            // 
            // OyunDetayi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTurleri);
            this.Controls.Add(this.lblYili);
            this.Controls.Add(this.lblMaliyeti);
            this.Controls.Add(this.lblAdi);
            this.Controls.Add(this.lblKazanci);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.lbTurleri);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbYili);
            this.Controls.Add(this.txtMaliyeti);
            this.Controls.Add(this.txtKazanci);
            this.Controls.Add(this.txtAdi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "OyunDetayi";
            this.Text = "Oyun Detayı";
            this.Load += new System.EventHandler(this.OyunDetayi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.ListBox lbTurleri;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbYili;
        private System.Windows.Forms.TextBox txtMaliyeti;
        private System.Windows.Forms.TextBox txtKazanci;
        private System.Windows.Forms.TextBox txtAdi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblKazanci;
        private System.Windows.Forms.Label lblAdi;
        private System.Windows.Forms.Label lblMaliyeti;
        private System.Windows.Forms.Label lblYili;
        private System.Windows.Forms.Label lblTurleri;
    }
}