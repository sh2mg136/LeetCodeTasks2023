using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
            // return Search_2(nums, target);
            return Search_3(nums, target);
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

        public int Search_3(int[] nums, int target)
        {
            if (!nums.Contains(target)) return -1;
            
            int j;

            for (int i = 0; i < nums.Length / 2; i++)
            {
                if (nums[i] == target) 
                    return i;
                
                j = nums.Length - i - 1;

                if (nums[j] == target)
                    return nums.Length - i - 1;
            }

            return -1;
        }

    }

    class VerControl
    {
        public Dictionary<int, bool> Dict = new Dictionary<int, bool>() { { 1, true } };

        Random Rnd = new Random();

        public VerControl()
        {
        }


        public void GenerateData()
        {
            Dict = new Dictionary<int, bool>();

            for (int i = 1; i < Rnd.Next(2, 100); i++)
            {
                Dict.Add(i, false);
            }

            for (int i = Dict.Count + 1; i < Dict.Count + Rnd.Next(1, 10); i++)
            {
                Dict.Add(i, true);
            }
        }


        public bool IsBadVersion(int n)
        {
            if (!Dict.ContainsKey(n))
                return false;
            return Dict[n];
        }
    }

    class VC : VerControl
    {

        public int FirstBadVersion(int n)
        {
            while (n > 0)
            {
                if (!IsBadVersion(n))
                    return n + 1;
                n--;
            }
            return n + 1;
        }

        public int FirstBadVersion3(int n)
        {
            int l = 0;
            int r = n;

            while (true)
            {
                int m = l + (r - l) / 2;
                if (!IsBadVersion(m))
                {
                    l = m + 1;
                }
                else if (IsBadVersion(m - 1))
                {
                    r = m - 1;
                }
                else
                {
                    return m;
                }
            }
        }

        public int FirstBadVersion4(int n)
        {
            int cnt = 1;

            if (IsBadVersion(cnt)) return cnt;

            while (n > 0)
            {
                if (IsBadVersion(++cnt))
                {
                    return cnt;
                }
                else if (!IsBadVersion(n))
                {
                    return n + 1;
                }

                n--;
            }

            return cnt;
        }

        public int FirstBadVersion2(int n)
        {
            int j = n;
            if (n == 1)
            {
                return IsBadVersion(n) ? 1 : 0;
            }
            else
            {
                while (j > 0)
                {
                    if (!IsBadVersion(j))
                        return j + 1;
                    j--;
                }
            }
            return 0;
        }
    }
}
