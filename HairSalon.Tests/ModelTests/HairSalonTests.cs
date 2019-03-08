using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;
using System.IO;

namespace HairSalon.Tests
{
  [TestClass]
  public class HairSalonTest : IDisposable
  {

    public void Dispose()
    {
      ClientClass.ClearAll();
      SpecialistClass.ClearAll();
      StylistClass.ClearAll();
    }


    public HairSalonTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8890;database=jasmine_lee_test;";
    }

    [TestMethod]
    public void GetStylistName_ReturnName_String()
    {
      //Arrange
      ClientClass new Client = (Client);
      //Act
      var newName = hawaii.GetName();

      //Assert
      Assert.IsInstanceOfType(newName, typeof(string));
    }

    [TestMethod]
    //Arrange
      string description = "Walk the dog.";
      Item newItem = new Item(description);

      //Act
      string updatedDescription = "Do the dishes";
      newItem.SetDescription(updatedDescription);
      string result = newItem.GetDescription();

      //Assert
      Assert.AreEqual(updatedDescription, result);
    }


    [TestMethod]

  public void GetAll_ReturnsEmptyList_ItemList()
  {
    //Arrange
    List<Item> newList = new List<Item> { };

    //Act
    List<Item> result = Item.GetAll();

    //Assert
    CollectionAssert.AreEqual(newList, result);
  }
  
  [TestMethod]
  public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
  {
    // Arrange, Act
    Item firstItem = new Item("Mow the lawn");
    Item secondItem = new Item("Mow the lawn");

    // Assert
    Assert.AreEqual(firstItem, secondItem);
  }

  }

}
