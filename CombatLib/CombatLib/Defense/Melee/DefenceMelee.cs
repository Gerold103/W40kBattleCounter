using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib.Defence.Melee
{

//Ц Е Л Ь   В   Б Л И Ж Н Е М   Б О Ю

    public abstract class DefenceMelee : Defense
    {
        protected int ws; //Диапазон [1; 10].
        protected bool wsDefined; //Флаг определенности
        public int WS 
        {
            get
            {
                if (this.wsDefined) return this.ws;
                else throw new ApplicationException("WS is Undefined");
            }
            set
            {
                if ((value < 1) || (value > 10))
                {
                    throw new ApplicationException("WS is OutOfRange [1..10]");
                }
                else
                {
                    this.ws = value;
                    this.wsDefined = true;
                }
            }
        }

        protected DefenceMelee(int extern_armorSave, int extern_invulSave) //Конструктор по умолчанию.
            : base(extern_armorSave, extern_invulSave)
        {
            this.wsDefined = false;
        }

        protected DefenceMelee(int extern_armorSave, int extern_invulSave, int extern_ws) //Конструктор не по умолчанию. Задает все характеристики сразу при создании объекта.
            : base(extern_armorSave, extern_invulSave) 
        {
            this.WS = extern_ws;
        }
    }
}
