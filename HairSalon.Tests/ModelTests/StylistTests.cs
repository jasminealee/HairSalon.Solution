using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest : IDisposable
  {
    public void Dispose()
    {
      StylistClass.ClearAll();
      ClientClass.ClearAll();
    }

    public StylistTest(){
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=jasmine_lee_test;";
    }

    [TestMethod]
    public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
    {
      StylistClass newStylist = new StylistClass("Stylist1", "1", 1);
      Assert.AreEqual(typeof(StylistClass), newStylist.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      string name = "Name1";
      StylistClass newStylist = new StylistClass(name, "1", 1);
      string result = newStylist.GetName();
      Assert.AreEqual(name, result);
    }


    [TestMethod]
    public void GetPhoneNumber_ReturnsPhoneNumber_String(){
      string phoneNumber = "1";
      StylistClass newStylist = new StylistClass("Stylist9", "1", 9);
      string result = newStylist.GetPhoneNumber();
      Assert.AreEqual(phoneNumber, result);
    }


    [TestMethod]
    public void GetClients_ReturnsEmptyList_ClientList()
    {
      StylistClass newStylist = new StylistClass("Stylist9", "9", 9);
      List<ClientClass> newList = new List<ClientClass>();

      List<ClientClass> result = newStylist.GetClients();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void SetPhoneNumber_SetsPhoneNumber_String(){
      StylistClass newStylist = new StylistClass("Stylist9", "9", 9);

      string newPhoneNumber = "9";
      newStylist.SetPhoneNumber(newPhoneNumber);
      string result = newStylist.GetPhoneNumber();

      Assert.AreEqual(newPhoneNumber, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_StylistList()
    {
      List<StylistClass> result = StylistClass.GetAll();
      List<StylistClass> newList = new List<StylistClass>();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfStylistsAreSame_Stylist()
    {
      StylistClass newStylist = new StylistClass("Stylist9", "9", 9);
      StylistClass newStylist2 = new StylistClass("Stylist9", "9", 9);

      Assert.AreEqual(newStylist, newStylist2);
    }
  }
}
