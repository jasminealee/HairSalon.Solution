using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
    public class SpecialtiesControllerTest{
    public SpecialtiesControllerTest(){
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=jasmine_lee_test;";
    }

    [TestMethod]
    public void Index_ReturnsCorrectView_True(){
      SpecialtiesController controller = new SpecialtiesController();
      ActionResult indexView = controller.Index();
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void Index_HasCorrectModelType_SpecialtyList(){
      SpecialtiesController controller = new SpecialtiesController();
      ViewResult indexView = controller.Index() as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<SpecialtyClass>));
    }

    [TestMethod]
    public void New_ReturnsCorrectView_True(){
      SpecialtiesController controller = new SpecialtiesController();
      ActionResult newView = controller.New();
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }

    [TestMethod]
    public void Create_ReturnsCorrectActionType_RedirectToActionResult(){
      SpecialtiesController controller = new SpecialtiesController();
      IActionResult view = controller.Create("Mullet");
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Create_RedirectsToCorrectAction_Index(){
      SpecialtiesController controller = new SpecialtiesController();
      RedirectToActionResult actionResult = controller.Create("ducktail") as RedirectToActionResult;
      string result = actionResult.ActionName;
      Assert.AreEqual(result, "Index");
    }

    [TestMethod]
    public void Show_ReturnsCorrectView_True(){
      SpecialtiesController controller = new SpecialtiesController();
      ActionResult showView = controller.Show(1);
      Assert.IsInstanceOfType(showView, typeof(ViewResult));
    }

    [TestMethod]
    public void Show_HasCorrectModelType_Dictionary(){
      SpecialtiesController controller = new SpecialtiesController();
      ViewResult showView = controller.Show(1) as ViewResult;
      var result = showView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

    [TestMethod]
    public void AddStylist_ReturnsCorrectActionType_RedirectToActionResult(){
      SpecialtiesController controller = new SpecialtiesController();
      IActionResult view = controller.AddStylist(1, 1);
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void AddStylist_RedirectsToCorrectAction_Show(){
      SpecialtiesController controller = new SpecialtiesController();
      RedirectToActionResult actionResult = controller.AddStylist(1, 1) as RedirectToActionResult;
      string result = actionResult.ActionName;
      Assert.AreEqual(result, "Show");
    }
  }
}
