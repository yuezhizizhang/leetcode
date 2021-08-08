## 2. Add Two Numbers
https://leetcode.com/problems/add-two-numbers/

> You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
> You may assume the two numbers do not contain any leading zero, except the number 0 itself.
>
> Example 1:
>   Input: l1 = [2,4,3], l2 = [5,6,4]
>   Output: [7,0,8]
>   Explanation: 342 + 465 = 807.
>
> Example 2:
>   Input: l1 = [0], l2 = [0]
>   Output: [0]
>
> Example 3:
>   Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
>   Output: [8,9,9,9,0,0,0,1]
>
> Constraints:
> * The number of nodes in each linked list is in the range [1, 100].
> * 0 <= Node.val <= 9
> * It is guaranteed that the list represents a number that does not have leading zeros.

**Solution:**

Time Complexity O(n), Space Complexity: O(n)

```C#
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
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
}
```

```JavaScript
/**
 * Definition for singly-linked list.
 * function ListNode(val, next) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.next = (next===undefined ? null : next)
 * }
 */
/**
 * @param {ListNode} l1
 * @param {ListNode} l2
 * @return {ListNode}
 */
var addTwoNumbers = function(l1, l2) {
    let carry = 0;
    let head = null;
    let next = null;

    while (l1 != null || l2 != null) {
    	let n1 = 0;
    	if (l1 != null) {
    		n1 = l1.val;
    		l1 = l1.next;
    	}

    	let n2 = 0;
    	if (l2 != null) {
    		n2 = l2.val;
    		l2 = l2.next;
    	}

    	let sum = n1 + n2 + carry;
    	carry = Math.floor(sum / 10);
    	let node = new ListNode(sum % 10);

    	if (head == null) {
    		head = node;
    		next = node;
    	} else {
    		next.next = node;
    		next = next.next;
    	}
    }

    if (carry != 0) {
    	let node = new ListNode(carry);
    	next.next = node;
    }

    return head;
};
```