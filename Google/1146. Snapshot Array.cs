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
            var snap = new SnapshotArray(3);
            snap.Set(0, 5);
            snap.Snap();
            snap.Set(0, 6);
            snap.Get(0, 0);
        }
    }

    public class SnapshotArray
    {
        private const int InitialValue = 0;
        private int Capacity { get; set; }
        private Dictionary<int, IList<int>> Snapshots { get; set; }
        private int SnapId { get; set; }

        public SnapshotArray(int length)
        {
            this.Capacity = length;
            this.Snapshots = new Dictionary<int, IList<int>>();
        }

        public void Set(int index, int val)
        {
            if (index < 0 || index >= Capacity) return;

            IList<int> list;
            int fill;
            if (this.Snapshots.ContainsKey(index))
            {
                list = this.Snapshots[index];
                fill = list.Last();
            }
            else
            {
                list = new List<int>();
                fill = InitialValue;
                this.Snapshots[index] = list;
            }

            var curr = list.Count;
            while (curr++ <= this.SnapId) list.Add(fill);

            list[this.SnapId] = val;
        }

        public int Snap()
        {
            this.SnapId++;
            return this.SnapId - 1;
        }

        public int Get(int index, int snap_id)
        {
            if (!this.Snapshots.ContainsKey(index)) return InitialValue;

            var history = this.Snapshots[index];
            if (history.Count <= snap_id) return history.Last();
            else return history[snap_id];
        }
    }

    /**
     * Your SnapshotArray object will be instantiated and called as such:
     * SnapshotArray obj = new SnapshotArray(length);
     * obj.Set(index,val);
     * int param_2 = obj.Snap();
     * int param_3 = obj.Get(index,snap_id);
     */
}
