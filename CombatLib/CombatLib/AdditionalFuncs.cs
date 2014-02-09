using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatLib
{
    public class AdditionalFuncs
    {
        private static void CheckStr(int[] arg)
        {
            int prevElem = 0;
            foreach (int elem in arg)
            {
                if (arg[0] == 0 || arg[arg.Length - 1] == 0 || prevElem + elem == 0) throw new ApplicationException("Wrong Input");
                prevElem = elem;
            }
        }
        public static string ReduceCubesToStr(int[] arg)
        {
            CheckStr(arg);
            String res = "";
            foreach (int elem in arg)
            {
                if (elem != 0) res += (char)(elem + '0');
                else
                {
                    res += '-';
                    res += '>';
                }
                res += ' ';
            }
            return res;
        }
    }
}
