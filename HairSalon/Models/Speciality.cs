using System;
using System.Collections.Generic;


namespace HairSalon.Models
{
  public class stylistClass
  {
    private int _id;
    private string _specialty;

    public StylistClass(int id, string specialty)
    {
      _id = id;
      _specialty = specialty;
    }

    public GetId()
    {
      return id;
    }

    public GetSpecialty()
    {
      return specialty;
    }

    public static Void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM specialty;";
      cmd.ExecuteNonQuery();
      conn..Close();
      if (conn != null)
      {
        conn.Dispose();
      }

    }


}
