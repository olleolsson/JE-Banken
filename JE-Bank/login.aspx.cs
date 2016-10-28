using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

namespace JE_Bank
{
    public partial class logIn : System.Web.UI.Page
    {
        public string pAdmin = "admin";

        Users användare = new Users();
        Postgres pg = new Postgres();
        index i = new index();

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnLogIn1_Click(object sender, EventArgs e)
        {
            användare.Användarnamn = "1";
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

        protected void btnLogIn2_Click(object sender, EventArgs e)
        {
            användare.Användarnamn = "2";

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

        protected void btnLogIn3_Click(object sender, EventArgs e)
        {
            användare.Användarnamn = "3";
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

        protected void btnLogIn4_Click(object sender, EventArgs e)
        {
            användare.Användarnamn = "4";
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

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            användare.Användarnamn = "admin";
            Response.Redirect("~/index.aspx?Parameter=" + Server.UrlEncode(användare.Användarnamn));
        }

    }
}