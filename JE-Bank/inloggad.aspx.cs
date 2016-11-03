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
        string x = "0001-01-01";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            användare.Användarnamn = Server.UrlDecode(Request.QueryString["Parameter"].ToString());
            lblDatum.Text ="Senast godkända test: " + pg.hämtaDatumGodkänd(användare.Användarnamn).ToShortDateString();

            if (pg.hämtaDatumGodkänd(användare.Användarnamn).ToShortDateString() == x)
            {
                lblDatum.Text = "Du har inte gjort något test ännu";
            }
            användare.Utförd = pg.hämtaDatumGjortTest(användare.Användarnamn);
        }

        protected void btnStartaTest_Click(object sender, EventArgs e)
        {
             användare.Godkänd = pg.hämtaDatumGodkänd(användare.Användarnamn);

             if ((DateTime.Now - användare.Godkänd).Days > 365)
             {

            if (( DateTime.Now - användare.Utförd).TotalDays < 7)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Du måste vänta 7 dagar innan du gör testet igen');", true);
            }

                 else
                 {
                    Response.Redirect("~/index.aspx?Parameter=" + Server.UrlEncode(användare.Användarnamn));
                 }
             }
             
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Du har redan ett godkänt test detta år');", true);
            }             
        }

        protected void btnHistorik_Click(object sender, EventArgs e)
        {

        }
    }
}