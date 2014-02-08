using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib.Phases.PhaseHits
{

//П О П А Д А Н И Я    П О   П Е Х О Т Е

    public class PhaseHitsVehicle : PhaseHits
    {
        public PhaseHitsVehicle(int extern_AddCond, int extern_hits, int extern_condition) //Конструктор не по умолчанию
            : base(extern_AddCond, extern_hits, extern_condition) { }

        public PhaseHitsVehicle() //Конструктор по умолчанию
            : base(7, 0, 7) { }
    }
}
