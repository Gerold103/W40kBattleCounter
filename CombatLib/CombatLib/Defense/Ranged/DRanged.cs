using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib
{
    class DRanged : Defense // для всего защищающегося и стреляющего
    {
        private int coverSave = 7;
        public int CoverSave
        {
            get { return this.coverSave; }
            set
            {
                if ((value < 1) || (value > 6))
                {
                    throw new ApplicationException("coverSave is OutOfRange [1..6]");
                }
                else
                {
                    this.coverSave = value;
                }
            }
        }
    }
}
