using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib.Phases.PhaseWounds
{

//Р А Н Ы   П О   Т Е Х Н И К Е

    public class PhaseWoundsVehicle : PhaseWounds
    {
        protected int rowSlidingWounds; //количество скользящих ран из общего числа до спасов. Диапазон [0; RowWounds]
        public int RowSlidingWounds
        {
            get { return this.rowSlidingWounds; }
            set
            {
                if ((value < 0) || (value > 1000))
                {
                    throw new ApplicationException("RowSlidingWounds is OutOfRange [0..1000]");
                }
                else
                {
                    this.rowSlidingWounds = value;
                }
            }
        }

        protected int slidingWounds; //количество скользящих ран из общего числа после спасов. Диапазон [0; Wounds]
        public int SlidingWounds
        {
            get { return this.slidingWounds; }
            set
            {
                if ((value < 0) || (value > 1000))
                {
                    throw new ApplicationException("SlidingWounds is OutOfRange [0..1000]");
                }
                else
                {
                    this.slidingWounds = value;
                }
            }
        }

        protected int rowPunchedWounds; //количество пробивающих ран из общего числа до спасов. Диапазон [0; RowWounds]
        public int RowPunchedWounds
        {
            get { return this.rowPunchedWounds; }
            set
            {
                if ((value < 0) || (value > 1000))
                {
                    throw new ApplicationException("RowPunchedWounds is OutOfRange [0..1000]");
                }
                else
                {
                    this.rowPunchedWounds = value;
                }
            }
        }

        protected int punchedWounds; //количество пробивающих ран из общего числа после спасов. Диапазон [0; Wounds]
        public int PunchedWounds
        {
            get { return this.punchedWounds; }
            set
            {
                if ((value < 0) || (value > 1000))
                {
                    throw new ApplicationException("PunchedWounds is OutOfRange [0..1000]");
                }
                else
                {
                    this.punchedWounds = value;
                }
            }
        }

        public PhaseWoundsVehicle() 
            : base() //Конструктор: RowSlidingWounds = 0, SlidingWounds = 0, RowPunchedWounds = 0, PunchedWounds = 0. Вызов базового конструктора.
        {
            this.rowSlidingWounds = 0;
            this.rowPunchedWounds = 0;
            this.slidingWounds = 0;
            this.punchedWounds = 0;
        }
    }
}
