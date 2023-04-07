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
    internal class RomanNumeralsSolver
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


        /// <summary>
        /// Given an integer, convert it to a roman numeral.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string IntToRoman(int num)
        {
            // if (FirstTwenty.ContainsValue(num)) return FirstTwenty.Where(x => x.Value == num).First().Key;

            string res = "";
            // 21 -> XXI
            // 22 -> XXII
            // 1994 -> MCMXCIV

            var D = new Dictionary<int, string>
            {
                { 1000, "M" },
                { 900,  "CM" },
                { 500,  "D" },
                { 400,  "CD" },
                { 100,  "C" },
                { 90,   "XC" },
                { 50,   "L" },
                { 40,   "XL" },
                { 10,   "X" },
                { 9,    "IX" },
                { 5,    "V" },
                { 4,    "IV" },
                { 1,    "I" },
            };

            int cnt = 0;

            foreach ( var x in D )
            {
                cnt = num / x.Key;
                if (cnt > 0)
                {
                    for (int i = 0; i < cnt; i++) res += x.Value;
                    num -= cnt * x.Key;
                }
            }

            /*
            cnt = num / 1000;
            for (int i = 0; i < cnt; i++) res += "M";
            num -= cnt * 1000;

            cnt = num / 900;
            for (int i = 0; i < cnt; i++) res += "CM";
            num -= cnt * 900;

            cnt = num / 500;
            for (int i = 0; i < cnt; i++) res += "D";
            num -= cnt * 500;

            cnt = num / 400;
            for (int i = 0; i < cnt; i++) res += "CD";
            num -= cnt * 400;

            cnt = num / 100;
            for (int i = 0; i < cnt; i++) res += "C";
            num -= cnt * 100;

            cnt = num / 90;
            for (int i = 0; i < cnt; i++) res += "XC";
            num -= cnt * 90;

            cnt = num / 50;
            for (int i = 0; i < cnt; i++) res += "L";
            num -= cnt * 50;

            cnt = num / 40;
            for (int i = 0; i < cnt; i++) res += "XL";
            num -= cnt * 40;
            */

            return res;
        }



    }
}
