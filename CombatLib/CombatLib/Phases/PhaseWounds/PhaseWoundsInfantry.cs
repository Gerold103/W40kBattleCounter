using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib.Phases.PhaseWounds
{

//Р А Н Ы   П О   П Е Х О Т Е

    public class PhaseWoundsInfantry : PhaseWounds
    {
        public PhaseWoundsInfantry() //Конструктор по умолчанию
            : base(7, 0, 0) { }

        public PhaseWoundsInfantry(int extern_condition, int extern_rowWounds, int extern_wounds) //Конструктор не по умолчанию
            : base(extern_condition, extern_rowWounds, extern_wounds) { }
    }
}
