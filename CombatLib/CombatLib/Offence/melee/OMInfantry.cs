using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib.Offence.Melee
{

//А Т А К У Ю Щ И Й   В   Б Л И Ж Н Е М   Б О Ю   П Е Х О Т И Н Е Ц

    public class OMInfantry : OffenceMelee
    {
        public override string ToString() //Возвращает строковое описание объекта.
        {
            string Result;

            if (this.aDefined) Result = "A = " + this.A.ToString() + "\n";
            else Result = "A is Undefined\n";

            if (this.sDefined) Result += "S = " + this.S.ToString() + "\n";
            else Result += "S is Undefined\n";

            if (this.AP != 7) Result += "AP = " + this.AP.ToString() + "\n";
            else Result += "AP is Undefined (=7)\n";

            if (this.wsDefined) Result += "WS = " + this.WS.ToString();
            else Result += "WS is Undefined";

            return Result;
        }

        public OMInfantry() //Конструктор по умолчанию. AP = 7, остальное не определено.
            : base(7) { }

        public OMInfantry(int extern_a, int extern_s, int extern_ap, int extern_ws) //Конструктор не по умолчанию.
            : base(extern_a, extern_s, extern_ap, extern_ws) { }
    }
}
