using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    [HttpGet("/stylists")]
    public ActionResult Index() {
      List<StylistClass> allStylists = StylistClass.GetAll();
      return View(allStylists);
    }

    [HttpPost("/stylists/delete")]
    public ActionResult DeleteAll()
    {
      StylistClass.ClearAll();
      return View();
    }

    [HttpPost("stylists/{stylistId}/delete")]
    public ActionResult Destroy(int stylistId){
      StylistClass.Find(stylistId).Delete();
      return RedirectToAction("Index");
    }

    [HttpPost("/stylists/{stylistId}/clients/{clientId}/delete")]
    public ActionResult Destroy(int stylistId, int clientId){
      ClientClass.Find(clientId).Delete();
      StylistClass foundStylist = StylistClass.Find(stylistId);
      List<ClientClass> stylistClients = foundStylist.GetClients();
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("stylist", foundStylist);
      model.Add("clients", stylistClients);
      return RedirectToAction("Show", new{id =stylistId});
    }

    [HttpGet("/stylists/new")]
    public ActionResult New() { return View(); }

    [HttpPost("/stylists")]
    public ActionResult Create(string name, string phoneNumber){
      StylistClass stylist = new StylistClass(name, phoneNumber);
      stylist.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      StylistClass foundStylist = StylistClass.Find(id);
      List<ClientClass> stylistClients = foundStylist.GetClients();
      List<SpecialtyClass> allSpecialties = SpecialtyClass.GetAll();
      List<SpecialtyClass> stylistSpecialties = foundStylist.GetSpecialties();
      model.Add("stylist", foundStylist);
      model.Add("clients", stylistClients);
      model.Add("specialties", allSpecialties);
      model.Add("stylistSpecialties", stylistSpecialties);
      return View("Show", model);
    }

    [HttpPost("/stylists/{stylistId}/clients")]
    public ActionResult Create(int stylistId, string name, string phoneNumber)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      StylistClass foundStylist = StylistClass.Find(stylistId);
      ClientClass newClient = new ClientClass(name, phoneNumber, stylistId);
      newClient.Save();
      List<ClientClass> stylistClients = foundStylist.GetClients();
      List<SpecialtyClass> stylistSpecialties = SpecialtyClass.GetAll();
      model.Add("stylist", foundStylist);
      model.Add("clients", stylistClients);
      model.Add("specialties", stylistSpecialties);
      return RedirectToAction("Show", new{id = stylistId});
    }

    [HttpGet("stylists/{stylistId}/edit")]
    public ActionResult Edit(int stylistId, int specialtyId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      StylistClass stylist = StylistClass.Find(stylistId);
      StylistClass specialty = StylistClass.Find(specialtyId);
      model.Add("specialty", specialty);
      model.Add("stylist", stylist);
      return View(model);
    }

    [HttpPost("/stylists/{stylistId}")]
    public ActionResult Update(int stylistId, string newName, string newPhoneNumber)
    {
      StylistClass stylist = StylistClass.Find(stylistId);
      stylist.Edit(newName, newPhoneNumber);
      Dictionary<string, object> model = new Dictionary<string, object>();
      List<ClientClass> stylistClients = stylist.GetClients();
      List<SpecialtyClass> stylistSpecialties = stylist.GetSpecialties();
      model.Add("stylist", stylist);
      model.Add("clients", stylistClients);
      model.Add("specialties", stylistSpecialties);
      return RedirectToAction("Show", new{id =stylistId});
    }

    [HttpPost("/stylists/{stylistId}/specialties/new")]
    public ActionResult AddSpecialty(int specialtyId, int stylistId)
    {
      //Dictionary<string, object> model = new Dictionary<string, object>();
      StylistClass foundStylist = StylistClass.Find(stylistId);
      // List<SpecialtyClass> allSpecialties = SpecialtyClass.GetAll();
      List<SpecialtyClass> stylistSpecialties = foundStylist.GetSpecialties();
      SpecialtyClass specialtyStylist = SpecialtyClass.Find(specialtyId);
      foundStylist.AddSpecialty(specialtyStylist);
      // model.Add("specialtyStylist", specialtyStylist);
      // model.Add("stylist", foundStylist);
      //model.Add("specialties", stylistSpecialties);
      return RedirectToAction("Show", new { id = stylistId });


    }
  }
}
