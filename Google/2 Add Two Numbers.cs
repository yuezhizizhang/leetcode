using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var p1 = l1;
            var p2 = l2;
            ListNode head = null;
            ListNode next = null;

            var carry = 0;
            while (p1 != null || p2 != null)
            {
                var n1 = 0;
                if (p1 != null)
                {
                    n1 = p1.val;
                    p1 = p1.next;
                }

                var n2 = 0;
                if (p2 != null)
                {
                    n2 = p2.val;
                    p2 = p2.next;
                }

                var sum = n1 + n2 + carry;
                var value = sum % 10;
                carry = (int)(sum / 10);

                var node = new ListNode(value);
                if (head == null)
                {
                    head = node;
                    next = head;
                }
                else
                {
                    next.next = node;
                    next = next.next;
                }
            }

            if (carry != 0)
            {
                next.next = new ListNode(carry);
            }

            return head;
        }

        public class ListNode
        {
            public int val { get; set; }
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }

    
}
