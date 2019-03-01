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
      StylistClass.ClearAll();
      ClientClass.ClearAll();
    }


    public HairSalonTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8890;database=jasmine_lee_test;";
    }

    [TestMethod]
    public void GetStylistName_ReturnName_String()
    {
      //Arrange
      string getStylistName = "Sally";

      //Act
      string newName = getStylistName.GetName();

      //Assert
      Assert.AreEqual( newName, typeof(string));
    }
  }
}
