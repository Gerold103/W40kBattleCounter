using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib
{

//Ц Е Л Ь   П Е Х О Т А   В   Б Л И Ж Н Е М   Б О Ю

    class DMInfantry : DefenceMelee
    {
        protected int t; //T - Диапазон [1; 10]. Защита пехоты.
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

        public DMInfantry() //Конструктор без параметров. В конструктор базового класса пересылается 7 и 7.
            : base(7, 7) { }

        public DMInfantry(int extern_armorSave, int extern_invulSave, int extern_ws, int extern_t) //Конструктор: WS, T берутся извне. ArmorSave, InvulSave берутся извне
                                                                                                   //и пересылаются в конструктор базового класса
            : base(extern_armorSave, extern_invulSave)
        {
            this.WS = extern_ws;
            this.T = extern_t;
        }
    }
}
