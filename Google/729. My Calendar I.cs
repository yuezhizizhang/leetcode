using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class Program
    {
        static void Main(string[] args)
        {
            var calendar = new MyCalendar();
            calendar.Book(10, 20);
            calendar.Book(15, 25);
            calendar.Book(20, 30);
        }
    }

    public class MyCalendar
    {
        private SortedList<int, int> Bookings { get; set; }

        public MyCalendar()
        {
            this.Bookings = new SortedList<int, int>();
        }

        public bool Book(int start, int end)
        {
            var ends = this.Bookings.Keys;
            var starts = this.Bookings.Values;
            var size = ends.Count;

            var pos = -1;
            for (var i = 0; i < size; i++)
            {
                if (start < ends[i]) break;
                
                pos = i;
            }

            if (size == 0 ||
                pos < 0 && end <= starts[0] ||
                pos == ends.Count - 1 ||
                end <= starts[pos + 1])
            {
                this.Bookings.Add(end, start);
                return true;
            }

            return false;
        }
    }

    /**
     * Your MyCalendar object will be instantiated and called as such:
     * MyCalendar obj = new MyCalendar();
     * bool param_1 = obj.Book(start,end);
     */
}
