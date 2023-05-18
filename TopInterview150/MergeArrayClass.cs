using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterview150
{
    internal class MergeArrayClass
    {
        /// <summary>
        /// 88. Merge Sorted Array
        /// 
        /// You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, 
        /// and two integers m and n, representing the number of elements in nums1 and nums2 respectively.
        /// Merge nums1 and nums2 into a single array sorted in non-decreasing order.
        /// 
        /// https://leetcode.com/problems/merge-sorted-array/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (nums2 == null || nums2.Length == 0)
                return;

            /*
            var l1 = nums1.Take(m).ToList();
            l1.AddRange(nums2.ToList());
            l1.Sort();
            for (int i = 0; i < m + n; i++) { nums1[i] = l1[i]; }
            Debug.Assert(nums1.Count == m);
            */

            var cnt = m + n;
            var t = cnt - 1;

            var l = m > 0 ? m - 1 : 0;
            var r = n > 0 ? n - 1 : 0;

            var m1 = nums1.Max();

            while (l >= 0 && r >= 0)
            {
                if (nums1[l] > nums2[r])
                {
                    nums1[t] = nums1[l];
                    l--;
                }
                else
                {
                    nums1[t] = nums2[r];
                    r--;
                }
                t--;
            }

            while (r >= 0)
            {
                nums1[r] = nums2[r];
                r--;
            }


            /*
            for (int i = nums2.Length - 1; i >= 0; i--)
            {
                if (nums2[i] >= nums1[l])
                {
                    nums1[t] = nums2[i];
                    n--;
                    t--;
                }
                else
                {
                    nums1[t] = nums1[l];
                    nums1[l] = nums2[i];
                    n--;
                    t--;

                    while (l > 0 && nums1[l] < nums1[l - 1])
                    {
                        (nums1[l], nums1[l - 1]) = (nums1[l - 1], nums1[l]);
                        n--;
                        t--;
                        if (l > 0) l--;
                    }
                }
            }
            */

            Debug.WriteLine(string.Join(", ", nums1));

            Debug.Assert(nums1 != null && nums1.Count() == cnt);
        }
    }
}