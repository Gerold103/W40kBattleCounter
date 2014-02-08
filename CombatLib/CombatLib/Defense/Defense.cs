using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib.Defence
{

//Ц Е Л Ь

    public abstract class Defense
    // Ремарка: весь код без комментариев представляет собой стандартное присваивание, либо присваивание через проверку с выдачей исключения в случае неудачи
    {
        protected int armorSave; //Диапазон [1; 7]. 7 - только если спасброска нет. Спасбросок по броне.
        public int ArmorSave
        {
            get { return this.armorSave; }
            set
            {
                if ((value < 1) || (value > 7))
                {
                    throw new ApplicationException("ArmorSave is OutOfRange [1..6]");
                }
                else
                {
                    this.armorSave = value;
                }
            }
        }

        protected int invulSave; //Диапазон [1; 7]. 7 - только если спасброска нет. Непробиваемый спасбросок.
        public int InvulSave
        {
            get { return this.invulSave; }
            set
            {
                if ((value < 1) || (value > 7))
                {
                    throw new ApplicationException("InvulSave is OutOfRange [1..6]");
                }
                else
                {
                    this.invulSave = value;
                }
            }
        }

        protected Defense(int extern_armorSave, int extern_invulSave) //Конструктор: ArmorSave, InvulSave. По умолчанию получает от сына ArmorSave = 7, InvulSave = 7
        {
            this.ArmorSave = extern_armorSave;
            this.InvulSave = extern_invulSave;
        }
    }
}
