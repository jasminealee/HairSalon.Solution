using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientsControllerTests
  {
    [TestMethod]
    public void ClientsControllerTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=jasmine_lee_test;";
    }

    [TestMethod]
    public void Show_ReturnsCorrectView_True()
    {
      ClientsController controller = new ClientsController();
      StylistClass stylist = new StylistClass("Stylist1", "1", 1);
      ClientClass client = new ClientClass("Client1", "111", 1, 1);
      ActionResult showView = controller.Show(1, 1);
      Assert.IsInstanceOfType(showView, typeof(ViewResult));
    }

    [TestMethod]
    public void Show_CorrectModelType_Dictionary()
    {
      ClientsController controller = new ClientsController();
      StylistClass stylist = new StylistClass("Stylist1", "1", 1);
      ClientClass client = new ClientClass("Client1", "111", 1, 1);
      ViewResult showView = controller.Show(1,1) as ViewResult;
      var result = showView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

    [TestMethod]
    public void New_ReturnsCorrectView_True()
    {
      ClientsController controller = new ClientsController();
      StylistClass stylist = new StylistClass("Stylist1", "1", 1);
      ActionResult newView = controller.New(1);
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }

    [TestMethod]
    public void New_CorrectModelType_Stylist(){
      ClientsController controller = new ClientsController();
      StylistClass stylist = new StylistClass("Stylist", "1", 1);
      ViewResult newView = controller.New(1) as ViewResult;
      var result = newView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(StylistClass));
    }

    [TestMethod]
    public void Edit_ReturnsCorrectView_True(){
      ClientsController controller = new ClientsController();
      StylistClass stylist = new StylistClass("Stylist1", "1", 1);
      ClientClass client = new ClientClass("Client1", "1", 1, 1);
      ActionResult showView = controller.Edit(1, 1);
      Assert.IsInstanceOfType(showView, typeof(ViewResult));
    }

    [TestMethod]
    public void Edit_HasCorrectModelType_Dictionary(){
      ClientsController controller = new ClientsController();
      StylistClass stylist = new StylistClass("Stylist", "1", 1);
      ClientClass client = new ClientClass("Client1", "1", 1, 1);
      ViewResult newView = controller.Edit(1, 1) as ViewResult;
      var result = newView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

    [TestMethod]
    public void Index_ReturnsCorrectView_True(){
      ClientsController controller = new ClientsController();
      ActionResult indexView = controller.Index();
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void Index_HasCorrectModelType_ClientList(){
      ClientsController controller = new ClientsController();
      ViewResult indexView = controller.Index() as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<ClientClass>));
    }

    public void DeleteAll_ReturnsCorrectActionType_RedirectToActionResult(){
      ClientsController controller = new ClientsController();
      IActionResult view = controller.DeleteAll();
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void DeleteAll_RedirectsToCorrectAction_Index()
    {
      ClientsController controller = new ClientsController();
      RedirectToActionResult actionResult = controller.DeleteAll() as RedirectToActionResult;
      string result = actionResult.ActionName;
      Assert.AreEqual(result, "Index");
    }

  }
}
