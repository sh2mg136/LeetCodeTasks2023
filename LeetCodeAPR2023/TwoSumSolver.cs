using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeAPR2023
{
    internal class TwoSumSolver
    {

        public int[] TwoSum(int[] nums, int target)
        {
            int[] answer = new int[] { 0, 0 };

            int diff;
            for (int i = 0; i < nums.Length; i++)
            {
                diff = target - nums[i];

                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == diff)
                    {
                        answer[0] = i;
                        answer[1] = j;
                        break;
                    }
                }
            }

            return answer;
        }

        public int[] TwoSum_V0(int[] nums, int target)
        {
            int diff;
            for (int i = 0; i < nums.Length; i++)
            {
                diff = target - nums[i];

                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == diff)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { 0, 0 };
        }
    }
}
