using OyunlarWinForms._2_Business.Models;
using OyunlarWinForms._2_Business.Services;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace OyunlarWinForms._3_UserInterface
{
    public partial class OyunDetayi : Form
    {
        private readonly Oyunlar _oyunlarForm;
        private readonly int _id;
        private OyunService oyunService = new OyunService();
        private TurService turService = new TurService();
        private YilService yilService = new YilService();

        public OyunDetayi(Oyunlar oyunlarForm, int id)
        {            
            InitializeComponent();

            _id = id;

            _oyunlarForm = oyunlarForm;
            this.MdiParent = oyunlarForm.MdiParent;
            this.WindowState = FormWindowState.Maximized;
            this.Show();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OyunDetayi_Load(object sender, EventArgs e)
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
            var oyun = oyunService.GetByID(_id);
            if (oyun ==null)
            {
                MessageBox.Show("İşlem sırasında hata meydana geldi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtAdi.Text = oyun.Adi;
            txtKazanci.Text = "";
            if (oyun.Kazanci.HasValue)
            {
                txtKazanci.Text = oyun.Kazanci.Value.ToString(new CultureInfo("tr"));
            }
            txtMaliyeti.Text = "";
            if (oyun.Maliyeti.HasValue)
            {
                txtMaliyeti.Text = oyun.Maliyeti.Value.ToString(new CultureInfo("tr"));
            }
            cbYili.SelectedValue = oyun.YilId;

            if (oyun.Turler != null && oyun.Turler.Count > 0)
            {
                for (int i = 0; i < lbTurleri.Items.Count; i++)
                {
                    var listItem = lbTurleri.Items[1];
                    var turItem = listItem as TurModel;
                    foreach (var tur in oyun.Turler)
                    {
                        if (turItem.Id == tur.Id)
                        {
                            lbTurleri.SetSelected(lbTurleri.Items.IndexOf(turItem), true);
                            break;
                        }
                    }
                }                
            }

            lblAdi.Text = oyun.Adi;
            lblKazanci.Text = "";
            if (oyun.Kazanci.HasValue)
            {
                lblKazanci.Text = oyun.Kazanci.Value.ToString(new CultureInfo("tr"));
            }
            txtMaliyeti.Text = "";
            if (oyun.Maliyeti.HasValue)
            {
                lblMaliyeti.Text = oyun.Maliyeti.Value.ToString(new CultureInfo("tr"));
            }
            lblYili.Text = oyun.YilId.ToString();
            lblTurleri.Text = "";
            if (oyun.Turler != null && oyun.Turler.Count > 0)
            {
                foreach (var tur in oyun.Turler)
                {
                    lblTurleri.Text += tur.Adi + ", ";
                }
                lblTurleri.Text = lblTurleri.Text.Trim(',', ' ');
            }
        }
    }
}
