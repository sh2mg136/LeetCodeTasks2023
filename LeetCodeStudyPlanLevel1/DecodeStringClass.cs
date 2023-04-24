using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlanLevel1
{
    internal class DecodeStringClass
    {
        /// <summary>
        /// 394. Decode String
        /// https://leetcode.com/problems/decode-string/?envType=study-plan&id=level-1
        /// Given an encoded string, return its decoded string.
        /// 
        /// The encoding rule is: k[encoded_string], 
        /// where the encoded_string inside the square brackets is being repeated exactly k times.
        /// Note that k is guaranteed to be a positive integer.
        /// 
        /// You may assume that the input string is always valid; 
        /// there are no extra white spaces, square brackets are well-formed, etc.
        /// Furthermore, you may assume that the original data does not contain any digits 
        /// and that digits are only for those repeat numbers, k.For example, there will not be input like 3a or 2[4].
        /// 
        /// The test cases are generated so that the length of the output will never exceed 105.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string DecodeString(string s)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ']')
                {
                    stack.Push(s[i]);
                }
                else
                {
                    string sub = string.Empty;
                    List<char> list = new List<char>();

                    while (stack.Peek() != '[')
                    {
                        list.Add(stack.Pop());
                    }
                    stack.Pop();
                    list.Reverse();
                    sub = string.Join("", list);

                    list.Clear();

                    while (stack.Any() && char.IsDigit(stack.Peek()))
                    {
                        list.Add(stack.Pop());
                    }

                    list.Reverse();
                    int k = int.Parse(string.Join("", list));

                    for (int j = 0; j < k; j++)
                    {
                        foreach (char c in sub)
                        {
                            stack.Push(c);
                        }
                    }
                }
            }

            return string.Join("", stack.Reverse().ToArray());
        }

        /// <summary>
        /// 1046. Last Stone Weight
        /// https://leetcode.com/problems/last-stone-weight/?envType=study-plan&id=level-1
        /// </summary>
        /// <param name="stones"></param>
        /// <returns></returns>
        public static int LastStoneWeight(int[] stones)
        {
            // return LastStoneWeight_1(stones);
            return LastStoneWeight_2(stones);
        }

        public static int LastStoneWeight_1(int[] stones)
        {
            if (stones == null || stones.Count() == 0) return 0;
            if (stones.Count() == 1) return stones[0];

            List<int> list = stones.OrderByDescending(x => x).ToList();
            while (list.Count() > 1)
            {
                var sub = list.Take(2).ToArray();
                list.RemoveAt(0);
                list.RemoveAt(0);
                if (sub[0] != sub[1])
                {
                    list.Add(sub[0] - sub[1]);
                    list = list.OrderByDescending(x => x).ToList();
                }
            }

            return list.FirstOrDefault(0);
        }

        /// <summary>
        /// PriorityQueue
        /// 
        /// Represents a collection of items that have a value and a priority. 
        /// On dequeue, the item with the lowest priority value is removed.
        /// </summary>
        /// <param name="stones"></param>
        /// <returns></returns>
        public static int LastStoneWeight_2(int[] stones)
        {
            var q = new PriorityQueue<int, int>(stones.Select(x => (x, -x)));

            while (q.Count > 1)
            {
                int a = q.Dequeue() - q.Dequeue();
                if (a != 0) q.Enqueue(a, -a);
            }

            return (q.Count == 0) ? 0 : q.Peek();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Encode(string[] input)
        {
            StringBuilder res = new StringBuilder();
            foreach (var s in input)
            {
                res.Append(s.Length);
                res.Append('#');
                res.Append(s);
            }
            return res.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string[] Decode(string input)
        {
            int i = 0, j;
            List<string> list = new List<string>();

            while (i < input.Length)
            {
                j = i;
                while (input[j] != '#')
                {
                    j++;
                }
                int.TryParse(input.AsSpan(i, j - i), out int len);
                list.Add(input.Substring(j + 1, len));
                i += len + j - i + 1;
            }

            return list.ToArray();
        }
    }
}
