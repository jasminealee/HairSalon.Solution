using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.TestsTools
{
  [TestClass]
  public class ClientTest : IDisposable
  {
    public void Dispose(){ ClientClass.ClearAll(); }

    public ClientTest(){
      DBConfiguration.ConnectionString = "server=localhost;user Id=root;password=root;port=8889;database=jasmine_lee_test;";
    }

    [TestMethod]
    public void GetName_ReturnsName_String(){
      string name = "Client2";
      ClientClass newClient = new ClientClass(name, "2", 2);
      string result = newClient.GetName();
      Assert.AreEqual(name, result);
    }
    //
    [TestMethod]
    public void GetStylistId_ReturnsStylistId_Int(){
      int stylistId = 9;
      ClientClass newClient = new ClientClass("Client9", "9", 9);
      int result = newClient.GetStylistId();
      Assert.AreEqual(stylistId, result);
    }

    [TestMethod]
    public void SetName_SetsName_String(){
      ClientClass newClient = new ClientClass("Client9", "9", 9);

      string newName = "Client7";
      newClient.SetName(newName);
      string result = newClient.GetName();

      Assert.AreEqual(newName, result);
    }

    [TestMethod]
    public void SetPhoneNumber_SetsPhoneNumber_String(){
      ClientClass newClient = new ClientClass("Client9", "9", 9);

      string newPhoneNumber = "8";
      newClient.SetPhoneNumber(newPhoneNumber);
      string result = newClient.GetPhoneNumber();

      Assert.AreEqual(newPhoneNumber, result);
    }

    [TestMethod]
    public void SetStylistId_SetsStylistId_Int(){
      ClientClass newClient = new ClientClass("Client9", "9", 9);

      int newStylistId = 7;
      newClient.SetStylistId(newStylistId);
      int result = newClient.GetStylistId();

      Assert.AreEqual(newStylistId, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ClientList(){
      List<ClientClass> newList = new List<ClientClass>();
      List<ClientClass> result = ClientClass.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Delete_DeleteClient_Client(){
      ClientClass testClient = new ClientClass("Client9", "9", 9);
      testClient.Save();
      List<ClientClass> emptyList = new List<ClientClass>();

      testClient.Delete();
      List<ClientClass> postDeleteClients = ClientClass.GetAll();

      CollectionAssert.AreEqual(emptyList, postDeleteClients);
    }
  }
}
