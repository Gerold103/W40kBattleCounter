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

        public override string ToString() //возвращает строковое описание объекта
        {
            string Result;

            if (this.Condition != 7) Result = "Condition = " + this.Condition.ToString() + "\n";
            else Result = "Condition is Undefined (=7)\n";

            if (this.RowWounds != 0) Result += "Row Wounds = " + this.RowWounds.ToString() + "\n";
            else Result += "Row Wounds are Undefined (or defined but = 0)\n";

            if (this.Wounds != 0) Result += "Wounds = " + this.Wounds.ToString() + "\n";
            else Result += "Wounds are Undefined (or defined but = 0)\n";

            if (this.WoundCubesStr != null) Result += "Wound Cubes = " + this.WoundCubesStr;
            else Result += "Wound Cubes are Undefined (=null)";

            return Result;
        }
    }
}
