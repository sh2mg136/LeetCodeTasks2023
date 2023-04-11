﻿// See https://aka.ms/new-console-template for more information
using LeetCodeStudyPlanLevel1;
using System.Diagnostics;

Console.WriteLine("LeetCode Study Plan - 1");

// 1480. Running Sum of 1d Array
// https://leetcode.com/problems/running-sum-of-1d-array/?envType=study-plan&id=level-1

Solution sol = new Solution();
var res = sol.RunningSum(new int[] { 1, 2, 3, 4 });
var correct = new int[] { 1, 3, 6, 10 };
Debug.Assert(Enumerable.SequenceEqual(res, correct));

res = sol.RunningSum(new int[] { 1, 1, 1, 1, 1 });
correct = new int[] { 1, 2, 3, 4, 5 };
Debug.Assert(Enumerable.SequenceEqual(res, correct));

res = sol.RunningSum(new int[] { 3, 1, 2, 10, 1 });
correct = new int[] { 3, 4, 6, 16, 17 };
Debug.Assert(Enumerable.SequenceEqual(res, correct));



/////////////////////////////////////////////////////////////
// 724. Find Pivot Index
int ires = sol.PivotIndexV2(new int[] { 1, 7, 3, 6, 5, 6 });
Debug.Assert(ires == 3);

ires = sol.PivotIndexV2(new int[] { 1, 2, 3 });
Debug.Assert(ires == -1);

ires = sol.PivotIndexV2(new int[] { 2, 1, -1 });
Debug.Assert(ires == 0);



/////////////////////////////////////////////////////////////
///
var bres = sol.IsIsomorphic("egg", "add");
Debug.Assert(bres);

bres = sol.IsIsomorphic("foo", "bar");
Debug.Assert(!bres);

bres = sol.IsIsomorphic("paper", "title");
Debug.Assert(bres);

bres = sol.IsIsomorphic("aba", "baa");
Debug.Assert(!bres);

bres = sol.IsIsomorphic("badc", "baba");
Debug.Assert(!bres);



/////////////////////////////////////////////////////////////
// 392. Is Subsequence
bres = sol.IsSubsequence("", "ahbgdc");
Debug.Assert(bres);

bres = sol.IsSubsequence("acb", "ahbgdc");
Debug.Assert(!bres);

bres = sol.IsSubsequence("abc", "ahbgdc");
Debug.Assert(bres);

bres = sol.IsSubsequence("abc", "haahgdc");
Debug.Assert(!bres);

bres = sol.IsSubsequence("axc", "ahbgdc");
Debug.Assert(!bres);
