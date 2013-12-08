using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib
{
    class DRInfantry : DRanged // для всего защищающегося и стреляющего и пехотного
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
        public DRInfantry(int aSave, int iSave, int coverSave, int t)
        {
            this.ArmorSave = aSave;
            this.InvulSave = iSave;
            this.CoverSave = coverSave;
            this.T = t;
        }
    }
}
