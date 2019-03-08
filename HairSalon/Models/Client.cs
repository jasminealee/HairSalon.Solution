using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
  public class ClientClass
  {
    private int _id;
    private string _name;
    private int _specialistid;

    public ClientClass (int id, string name, int specialistid)
    {
      _id = id;
      _name = name;
      _specialist_id = specialistid;
    }

    public ClientClass (string name, int specialistid)
    {
      _id = id;
      _specialistid = specialistid;
    }

    public int GetId()
    {
      return id;
    }

    public string GetName()
    {
      return name;
    }

    public int GetSpecialistId()
    {
      return specialist_id;
    }

    public static List<ClientClass> GetAll()
    {
      List<ClientClass> allClients = new List<ClientClass> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        int stylist_id = rdr.GetInt32(2);
        ClientClass newClient = new ClientClass(id, name, stylist_id);
        allClients.Add(newClient);

      }
      conn.Close();
      if (conn !=null)
      {
          conn.Dispose();
      }
      return allClients;
    }
    }
  }


}
