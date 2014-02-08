using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib.Offence.Ranged
{

//А Т А К У Ю Щ И Й   В   Д А Л Ь Н Е М   Б О Ю   П Е Х О Т И Н Е Ц

    public class ORInfantry : OffenceRanged
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

            if (this.bsDefined) Result += "BS = " + this.BS.ToString();
            else Result += "BS is Undefined";

            return Result;
        }

        public ORInfantry() //Конструктор по умолчанию. AP = 7, остальное не определено.
            : base(7) { }

        public ORInfantry(int extern_a, int extern_s, int extern_ap, int extern_bs) //Конструктор не по умолчанию.
            : base(extern_a, extern_s, extern_ap, extern_bs) { }
    }
}
