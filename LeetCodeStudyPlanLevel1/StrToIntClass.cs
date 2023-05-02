using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlanLevel1
{
    internal class StrToIntClass
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int StringToInt(string s)
        {
            s = s.Trim();
            if (string.IsNullOrEmpty(s))
                return 0;
            var sign = 1;
            if (s.StartsWith("-"))
                sign = -1;

            var t = IsNumber(s);
            if (!t.Item1) return 0;
            var str = t.Item2;

            long res = 0;
            long k = 1;

            try
            {
                for (int i = str.Length - 1; i >= 0; i--)
                {
                    if (k > int.MaxValue)
                        throw new InvalidOperationException("Absolutely fucked up case!");

                    res += Nums[str[i]] * k;

                    if (res * sign > int.MaxValue)
                        return int.MaxValue;
                    if (res * sign < int.MinValue)
                        return int.MinValue;

                    k *= 10;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return sign > 0 ? int.MaxValue : int.MinValue;
            }

            return (int)res * sign;
        }

        static (bool, string) IsNumber(string value)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            bool hasSign = false;
            for (i = 0; i < value.Length; i++)
            {
                if (value[i] == '+' || value[i] == '-')
                {
                    if (!hasSign)
                    {
                        hasSign = true;
                        continue;
                    }
                    else return (false, string.Empty);
                }
                else if (Char.IsDigit(value[i]))
                {
                    break;
                }
                else
                    return (false, string.Empty);
            }

            for (int k = i; k < value.Length; k++)
            {
                if (!Char.IsDigit(value[k]))
                    break;
                sb.Append(value[k]);
            }

            var text = sb.ToString();

            if (text.StartsWith('0'))
                text = text.TrimStart('0');

            return (true, text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Obsolete]
        static string DigitsOnly(string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in input)
            {
                if (Char.IsNumber(c))
                    sb.Append(c);
                else break;
            }
            return sb.ToString();
        }

        static Dictionary<char, int> Nums = new Dictionary<char, int>()
            {
                { '0', 0 },
                { '1', 1},
                { '2', 2},
                { '3', 3},
                { '4', 4},
                { '5', 5},
                { '6', 6},
                { '7', 7},
                { '8', 8},
                { '9', 9},
            };

        static Dictionary<uint, char> Digits = new Dictionary<uint, char>()
            {
                { 0, '0' },
                { 1, '1' },
                { 2, '2' },
                { 3, '3' },
                { 4, '4' },
                { 5, '5' },
                { 6, '6' },
                { 7, '7' },
                { 8, '8' },
                { 9, '9' },
            };

        /// <summary>
        /// IntToString
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string IntToString(uint value)
        {
            if (value == 0) return "0";
            // int.MaxValue = 2 147 483 647
            uint k = 1, o;
            List<char> chars = new List<char>();

            while (k > 0)
            {
                k = value / 10;
                o = value % 10;

                if (o > 0 || k > 0)
                {
                    chars.Add(Digits[o]);
                    value = (value - o) / 10;
                }
            }

            chars.Reverse();

            return string.Join("", chars);
        }
    }
}
