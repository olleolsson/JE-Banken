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
        HtmlInputRadioButton rdbtn = new HtmlInputRadioButton();
        HtmlInputCheckBox input = new HtmlInputCheckBox();
        public List<Fråga> frågor = new List<Fråga>();

        protected void Page_Load(object sender, EventArgs e)
        {
           Users användare = new Users();
            Postgres pg = new Postgres();
            användare.Användarnamn = Server.UrlDecode(Request.QueryString["Parameter"].ToString());
            användare.Certifierad = Convert.ToBoolean(pg.AnvändarTyp(användare.Användarnamn));

            if (användare.Certifierad == true)
            {

                AppendProv(xmlToListLilla());
            }

            if (användare.Certifierad == false)
            {
                AppendProv(xmlToListStora());
            }
        }
      
        public void AppendProv(List<Fråga> frågor) 
        {
            int frågaNr = 1;

            foreach (Fråga f in frågor)
            {
                int x = 0;
                
                HtmlGenericControl frågeruta = new HtmlGenericControl("div id=frågeruta");
                HtmlGenericControl frågenummer = new HtmlGenericControl("div id=frågenummer");
                HtmlGenericControl frågan = new HtmlGenericControl("div id=frågan");
                frågenummer.InnerText = "Fråga " + frågaNr++;
                frågan.InnerText = f.Frågan;

                frågeruta.Controls.Add(frågenummer);
                frågeruta.Controls.Add(frågan);

                HtmlGenericControl form = new HtmlGenericControl("form");
                foreach (Svarsalternativ s in f.Svarsalternativslista)
                {
                    
                    if (s.RättSvar == true)
                    {
                        x++;
                    }
                }

                foreach (Svarsalternativ s in f.Svarsalternativslista)
                {
                    HtmlGenericControl svar = new HtmlGenericControl("div id=svarsalternativ");
                    HtmlGenericControl svarText = new HtmlGenericControl("div id=svarstext");

                    rdbtn = new HtmlInputRadioButton();
                    input = new HtmlInputCheckBox();


                    svarText.InnerText = s.Svaren;

                    if (x >= 2)
                    {
                        input.Value = s.RättSvar.ToString();
                        svar.Controls.Add(input);
                    }

                    if (x==1)
                    {
                        rdbtn.Value = s.RättSvar.ToString();
                        svar.Controls.Add(rdbtn);
                    }
                    svar.Controls.Add(svarText);

                    form.Controls.Add(svar);
                    frågeruta.Controls.Add(form);
                    allafrågor.Controls.Add(frågeruta);
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
                Svarsalternativ s = new Svarsalternativ();
                s.Svaren = node.ChildNodes[i].InnerText;    //Det rätta svaret som laddas in i listan har attributet rätt="y" 


                if (node.ChildNodes[i].Attributes.Count == 0)
                {
                    s.RättSvar = false;
                }
                else if (node.ChildNodes[i].Attributes.Count >= 1)
                {
                    s.RättSvar = true;
                }


                f.Svarsalternativslista.Add(s);                   //det ska vi jämföra mot sen under rättningen av provet vad användaren valt.
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
                    Svarsalternativ s = new Svarsalternativ();
                    s.Svaren = node.ChildNodes[i].InnerText;

                    if (node.ChildNodes[i].Attributes.Count == 0)
                    {
                        s.RättSvar = false;
                    }
                    else if (node.ChildNodes[i].Attributes.Count >= 1)
                    {
                        s.RättSvar = true;
                    }
                    f.Svarsalternativslista.Add(s);
                }
            }
            return Storatestet;
        }

        protected void btnRätta_Click(object sender, EventArgs e)
        {
            int antalRätt = 0;

            foreach (Fråga f in frågor)
            {
                foreach (Svarsalternativ s in f.Svarsalternativslista)
                {
                    if (s.RättSvar && rdbtn.Value == "True" && rdbtn.Checked)
                    {
                        antalRätt++;
                    }
                }
            }

            //ptagg.InnerText = antalRätt.ToString();
        }

        public void Rätta()
        {


        }

    }
}