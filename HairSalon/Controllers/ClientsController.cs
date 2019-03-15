using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    [HttpGet("/clients")]
    public ActionResult Index(){
      List<ClientClass> allClients = ClientClass.GetAll();
      return View(allClients);
    }

    [HttpPost("/clients/delete")]
    public ActionResult DeleteAll(){
      ClientClass.ClearAll();
      return RedirectToAction("Index");
    }

    [HttpGet("/stylists/{stylistID}/clients/{clientID}/edit")]
    public ActionResult Edit(int stylistId, int clientId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      StylistClass stylist = StylistClass.Find(stylistId);
      model.Add("stylist", stylist);
      ClientClass client = ClientClass.Find(clientId);
      model.Add("client", client);
      return View(model);
    }

    [HttpGet("/stylists/{stylistId}/clients/new")]
    public ActionResult New(int stylistId)
    {
      StylistClass stylist = StylistClass.Find(stylistId);
      return View(stylist);
    }

    [HttpPost("/stylists/{stylistID}/clients/{clientId}")]
    public ActionResult Update(int stylistId, int clientId, string name, string phoneNumber)
    {
      ClientClass client = ClientClass.Find(clientId);
      client.Edit(name, phoneNumber);
      Dictionary<string, object> model = new Dictionary<string, object>();
      StylistClass stylist = StylistClass.Find(stylistId);
      model.Add("stylist", stylist);
      model.Add("client", client);
      return View("Show", model);
    }

    [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
    public ActionResult Show(int stylistId, int clientId){
      ClientClass client = ClientClass.Find(clientId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      StylistClass stylist = StylistClass.Find(stylistId);
      model.Add("client", client);
      model.Add("stylist", stylist);
      return View(model);
    }
  }
}
