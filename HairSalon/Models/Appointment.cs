using System.Collections.Generic;
using System;

namespace HairSalon.Models
{
  public class Appointment
  {
    public int AppointmentId { get; set; }
    public string Name {get; set;}
    public DateTime Date {get; set;}
    public string DateInfo {get {return Date.ToString("mm/dd/yyyy");}}
    public int Time {get; set;}
    public int ClientId { get; set; }
    public virtual Client Client { get; set; }
  }
}