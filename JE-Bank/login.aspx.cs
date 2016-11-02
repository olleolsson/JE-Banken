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
            Response.Redirect("~/inloggad.aspx?Parameter=" + Server.UrlEncode(användare.Användarnamn));
        }

        protected void btnLogIn2_Click(object sender, EventArgs e)
        {
            användare.Användarnamn = "2";
            Response.Redirect("~/inloggad.aspx?Parameter=" + Server.UrlEncode(användare.Användarnamn));
        }

        protected void btnLogIn3_Click(object sender, EventArgs e)
        {
            användare.Användarnamn = "3";
            Response.Redirect("~/inloggad.aspx?Parameter=" + Server.UrlEncode(användare.Användarnamn));
        }

        protected void btnLogIn4_Click(object sender, EventArgs e)
        {
            användare.Användarnamn = "4";
            Response.Redirect("~/inloggad.aspx?Parameter=" + Server.UrlEncode(användare.Användarnamn));
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            användare.Användarnamn = "admin";
            Response.Redirect("~/index.aspx?Parameter=" + Server.UrlEncode(användare.Användarnamn));
        }

    }
}