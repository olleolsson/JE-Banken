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
        public List<HtmlInputCheckBox> checkList = new List<HtmlInputCheckBox>();
        public List<HtmlInputRadioButton> radioList = new List<HtmlInputRadioButton>();
        Postgres pg = new Postgres();
        Users användare = new Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            btnFacit.Visible = false;
            Postgres pg = new Postgres();
            användare.Användarnamn = Server.UrlDecode(Request.QueryString["Parameter"].ToString());
            användare.Certifierad = Convert.ToBoolean(pg.AnvändarTyp(användare.Användarnamn));

            if (användare.Certifierad == true)
            {
                string sökvägXML = "lillaTestet.xml";
                AppendProv(xmlToList(sökvägXML));
            }

            if (användare.Certifierad == false)
            {
                string sökvägXML = "storaTestet.xml";
                AppendProv(xmlToList(sökvägXML));
            }           
        }

        public void AppendProv(List<Fråga> frågor)
        {
            int frågaNr = 1;
            int svarId = 1;
            int indexArr = 0;
            int räkna = 0;
            int knappid = 0;

            foreach (Fråga f in frågor)
            {
                int x = 0;

                HtmlGenericControl frågeruta = new HtmlGenericControl("div id=frågeruta");
                HtmlGenericControl frågenummer = new HtmlGenericControl("div id=frågenummer");
                HtmlGenericControl frågan = new HtmlGenericControl("div id=frågan");
                HtmlGenericControl kategori = new HtmlGenericControl("div id=kategori");

                frågenummer.InnerHtml = "<p id=rubrik> Fråga " + frågaNr++ + "</p>";
                frågan.InnerText = f.Frågan;
                kategori.InnerHtml = "<p id=txtkat> Kategori: " + f.Kategori + "</p>";

                frågeruta.Controls.Add(frågenummer);
                frågeruta.Controls.Add(kategori);
                frågeruta.Controls.Add(frågan);

                HtmlGenericControl bild = new HtmlGenericControl("img id=bild src=" + f.Bild);

                foreach (Svarsalternativ s in f.Svarsalternativslista) //Räknar antalet rätta svar i en fråga.
                {
                    if (s.RättSvar == "rätt")
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

                    if (räkna == 4)
                    {
                        svarId++;
                        räkna -= 4;
                    }
                    svarText.InnerText = s.Svaren;

                    if (x >= 2)
                    {
                        input.Value = s.RättSvar;
                        input.Name = "hej" + svarId;
                        input.ID = knappid.ToString();
                        räkna++;
                        knappid++;
                        svar.Controls.Add(input);
                        checkList.Add(input);
                    }

                    if (x == 1)
                    {
                        rdbtn.Value = s.RättSvar;
                        rdbtn.Name = "hej" + svarId;
                        rdbtn.ID = knappid.ToString();
                        räkna++;
                        knappid++;
                        svar.Controls.Add(rdbtn);
                        radioList.Add(rdbtn);
                        indexArr++;
                    }
                    svar.Controls.Add(svarText);
                    frågeruta.Controls.Add(svar);

                    if (f.Bild != null)
                    {
                        frågeruta.Controls.Add(bild);
                    }
                   
                    allafrågor.Controls.Add(frågeruta);
                }
            }
        }

        public List<Fråga> xmlToList(string sökvägXML)
        {
            List<Fråga> Testet = new List<Fråga>();
            string path = Server.MapPath(sökvägXML);
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNodeList allafrågor = doc.SelectNodes("/quiz/Frågor/*/fråga");

            foreach (XmlNode node in allafrågor)
            {
                Fråga f = new Fråga();
                f.Frågan = node["Frågan"].InnerText;
                f.Kategori = node.ParentNode.Name;
                
                XmlNode parent = node.ParentNode;
                XmlNode attribute = node.Attributes["test"];

                for (int i = 1; i < node.ChildNodes.Count; i++)
                {
                    Svarsalternativ s = new Svarsalternativ();
                    s.Svaren = node.ChildNodes[i].InnerText;

                    if (node.ChildNodes[i].Attributes["rätt"] != null)
                    {
                        s.RättSvar = "rätt";
                    }

                    else if (node.ChildNodes[i].Attributes["fel"] != null)
                    {
                        s.RättSvar = "fel";
                    }

                    try
                    {
                        f.Bild = node.FirstChild.Attributes["bild"].Value;
                    }
                    catch (Exception)
                    {

                    }

                    f.Svarsalternativslista.Add(s);
                }
                Testet.Add(f);
            }
            return Testet;
        }

        protected void btnRätta_Click(object sender, EventArgs e)
        {
            Rätta();
            btnFacit.Visible = true;
        }

        public void Rätta()
        {
            {
                int räkna = 0;

                foreach (HtmlInputRadioButton r in radioList)
                {
                    
                    if (r.Checked && r.Value=="rätt")
                    {
                        räkna++;
                    }

                    r.Disabled = true;
                }

                int antal = 0;
                foreach (HtmlInputCheckBox c in checkList)//Metod för att rätta frågor med 2 rätta svar där båda rätta svaren måste vara ifyllda.
                {
                    
                    if (c.Checked && c.Value == "rätt")
                    {
                        antal++;
                        if (antal > 1)
                        {
                            räkna++;
                        }
                        if (antal == 2)
                        {
                            antal--;
                            antal--;
                        }
                    }
                    c.Disabled = true;
                }
                ptagg.InnerText = räkna.ToString();

                //if (räkna <=11)
                //{
                //    pg.sättTidGodkänd(användare.Användarnamn);
                //}
                //if (räkna >= 10)
                //{
                //    pg.sättTidGjortTest(användare.Användarnamn);
                //}
            }
        }

        protected void btnFacit_Click(object sender, EventArgs e)
        {

        }
    }
}