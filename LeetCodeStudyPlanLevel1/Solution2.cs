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
            ListNode? node = null;
            ListNode? ptr = head;
            ListNode? next_node;

            while (ptr != null)
            {
                next_node = ptr.next;
                ptr.next = node;
                node = ptr;
                ptr = next_node;
            }

            return node;
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
    }
}