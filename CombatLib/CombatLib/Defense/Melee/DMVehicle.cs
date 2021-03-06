﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib.Defence.Melee
{

//Ц Е Л Ь   Т Е Х Н И К А   В   Б Л И Ж Н Е М   Б О Ю

    public class DMVehicle : DefenceMelee
    {
        protected int t; //T - Диапазон [1; 14]. Защита техники.
        protected bool tDefined; //Флаг определенности
        public int T
        {
            get
            {
                if (this.tDefined) return this.t;
                else throw new ApplicationException("T is Undefined");
            }
            set
            {
                if ((value < 1) || (value > 14))
                {
                    throw new ApplicationException("T is OutOfRange [1..14]");
                }
                else
                {
                    this.t = value;
                    this.tDefined = true;
                }
            }
        }

        public override string ToString() //Возвращает строковое описание объекта.
        {
            string Result;

            if (this.ArmorSave != 7) Result = "ArmorSave = " + this.ArmorSave.ToString() + "\n";
            else Result = "ArmorSave is Undefined (=7)\n";

            if (this.InvulSave != 7) Result += "InvulSave = " + this.InvulSave.ToString() + "\n";
            else Result += "InvulSave is Undefined (=7)\n";

            if (this.wsDefined) Result += "WS = " + this.WS.ToString() + "\n";
            else Result += "WS is Undefined\n";

            if (this.tDefined) Result += "T = " + this.T.ToString();
            else Result += "T is Undefined";

            return Result;
        }

        public DMVehicle() //Конструктор по умолчанию. ArmorSave = 7, InvulSave = 7
            : base(7, 7)
        {
            this.tDefined = false;
        }

        public DMVehicle(int extern_armorSave, int extern_invulSave, int extern_ws, int extern_t) //Конструктор не по умолчанию. Самостоятельно обрабатывает только T.
            : base(extern_armorSave, extern_invulSave, extern_ws)
        {
            this.T = extern_t;
        }
    }
}
