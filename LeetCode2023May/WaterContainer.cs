using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace LeetCode2023May
{
    internal class WaterContainer
    {
        /// <summary>
        /// 11. Container With Most Water
        /// https://leetcode.com/problems/container-with-most-water/
        /// You are given an integer array height of length n. 
        /// There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).
        /// 
        /// Find two lines that together with the x-axis form a container, such that the container contains the most water.
        /// 
        /// Return the maximum amount of water a container can store.
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public static int MaxArea(int[] height)
        {
            // return MaxArea_BruteForce(height);
            return MaxArea_Linear(height);
        }

        /// <summary>
        /// BruteForce sol.
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        private static int MaxArea_BruteForce(int[] height)
        {
            int res = 0, area;

            for (int i = 0; i < height.Length; i++)
            {
                for (int j = i + 1; j < height.Length; j++)
                {
                    area = (j - i) * Math.Min(height[i], height[j]);
                    if (area > res) res = area;
                }
            }

            return res;
        }

        /// <summary>
        /// O(n)
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        private static int MaxArea_Linear(int[] height)
        {
            int res = 0, area;
            var (l, r) = (0, height.Length - 1);

            while (l < r)
            {
                area = (r - l) * Math.Min(height[l], height[r]);
                if (area > res)
                    res = area;

                if (height[l] < height[r]) l++;
                else r--;
            }

            return res;
        }
    }
}
