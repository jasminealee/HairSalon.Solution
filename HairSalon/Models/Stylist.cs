using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
  public class StylistClass
  {
      private int _id;
      public string _name;

      public StylistClass(string name)
      {
          _name = name;
      }

      public StylistClass(int id, string name)
      {
          _id = id;
          _name = name;
      }

      public string GetName()
      {
          return _name;
      }

      public int GetId()
      {
          return _id;
      }

      public static void ClearAll()
      {
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
    }
  }
}
