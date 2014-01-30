using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib
{

//А Т А К У Ю Щ И Й

    public abstract class Offence
        /* Ремарка: весь код без комментариев представляет собой стандартное присваивание, либо присваивание через проверку с выдачей исключения в случае неудачи */
    {
        protected int a; //Диапазон [0; 1000]. Количество атак.
        public int A
        {
            get { return this.a; }
            set
            {
                if ((value < 0) || (value > 1000))
                {
                    throw new ApplicationException("A is OutOfRange [0..1000]");
                }
                else
                {
                    this.a = value;
                }
            }
        }

        protected int s; //Диапазон [0; 10]. Сила.
        public int S
        {
            get { return this.s; }
            set
            {
                if ((value < 0) || (value > 10))
                {
                    throw new ApplicationException("S is OutOfRange [0..10]");
                }
                else
                {
                    this.s = value;
                }
            }
        }

        protected int ap; //Диапазон [1; 6].
        public int AP
        {
            get { return this.ap; }
            set
            {
                if ((value < 1) || (value > 6))
                {
                    throw new ApplicationException("A is OutOfRange [1..6]");
                }
                else
                {
                    this.ap = value;
                }
            }
        }

        protected Offence(int extern_ap) //Конструктор: AP = 7
        {
            this.AP = extern_ap;
        }
    }
}
