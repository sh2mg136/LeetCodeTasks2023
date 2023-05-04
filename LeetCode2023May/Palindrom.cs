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
    }
}