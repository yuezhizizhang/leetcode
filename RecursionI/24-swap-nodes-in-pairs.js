class ListNode {
  constructor(data, next = null) {
    this.data = data;
    this.next = next;
  }
}

class LinkedList {
  constructor() {
    this.head = null;
  }
  
  append(data) {
    const node = new ListNode(data);
    
    if (!this.head) {
      this.head = node;
      return this.head;
    }
    
    let tail = this.head;
    while(!!tail.next) {
      tail = tail.next;
    }
    tail.next = node;
    
    return this.head;
  }
}

/**
 * Swap Nodes in Pairs
 * https://leetcode.com/problems/swap-nodes-in-pairs/
 *
 * Given a linked list, swap every two adjacent nodes and return its head.
 * e.g.  for a list 1-> 2 -> 3 -> 4, one should return the head of list as 2 -> 1 -> 4 -> 3.
 * 
 * Definition for singly-linked list.
 * function ListNode(val) {
 *     this.val = val;
 *     this.next = null;
 * }
 * 
 * @param {ListNode} head
 * @return {ListNode}
 */
function swapPairs(head) {
  if (!head || !head.next) {
    return head;
  }
  
  const first = head;
  const second = head.next;
  const tail = head.next.next;
  second.next = first;
  first.next = swapPairs(tail);
  return second;
}