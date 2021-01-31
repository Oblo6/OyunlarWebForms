using OyunlarWinForms._2_Business.Enums;
using OyunlarWinForms._2_Business.Models;
using OyunlarWinForms._2_Business.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OyunlarWinForms._3_UserInterface
{
    public partial class OyunEkle : Form
    {
        private readonly YilService yilService = new YilService();
        private readonly TurService turService = new TurService();
        private readonly OyunService oyunService = new OyunService();

        //public OyunEkle()
        //{
        //    InitializeComponent();
        //}
        private readonly Oyunlar _oyunlarForm;
        public OyunEkle(Oyunlar oyunlarForm)
        {
            InitializeComponent();
            _oyunlarForm = oyunlarForm;
            this.MdiParent = _oyunlarForm.MdiParent;
            this.WindowState = FormWindowState.Maximized;
            this.Show();            
        }

        private void OyunEkle_Load(object sender, EventArgs e)
        {
            FillYillar();
            FillTurler();
        }

        private void FillTurler()
        {
            lbTurleri.Items.Clear();
            var turler = turService.GetList();
            if (turler ==null)
            {
                MessageBox.Show("İşlem sırasında hata meydana geldi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lbTurleri.ValueMember = "Id";
            lbTurleri.DisplayMember = "Adi";
            lbTurleri.DataSource = turler;
            lbTurleri.ClearSelected();
        }

        private void FillYillar()
        {
            cbYili.Items.Clear();
            var yillar = yilService.GetList();
            yillar.Insert(0, new YilModel()
            {
                Id = - 1,
                Degeri = "---Seçiniz---" 
            });
            cbYili.ValueMember = "Id";
            cbYili.DisplayMember = "Degeri";
            cbYili.DataSource = yillar;
            cbYili.SelectedIndex = 0;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            var model = new OyunModel();
            model.Adi = txtAdi.Text;
            model.Kazanci = null;
            if (!string.IsNullOrWhiteSpace(txtKazanci.Text))
            {
                model.Kazanci = Convert.ToDouble(txtKazanci.Text, new CultureInfo("tr"));
            }
            model.Maliyeti = null;
            if (!string.IsNullOrWhiteSpace(txtMaliyeti.Text))
            {
                model.Maliyeti = Convert.ToDouble(txtMaliyeti.Text, new CultureInfo("tr"));
            }
            model.YilId = Convert.ToInt32(cbYili.SelectedValue);
            model.Turler = new List<TurModel>();
            TurModel tur;
            foreach (var selectedItem in lbTurleri.SelectedItems)
            {
                //tur = (TurModel)selectedItem;
                tur = selectedItem as TurModel;
                model.Turler.Add(tur);
            }
            Islem islem = oyunService.Add(model);           
            switch (islem)
            {
                case Islem.Hata:
                    MessageBox.Show("İşlem sırasında hata meydana geldi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;               
                case Islem.BasarisizBosDeger:
                    MessageBox.Show("Formdaki ( * ) ile işaretlenmiş alanlar dolu olmalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case Islem.BasarisizKayitVar:
                    MessageBox.Show("Girdiğiniz ada sahip oyun kaydı bulunmaktadır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case Islem.Basarili:
                    this.Close();
                    _oyunlarForm.FillGrid();
                    break;
                default:
                    break;
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtAdi.Clear();
            txtMaliyeti.Text = "";
            txtKazanci.Text = "";
            cbYili.SelectedIndex = 0;
            lbTurleri.ClearSelected();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
