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
            Console.WriteLine("PlayHits, Play Ranged"); //отладочный вывод

            CombatLib.Addition.AdditionalFuncs.RangedHitConditions(AttackingPlayer, ref Hits); //вычисляем условия попадания, включая добавочное, на основе данных из класса нападающего

            int i, j; //j - счетчик бросков на попадание без учета перебрасываний, i - счетчик всех бросков на попадания и нулей, обозначающих переброс
            Hits.HitCubes = new int[AttackingPlayer.A]; //выделение памяти под массив кубов на попадание. Количество элементов = количеству атак

            for (j = 0, i = 0; j < AttackingPlayer.A; j++) //цикл бросков кубов
            {
                Hits.HitCubes[i] = RndGenerator.Next(1, 7);
                if (Hits.HitCubes[i] >= Hits.Condition) Hits.Hits++;
                else if (Hits.AdditionalCondition < 7)
                {
                    i++;
                    Hits.HitCubes[i] = 0; //отмечаем, что куб был переброшен, добавляя 0 и изменяя счетчик бросков i
                    i++;
                    Hits.HitCubes[i] = RndGenerator.Next(1, 7);
                    if (Hits.HitCubes[i] >= Hits.AdditionalCondition) Hits.Hits++;
                }
                i++;
            }
            Hits.HitCubesStr = CombatLib.Addition.AdditionalFuncs.ReduceCubesToStr(Hits.HitCubes); //преобразуем кубы на попадание в строку
            return Hits.Hits;
        }

        public static int PlayMelee(CombatLib.Offence.Melee.OffenceMelee AttackingPlayer, CombatLib.Defence.Melee.DefenceMelee DefendingPlayer, ref CombatLib.Phases.PhaseHits.PhaseHits Hits,
            ref Random RndGenerator) //Ближний бой, начальные данные берутся из потомка OffenceMelee, результат записывается в экземпляр потомка класса PhaseHits, случайные числа получаются из
            //экземпляра класса Random, возвращает количество попаданий
        {
            Console.WriteLine("PlayHits, Play Melee"); //отладочный вывод

            CombatLib.Addition.AdditionalFuncs.MeleeHitCondition(AttackingPlayer, DefendingPlayer, ref Hits); ////вычисляем условие попадания

            int i, j; //j - счетчик бросков на попадание без учета перебрасываний, i - счетчик всех бросков на попадания и нулей, обозначающих переброс
            Hits.HitCubes = new int[AttackingPlayer.A]; //выделение памяти под массив кубов на попадание. Количество элементов = количеству атак

            for (i = 0, j = 0; j < AttackingPlayer.A; j++) //цикл бросков кубов
            {
                Hits.HitCubes[i] = RndGenerator.Next(1, 7);
                if (Hits.HitCubes[i] >= Hits.Condition) Hits.Hits++;
                else if (Hits.AdditionalCondition < 7)
                {
                    i++;
                    Hits.HitCubes[i] = 0; //отмечаем, что куб был переброшен, добавляя 0 и изменяя счетчик бросков i
                    i++;
                    Hits.HitCubes[i] = RndGenerator.Next(1, 7);
                    if (Hits.HitCubes[i] >= Hits.AdditionalCondition) Hits.Hits++;
                }
                i++;
            }
            Hits.HitCubesStr = CombatLib.Addition.AdditionalFuncs.ReduceCubesToStr(Hits.HitCubes); //преобразуем кубы на ранения в строку
            return Hits.Hits;
        }
    }
}
