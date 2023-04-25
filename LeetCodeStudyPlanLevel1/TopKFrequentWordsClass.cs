using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlanLevel1
{
    internal class TopKFrequentWordsClass
    {
        /// <summary>
        /// 692. Top K Frequent Words
        /// https://leetcode.com/problems/top-k-frequent-words/?envType=study-plan&id=level-1
        /// 
        /// Given an array of strings words and an integer k, 
        /// return the k most frequent strings.
        /// 
        /// Return the answer sorted by the frequency from highest to lowest.
        /// Sort the words with the same frequency by their lexicographical order.
        /// </summary>
        /// <param name="words"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static IList<string> TopKFrequent(string[] words, int k)
        {
            List<string> result = new List<string>();

            var dict = words
                .GroupBy(x => x)
                .ToDictionary(k => k.Key, k => k.Count())
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key);

            int i = 0;

            foreach (var word in dict)
            {
                result.Add(word.Key);

                if (++i >= k)
                    break;
            }

            return result;
        }
    }
}
