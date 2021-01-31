
namespace OyunlarWinForms._3_UserInterface
{
    partial class OyunRaporu
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
            this.dgvOyunlarRap = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdi = new System.Windows.Forms.TextBox();
            this.btnSorgula = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbYili = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaliyetBas = new System.Windows.Forms.TextBox();
            this.txtMaliyetSon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKazSon = new System.Windows.Forms.TextBox();
            this.txtKazBas = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbTurleri = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbSayfa = new System.Windows.Forms.ComboBox();
            this.cbSiralamaDeger = new System.Windows.Forms.ComboBox();
            this.cbSiralamaSutun = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnTemizle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOyunlarRap)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOyunlarRap
            // 
            this.dgvOyunlarRap.AllowUserToAddRows = false;
            this.dgvOyunlarRap.AllowUserToDeleteRows = false;
            this.dgvOyunlarRap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvOyunlarRap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOyunlarRap.Location = new System.Drawing.Point(12, 183);
            this.dgvOyunlarRap.MultiSelect = false;
            this.dgvOyunlarRap.Name = "dgvOyunlarRap";
            this.dgvOyunlarRap.ReadOnly = true;
            this.dgvOyunlarRap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOyunlarRap.Size = new System.Drawing.Size(776, 150);
            this.dgvOyunlarRap.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Adı :";
            // 
            // txtAdi
            // 
            this.txtAdi.Location = new System.Drawing.Point(106, 24);
            this.txtAdi.Name = "txtAdi";
            this.txtAdi.Size = new System.Drawing.Size(258, 20);
            this.txtAdi.TabIndex = 2;
            // 
            // btnSorgula
            // 
            this.btnSorgula.Location = new System.Drawing.Point(106, 154);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.Size = new System.Drawing.Size(83, 23);
            this.btnSorgula.TabIndex = 3;
            this.btnSorgula.Text = "Sorgula";
            this.btnSorgula.UseVisualStyleBackColor = true;
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(410, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Yılı :";
            // 
            // cbYili
            // 
            this.cbYili.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYili.FormattingEnabled = true;
            this.cbYili.Location = new System.Drawing.Point(476, 24);
            this.cbYili.Name = "cbYili";
            this.cbYili.Size = new System.Drawing.Size(258, 21);
            this.cbYili.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Maliyeti :";
            // 
            // txtMaliyetBas
            // 
            this.txtMaliyetBas.Location = new System.Drawing.Point(106, 53);
            this.txtMaliyetBas.Name = "txtMaliyetBas";
            this.txtMaliyetBas.Size = new System.Drawing.Size(118, 20);
            this.txtMaliyetBas.TabIndex = 7;
            // 
            // txtMaliyetSon
            // 
            this.txtMaliyetSon.Location = new System.Drawing.Point(246, 53);
            this.txtMaliyetSon.Name = "txtMaliyetSon";
            this.txtMaliyetSon.Size = new System.Drawing.Size(118, 20);
            this.txtMaliyetSon.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(600, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "-";
            // 
            // txtKazSon
            // 
            this.txtKazSon.Location = new System.Drawing.Point(616, 53);
            this.txtKazSon.Name = "txtKazSon";
            this.txtKazSon.Size = new System.Drawing.Size(118, 20);
            this.txtKazSon.TabIndex = 12;
            // 
            // txtKazBas
            // 
            this.txtKazBas.Location = new System.Drawing.Point(476, 53);
            this.txtKazBas.Name = "txtKazBas";
            this.txtKazBas.Size = new System.Drawing.Size(118, 20);
            this.txtKazBas.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(410, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Kazancı :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Türleri :";
            // 
            // lbTurleri
            // 
            this.lbTurleri.FormattingEnabled = true;
            this.lbTurleri.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbTurleri.Location = new System.Drawing.Point(106, 79);
            this.lbTurleri.Name = "lbTurleri";
            this.lbTurleri.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbTurleri.Size = new System.Drawing.Size(258, 69);
            this.lbTurleri.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(627, 342);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Sayfa";
            // 
            // cbSayfa
            // 
            this.cbSayfa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSayfa.FormattingEnabled = true;
            this.cbSayfa.Location = new System.Drawing.Point(667, 339);
            this.cbSayfa.Name = "cbSayfa";
            this.cbSayfa.Size = new System.Drawing.Size(121, 21);
            this.cbSayfa.TabIndex = 17;
            this.cbSayfa.SelectedIndexChanged += new System.EventHandler(this.cbSayfa_SelectedIndexChanged);
            // 
            // cbSiralamaDeger
            // 
            this.cbSiralamaDeger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSiralamaDeger.FormattingEnabled = true;
            this.cbSiralamaDeger.Location = new System.Drawing.Point(484, 339);
            this.cbSiralamaDeger.Name = "cbSiralamaDeger";
            this.cbSiralamaDeger.Size = new System.Drawing.Size(121, 21);
            this.cbSiralamaDeger.TabIndex = 18;
            this.cbSiralamaDeger.SelectedIndexChanged += new System.EventHandler(this.cbSiralamaDeger_SelectedIndexChanged);
            // 
            // cbSiralamaSutun
            // 
            this.cbSiralamaSutun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSiralamaSutun.FormattingEnabled = true;
            this.cbSiralamaSutun.Location = new System.Drawing.Point(357, 339);
            this.cbSiralamaSutun.Name = "cbSiralamaSutun";
            this.cbSiralamaSutun.Size = new System.Drawing.Size(121, 21);
            this.cbSiralamaSutun.TabIndex = 19;
            this.cbSiralamaSutun.SelectedIndexChanged += new System.EventHandler(this.cbSiralamaSutun_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(304, 342);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Sıralama";
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(195, 154);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(83, 23);
            this.btnTemizle.TabIndex = 21;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // OyunRaporu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbSiralamaSutun);
            this.Controls.Add(this.cbSiralamaDeger);
            this.Controls.Add(this.cbSayfa);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbTurleri);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtKazSon);
            this.Controls.Add(this.txtKazBas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMaliyetSon);
            this.Controls.Add(this.txtMaliyetBas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbYili);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSorgula);
            this.Controls.Add(this.txtAdi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvOyunlarRap);
            this.Name = "OyunRaporu";
            this.Text = "Oyun Raporu";
            this.Load += new System.EventHandler(this.OyunRaporu_Load);
            this.Shown += new System.EventHandler(this.OyunRaporu_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOyunlarRap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOyunlarRap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAdi;
        private System.Windows.Forms.Button btnSorgula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbYili;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaliyetBas;
        private System.Windows.Forms.TextBox txtMaliyetSon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKazSon;
        private System.Windows.Forms.TextBox txtKazBas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lbTurleri;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbSayfa;
        private System.Windows.Forms.ComboBox cbSiralamaDeger;
        private System.Windows.Forms.ComboBox cbSiralamaSutun;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnTemizle;
    }
}