using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib
{

//Ц Е Л Ь   В   Б Л И Ж Н Е М   Б О Ю

    public abstract class DefenceMelee : Defense
    {
        protected int ws; //Диапазон [1; 10].
        public int WS 
        {
            get { return this.ws; }
            set
            {
                if ((value < 1) || (value > 10))
                {
                    throw new ApplicationException("WS is OutOfRange [1..10]");
                }
                else
                {
                    this.ws = value;
                }
            }
        }

        protected DefenceMelee(int extern_armorSave, int extern_invulSave) //Конструктор, передающий ArmorSave и InvulSave конструктору базового класса
            : base(extern_armorSave, extern_invulSave) { }
    }
}
