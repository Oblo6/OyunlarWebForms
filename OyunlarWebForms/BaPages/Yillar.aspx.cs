using OyunlarWebForms.BaBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OyunlarWebForms.BaPages
{
    public partial class Yillar : System.Web.UI.Page
    {
        private YilService yilService = new YilService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGrid();
            }
        }

        private void FillGrid()
        {
            var yillar = yilService.GetList();
            if (yillar == null)
            {
                lblBilgi.Text = "İşlem sırasında hata meydana geldi!";
                return;
            }
            gvYillar.DataSource = yillar;
            gvYillar.DataBind();
            SetColumnVisibilities();
        }

        private void SetColumnVisibilities()
        {
            gvYillar.HeaderRow.Cells[1].Visible = false;
            foreach (GridViewRow row in gvYillar.Rows)
            {
                row.Cells[1].Visible = false;
            }
        }

        protected void gvTurler_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvYillar.SelectedRow.Cells[1].Text;
            Response.Redirect("YilDetayi.aspx?id=" + id);
        }

        protected void lbEkle_Click(object sender, EventArgs e)
        {
            Response.Redirect("YilEkle.aspx");
        }
    }
}