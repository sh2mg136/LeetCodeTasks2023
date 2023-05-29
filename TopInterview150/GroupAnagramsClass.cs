namespace TopInterview150
{
    internal class GroupAnagramsClass
    {
        /// <summary>
        /// 49. Group Anagrams
        ///
        /// Given an array of strings strs, group the anagrams together.
        /// You can return the answer in any order.
        ///
        /// An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase,
        /// typically using all the original letters exactly once.
        /// https://leetcode.com/problems/group-anagrams/
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            // return GroupAnagrams_Ver_1(strs);
            // return GroupAnagrams_Ver_2(strs);
            // return GroupAnagrams_Ver_3(strs);
            // return GroupAnagrams_Ver_4(strs);
            return GroupAnagrams_Ver_5(strs);
        }

        /// <summary>
        /// Using custom comparer
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        private static IList<IList<string>> GroupAnagrams_Ver_1(string[] strs)
        {
            int A = (int)'a';
            Dictionary<int[], List<string>> dict = new Dictionary<int[], List<string>>(new MyArrayComparer());

            foreach (string str in strs)
            {
                var cnt = Enumerable.Repeat(0, 26).ToArray();

                foreach (char ch in str)
                {
                    cnt[(int)ch - A]++;
                }

                if (dict.ContainsKey(cnt))
                    dict[cnt].Add(str);
                else
                    dict.Add(cnt, new List<string>() { str });
            }

            IList<IList<string>> res = new List<IList<string>>();

            foreach (var p in dict) res.Add(p.Value);

            return res;
        }

        /// <summary>
        /// Using string as a dictionary key
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        private static IList<IList<string>> GroupAnagrams_Ver_2(string[] strs)
        {
            int A = (int)'a';
            Dictionary<string, IList<string>> dict = new Dictionary<string, IList<string>>();

            string key;
            int i;
            int[] cnt;

            foreach (string str in strs)
            {
                cnt = Enumerable.Repeat(0, 26).ToArray();

                foreach (char ch in str)
                {
                    // cnt[(int)ch - A]++;
                    cnt[ch - 'a']++;
                }

                i = 0;
                // key = string.Join("", cnt.Select(x => $"{(char)(i++)}{x}"));
                key = string.Join("", cnt.Select(x => $"{i++}{x}"));

                if (dict.ContainsKey(key))
                    dict[key].Add(str);
                else
                    dict.Add(key, new List<string>() { str });
            }

            // IList<IList<string>> res = new List<IList<string>>();
            // foreach (var p in dict) res.Add(p.Value);

            return dict.Values.ToList();
        }

        private static IList<IList<string>> GroupAnagrams_Ver_3(string[] strs)
        {
            return strs
                .GroupBy(s => new string(s.OrderBy(c => c).ToArray()))
                .Select(g => g.ToList() as IList<string>)
                .ToList();
        }

        private static IList<IList<string>> GroupAnagrams_Ver_4(string[] strs)
        {
            var res =
                (
                 from str in strs
                 group str by new string(str.OrderBy(s => s).ToArray())
                 into g
                 select g.ToList() as IList<string>
                )
            .ToList();

            return res;
        }

        /// <summary>
        /// https://leetcode.com/problems/group-anagrams/solutions/3556931/best-run-time-and-memory-solution-in-c/
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        private static IList<IList<string>> GroupAnagrams_Ver_5(string[] strs)
        {
            var dict = new Dictionary<string, IList<string>>();

            for (int i = 0; i < strs.Length; i++)
            {
                char[] arr = strs[i].ToCharArray();
                Array.Sort(arr);
                string sorted = new(arr);

                if (!dict.ContainsKey(sorted))
                {
                    dict.Add(sorted, new List<String>() { strs[i] });
                }
                else
                {
                    dict[sorted].Add(strs[i]);
                }
            }

            return dict.Values.ToList();
        }
    }

    public class MyArrayComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[]? x, int[]? y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;

            if (x.Length != y.Length)
            {
                return false;
            }
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                {
                    return false;
                }
            }
            return true;
        }

        public int GetHashCode(int[] obj)
        {
            int result = 17;
            for (int i = 0; i < obj.Length; i++)
            {
                unchecked
                {
                    result = result * 23 + obj[i];
                }
            }
            return result;
        }
    }
}