﻿// https://leetcode.com/studyplan/top-interview-150/
using System.Diagnostics;
using TopInterview150;

const string WRONG = "- = Wrong answer = -";

Console.WriteLine("Top Interview 150");

////////////////////////////////////////////////////////////////////////////////////////////
/// 88. Merge Sorted Array

// Expected [1,2,3,4,5,6]
(new MergeArrayClass()).Merge(new int[] { 4, 5, 6, 0, 0, 0 }, 3, new int[] { 1, 2, 3 }, 3);

// Expected [1,2,3,4,5,6]
(new MergeArrayClass()).Merge(new int[] { 1, 2, 4, 5, 6, 0 }, 5, new int[] { 3 }, 1);

// Expected [1,2,3,4,5,6]
(new MergeArrayClass()).Merge(new int[] { 4, 0, 0, 0, 0, 0 }, 1, new int[] { 1, 2, 3, 5, 6 }, 5);

// Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
// Output: [1,2,2,3,5,6]
(new MergeArrayClass()).Merge(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3);

// Input: nums1 = [1], m = 1, nums2 = [], n = 0
// Output: [1]
(new MergeArrayClass()).Merge(new int[] { 1 }, 1, new int[] { }, 0);

// Input: nums1 = [0], m = 0, nums2 = [1], n = 1
// Output: [1]
(new MergeArrayClass()).Merge(new int[] { 0 }, 0, new int[] { 1 }, 1);

////////////////////////////////////////////////////////////////////////////////////////////
/// 27. Remove Element

int iRes = RemoveElementClass.RemoveElement(new int[] { 3, 2, 2, 3 }, 3);
Debug.Assert(iRes == 2, WRONG);

iRes = RemoveElementClass.RemoveElement(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2);
Debug.Assert(iRes == 5, WRONG);

////////////////////////////////////////////////////////////////////////////////////////////
/// 26. Remove Duplicates from Sorted Array

iRes = RemoveElementClass.RemoveDuplicates(new int[] { 1, 1, 2 });
Debug.Assert(iRes == 2, WRONG);

iRes = RemoveElementClass.RemoveDuplicates(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 });
Debug.Assert(iRes == 5, WRONG);

////////////////////////////////////////////////////////////////////////////////////////////
/// 80. Remove Duplicates from Sorted Array II

iRes = RemoveElementClass.RemoveDuplicates2(new int[] { 1, 1, 1, 2, 2, 3 });
// Output: 5, nums = [1,1,2,2,3,_]
Debug.Assert(iRes == 5, WRONG);

iRes = RemoveElementClass.RemoveDuplicates2(new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 });
// Output: 7, nums = [0,0,1,1,2,3,3,_,_]
Debug.Assert(iRes == 7, WRONG);

////////////////////////////////////////////////////////////////////////////////////////////
/// 169. Majority Element

iRes = Majority.MajorityElement(new int[] { 3, 2, 3 });
Debug.Assert(iRes == 3, WRONG);

iRes = Majority.MajorityElement(new int[] { 2, 2, 1, 1, 1, 2, 2 });
Debug.Assert(iRes == 2, WRONG);

iRes = Majority.MajorityElement(new int[] { 2, 9, 8, 2, 1, 8, 1, 7, 1, 2, 6, 6, 4, 2, 3, 4, 8, 9, 8, 8, 3, 8, 5, 8, 8, 0, 8, 0, 8 });
Debug.Assert(iRes == 8, WRONG);

////////////////////////////////////////////////////////////////////////////////////////////
/// 189. Rotate Array

(new RotateArray()).Rotate(new int[] { 1, 2 }, 3);

(new RotateArray()).Rotate(new int[] { 1, 2, 3 }, 4);

(new RotateArray()).Rotate(new int[] { 1, 2, 3, 4, 5, 6 }, 2);

(new RotateArray()).Rotate(new int[] { 1, 2, 3, 4, 5, 6 }, 3);

(new RotateArray()).Rotate(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 2);

(new RotateArray()).Rotate(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3);

////////////////////////////////////////////////////////////////////////////////////////////
/// 58. Length of Last Word (Easy)

iRes = LengthOfLastWord.GetLengthOfLastWord("Hello World");
Debug.Assert(iRes == 5, WRONG);

iRes = LengthOfLastWord.GetLengthOfLastWord("   fly me   to   the moon  ");
Debug.Assert(iRes == 4, WRONG);

iRes = LengthOfLastWord.GetLengthOfLastWord("luffy is still joyboy");
Debug.Assert(iRes == 6, WRONG);

////////////////////////////////////////////////////////////////////////////////////////////
/// 135. Candy (Hard)

iRes = CandyClass.Candy(new int[] { 5, 3, 2, 1, 2, 6, 5, 4, 4, 7 });
Debug.Assert(iRes == 21, WRONG);

iRes = CandyClass.Candy(new int[] { 1, 0, 2 });
Debug.Assert(iRes == 5, WRONG);

iRes = CandyClass.Candy(new int[] { 1, 2, 2 });
Debug.Assert(iRes == 4, WRONG);


////////////////////////////////////////////////////////////////////////////////////////////
/// 122. Best Time to Buy and Sell Stock II

iRes = (new BuySellStockClassII()).MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 });
Debug.Assert(iRes == 7, WRONG);

iRes = (new BuySellStockClassII()).MaxProfit(new int[] { 1, 2, 3, 4, 5 });
Debug.Assert(iRes == 4, WRONG);

iRes = (new BuySellStockClassII()).MaxProfit(new int[] { 7, 6, 4, 3, 1 });
Debug.Assert(iRes == 0, WRONG);

////////////////////////////////////////////////////////////////////////////////////////////
/// 55. Jump Game

var b = JumpGameClass.CanJump(new int[] { 2, 3, 1, 1, 4 });
Debug.Assert(b, WRONG);

b = JumpGameClass.CanJump(new int[] { 3, 2, 1, 0, 4 });
Debug.Assert(!b, WRONG);

////////////////////////////////////////////////////////////////////////////////////////////
/// 45. Jump Game II

iRes = JumpGameClass.CanJumpII(new int[] { 2, 3, 0, 1, 1, 3, 0, 1, 4 });
Debug.Assert(iRes == 4, WRONG);

iRes = JumpGameClass.CanJumpII(new int[] { 2, 3, 0, 1, 1, 2, 0, 1, 4 });
Debug.Assert(iRes == 5, WRONG);

iRes = JumpGameClass.CanJumpII(new int[] { 2, 3, 1, 1, 4 });
Debug.Assert(iRes == 2, WRONG);

iRes = JumpGameClass.CanJumpII(new int[] { 2, 3, 0, 1, 4 });
Debug.Assert(iRes == 2, WRONG);


b = JumpGameClass.IsAnagram("anagram", "nagaram");
Debug.Assert(b, WRONG);

b = JumpGameClass.IsAnagram("anagram", "nagaras");
Debug.Assert(!b, WRONG);

////////////////////////////////////////////////////////////////////////////////////////////
/// 49. Group Anagrams

var listOfLists = GroupAnagramsClass.GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });
// Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
Debug.Assert(listOfLists.Count == 3, WRONG);


listOfLists = GroupAnagramsClass.GroupAnagrams(new string[] { "bdddddddddd", "bbbbbbbbbbc" });
// Expected: [["bbbbbbbbbbc"],["bdddddddddd"]]
Debug.Assert(listOfLists.Count == 2, WRONG);
Debug.Assert(listOfLists[0].Contains("bbbbbbbbbbc") || listOfLists[0].Contains("bdddddddddd"), WRONG);
Debug.Assert(listOfLists[1].Contains("bbbbbbbbbbc") || listOfLists[1].Contains("bdddddddddd"), WRONG);


listOfLists = GroupAnagramsClass.GroupAnagrams(new string[] { "" });
Debug.Assert(listOfLists.Count == 1, WRONG);
Debug.Assert(listOfLists[0][0] == "", WRONG);


listOfLists = GroupAnagramsClass.GroupAnagrams(new string[] { "a" });
Debug.Assert(listOfLists.Count == 1, WRONG);
Debug.Assert(listOfLists[0][0] == "a", WRONG);

////////////////////////////////////////////////////////////////////////////////////////////
/// 347. Top K Frequent Elements

var iarr = TopKFrequentElements.TopKFrequent(new int[] { 1, 1, 1, 2, 2, 3 }, 2);
Debug.Assert(iarr.Length == 2 && iarr[0] == 1 && iarr[1] == 2, WRONG);

iarr = TopKFrequentElements.TopKFrequent(new int[] { 1 }, 1);
Debug.Assert(iarr.Length == 1 && iarr[0] == 1, WRONG);

////////////////////////////////////////////////////////////////////////////////////////////
/// 238. Product of Array Except Self

iarr = ProductOfArrayExceptSelf.ProductExceptSelf(new int[] { 2, 3, 4, 5 });
var iarrc = new int[] { 60, 40, 30, 24 };
Debug.Assert(Enumerable.SequenceEqual(iarr, iarrc), WRONG);

iarr = ProductOfArrayExceptSelf.ProductExceptSelf(new int[] { 1, 2, 3, 4 });
iarrc = new int[] { 24, 12, 8, 6 };
Debug.Assert(Enumerable.SequenceEqual(iarr, iarrc), WRONG);

iarr = ProductOfArrayExceptSelf.ProductExceptSelf(new int[] { -1, 1, 0, -3, 3 });
iarrc = new int[] { 0, 0, 9, 0, 0 };
Debug.Assert(Enumerable.SequenceEqual(iarr, iarrc), WRONG);
