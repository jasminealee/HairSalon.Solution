using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {
    [HttpGet("/stylists/clients/new")]
    public ActionResult New()
    {
      List<Stylist> allStylists = Stylist.GetAll();
      return View(allStylists);
    }

    [HttpPost("/stylists/clients/new")]
    public ActionResult MakeClient(string clientName, int stylistId)
    {
            Client client = new Client(clientName, stylistId);
            client.Save();
            return RedirectToAction("ShowAll");
        }

        [HttpGet("/stylists/clients/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Client.Delete(id);
            return View();
        }

        [HttpGet("/stylists/clients/{id}")]
        public ActionResult Show(int id)
        {
            Client client = Client.GetClientById(id);
            return View(client);
        }

        [HttpGet("/stylists/clients/showall")]
        public ActionResult ShowAll()
        {
            List<Client> clientList = Client.GetAll();
            return View(clientList);
        }

        [HttpGet("/stylists/clients/deleteall")]
        public ActionResult DeleteAll()
        {
            Client.ClearAll();
            return RedirectToAction("ShowAll");
        }

}    }  
