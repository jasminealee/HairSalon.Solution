using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class SpecialtyClass
  {
    private string _feature;
    private int _id;

    public SpecialtyClass(string feature, int id = 0)
    {
      _feature = feature;
      _id = id;
    }

    public string GetFeature()
    {
      return _feature;
    }

    public int GetId()
    {
      return _id;
    }

    public void SetFeature(string feature)
    {
      _feature = feature;
    }

    public void SetId(int id)
    {
      _id = id;
    }

    public void AddStylist(StylistClass newStylist)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists_specialties (stylist_Id, specialty_Id) VALUES (@stylistId, @specialtyId);";
      MySqlParameter stylist_Id = new MySqlParameter();
      stylist_Id.ParameterName = "@stylistId";
      stylist_Id.Value = newStylist.GetId();
      cmd.Parameters.Add(stylist_Id);
      MySqlParameter specialty_Id = new MySqlParameter();
      specialty_Id.ParameterName = "@specialtyId";
      specialty_Id.Value = _id;
      cmd.Parameters.Add(specialty_Id);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM specialties; DELETE FROM stylists_specialties;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if(conn!=null)
      {
        conn.Dispose();
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO specialties (feature) VALUES (@feature);";
      MySqlParameter feature = new MySqlParameter();
      feature.ParameterName = "@feature";
      feature.Value = _feature;
      cmd.Parameters.Add(feature);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<SpecialtyClass> GetAll()
    {
      List<SpecialtyClass> allSpecialties = new List<SpecialtyClass> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read()){
        int id = rdr.GetInt32(0);
        string feature = rdr.GetString(1);
        SpecialtyClass newSpecialty = new SpecialtyClass(feature, id);
        allSpecialties.Add(newSpecialty);
      }

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return allSpecialties;
    }

    public List<StylistClass> GetStylists()
    {
      List<StylistClass> allStylists = new List<StylistClass>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT stylists.* FROM stylists JOIN stylists_specialties ON (stylists.Id = stylists_specialties.stylist_Id) JOIN specialties ON (stylists_specialties.specialty_Id = specialties.Id) WHERE specialties.Id = (@specialtyId);";
      MySqlParameter specialtyId = new MySqlParameter();
      specialtyId.ParameterName = "@specialtyId";
      specialtyId.Value = this._id;
      cmd.Parameters.Add(specialtyId);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string phoneNumber = rdr.GetString(2);
        StylistClass newStylist = new StylistClass(name, phoneNumber, stylistId);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if(conn!=null)
      {
        conn.Dispose();
      }
      return allStylists;
    }

    public static SpecialtyClass Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties WHERE id = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int specialtyId = 0;
      string feature = "";
      while (rdr.Read())
      {
        specialtyId = rdr.GetInt32(0);
        feature = rdr.GetString(1);
      }
      SpecialtyClass foundSpecialty = new SpecialtyClass(feature, specialtyId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundSpecialty;
    }

    public override bool Equals(System.Object otherSpecialty)
    {
      if (!(otherSpecialty is SpecialtyClass))
      {
        return false;
      }
      else
      {
        SpecialtyClass newSpecialty = (SpecialtyClass) otherSpecialty;
        bool specialtyEquality = (this.GetFeature() == newSpecialty.GetFeature() && this.GetId() == newSpecialty.GetId ());
        return (specialtyEquality);
      }
    }
  }
}
