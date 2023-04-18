﻿// See https://aka.ms/new-console-template for more information
using LeetCodeStudyPlanLevel1;
using System;
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


/////////////////////////////////////////////////////////////
///
CMisc cm = new CMisc();
var ir = cm.Reverse(123);
Debug.Assert(ir == 321);

ir = cm.Reverse(-321);
Debug.Assert(ir == -123);

int im = int.MaxValue; // 2 147 483 647 -> 7 463 847 412
var t = Math.Pow(2, 31) - 1;
ir = cm.Reverse(im);
Debug.Assert(ir == 0);

ir = cm.Reverse(int.MinValue + 1);
Debug.Assert(ir == 0);

ir = cm.Reverse(int.MinValue);
Debug.Assert(ir == 0);

var charr = new char[] { 'A', 'b', 'c' };
charr = charr.Reverse().ToArray();
Debug.Assert(charr != null && charr[0] == 'c' && charr.Last() == 'A');

cm.ReverseString(new char[] { 'a' });

cm.ReverseString(new char[] { 'a', 'b' });

cm.ReverseString(new char[] { 'a', 'b', 'c' });



/////////////////////////////////////////////////////////////
// 121. Best Time to Buy and Sell Stock
BuySellStockClass bsc = new BuySellStockClass();
var profit = bsc.MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 });
Debug.Assert(profit == 5);

profit = bsc.MaxProfit(new int[] { 7, 6, 4, 3, 1 });
Debug.Assert(profit == 0);

profit = bsc.MaxProfit(new int[] { 1, 2 });
Debug.Assert(profit == 1);


/////////////////////////////////////////////////////////////
// 409. Longest Palindrome
profit = bsc.LongestPalindrome("a");
Debug.Assert(profit == 1);

profit = bsc.LongestPalindrome("bb");
Debug.Assert(profit == 2);

profit = bsc.LongestPalindrome("ccc");
Debug.Assert(profit == 3);

profit = bsc.LongestPalindrome("abccccdd");
Debug.Assert(profit == 7);

profit = bsc.LongestPalindrome("aaabbbbbccccdd");
Debug.Assert(profit == 13, "Wrong answer");

var str = @"civilwartestingwhetherthatnaptionoranynartionsoconceivedandsodedicatedcanlongendureWeareqmetonagreatbattlefiemldoftzhatwarWehavecometodedicpateaportionofthatfieldasafinalrestingplaceforthosewhoheregavetheirlivesthatthatnationmightliveItisaltogetherfangandproperthatweshoulddothisButinalargersensewecannotdedicatewecannotconsecratewecannothallowthisgroundThebravelmenlivinganddeadwhostruggledherehaveconsecrateditfaraboveourpoorponwertoaddordetractTgheworldadswfilllittlenotlenorlongrememberwhatwesayherebutitcanneverforgetwhattheydidhereItisforusthelivingrathertobededicatedheretotheulnfinishedworkwhichtheywhofoughtherehavethusfarsonoblyadvancedItisratherforustobeherededicatedtothegreattdafskremainingbeforeusthatfromthesehonoreddeadwetakeincreaseddevotiontothatcauseforwhichtheygavethelastpfullmeasureofdevotionthatweherehighlyresolvethatthesedeadshallnothavediedinvainthatthisnationunsderGodshallhaveanewbirthoffreedomandthatgovernmentofthepeoplebythepeopleforthepeopleshallnotperishfromtheearth";

profit = bsc.LongestPalindrome(str);
Debug.Assert(profit == 983, "Wrong answer");


/////////////////////////////////////////////////////////////
/// 589. N-ary Tree Preorder Traversal
TreeClass treeC = new TreeClass();

Node node = new(1);

node.children = new List<Node>() {
    new Node(3, new List<Node>()
    {
        new Node(5),
        new Node(6),
    }),
    new Node(2),
    new Node(4),
};

var listResult = treeC.Preorder(node);
var correct_list = new List<int>() { 1, 3, 5, 6, 2, 4 };
Debug.Assert(Enumerable.SequenceEqual(listResult, correct_list), "Wrong answer");
Debug.WriteLine("Done!");

node = new Node(1, new List<Node>()
{
    new Node(2),
    new Node(3, new List<Node>()
    {
        new Node(6),
        new Node(7, new List<Node>()
        {
            new Node(11, new List<Node>()
            {
                new Node(14)
            })
        }),
    }),
    new Node(4, new List<Node>()
    {
        new Node(8, new List<Node>()
        {
            new Node(12)
        })
    }),
    new Node(5, new List<Node>()
    {
        new Node(9, new List<Node>()
        {
            new Node(13)
        }),
        new Node(10)
    }),
});

listResult = treeC.Preorder(node);
correct_list = new List<int>() { 1, 2, 3, 6, 7, 11, 14, 4, 8, 12, 5, 9, 13, 10 };
Debug.Assert(Enumerable.SequenceEqual(listResult, correct_list), "Wrong answer");
Debug.WriteLine("Done!");



/////////////////////////////////////////////////////////////
/// 102. Binary Tree Level Order Traversal
treeC = new TreeClass();

TreeNode tn = new TreeNode(3,
    new TreeNode(9),
    new TreeNode(20, new TreeNode(15), new TreeNode(7)));

var correct_output = new List<List<int>>()
{
    new List<int> { 3 },
    new List<int> { 9, 20 },
    new List<int> { 15, 7 },
};

var tnres = treeC.LevelOrder(tn);
Debug.Assert(tnres.Count == correct_output.Count);
for (int i = 0; i < correct_output.Count; i++)
{
    Debug.Assert(Enumerable.SequenceEqual(tnres[i], correct_output[i]), "Wrong answer");
}
Debug.WriteLine("Done!");


/////////////////////////////////////////////////////////////
// 429. N-ary Tree Level Order Traversal

node = new(1);

node.children = new List<Node>() {
    new Node(3, new List<Node>()
    {
        new Node(5),
        new Node(6),
    }),
    new Node(2),
    new Node(4),
};

correct_output = new List<List<int>>()
{
    new List<int> { 1 },
    new List<int> { 3, 2, 4 },
    new List<int> { 5, 6 },
};

var lores = treeC.LevelOrder(node);

Debug.Assert(lores.Count == correct_output.Count);
for (int i = 0; i < correct_output.Count; i++)
{
    Debug.Assert(Enumerable.SequenceEqual(lores[i], correct_output[i]), "Wrong answer");
}
Debug.WriteLine("Done!");



/////////////////////////////////////////////////////////////
/// 704. Binary Search
CBinarySearch cbc = new CBinarySearch();

ires = cbc.Search(new int[] { -1, 0, 3, 5, 9, 12 }, 9);
Debug.Assert(ires == 4);

ires = cbc.Search(new int[] { -1, 0, 3, 5, 9, 12 }, 2);
Debug.Assert(ires == -1);


/////////////////////////////////////////////////////////////
/// 278. First Bad Version
VC vc = new VC();
vc.Dict = new Dictionary<int, bool>() { { 1, true } };
ires = vc.FirstBadVersion3(1);
Debug.Assert(ires == 1);

vc.Dict = new Dictionary<int, bool>() { { 1, false }, { 2, true } };
ires = vc.FirstBadVersion3(2);
Debug.Assert(ires == 2);

vc.Dict = new Dictionary<int, bool>()
{
    { 1, false },
    { 2, false },
    { 3, false },
    { 4, true },
    { 5, true }
};
ires = vc.FirstBadVersion3(5);
Debug.Assert(ires == 4);


vc.Dict = new Dictionary<int, bool>()
{
    { 1, false },
    { 2, false },
    { 3, false },
    { 4, false },
    { 5, false },
    { 6, false },
    { 7, false },
    { 8, false },
    { 9, false },
    { 10, false },
    { 11, true },
    { 12, true },
    { 13, true },
    { 14, true },
    { 15, true }
};
ires = vc.FirstBadVersion3(15);
Debug.Assert(ires == 11);
