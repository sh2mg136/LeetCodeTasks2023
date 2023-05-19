using System.Data;

namespace TopInterview150
{
    internal class RemoveElementClass
    {
        /// <summary>
        /// 27. Remove Element
        ///
        /// https://leetcode.com/problems/remove-element/?envType=study-plan-v2&id=top-interview-150
        ///
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int RemoveElement(int[] nums, int val)
        {
            /*
            var tmp = nums.Where(x => x != val).ToArray();
            int res = tmp.Count();
            int i = 0;
            foreach (var x in tmp) nums[i++] = x;
            */

            int i = 0, p = 0;

            while (i < nums.Length)
            {
                if (nums[i] != val)
                {
                    if (nums[p] != nums[i])
                        nums[p] = nums[i];
                    p++;
                }
                i++;
            }

            return p;
        }

        /// <summary>
        /// 26. Remove Duplicates from Sorted Array
        /// https://leetcode.com/problems/remove-duplicates-from-sorted-array/?envType=study-plan-v2&id=top-interview-150
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int RemoveDuplicates(int[] nums)
        {
            int p = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                    continue;
                else
                    nums[p++] = nums[i];
            }

            return p;
        }

        /// <summary>
        /// 80. Remove Duplicates from Sorted Array II
        /// https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/?envType=study-plan-v2&id=top-interview-150
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int RemoveDuplicates2(int[] nums)
        {
            int p = 1;
            Dictionary<int, int> map = new Dictionary<int, int>() { { nums[0], 1 } };

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1] && map[nums[i]] >= 2)
                    continue;
                else
                {
                    nums[p++] = nums[i];

                    if (map.ContainsKey(nums[i])) map[nums[i]]++;
                    else map.Add(nums[i], 1);
                }
            }

            return p;
        }
    }
}