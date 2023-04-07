using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("AutoTests")]
namespace LeetCodeAPR2023
{
    /// <summary>
    /// 
    /// 3. Longest Substring Without Repeating Characters
    /// 
    /// https://leetcode.com/problems/longest-substring-without-repeating-characters/
    /// 
    /// </summary>
    internal class LongestSubstringWithoutRepeatingCharactersClass
    {

        /// <summary>
        /// Given a string s, find the length of the longest substring without repeating characters.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            int res = 0, tmp = 0, i, j;
            List<char> chr = new List<char>();

            for (i = 0; i < s.Length; i++)
            {
                if (!chr.Contains(s[i]))
                {
                    chr.Add(s[i]);
                    tmp++;
                    if (tmp > res) res = tmp;
                }
                else
                {
                    for (j = i - 1; j >= 0; j--)
                    {
                        if (s[j] == s[i])
                        {
                            i = j;
                            break;
                        }
                    }
                    chr.Clear();
                    tmp = 0;
                }
            }

            return res;
        }
    }
}
