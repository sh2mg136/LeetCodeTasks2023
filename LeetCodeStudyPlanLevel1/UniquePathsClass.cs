using System.Diagnostics;

namespace LeetCodeStudyPlanLevel1
{
    internal class UniquePathsClass
    {
        /// <summary>
        /// 62. Unique Paths
        /// https://leetcode.com/problems/unique-paths/?envType=study-plan&id=level-1
        ///
        /// There is a robot on an m x n grid.
        /// The robot is initially located at the top-left corner (i.e., grid[0][0]).
        /// The robot tries to move to the bottom-right corner (i.e., grid[m - 1][n - 1]).
        /// The robot can only move either down or right at any point in time.
        ///
        /// Given the two integers m and n, return the number of possible unique paths that the robot can take to reach the bottom-right corner.
        ///
        /// The test cases are generated so that the answer will be less than or equal to 2 * 109.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int UniquePaths(int m, int n)
        {
            return UniquePaths_1(m, n);
            // return UniquePaths_2(m, n);
        }

        private int UniquePaths_1(int m, int n)
        {
            var arr = Enumerable.Repeat(1, n).ToArray();

            for (int i = 0; i < m - 1; i++)
            {
                var newRow = Enumerable.Repeat(1, n).ToArray();

                for (int j = n - 2; j >= 0; j--)
                {
                    newRow[j] = newRow[j + 1] + arr[j];
                }

                arr = newRow;
            }

            return arr.FirstOrDefault(0);
        }

        private int UniquePaths_2(int m, int n)
        {
            var f = Fact(0);
            Debug.Assert(f == 1);
            f = Fact(1);
            Debug.Assert(f == 1);
            f = Fact(2);
            Debug.Assert(f == 2);
            f = Fact(3);
            Debug.Assert(f == 6);
            f = Fact(4);
            Debug.Assert(f == 24);
            f = Fact(5);
            Debug.Assert(f == 120);
            f = Fact(6);
            Debug.Assert(f == 720);
            f = Fact(10);
            Debug.Assert(f == 3628800);

            // C(m-n, m)
            // (m-n-2)! / (m-1)! * (n-1)!
            var res = Fact(m + n - 2) / (Fact(m - 1) * Fact(n - 1));
            return (int)res;
        }

        private static long Fact(int n)
        {
            if (n <= 0)
            {
                return 1;
            }
            return n * Fact(n - 1);
        }
    }
}