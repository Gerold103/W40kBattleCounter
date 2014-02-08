using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib.BattleFuncs
{

//Р А Н Ы

    public static class PlayWounds
    {

//Д А Л Ь Н И Й   Б О Й

        public static int RangedPlay(CombatLib.Offence.Ranged.OffenceRanged AttackingPlayer, CombatLib.Defence.Ranged.DRInfantry DefendingPlayer, CombatLib.Phases.PhaseHits.PhaseHitsInfantry Hits,
            ref CombatLib.Phases.PhaseWounds.PhaseWoundsInfantry Wounds, ref Random RndGenerator) //Дальний бой против пехоты, начальные данные берутся из потомка OffenceRanged, DRInfantry, PhaseHitsInfantry,
        //результат записывается в экземпляр класса PhaseWoundsInfantry,
        //случайные числа получаются из экземпляра класса Random, возвращает общее количество ран
        {
            Console.WriteLine("PlayWounds, RangedPlay, aim - infantry");
            return 0;
        }

        public static int RangedPlay(CombatLib.Offence.Ranged.OffenceRanged AttackingPlayer, CombatLib.Defence.Ranged.DRVehicle DefendingPlayer, CombatLib.Phases.PhaseHits.PhaseHitsVehicle Hits,
            ref CombatLib.Phases.PhaseWounds.PhaseWoundsVehicle Wounds, ref Random RndGenerator) //Дальний бой против техники, начальные данные берутся из потомка OffenceRanged, DRVehicle, PhaseHitsVehicle,
        //результат записывается в экземпляр класса PhaseWoundsVehicle,
        //случайные числа получаются из экземпляра класса Random, возвращает общее количество ран
        {
            Console.WriteLine("PlayWounds, RangedPlay, aim - vehicle");
            return 0;
        }

//Б Л И Ж Н И Й   Б О Й

        public static int MeleePlay(CombatLib.Offence.Melee.OffenceMelee AttackingPlayer, CombatLib.Defence.Melee.DMInfantry DefendingPlayer, CombatLib.Phases.PhaseHits.PhaseHitsInfantry Hits,
            ref CombatLib.Phases.PhaseWounds.PhaseWoundsInfantry Wounds, ref Random RndGenerator) //Ближний бой против пехоты, начальные данные берутся из потомка OffenceMelee, DMInfantry, PhaseHitsInfantry,
        //результат записывается в экземпляр класса PhaseWoundsInfantry,
        //случайные числа получаются из экземпляра класса Random, возвращает общее количество ран
        {
            Console.WriteLine("PlayWounds, MeleePlay, aim - infantry");
            return 0;
        }

        public static int MeleePlay(CombatLib.Offence.Melee.OffenceMelee AttackingPlayer, CombatLib.Defence.Melee.DMVehicle DefendingPlayer, CombatLib.Phases.PhaseHits.PhaseHitsVehicle Hits,
            ref CombatLib.Phases.PhaseWounds.PhaseWoundsVehicle Wounds, ref Random RndGenerator) //Ближний бой против техники, начальные данные берутся из потомка OffenceMelee, DMVehicle, PhaseHitsVehicle,
        //результат записывается в экземпляр класса PhaseWoundsVehicle,
        //случайные числа получаются из экземпляра класса Random, возвращает общее количество ран
        {
            Console.WriteLine("PlayWounds, MeleePlay, aim - vehicle");
            return 0;
        }
    }
}
