using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class SpecialtyClass
    {
        private int _id;
        private string _specialty;

        public SpecialtyClass(string specialty, int id=0)
        {
            _specialty = specialty;
            _id = id;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetSpecialty()
        {
            return _specialty;
        }

        public static void Save(string specialty)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO specialty VALUES;";
            cmd.Parameters.AddWithValue("@Specialty" , specialty);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }


        public static List<Specialty> GetAll()
        {
            List<Specialty> allSpecialties = new List<Specialty> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialty;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                Specialty newSpeciaity = new Specialty(name, id);
                allSpecialty.Add(newSpecialty);

            }
            conn.Close();
            if (conn !=null)
            {
                conn.Dispose();
            }
            return allSpecialties;
        }

        public static void SaveSpecialtyStylist(int stylistId, int specialtyId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO specialties_stylists VALUES (@Stylist_id, @Specialty_id);";
            cmd.Parameters.AddWithValue(stylistId);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
      }


        public static void DeleteSpecialty(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM specialties WHERE id = " + id + ";";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
          }

    }
}
