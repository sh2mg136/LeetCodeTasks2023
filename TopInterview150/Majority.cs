using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TopInterview150
{
    internal class Majority
    {
        /// <summary>
        /// 169. Majority Element
        /// 
        /// https://leetcode.com/problems/majority-element/?envType=study-plan-v2&id=top-interview-150
        /// 
        /// Given an array nums of size n, return the majority element.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MajorityElement(int[] nums)
        {
            // return MajorityElement_V1(nums);
            // return MajorityElement_V2(nums);
            return MajorityElement_V3(nums);
        }

        public static int MajorityElement_V3(int[] nums)
        {
            return nums?.GroupBy(x => x)?.MaxBy(x => x.Count())?.Key ?? 0;
        }

        public static int MajorityElement_V2(int[] nums)
        {
            var list = nums.GroupBy(x => x).Select(g => new { g.Key, Cnt = g.Count() }).ToList();
            var res = 0;
            if (list != null)
                res = list.MaxBy(x => x.Cnt)?.Key ?? 0;
            return res;
        }

        public static int MajorityElement_V1(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];

            Dictionary<int, int> map = new Dictionary<int, int>();
            int max = 0, res = 0;

            foreach (int num in nums)
            {
                if (map.ContainsKey(num))
                {
                    map[num]++;
                }
                else map.Add(num, 1);

                if (map[num] > max)
                {
                    max = map[num];
                    res = num;
                }
            }

            return res;
        }
    }
}
