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
            Console.WriteLine("PlayWounds, RangedPlay, aim - infantry"); //отладочный вывод

            CombatLib.Phases.PhaseWounds.PhaseWounds baseWounds = Wounds; //создаем указатель на базовый класс для класса фазы ран пехоты, чтобы передать его в функцию
            CombatLib.Addition.AdditionalFuncs.RangedWoundCondition(AttackingPlayer, DefendingPlayer, ref baseWounds); //вычисляем условие ранения

            int i; //счетчик всех бросков на раны
            Wounds.WoundCubes = new int[Hits.Hits]; //выделяем память под массив кубов ран

            for (i = 0; i < Hits.Hits; i++) //цикл бросков кубов
            {
                Wounds.WoundCubes[i] = RndGenerator.Next(1, 7);
                if (Wounds.WoundCubes[i] >= Wounds.Condition) Wounds.RowWounds++;
            }
            Wounds.WoundCubesStr = CombatLib.Addition.AdditionalFuncs.ReduceCubesToStr(Wounds.WoundCubes); //преобразуем кубы на раны в строку
            return Wounds.RowWounds;
        }

        public static int RangedPlay(CombatLib.Offence.Ranged.OffenceRanged AttackingPlayer, CombatLib.Defence.Ranged.DRVehicle DefendingPlayer, CombatLib.Phases.PhaseHits.PhaseHitsVehicle Hits,
            ref CombatLib.Phases.PhaseWounds.PhaseWoundsVehicle Wounds, ref Random RndGenerator) //Дальний бой против техники, начальные данные берутся из потомка OffenceRanged, DRVehicle, PhaseHitsVehicle,
        //результат записывается в экземпляр класса PhaseWoundsVehicle,
        //случайные числа получаются из экземпляра класса Random, возвращает общее количество ран
        {
            Console.WriteLine("PlayWounds, RangedPlay, aim - vehicle"); //отладочный вывод

            CombatLib.Phases.PhaseWounds.PhaseWounds baseWounds = Wounds; //создаем указатель на базовый класс для класса фазы ран техники, чтобы передать его в функцию
            CombatLib.Addition.AdditionalFuncs.VehicleWoundCondition(DefendingPlayer, ref baseWounds); //вычисляем условие ранения

            int i; //счетчик всех бросков на раны
            Wounds.WoundCubes = new int[Hits.Hits]; //выделяем память под массив кубов ран

            for (i = 0; i < Hits.Hits; i++) //цикл бросков кубов
            {
                Wounds.WoundCubes[i] = RndGenerator.Next(1, 7);
                if (Wounds.WoundCubes[i] + AttackingPlayer.S < Wounds.Condition) continue; //если куб + сила атакующего меньше условия попадания, то ничего не происходит
                else if (Wounds.WoundCubes[i] + AttackingPlayer.S == Wounds.Condition) Wounds.RowSlidingWounds++; //если эта величина равна условию попадания, то ранение по технике засчитывается,
                                                                                                                  //скользящее
                else Wounds.RowPunchedWounds++; //если больше, то ранение - пробивающее
            }
            Wounds.RowWounds = Wounds.RowPunchedWounds + Wounds.RowSlidingWounds;
            Wounds.WoundCubesStr = CombatLib.Addition.AdditionalFuncs.ReduceCubesToStr(Wounds.WoundCubes); //преобразуем кубы на раны в строку
            return Wounds.RowWounds;
        }

//Б Л И Ж Н И Й   Б О Й

        public static int MeleePlay(CombatLib.Offence.Melee.OffenceMelee AttackingPlayer, CombatLib.Defence.Melee.DMInfantry DefendingPlayer, CombatLib.Phases.PhaseHits.PhaseHitsInfantry Hits,
            ref CombatLib.Phases.PhaseWounds.PhaseWoundsInfantry Wounds, ref Random RndGenerator) //Ближний бой против пехоты, начальные данные берутся из потомка OffenceMelee, DMInfantry, PhaseHitsInfantry,
        //результат записывается в экземпляр класса PhaseWoundsInfantry,
        //случайные числа получаются из экземпляра класса Random, возвращает общее количество ран
        {
            Console.WriteLine("PlayWounds, MeleePlay, aim - infantry");

            CombatLib.Phases.PhaseWounds.PhaseWounds baseWounds = Wounds; //создаем указатель на базовый класс для класса фазы ран пехоты, чтобы передать его в функцию
            CombatLib.Addition.AdditionalFuncs.MeleeWoundCondition(AttackingPlayer, DefendingPlayer, ref baseWounds); //вычисляем условие ранения

            int i; //счетчик всех бросков на раны
            Wounds.WoundCubes = new int[Hits.Hits]; //выделяем память под массив кубов ран

            for (i = 0; i < Hits.Hits; i++) //цикл бросков кубов
            {
                Wounds.WoundCubes[i] = RndGenerator.Next(1, 7);
                if (Wounds.WoundCubes[i] >= Wounds.Condition) Wounds.RowWounds++;
            }
            Wounds.WoundCubesStr = CombatLib.Addition.AdditionalFuncs.ReduceCubesToStr(Wounds.WoundCubes); //преобразуем кубы на раны в строку
            return Wounds.RowWounds;
        }

        public static int MeleePlay(CombatLib.Offence.Melee.OffenceMelee AttackingPlayer, CombatLib.Defence.Melee.DMVehicle DefendingPlayer, CombatLib.Phases.PhaseHits.PhaseHitsVehicle Hits,
            ref CombatLib.Phases.PhaseWounds.PhaseWoundsVehicle Wounds, ref Random RndGenerator) //Ближний бой против техники, начальные данные берутся из потомка OffenceMelee, DMVehicle, PhaseHitsVehicle,
        //результат записывается в экземпляр класса PhaseWoundsVehicle,
        //случайные числа получаются из экземпляра класса Random, возвращает общее количество ран
        {
            Console.WriteLine("PlayWounds, MeleePlay, aim - vehicle");

            CombatLib.Phases.PhaseWounds.PhaseWounds baseWounds = Wounds; //создаем указатель на базовый класс для класса фазы ран техники, чтобы передать его в функцию
            CombatLib.Addition.AdditionalFuncs.VehicleWoundCondition(DefendingPlayer, ref baseWounds); //вычисляем условие ранения

            int i; //счетчик всех бросков на раны
            Wounds.WoundCubes = new int[Hits.Hits]; //выделяем память под массив кубов ран

            for (i = 0; i < Hits.Hits; i++) //цикл бросков кубов
            {
                Wounds.WoundCubes[i] = RndGenerator.Next(1, 7);
                if (Wounds.WoundCubes[i] + AttackingPlayer.S < Wounds.Condition) continue; //если куб + сила атакующего меньше условия попадания, то ничего не происходит
                else if (Wounds.WoundCubes[i] + AttackingPlayer.S == Wounds.Condition) Wounds.RowSlidingWounds++; //если эта величина равна условию попадания, то ранение по технике засчитывается,
                //скользящее
                else Wounds.RowPunchedWounds++; //если больше, то ранение - пробивающее
            }
            Wounds.RowWounds = Wounds.RowPunchedWounds + Wounds.RowSlidingWounds;
            Wounds.WoundCubesStr = CombatLib.Addition.AdditionalFuncs.ReduceCubesToStr(Wounds.WoundCubes); //преобразуем кубы на раны в строку
            return Wounds.RowWounds;
        }
    }
}
