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
        /// <summary>
        /// Спасброски за пехоту
        /// </summary>
        /// <param name="Wounds"></param>
        /// <param name="Saves"></param>
        /// <param name="RndGenerator"></param>
        /// <returns></returns>
        public static int Play(CombatLib.Phases.PhaseWounds.PhaseWoundsInfantry Wounds, ref CombatLib.Phases.PhaseSaves.PhaseSavesInfantry Saves, ref Random RndGenerator) //Спасброски за пехоту, начальные данные
        //берутся из PhaseWoundsInfantry, результат записывается в PhaseSavesInfantry, случайные числа получаются из экземпляра класса Random, возвращает количество спасенных
        {
            Console.WriteLine("PlaySaves, aim - infantry");
            return 0;
        }

        /// <summary>
        /// Спасброски за технику
        /// </summary>
        /// <param name="Wounds"></param>
        /// <param name="Saves"></param>
        /// <param name="RndGenerator"></param>
        /// <returns></returns>
        public static int Play(CombatLib.Phases.PhaseWounds.PhaseWoundsVehicle Wounds, ref CombatLib.Phases.PhaseSaves.PhaseSavesVehicle Saves, ref Random RndGenerator) //Спасброски за технику, начальные данные
        //берутся из PhaseWoundsVehicle, результат записывается в PhaseSavesVehicle, случайные числа получаются из экземпляра класса Random, возвращает количество спасенных
        {
            Console.WriteLine("PlaySaves, aim - vehicle");
            return 0;
        }
    }
}
