using OyunlarWebForms.BaBusiness;
using OyunlarWebForms.BaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OyunlarWebForms.BaPages
{
    public partial class YilEkle : System.Web.UI.Page
    {
        private YilService yilService = new YilService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            YilModel model = new YilModel()
            {
                Degeri = txtDegeri.Text
            };
            Islem islem = yilService.Add(model);
            //if (islem == Islem.Basarili)
            //{
            //    Response.Redirect("Yillar.aspx");
            //}
            //else if (islem == Islem.BasarisizBosDeger)
            //{
            //    lblBilgi.Text = "Boş değer girilemez";
            //}
            //else if (islem == Islem.BasarisizKayitVar)
            //{
            //    lblBilgi.Text = "Girdiğiniz değere sahip yıl kaydı bulunduğundan işlem gerçekleştirilemedi.";
            //}
            //else
            //{
            //    lblBilgi.Text = "İşlem sırasında hata meydana geldi!";
            //}
            switch (islem)
            {                
                case Islem.Basarili:
                    Response.Redirect("Yillar.aspx");
                    break;
                case Islem.BasarisizBosDeger:
                    lblBilgi.Text = "Boş değer girilemez";
                    break;
                case Islem.BasarisizKayitVar:
                    lblBilgi.Text = "Girdiğiniz değere sahip yıl kaydı bulunduğundan işlem gerçekleştirilemedi.";
                    break;
                default:
                    lblBilgi.Text = "İşlem sırasında hata meydana geldi!";
                    break;
            }
        }
    }
}
