using OyunlarWebForms.BaEntities;
using OyunlarWebForms.BaModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OyunlarWebForms.BaPages
{
    public partial class Oyunlar : System.Web.UI.Page
    {
        private OyunlarContext db = new OyunlarContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                FillGrid();

            pDetay.Visible = false;
            pYeni.Visible = false;
            pDuzenle.Visible = false;
        }

        private void FillGrid()
        {
            //Lazy loading...
            //List<Oyun> oyunlarEntity = db.Oyun.ToList();

            //eager loading...
            List<Oyun> oyunlarEntity = db.Oyun.Include("Yil").ToList();

            List<OyunModel> oyunlarModel = new List<OyunModel>();
            OyunModel oyunModel;
            //foreach (Oyun oyunEntity in oyunlarEntity)
            //{
            //    oyunModel = new OyunModel()
            //    {
            //        Id = oyunEntity.Id,
            //        Adi = oyunEntity.Adi,
            //        Kazanci = oyunEntity.Kazanci,
            //        Maliyeti = oyunEntity.Maliyeti,
            //        YilId = oyunEntity.YilId,
            //        YilDegeri = oyunEntity.Yil.Degeri
            //    };
            //    oyunlarModel.Add(oyunModel);
            //}
            oyunlarModel = oyunlarEntity.Select(oyunEntity => new OyunModel()
            {
                Id = oyunEntity.Id,
                Adi = oyunEntity.Adi,
                Kazanci = oyunEntity.Kazanci,
                Maliyeti = oyunEntity.Maliyeti,
                YilId = oyunEntity.YilId,
                YilDegeri = oyunEntity.Yil.Degeri,
                KarZarar = oyunEntity.Kazanci != null && oyunEntity.Maliyeti.HasValue ? (oyunEntity.Kazanci.Value - oyunEntity.Maliyeti.Value).ToString("c2", new CultureInfo("tr")) : ""
            }).ToList();

            gvOyunlar.DataSource = oyunlarModel;
            gvOyunlar.DataBind();

            gvOyunlar.HeaderRow.Cells[1].Visible = false;
            foreach (GridViewRow row in gvOyunlar.Rows)
            {
                row.Cells[1].Visible = false;
            }

            //CRUD: Create, Read, Update Delete
        }

        protected void dgOyunlar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnDetay_Click(object sender, EventArgs e)
        {
            lblBilgi.Text = "";
            if (gvOyunlar.SelectedIndex == -1)
            {
                lblBilgi.Text = "Lütfen listeden kayıt seçiniz!";
                return;
            }
            int id = Convert.ToInt32(gvOyunlar.SelectedRow.Cells[1].Text);
            //lblBilgi.Text = id;

            //Oyun oyunEntity = db.Oyun.Find(id);  //Entity Framework


            Oyun oyunEntity;

            // Sonu OrDefault ile biten LINQ methodları eğer kayıt bulunamazsa null döner. Default ile bitmeyenler kayıt bulunamazsa hata fırlatır.
            // Where(koşul(lar)) belirtilen koşul(lar)a uygun içerisinde kayıt olmayan, tek kayıt olan veya birden çok kayıt olan bir veri kümesi döner.
            // Bu küme içerisinden ihtiyaç duyulan kayda SingleOrDefault() veya FirstOrDefault() ile ulaşılabilir.
            //oyunEntity = db.Oyun.Where(oyun => oyun.Id == id).SingleOrDefault(); // Filtreleme sonucundan tek kayıt getir, birden çok kayıt gelirse hata verir.
            //oyunEntity = db.Oyun.Where(oyun => oyun.Id == id).FirstOrDefault(); // Filtreleme sonucundan ilk kaydı getir.

            // LastOrDefault() methodu bazı durumlarda hata verebilir. Eğer mutlaka kullanılması gerekiyorsa bu tip durumlarda bir aşağıdaki comment'siz
            // satırda olduğu gibi kayıtlar belli koşul(lar)a göre azalan olarak sıralanıp ilk kayıt çekilerek son kayda ulaşılmış olur.
            //oyunEntity = db.Oyun.Where(oyun => oyun.Id == id).LastOrDefault(); // Filtreleme sonucundan son kaydı getir.
            //oyunEntity = db.Oyun.OrderByDescending(oyun => oyun.Id).Where(oyun => oyun.Id == id).FirstOrDefault(); // Filtreleme sonucundan son kaydı getir.



            // Aşağıdaki methodlar belirtilen koşul(lar)a uygun tek bir kayıt döner.
            // Eğer belirtilen koşul(lar)a göre tek bir kayda ulaşılmak isteniyorsa aşağıdaki methodları kullanmak daha doğrudur.
            //oyunEntity = db.Oyun.FirstOrDefault(oyun => oyun.Id == id); // Filtreleme sonucundan ilk kaydı getir.

            // LastOrDefault(koşul(lar)) methodu bazı durumlarda hata verebilir. Eğer mutlaka kullanılması gerekiyorsa bu tip durumlarda bir aşağıdaki comment'siz
            // satırda olduğu gibi kayıtlar belli koşul(lar)a göre azalan olarak sıralanıp ilk kayıt çekilerek son kayda ulaşılmış olur.
            //oyunEntity = db.Oyun.LastOrDefault(oyun => oyun.Id == id); // Filtreleme sonucundan son kaydı getir.
            //oyunEntity = db.Oyun.OrderByDescending(oyun => oyun.Id).FirstOrDefault(oyun => oyun.Id == id); // Filtreleme sonucundan son kaydı getir.

            //oyunEntity = db.Oyun.SingleOrDefault(oyun => oyun.Id == id); // Filtreleme sonucundan tek kayıt getir, birden çok kayıt gelirse hata verir.

            // Yukarıdaki tüm LINQ methodları List gibi kolleksiyonlarda da kullanılabilir ancak aşğıdaki Find methodu sadece DbSet (Entity Framework) için kullanılabilir.
            oyunEntity = db.Oyun.Find(id);

            OyunModel oyunModel = new OyunModel();
            oyunModel.Id = oyunEntity.Id;
            oyunModel.Adi = oyunEntity.Adi;
            oyunModel.Kazanci = oyunEntity.Kazanci;
            oyunModel.Maliyeti = oyunEntity.Maliyeti;
            oyunModel.YilId = oyunEntity.YilId;
            oyunModel.YilDegeri = oyunEntity.Yil.Degeri;
            //oyunModel.TurAdlari = oyunEntity.OyunTur.Select(oyunTur => oyunTur.Tur.Adi).ToList();
            oyunModel.TurAdlari = string.Join(", ", oyunEntity.OyunTur.Select(oyunTur => oyunTur.Tur.Adi).ToList());

            lblTurleri.Text = oyunModel.TurAdlari;
            //foreach (string turAdi in oyunModel.TurAdlari)
            //{
            //    lblTurleri.Text += turAdi + ", ";
            //}
            //lblTurleri.Text = lblTurleri.Text.Trim(',', ' ');
            lblAdi.Text = oyunModel.Adi;
            lblMaliyeti.Text = "";
            if (oyunModel.Maliyeti.HasValue)   //if (oyunModel.Maliyeti != null)
            {
                lblMaliyeti.Text = oyunModel.Maliyeti.Value.ToString(new CultureInfo("tr"));
            }
            lblKazanci.Text = "";
            if (oyunModel.Kazanci != null)
            {
                lblKazanci.Text = oyunModel.Kazanci.Value.ToString(new CultureInfo("en"));
            }
            lblYili.Text = oyunModel.YilDegeri;

            pDetay.Visible = true;
        }

        protected void lbYeni_Click(object sender, EventArgs e)
        {
            FillYillar(ddlYiliYeni);
            FillTurlerListBox(lbTürleri);
            //pYeni.Visible = !pYeni.Visible;
            pYeni.Visible = true;
        }

        public void FillTurlerListBox(ListBox ListBox)
        {
            ListBox.Items.Clear();
            var turlerModel =  db.Tur.OrderBy(tur => tur.Adi).Select(tur => new TurModel()
            {
                Id = tur.Id,
                Adi = tur.Adi
            }).ToList();
            ListBox.DataValueField = "Id";
            ListBox.DataTextField = "Adi";
            ListBox.DataSource = turlerModel;
            ListBox.DataBind();
        }

        private void FillYillar(DropDownList dropDownList)
        {
            dropDownList.Items.Clear();
            var yillarEntity = db.Yil.OrderByDescending(yil => yil.Degeri).ToList();
            //var yillarEntity = db.Yil.OrderBy(yil => yil.Degeri).ToList();
            var yillarModel = yillarEntity.Select(yilEntity => new YilModel()
            {
                Id = yilEntity.Id,
                Degeri = yilEntity.Degeri
            }).ToList();
            dropDownList.DataValueField = "Id";
            dropDownList.DataTextField = "Degeri";
            dropDownList.DataSource = yillarModel;
            dropDownList.DataBind();
            dropDownList.Items.Insert(0, "---Seçiniz---");
        }

        protected void btnKaydetYeni_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdiYeni.Text))
            {
                lblBilgi.Text = "Adı boş bırakılamaz!";
                pYeni.Visible = true;
                return;
            }
            double maliyetValidasyon;
            double kazanciValidasyon;
            if (!string.IsNullOrWhiteSpace(txtMaliyetiYeni.Text))
            {
                if (!double.TryParse(txtMaliyetiYeni.Text.Trim().Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out maliyetValidasyon))
                {
                    lblBilgi.Text = "Maliyet sayısal olmalıdır";
                    pYeni.Visible = true;
                    return;
                }
            }
            if (!string.IsNullOrWhiteSpace(txtKazanciYeni.Text))
            {
                if (!double.TryParse(txtKazanciYeni.Text.Trim().Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out kazanciValidasyon))
                {
                    lblBilgi.Text = "Kazancı sayısal olmalıdır!";
                    pYeni.Visible = true;
                    return;
                }
            }
            if (ddlYiliYeni.SelectedIndex == 0)
            {
                lblBilgi.Text = "Yıl seçiniz";
                pYeni.Visible = true;
                return;
            }

            if (lbTürleri.SelectedIndex == -1)
            {
                lblBilgi.Text = "En az bir tür seçilmelidir";
                pYeni.Visible = true;
                return;
            }

            if (db.Oyun.Any(oyun => oyun.Adi.ToLower() == txtAdiYeni.Text.ToLower().Trim()))
            {
                lblBilgi.Text = "Girdiğiniz oyun adına sahip kayıt bulunmaktadır.";
                pYeni.Visible = true;
                return;
            }

            OyunModel oyunModel = new OyunModel()
            {
                Adi = txtAdiYeni.Text.Trim(),
                YilId = Convert.ToInt32(ddlYiliYeni.SelectedValue)                                
            };

            oyunModel.TurIdleri = new List<int>();
            foreach (ListItem item in lbTürleri.Items)
            {
                if (item.Selected)
                {
                    oyunModel.TurIdleri.Add(Convert.ToInt32(item.Value));
                }
            }

            oyunModel.Maliyeti = null;
            if (!string.IsNullOrWhiteSpace(txtMaliyetiYeni.Text))
            {
                oyunModel.Maliyeti = Convert.ToDouble(txtMaliyetiYeni.Text.Trim().Replace(",", "."), CultureInfo.InvariantCulture);//BİR GUN DONER BURAYI ARARSIN
            }

            oyunModel.Kazanci = null;
            if (!string.IsNullOrEmpty(txtKazanciYeni.Text))
            {
                oyunModel.Kazanci = Convert.ToDouble(txtKazanciYeni.Text.Trim().Replace(",", "."), CultureInfo.InvariantCulture);
            }

            Oyun oyunEntity = new Oyun()
            {
                Adi = oyunModel.Adi,
                Kazanci = oyunModel.Kazanci,
                Maliyeti = oyunModel.Maliyeti,
                YilId = oyunModel.YilId,
                OyunTur = oyunModel.TurIdleri.Select(turId => new OyunTur() {
                    OyunId = oyunModel.Id,
                    TurId = turId
                }).ToList()
            };

            db.Oyun.Add(oyunEntity);
            db.SaveChanges();
            lblBilgi.Text = "Oyun başarıyla kaydedildi";
            FillGrid();
        }

        protected void btnTemizleYeni_Click(object sender, EventArgs e)
        {
            txtAdiYeni.Text = "";
            txtMaliyetiYeni.Text = "";
            txtKazanciYeni.Text = "";
            ddlYiliYeni.SelectedIndex = 0;
            foreach (ListItem item in lbTürleri.Items)
            {
                item.Selected = false;
            }
            lblBilgi.Text = "";
            pYeni.Visible = true;
        }


        protected void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (gvOyunlar.SelectedIndex == -1)
            {
                lblBilgi.Text = "Lütfen listeden kayıt seçiniz...";
                return;
            }

            FillYillar(ddlYiliDuzenle);
            FillTurlerCheckboxList(cblTurleriDuzenle);

            int id = Convert.ToInt32(gvOyunlar.SelectedRow.Cells[1].Text);
            Oyun oyunEntity = db.Oyun.Find(id);
            OyunModel oyunModel = new OyunModel()
            {
                Id = oyunEntity.Id,
                Adi = oyunEntity.Adi,
                Kazanci = oyunEntity.Kazanci,
                Maliyeti = oyunEntity.Maliyeti,
                YilId = oyunEntity.YilId,
                TurIdleri = oyunEntity.OyunTur.Select(oyunTur => oyunTur.TurId).ToList()
            };

            foreach (ListItem item in cblTurleriDuzenle.Items)
            {
                foreach (int turId in oyunModel.TurIdleri)
                {
                    if (item.Value == turId.ToString())
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }

            txtAdiDuzenle.Text = oyunModel.Adi;
            txtKazanciDuzenle.Text = "";
            if (oyunModel.Kazanci.HasValue)
                txtKazanciDuzenle.Text = oyunModel.Kazanci.Value.ToString(CultureInfo.InvariantCulture).Replace(".", ",");

            txtMaliyetiDuzenle.Text = "";
            if (oyunModel.Maliyeti.HasValue)
                txtMaliyetiDuzenle.Text = oyunModel.Maliyeti.Value.ToString(CultureInfo.InvariantCulture).Replace(".", ",");

            ddlYiliDuzenle.SelectedValue = oyunModel.YilId.ToString();

            pDuzenle.Visible = true;
        }

        private void FillTurlerCheckboxList(CheckBoxList checkBoxList)
        {
            cblTurleriDuzenle.Items.Clear();
            var turlerModel = db.Tur.OrderBy(tur => tur.Adi).Select(tur => new TurModel()
            {
                Id = tur.Id,
                Adi = tur.Adi
            }).ToList();
            cblTurleriDuzenle.DataValueField = "Id";
            cblTurleriDuzenle.DataTextField = "Adi";
            cblTurleriDuzenle.DataSource = turlerModel;
            cblTurleriDuzenle.DataBind();
        }

        protected void btnKaydetDuzenle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdiDuzenle.Text))
            {
                lblBilgi.Text = "Adı boş bırakılamaz!";
                pDuzenle.Visible = true;
                return;
            }
            double maliyetValidasyon;
            double kazanciValidasyon;
            if (!string.IsNullOrWhiteSpace(txtMaliyetiDuzenle.Text))
            {
                if (!double.TryParse(txtMaliyetiDuzenle.Text.Trim().Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out maliyetValidasyon))
                {
                    lblBilgi.Text = "Maliyet sayısal olmalıdır";
                    pDuzenle.Visible = true;
                    return;
                }
            }
            if (!string.IsNullOrWhiteSpace(txtKazanciDuzenle.Text))
            {
                if (!double.TryParse(txtKazanciDuzenle.Text.Trim().Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out kazanciValidasyon))
                {
                    lblBilgi.Text = "Kazancı sayısal olmalıdır!";
                    pDuzenle.Visible = true;
                    return;
                }
            }
            if (ddlYiliDuzenle.SelectedIndex == 0)
            {
                lblBilgi.Text = "Yıl seçiniz";
                pDuzenle.Visible = true;
                return;
            }

            if (cblTurleriDuzenle.SelectedIndex == -1)
            {
                lblBilgi.Text = "En az bir tür kaydı seçilmelidir!";
                pDuzenle.Visible = true;
                return;
            }

            int id = Convert.ToInt32(gvOyunlar.SelectedRow.Cells[1].Text);
            if (db.Oyun.Any(oyun => oyun.Adi.ToLower() == txtAdiDuzenle.Text.ToLower().Trim() && oyun.Id != id))
            {
                lblBilgi.Text = "Girdiğiniz oyun adına sahip kayıt bulunmaktadır.";
                pDuzenle.Visible = true;
                return;
            }

            OyunModel oyunModel = new OyunModel()
            {
                Adi = txtAdiDuzenle.Text.Trim(),
                YilId = Convert.ToInt32(ddlYiliDuzenle.SelectedValue)
            };

            oyunModel.TurIdleri = new List<int>();
            foreach (ListItem item in cblTurleriDuzenle.Items)
            {
                if (item.Selected)
                {
                    oyunModel.TurIdleri.Add(Convert.ToInt32(item.Value));
                }
            }

            oyunModel.Maliyeti = null;
            if (!string.IsNullOrWhiteSpace(txtMaliyetiDuzenle.Text))
            {
                oyunModel.Maliyeti = Convert.ToDouble(txtMaliyetiDuzenle.Text.Trim().Replace(",", "."), CultureInfo.InvariantCulture);//BİR GUN DONER BURAYI ARARSIN
            }

            oyunModel.Kazanci = null;
            if (!string.IsNullOrEmpty(txtKazanciDuzenle.Text))
            {
                oyunModel.Kazanci = Convert.ToDouble(txtKazanciDuzenle.Text.Trim().Replace(",", "."), CultureInfo.InvariantCulture);
            }

            oyunModel.Id = id;
            Oyun oyunEntity = db.Oyun.Find(oyunModel.Id);

            db.OyunTur.RemoveRange(oyunEntity.OyunTur.ToList());
            oyunEntity.OyunTur = oyunModel.TurIdleri.Select(turId => new OyunTur()
            {
                OyunId = oyunEntity.Id,
                TurId = turId
            }).ToList();

            oyunEntity.Adi = oyunModel.Adi;
            oyunEntity.Kazanci = oyunModel.Kazanci;
            oyunEntity.Maliyeti = oyunModel.Maliyeti;
            oyunEntity.YilId = oyunModel.YilId;
            db.Entry(oyunEntity).State = EntityState.Modified;
            db.SaveChanges();
            lblBilgi.Text = "Oyun başarıyla güncellendi";
            FillGrid();
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            if (gvOyunlar.SelectedIndex == -1)
            {
                lblBilgi.Text = "Lütfen listeden kayıt seçiniz...";
            }

            int id = Convert.ToInt32(gvOyunlar.SelectedRow.Cells[1].Text);
            Oyun oyunEntity = db.Oyun.Find(id);
            db.OyunTur.RemoveRange(oyunEntity.OyunTur.ToList());
            db.Oyun.Remove(oyunEntity);
            db.SaveChanges();
            lblBilgi.Text = "Oyun başarıyla silindi";
            FillGrid();
        }

        protected void btnTemizleDüzenle_Click(object sender, EventArgs e)
        {
            txtAdiDuzenle.Text = "";
            txtMaliyetiDuzenle.Text = "";
            txtKazanciDuzenle.Text = "";
            ddlYiliDuzenle.SelectedIndex = 0;
            foreach (ListItem item in cblTurleriDuzenle.Items)
            {
                item.Selected = false;
            }
            lblBilgi.Text = "";
            pDuzenle.Visible = true;
        }
    }
}