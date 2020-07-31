using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Stylist
  {
    public Cuisine()
    {
      this.Clients = new HashSet<Client>();
    }
    public int StylistId { get; set; }
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Speciality { get; set; }
    public virtual ICollection<Client> Clients { get; set; }
  }
}