using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib
{

//А Т А К У Ю Щ А Я   В   Б Л И Ж Н Е М   Б О Ю   Т Е Х Н И К А

    public class OMVehicle : OffenceMelee
    {
        public OMVehicle() //Конструктор без параметров. В конструктор базового класса пересылается 7.
            : base(7) { }

        public OMVehicle(int extern_a, int extern_s, int extern_ws, int extern_ap) //Конструктор: A, S, WS берутся извне. AP берется извне и пересылается
                                                                                   //в конструктор базового класса
            : base(extern_ap)
        {
            this.A = extern_a;
            this.S = extern_s;
            this.WS = extern_ws;
        }
    }
}
