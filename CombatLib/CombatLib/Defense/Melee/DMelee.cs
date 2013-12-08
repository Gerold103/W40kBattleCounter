using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib
{
    class DMelee : Defense // для всего защищающегося в ближнем бою
    {
        private int ws;
        public int WS 
        {
            get { return this.ws; }
            set
            {
                if ((value < 1) || (value > 10))
                {
                    throw new ApplicationException("WS is OutOfRange [1..10]");
                }
                else
                {
                    this.ws = value;
                }
            }
        }
    }
}
