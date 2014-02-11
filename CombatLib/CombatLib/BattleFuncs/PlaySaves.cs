using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib.BattleFuncs
{

//С П А С Б Р О С К И

    public static class PlaySaves
    {
        public static int Play(ref CombatLib.Phases.PhaseWounds.PhaseWoundsInfantry Wounds, ref CombatLib.Phases.PhaseSaves.PhaseSavesInfantry Saves, ref Random RndGenerator) //Спасброски за пехоту, начальные данные
        //берутся из PhaseWoundsInfantry, результат записывается в PhaseSavesInfantry, случайные числа получаются из экземпляра класса Random, возвращает количество спасенных
        {
            Console.WriteLine("PlaySaves, aim - infantry"); //отладочный вывод
            int i; //счетчик всех попыток спасения
            Saves.SaveCubes = new int[Wounds.RowWounds]; //выделение памяти под массив кубов на спасброски. Количество бросков = количеству потенциальных ран

            for (i = 0; i < Wounds.RowWounds; i++)
            {
                Saves.SaveCubes[i] = RndGenerator.Next(1, 7);
                if (Saves.SaveCubes[i] >= Saves.Condition) Saves.Saves++;
            }
            Wounds.Wounds = Wounds.RowWounds - Saves.Saves; //Итоговое количество ран = разница между потенциальными и спасшимися
            return 0;
        }

        public static int Play(ref CombatLib.Phases.PhaseWounds.PhaseWoundsVehicle Wounds, ref CombatLib.Phases.PhaseSaves.PhaseSavesVehicle Saves, ref Random RndGenerator) //Спасброски за технику, начальные данные
        //берутся из PhaseWoundsVehicle, результат записывается в PhaseSavesVehicle, случайные числа получаются из экземпляра класса Random, возвращает количество спасенных
        {
            Console.WriteLine("PlaySaves, aim - vehicle");
            return 0;
        }
    }
}
