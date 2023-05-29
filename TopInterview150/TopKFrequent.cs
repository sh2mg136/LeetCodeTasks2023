using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterview150
{
    internal class TopKFrequentElements
    {
        /// <summary>
        /// 347. Top K Frequent Elements
        /// 
        /// Given an integer array nums and an integer k, 
        /// return the k most frequent elements. 
        /// You may return the answer in any order.
        /// 
        /// https://leetcode.com/problems/top-k-frequent-elements/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
                        
            foreach (int num in nums)
            {
                if (map.ContainsKey(num)) map[num]++;
                else map.Add(num, 1);
            }

            var res = map.OrderByDescending(x => x.Value).Take(k).Select(x=>x.Key).ToArray();

            return res;
        }
    }
}
