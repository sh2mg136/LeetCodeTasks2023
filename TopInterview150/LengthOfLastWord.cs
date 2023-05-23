using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterview150
{
    internal class LengthOfLastWord
    {
        public static int GetLengthOfLastWord(string s)
        {
            var arr = s.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (!arr.Any()) return 0;
            return arr.Last().Length;
        }
    }
}
