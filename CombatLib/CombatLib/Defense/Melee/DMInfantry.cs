using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib
{
    class DMInfantry : DMelee // для всего защищающегося и в ближнем бою и пехоты
    {
        private int t;
        public int T
        {
            get { return this.t; }
            set
            {
                if ((value < 1) || (value > 10))
                {
                    throw new ApplicationException("T is OutOfRange [1..10]");
                }
                else
                {
                    this.t = value;
                }
            }
        }
        public DMInfantry(int aSave, int iSave, int WSm, int t)
        {
            this.ArmorSave = aSave;
            this.InvulSave = iSave;
            this.WS = WS;
            this.T = t;
        }
    }
}
