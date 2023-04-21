using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlanLevel1
{
    internal class LongestRepeatingCharacterReplacement
    {
        /// <summary>
        /// 424. Longest Repeating Character Replacement
        /// https://leetcode.com/problems/longest-repeating-character-replacement/?envType=study-plan&id=level-1
        /// 
        /// You are given a string s and an integer k. 
        /// You can choose any character of the string 
        /// and change it to any other uppercase English character. 
        /// You can perform this operation at most k times.
        /// 
        /// Return the length of the longest substring 
        /// containing the same letter you can get 
        /// after performing the above operations.
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int Go(string s, int k)
        {
            int res = 0;
            int left = 0;
            int mostFrequent = 0;

            Dictionary<char, int> map = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (map.ContainsKey(s[i])) map[s[i]]++;
                else map.Add(s[i], 1);

                if (map[s[i]] > mostFrequent)
                    mostFrequent = map[s[i]];

                if (i - left + 1 - mostFrequent > k)
                {
                    map[s[left]]--;
                    left++;
                }

                if (i - left + 1 > res) 
                    res = i - left + 1;
            }

            return res;
        }
    }
}
