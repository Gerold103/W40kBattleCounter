using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib
{
    public abstract class ADistant : Atk
    {
        private int bs;
        public int BS
        {
            get { return this.bs; }
            set
            {
                if ((value < 1) || (value > 10))
                {
                    throw new ApplicationException("BS is OutOfRange [1..10]");
                }
                else
                {
                    this.bs = value;
                }
            }
        }
    }
}
