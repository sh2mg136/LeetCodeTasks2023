using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2023May
{
    internal class Three_3_Sum
    {
        /// <summary>
        /// 15. 3Sum
        /// https://leetcode.com/problems/3sum/
        /// 
        /// Given an integer array nums, 
        /// return all the triplets [nums[i], nums[j], nums[k]] 
        /// such that i != j, i != k, and j != k, 
        /// and nums[i] + nums[j] + nums[k] == 0.
        /// 
        /// Notice that the solution set must not contain duplicate triplets.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            var res = new List<IList<int>>();

            Array.Sort(nums);

            int i = 0, l, r;

            foreach (var a in nums)
            {
                if (i > 0 && a == nums[i - 1])
                {
                    i++;
                    continue;
                }

                l = i + 1;
                r = nums.Length - 1;

                while (l < r)
                {
                    var sum3 = a + nums[l] + nums[r];

                    if (sum3 < 0) l++;
                    else if (sum3 > 0) r--;
                    else
                    {
                        res.Add(new List<int>() { a, nums[l], nums[r] });

                        l++;
                        while (nums[l] == nums[l - 1] && l < r)
                            l++;
                    }
                }

                i++;
            }

            return res;
        }
    }
}
