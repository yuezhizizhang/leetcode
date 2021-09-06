using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Program
    {
        static void Main(string[] args)
        {
            var median = new MedianFinder();
            median.AddNum(6);
            median.AddNum(10);
            median.AddNum(2);
            median.AddNum(6);
            median.AddNum(5);
            median.AddNum(0);
            var value = median.FindMedian();
            median.AddNum(3);
            value = median.FindMedian();
        }
    }

    public class MedianFinder
    {
        List<int> numbers;

        /** initialize your data structure here. */
        public MedianFinder()
        {
            numbers = new List<int>();
        }

        public void AddNum(int num)
        {
            var index = numbers.BinarySearch(num);

            if (index >= 0)
            {
                numbers.Insert(index, num);
            }
            else
            {
                numbers.Insert(~index, num);
            }
        }

        public double FindMedian()
        {
            var midIndex = numbers.Count / 2;

            if (numbers.Count % 2 == 0)
            {
                return (numbers[midIndex] + numbers[midIndex - 1]) / 2.0;
            }
            else
            {
                return numbers[midIndex];
            }
        }
    }

    public class MedianFinderUsingHeap
    {
        private Heap minHeap;
        private Heap maxHeap;

        /** initialize your data structure here. */
        public MedianFinderUsingHeap()
        {
            this.minHeap = new Heap(new MinComparer());
            this.maxHeap = new Heap(new MaxComparer());
        }

        public void AddNum(int num)
        {
            this.maxHeap.Add(num);

            this.minHeap.Add(this.maxHeap.Top());
            this.maxHeap.Delete();

            if (this.minHeap.Size > this.maxHeap.Size)
            {
                this.maxHeap.Add(this.minHeap.Top());
                this.minHeap.Delete();
            }
        }

        public double FindMedian()
        {
            var total = this.minHeap.Size + this.maxHeap.Size;
            if (total % 2 == 0)
            {
                return (this.minHeap.Top() + this.maxHeap.Top()) / 2.0;
            }
            else
            {
                return this.maxHeap.Top();
            }
        }
    }

    public class Heap
    {
        private IList<int> heap;
        private IComparer<int> comparer;

        public int Size 
        {
            get => this.heap.Count;
        }

        public Heap(IComparer<int> comparer)
        {
            this.heap = new List<int>();
            this.comparer = comparer;
        }

        public int Top()
        {
            if (this.heap.Count < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.heap[0];
        }

        public void Add(int num)
        {
            this.heap.Add(num);
            this.SiftUp(heap.Count - 1);
        }

        public bool Delete()
        {
            if (this.heap.Count < 1)
            {
                return false;
            }

            var last = this.heap[this.heap.Count - 1];
            this.heap.RemoveAt(this.heap.Count - 1);
            if (this.heap.Count > 0)
            {
                this.heap[0] = last;
                this.SiftDown();
            }
            return true;
        }

        private void SiftUp(int index)
        {
            if (index <= 0 || index >= heap.Count)
            {
                return;
            }

            var parent = (index - 1) / 2;
            while (parent >= 0)
            {
                var curr = this.heap[index];
                var swap = this.heap[parent];
                if (this.comparer.Compare(curr, swap) < 0)
                {
                    this.heap[index] = swap;
                    this.heap[parent] = curr;
                }

                index = parent;
                parent = index == 0 ? -1 : (index - 1) / 2;
            }
        }

        private void SiftDown()
        {
            var curr = 0;

            while (curr < this.heap.Count)
            {
                var left = curr * 2 + 1;
                var right = curr * 2 + 2;
                var swap = -1;

                if (right >= this.heap.Count)
                {
                    if (left >= this.heap.Count)
                    {
                        return;
                    }
                    else
                    {
                        swap = left;
                    }
                }
                else
                {
                    if (this.comparer.Compare(this.heap[left], this.heap[right]) < 0)
                    {
                        swap = left;
                    }
                    else
                    {
                        swap = right;
                    }
                }

                if (this.comparer.Compare(this.heap[swap], this.heap[curr]) < 0)
                {
                    var value = this.heap[curr];
                    this.heap[curr] = this.heap[swap];
                    this.heap[swap] = value;

                    curr = swap;
                }
                else
                {
                    return;
                }
            }
        }
    }

    public class MinComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x - y;
        }
    }

    public class MaxComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y - x;
        }
    }
}
