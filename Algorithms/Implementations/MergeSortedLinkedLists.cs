using System;
using System.Collections.Generic;
using System.Linq;

class MergeSortedLinkedLists
{
    public static void Run()
    {
        ListNode l1 = new ListNode(1);
        l1.next = new ListNode(2);
        l1.next.next = new ListNode(3);

        ListNode l2 = new ListNode(3);

        Console.WriteLine(new Solution().MergeTwoLists(l1, l2));
    }


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;

            if (l2 == null)
                return l1;

            ListNode l3;
            if (l1.val < l2.val)
            {
                l3 = l1;
                l1 = l1.next;
            }
            else
            {
                l3 = l2;
                l2 = l2.next;
            }

            ListNode cur = l3;

            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    cur.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    cur.next = l2;
                    l2 = l2.next;
                }
                cur = cur.next;
            }
            if (l1 != null)
                cur.next = l1;
            else
                cur.next = l2;
            return l3;
        }
    }
}