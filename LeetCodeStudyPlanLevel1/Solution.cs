using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetCodeStudyPlanLevel1
{
    internal class Solution
    {
        /// <summary>
        /// 1480. Running Sum of 1d Array
        /// https://leetcode.com/problems/running-sum-of-1d-array/?envType=study-plan&id=level-1
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] RunningSum(int[] nums)
        {
            List<int> result = new List<int>();
            var start = 0;
            foreach (var i in nums)
            {
                result.Add(start += i);
            }
            return result.ToArray();
        }

        /// <summary>
        /// 724. Find Pivot Index
        /// https://leetcode.com/problems/find-pivot-index/?envType=study-plan&id=level-1
        /// Given an array of integers nums, calculate the pivot index of this array.
        /// 
        /// The pivot index is the index where the sum of all the numbers strictly to the left of the index 
        /// is equal to the sum of all the numbers strictly to the index's right.
        /// 
        /// Сводной индекс — это индекс, в котором сумма всех чисел строго слева от индекса 
        /// равна сумме всех чисел строго справа от индекса.
        /// 
        /// If the index is on the left edge of the array, then the left sum is 0 because there are no elements to the left.
        /// This also applies to the right edge of the array.
        /// 
        /// Return the leftmost pivot index.If no such index exists, return -1.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int PivotIndex(int[] nums)
        {
            if (nums.Length == 0) return -1;
            if (nums.Length == 1) return 0;

            int left = 0, right;

            for (int i = 0; i < nums.Length; i++)
            {
                right = 0;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    right += nums[j];
                }

                if (left == right) return i;

                left += nums[i];
            }

            return -1;
        }

        public int PivotIndexV2(int[] nums)
        {
            if (nums.Length == 1) return 0;

            int left = 0;
            int right = nums.Skip(1).Sum();

            for (int i = 0; i < nums.Length; i++)
            {
                if (left == right) return i;

                if ((i + 1) < nums.Length)
                {
                    left += nums[i];
                    right -= nums[i + 1];
                }
            }

            if (left == 0)
            {
                return nums.Length - 1;
            }

            return -1;
        }

        /// <summary>
        /// 205. Isomorphic Strings
        /// https://leetcode.com/problems/isomorphic-strings/?envType=study-plan&id=level-1
        /// 
        /// Given two strings s and t, determine if they are isomorphic.
        /// 
        /// Two strings s and t are isomorphic if the characters in s can be replaced to get t.
        /// 
        /// All occurrences of a character must be replaced with another character 
        /// while preserving the order of characters.No two characters may map to the same character, 
        /// but a character may map to itself.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            Dictionary<char, char> dict = new Dictionary<char, char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    if (dict[s[i]] != t[i])
                        return false;
                }
                else
                {
                    if (!dict.ContainsKey(s[i]))
                    {
                        if (!dict.ContainsValue(t[i]))
                            dict.Add(s[i], t[i]);
                        else
                            return false;
                    }
                    else
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 392. Is Subsequence
        /// https://leetcode.com/problems/is-subsequence/?envType=study-plan&id=level-1
        /// 
        /// Given two strings s and t, return true if s is a subsequence of t, or false otherwise.
        /// 
        /// A subsequence of a string is a new string that is formed 
        /// from the original string by deleting some(can be none) of the characters 
        /// without disturbing the relative positions of the remaining characters. 
        /// (i.e., "ace" is a subsequence of "abcde" while "aec" is not).
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsSubsequence(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
                return true;

            int cnt = 0;
            int res = 0;
            foreach (char ch in s)
            {
                if (!t.Contains(ch))
                    return false;

                cnt = t.IndexOf(ch, cnt);

                if (cnt >= 0)
                {
                    if (++res == s.Length)
                        return true;
                    cnt++;
                }
                else
                    return false;
            }
            return false;
        }
    }
}
