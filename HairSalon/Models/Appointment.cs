using System.Collections.Generic;
using System;

namespace HairSalon.Models
{
  public class Appointment
  {
    public int AppointmentId { get; set; }
    public string Name {get; set;}
    public DateTime Date {get; set;}
    public string DateInfo {get {return Date.ToString("MM/dd/yyyy");}}
    public int Time {get; set;}

    public string TimeInfo 
    { get 
      {
        if(Time == 12 || (Time >=1 && Time < 8))
        {
          return Time + " pm";
        }
        else
        {
          return Time + " am";
        }
      }
    }
    public int ClientId { get; set; }
    public virtual Client Client { get; set; }
  }
}