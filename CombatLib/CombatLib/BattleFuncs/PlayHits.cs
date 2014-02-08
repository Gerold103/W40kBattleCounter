using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib.BattleFuncs
{

//П О П А Д А Н И Я

    public static class PlayHits
    {
        public static int PlayRanged(CombatLib.Offence.Ranged.OffenceRanged AttackingPlayer, ref CombatLib.Phases.PhaseHits.PhaseHits Hits, ref Random RndGenerator) //Дальний бой, начальные данные берутся
        //из потомка OffenceDistant, результат записывается в экземпляр потомка класса PhaseHits, случайные числа получаются из экземпляра класса Random, возвращает количество попаданий
        {
            Console.WriteLine("PlayHits, Play Ranged");
            return 0;
        }

        public static int PlayMelee(CombatLib.Offence.Melee.OffenceMelee AttackingPlayer, ref CombatLib.Phases.PhaseHits.PhaseHits Hits, ref Random RndGenerator) //Ближний бой, начальные данные берутся
        //из потомка OffenceMelee, результат записывается в экземпляр потомка класса PhaseHits, случайные числа получаются из экземпляра класса Random, возвращает количество попаданий
        {
            Console.WriteLine("PlayHits, Play Melee");
            return 0;
        }
    }
}
