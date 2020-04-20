using System;
using System.Collections;
using System.Collections.Generic;

class Sum2NumbersLinkedList
{
    public static void Run()
    {
        ListNode l1 = new ListNode(2);
        l1.next = new ListNode(4);
        l1.next.next = new ListNode(3);

        ListNode l2 = new ListNode(5);
        l2.next = new ListNode(6);
        l2.next.next = new ListNode(4);
        l2.next.next = new ListNode(1);


        Console.WriteLine(new Solution().AddTwoNumbers(l1,l2));
    }



    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode head=null, l3=null;
            int digit = 0;
            while (l1 != null || l2 != null)
            {
                if (l1 != null)
                {
                    digit += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    digit += l2.val;
                    l2 = l2.next;
                }

                var node= new ListNode(digit % 10);
                if (l3 == null)
                {
                    l3 = node;
                    head = l3;
                }
                else
                {
                    l3.next = node;
                    l3 = l3.next;
                }
                digit /= 10;
            }
            if (digit > 0)
                l3.next = new ListNode(digit);
            return head;
        }
    }
}