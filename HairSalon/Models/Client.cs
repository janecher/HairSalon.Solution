using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Client
  {
    public int ClientId { get; set; }
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public int StylistId { get; set; }
    public virtual Stylist Stylist { get; set; }
  }
}