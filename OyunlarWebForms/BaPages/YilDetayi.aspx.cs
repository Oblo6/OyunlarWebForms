using OyunlarWebForms.BaBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OyunlarWebForms.BaModels
{
    public partial class YilDetayi : System.Web.UI.Page
    {
        private YilService yilService = new YilService();
        private string idQueryString;
        protected void Page_Load(object sender, EventArgs e)
        {
            idQueryString = Request.QueryString["id"];

            if (!Page.IsPostBack)
            {            

                if (string.IsNullOrEmpty(idQueryString))
                {
                    Response.Redirect("Turler.aspx");
                }
                else
                {
                    int id = Convert.ToInt32(idQueryString);
                    YilModel model = yilService.GetByID(id);
                    
                }
            }
        }

        protected void ibDüzenle_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("YilDuzenle.aspx?id=" + idQueryString);
            
        }

        protected void ibSil_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("YilSil.aspx?id=" + idQueryString);
        }
    }
}