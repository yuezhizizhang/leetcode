using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var intervals = new int[6][] { new int[2] { 1923, 2986 }, new int[2] { 848, 3846 }, new int[2] { 4284, 5907 }, new int[2] { 4466, 4781 }, new int[2] { 518, 2918 }, new int[] { 300, 5870 } };
            var solution = new Solution();
            solution.MinMeetingRooms(intervals);
        }
    }

    public class Solution
    {
        public int MinMeetingRooms(int[][] intervals)
        {
            if (intervals == null || intervals.Length < 1)
            {
                return 0;
            }

            var size = intervals.Length;
            if (size == 1)
            {
                return 1;
            }

            var starts = new int[size];
            var ends = new int[size];

            for (var i = 0; i < size; i++)
            {
                starts[i] = intervals[i][0];
                ends[i] = intervals[i][1];
            }

            Array.Sort(starts);
            Array.Sort(ends);

            var rooms = 0;
            var endPtr = 0;
            for (var i = 0; i < size; i++)
            {
                if (starts[i] < ends[endPtr])
                {
                    rooms++;
                }
                else
                {
                    endPtr++;
                }
            }

            return rooms;
        }

        public int MinMeetingRoomsSlow(int[][] intervals)
        {
            var orderedByStartTime = intervals.OrderBy(interval => interval[0]).ToArray();

            var rooms = 1;
            var head = new Node(orderedByStartTime[0][1]);
            var tail = head;
            for (var i = 1; i < orderedByStartTime.Length; i++)
            {
                if (orderedByStartTime[i][0] < head.Value)
                {
                    var node = new Node(orderedByStartTime[i][1]);
                    AddNode(ref head, ref tail, node);
                    rooms++;
                }
                else
                {
                    head.Value = orderedByStartTime[i][1];
                    if (tail != head)
                    {
                        var node = head;
                        head = head.Next;
                        AddNode(ref head, ref tail, node);
                    }
                }
            }

            return rooms;
        }

        private void AddNode(ref Node head, ref Node tail, Node node)
        {
            var curr = head;
            var prev = head;
            while (curr != null)
            {
                if (node.Value < curr.Value)
                {
                    node.Next = curr;
                    if (head == curr)
                    {
                        head = node;
                    }
                    else
                    {
                        prev.Next = node;
                    }
                    return;
                }

                prev = curr;
                curr = curr.Next;
            }

            tail.Next = node;
            node.Next = null;
            tail = node;
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value, Node next = null)
        {
            this.Value = value;
            this.Next = next;
        }
    }
}
