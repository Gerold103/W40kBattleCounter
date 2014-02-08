using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib.Phases.PhaseWounds
{

//Р А Н Ы

    public abstract class PhaseWounds : Phase
    {
        protected int rowWounds; //количество ран до спасбросков. Диапазон [0; Hits]
        public int RowWounds
        {
            get { return this.rowWounds; }
            set
            {
                if ((value < 0) || (value > 1000))
                {
                    throw new ApplicationException("RowWounds is OutOfRange [0..1000]");
                }
                else
                {
                    this.rowWounds = value;
                }
            }
        }

        protected int wounds; //количество ран в итоге, после отыгрыша спасбросков, если они были.
                              //Диапазон [0; RowWounds]
        public int Wounds
        {
            get { return this.wounds; }
            set
            {
                if ((value < 0) || (value > 1000))
                {
                    throw new ApplicationException("Wounds is OutOfRange [0..1000]");
                }
                else
                {
                    this.wounds = value;
                }
            }
        }

        public string WoundCubesStr; //userfriendly строковое представление кубов на раны. Будет иметь читабельный для
                                     //пользователя вид. Состоит из чисел от 1 до 6, разделенных пробелами или символами '->'
                                     //в случае, если куб был переброшен
        public int[] WoundCubes; //содержит непосредственно значения кубов на раны. Это числа от 1 до 6. Если куб был переброшен, то
                                 //после него в массив пишется число 0 и после него новое значение. Позже 0 будет заменен на '->' при переводе
                                 //в строку

        protected PhaseWounds(int extern_condition, int extern_rowWounds, int extern_wounds) //Конструктор
            : base(extern_condition) 
        {
            this.RowWounds = extern_rowWounds;
            this.Wounds = extern_wounds;
            this.WoundCubesStr = "Ран нет";
            this.WoundCubes = null;
        }
    }
}
