using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2023May
{
    /// <summary>
    /// 1035. Uncrossed Lines
    /// </summary>
    internal class UncrossedLines
    {
        /// <summary>
        /// 1035. Uncrossed Lines
        /// https://leetcode.com/problems/uncrossed-lines/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public static int MaxUncrossedLines(int[] nums1, int[] nums2)
        {
            DP = new int[nums1.Length + 1, nums2.Length + 1];
            Console.WriteLine(DP[0, 0]);

            // return MaxUncrossedLines_V1(nums1, nums2);
            return MaxUncrossedLines_V2(nums1, nums2);
        }

        static int[,] DP = new int[1, 1];

        static int MaxUncrossedLines_V2(int[] nums1, int[] nums2)
        {
            int[] curr = new int[nums2.Length + 1];
            int[] prev = new int[nums2.Length + 1];

            for (int i = 0; i < nums1.Length; i++)
            {
                curr = new int[nums2.Length + 1];

                for (int j = 0; j < nums2.Length; j++)
                {
                    if (nums1[i] == nums2[j])
                    {
                        curr[j + 1] = 1 + prev[j];
                    }
                    else
                    {
                        curr[j + 1] = Math.Max(curr[j], prev[j + 1]);
                    }
                }

                prev = curr;
            }

            return curr[nums2.Length];
        }

        static int MaxUncrossedLines_V1(int[] nums1, int[] nums2)
        {
            return dfs(0, 0, nums1, nums2);
        }

        static int dfs(int i, int j, int[] nums1, int[] nums2)
        {
            if (i == nums1.Length || j == nums2.Length)
                return 0;

            if (DP[i, j] > 0)
                return DP[i, j];

            if (nums1[i] == nums2[j])
            {
                DP[i, j] = 1 + dfs(i + 1, j + 1, nums1, nums2);
            }
            else
            {
                DP[i, j] = Math.Max(dfs(i + 1, j, nums1, nums2), dfs(i, j + 1, nums1, nums2));
            }

            return DP[i, j];
        }
    }
}
