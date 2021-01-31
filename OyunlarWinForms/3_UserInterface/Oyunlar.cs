using OyunlarWinForms._2_Business.Enums;
using OyunlarWinForms._2_Business.Services;
using System;
using System.Windows.Forms;

namespace OyunlarWinForms._3_UserInterface
{
    public partial class Oyunlar : Form
    {
        private OyunService oyunService = new OyunService();

        //public Oyunlar()
        //{
        //    InitializeComponent();
        //}      

        private readonly OyunYoneticisi _oyunYoneticisiForm;

        public Oyunlar(OyunYoneticisi oyunYöneticisiForm)
        {
            InitializeComponent();
            _oyunYoneticisiForm = oyunYöneticisiForm;
            this.MdiParent = _oyunYoneticisiForm;
            WindowState = FormWindowState.Maximized;
            this.Show();
        }

        private void Oyunlar_Load(object sender, EventArgs e)
        {
            
        }

        private void Oyunlar_Shown(object sender, EventArgs e)
        {
            FillGrid();
        }

        public void FillGrid()
        {
            var oyunlar = oyunService.GetList();
            dgvOyunlar.DataSource = oyunlar;
            dgvOyunlar.ClearSelection();
            SetColumnVisibilities();
            //SetColumnNames();
            SetColumnWidths();
        }

        private void SetColumnWidths()
        {
            //dgvOyunlar.Columns["KarZarar"].Width = 150;
            foreach (DataGridViewColumn column in dgvOyunlar.Columns)
            {
                column.Width = 150;
            }
        }

        //private void SetColumnNames()
        //{
        //    dgvOyunlar.Columns["Adi"].HeaderText = "Oyun Adı";
        //    dgvOyunlar.Columns["Kazanci"].HeaderText = "Oyun Kazancı";
        //    dgvOyunlar.Columns["Maliyeti"].HeaderText = "Oyun Maliyeti";
        //    dgvOyunlar.Columns["YilId"].HeaderText = "Oyun Yılı";
        //    dgvOyunlar.Columns["KarZarar"].HeaderText = "Oyun Karı/Zararı";
        //}

        private void SetColumnVisibilities()
        {
            dgvOyunlar.Columns["Id"].Visible = false;
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OyunEkle form = new OyunEkle();
            //form.Show();

            this.Hide();
            OyunEkle form = new OyunEkle(this);
        }

        private void detayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvOyunlar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Listeden oyun seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvOyunlar.SelectedRows[0].Cells[0].Value); //selected id
            OyunDetayi ODForm = new OyunDetayi(this, id);
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvOyunlar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Listeden oyun seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvOyunlar.SelectedRows[0].Cells[0].Value); //selected id

            OyunDuzenle oyunDuzenleForm = new OyunDuzenle(this);
            oyunDuzenleForm.Id = id;
            oyunDuzenleForm.Show();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvOyunlar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Listeden oyun seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvOyunlar.SelectedRows[0].Cells[0].Value);

            var dialogResult = MessageBox.Show("Seçtiğiniz oyun kaydını silmek istiyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                var islem = oyunService.Delete(id);
                if (islem == Islem.Hata)
                    MessageBox.Show("İşlem sırasnda hata meydana geldi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    FillGrid();
            }
        }
    }
}
