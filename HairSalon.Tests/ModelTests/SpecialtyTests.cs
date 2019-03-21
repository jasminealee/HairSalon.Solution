using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTest : IDisposable
  {
    public void Dispose(){
      SpecialtyClass.ClearAll();
      ClientClass.ClearAll();
      StylistClass.ClearAll();
    }

    public SpecialtyTest(){
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=jasmine_lee_test;";
    }

    [TestMethod]
    public void SpecialtyContstructor_CreatesInstanceOfSpecialty_Specialty(){
      SpecialtyClass newSpecialty = new SpecialtyClass("Ducktail");
      Assert.AreEqual(typeof(SpecialtyClass), newSpecialty.GetType());
    }
  }
}
