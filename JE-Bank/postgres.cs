using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Configuration;

namespace JE_Bank
{
    public class postgres
    {

        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private NpgsqlDataReader dr;

        // Skapar koppling mot databas
        static void PgOpen()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;User Id=interaktiva_g26;Password=bankapp;Database=interaktiva_g26;SslMode=Require;");
            conn.Open();
        }

        static void PgClose()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;User Id=interaktiva_g26;Password=bankapp;Database=interaktiva_g26;SslMode=Require;");
            conn.Close();
        }

        public void TestSqlFråga()
        {
            PgOpen();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM användare");
            NpgsqlDataReader reader = cmd.ExecuteReader();


            PgClose();
        }



    }
}