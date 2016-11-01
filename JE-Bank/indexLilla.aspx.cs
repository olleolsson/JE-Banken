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
        protected void Page_Load(object sender, EventArgs e)
        {
            xmlToListLilla();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            //foreach (Fråga f in xmlToListLilla())
            //{
            //    foreach (Svarsalternativ s in f.Svarsalternativslista)
            //    {
            //        foreach (Control c in form1.FindControl("allafrågor").Controls)
            //        {
            //            foreach (Control v in form1.FindControl("frågeruta").Controls)
            //            {
            //                foreach (Control b in form1.FindControl("svarsalternativ").Controls)
            //                {
            //                    RadioButton radio = b as RadioButton;
            //                    if (radio is RadioButton)
            //                    {
            //                        radio.Text = s.Svaren;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            foreach (Fråga f in xmlToListLilla())
            {
                foreach (Svarsalternativ s in f.Svarsalternativslista)
                {
                    foreach (Control c in form1.Controls)
                    {
                        foreach (Control childc in c.Controls)
                        {
                            foreach (Control childd in childc.Controls)
                            {
                               
                                    RadioButton radio = childd as RadioButton;
                                    if (radio is RadioButton)
                                    {
                                        radio.Text = s.Svaren;
                                    }
                                

                            }

                        }
                    }
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
 
    }
}