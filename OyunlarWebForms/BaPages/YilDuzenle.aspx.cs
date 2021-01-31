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
    public partial class YilDuzenle : System.Web.UI.Page
    {
        private YilService yilService = new YilService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string id = Request.QueryString["id"];
                if (string.IsNullOrWhiteSpace(id))
                {
                    Response.Redirect("Yillar.aspx");
                }
                else
                {
                    YilModel model = yilService.GetByID(Convert.ToInt32(id));
                    txtDegeri.Text = model.Degeri;
                }
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            YilModel model = new YilModel()
            {
                Id = Convert.ToInt32(id),
                Degeri = txtDegeri.Text
            };
            Islem islem = yilService.Update(model);
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

        protected void btnDetay_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            Response.Redirect("YilDetayi.aspx?id=" + id);
        }
    }
}