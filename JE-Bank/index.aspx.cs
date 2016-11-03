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
        public Dictionary<string, string> facit = new Dictionary<string, string>();
        Postgres pg = new Postgres();
        Users användare = new Users();
        string sökvägXML;

        protected void Page_Load(object sender, EventArgs e)
        {      
            btnFacit.Visible = false;
            Postgres pg = new Postgres();
            användare.Användarnamn = Server.UrlDecode(Request.QueryString["Parameter"].ToString());
            användare.Certifierad = Convert.ToBoolean(pg.AnvändarTyp(användare.Användarnamn));

            if (användare.Certifierad == true)
            {
                sökvägXML = "lillaTestet.xml";
                AppendProv(xmlToList(sökvägXML));
            }

            if (användare.Certifierad == false)
            {
                sökvägXML = "storaTestet.xml";
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

                        if (s.RättSvar == "rätt")
                        {
                            facit.Add(s.Svaren, f.Frågan);
                    }

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

                        if (s.RättSvar == "rätt")

	                    {
                            facit.Add(s.Svaren, f.Frågan);
	                    }
                                            
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
                Fråga k = new Fråga();
                int antalrätt = 0;
                int antalValdaSvarsalternativ = 0;
                int antalfrågor = 0;
                int antalrättetik = 0;
                int antalrättekonomi = 0;
                int antalrättprodukter = 0;
                int antalfrågoretik = 0;
                int antalfrågorekonomi = 0;
                int antalfrågorprodukter = 0;

                //foreach (HtmlInputRadioButton r in radioList)
                //{
                    
                //    if (r.Checked && r.Value=="rätt")
                //    {
                //        antalrätt++;
                //    }                   

                //    r.Disabled = true;
                //}

                

                foreach (Fråga f in xmlToList(sökvägXML))//räknar antalet frågor för att vi ska kunna veta hur mkt 70% är när vi rättar.
                {
                    antalfrågor++;
                }

                foreach (Fråga f in xmlToList(sökvägXML))
                {
                    if (f.Kategori =="Etik")
                    {
                        antalfrågoretik++;
                        foreach (HtmlInputRadioButton r in radioList)
                        {

                            if (r.Checked && r.Value == "rätt")
                            {
                                antalrätt++;
                                antalrättetik++;
                            }

                            r.Disabled = true;
                        }

                        foreach (HtmlInputCheckBox c in checkList)//Metod för att rätta frågor med 2 rätta svar där båda rätta svaren måste vara ifyllda.
                        {
                            if (c.Checked)//Ifsats för att man inte ska kunna få rätt ifall man fyller i alla alternativ.
                            {
                                if (c.Value == "rätt")
                                {
                                    antalValdaSvarsalternativ++;
                                }

                                if (c.Value == "fel")
                                {
                                    antalValdaSvarsalternativ--;
                                }
                            }

                            if (antalValdaSvarsalternativ == 2)
                            {
                                antalrätt++;
                                antalrättetik++;
                            }
                            c.Disabled = true;
                        }
                    }

                    if (f.Kategori =="Ekonomi")
                    {
                        antalfrågorekonomi++;
                        foreach (HtmlInputRadioButton r in radioList)
                        {

                            if (r.Checked && r.Value == "rätt")
                            {
                                antalrätt++;
                                antalrättekonomi++;
                            }

                            r.Disabled = true;
                        }

                        foreach (HtmlInputCheckBox c in checkList)//Metod för att rätta frågor med 2 rätta svar där båda rätta svaren måste vara ifyllda.
                        {
                            if (c.Checked)//Ifsats för att man inte ska kunna få rätt ifall man fyller i alla alternativ.
                            {
                                if (c.Value == "rätt")
                                {
                                    antalValdaSvarsalternativ++;
                                }

                                if (c.Value == "fel")
                                {
                                    antalValdaSvarsalternativ--;
                                }
                            }

                            if (antalValdaSvarsalternativ == 2)
                            {
                                antalrätt++;
                                antalrättekonomi++;
                            }
                            c.Disabled = true;
                        }
                    }

                    if (f.Kategori == "Produkter")
                    {
                        antalfrågorprodukter++;
                        foreach (HtmlInputRadioButton r in radioList)
                        {

                            if (r.Checked && r.Value == "rätt")
                            {
                                antalrätt++;
                                antalrättprodukter++;
                            }

                            r.Disabled = true;
                        }

                        foreach (HtmlInputCheckBox c in checkList)//Metod för att rätta frågor med 2 rätta svar där båda rätta svaren måste vara ifyllda.
                        {
                            if (c.Checked)//Ifsats för att man inte ska kunna få rätt ifall man fyller i alla alternativ.
                            {
                                if (c.Value == "rätt")
                                {
                                    antalValdaSvarsalternativ++;
                                }

                                if (c.Value == "fel")
                                {
                                    antalValdaSvarsalternativ--;
                                }
                            }

                            if (antalValdaSvarsalternativ == 2)
                            {
                                antalrätt++;
                                antalrättprodukter++;
                            }
                            c.Disabled = true;
                        }
                    }
                }

                //foreach (HtmlInputCheckBox c in checkList)//Metod för att rätta frågor med 2 rätta svar där båda rätta svaren måste vara ifyllda.
                //{
                //    if (c.Checked)//Ifsats för att man inte ska kunna få rätt ifall man fyller i alla alternativ.
                //    {
                //        if (c.Value == "rätt")
                //        {
                //            antalValdaSvarsalternativ++;
                //        }

                //        if (c.Value == "fel")
                //        {
                //            antalValdaSvarsalternativ--;
                //        }
                //    }

                //    if (antalValdaSvarsalternativ == 2)
                //    {
                //        antalrätt++;
                //    }
                //    c.Disabled = true;
                //}
                ptagg.InnerText = antalrätt.ToString();


                //if (antalrätt > (antalfrågor * 0.7) && antalrättetik > (antalfrågoretik * 0.6) && antalrättekonomi > (antalfrågorekonomi * 0.6) && antalrättprodukter > (antalfrågorprodukter * 0.6))
                //{
                //    pg.sättTidGodkänd(användare.Användarnamn);
                //    pg.sättTidGjortTest(användare.Användarnamn);
                //}
                //if (antalrätt < (antalfrågor * 0.7) || antalrättetik < (antalfrågoretik * 0.6) || antalrättekonomi < (antalfrågorekonomi * 0.6) || antalrättprodukter < (antalfrågorprodukter * 0.6))
                //{
                //    pg.sättTidGjortTest(användare.Användarnamn);
                //}
            }
                }
        
        protected void btnFacit_Click(object sender, EventArgs e)       
        {
            //Response.Redirect("~/facit.aspx?Parameter=" + Server.UrlEncode(användare.Användarnamn));

            HtmlGenericControl diven = new HtmlGenericControl("div");


            foreach (KeyValuePair<string, string> entry in facit)
            {
                diven = new HtmlGenericControl("div");
                diven.InnerText = entry.Value + " " + entry.Key;
                ptagg.Controls.Add(diven);


            }
        }
    }
}