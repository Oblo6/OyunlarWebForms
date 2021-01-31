using OyunlarWinForms._2_Business.Models;
using OyunlarWinForms._2_Business.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OyunlarWinForms._3_UserInterface
{
    public partial class OyunRaporu : Form
    {
        private readonly OyunYoneticisi _oyunYoneticisiForm;

        private OyunService oyunService = new OyunService();
        private TurService turService = new TurService();
        private YilService yilService = new YilService();

        private bool formIlkYukleme = true;

        public OyunRaporu(OyunYoneticisi oyunYoneticisiForm)
        {
            InitializeComponent();

            _oyunYoneticisiForm = oyunYoneticisiForm;
            this.MdiParent = oyunYoneticisiForm;
            this.WindowState = FormWindowState.Maximized;
            this.Show();
        }

        private void OyunRaporu_Load(object sender, EventArgs e)
        {
            FillSiralama();
            FillYillar();
            FillTurler();
            FillGrid();
            setColumnVisibilities();
            formIlkYukleme = false;
        }

        private void FillSiralama()
        {
            cbSiralamaSutun.Items.Clear();
            cbSiralamaSutun.Items.Add("Oyun Adı");
            cbSiralamaSutun.Items.Add("Oyun Maliyeti");
            cbSiralamaSutun.Items.Add("Oyun Kazancı");
            cbSiralamaSutun.Items.Add("Oyun Türü");
            cbSiralamaSutun.Items.Add("Oyun Yılı");
            cbSiralamaSutun.Text = "Oyun Adı";
            cbSiralamaDeger.Items.Clear();
            cbSiralamaDeger.Items.Add("Artan");
            cbSiralamaDeger.Items.Add("Azalan");
            cbSiralamaDeger.Text = "Artan";
        }

        private void FillTurler()
        {
            var turler = turService.GetList();
            if (turler == null)
            {
                MessageBox.Show("İşlem sırasında hata meydana geldi!");
                return;
            }
            lbTurleri.ValueMember = "Id";
            lbTurleri.DisplayMember = "Adi";
            lbTurleri.DataSource = turler;
            lbTurleri.ClearSelected();
        }

        private void FillYillar()
        {
            var yillar = yilService.GetList();
            if (yillar == null)
            {
                MessageBox.Show("İşlem sırasında hata meydana geldi!");
                return;
            }
            yillar.Insert(0, new YilModel()
            {
                Id = -1,
                Degeri = " - - Tümü - -"
            });
            cbYili.ValueMember = "Id";
            cbYili.DisplayMember = "Degeri";
            cbYili.DataSource = yillar;
            cbYili.SelectedIndex = 0;
        }

        private void setColumnVisibilities()
        {
            dgvOyunlarRap.Columns["Id"].Visible = false;
            dgvOyunlarRap.Columns["TurId"].Visible = false;

        }

        private void FillGrid(bool sayfalariDoldur = true)
        {
            //var query = oyunService.GetQuery();
            var query = oyunService.GetQueryFromView();

            #region Sıralama
            //query = query.OrderBy(o => o.Adi).ThenBy(o => o.Kazanci).ThenByDescending(o => o.TurAdi);
            if (cbSiralamaSutun.Text == "Oyun Adı")
            {
                if (cbSiralamaDeger.Text == "Artan")
                {
                    query = query.OrderBy(o => o.Adi);
                }
                else
                {
                    query = query.OrderByDescending(o => o.Adi);
                }
            }

            else if (cbSiralamaSutun.Text == "Oyun Maliyeti")
            {
                if (cbSiralamaDeger.Text == "Artan")
                {
                    query = query.OrderBy(o => o.Maliyeti);
                }
                else
                {
                    query = query.OrderByDescending(o => o.Maliyeti);
                }
            }

            else if (cbSiralamaSutun.Text == "Oyun Kazancı")
            {
                if (cbSiralamaDeger.Text == "Artan")
                {
                    query = query.OrderBy(o => o.Kazanci);
                }
                else
                {
                    query = query.OrderByDescending(o => o.Kazanci);
                }
            }

            else if (cbSiralamaSutun.Text == "Oyun Türü")
            {
                if (cbSiralamaDeger.Text == "Artan")
                {
                    query = query.OrderBy(o => o.TurAdi);
                }
                else
                {
                    query = query.OrderByDescending(o => o.TurAdi);
                }
            }

            else if (cbSiralamaSutun.Text == "Oyun Yılı")
            {
                if (cbSiralamaDeger.Text == "Artan")
                {
                    query = query.OrderBy(o => o.YilId);
                }
                else
                {
                    query = query.OrderByDescending(o => o.YilId);
                }
            }

            #endregion

            #region Filtreleme
            //dogru yöntem
            if (!string.IsNullOrWhiteSpace(txtAdi.Text))
            {
                //query = query.Where(o => o.Adi.ToUpper() == txtAdi.Text.ToUpper().Trim());   
                //query = query.Where(o => o.Adi.ToUpper().StartsWith(txtAdi.Text.ToUpper().Trim()));
                //query = query.Where(o => o.Adi.ToUpper().EndsWith(txtAdi.Text.ToUpper().Trim()));
                query = query.Where(o => o.Adi.ToUpper().Contains(txtAdi.Text.ToUpper().Trim()));
            }
            if (cbYili.SelectedIndex > 0)
            {
                int yilId = Convert.ToInt32(cbYili.SelectedValue);
                query = query.Where(o => o.YilId == yilId);
            }

            if (!string.IsNullOrWhiteSpace(txtMaliyetBas.Text))
            {
                double maliyetBaslangic = Convert.ToDouble(txtMaliyetBas.Text.Trim(), new CultureInfo("tr"));
                query = query.Where(o => o.Maliyeti >= maliyetBaslangic);
            }
            if (!string.IsNullOrWhiteSpace(txtMaliyetSon.Text))
            {
                double maliyetBitis = Convert.ToDouble(txtMaliyetSon.Text.Trim(), new CultureInfo("tr"));
                query = query.Where(o => o.Maliyeti <= maliyetBitis);
            }

            if (!string.IsNullOrWhiteSpace(txtKazBas.Text))
            {
                double kazanciBaslangic = Convert.ToDouble(txtKazBas.Text.Trim(), new CultureInfo("tr"));
                query = query.Where(o => o.Maliyeti >= kazanciBaslangic);
            }
            if (!string.IsNullOrWhiteSpace(txtKazSon.Text))
            {
                double kazanciBitis = Convert.ToDouble(txtKazSon.Text.Trim(), new CultureInfo("tr"));
                query = query.Where(o => o.Kazanci <= kazanciBitis);
            }

            if (lbTurleri.SelectedItems.Count > 0)
            {
                List<int?> turIdleri = new List<int?>();
                foreach (var selectedItem in lbTurleri.SelectedItems)
                {
                    var turItem = selectedItem as TurModel;
                    turIdleri.Add(turItem.Id);
                }
                query = query.Where(o => turIdleri.Contains(o.TurId ));
            }
            #endregion            

            #region Sayfalama
            int toplamKayitSayisi = query.Count();
            int herBirSayfadakiKayitSayisi = Convert.ToInt32(ConfigurationManager.AppSettings["herBirSayfadakiKayitSayisi"]);

            int sayfaSayisi = Convert.ToInt32(Math.Ceiling((decimal)toplamKayitSayisi / (decimal)herBirSayfadakiKayitSayisi));
            int sayfaNo = 1;
            if (cbSayfa.Text != "")
                sayfaNo = Convert.ToInt32(cbSayfa.Text);
            if (sayfalariDoldur)
            {
                cbSayfa.Items.Clear();
                for (int i = 1; i <= sayfaSayisi; i++)
                {
                    cbSayfa.Items.Add(i);
                }
                sayfaNo = 1;
                cbSayfa.Text = sayfaNo.ToString();
            }

            query = query.Skip((sayfaNo - 1) * herBirSayfadakiKayitSayisi).Take(herBirSayfadakiKayitSayisi);
            #endregion

            var oyunlar = query.ToList();

            //Yanlış yöntem
            //if (!string.IsNullOrWhiteSpace(txtAdi.Text)) 
            //    oyunlar = oyunlar.Where(o => o.Adi.ToUpper() == txtAdi.Text.ToUpper().Trim()).ToList();


            dgvOyunlarRap.DataSource = oyunlar;
            dgvOyunlarRap.ClearSelection();
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void OyunRaporu_Shown(object sender, EventArgs e)
        {
            dgvOyunlarRap.ClearSelection();
        }

        private void cbSayfa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!formIlkYukleme)
                FillGrid(false);
        }

        private void cbSiralamaSutun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!formIlkYukleme)
                FillGrid(false);
        }

        private void cbSiralamaDeger_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!formIlkYukleme)
                FillGrid(false);
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtAdi.Clear();
            cbYili.SelectedIndex = 0;
            txtMaliyetBas.Text = "";
            txtMaliyetSon.Text = "";
            txtKazBas.Text = "";
            txtKazSon.Text = "";
            lbTurleri.ClearSelected();
            cbSiralamaSutun.Text = "Oyun Adı";
            cbSiralamaDeger.Text = "";
            formIlkYukleme = true;
            FillGrid();
            formIlkYukleme = false;
        }
    }
}
