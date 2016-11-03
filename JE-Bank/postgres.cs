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

        NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["interaktiva_g26"].ConnectionString);


        public string AnvändarTyp(string anvandare)//fråga till databasen för att se om användare är certifierad.
        {
            conn.Open();

            string fråga = "SELECT certifierad FROM användare WHERE användarnamn = @anvandare";
            
            NpgsqlCommand cmd = new NpgsqlCommand(fråga, conn);
            cmd.Parameters.AddWithValue("anvandare", anvandare);

            NpgsqlDataReader reader = cmd.ExecuteReader();
            Users nyAnvändare = new Users();

            while (reader.Read())
            {
                nyAnvändare = new Users()
                {
                    Certifierad = Convert.ToBoolean(reader["certifierad"])
                };
            }
            reader.Close();
            conn.Close();
            return nyAnvändare.Certifierad.ToString();
        }

        public void sättTidGodkänd(string anvandare)//Fråga för att sätta datum för avklarat test
        {
            conn.Open();

            string fråga = "UPDATE resultat SET godkänd = CURRENT_TIMESTAMP, datum_utförd = null WHERE användare = @anvandare";

            NpgsqlCommand cmd = new NpgsqlCommand(fråga, conn);
            cmd.Parameters.AddWithValue("anvandare", anvandare);
            conn.Close();
        }

        public void sättTidGjortTest(string anvandare)//Fråga för att sätta datum för rättat test
        {
            conn.Open();

            string fråga = "UPDATE resultat SET datum_utförd = CURRENT_TIMESTAMP WHERE användare = @anvandare";
            NpgsqlCommand cmd = new NpgsqlCommand(fråga, conn);
            cmd.Parameters.AddWithValue("anvandare", anvandare);
            conn.Close();
        }

        public DateTime hämtaDatumGodkänd(string anvandare)
        {
            conn.Open();
            string fråga = "SELECT godkänd FROM resultat WHERE godkänd < current_timestamp AND användare = @anvandare";

            NpgsqlCommand cmd = new NpgsqlCommand(fråga, conn);
            cmd.Parameters.AddWithValue("anvandare", anvandare);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            Users nyAnvändare = new Users();

            while (reader.Read())
            {
                nyAnvändare = new Users()
                {
                    Godkänd = Convert.ToDateTime(reader["godkänd"])
                };
            }
            reader.Close();
            conn.Close();
            return nyAnvändare.Godkänd;
        }

        public DateTime hämtaDatumGjortTest(string anvandare)
        {
            conn.Open();

            string fråga = "SELECT datum_utförd FROM resultat WHERE användare = @anvandare";

            NpgsqlCommand cmd = new NpgsqlCommand(fråga, conn);
            cmd.Parameters.AddWithValue("anvandare", anvandare);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            Users nyAnvändare = new Users();

            while (reader.Read())
            {               
                    nyAnvändare = new Users()
                    {
                        Utförd = Convert.ToDateTime(reader["datum_utförd"])
                    };                               
            }
            reader.Close();
            conn.Close();
            return nyAnvändare.Utförd;
        }
    }
}