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
         [TestMethod]
public void Edit_UpdatesItemInDatabase_String()
{
  //Arrange
  string firstDescription = "Walk the Dog";
  Item testItem = new Item(firstDescription);
  testItem.Save();
  string secondDescription = "Mow the lawn";

  //Act
  testItem.Edit(secondDescription);
  string result = Item.Find(testItem.GetId()).GetDescription();

  //Assert
  Assert.AreEqual(secondDescription, result);
}

public void Edit(string newDescription)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE items SET description = @newDescription WHERE id = @searchId;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = _id;
      cmd.Parameters.Add(searchId);
      MySqlParameter description = new MySqlParameter();
      description.ParameterName = "@newDescription";
      description.Value = newDescription;
      cmd.Parameters.Add(description);
      cmd.ExecuteNonQuery();

      // More logic will go here.

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

}
