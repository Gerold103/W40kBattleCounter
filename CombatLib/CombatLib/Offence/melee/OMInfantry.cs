﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib
{
    public class OMInfantry : OffenceMelee // для всего атакующего и дерущегося в ближнем бою и пехотного
    {
        public OMInfantry(int a, int s, int ap, int ws)
        {
            this.A = a;
            this.S = s;
            this.AP = ap;
            this.WS = ws;
        }
    }
}