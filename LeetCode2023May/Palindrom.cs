using System.Text;

namespace LeetCode2023May
{
    internal class Palindrom
    {
        private static int start = 0;
        private static int len = 0;

        /// <summary>
        /// 5. Longest Palindromic Substring
        /// https://leetcode.com/problems/longest-palindromic-substring/
        /// Given a string s, return the longest
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string LongestPalindrome(string s)
        {
            Palindrom.start = 0;
            Palindrom.len = 0;

            // return LongestPalindrome_1(s);

            return LongestPalindrome_V2(s);
        }

        private static string LongestPalindrome_V2(string s)
        {
            int len = 0;
            int start = 0;

            for (int i = 0; i < s.Length; i++)
            {
                var (l, r) = (i, i);

                while (l >= 0 && r < s.Length && s[l] == s[r])
                {
                    if (r - l + 1 > len)
                    {
                        len = r - l + 1;
                        start = l;
                    }

                    l--;
                    r++;
                }

                (l, r) = (i, i + 1);

                while (l >= 0 && r < s.Length && s[l] == s[r])
                {
                    if (r - l + 1 > len)
                    {
                        len = r - l + 1;
                        start = l;
                    }

                    l--;
                    r++;
                }
            }

            return s.Substring(start, len);
        }

        private static string LongestPalindrome_V1(string s)
        {
            if (s.Length < 2) return s;

            for (int i = 0; i < s.Length; i++)
            {
                Check(s, i, i);
                Check(s, i, i + 1);
            }

            return s.Substring(start, len);
        }

        private static void Check(string s, int start, int end)
        {
            while (start >= 0 && end < s.Length && s[start] == s[end])
            {
                start--;
                end++;
            }

            if (end - start > len)
            {
                len = end - start - 1;
                Palindrom.start = start + 1;
            }
        }

        /// <summary>
        /// 9. Palindrome Number
        /// https://leetcode.com/problems/palindrome-number/
        /// 
        /// Given an integer x, return true if x is a palindrome, and false otherwise.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            if (x <= 9) return true;

            var str = x.ToString();
            int j = str.Length - 1;

            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[j]) return false;
                j--;
            }

            return true;
        }

        /// <summary>
        /// 14. Longest Common Prefix
        /// https://leetcode.com/problems/longest-common-prefix/
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0) return string.Empty;
            if (strs.Length == 1) return strs[0];

            var shortest = strs.MinBy(a => a.Length) ?? string.Empty;

            int cnt = 0;

            for (int i = 0; i < shortest.Length; i++)
            {
                foreach (var s in strs.Skip(1))
                {
                    if (s.Length <= i || strs.First()[i] != s[i])
                        return strs.First()[..cnt];
                }
                cnt++;
            }

            return strs.First()[..cnt];
        }
    }
}