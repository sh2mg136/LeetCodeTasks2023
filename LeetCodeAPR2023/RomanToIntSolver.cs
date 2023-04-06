using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeAPR2023
{
    /// <summary>
    /// Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
    /// 
    /// Symbol       Value
    /// I             1
    /// V             5
    /// X             10
    /// L             50
    /// C             100
    /// D             500
    /// M             1000
    /// 
    /// </summary>
    internal class RomanToIntSolver
    {

        private readonly Dictionary<char, int> dict = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
         };

        public int RomanToInt(string s)
        {
            // if (FirstTwenty.ContainsKey(s)) return FirstTwenty[s];

            char[] ch = s.ToCharArray();
            int result = 0;
            int num, next;

            for (int i = 0; i < ch.Length; i++)
            {
                num = dict[ch[i]];

                if (i < ch.Length - 1)
                {
                    next = dict[ch[i + 1]];

                    if (next > num)
                    {
                        num = next - num;
                        i++;
                    }
                }

                result += num;
            }

            return result;
        }

        public readonly Dictionary<string, int> FirstTwenty = new Dictionary<string, int>
        {
            { "I", 1 },
            { "II", 2 },
            { "III", 3 },
            { "IV", 4 },
            { "V", 5 },
            { "VI", 6 },
            { "VII", 7 },
            { "VIII", 8 },
            { "IX", 9 },
            { "X", 10 },
            { "XI", 11 },
            { "XII", 12 },
            { "XIII", 13 },
            { "XIV", 14 },
            { "XV", 15 },
            { "XVI", 16 },
            { "XVII", 17 },
            { "XVIII", 18 },
            { "XIX", 19 },
            { "XX", 20 },
         };

    }
}
