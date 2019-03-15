// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using HairSalon.Models;
// using System;
// using System.Collections.Generic;
//
// namespace HairSalon.Tests
// {
//   [TestClass]
//   public class SpecialtyTest : IDisposable
//   {
//     public void Dispose(){
//       Specialty.ClearAll();
//       Client.ClearAll();
//       Stylist.ClearAll();
//     }
//
//     public SpecialtyTest(){
//       DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=jasmine_lee_test;";
//     }
//
//     [TestMethod]
//     public void SpecialtyContstructor_CreatesInstanceOfSpecialty_Specialty(){
//       Specialty newSpecialty = new Specialty("Mullet");
//       Assert.AreEqual(typeof(Specialty), newSpecialty.GetType());
//     }
//
//     [TestMethod]
//     public void GetDescription_ReturnsDescription_String(){
//       string description = "Mullet";
//       Specialty newSpecialty = new Specialty("Mullet");
//       string result = newSpecialty.GetDescription();
//       Assert.AreEqual(description, result);
//     }
//
//     [TestMethod]
//     public void GetID_ReturnsID_Int(){
//       Specialty newSpecialty = new Specialty("Mullet", 5);
//       int result = newSpecialty.GetID();
//       Assert.AreEqual(5, result);
//     }
//
//
//     [TestMethod]
//     public void SetDescription_SetsDescription_String(){
//       Specialty specialty = new Specialty("Mullet");
//
//       string newDescription = "Short Bob";
//       specialty.SetDescription(newDescription);
//       string result = specialty.GetDescription();
//
//       Assert.AreEqual(newDescription, result);
//     }
//
//     [TestMethod]
//     public void AddStylist_AddsStylistToSpecialty_StylistList()
//     {
//       Specialty testSpecialty = new Specialty("Mullet");
//       testSpecialty.Save();
//       Stylist testStylist = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");
//       testStylist.Save();
//
//       testSpecialty.AddStylist(testStylist);
//       List<Stylist> result = testSpecialty.GetStylists();
//       List<Stylist> testList = new List<Stylist>{testStylist};
//
//       CollectionAssert.AreEqual(testList, result);
//     }
//
//     [TestMethod]
//     public void GetStylists_ReturnsAllStylistsWithSpecialty_StylistList()
//     {
//       Specialty testSpecialty = new Specialty("Mullet");
//       testSpecialty.Save();
//       Stylist testStylist1 = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");
//       testStylist1.Save();
//       Stylist testStylist2 = new Stylist("Kara", "Danvers", "395-302-9820", "karadanversATgmailDOTcom");
//       testStylist2.Save();
//
//       testSpecialty.AddStylist(testStylist1);
//       List<Stylist> result = testSpecialty.GetStylists();
//       List<Stylist> testList = new List<Stylist> {testStylist1};
//
//       CollectionAssert.AreEqual(testList, result);
//     }
//
//     [TestMethod]
//     public void GetAll_ReturnsSpecialties_SpecialtiesList()
//     {
//       Specialty newSpecialty = new Specialty("Mullet");
//       Specialty newSpecialty2 = new Specialty("Short Bob");
//       newSpecialty.Save();
//       newSpecialty2.Save();
//       List<Specialty> newList = new List<Specialty> { newSpecialty, newSpecialty2 };
//
//       List<Specialty> result = Specialty.GetAll();
//
//       CollectionAssert.AreEqual(newList, result);
//     }
//
//     [TestMethod]
//     public void Find_ReturnsCorrectSpecialtyFromDatabase_Specialty()
//     {
//       Specialty newSpecialty = new Specialty("Mullet");
//       newSpecialty.Save();
//
//       Specialty result = Specialty.Find(newSpecialty.GetID());
//
//       Assert.AreEqual(newSpecialty, result);
//     }
//   }
// }
