namespace LeetCodeStudyPlanLevel1
{
    internal class FibonacciNumbers
    {
        public static int[] Fibonacci = {
            0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181,
            6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040,
            1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 39088169, 63245986,
            102334155, 165580141, 267914296, 433494437, 701408733, 1134903170, 1836311903
        };

        public int fib(int n)
        {
            return Fibonacci[n];
        }

        //Fibonacci Series using Recursion
        public int fib2(int n)
        {
            if (n <= 1) return n;
            return fib2(n - 1) + fib2(n - 2);
        }

        // Dynamic Programming
        public int fib3(int n)
        {
            /* Declare an array to store Fibonacci numbers. */
            int[] f = new int[n + 1]; // 1 extra to handle case, n = 0
            int i;

            /* 0th and 1st number of the series are 0 and 1*/
            f[0] = 1;
            f[1] = 1;

            for (i = 2; i <= n; i++)
            {
                /* Add the previous 2 numbers in the series and store it */
                f[i] = f[i - 1] + f[i - 2];
            }

            return f[n];
        }

        public static IEnumerable<int> Get(int max)
        {
            yield return 0;
            yield return 1;
            var current = (n0: 0, n1: 1);
            while (current.n0 < max)
            {
                current = (current.n1, current.n0 + current.n1);
                yield return current.n1;
            }
        }

    }
}