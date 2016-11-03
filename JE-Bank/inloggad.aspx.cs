using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JE_Bank
{
    public partial class inloggad : System.Web.UI.Page
    {
        Users användare = new Users();
        Postgres pg = new Postgres();

        protected void Page_Load(object sender, EventArgs e)
        {
            användare.Användarnamn = Server.UrlDecode(Request.QueryString["Parameter"].ToString());
            lblDatum.Text ="Senast godkända test: " + pg.hämtaDatumGodkänd(användare.Användarnamn).ToShortDateString();
            
        }

        protected void btnStartaTest_Click(object sender, EventArgs e)
        {
             användare.Godkänd = pg.hämtaDatumGodkänd(användare.Användarnamn);
             
             Response.Redirect("~/index.aspx?Parameter=" + Server.UrlEncode(användare.Användarnamn));
 
             //if ((användare.Godkänd - DateTime.Now).TotalDays > 365)
             //{
             //    Response.Redirect("~/index.aspx?Parameter=" + Server.UrlEncode(användare.Användarnamn));
             //}
 
             //else
             //{
             //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Du har redan gjort ditt prov i år');", true);
             //}
        }

        protected void btnHistorik_Click(object sender, EventArgs e)
        {

        }
    }
}