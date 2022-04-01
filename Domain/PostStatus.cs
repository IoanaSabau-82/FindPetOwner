using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum PostStatus { Open = 0, Pending = 1, CipFound = 2, NoCip = 3, OpenForAdoption = 4, Closed = 5 };

    //pt 3 sau 2, dar nu se poate contacta stapanul, se lasa postarea deschisa timp de 2 saptamani sa il poata revendica totusi stapanul
    //dupa care se trece in 4 pt o perioada de timp. Administratorul paginii verifica toate postarile deschise de 1 luna si sa ia legatura
    //cu userul daca se inchide sau nu postarea
}
