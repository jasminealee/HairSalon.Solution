// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using HairSalon.Models;
// using System;
// using System.Collections.Generic;
//
// namespace HairSalon.Tests
// {
//   [TestClass]
//   public class StylistTest : IDisposable
//   {
//     public void Dispose()
//     {
//       Stylist.ClearAll();
//       Client.ClearAll();
//     }
//
//     public StylistTest(){
//       DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=jasmine_lee_test;";
//     }
//
//     [TestMethod]
//     public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
//     {
//       StylistClass newStylist = new StylistClass("Winston", "0443", 55);
//       Assert.AreEqual(typeof(Stylist), newStylist.GetType());
//     }

    // [TestMethod]
    // public void GetName_ReturnsName_String()
    // {
    //   string name = "Jet";
    //   StylistClass newStylist = new StylistClass(name, "7545", 77);
    //   string result = newStylist.GetName();
    //   Assert.AreEqual(name, result);
    // }

    //
    // [TestMethod]
    // public void GetPhoneNumber_ReturnsPhoneNumber_String(){
    //   string phoneNumber = "607-499-0243";
    //   Stylist newStylist = new Stylist("Bob", "Foo", phoneNumber, "bobfooATgmailDOTcom");
    //   string result = newStylist.GetPhoneNumber();
    //   Assert.AreEqual(phoneNumber, result);
    // }
    //
    // [TestMethod]
    // public void GetEmail_ReturnsEmail_String(){
    //   string email = "bobfooATgmailDOTcom";
    //   Stylist newStylist = new Stylist("Bob", "Foo", "607-499-0243", email);
    //   string result = newStylist.GetEmail();
    //   Assert.AreEqual(email, result);
    // }
    //
    // [TestMethod]
    // public void GetClients_ReturnsEmptyList_ClientList()
    // {
    //   Stylist newStylist = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");
    //   List<Client> newList = new List<Client>();
    //
    //   List<Client> result = newStylist.GetClients();
    //
    //   CollectionAssert.AreEqual(newList, result);
    // }
    //
    // [TestMethod]
    // public void GetClients_ReturnsClients_ListClient(){
    //   Stylist newStylist = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");
    //   newStylist.Save();
    //   Client newClient = new Client("Kara", "Danvers", "603-682-9071", "karadanversATgmailDOTcom", newStylist.GetID());
    //   newClient.Save();
    //   List<Client> clientList = new List<Client> {newClient};
    //
    //   List<Client> result = newStylist.GetClients();
    //
    //   CollectionAssert.AreEqual(clientList, result);
    // }
    //
    // [TestMethod]
    // public void SetFirstName_SetsFirstName_String(){
    //   Stylist newStylist = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");
    //
    //   string newFirstName = "Kara";
    //   newStylist.SetFirstName(newFirstName);
    //   string result = newStylist.GetFirstName();
    //
    //   Assert.AreEqual(newFirstName, result);
    // }
    //
    // [TestMethod]
    // public void SetLastName_SetsLastName_String(){
    //   Stylist newStylist = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");
    //
    //   string newLastName = "Danvers";
    //   newStylist.SetLastName(newLastName);
    //   string result = newStylist.GetLastName();
    //
    //   Assert.AreEqual(newLastName, result);
    // }
    //
    // [TestMethod]
    // public void SetPhoneNumber_SetsPhoneNumber_String(){
    //   Stylist newStylist = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");
    //
    //   string newPhoneNumber = "390-275-3988";
    //   newStylist.SetPhoneNumber(newPhoneNumber);
    //   string result = newStylist.GetPhoneNumber();
    //
    //   Assert.AreEqual(newPhoneNumber, result);
    // }
    //
    // [TestMethod]
    // public void SetEmail_SetsEmail_String(){
    //   Stylist newStylist = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");
    //
    //   string newEmail = "bobfooATyahooDOTcom";
    //   newStylist.SetEmail(newEmail);
    //   string result = newStylist.GetEmail();
    //
    //   Assert.AreEqual(newEmail, result);
    // }
    //
    // // [TestMethod]
    // // public void AddClient_AddsClient_Client(){
    // //   Stylist newStylist = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");
    // //   Client newClient = new Client("Kara", "Danvers", "603-682-9071", "karadanversATgmailDOTcom", 3);
    // //   List<Client> clientList = new List<Client> {newClient};
    // //
    // //   newStylist.AddClient(newClient);
    // //   List<Client> result = newStylist.GetClients();
    // //
    // //   CollectionAssert.AreEqual(clientList, result);
    // // }
    //
    // [TestMethod]
    // public void GetAll_ReturnsEmptyList_StylistList()
    // {
    //   List<Stylist> result = Stylist.GetAll();
    //   List<Stylist> newList = new List<Stylist>();
    //   CollectionAssert.AreEqual(newList, result);
    // }
    //
    // [TestMethod]
    // public void GetAll_ReturnsStylists_StylistList()
    // {
    //   Stylist newStylist = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");
    //   Stylist newStylist2 = new Stylist("Kara", "Danvers", "603-682-9071", "karadanversATgmailDOTcom");
    //   newStylist.Save();
    //   newStylist2.Save();
    //   List<Stylist> newList = new List<Stylist> { newStylist, newStylist2 };
    //
    //   List<Stylist> result = Stylist.GetAll();
    //
    //   CollectionAssert.AreEqual(newList, result);
    // }
    //
    // [TestMethod]
    // public void Find_ReturnsCorrectStylistFromDatabase_Stylist()
    // {
    //   Stylist newStylist = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");
    //   newStylist.Save();
    //
    //   Stylist result = Stylist.Find(newStylist.GetId());
    //
    //   Assert.AreEqual(newStylist, result);
    // }
    //
    // [TestMethod]
    // public void Equals_ReturnsTrueIfStylistsAreSame_Stylist()
    // {
    //   Stylist newStylist = new Stylist("Kara", "Danvers", "603-682-9071", "karadanversATgmailDOTcom");
    //   Stylist newStylist2 = new Stylist("Kara", "Danvers", "603-682-9071", "karadanversATgmailDOTcom");
    //
    //   Assert.AreEqual(newStylist, newStylist2);
    // }
    //
    // [TestMethod]
    // public void Save_AssignsIDToStylist_ID()
    // {
    //   Stylist testStylist = new Stylist("Kara", "Danvers", "603-682-9071", "karadanversATgmailDOTcom");
    //
    //   testStylist.Save();
    //   Stylist savedStylist = Stylist.GetAll()[0];
    //   int result = savedStylist.GetID();
    //   int testID = testStylist.GetID();
    //
    //   Assert.AreEqual(testID, result);
    // }
    //
    // [TestMethod]
    // public void Delete_DeletesStylist_Stylist(){
    //   Stylist testStylist = new Stylist("Kara", "Danvers", "603-682-9071", "karadanversATgmailDOTcom");
    //   testStylist.Save();
    //   List<Stylist> emptyList = new List<Stylist>();
    //
    //   testStylist.Delete();
    //   List<Stylist> postDeleteStylists = Stylist.GetAll();
    //
    //   CollectionAssert.AreEqual(emptyList, postDeleteStylists);
    // }
    //
    // [TestMethod]
    // public void Edit_UpdatesStylistInDatabase_String()
    // {
    //   Stylist testStylist = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");
    //   testStylist.Save();
    //   string altFirstName = "Kara";
    //   string altLastName = "Danvers";
    //   string altPhoneNumber = "603-682-9071";
    //   string altEmail = "karadanversATgmailDOTcom";
    //   Stylist altStylist = new Stylist(altFirstName, altLastName, altPhoneNumber, altEmail, testStylist.GetID());
    //
    //   testStylist.Edit(altFirstName, altLastName, altPhoneNumber, altEmail);
    //
    //   Assert.AreEqual(testStylist, altStylist);
    // }
    //
    // [TestMethod]
    // public void GetSpecialties_ReturnsAllSpecialtiesWithStylist_SpecialtyList()
    // {
    //   Stylist testStylist = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");
    //   testStylist.Save();
    //   Specialty testSpecialty1 = new Specialty("Mullet");
    //   testSpecialty1.Save();
    //   Specialty testSpecialty2 = new Specialty("Short Bob");
    //   testSpecialty2.Save();
    //
    //   testStylist.AddSpecialty(testSpecialty2);
    //   List<Specialty> result = testStylist.GetSpecialties();
    //   List<Specialty> testList = new List<Specialty> {testSpecialty2};
    //
    //   CollectionAssert.AreEqual(testList, result);
    // }
    //
    // [TestMethod]
    // public void AddSpecialty_AddsSpecialtyToStylist_SpecialtyList()
    // {
    //   Stylist testStylist = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");
    //   testStylist.Save();
    //   Specialty testSpecialty = new Specialty("Mullet");
    //   testSpecialty.Save();
    //
    //   testStylist.AddSpecialty(testSpecialty);
    //   List<Specialty> result = testStylist.GetSpecialties();
    //   List<Specialty> testList = new List<Specialty>{testSpecialty};
    //
      // CollectionAssert.AreEqual(testList, result);
    // }
//   }
// }
