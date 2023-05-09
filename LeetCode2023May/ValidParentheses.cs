using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2023May
{
    internal class ValidParentheses
    {
        /// <summary>
        /// 20. Valid Parentheses
        /// https://leetcode.com/problems/valid-parentheses/
        /// 
        /// Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        /// 
        /// An input string is valid if:
        /// Open brackets must be closed by the same type of brackets.
        /// Open brackets must be closed in the correct order.
        /// Every close bracket has a corresponding open bracket of the same type.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsValid(string s)
        {
            return IsValid_V1(s);
            // return IsValid_V21(s);
        }

        static readonly Dictionary<char, char> Map = new()
        {
            {'{',  '}'},
            {'(',  ')'},
            {'[',  ']'},
        };

        static bool IsValid_V1(string s)
        {
            Stack<char> stack = new();

            foreach (char ch in s)
            {
                if (Map.ContainsKey(ch))
                {
                    stack.Push(ch);
                    continue;
                }

                if (stack.Count == 0)
                    return false;

                if (Map[stack.Pop()] == ch)
                    continue;

                return false;
            }

            return stack.Count == 0;
        }

        static bool IsValid_V2(string s)
        {
            // Get ready initial state (enforce element type)
            var k = new Stack<char>();
            // Evaluate each character for potential mismatch 
            foreach (char c in s)
            {
                // Push closing round bracket onto the stack
                if (c == '(') { k.Push(')'); continue; }
                // Push closing curly bracket onto the stack
                if (c == '{') { k.Push('}'); continue; }
                // Push closing square bracket onto the stack
                if (c == '[') { k.Push(']'); continue; }
                // Look out for imbalanced strings or mismatches
                if (k.Count == 0 || c != k.Pop()) return false;
            }
            // Empty stack means string is valid and invalid otherwise
            return k.Count == 0;
        }

        static bool IsValid_V21(string s)
        {
            var k = new Stack<char>();
            foreach (char c in s)
            {
                if (c == '(')
                {
                    k.Push(')');
                    continue;
                }

                if (c == '{')
                {
                    k.Push('}');
                    continue;
                }

                if (c == '[')
                {
                    k.Push(']');
                    continue;
                }

                if (k.Count == 0 || c != k.Pop())
                    return false;
            }
            return k.Count == 0;
        }

        static bool IsValid_V3(string s)
        {
            var stack = new Stack<char>();
            foreach (var ch in s)
            {
                if (ch is '(' or '{' or '[')
                {
                    stack.Push(ch);
                    continue;
                }

                if (!stack.TryPop(out var bracket))
                {
                    return false;
                }

                switch (ch)
                {
                    case ')' when bracket != '(':
                    case '}' when bracket != '{':
                    case ']' when bracket != '[':
                        return false;
                }
            }
            return !stack.Any();
        }
    }
}
