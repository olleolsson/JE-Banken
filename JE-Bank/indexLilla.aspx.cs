using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace JE_Bank
{
    public partial class indexLilla : System.Web.UI.Page
    {
        Fråga f = new Fråga();
        Svarsalternativ s = new Svarsalternativ();
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = Server.MapPath("lillaTestet.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList allafrågor = doc.SelectNodes("/quiz/Frågor/*/fråga");

            foreach (XmlNode node in allafrågor) 
            {
                
            radio1.Items.Add(new ListItem(node["Frågan"].InnerText,"rätt"));
            
            }
           
     

        }

        protected void radio1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
             string fråga1 = radio1.SelectedValue.ToString();
           
        }
    }
}