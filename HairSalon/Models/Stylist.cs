using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;


namespace HairSalon.Models
{
  public class stylistClass
  {
    private int _id;
    private string _name;

    public StylistClass (int id, string name)
    {
      _id = id;
      _name = name;
    }
    public GetId()
    {
      return _id;
    }
    public GetName()
    {
      return _name;
    }

    public void SetId (newId)
    {
      _id = newId;
    }

    public static List<StylistClass> GetAll()
    {
      List<StylistClass> GetAll()
      {
        List<StylistClass> allListClass = new List<StylistClass> {};
        MySqlConneciton conn =DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM stylistClass;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while (rdr.Read())
        {
          int Id = rdr.GetInt32(0);
          string Description = rdr.GetString(1);
          Item
        }
      }
    }

}
