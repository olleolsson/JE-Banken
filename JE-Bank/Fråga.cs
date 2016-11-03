using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JE_Bank
{
    public class Fråga
    {
        public string Frågan { get; set; }
        public string Kategori { get; set; }
        public string Bild { get; set; }
        public List<Svarsalternativ> Svarsalternativslista { get; set; } 

        public Fråga() //skapar nylista som innehåller svarsalternativ varje gång vi gör ett objekt av klassen fråga
        {
            Svarsalternativslista = new List<Svarsalternativ>();
        }
    }
}