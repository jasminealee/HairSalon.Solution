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

    public void Save(){
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists (name, phoneNumber) VALUES (@name, @phoneNumber);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = this._name;
      cmd.Parameters.Add(name);
      MySqlParameter phoneNumber = new MySqlParameter();
      phoneNumber.ParameterName = "@phoneNumber";
      phoneNumber.Value = this._phoneNumber;
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
        int stylistId = rdr.GetInt32(2);
        string name = rdr.GetString(0);
        string phoneNumber = rdr.GetString(1);
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
        int clientId = rdr.GetInt32(3);
        string name = rdr.GetString(0);
        string phoneNumber = rdr.GetString(1);
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

    public void SetName(string name)
    {
      _name = name;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
      _phoneNumber = phoneNumber;
    }


    public void Edit(string newName, string newPhoneNumber){
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE stylists SET name = @name, phoneNumber = @phoneNumber WHERE id = @stylistId;";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = newName;
      cmd.Parameters.Add(name);
      MySqlParameter phoneNumber = new MySqlParameter();
      phoneNumber.ParameterName = "@phoneNumber";
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
      cmd.CommandText = @"SELECT * FROM stylists WHERE Id = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int stylistId = 0;
      string name = " ";
      string phoneNumber = " ";
      while (rdr.Read())
      {
        stylistId = rdr.GetInt32(2);
        name = rdr.GetString(0);
        phoneNumber = rdr.GetString(1);
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
  }
}
