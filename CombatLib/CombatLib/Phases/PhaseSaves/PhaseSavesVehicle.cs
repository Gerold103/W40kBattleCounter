using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib.Phases.PhaseSaves
{

//С П А С Б Р О С К И   Д Л Я   Т Е Х Н И К И

    public class PhaseSavesVehicle : PhaseSaves
    {
        protected int slidingSaves; //сколько скользящих ран было проигнорировано от общего числа. Диапазон [0; Saves]
        public int SlidingSaves
        {
            get { return this.slidingSaves; }
            set
            {
                if ((value < 0) || (value > 1000))
                {
                    throw new ApplicationException("SlidingSaves is OutOfRange [0..1000]");
                }
                else
                {
                    this.slidingSaves = value;
                }
            }
        }

        protected int punchedSaves; //сколько пробивающих ран было проигнорировано от общего числа. Диапазон [0; Saves]
        public int PunchedSaves
        {
            get { return this.punchedSaves; }
            set
            {
                if ((value < 0) || (value > 1000))
                {
                    throw new ApplicationException("PunchedSaves is OutOfRange [0..1000]");
                }
                else
                {
                    this.punchedSaves = value;
                }
            }
        }

        public PhaseSavesVehicle() //Конструкто по умолчанию
            : base(0, 7)
        {
            this.PunchedSaves = 0;
            this.SlidingSaves = 0;
        }

        public PhaseSavesVehicle(int extern_saves, int extern_condition, int extern_slidingSaves, int extern_punchedSaves) //Конструктор не по умолчанию
            : base(extern_saves, extern_condition) 
        {
            this.PunchedSaves = extern_punchedSaves;
            this.SlidingSaves = extern_slidingSaves;
        }
    }
}
