using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib
{

//Ц Е Л Ь   В   Д А Л Ь Н Е М   Б О Ю

    public abstract class DefenceRanged : Defense
    {
        protected int coverSave; //Дипазон [1; 6]. 7 - если спасброска нет. Спасбросок по укрытию.
        public int CoverSave
        {
            get { return this.coverSave; }
            set
            {
                if ((value < 1) || (value > 6))
                {
                    throw new ApplicationException("coverSave is OutOfRange [1..6]");
                }
                else
                {
                    this.coverSave = value;
                }
            }
        }

        protected DefenceRanged(int extern_armorSave, int extern_invulSave, int extern_coverSave = 7) //Конструктор, передающий ArmorSave и InvulSave конструктору базового класса, 
                                                                                                //и получающий CoverSave для самостоятельной обработки
            : base(extern_armorSave, extern_invulSave)
        {
            this.CoverSave = extern_coverSave;
        }
    }
}
