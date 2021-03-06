﻿using System;
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
                                 //Диапазон [1; 15]. 15 - нельзя ранить
        public int Condition
        {
            get { return this.condition; }
            set
            {
                if ((value < 1) || (value > 15))
                {
                    throw new ApplicationException("Condition is OutOfRange [1..6]");
                }
                else
                {
                    this.condition = value;
                }
            }
        }

        protected Phase(int extern_condition) //Конструктор
        {
            this.Condition = extern_condition;
        }
    }
}
