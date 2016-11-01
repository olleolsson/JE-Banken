﻿using System;
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
            användare.Certifierad = Convert.ToBoolean(pg.AnvändarTyp(användare.Användarnamn));

            if (användare.Certifierad == true) //Köra lilla testet
            {
                //if ((användare.Godkänd - DateTime.Now).TotalDays > 365)//Kollar ifall anvädaren gjort godkänt test innom ett år
                //{
                //    Response.Redirect("~/indexLilla.aspx);
                //}

                //else //Ifall användaren har godkänt test
                //{
                //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Du har redan gjort ditt prov i år');", true);
                //}
            }

            if (användare.Certifierad == false)//Köra stora testet
            {
                
            }

            
            
            
        }

        protected void btnLogIn2_Click(object sender, EventArgs e)
        {
            användare.Användarnamn = "2";

            användare.Godkänd = pg.hämtaDatumGodkänd(användare.Användarnamn);
            användare.Certifierad = Convert.ToBoolean(pg.AnvändarTyp(användare.Användarnamn));

            if (användare.Certifierad == true) //Köra lilla testet
            {
                //if ((användare.Godkänd - DateTime.Now).TotalDays > 365)//Kollar ifall anvädaren gjort godkänt test innom ett år
                //{
                //    Response.Redirect("~/indexLilla.aspx);
                //}

                //else //Ifall användaren har godkänt test
                //{
                //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Du har redan gjort ditt prov i år');", true);
                //}
            }

            if (användare.Certifierad == false)//Köra stora testet
            {

            }
        }

        protected void btnLogIn3_Click(object sender, EventArgs e)
        {
            användare.Användarnamn = "3";
            användare.Godkänd = pg.hämtaDatumGodkänd(användare.Användarnamn);
            användare.Certifierad = Convert.ToBoolean(pg.AnvändarTyp(användare.Användarnamn));

            if (användare.Certifierad == true) //Köra lilla testet
            {
                //if ((användare.Godkänd - DateTime.Now).TotalDays > 365)//Kollar ifall anvädaren gjort godkänt test innom ett år
                //{
                //    Response.Redirect("~/indexLilla.aspx);
                //}

                //else //Ifall användaren har godkänt test
                //{
                //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Du har redan gjort ditt prov i år');", true);
                //}
            }

            if (användare.Certifierad == false)//Köra stora testet
            {

            }

        }

        protected void btnLogIn4_Click(object sender, EventArgs e)
        {
            användare.Användarnamn = "4";
            användare.Godkänd = pg.hämtaDatumGodkänd(användare.Användarnamn);
            användare.Certifierad = Convert.ToBoolean(pg.AnvändarTyp(användare.Användarnamn));

            if (användare.Certifierad == true) //Köra lilla testet
            {
                //if ((användare.Godkänd - DateTime.Now).TotalDays > 365)//Kollar ifall anvädaren gjort godkänt test innom ett år
                //{
                //    Response.Redirect("~/indexLilla.aspx);
                //}

                //else //Ifall användaren har godkänt test
                //{
                //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Du har redan gjort ditt prov i år');", true);
                //}
            }

            if (användare.Certifierad == false)//Köra stora testet
            {

            }

        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            användare.Användarnamn = "admin";
            Response.Redirect("~/index.aspx?Parameter=" + Server.UrlEncode(användare.Användarnamn));
        }

    }
}