using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetCode2023May
{
    internal class TwoSumIISolver
    {
        /// <summary>
        /// 167. Two Sum II - Input Array Is Sorted
        /// 
        /// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
        /// 
        /// Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, 
        /// find two numbers such that they add up to a specific target number. 
        /// Let these two numbers be numbers[index1] and numbers[index2] where 1 <= index1 < index2 <= numbers.length.
        /// 
        /// Return the indices of the two numbers, index1 and index2, 
        /// added by one as an integer array[index1, index2] of length 2.
        /// 
        /// The tests are generated such that there is exactly one solution.
        /// You may not use the same element twice.
        /// 
        /// https://www.youtube.com/watch?v=cQ1Oz4ckceM
         /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] numbers, int target)
        {
            // return TwoSum_V1(numbers, target);
            // return TwoSum_V2(numbers, target);
            return TwoSum_V3(numbers, target);
        }

        int[] TwoSum_V3(int[] numbers, int target)
        {
            int i = 0, j = numbers.Length - 1, sum = 0;

            while (i < j)
            {
                sum = numbers[i] + numbers[j];

                if (sum > target)
                {
                    j--;
                }
                else if (sum < target)
                {
                    i++;
                }
                else break;
            }

            return new int[] { i + 1, j + 1 };
        }

        int[] TwoSum_V2(int[] numbers, int target)
        {
            int i = 0, j = 1;

            while (i < numbers.Length - 1)
            {
                while (j < numbers.Length)
                {
                    if (numbers[i] + numbers[j] == target)
                        return new int[] { i + 1, j + 1 };
                    j++;
                }

                i++;
                j = i + 1;
            }

            return new int[] { 0, 0 };
        }

        int[] TwoSum_V1(int[] numbers, int target)
        {
            int diff;
            for (int i = 0; i < numbers.Length; i++)
            {
                diff = target - numbers[i];

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] == diff)
                    {
                        return new int[] { i + 1, j + 1 };
                    }
                }
            }
            return new int[] { 0, 0 };
        }
    }
}
