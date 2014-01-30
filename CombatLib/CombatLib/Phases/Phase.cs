using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib.Phases
{
    public abstract class Phase
    {
        protected int condition; //основное условие класса. Для попаданий - условие попадания
                                 //для ран - ранения, для спасбросков - наилучший спас из возможных
                                 //Диапазон [1; 6].
        public int Condition
        {
            get { return this.condition; }
            set
            {
                if ((value < 1) || (value > 6))
                {
                    throw new ApplicationException("Condition is OutOfRange [1..6]");
                }
                else
                {
                    this.condition = value;
                }
            }
        }

        protected Phase() //Конструктор: Condition = 7;
        {
            this.condition = 7;
        }
    }
}
