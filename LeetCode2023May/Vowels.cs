using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2023May
{
    internal class Vowels
    {
        /// <summary>
        /// 1456. Maximum Number of Vowels in a Substring of Given Length
        /// https://leetcode.com/problems/maximum-number-of-vowels-in-a-substring-of-given-length/
        /// 
        /// Given a string s and an integer k, 
        /// return the maximum number of vowel letters in any substring of s with length k.
        /// 
        /// Vowel letters in English are 'a', 'e', 'i', 'o', and 'u'.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int MaxVowels(string s, int k)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;
            if (s.Length < k) return 0;

            var res = 0;
            // int m = CountVowels(s.Substring(0, k));
            int m = 0;

            Stopwatch sw = new Stopwatch();

            sw.Start();
            m = s.Substring(0, k).Where(x => VowelsList.Contains(x)).Count();
            sw.Stop();
            Debug.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            m = (from t in s.Substring(0, k) join r in VowelsList on t equals r select r).Count();
            sw.Stop();
            Debug.WriteLine(sw.ElapsedMilliseconds);

            if (m > res) res = m;

            for (int i = k; i < s.Length; i++)
            {
                if (m > 0 && VowelsList.Contains(s[i - k]))
                    m--;

                if (VowelsList.Contains(s[i]))
                    m++;

                if (m > res) res = m;
            }

            return res;
        }

        static char[] VowelsList = new char[] { 'a', 'e', 'i', 'o', 'u' };

        private static int CountVowels(string s)
        {
            int i = 0;
            foreach (char ch in s)
            {
                if (VowelsList.Contains(ch)) i++;
            }
            return i;
        }
    }
}
