// See https://aka.ms/new-console-template for more information
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



/////////////////////////////////////////////////////////////
//  21. Merge Two Sorted Lists
Solution2 sol2 = new Solution2();

var a3 = new ListNode(4);
var a2 = new ListNode(2, a3);
var a1 = new ListNode(1, a2);

var b3 = new ListNode(4);
var b2 = new ListNode(3, b3);
var b1 = new ListNode(1, b2);

var res_list = sol2.MergeTwoLists(a1, b1);
Debug.Assert(res_list != null);
Debug.Assert(res_list.val == 1);
Debug.Assert(res_list.next.val == 1);
Debug.Assert(res_list.next.next.val == 2);
Debug.Assert(res_list.next.next.next.val == 3);
Debug.Assert(res_list.next.next.next.next.val == 4);
Debug.Assert(res_list.next.next.next.next.next.val == 4);
Debug.Assert(res_list.next.next.next.next.next.next == null);



/////////////////////////////////////////////////////////////
// 206. Reverse Linked List

var c5 = new ListNode(5);
var c4 = new ListNode(4, c5);
var c3 = new ListNode(3, c4);
var c2 = new ListNode(2, c3);
var c1 = new ListNode(1, c2);

res_list = sol2.ReverseList(c1);

Debug.Assert(res_list != null && res_list.val == 5);
Debug.Assert(res_list.next != null && res_list.next.val == 4);
Debug.Assert(res_list.next.next != null && res_list.next.next.val == 3);
Debug.Assert(res_list.next.next.next != null && res_list.next.next.next.val == 2);
Debug.Assert(res_list.next.next.next.next != null && res_list.next.next.next.next.val == 1);
Debug.Assert(res_list.next.next.next.next.next == null);


/////////////////////////////////////////////////////////////
// 876. Middle of the Linked List
var e1 = new ListNode(1);
res_list = sol2.MiddleNode(e1);
Debug.Assert(res_list != null && res_list.val == 1);

var d5 = new ListNode(5);
var d4 = new ListNode(4, d5);
var d3 = new ListNode(3, d4);
var d2 = new ListNode(2, d3);
var d1 = new ListNode(1, d2);

res_list = sol2.MiddleNode(d1);

Debug.Assert(res_list != null && res_list.val == 3);
Debug.Assert(res_list.next != null && res_list.next.val == 4);
Debug.Assert(res_list.next.next != null && res_list.next.next.val == 5);
Debug.Assert(res_list.next.next.next == null);

var d6 = new ListNode(6);
d5.next = d6;

res_list = sol2.MiddleNode(d1);

Debug.Assert(res_list != null && res_list.val == 4);
Debug.Assert(res_list.next != null && res_list.next.val == 5);
Debug.Assert(res_list.next.next != null && res_list.next.next.val == 6);
Debug.Assert(res_list.next.next.next == null);


/////////////////////////////////////////////////////////////
// 142. Linked List Cycle II

var f4 = new ListNode(-4);
var f3 = new ListNode(0, f4);
var f2 = new ListNode(2, f3);
var f1 = new ListNode(3, f2);

f4.next = f2;

res_list = sol2.DetectCycle2(f1);
Debug.Assert(res_list != null && res_list.val == 2);
Debug.Assert(res_list.next != null && res_list.next.val == 0);
Debug.Assert(res_list.next.next != null && res_list.next.next.val == -4);
//tail connects to node index 1