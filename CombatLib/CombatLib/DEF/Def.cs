using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib
{
    public abstract class Def
    {
        private int armorSave = 7, invulSave = 7;
        public int ArmorSave // a = int[1..6];
        {
            get { return this.armorSave; }
            set
            {
                if ((value < 1) || (value > 6))
                {
                    throw new ApplicationException("armorSave is OutOfRange [1..6]");
                }
                else
                {
                    this.armorSave = value;
                }
            }
        }

        public int InvulSave
        {
            get { return this.invulSave; }
            set
            {
                if ((value < 1) || (value > 6))
                {
                    throw new ApplicationException("invulSave is OutOfRange [1..6]");
                }
                else
                {
                    this.invulSave = value;
                }
            }
        }
    }
}
