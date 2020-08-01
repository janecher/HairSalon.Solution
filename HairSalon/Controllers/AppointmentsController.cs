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
    public ActionResult Create(Client client)
    {
      ViewBag.ClientId = client.ClientId;
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
      _db.Appointments.Add(appointment);
      _db.SaveChanges();
      return RedirectToAction("Details", "Clients", new { id = appointment.ClientId });
    }

    public ActionResult Edit(int id)
    {
      Appointment thisAppointment = _db.Appointments.FirstOrDefault(appointments => appointments.AppointmentId == id);
      return View(thisAppointment);
    }

    [HttpPost]
    public ActionResult Edit(Appointment appointment)
    {
      _db.Entry(appointment).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", "Clients", new { id = appointment.ClientId });
    }

    public ActionResult Delete(int id)
    {
      Appointment thisAppointment = _db.Appointments.FirstOrDefault(appointments => appointments.AppointmentId == id);
      return View(thisAppointment);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Appointment thisAppointment = _db.Appointments.FirstOrDefault(appointments => appointments.AppointmentId == id);
      _db.Appointments.Remove(thisAppointment);
      _db.SaveChanges();
      return RedirectToAction("Details", "Clients", new { id = thisAppointment.ClientId });
    }
  }
}