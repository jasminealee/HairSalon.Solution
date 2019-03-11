using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientControllerTest
    {
      [TestMethod]
      public void CreateClient_ReturnCorrectInfo_True()
      {
        //Arrange
        ClientController controller = new ClientController();
        //Act
         ActionResult newView = controller.CreateClient("Hippo", 0);

         //Assert
         Assert.IsInstanceOfType(newView, typeof(RedirectToActionResult));
      }

      [TestMethod]
      public void DeleteClient_ReturnsCorrectInfo_True()
      {
        //Arrange
        ClientController controller = new ClientController();
        //Act
         ActionResult newView = controller.Delete(0);

         //Assert
         Assert.IsInstanceOfType(newView, typeof(ViewResult));
      }

      [TestMethod]
      public void ShowClient_ReturnsCorrectInfo_True()
      {
        ClientControlloer controller = new ClientController();
        ActionResult newView = controller.Show(0);
        Assert.IsInstanceOfType(newView, typeof(viewResult));
      }

      [TestMethod]
      public void Search_ReturnsCorrectView_True()
      {
        //Arrange
            ClientController controller = new ClientController();

            //Act
            ActionResult newView = controller.Search("dog");

            //Assert
            Assert.IsInstanceOfType(newView, typeof(RedirectToActionResult));
      }
    }
}
