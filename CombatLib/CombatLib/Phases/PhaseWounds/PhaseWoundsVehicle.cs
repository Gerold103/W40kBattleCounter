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

        public PhaseWoundsVehicle() //Конструктор по умолчанию
            : base(7, 0, 0)
        {
            this.RowSlidingWounds = 0;
            this.RowPunchedWounds = 0;
            this.SlidingWounds = 0;
            this.PunchedWounds = 0;
        }

        public PhaseWoundsVehicle(int extern_condition, int extern_rowWounds, int extern_wounds, int extern_rowSlidingWounds, int extern_slidingWounds, int extern_rowPunchedWounds, int extern_punchedWounds) 
            : base(extern_condition, extern_rowWounds, extern_wounds) //Конструктор не по умолчанию
        {
            this.RowSlidingWounds = extern_rowSlidingWounds;
            this.RowPunchedWounds = extern_rowPunchedWounds;
            this.SlidingWounds = extern_slidingWounds;
            this.PunchedWounds = extern_punchedWounds;
        }
    }
}
