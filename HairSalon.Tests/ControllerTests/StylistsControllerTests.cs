using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistsControllerTest
  {
    public StylistsControllerTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=jasmine_lee_test;";
    }

    [TestMethod]
    public void Create_ReturnsCorrectActionType_RedirectToActionResult(){
      StylistsController controller = new StylistsController();
      IActionResult view = controller.Create("Winston", "1433", 34);
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Create_RedirectsToCorrectAction_Index(){
      StylistsController controller = new StylistsController();
      RedirectToActionResult actionResult = controller.Create("Jim", "0768", 92 ) as RedirectToActionResult;
      string result = actionResult.ActionName;
      Assert.AreEqual(result, "Index");
    }

    [TestMethod]
    public void New_ReturnsCorrectView_True(){
      StylistsController controller = new StylistsController();
      ActionResult newView = controller.New();
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }

    [TestMethod]
    public void Index_ReturnsCorrectView_True(){
      StylistsController controller = new StylistsController();
      ActionResult indexView = controller.Index();
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void Index_HasCorrectModelType_StylistList(){
      StylistsController controller = new StylistsController();
      ViewResult indexView = controller.Index() as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<Stylist>));
    }

    [TestMethod]
    public void Delete_ReturnsCorrectView_True(){
      StylistsController controller = new StylistsController();
      ActionResult deleteView = controller.DeleteAll();
      Assert.IsInstanceOfType(deleteView, typeof(ViewResult));
    }

    [TestMethod]
    public void Show_ReturnsCorrectView_True(){
      StylistsController controller = new StylistsController();
      StylistClass stylist = new StylistClass("Mango", "2847", 62);
      ActionResult showView = controller.Show(1);
      Assert.IsInstanceOfType(showView, typeof(ViewResult));
    }

    [TestMethod]
    public void Show_HasCorrectModelType_Stylist(){
      StylistsController controller = new StylistsController();
      StylistClass stylist = new StylistClass("phil", "3513", 15);
      ViewResult showView = controller.Show(1) as ViewResult;
      var result = showView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

    [TestMethod]
    public void Create_ReturnsCorrectView_True(){
      StylistsController controller = new StylistsController();
      ActionResult createView = controller.Create(1, "dawn", "1521", 74);
      Assert.IsInstanceOfType(createView, typeof(ViewResult));
    }

    [TestMethod]
    public void Create_HasCorrectModelType_Dictionary(){
      StylistsController controller = new StylistsController();
      ViewResult createView = controller.Create(1, "sally", "9850", 48) as ViewResult;
      var result = createView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

    [TestMethod]
    public void Destroy_RedirectsToCorrectAction_Index(){
      StylistsController controller = new StylistsController();
      RedirectToActionResult actionResult = controller.Destroy(1) as RedirectToActionResult;
      string result = actionResult.ActionName;
      Assert.AreEqual(result, "Index");
    }

    [TestMethod]
    public void Destroy_ReturnsCorrectActionType_RedirectToActionResult(){
      StylistsController controller = new StylistsController();
      IActionResult view = controller.Destroy(1);
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Edit_ReturnsCorrectView_True(){
      StylistsController controller = new StylistsController();
      ActionResult showView = controller.Edit(1);
      Assert.IsInstanceOfType(showView, typeof(ViewResult));
    }

    [TestMethod]
    public void Edit_HasCorrectModelType_Stylist(){
      StylistsController controller = new StylistsController();
      ViewResult newView = controller.Edit(1) as ViewResult;
      var result = newView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(StylistClass));
    }

    [TestMethod]
    public void Update_ReturnsCorrectView_True(){
      StylistsController controller = new StylistsController();
      ActionResult showView = controller.Update(1, "jo", "0360", 88);
      Assert.IsInstanceOfType(showView, typeof(ViewResult));
    }

    [TestMethod]
    public void Update_HasCorrectModelType_Dictionary(){
      StylistsController controller = new StylistsController();
      ViewResult newView = controller.Update(1, "greta", "1193", 33, "blaATgmailDOTcom") as ViewResult;
      var result = newView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

    [TestMethod]
    public void Destroy_ReturnsCorrectView_True(){
      StylistsController controller = new StylistsController();
      ActionResult showView = controller.Destroy(1, 1);
      Assert.IsInstanceOfType(showView, typeof(ViewResult));
    }

    [TestMethod]
    public void Destroy_HasCorrectModelType_Dictionary(){
      StylistsController controller = new StylistsController();
      ViewResult newView = controller.Destroy(1, 1) as ViewResult;
      var result = newView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

    [TestMethod]
    public void AddSpecialty_ReturnsCorrectActionType_RedirectToActionResult(){
      StylistsController controller = new StylistsController();
      IActionResult view = controller.AddSpecialty(1, 1);
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void AddSpecialty_RedirectsToCorrectAction_Show(){
      StylistsController controller = new StylistsController();
      RedirectToActionResult actionResult = controller.AddSpecialty(1,1) as RedirectToActionResult;
      string result = actionResult.ActionName;
      Assert.AreEqual(result, "Show");
    }
  }
}
