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

        public void AppendProv(List<Frågan> frågor) 
        {
            foreach (Frågan f in frågor) 
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.InnerText = f.Frågan;
                allafrågor.Controls.Add(div);
            
            }
        
        }



	
        public List<Frågan> xmlToListLilla() 
        {

        List<Frågan> Lillatestet = new List<Frågan>();

        string path = Server.MapPath("lillaTestet.xml");
        XmlDocument doc = new XmlDocument();
        doc.Load(path);

        XmlNodeList allafrågor = doc.SelectNodes("/quiz/Frågor/*/fråga");

        foreach (XmlNode node in allafrågor)
        {
            Frågan f = new Frågan();
            f.Frågan = node["Frågan"].InnerText;
            Lillatestet.Add(f);

            foreach (XmlNode nod in allafrågor)
            {
                Svar s = new Svar();
                s.Svaren = nod["svar"].InnerText;
                f.Svarsalternativ.Add(s);
            }
        }

        return Lillatestet;       

        }


        public List<Frågan> xmlToListStora()
        {

            List<Frågan> Storatestet = new List<Frågan>();

            string path = Server.MapPath("storaTestet.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNodeList allafrågor = doc.SelectNodes("/quiz/Frågor/*/fråga");

            foreach (XmlNode node in allafrågor)
            {
                Frågan f = new Frågan();
                f.Frågan = node["Frågan"].InnerText;
                Storatestet.Add(f);
            }

            return Storatestet;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Postgres pg = new Postgres();
            allafrågor.InnerText = pg.TestSqlFråga();
        }
    }
}