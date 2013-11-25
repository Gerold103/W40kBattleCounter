using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib
{
    public class AMInfantry : AMelee
    {
        public AMInfantry(int a, int s, int ap, int ws)
        {
            this.A = a;
            this.S = s;
            this.AP = ap;
            this.WS = ws;
        }
    }
}
