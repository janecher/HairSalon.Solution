using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Stylist
  {
    public Stylist()
    {
      this.Clients = new HashSet<Client>();
    }
    public int StylistId { get; set; }
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Speciality { get; set; }
    public string FullName {get {return FirstName + " " + LastName + ", " + Speciality;}}
    public virtual ICollection<Client> Clients { get; set; }
  }
}