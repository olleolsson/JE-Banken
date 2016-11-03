using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace JE_Bank
{
    public partial class Facit : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl diven = new HtmlGenericControl("div");


            foreach (KeyValuePair<string, string> entry in PreviousPage.facit)
            {
                diven = new HtmlGenericControl("div");
                diven.InnerText = entry.Value + " " + entry.Key;
                ptagg1.Controls.Add(diven);


            }
        }
    }
}