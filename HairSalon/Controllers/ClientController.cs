using Microsoft.AspNetCore.Mvc;
using WordCounter.Models;
using System.Collections.Generic;

namespace Client.Controllers
{
  public class ClientController : Controller
  {
    [HttpGet("/client")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet("/client/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/client")]
    public ActionResult Action(string phrase, string word)
    {
      int counter = 0;
      RepeatCounter myRepeatCounter = new RepeatCounter(phrase, word, counter);
      myRepeatCounter.Count(phrase, word, counter);
      return RedirectToAction("Index", myRepeatCounter);
    }
    [HttpPost("/categories/{categoryId}/items")]
    public ActionResult Create(int categoryId, string itemDescription)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category foundCategory = Category.Find(categoryId);
      Item newItem = new Item(itemDescription);
      newItem.Save();    // <--- This line is new!
      foundCategory.AddItem(newItem);
      List<Item> categoryItems = foundCategory.GetItems();
      model.Add("items", categoryItems);
      model.Add("category", foundCategory);
      return View("Show", model);
    }
    [TestMethod]
  public void Save_AssignsIdToObject_Id()
  {
    //Arrange
    Item testItem = new Item("Mow the lawn");

    //Act
    testItem.Save();
    Item savedItem = Item.GetAll()[0];

    int result = savedItem.GetId();
    int testId = testItem.GetId();

    //Assert
    Assert.AreEqual(testId, result);
  }

  }
}
