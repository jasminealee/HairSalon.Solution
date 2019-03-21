using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class ClientClass
  {
    private string _name;
    private string _phoneNumber;
    private int _stylistId;
    private int _id;

    public ClientClass(string name, string phoneNumber, int stylistId, int id=0)
    {
      _name = name;
      _phoneNumber = phoneNumber;
      _stylistId = stylistId;
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

    public int GetStylistId()
    {
      return _stylistId;
    }

    public void SetName(string name)
    {
      _name = name;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
      _phoneNumber = phoneNumber;
    }

    public void SetStylistId(int stylistId)
    {
      _stylistId = stylistId;
    }

    public void SetId(int id)
    {
      _id = id;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (name, phoneNumber, stylistId) VALUES (@name, @phoneNumber, @stylistId);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = @"name";
      name.Value = this._name;
      cmd.Parameters.Add(name);
      MySqlParameter phoneNumber = new MySqlParameter();
      phoneNumber.ParameterName = @"phoneNumber";
      phoneNumber.Value = this._phoneNumber;
      cmd.Parameters.Add(phoneNumber);
      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = @"stylistId";
      stylistId.Value = this._stylistId;
      cmd.Parameters.Add(stylistId);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<ClientClass> GetAll(){
      List<ClientClass> allClients = new List<ClientClass>();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read()){
        int clientId = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string phoneNumber = rdr.GetString(2);
        int stylistId = rdr.GetInt32(3);
        ClientClass newClient = new ClientClass(name, phoneNumber, stylistId, clientId);
        allClients.Add(newClient);
      }

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return allClients;
    }

    public void Edit(string newName, string newPhoneNumber){
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE clients SET name = @name, phoneNumber = @phoneNumber WHERE id = @searchId;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = _id;
      cmd.Parameters.Add(searchId);
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = newName;
      cmd.Parameters.Add(name);
      MySqlParameter phoneNumber = new MySqlParameter();
      phoneNumber.ParameterName = "@phoneNumber";
      phoneNumber.Value = newPhoneNumber;
      cmd.Parameters.Add(phoneNumber);
      cmd.ExecuteNonQuery();
      _name = newName;
      _phoneNumber = newPhoneNumber;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }


    public override bool Equals(System.Object otherClient){
      if (!(otherClient is ClientClass))
      {
        return false;
      }
      else
      {
        ClientClass newClient = (ClientClass) otherClient;
        bool clientEquality = (this.GetName() == newClient.GetName() && this.GetPhoneNumber() == newClient.GetPhoneNumber() && this.GetId() == newClient.GetId()  && this.GetStylistId() == newClient.GetStylistId());
        return (clientEquality);
      }
    }

    public static ClientClass Find(int id){
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE Id = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int clientId = 0;
      string name = "";
      string phoneNumber = "";
      int stylistId = 0;
      while (rdr.Read())
      {
        clientId = rdr.GetInt32(0);
        name = rdr.GetString(1);
        phoneNumber = rdr.GetString(2);
        stylistId = rdr.GetInt32(3);
      }
      ClientClass foundClient = new ClientClass(name, phoneNumber, stylistId, clientId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundClient;
    }

    public void Delete(){
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients WHERE Id = @selectId;";
      MySqlParameter selectId = new MySqlParameter();
      selectId.ParameterName = "@selectId";
      selectId.Value = this._id;
      cmd.Parameters.Add(selectId);
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
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
