using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JE_Bank
{
    public class Fråga
    {
        public string Fråga { get; set; }
        public List<Svar> Svarsalternativ { get; set; } 

        public Fråga()
        {
            Svarsalternativ = new List<Svar>();
        }
    }


}