using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    private readonly HairSalonContext _db;

    public ClientsController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Client> model = _db.Clients.Include(client => client.Stylist).ToList();
      return View(model);
    }
    
    [HttpGet]
    public ActionResult Create()
    {
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "FullName");
      return View();
    }
    
    [HttpPost]
    public ActionResult Create(Client client)
    {
      foreach(Client clientExist in _db.Clients)
      {
        if(clientExist.FirstName == client.FirstName && clientExist.LastName == client.LastName)
        {
          return RedirectToAction("Details", "Stylists", new { id = clientExist.StylistId });
        }
      }
      _db.Clients.Add(client);
      _db.SaveChanges();
      return RedirectToAction("Details", "Stylists", new { id = client.StylistId });
    }

    public ActionResult Details(int id)
    {
      Client thisClient = _db.Clients.Include(client => client.Appointments).FirstOrDefault(clients => clients.ClientId == id);
      return View(thisClient);
    }

    public ActionResult Edit(int id)
    {
      Client thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "FullName");
      return View(thisClient);
    }

    [HttpPost]
    public ActionResult Edit(Client client)
    {
      _db.Entry(client).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", "Clients", new { id = client.ClientId });
    }

    public ActionResult Delete(int id)
    {
      Client thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
      return View(thisClient);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Client thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
      _db.Clients.Remove(thisClient);
      _db.SaveChanges();
      return RedirectToAction("Details", "Stylists", new { id = thisClient.StylistId });
    }
  }
}