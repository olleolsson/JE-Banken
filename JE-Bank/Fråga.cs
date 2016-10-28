using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JE_Bank
{
    public class Fråga
    {
        public string Frågan { get; set; }
        public List<Svarsalternativ> Svarsalternativ { get; set; } 

        public Fråga()
        {
            Svarsalternativ = new List<Svarsalternativ>();
        }
    }


}