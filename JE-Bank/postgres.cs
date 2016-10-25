using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Configuration;

namespace JE_Bank
{
    public class Postgres
    {

        //private NpgsqlConnection conn;
        //private NpgsqlCommand cmd;
        //private NpgsqlDataReader dr;
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;User Id=interaktiva_g26;Password=bankapp;Database=interaktiva_g26;SslMode=Require;");

        public string TestSqlFråga()
        {
            conn.Open();

            string fråga = "SELECT användarnamn FROM användare";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(fråga, conn);

            NpgsqlCommand cmd = new NpgsqlCommand(fråga);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            Users nyAnvändare = new Users();

            while (reader.Read())
                nyAnvändare = new Users()
                {
                    Användarnamn = reader["användarnamn"].ToString()
                };
            return nyAnvändare.Användarnamn;


            conn.Close();
        }



    }
}