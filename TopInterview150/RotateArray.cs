using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TopInterview150
{
    internal class RotateArray
    {
        /// <summary>
        /// 189. Rotate Array
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void Rotate(int[] nums, int k)
        {
            if (nums.Length <= 1) return;
            if (k == 0) return;

            if (nums.Length == 2)
            {
                if (k % 2 > 0) Array.Reverse(nums);
                return;
            }

            if (k > nums.Length) k %= nums.Length;

            Array.Reverse(nums);

            // Hint!
            // Array.Reverse(nums[k..]);
            // Array.Reverse(nums[..k]);

            int l = 0, r = k - 1;

            while (l < r)
            {
                (nums[l], nums[r]) = (nums[r--], nums[l++]);
            }

            l = k;
            r = nums.Length - 1;

            while (l < r)
            {
                (nums[l], nums[r]) = (nums[r--], nums[l++]);
            }

            /*
            int j = k - 1;
            for (int i = 0; i < k / 2; i++)
            {
                (nums[i], nums[j]) = (nums[j], nums[i]);
                j--;
            }

            j = nums.Length - 1;
            var len = (nums.Length - k) / 2; 
            for (int i = k; i < k + len; i++)
            {
                (nums[i], nums[j]) = (nums[j], nums[i]);
                j--;
            }
            */

            Debug.WriteLine(nums.ToString());
        }
    }
}
