using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib
{

//Ц Е Л Ь   Т Е Х Н И К А   В   Б Л И Ж Н Е М   Б О Ю

    class DMVehicle : DefenceMelee
    {
        protected int t; //T - Диапазон [1; 14]. Защита техники.
        public int T
        {
            get { return this.t; }
            set
            {
                if ((value < 1) || (value > 14))
                {
                    throw new ApplicationException("T is OutOfRange [1..14]");
                }
                else
                {
                    this.t = value;
                }
            }
        }

        public DMVehicle() //Конструктор без параметров. В конструктор базового класса пересылается 7 и 7.
            : base(7, 7) { }

        public DMVehicle(int extern_armorSave, int extern_invulSave, int extern_ws, int extern_t) //Конструктор: S, T берутся извне. ArmorSave, InvulSave берутся извне
                                                                                                  //и пересылаются в конструктор базового класса
            : base(extern_armorSave, extern_invulSave)
        {
            this.WS = extern_ws;
            this.T = extern_t;
        }
    }
}
