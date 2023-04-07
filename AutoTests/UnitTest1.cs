using LeetCodeAPR2023;
using System.Diagnostics;

namespace AutoTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            LongestSubstringWithoutRepeatingCharactersClass c = new LongestSubstringWithoutRepeatingCharactersClass();

            var res = c.LengthOfLongestSubstring("abcabcbb");
            Assert.Equal(3, res);

            res = c.LengthOfLongestSubstring("bbbbb");
            Assert.Equal(1, res);

            res = c.LengthOfLongestSubstring("pwwkew");
            Assert.Equal(3, res);

            res = c.LengthOfLongestSubstring(" ");
            Assert.Equal(1, res);

            res = c.LengthOfLongestSubstring("pwwke w");
            Assert.Equal(4, res);

            res = c.LengthOfLongestSubstring("dvdf");
            Assert.Equal(3, res);
        }
    }
}