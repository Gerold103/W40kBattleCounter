using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib
{

//А Т А К У Ю Щ И Й   В   Д А Л Ь Н Е М   Б О Ю   П Е Х О Т И Н Е Ц

    public class ORInfantry : OffenceRanged
    {
        public ORInfantry() //Конструктор без параметров. В конструктор базового класса пересылается 7.
            : base(7) { }

        public ORInfantry(int extern_a, int extern_s, int extern_bs, int extern_ap) //Конструктор: A, S, BS берутся извне. AP берется извне или = 7 по умолчанию и пересылается
                                                                                    //в конструктор базового класса
            : base(extern_ap)
        {
            this.A = extern_a;
            this.S = extern_s;
            this.BS = extern_bs;
        }
    }
}
