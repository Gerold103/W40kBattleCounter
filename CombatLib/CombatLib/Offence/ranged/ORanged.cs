using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib
{

//А Т А К У Ю Щ И Й   В   Д А Л Ь Н Е М   Б О Ю

    public abstract class OffenceRanged : Offence
    {
        protected int bs; //BS атакующего. Дипазон [1; 10].
        public int BS
        {
            get { return this.bs; }
            set
            {
                if ((value < 1) || (value > 10))
                {
                    throw new ApplicationException("BS is OutOfRange [1..10]");
                }
                else
                {
                    this.bs = value;
                }
            }
        }

        protected OffenceRanged(int extern_ap) //Конструктор, передающий AP конструктору базового класса
            : base(extern_ap) { }
    }
}
