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

    public override bool Equals(System.Object otherStylist)
  {
    if (!(otherStylist is Stylist))
    {
      return false;
    }
    else
    {
      Stylist newStylist = (Stylist) otherStylist;
      return this.GetName().Equals(newStylist.GetName());
    }
  }

  public override int GetHashCode()
  {
    return this.GetName().GetHashCode();
  }
  public override bool Equals(System.Object otherItem)
      {
        if (!(otherItem is Item))
        {
          return false;
        }
        else
        {
          Item newItem = (Item) otherItem;
          bool descriptionEquality = (this.GetDescription() == newItem.GetDescription());
          return (descriptionEquality);
        }
      }
      public void Save()
         {
           MySqlConnection conn = DB.Connection();
           conn.Open();
           var cmd = conn.CreateCommand() as MySqlCommand;
           cmd.CommandText = @"INSERT INTO items (description) VALUES (@ItemDescription);";

           // more logic will go here in a moment

            conn.Close();
            if (conn != null)
            {
              conn.Dispose();
            }
         }


}
