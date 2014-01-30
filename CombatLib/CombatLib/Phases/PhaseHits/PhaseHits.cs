﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib.Phases
{

//П О П А Д А Н И Я

    public abstract class PhaseHits: Phase
    {
        protected int additionalCondition; //дополнительное условие попадания. Обычно появляется,
                                           //когда BS атакующего выше 5. Диапазон [1; 6]
        public int AdditionalCondition
        {
            get { return this.additionalCondition; }
            set
            {
                if ((value < 1) || (value > 6))
                {
                    throw new ApplicationException("AdditionalCondition is OutOfRange [1..6]");
                }
                else
                {
                    this.additionalCondition = value;
                }
            }
        }

        protected int hits; //количество попаданий. Диапазон [0; A]
        public int Hits
        {
            get { return this.hits; }
            set
            {
                if ((value < 0) || (value > 1000))
                {
                    throw new ApplicationException("Hits is OutOfRange [0..1000]");
                }
                else
                {
                    this.hits = value;
                }
            }
        }

        public string HitCubesStr; //userfriendly строковое представление кубов на попадания. Будет иметь читабельный для
                                   //пользователя вид. Состоит из чисел от 1 до 6, разделенных пробелами или символами '->'
                                   //в случае, если куб был переброшен
        public int[] HitCubes; //содержит непосредственно значения кубов на попадания. Это числа от 1 до 6. Если куб был переброшен, то
                               //после него в массив пишется число 0 и после него новое значение. Позже 0 будет заменен на '->' при переводе
                               //в строку

        protected PhaseHits() 
            : base() //Конструктор: AdditionalCondition = 7, Hits = 0, HitCubesStr = "Попаданий нет". Вызов конструктора базового класса.
        {
            this.additionalCondition = 7;
            this.hits = 0;
            this.HitCubesStr = "Попаданий нет";
            this.HitCubes = null;
        }
    }
}
