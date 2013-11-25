using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CombatLib;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //A - ATK, D - DEF, M - MELEE, R - RANGED
            AMInfantry test = new AMInfantry(2000, 1, 1, 1);
            ADVehicle test2 = new ADVehicle(1, 1, 1, 1);
            Console.WriteLine("{0} {1}",test.A,test2.BS);
        }
    }
}
