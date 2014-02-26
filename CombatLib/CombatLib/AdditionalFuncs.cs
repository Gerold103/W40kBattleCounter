using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib.Addition
{
    public class AdditionalFuncs
    {
        private static void CheckStr(int[] arg)
        {
            int prevElem = 0;
            foreach (int elem in arg)
            {
                if (arg[0] == 0) throw new ApplicationException("Wrong Input: first element = 0");
                if (arg[arg.Length - 1] == 0) throw new ApplicationException("Wrong Input: last element = 0");
                if (prevElem + elem == 0) throw new ApplicationException("Wrong Input: repeating 0's");
                prevElem = elem;
            }
        }
        public static string ReduceCubesToStr(int[] arg)
        {
            CheckStr(arg);
            String res = "";
            foreach (int elem in arg)
            {
                if (elem == 0) res = res.Substring(0,res.Length-1) + '→';
                else
                {
                    res += (char)(elem + '0');
                    res += ' ';
                }
            }
            return res;
        }

        public static int RangedHitConditions(CombatLib.Offence.Ranged.OffenceRanged AttackingPlayer, ref CombatLib.Phases.PhaseHits.PhaseHits Hits) //вычисляем табличное значение условий попадания в
            //дальнем бою
        {
            if (AttackingPlayer.BS < 6)
            {
                Hits.Condition = 7 - AttackingPlayer.BS;
            }
            else
            {
                Hits.Condition = 2;
                Hits.AdditionalCondition = 12 - AttackingPlayer.BS;
            }
            return Hits.Condition;
        }

        public static int RangedWoundCondition(CombatLib.Offence.Ranged.OffenceRanged AttackingPlayer, CombatLib.Defence.Ranged.DRInfantry DefendingPlayer,
            ref CombatLib.Phases.PhaseWounds.PhaseWounds Wounds) //вычисляем табличное значение условия ранения для пехоты в дальнем бою
        {
            int difference = AttackingPlayer.S - DefendingPlayer.T;
            if (difference >= 2)
            {
                Wounds.Condition = 2;
            }
            else if ((difference >= -3) && (difference <= 1))
            {
                if (difference <= -2) Wounds.Condition = 6;
                if (difference == -1) Wounds.Condition = 5;
                if (difference == 0) Wounds.Condition = 4;
                if (difference == 1) Wounds.Condition = 3;
            }
            else Wounds.Condition = 7;
            return Wounds.Condition;
        }

        public static int VehicleWoundCondition(CombatLib.Defence.Ranged.DRVehicle DefendingPlayer,
            ref CombatLib.Phases.PhaseWounds.PhaseWounds Wounds) //вычисляем табличное значение условия ранения для техники
        {
            Wounds.Condition = DefendingPlayer.T;
            return Wounds.Condition;
        }

        public static int VehicleWoundCondition(CombatLib.Defence.Melee.DMVehicle DefendingPlayer,
            ref CombatLib.Phases.PhaseWounds.PhaseWounds Wounds) //вычисляем табличное значение условия ранения для техники
        {
            Wounds.Condition = DefendingPlayer.T;
            return Wounds.Condition;
        }

        public static int BestSaveThrow(int ap, int cover, int armor = 7, int invul = 7)
        {
            int res;
            if ((ap <= armor) || (armor >= cover) && (armor >= invul))
            {
                if (cover >= invul) res = invul;
                else res = cover;
            }
            else
            {
                if (invul >= cover)
                {
                    if (armor <= cover) res = armor;
                    else res = cover;
                }
                else
                {
                    if (armor <= invul) res = armor;
                    else res = invul;
                }
            }
            return res;
        }

        public static int MeleeHitCondition(CombatLib.Offence.Melee.OffenceMelee AttackingPlayer, CombatLib.Defence.Melee.DefenceMelee DefendingPlayer,
            ref CombatLib.Phases.PhaseHits.PhaseHits Hits) //вычисляем табличное значение условия попадания в ближнем бою
        {
            if (AttackingPlayer.WS - DefendingPlayer.WS > 0) Hits.Condition = 3;
            else if (AttackingPlayer.WS * 2 < DefendingPlayer.WS) Hits.Condition = 5;
            else Hits.Condition = 4;
            return Hits.Condition;
        }

        public static int MeleeWoundCondition(CombatLib.Offence.Melee.OffenceMelee AttackingPlayer, CombatLib.Defence.Melee.DMInfantry DefendingPlayer,
            ref CombatLib.Phases.PhaseWounds.PhaseWounds Wounds) //вычисляем табличное значение условия ранения в ближнем бою
        {
            int difference = AttackingPlayer.S - DefendingPlayer.T;
            if (difference >= 2) Wounds.Condition = 2;
            else if ((difference >= -3) && (difference <= 1))
            {
                if (difference <= -2) Wounds.Condition = 6;
                if (difference == -1) Wounds.Condition = 5;
                if (difference == 0) Wounds.Condition = 4;
                if (difference == 1) Wounds.Condition = 3;
            }
            else Wounds.Condition = 7;
            return Wounds.Condition;
        }
    }
}
