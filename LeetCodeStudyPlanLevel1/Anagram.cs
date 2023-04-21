using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlanLevel1
{
    internal class Anagram
    {
        /// <summary>
        /// 438. Find All Anagrams in a String
        /// 
        /// https://leetcode.com/problems/find-all-anagrams-in-a-string/?envType=study-plan&id=level-1
        /// 
        /// Given two strings s and p, 
        /// return an array of all the start indices of p's anagrams in s. 
        /// You may return the answer in any order.
        /// 
        /// An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, 
        /// typically using all the original letters exactly once.
        /// 
        /// Example 1:
        /// Input: s = "cbaebabacd", p = "abc"
        /// Output: [0,6]
        /// Explanation:
        /// The substring with start index = 0 is "cba", which is an anagram of "abc".
        /// The substring with start index = 6 is "bac", which is an anagram of "abc".
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static IList<int> FindAnagrams(string s, string p)
        {
            var res = new List<int>();

            var len = p.Length;
            if (len > s.Length) return res;

            var pMap = getMap(p);

            var sub = s.Substring(0, len);
            var sMap = getMap(sub);
            if (areEqual(sMap, pMap))
                res.Add(0);

            for (int i = 1; i <= s.Length - len; i++)
            {
                var ch = sub.First();

                sub = s.Substring(i, len);

                if (sMap[ch] == 1) sMap.Remove(ch);
                else sMap[ch]--;

                ch = sub.Last();
                if (sMap.ContainsKey(ch)) sMap[ch]++;
                else sMap.Add(ch, 1);

                if (areEqual(sMap, pMap))
                    res.Add(i);
            }

            return res;
        }

        static Dictionary<char, int> getMap(string s)
        {
            return s.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        }

        static bool areEqual(Dictionary<char, int> smap, Dictionary<char, int> pmap)
        {
            foreach (var m in pmap)
            {
                if (!smap.ContainsKey(m.Key))
                    return false;
            }

            foreach (var m in smap)
            {
                if (!pmap.ContainsKey(m.Key))
                    return false;

                if (m.Value != pmap[m.Key])
                    return false;
            }
            return true;
        }

        static bool areEqual_Slow(string s, string p)
        {
            var a = s.Distinct().ToArray();
            var b = p.Distinct().ToArray();

            if (!a.All(x => b.Contains(x))) return false;

            if (!b.All(x => a.Contains(x))) return false;

            foreach (var ch in a)
            {
                if (s.Where(x => x == ch).Count() != p.Where(x => x == ch).Count())
                    return false;
            }

            return true;
        }

        static int calc(string s)
        {
            int res = 0;
            foreach (var ch in s)
                res += ch;
            return res;
        }
    }
}
