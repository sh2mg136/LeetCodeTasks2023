namespace TopInterview150
{
    /// <summary>
    /// 238. Product of Array Except Self
    /// </summary>
    internal class ProductOfArrayExceptSelf
    {
        /// <summary>
        /// 238. Product of Array Except Self
        ///
        /// Given an integer array nums,
        /// return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].
        ///
        /// The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
        ///
        /// You must write an algorithm that runs in O(n) time and without using the division operation.
        ///
        /// https://leetcode.com/problems/product-of-array-except-self/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] ProductExceptSelf(int[] nums)
        {
            // return ProductExceptSelf_V1(nums);
            // return ProductExceptSelf_V2(nums);
            return ProductExceptSelf_V3(nums);
        }

        private static int[] ProductExceptSelf_V1(int[] nums)
        {
            var res = new int[nums.Length];
            var a = Enumerable.Repeat(1, nums.Length).ToArray();
            var b = Enumerable.Repeat(1, nums.Length).ToArray();

            int tmp = 1;

            foreach (int i in Enumerable.Range(1, nums.Length - 1))
            {
                a[i] = tmp * nums[i - 1];
                tmp = a[i];
            }

            tmp = 1;

            for (int i = nums.Length - 2; i >= 0; i--)
            {
                b[i] = tmp * nums[i + 1];
                tmp = b[i];
            }

            foreach (int i in Enumerable.Range(0, nums.Length))
            {
                res[i] = a[i] * b[i];
            }

            return res;
        }

        private static int[] ProductExceptSelf_V2(int[] nums)
        {
            var res = new int[nums.Length];
            int a = 1;

            foreach (int i in Enumerable.Range(0, nums.Length))
            {
                res[i] = a;
                a *= nums[i];
            }

            a = 1;

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                res[i] *= a;
                a *= nums[i];
            }

            return res;
        }

        private static int[] ProductExceptSelf_V3(int[] nums)
        {
            var res = Enumerable.Repeat(1, nums.Length).ToArray();

            int tmp = 1;

            foreach (int i in Enumerable.Range(1, nums.Length - 1))
            {
                tmp *= nums[i - 1];
                res[i] = tmp;
            }

            tmp = 1;

            for (int i = nums.Length - 2; i >= 0; i--)
            {
                tmp *= nums[i + 1];
                res[i] *= tmp;
            }

            return res;
        }
    }
}