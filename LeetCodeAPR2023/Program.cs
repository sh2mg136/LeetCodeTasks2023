using LeetCodeAPR2023;
using System.Diagnostics;

// https://leetcode.com/problems/two-sum/
Console.WriteLine("LeetCode: Two-Sum");
var res = (new TwoSumSolver()).TwoSum(new int[] { 1, 2, 3, 5, 6 }, 5);
var correct = new int[] { 1, 2 };
bool isEqual = Enumerable.SequenceEqual(res, correct);
Debug.Assert(isEqual, "Not matched");

res = (new TwoSumSolver()).TwoSum(new int[] { 0, 1, 3, 5, 6 }, 5);
correct = new int[] { 0, 3 };
isEqual = Enumerable.SequenceEqual(res, correct);
Debug.Assert(isEqual, "Not matched");

res = (new TwoSumSolver()).TwoSum(new int[] { 2, 7, 11, 15 }, 9);
correct = new int[] { 0, 1 };
isEqual = Enumerable.SequenceEqual(res, correct);
Debug.Assert(isEqual, "Not matched");

res = (new TwoSumSolver()).TwoSum(new int[] { 3, 2, 4 }, 6);
correct = new int[] { 1, 2 };
isEqual = Enumerable.SequenceEqual(res, correct);
Debug.Assert(isEqual, "Not matched");

res = (new TwoSumSolver()).TwoSum(new int[] { 3, 3 }, 6);
correct = new int[] { 0, 1 };
isEqual = Enumerable.SequenceEqual(res, correct);
Debug.Assert(isEqual, "Not matched");

res = (new TwoSumSolver()).TwoSum(new int[] { -3, 4, 3, 90 }, 0);
correct = new int[] { 0, 2 };
isEqual = Enumerable.SequenceEqual(res, correct);
Debug.Assert(isEqual, "Not matched");



///////////////////////////////////////////////////////////////

// https://leetcode.com/problems/add-two-numbers/
AddTwoNumbersClass @class = new AddTwoNumbersClass();

var l3 = new ListNode(3, next: null);
var l2 = new ListNode(4, next: l3);
var l1 = new ListNode(2, next: l2);

var k3 = new ListNode(4, next: null);
var k2 = new ListNode(6, next: k3);
var k1 = new ListNode(5, next: k2);

var cres = @class.AddTwoNumbers(l1, k1);
Debug.Assert(cres != null);
Debug.Assert(cres.val == 7);
Debug.Assert(cres.next?.val == 0);
Debug.Assert(cres.next?.next?.val == 8);

var a7 = new ListNode(9, next: null);
var a6 = new ListNode(9, next: a7);
var a5 = new ListNode(9, next: a6);
var a4 = new ListNode(9, next: a5);
var a3 = new ListNode(9, next: a4);
var a2 = new ListNode(9, next: a3);
var a1 = new ListNode(9, next: a2);

var b4 = new ListNode(9, next: null);
var b3 = new ListNode(9, next: b4);
var b2 = new ListNode(9, next: b3);
var b1 = new ListNode(9, next: b2);

cres = @class.AddTwoNumbers(a1, b1);
Debug.Assert(cres != null);
Debug.Assert(cres.val == 8);
Debug.Assert(cres.next?.val == 9);
Debug.Assert(cres.next?.next?.val == 9);
Debug.Assert(cres.next?.next?.next?.val == 9);
Debug.Assert(cres.next?.next?.next?.next?.val == 0);
Debug.Assert(cres.next?.next?.next?.next?.next?.val == 0);
Debug.Assert(cres.next?.next?.next?.next?.next?.next?.val == 0);
Debug.Assert(cres.next?.next?.next?.next?.next?.next?.next?.val == 1);
Debug.Assert(cres.next?.next?.next?.next?.next?.next?.next?.next == null);


///
/// 13. Roman to Integer
/// 
/// https://leetcode.com/problems/roman-to-integer/
/// 
var rs = new RomanNumeralsSolver();

var rres = rs.RomanToInt("III");
Debug.Assert(rres == 3);

foreach (var val in rs.FirstTwenty)
{
    rres = rs.RomanToInt(val.Key);
    Debug.Assert(rres == val.Value);
}

rres = rs.RomanToInt("IV");
Debug.Assert(rres == 4);

rres = rs.RomanToInt("VII");
Debug.Assert(rres == 7);

rres = rs.RomanToInt("VIII");
Debug.Assert(rres == 8);

rres = rs.RomanToInt("IX");
Debug.Assert(rres == 9);

rres = rs.RomanToInt("LVIII");
Debug.Assert(rres == 58);

rres = rs.RomanToInt("MCMXCIV");
Debug.Assert(rres == 1994);

///////////////////////////////////////////
/// int to Roman
/// 

var s = rs.IntToRoman(1994);
Debug.Assert(s == "MCMXCIV");

foreach (var val in rs.FirstTwenty)
{
    s = rs.IntToRoman(val.Value);
    Debug.WriteLine($"{val.Value} -> {s}");
    Debug.Assert(s == val.Key);
}

s = rs.IntToRoman(1994);
Debug.Assert(s == "MCMXCIV");



///////////////////////////////////////////
LongestSubstringWithoutRepeatingCharactersClass c = new LongestSubstringWithoutRepeatingCharactersClass();

var ires = c.LengthOfLongestSubstring("abcabcbb");
Debug.Assert(3 == ires);

ires = c.LengthOfLongestSubstring("bbbb");
Debug.Assert(1 == ires);

ires = c.LengthOfLongestSubstring("pwwkew");
Debug.Assert(3 == ires);

ires = c.LengthOfLongestSubstring(" ");
Debug.Assert(1 == ires);

ires = c.LengthOfLongestSubstring("pwwke w");
Debug.Assert(4 == ires);

ires = c.LengthOfLongestSubstring("dvdf");
Debug.Assert(3 == ires);



//////////////////////////////////////////
/// https://leetcode.com/problems/median-of-two-sorted-arrays/
MedianTwoSortedArraysClass mcl = new MedianTwoSortedArraysClass();
var arr1 = new int[] { 1, 3 };
var arr2 = new int[] { 2 };
var dbl_res = mcl.FindMedianSortedArrays(arr1, arr2);
Debug.Assert(dbl_res == 2.000);

arr1 = new int[] { 1, 2 };
arr2 = new int[] { 3, 4 };
dbl_res = mcl.FindMedianSortedArrays(arr1, arr2);
Debug.Assert(dbl_res == 2.500);

arr1 = new int[] { 1, 1 };
arr2 = new int[] { 1, 2 };
dbl_res = mcl.FindMedianSortedArrays(arr1, arr2);
Debug.Assert(dbl_res == 1.000);
