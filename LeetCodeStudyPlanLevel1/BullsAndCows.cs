using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlanLevel1
{
    internal class BullsAndCows
    {
        /// <summary>
        /// 299. Bulls and Cows
        /// https://leetcode.com/problems/bulls-and-cows/?envType=study-plan&id=level-1
        /// </summary>
        /// <param name="secret"></param>
        /// <param name="guess"></param>
        /// <returns></returns>
        public static string GetHint(string secret, string guess)
        {
            int bulls = 0;
            Dictionary<char, int> sMap = new Dictionary<char, int>();
            Dictionary<char, int> gMap = new Dictionary<char, int>();

            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                {
                    bulls++;
                }
                else
                {
                    if (sMap.ContainsKey(secret[i])) sMap[secret[i]]++;
                    else sMap.Add(secret[i], 1);

                    if (gMap.ContainsKey(guess[i])) gMap[guess[i]]++;
                    else gMap.Add(guess[i], 1);
                }
            }

            var cows = 0;
            foreach (var p in gMap)
            {
                if (sMap.ContainsKey(p.Key))
                {
                    cows += Math.Min(sMap[p.Key], gMap[p.Key]);
                }
            }

            return $"{bulls}A{cows}B";
        }

        /// <summary>
        /// ByteToString
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ByteToString(int value)
        {
            StringBuilder builder = new StringBuilder(sizeof(byte) * 8);
            BitArray[] bitArrays = BitConverter.GetBytes(value).Reverse().Select(b => new BitArray(new[] { b })).ToArray();
            foreach (bool bit in bitArrays.SelectMany(bitArray => bitArray.Cast<bool>().Reverse()))
            {
                builder.Append(bit ? '1' : '0');
            }
            return builder.ToString();
        }

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
