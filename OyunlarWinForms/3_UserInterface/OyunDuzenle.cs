using OyunlarWinForms._2_Business.Enums;
using OyunlarWinForms._2_Business.Models;
using OyunlarWinForms._2_Business.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace OyunlarWinForms._3_UserInterface
{
    public partial class OyunDuzenle : Form
    {
        public int Id { get; set; }

        private TurService turService = new TurService();
        private OyunService oyunService = new OyunService();
        private YilService yilService = new YilService();
        private readonly Oyunlar _oyunlarForm;

        public OyunDuzenle(Oyunlar oyunlarForm)
        {
            InitializeComponent();

            _oyunlarForm = oyunlarForm;
            this.MdiParent = oyunlarForm.MdiParent;
            this.WindowState = FormWindowState.Maximized;
            //this.Show();
        }

        private void OyunDuzenle_Load(object sender, EventArgs e)
        {
            FillYillar();
            FillTurler();
            FillDetay();
        }

        private void FillTurler()
        {
            lbTurleri.Items.Clear();
            var turler = turService.GetList();
            if (turler == null)
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
                Id = -1,
                Degeri = "---Seçiniz---"
            });
            cbYili.ValueMember = "Id";
            cbYili.DisplayMember = "Degeri";
            cbYili.DataSource = yillar;
            cbYili.SelectedIndex = 0;
        }
        private void FillDetay()
        {
            var oyun = oyunService.GetByID(Id);
            if (oyun == null)
            {
                MessageBox.Show("İşlem sırasında hata meydana geldi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtAdi.Text = oyun.Adi;
            txtKazanci.Text = "";
            if (oyun.Kazanci != null)
                txtKazanci.Text = oyun.Kazanci.Value.ToString(new CultureInfo("tr"));

            txtMaliyeti.Text = "";
            if (oyun.Maliyeti != null)
                txtMaliyeti.Text = oyun.Maliyeti.Value.ToString(new CultureInfo("tr"));
            cbYili.SelectedValue = oyun.YilId;
            if (oyun.Turler != null && oyun.Turler.Count > 0)
            {
                for (int i = 0; i < lbTurleri.Items.Count; i++)
                {
                    var turItem = lbTurleri.Items[i] as TurModel;
                    for (int j = 0; j < oyun.Turler.Count; j++)
                    {
                        var tur = oyun.Turler[j];
                        if (turItem.Id == tur.Id)
                        {
                            lbTurleri.SetSelected(i, true);
                            break;
                        }
                    }
                }
            }            
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            var model = new OyunModel();
            model.Id = Id;
            model.Adi = txtAdi.Text;
            model.Kazanci = null;
            if (!string.IsNullOrWhiteSpace(txtKazanci.Text))
                model.Kazanci = Convert.ToDouble(txtKazanci.Text.Trim(), new CultureInfo("tr"));
            model.Maliyeti = null;
            if (!string.IsNullOrWhiteSpace(txtMaliyeti.Text))
                model.Maliyeti = Convert.ToDouble(txtMaliyeti.Text.Trim(), new CultureInfo("tr"));
            model.YilId = Convert.ToInt32(cbYili.SelectedValue);
            model.Turler = new List<TurModel>();
            foreach (var listItem in lbTurleri.SelectedItems)
            {
                var turItem = (TurModel)listItem;
                model.Turler.Add(turItem);
            }
            var islem = oyunService.Update(model);
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
