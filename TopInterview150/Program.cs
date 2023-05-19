// https://leetcode.com/studyplan/top-interview-150/
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

