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

        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private NpgsqlDataReader dr;

        public Postgres()
        {
            conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["interaktiva_g26"].ConnectionString);
            conn.Open();
        }


        private void sqlNonQuery(string fråga) // Ger möjlighet att ställa frågor mot databas
        {
            try
            {
                cmd = new NpgsqlCommand(fråga, conn);
                cmd.ExecuteNonQuery();
            }

            catch 
            {
                
            }
        }

        private NpgsqlDataReader sqlFråga(string fråga) // Skickar in fråga och retunerar från databas
        {
            try
            {
                cmd = new NpgsqlCommand(fråga, conn);
                dr = cmd.ExecuteReader();

                return dr;
            }

            catch 
            {              
                return null;
            }
        }


        public string TestSqlFråga()
        {
            conn.Open();
            
            string fråga = "SELECT användarnamn FROM användare";

            NpgsqlCommand cmd = new NpgsqlCommand(fråga, conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            Users nyAnvändare = new Users();

            while (reader.Read())
                nyAnvändare = new Users()
                {
                    Användarnamn = reader["användarnamn"].ToString()
                };
                reader.Close();

                conn.Close();               
            return nyAnvändare.Användarnamn;
        }
    }
}