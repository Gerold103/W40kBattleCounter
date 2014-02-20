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

        public override string ToString() //возвращает строковое описание объекта
        {
            string Result;

            if (this.Condition != 7) Result = "Condition = " + this.Condition.ToString() + "\n";
            else Result = "Condition is Undefined (=7)";

            if (this.SaveCubesStr != null) Result += "Save Cubes = " + this.SaveCubesStr + "\n";
            else Result += "Save Cubes is Undefined (=null)";

            if (this.Saves != 0) Result += "Saves = " + this.Saves.ToString();
            else Result += "Saves is Undefined (or defined but = 0)";

            return Result;
        }
    }
}
