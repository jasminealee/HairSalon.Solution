using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
  public class Client
  {
    private string _name;
    private int _address;
    private int _phoneNumber;
    private string _email;
    private int _stylistId;


    public Client(string name, string address, string phoneNumber, string email, int stylistId)
    {
      _name = name;
      _address = address;
      _phoneNumber = phoneNumber;
      _email = email;
      _stylist_id = stylist_id;
    }

    public Client(string name, int stylist_id)
    {
      _name = name;
      _stylist_id = stylist_id;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetAddress()
    {
      return _address;
    }

    public string GetEmail()
    {
      return _email;
    }

    public int GetStylistId()
    {
      return _stylist_id;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (name, stylistId) VALUES (@ClientName , @ClientStylistId);";
      cmd.Parameters.AddWithValue("@ClientName" , this._name);
      cmd.Parameters.AddWithValue("@ClientStylistId" , this._stylistId);
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

    public static List<ClientClass> GetAll()
    {
      List<ClientClass> allClients = new List<ClientClass> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read()
      {
        string name = rdr.GetString(1);
        int address = rdr.GetInt32(2);
        int phoneNumber = rdr.GetInt(2);
        string email = rdr.GetString(1);
        int stylistId = rdr.GetInt32(2);
        Client newClient = new Client( name, address, phoneNumber, email, stylist_id);
        allClients.Add(newClient);

      }
      conn.Close();
      if (conn !=null)
      {
        conn.Dispose();
      }
      return allClients;
    }

    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool nameEquality = (this.GetName() == newClient.GetName());
        return (nameEquality);
      }
    }
}
  }
