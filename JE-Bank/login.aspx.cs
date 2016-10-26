using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JE_Bank
{
    public partial class logIn : System.Web.UI.Page
    {
        public string pAdmin = "admin";

        Users användare = new Users();
        Postgres pg = new Postgres();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogIn1_Click(object sender, EventArgs e)
        {
            användare.Användarnamn = "1";
            pg.AnvändarTyp(användare.Användarnamn);

            if (användare.Certifierad == true)
            {
                
            }

            if (användare.Certifierad == false)
            {
                
            }
        }

        protected void btnLogIn2_Click(object sender, EventArgs e)
        {
            användare.Användarnamn = "2";
            pg.AnvändarTyp(användare.Användarnamn);

            if (användare.Certifierad == true)
            {

            }

            if (användare.Certifierad == false)
            {

            }
        }

        protected void btnLogIn3_Click(object sender, EventArgs e)
        {
            användare.Användarnamn = "3";
            pg.AnvändarTyp(användare.Användarnamn);

            if (användare.Certifierad == true)
            {

            }

            if (användare.Certifierad == false)
            {

            }
        }

        protected void btnLogIn4_Click(object sender, EventArgs e)
        {
            användare.Användarnamn = "4";
            pg.AnvändarTyp(användare.Användarnamn);

            if (användare.Certifierad == true)
            {

            }

            if (användare.Certifierad == false)
            {

            }
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            användare.Användarnamn = "admin";
            pg.AnvändarTyp(användare.Användarnamn);
        }
    }
}