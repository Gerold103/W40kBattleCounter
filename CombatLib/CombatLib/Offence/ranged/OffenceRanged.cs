using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib.Offence.Ranged
{

//А Т А К У Ю Щ И Й   В   Д А Л Ь Н Е М   Б О Ю

    public abstract class OffenceRanged : Offence
    {
        protected int bs; //BS атакующего. Дипазон [1; 10].
        protected bool bsDefined; //Флаг определенности
        public int BS
        {
            get
            {
                if (this.bsDefined) return this.bs;
                else throw new ApplicationException("BS is Undefined");
            }
            set
            {
                if ((value < 1) || (value > 10))
                {
                    throw new ApplicationException("BS is OutOfRange [1..10]");
                }
                else
                {
                    this.bs = value;
                    this.bsDefined = true;
                }
            }
        }

        protected OffenceRanged(int extern_a, int extern_s, int extern_ap, int extern_bs) //Конструктор не по умолчанию.
            : base(extern_a, extern_s, extern_ap)
        {
            this.BS = extern_bs;
        }

        protected OffenceRanged(int extern_ap) //Конструктор по умолчанию. Получает AP от сыновьего объекта.
            : base(extern_ap)
        {
            this.bsDefined = false;
        }
    }
}
