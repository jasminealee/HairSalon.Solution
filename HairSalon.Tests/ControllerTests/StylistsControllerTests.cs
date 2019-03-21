using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistsControllerTests
  {
    [TestMethod]
    public void StylistsControllerTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=jasmine_lee_test;";
    }

    [TestMethod]
    public void Show_ReturnsCorrectView_True(){
      StylistsController controller = new StylistsController();
      StylistClass stylist = new StylistClass("Stylist1", "1", 1);
      ActionResult showView = controller.Show(1);
      Assert.IsInstanceOfType(showView, typeof(ViewResult));
    }

    [TestMethod]
    public void Show_HasCorrectModelType_Stylist(){
      StylistsController controller = new StylistsController();
      StylistClass stylist = new StylistClass("Stylist1", "1", 1);
      ViewResult showView = controller.Show(1) as ViewResult;
      var result = showView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }
  }
}
