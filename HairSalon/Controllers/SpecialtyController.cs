using Microsoft.AspNetCore.Mvc;
using WordCounter.Models;
using System.Collections.Generic;

namespace WordCounter.Controllers
{
  public class WordCounterController : Controller
  {
    [HttpGet("/wordcounter")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet("/wordcounter/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/wordcounter")]
    public ActionResult Action(string phrase, string word)
    {
      int counter = 0;
      RepeatCounter myRepeatCounter = new RepeatCounter(phrase, word, counter);
      myRepeatCounter.Count(phrase, word, counter);
      return RedirectToAction("Index", myRepeatCounter);
    }
  }
}
