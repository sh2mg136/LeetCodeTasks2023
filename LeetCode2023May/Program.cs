using LeetCode2023May;
using System.Diagnostics;

Console.WriteLine("LeetCode 2023 May");

int ires;
string sres;

sres = Palindrom.LongestPalindrome("babad");
Debug.Assert(sres == "bab" || sres == "aba");

sres = Palindrom.LongestPalindrome("cbbd");
Debug.Assert(sres == "bb");

sres = Palindrom.LongestPalindrome("a");
Debug.Assert(sres == "a");

sres = Palindrom.LongestPalindrome("ac");
Debug.Assert(sres == "a" || sres == "c");


