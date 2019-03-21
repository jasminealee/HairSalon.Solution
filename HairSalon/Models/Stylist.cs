using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class StylistClass
  {
    private string _name;
    private string _phoneNumber;
    private int _id;

    public StylistClass(string name, string phoneNumber, int id=0){
      _name = name;
      _phoneNumber = phoneNumber;
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetPhoneNumber()
    {
       return _phoneNumber;
    }

    public int GetId()
    {
      return _id;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public void SetPhoneNumber(string newPhoneNumber)
    {
      _phoneNumber = newPhoneNumber;
    }


    public void Save(){
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists (name, phoneNumber) VALUES (@name, @phoneNumber);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = _name;
      cmd.Parameters.Add(name);
      MySqlParameter phoneNumber = new MySqlParameter();
      phoneNumber.ParameterName = "@phoneNumber";
      phoneNumber.Value =_phoneNumber;
      cmd.Parameters.Add(phoneNumber);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<StylistClass> GetAll() {
      List<StylistClass> allStylists = new List<StylistClass>();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read()){
        int stylistId = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string phoneNumber = rdr.GetString(2);
        StylistClass newStylist = new StylistClass(name, phoneNumber, stylistId);
        allStylists.Add(newStylist);
      }

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return allStylists;
    }


    public void AddSpecialty(SpecialtyClass newSpecialty)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT into stylists_specialties(stylist_Id, specialty_Id) VALUES (@stylistId, @specialtyId);";
      MySqlParameter stylist_Id = new MySqlParameter();
      stylist_Id.ParameterName = "@stylistId";
      stylist_Id.Value = _id;
      cmd.Parameters.Add(stylist_Id);
      MySqlParameter specialty_Id = new MySqlParameter();
      specialty_Id.ParameterName = "@specialtyId";
      specialty_Id.Value = newSpecialty.GetId();
      cmd.Parameters.Add(specialty_Id);
      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<ClientClass> GetClients()
    {
      List<ClientClass> allStylistClients = new List<ClientClass>();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE stylistId = @stylistId;";
      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@stylistId";
      stylistId.Value = this._id;
      cmd.Parameters.Add(stylistId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string phoneNumber = rdr.GetString(2);
        ClientClass newClient = new ClientClass(name, phoneNumber, _id, clientId);
        allStylistClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylistClients;
    }

    public void Edit(string newName, string newPhoneNumber){
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE stylists SET name = @newName, phoneNumber = @newPhoneNumber WHERE id = @stylistId;";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@newName";
      name.Value = newName;
      cmd.Parameters.Add(name);
      MySqlParameter phoneNumber = new MySqlParameter();
      phoneNumber.ParameterName = "@newPhoneNumber";
      phoneNumber.Value = newPhoneNumber;
      cmd.Parameters.Add(phoneNumber);
      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@stylistId";
      stylistId.Value = _id;
      cmd.Parameters.Add(stylistId);
      cmd.ExecuteNonQuery();
      _name = newName;
      _phoneNumber = newPhoneNumber;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherStylist){
      if (!(otherStylist is StylistClass))
      {
        return false;
      }
      else
      {
        StylistClass newStylist = (StylistClass) otherStylist;
        bool stylistEquality = (this.GetName() == newStylist.GetName() &&  this.GetPhoneNumber() == newStylist.GetPhoneNumber() && this.GetId() == newStylist.GetId());
        return (stylistEquality);
      }
    }

    public static StylistClass Find(int id){
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists WHERE Id = (@thisId);";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int stylistId = 0;
      string name = "";
      string phoneNumber = "";
      while (rdr.Read())
      {
        stylistId = rdr.GetInt32(0);
        name = rdr.GetString(1);
        phoneNumber = rdr.GetString(2);
      }
      StylistClass foundStylist = new StylistClass(name, phoneNumber, stylistId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundStylist;
    }


    public void Delete(){
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists WHERE Id = @thisId; DELETE FROM clients WHERE stylistId = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = this._id;
      cmd.Parameters.Add(thisId);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static void ClearAll(){
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      ClientClass.ClearAll();
    }

    public List<SpecialtyClass> GetSpecialties()
    {
      List<SpecialtyClass> allSpecialties = new List<SpecialtyClass>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT specialties.* FROM specialties JOIN stylists_specialties ON (specialties.Id = stylists_specialties.specialty_Id) JOIN stylists ON (stylists_specialties.stylist_Id = stylists.Id) WHERE stylists.Id = (@specialtyId);";
      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@stylistId";
      stylistId.Value = this._id;
      cmd.Parameters.Add(stylistId);
      MySqlParameter specialtyId = new MySqlParameter();
      specialtyId.ParameterName = "@specialtyId";
      specialtyId.Value = this._id;
      cmd.Parameters.Add(specialtyId);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int specialty_Id = rdr.GetInt32(0);
        string feature = rdr.GetString(1);
        SpecialtyClass newSpecialty = new SpecialtyClass(feature, specialty_Id);
        allSpecialties.Add(newSpecialty);
      }
      conn.Close();
      if(conn!=null)
      {
        conn.Dispose();
      }
      return allSpecialties;
    }
  }
}
