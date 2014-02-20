using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib.Phases.PhaseHits
{

//П О П А Д А Н И Я    П О   П Е Х О Т Е

    public class PhaseHitsInfantry : PhaseHits
    {
        public PhaseHitsInfantry(int extern_AddCond, int extern_hits, int extern_condition) //Конструктор не по умолчанию
            : base(extern_AddCond, extern_hits, extern_condition) { }

        public PhaseHitsInfantry() //Конструктор по умолчанию
            : base(7, 0, 7) { }

        public override string ToString() //возвращает строковое описание объекта
        {
            string Result;
            if (this.Condition != 7) Result = "Condition = " + this.Condition.ToString() + "\n";
            else Result = "Condition is Undefined (=7)\n";

            if (this.AdditionalCondition != 7) Result += "Additional Condition = " + this.AdditionalCondition.ToString() + "\n";
            else Result += "Additional Condition is Undefined (=7)\n";

            if (this.HitCubesStr != null) Result += "Hit Cubes = " + this.HitCubesStr + "\n";
            else Result += "Cubes for hits is Undefined (=null)\n";

            if (this.Hits != 0) Result += "Hits = " + this.Hits.ToString();
            else Result += "Hits is Undefined (or defined but = 0)";

            return Result;
        }
    }
}
