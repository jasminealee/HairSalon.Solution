using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class SpecialtiesController : Controller
  {
    [HttpGet("/specialties")]
    public ActionResult Index() {
      List<SpecialtyClass> allSpecialties = SpecialtyClass.GetAll();
      return View(allSpecialties);
    }

    [HttpGet("/specialties/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/specialties")]
    public ActionResult Create(string feature){
      SpecialtyClass specialty = new SpecialtyClass(feature);
      specialty.Save();
      return RedirectToAction("Index");
    }

    [HttpPost("/specialties/{specialtyId}/stylists/new")]
    public ActionResult AddStylist(int specialtyId, int stylistId)
    {
      SpecialtyClass specialty = SpecialtyClass.Find(specialtyId);
      StylistClass stylist = StylistClass.Find(stylistId);
      specialty.AddStylist(stylist);
      return RedirectToAction("Show", new { id = specialtyId });
    }

    [HttpGet("/specialties/{Id}")]
    public ActionResult Show(int id){
      SpecialtyClass specialty = SpecialtyClass.Find(id);
      List<StylistClass> stylists = specialty.GetStylists();
      List<StylistClass> allStylists = StylistClass.GetAll();
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("specialty", specialty);
      model.Add("stylists", stylists);
      model.Add("allStylists", allStylists);
      return View(model);
    }
  }
}
