using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib.Phases.PhaseSaves
{

//С П А С Б Р О С К И   Д Л Я   П Е Х О Т Ы

    public class PhaseSavesInfantry : PhaseSaves
    {
        public PhaseSavesInfantry(int extern_saves, int extern_condition) //Конструктор не по умолчанию
            : base(extern_saves, extern_condition) { }

        public PhaseSavesInfantry() //Конструктор по умолчанию
            : base(0, 7) { }
    }
}
