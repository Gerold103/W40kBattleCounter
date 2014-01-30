using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib
{

//А Т А К У Ю Щ И Й   В   Б Л И Ж Н Е М   Б О Ю

    public abstract class OffenceMelee : Offence // для всего атакующего и дерущегося в ближнем бою
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

        protected OffenceMelee(int extern_ap) //Конструктор, передающий AP конструктору базового класса
            : base(extern_ap) { }
    }
}
