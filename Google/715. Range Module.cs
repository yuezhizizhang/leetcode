using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class RangeModule
    {
        private SortedList<int, int> Ranges { get; set; }

        public RangeModule()
        {
            this.Ranges = new SortedList<int, int>();
        }

        public void AddRange(int left, int right)
        {
            var starts = this.Ranges.Keys;
            var ends = this.Ranges.Values;
            var size = starts.Count;

            int i;
            for (i = 0; i < size; i++)
            {
                if (left <= ends[i]) break;
            }

            if (i >= size)
            {
                this.Ranges.Add(left, right);
                return;
            }

            if (right < starts[i])
            {
                this.Ranges.Add(left, right);
                return;
            }

            left = Math.Min(starts[i], left);
            int j;
            for (j = i; j < size; j++)
            {
                if (right < starts[j]) break;
            }

            right = Math.Max(right, ends[j - 1]);
            for (var index = j - 1; index >= i; index --)
            {
                this.Ranges.RemoveAt(index);
            }
            this.Ranges.Add(left, right);
        }

        public bool QueryRange(int left, int right)
        {
            foreach (var pair in this.Ranges)
            {
                if (left >= pair.Key && right <= pair.Value) return true;

                if (left <= pair.Value) return false;
            }

            return false;
        }

        public void RemoveRange(int left, int right)
        {
            var starts = this.Ranges.Keys;
            var ends = this.Ranges.Values;
            var size = starts.Count;

            int i;
            for (i = 0; i < size; i++)
            {
                if (left < ends[i]) break;
            }

            if (i >= size) return;

            if (right <= starts[i]) return;

            int j = i;
            for (; j < size; j++)
            {
                if (right < starts[j]) break;
            }

            var begin = starts[i];
            var end = ends[j - 1];
            for (var index = j - 1; index >= i; index--)
            {
                this.Ranges.RemoveAt(index);
            }

            if (left > begin) this.Ranges.Add(begin, left);

            if (right < end) this.Ranges.Add(right, end);
        }
    }

    /**
     * Your RangeModule object will be instantiated and called as such:
     * RangeModule obj = new RangeModule();
     * obj.AddRange(left,right);
     * bool param_2 = obj.QueryRange(left,right);
     * obj.RemoveRange(left,right);
     */
}
