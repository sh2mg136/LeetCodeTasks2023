using System.Diagnostics;

namespace LeetCodeStudyPlanLevel1
{
    public class ListNode
    {
        public int val;
        public ListNode? next;

        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }

        public override string ToString()
        {
            var n = next == null ? "NULL" : next.val.ToString();
            var nn = (next != null && next?.next != null) ? next?.next?.val.ToString() : "NULL";
            return $"{val} -> {n} -> {nn}";
        }
    }

    internal class Solution2
    {
        /// <summary>
        /// 21. Merge Two Sorted Lists
        /// https://leetcode.com/problems/merge-two-sorted-lists/?envType=study-plan&id=level-1
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            return MergeTwoListsV3(list1, list2);

            /*
            var r = (new Random()).Next(3);

            switch (r)
            {
                default:
                case 0:
                    return MergeTwoListsV1(list1, list2);

                case 1:
                    return MergeTwoListsV2(list1, list2);

                case 2:
                    return MergeTwoListsV2(list1, list2);
            }
            */

            /*
            if (new Random().Next(10) >= 5)
                return MergeTwoListsV1(list1, list2);
            else
                return MergeTwoListsV2(list1, list2);
            */
        }

        private ListNode MergeTwoListsV1(ListNode list1, ListNode list2)
        {
            if (list1 == null && list2 == null) return new ListNode(0);
            if (list1 == null && list2 != null) return list2;
            if (list1 != null && list2 == null) return list1;

            if (list1?.val < list2?.val)
            {
                list1.next = MergeTwoLists(list1.next, list2);
                return list1;
            }
            else
            {
                list2.next = MergeTwoLists(list1, list2.next);
                return list2;
            }
        }

        private ListNode MergeTwoListsV2(ListNode list1, ListNode list2)
        {
            if (list1 == null && list2 == null) return new ListNode(0);
            if (list1 == null && list2 != null) return list2;
            if (list1 != null && list2 == null) return list1;

            ListNode pnt;

            if (list1.val <= list2.val)
            {
                pnt = list1;
                list1 = list1.next;
            }
            else
            {
                pnt = list2;
                list2 = list2.next;
            }

            ListNode cur = pnt;

            while (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    cur.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    cur.next = list2;
                    list2 = list2.next;
                }
                cur = cur.next;
            }

            if (list1 != null)
            {
                cur.next = list1;
            }
            else if (list2 != null)
            {
                cur.next = list2;
            }

            return pnt;
        }

        private ListNode MergeTwoListsV3(ListNode list1, ListNode list2)
        {
            if (list1 == null && list2 == null) return new ListNode(0);
            if (list1 == null && list2 != null) return list2;
            if (list1 != null && list2 == null) return list1;

            ListNode pnt;

            if (list1.val <= list2.val)
            {
                pnt = list1;
                list1 = list1.next;
            }
            else
            {
                pnt = list2;
                list2 = list2.next;
            }

            ListNode cur = pnt;

            while (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    cur.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    cur.next = list2;
                    list2 = list2.next;
                }
                cur = cur.next;
            }

            if (list1 != null)
            {
                cur.next = list1;
            }
            else if (list2 != null)
            {
                cur.next = list2;
            }

            return pnt;
        }

        /// <summary>
        /// 206. Reverse Linked List
        /// https://leetcode.com/problems/reverse-linked-list/?envType=study-plan&id=level-1
        /// Given the head of a singly linked list, reverse the list, and return the reversed list.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode? ReverseList(ListNode head)
        {
            // return ReverseList_V1(head);
            return ReverseList_V2(head);
        }

        /// <summary>
        /// Iterative solution
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        private ListNode? ReverseList_V1(ListNode head)
        {
            ListNode? node = null;
            ListNode? ptr = head;
            ListNode? next;

            while (ptr != null)
            {
                next = ptr.next;
                ptr.next = node;
                node = ptr;
                ptr = next;
            }

            return node;
        }

        /// <summary>
        /// Iterative solution 2
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        private ListNode? ReverseList_V2(ListNode head)
        {
            ListNode? prev = null, curr = head, temp;

            while (curr != null)
            {
                temp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = temp;
            }

            return prev;
        }

        /// <summary>
        /// 876. Middle of the Linked List
        /// https://leetcode.com/problems/middle-of-the-linked-list/?envType=study-plan&id=level-1
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode? MiddleNode(ListNode head)
        {
            if (head == null)
                return null;

            ListNode? ptr = head;
            ListNode? next_node = null;

            int cnt = 0;
            while (ptr != null)
            {
                cnt++;
                next_node = ptr.next;
                ptr = next_node;
            }
            Debug.Assert(cnt > 0);

            if (cnt == 1) return head;

            var mid = cnt / 2;
            cnt = 0;
            ptr = head;
            next_node = null;

            while (ptr != null)
            {
                cnt++;
                next_node = ptr.next;
                ptr = next_node;
                if (cnt == mid) break;
            }

            return next_node;
        }

        /// <summary>
        /// 142. Linked List Cycle II
        /// .
        /// https://leetcode.com/problems/linked-list-cycle-ii/?envType=study-plan&id=level-1
        /// .
        /// Given the head of a linked list, return the node where the cycle begins.
        /// If there is no cycle, return null.
        /// There is a cycle in a linked list if there is some node in the list
        /// that can be reached again by continuously following the next pointer.Internally,
        /// pos is used to denote the index of the node that tail's next pointer is connected to (0-indexed).
        /// It is -1 if there is no cycle.
        /// Note that pos is not passed as a parameter.
        /// .
        /// Do not modify the linked list.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode? DetectCycle(ListNode head)
        {
            Dictionary<ListNode, ListNode?> dict = new Dictionary<ListNode, ListNode?>();
            ListNode? ptr = head;
            ListNode? next_node = null;

            while (ptr != null)
            {
                dict.Add(ptr, ptr.next);
                Console.WriteLine(ptr.val);

                if (ptr.next != null && dict.ContainsKey(ptr.next))
                {
                    return ptr.next;
                }

                next_node = ptr.next;
                ptr = next_node;
            }

            return null;
        }

        public ListNode? DetectCycle2(ListNode head)
        {
            ListNode? slow = head;
            ListNode? fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow?.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    slow = head;
                    while (slow != fast)
                    {
                        slow = slow?.next;
                        fast = fast?.next;
                    }
                    return slow;
                }
            }

            return null;
        }
    }
}