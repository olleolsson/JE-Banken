﻿using System;
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

        public void AppendProv(List<Fråga> frågor) 
        {
            foreach (Fråga f in frågor) 
            {
                HtmlGenericControl div = new HtmlGenericControl("div id=frågan");
                div.InnerText = f.Frågan;
                allafrågor.Controls.Add(div);               

                foreach (Svar s in f.Svarsalternativ)
                {
                    int i;
                    HtmlGenericControl div1 = new HtmlGenericControl("div id=svarsalternativ");
                    HtmlInputCheckBox input = new HtmlInputCheckBox();
                    div1.InnerText = s.Svaren;
                    
                    //allafrågor.Controls.Add(input);
                }
                
            }
        
        }



	
        public List<Fråga> xmlToListLilla() 
        {

        List<Fråga> Lillatestet = new List<Fråga>();

        string path = Server.MapPath("lillaTestet.xml");
        XmlDocument doc = new XmlDocument();
        doc.Load(path);

        XmlNodeList allafrågor = doc.SelectNodes("/quiz/Frågor/*/fråga");
        XmlNodeList allasvar = doc.SelectNodes("/quiz/Frågor/*/fråga/Frågan");

        foreach (XmlNode node in allafrågor)
        {
            Fråga f = new Fråga();
            f.Frågan = node["Frågan"].InnerText;
            Lillatestet.Add(f);

            for (int i = 1; i < node.ChildNodes.Count; i++)
            {
                Svar s = new Svar();
                s.Svaren = node.ChildNodes[i].InnerText;
                f.Svarsalternativ.Add(s);
            }           
        }

        return Lillatestet;       

        }


        public List<Fråga> xmlToListStora()
        {

            List<Fråga> Storatestet = new List<Fråga>();

            string path = Server.MapPath("storaTestet.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNodeList allafrågor = doc.SelectNodes("/quiz/Frågor/*/fråga");

            foreach (XmlNode node in allafrågor)
            {
                Fråga f = new Fråga();
                f.Frågan = node["Frågan"].InnerText;
                Storatestet.Add(f);

                for (int i = 1; i < node.ChildNodes.Count; i++)
                {
                    Svar s = new Svar();
                    s.Svaren = node.ChildNodes[i].InnerText;
                    f.Svarsalternativ.Add(s);
                }
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