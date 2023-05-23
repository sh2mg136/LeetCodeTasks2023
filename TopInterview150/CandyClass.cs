using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterview150
{
    internal class CandyClass
    {
        /// <summary>
        /// 135. Candy
        /// There are n children standing in a line. 
        /// Each child is assigned a rating value given in the integer array ratings.
        /// You are giving candies to these children subjected to the following requirements:
        /// - Each child must have at least one candy.
        /// - Children with a higher rating get more candies than their neighbors.
        /// 
        /// Return the minimum number of candies you need to have to distribute the candies to the children.
        /// 
        /// https://leetcode.com/problems/candy/?envType=study-plan-v2&id=top-interview-150
        /// </summary>
        /// <param name="ratings"></param>
        /// <returns></returns>
        public static int Candy(int[] ratings)
        {
            return Candy_Ver_1(ratings);
            // return Candy_Ver_2(ratings);
        }

        public static int Candy_Ver_1(int[] ratings)
        {
            int res = 0;
            var l = Enumerable.Repeat(1, ratings.Length).ToArray();
            var r = Enumerable.Repeat(1, ratings.Length).ToArray();

            for (int i = 1; i < ratings.Length; i++)
            {
                if (ratings[i] > ratings[i - 1]) l[i] = l[i - 1] + 1;
            }

            for (int i = ratings.Length - 1; i > 0; i--)
            {
                if (ratings[i - 1] > ratings[i]) r[i - 1] = r[i] + 1;
            }

            for (int i = 0; i < ratings.Length; i++)
            {
                res += Math.Max(l[i], r[i]);
            }

            return res;
        }

        /// <summary>
        /// Improve space complexity (let's get rid of one array).
        /// Time: O(n).
        /// Space: O(1).
        /// </summary>
        /// <param name="ratings"></param>
        /// <returns></returns>
        public static int Candy_Ver_2(int[] ratings)
        {
            if (ratings.Length <= 1) return ratings.Length;

            int up = 0, down = 0, prev = 0, res = 0;

            for (int i = 1; i < ratings.Length; i++)
            {
                int curr = ratings[i] > ratings[i - 1] ? 1 : (ratings[i] < ratings[i - 1] ? -1 : 0);

                if ((prev < 0 && curr >= 0) || (prev > 0 && curr == 0))
                {
                    res += sum(up) + sum(down) + Math.Max(up, down);
                    up = 0;
                    down = 0;
                }

                if (curr > 0) up++;
                else if (curr < 0) down++;
                else res++;

                prev = curr;
            }

            res += sum(up) + sum(down) + Math.Max(up, down) + 1;

            return res;
        }

        private static int sum(int n)
        {
            return (n * (n + 1)) / 2;
        }
    }
}
