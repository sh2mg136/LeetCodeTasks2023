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
    }
}
