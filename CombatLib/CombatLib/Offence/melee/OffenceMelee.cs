using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib
{

//А Т А К У Ю Щ И Й   В   Б Л И Ж Н Е М   Б О Ю

    public abstract class OffenceMelee : Offence
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

        protected OffenceMelee(int extern_a, int extern_s, int extern_ap, int extern_ws) //Конструктор не по умолчанию.
            : base(extern_a, extern_s, extern_ap)
        {
            this.WS = extern_ws;
        }

        protected OffenceMelee(int extern_ap) //Конструктор по умолчанию. Получает AP от сыновьего объекта.
            : base(extern_ap)
        {
            this.wsDefined = false;
        }
    }
}
