/**
 * Merge Two Sorted Lists
 * https://leetcode.com/problems/merge-two-sorted-lists/
 * 
 * Merge two sorted linked lists and return it as a new list. The new list should be made by splicing together the nodes of the first two lists.
 * 
 * Example:
 * Input: 1->2->4, 1->3->4
 * Output: 1->1->2->3->4->4
 */
/**
 * Definition for singly-linked list.
 * function ListNode(val) {
 *     this.val = val;
 *     this.next = null;
 * }
 */
/**
 * By recursion
 *
 * @param {ListNode} l1
 * @param {ListNode} l2
 * @return {ListNode}
 */
var mergeTwoListsRecursively = function(l1, l2) {
  if (!l1 || !l2) {
    return l1 || l2;
  }
  
  let head = null;
  if (l1.val <= l2.val) {
    head = l1;
    head.next = mergeTwoLists(l1.next, l2);
  } else {
    head = l2;
    head.next = mergeTwoLists(l1, l2.next);
  }
  
  return head;
};

/**
 * By iterate through the shorter one of l1 and l2.
 *
 * @param {ListNode} l1
 * @param {ListNode} l2
 * @return {ListNode}
 */
var mergeTwoListsIteratively = function(l1, l2) {
  if (!l1 || !l2) {
    return l1 || l2;
  }
  
  let head = null, tail = null;
  if (l1.val <= l2.val) {
    head = l1;
    tail = l1;
    l1 = l1.next;
  } else {
    head = l2;
    tail = l2;
    l2 = l2.next;
  }
  
  while (!!l1 && !!l2) {
    if (l1.val <= l2.val) {
      tail.next = l1;
      tail = l1;
      l1 = l1.next;
    } else {
      tail.next = l2;
      tail = l2;
      l2 = l2.next;
    }
  }

  tail.next = l1 || l2;
  
  return head;
};

