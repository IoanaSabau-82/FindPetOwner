using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
    //I should create an empty class picture? to use instead of object
    
    public class FoundPetPost : IPost
    { public IUser user { get; set; }
      public Dictionary<int, object> Pictures { get; set; }
      string Phone { get; set; }
      List<DateTime> Availability { get; set; }
      string Comment { get; set; }
      string Address { get; set; }
      List<double> GPScoordinates { get; set; }
      Status Status { get; set; } //se poate pune in setter un default value? care sa poata fi schimbat? sa fie default open

    }

    public enum Status { open, inProgress, closed };
}


