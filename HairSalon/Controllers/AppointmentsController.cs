using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
  public class AppointmentsController : Controller
  {
    private readonly HairSalonContext _db;

    public AppointmentsController(HairSalonContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult Create()
    {
      ViewBag.ClientId = new SelectList(_db.Clients, "ClientId", "FullName");
      ViewBag.Time = new List<string>{"9am, 10am, 11am, 1pm, 2pm"};
      return View();
    }
    
    [HttpPost]
    public ActionResult Create(Appointment appointment)
    {
      /*foreach(Appointment appointmentExist in _db.Appointments)
      {
        if(appointmentExist.Time == appointment.Time)
        {
          return RedirectToAction("Index");
        }
      }*/
      ViewBag.Time.Remove(appointment.Time);
      _db.Appointments.Add(appointment);
      _db.SaveChanges();
      return RedirectToAction("Details", "Clients", new { id = appointment.ClientId });
    }
  }
}