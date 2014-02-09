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
    }
}
