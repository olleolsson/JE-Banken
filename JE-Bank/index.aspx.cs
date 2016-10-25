using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Npgsql;

using System.Xml;

namespace JE_Bank
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           AppendProv(xmlToListLilla());
           AppendProv(xmlToListStora());
        }

        public void AppendProv(List<Prov> frågor) 
        {
            foreach (Prov f in frågor) 
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.InnerText = f.Fråga;
                allafrågor.Controls.Add(div);
            
            }
        
        }



	
        public List<Prov> xmlToListLilla() 
        {

        List<Prov> Lillatestet = new List<Prov>();

        string path = Server.MapPath("lillaTestet.xml");
        XmlDocument doc = new XmlDocument();
        doc.Load(path);

        XmlNodeList allafrågor = doc.SelectNodes("/quiz/Frågor/*/fråga");

        foreach (XmlNode node in allafrågor)
        {
            Prov f = new Prov();
            f.Fråga = node["Frågan"].InnerText;
            Lillatestet.Add(f);
        }

        return Lillatestet;       

        }


        public List<Prov> xmlToListStora()
        {

            List<Prov> Storatestet = new List<Prov>();

            string path = Server.MapPath("storaTestet.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNodeList allafrågor = doc.SelectNodes("/quiz/Frågor/*/fråga");

            foreach (XmlNode node in allafrågor)
            {
                Prov f = new Prov();
                f.Fråga = node["Frågan"].InnerText;
                Storatestet.Add(f);
            }

            return Storatestet;

        }
    }
}