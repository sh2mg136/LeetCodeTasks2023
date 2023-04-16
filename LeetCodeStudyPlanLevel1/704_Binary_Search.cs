using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlanLevel1
{
    internal class CBinarySearch
    {
        /// <summary>
        /// 704. Binary Search
        /// 
        /// https://leetcode.com/problems/binary-search/?envType=study-plan&id=level-1
        /// 
        /// Given an array of integers nums which is sorted in ascending order, 
        /// and an integer target, write a function to search target in nums. 
        /// If target exists, then return its index. Otherwise, return -1.
        /// 
        /// You must write an algorithm with O(log n) runtime complexity.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            // return Search_1(nums, target);
            return Search_2(nums, target);
        }

        public int Search_1(int[] nums, int target)
        {
            if (!nums.Contains(target)) return -1;

            int cnt = 0;

            foreach (int i in nums)
            {
                if (i == target) break;
                cnt++;
            }

            return cnt;
        }

        public int Search_2(int[] nums, int target)
        {
            if (!nums.Contains(target)) return -1;

            int cnt = 0;
            int j;

            for (int i = 0; i < nums.Length / 2; i++)
            {
                if (nums[i] == target) break;
                j = nums.Length - cnt - 1;
                if (nums[j] == target)
                    return nums.Length - cnt - 1;
                cnt++;
            }

            return cnt;
        }

    }
}
