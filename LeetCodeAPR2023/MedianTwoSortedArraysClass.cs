using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeAPR2023
{
    /// <summary>
    /// 4. Median of Two Sorted Arrays
    /// https://leetcode.com/problems/median-of-two-sorted-arrays/
    /// </summary>
    internal class MedianTwoSortedArraysClass
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var mrg = nums1
                .Concat(nums2)
                .OrderBy(x => x)
                .ToArray();

            var tcnt = mrg.Count();
            int n = tcnt / 2;

            if (tcnt == 1)
            {
                return mrg[0];
            }
            else if (tcnt % 2 == 0)
            {
                return ((double)mrg[n - 1] + mrg[n]) / 2;
            }
            else
            {
                return (double)mrg[n];
            }
        }
    }
}
