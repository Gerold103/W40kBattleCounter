using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib.Offence
{

//А Т А К У Ю Щ И Й

    public abstract class Offence
        /* Ремарка: весь код без комментариев представляет собой стандартное присваивание, либо присваивание через проверку с выдачей исключения в случае неудачи */
    {
        protected int a; //Диапазон [0; 1000]. Количество атак.
        protected bool aDefined; //Флаг определенности
        public int A
        {
            get
            {
                if (this.aDefined) return this.a;
                else throw new ApplicationException("A is Undefined");
            }
            set
            {
                if ((value < 0) || (value > 1000))
                {
                    throw new ApplicationException("A is OutOfRange [0..1000]");
                }
                else
                {
                    this.a = value;
                    this.aDefined = true;
                }
            }
        }

        protected int s; //Диапазон [0; 10]. Сила.
        protected bool sDefined; //Флаг определенности
        public int S
        {
            get
            {
                if (this.sDefined) return this.s;
                else throw new ApplicationException("S is Undefined");
            }
            set
            {
                if ((value < 0) || (value > 10))
                {
                    throw new ApplicationException("S is OutOfRange [0..10]");
                }
                else
                {
                    this.s = value;
                    this.sDefined = true;
                }
            }
        }

        protected int ap; //Диапазон [1; 7]. 7 - только если не определено
        public int AP
        {
            get { return this.ap; }
            set
            {
                if ((value < 1) || (value > 7))
                {
                    throw new ApplicationException("AP is OutOfRange [1..6]");
                }
                else
                {
                    this.ap = value;
                }
            }
        }

        protected Offence(int extern_a, int extern_s, int extern_ap) //Конструктор не по умолчанию. Для инициализации всех характеристик сразу при создании объекта.
        {
            this.A = extern_a;
            this.S = extern_s;
            this.AP = extern_ap;
        }

        protected Offence(int extern_ap) //Конструктор по умолчанию. Принимает от сыновьего объекта аргумент для AP.
        {
            this.AP = extern_ap;
            this.aDefined = false;
            this.sDefined = false;
        }
    }
}
