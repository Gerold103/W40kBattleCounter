using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib
{

//Ц Е Л Ь   П Е Х О Т А   В   Д А Л Ь Н Е М   Б О Ю

    class DRInfantry : DefenceRanged
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

        public DRInfantry() //Конструктор без параметров. В конструктор базового класса пересылается 7 и 7.
            : base(7, 7) { }

        public DRInfantry(int extern_t, int extern_armorSave = 7, int extern_invulSave = 7, int extern_coverSave = 7) //Конструктор: T берется извне. ArmorSave, InvulSave, CoverSave
                                                                                                                      //берутся извне и пересылаются в конструктор базового класса
                                                                                                                      //или приравниваются к 7 по умолчанию
            : base(extern_armorSave, extern_invulSave, extern_coverSave)
        {
            this.T = extern_t;
        }
    }
}
