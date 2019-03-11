using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class SpecialtyController : Controller
    {
        [HttpGet("/stylists/specialties/showall")]
        public ActionResult ShowAll()
        {
            List<Specialty> allSpecialties = Specialty.GetAll();
            return View(allSpecialties);
        }

        [HttpGet("/stylists/specialties/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/stylists/specialties/new")]
        public ActionResult Create(string specialty)
        {
            SpecialtyClass.Save(specialty);
            return RedirectToAction("ShowAll");
        }
    }
}
