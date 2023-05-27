using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices;
using System;

namespace TopInterview150
{
    internal class JumpGameClass
    {
        /// <summary>
        /// 55. Jump Game
        ///
        /// You are given an integer array nums.
        /// You are initially positioned at the array's first index,
        /// and each element in the array represents your maximum jump length at that position.
        ///
        /// Return true if you can reach the last index,
        /// or false otherwise.
        ///
        /// https://leetcode.com/problems/jump-game/?envType=study-plan-v2&id=top-interview-150
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool CanJump(int[] nums)
        {
            return CanJump_Ver1(nums);
        }

        private static bool CanJump_Ver1(int[] nums)
        {
            var last = nums[nums.Length - 1];

            for (int i = nums.Length - 1; i >= 0; i--)
                if (i + nums[i] >= last)
                    last = i;

            return last == 0;
        }

        /// <summary>
        /// 45. Jump Game II
        /// 
        /// You are given a 0-indexed array of integers nums of length n. 
        /// You are initially positioned at nums[0].
        /// 
        /// Each element nums[i] represents the maximum length of a forward jump from index i.
        /// In other words, if you are at nums[i], you can jump to any nums[i + j] where:
        /// 0 <= j <= nums[i] and i + j < n;
        /// 
        /// Return the minimum number of jumps to reach nums[n - 1]. 
        /// The test cases are generated such that you can reach nums[n - 1].
        /// 
        /// https://leetcode.com/problems/jump-game-ii/?envType=study-plan-v2&id=top-interview-150
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int CanJumpII(int[] nums)
        {
            // return CanJumpII_Ver1(nums);
            return CanJumpII_Ver2(nums);
        }

        static int CanJumpII_Ver2(int[] nums)
        {
            int res = 0, l = 0, r = 0, big;

            while (r < nums.Length - 1)
            {
                big = 0;

                for (int i = l; i <= r; i++)
                {
                    if (i + nums[i] > big)
                        big = i + nums[i];
                }

                l = r + 1;
                r = big;

                res++;
            }

            return res;
        }

        static int CanJumpII_Ver1(int[] nums)
        {
            int res = 0, l = 0, r = 0;
            List<int> hopes;

            while (r < nums.Length - 1)
            {
                hopes = new List<int>(r - l + 1);

                for (int i = l; i <= r; i++)
                {
                    hopes.Add(i + nums[i]);
                }

                l = r + 1;
                r = hopes.Max();

                res++;
            }

            return res;
        }


        public bool ContainsDuplicate(int[] nums)
        {
            return nums.GroupBy(x => x).Any(g => g.Count() > 1);
        }

        public bool ContainsDuplicate_2(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (int x in nums)
            {
                if (set.Contains(x))
                    return true;
                set.Add(x);
            }
            return false;
        }

        public static bool IsAnagram(string s, string t)
        {
            return IsAnagram_Ver_1(s, t);
            // return IsAnagram_Ver_2(s, t);
        }

        static bool IsAnagram_Ver_2(string s, string t)
        {
            if (s.Length != t.Length) return false;

            SortedList<char, int> a = new();
            SortedList<char, int> b = new();

            for (int i = 0; i < s.Length; i++)
            {
                if (a.ContainsKey(s[i])) a[s[i]]++; else a.Add(s[i], 1);
                if (b.ContainsKey(t[i])) b[t[i]]++; else b.Add(t[i], 1);
            }

            return Enumerable.SequenceEqual(a, b);
        }

        static bool IsAnagram_Ver_1(string s, string t)
        {
            if (s.Length != t.Length) return false;

            Dictionary<char, int> a = new();
            Dictionary<char, int> b = new();

            for (int i = 0; i < s.Length; i++)
            {
                if (a.ContainsKey(s[i])) a[s[i]]++; else a.Add(s[i], 1);
                if (b.ContainsKey(t[i])) b[t[i]]++; else b.Add(t[i], 1);
            }

            return Enumerable.SequenceEqual(a, b);

            foreach (var p in a)
            {
                if (!b.ContainsKey(p.Key) || b[p.Key] != p.Value)
                    return false;
            }

            return true;
        }
    }
}