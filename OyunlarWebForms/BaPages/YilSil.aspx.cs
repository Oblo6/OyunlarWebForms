using OyunlarWebForms.BaBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OyunlarWebForms.BaPages
{
    public partial class YilSil : System.Web.UI.Page
    {
        private YilService yilService = new YilService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string idOuertString = Request.QueryString["id"];
                if (string.IsNullOrWhiteSpace(idOuertString))
                {
                    Response.Redirect("Yillar.aspx");
                }
                else
                {
                    var model = yilService.GetByID(Convert.ToInt32(idOuertString));
                    lblDegeri.Text = model.Degeri;
                }                
            }
        }

        protected void btnEvet_Click(object sender, EventArgs e)
        {
            string idOuertString = Request.QueryString["id"];
            Islem islem =  yilService.Delete(Convert.ToInt32(idOuertString));
            if (islem == Islem.Basarili)
            {
                Response.Redirect("Yillar.aspx");
            }
            else if (islem == Islem.BasarisizIliskiliKayitVar)
            {
                lblBilgi.Text = "Silmek istediğiniz yil kaydi ile ilişkili oyun kaydı bulunduğundan işlem gerceklestirilemedi";
            }
            else
            {
                lblBilgi.Text = "İşlem sırasında hata meydana geldi!";
            }
        }

        
        protected void btnHayir_Click(object sender, EventArgs e)
        {
            string idOuertString = Request.QueryString["id"];
            Response.Redirect("YilDetayi.aspx?id=" + idOuertString);
        }
    }
}