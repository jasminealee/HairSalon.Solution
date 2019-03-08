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
  }
}
