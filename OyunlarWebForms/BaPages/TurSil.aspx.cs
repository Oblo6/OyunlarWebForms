using OyunlarWebForms.BaBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OyunlarWebForms.BaPages
{
    public partial class TurSil : System.Web.UI.Page
    {
        private TurService turService = new TurService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string idOuertString = Request.QueryString["id"];
                if (string.IsNullOrWhiteSpace(idOuertString))
                {
                    Response.Redirect("Turler.aspx");
                }
                else
                {
                    var model = turService.GetByID(Convert.ToInt32(idOuertString));
                    lblAdi.Text = model.Adi;
                }                
            }
        }

        protected void btnEvet_Click(object sender, EventArgs e)
        {
            string idOuertString = Request.QueryString["id"];
            turService.Delete(Convert.ToInt32(idOuertString));
            Response.Redirect("Turler.aspx");
        }

        
        protected void btnHayir_Click(object sender, EventArgs e)
        {
            string idOuertString = Request.QueryString["id"];
            Response.Redirect("TurDetayi.aspx?id=" + idOuertString);
        }
    }
}