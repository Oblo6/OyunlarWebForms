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
    public partial class TurDuzenle : System.Web.UI.Page
    {
        private TurService turService = new TurService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["turid"] == null)
                {
                    Response.Redirect("Turler.aspx");
                }
                else
                {
                    string idSession = Session["turid"].ToString();
                    //lblBilgi.Text = idSession;

                    var model = turService.GetByID(Convert.ToInt32(idSession));
                    txtAdi.Text = model.Adi;
                }
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            string idSession = Session["turid"].ToString();
            var model = new TurModel()
            {
                Id = Convert.ToInt32(idSession),
                Adi = txtAdi.Text.Trim()
            };
            if (turService.Update(model))
            {
                lblBilgi.Text = "Güncellendi";
            }
            else
            {
                lblBilgi.Text = model.Adi + " diye kayıt var";
            }
        }

        protected void btnDetay_Click(object sender, EventArgs e)
        {
            string idSession = Session["turid"].ToString();
            Response.Redirect("TurDetayi.aspx?id=" + idSession);

        }
    }
}