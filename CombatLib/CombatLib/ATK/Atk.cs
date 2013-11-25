using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib
{
    public abstract class Atk
    {
        private int a, s, ap = 7;
        public int A // a = int[0.1000];
        {
            get { return this.a; }
            set
            {
                if ((value < 0) || (value > 1000))
                {
                    Console.WriteLine("SASAI");
                    //throw new ApplicationException
                    //("A is OutOfRange [0..1000]");
                }
                else
                {
                    this.a = value;
                }
            }
        }

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
    }
}
