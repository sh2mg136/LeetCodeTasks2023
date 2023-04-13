using System.Diagnostics;

namespace LeetCodeStudyPlanLevel1
{
    internal class CMisc
    {
        public int Reverse(int x)
        {
            if (x == int.MinValue) return 0;

            var t = Math.Abs(x);
            var arr = Math.Abs(x).ToString().Reverse();
            var s = string.Join("", arr);
            try
            {
                return (int.Parse(s)) * (x < 0 ? -1 : 1);
            }
            catch
            {
                return 0;
            }
        }

        public void ReverseString(char[] s)
        {
            int cnt = s.Length / 2;
            int i = 0;
            while (i < cnt)
            {
                char c = s[i];
                s[i] = s[s.Length - 1 - i];
                s[s.Length - 1 - i] = c;
                i++;
            }
            Console.WriteLine(s);
            Debug.Assert(s[0] == 'c' && s[s.Length - 1] == 'a');
        }

        public void ReverseString2(char[] s)
        {
            int cnt = s.Length / 2;
            int i = 0;
            while (i < cnt)
            {
                (s[i], s[s.Length - 1 - i]) = (s[s.Length - 1 - i], s[i]);

                /*
                    char c = s[i];
                    s[i] = s[s.Length - 1 - i];
                    s[s.Length - 1 - i] = c;
                */

                i++;
            }
            Console.WriteLine(s);
            Debug.Assert(s[0] == 'c' && s[s.Length - 1] == 'a');
        }
    }
}