namespace LeetCodeAPR2023
{
    /// <summary>
    /// Definition for singly-linked list.
    /// </summary>
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

    internal class AddTwoNumbersClass
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode res = new ListNode(0);
            ListNode ptr = res;
            int perenos = 0;
            ListNode? t1 = l1;
            ListNode? t2 = l2;

            while (t1 != null || t2 != null)
            {
                int sum = (t1?.val ?? 0) + (t2?.val ?? 0) + perenos;
                perenos = sum / 10;
                ptr.next = new ListNode(sum % 10);
                ptr = ptr.next;
                t1 = t1?.next;
                t2 = t2?.next;
            }

            if (perenos == 1) ptr.next = new ListNode(1);

            return res?.next ?? new ListNode(0);
        }
    }
}