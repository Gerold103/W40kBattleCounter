using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib.Phases.PhaseSaves
{

//С П А С Б Р О С К И
//стоит отметить, как они будут выкидываться. Так как пробивающая рана гораздо опаснее, чем скользящая, то все спасы будут
//сначала тратиться на пробивающие раны и если они после этого не закончатся, то остатки будут потрачены на спасы против скользящих ран

    public abstract class PhaseSaves : Phase
    {
        protected int saves; //сколько ран будет проигнорировано. Диапазон [0; RowWounds]
        public int Saves
        {
            get { return this.saves; }
            set
            {
                if ((value < 0) || (value > 1000))
                {
                    throw new ApplicationException("Saves is OutOfRange [0..1000]");
                }
                else
                {
                    this.saves = value;
                }
            }
        }

        public string SaveCubesStr; //userfriendly строковое представление кубов на спасы. Будет иметь читабельный для
                                    //пользователя вид. Состоит из чисел от 1 до 6, разделенных пробелами или символами '->'
                                    //в случае, если куб был переброшен
        public int[] SaveCubes; //содержит непосредственно значения кубов на спасы. Это числа от 1 до 6. Если куб был переброшен, то
                                //после него в массив пишется число 0 и после него новое значени. Позже 0 будет заменен на '->' при переводе
                                //в строку

        protected PhaseSaves(int extern_saves, int extern_condition) //Конструктор
            : base(extern_condition) 
        {
            this.Saves = extern_saves;
            this.SaveCubesStr = "Спасбросков нет";
            this.SaveCubes = null;
        }
    }
}
