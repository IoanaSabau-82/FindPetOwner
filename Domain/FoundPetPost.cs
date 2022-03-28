using FindPetOwner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
    //I should create an empty class picture? to use instead of object
    
    public class FoundPetPost
    { public User User { get; set; }
      public Dictionary<int, object> Pictures { get; set; }
      public string Phone { get; set; }
      public List<DateTime> Availability { get; set; }
      public string Comment { get; set; }
      public string Address { get; set; }
      public List<double> GPScoordinates { get; set; }
      public Status Status { get; set; } //default se seteaza in application? 
    }

    public enum Status { open, inProgress, closed };
}


