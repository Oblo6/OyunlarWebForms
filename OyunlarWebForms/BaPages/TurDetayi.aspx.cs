using OyunlarWebForms.BaBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OyunlarWebForms.BaModels
{
    public partial class TurDetayi : System.Web.UI.Page
    {
        private TurService turSerive = new TurService();
        private string idQueryString;
        protected void Page_Load(object sender, EventArgs e)
        {
            idQueryString = Request.QueryString["id"];//http://domian/TurDetayi.aspx?id=5
                                                      // istek: Request
                                                      // yanıt: Reponse
                                                      //string firma = Request.QueryString["firma"]; // http://domain.com/TurDetayi.aspx?firma=BilgeAdam
                                                      //string sehir = Request.QueryString["sehir"]; // http://domain.com/TurDetayi.aspx?firma=BilgeAdam&sehir=Ankara
                                                      //lblBilgi.Text = "Firma: " + firma + ", Şehir: " + sehir;
            if (!Page.IsPostBack)
            {            

                if (string.IsNullOrEmpty(idQueryString))
                {
                    Response.Redirect("Turler.aspx");
                }
                else
                {
                    int id = Convert.ToInt32(idQueryString);
                    turSerive.GetByID(id);
                    TurModel model = turSerive.GetByID(id);
                    lblAdi.Text = model.Adi;
                    lblBilgi.Text = "Tür detayı bildirildi";
                }
            }
        }

        protected void ibDüzenle_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("TurDuzenle.aspx?id=" + idQueryString);
            Session["turid"] = idQueryString;
            Response.Redirect("TurDuzenle.aspx");
        }

        protected void ibSil_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("TurSil.aspx?id=" + idQueryString);
        }
    }
}