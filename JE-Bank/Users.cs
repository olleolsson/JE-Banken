using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JE_Bank
{
    public class Users
    {
        public string Användarnamn { get; set; }
        public string Användartyp { get; set; }
        public bool Certifierad { get; set; }
        public DateTime Godkänd { get; set; }
    }
}