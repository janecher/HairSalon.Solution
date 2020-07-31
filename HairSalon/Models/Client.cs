using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Client
  {
    public Client()
    {
      this.Appointments = new HashSet<Appointment>();
    }
    public int ClientId { get; set; }
    public string FirstName {get; set;}
    public string LastName {get; set;}

    public string FullName {get {return FirstName + " " + LastName;}}
    public int StylistId { get; set; }
    public virtual Stylist Stylist { get; set; }
    public virtual ICollection<Appointment> Appointments { get; set; }

  }
}