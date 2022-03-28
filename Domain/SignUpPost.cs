using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SignUpPost:IPost
    {
    private IUser User { get; set; }
    private FoundPetPost Post { get; set; }

    public DateTime When;
}
}
