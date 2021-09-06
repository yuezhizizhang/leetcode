using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomizedSet obj = new RandomizedSet();
            bool param_1 = obj.Insert(0);
            int val = obj.GetRandom();
            bool param_2 = obj.Remove(0);
            bool param_3 = obj.Insert(0);
        }
    }

    public class RandomizedSet
    {
        private readonly IList<int> Numbers;
        private readonly IDictionary<int, int> NumIndexPair;
        private readonly Random RandomGen;

        /** Initialize your data structure here. */
        public RandomizedSet()
        {
            this.Numbers = new List<int>();
            this.NumIndexPair = new Dictionary<int, int>();
            this.RandomGen = new Random();
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (this.NumIndexPair.ContainsKey(val))
            {
                return false;
            }

            this.Numbers.Add(val);
            this.NumIndexPair.Add(val, this.Numbers.Count - 1);
            return true;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (this.Numbers.Count < 1 || !this.NumIndexPair.ContainsKey(val))
            {
                return false;
            }

            var index = this.NumIndexPair[val];
            this.NumIndexPair.Remove(val);
            var last = this.Numbers.Count - 1;
            val = this.Numbers[last];
            this.Numbers.RemoveAt(last);
            if (index != last)
            {
                this.Numbers[index] = val;
                this.NumIndexPair[val] = index;
            }
            return true;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            if (this.Numbers.Count < 1)
            {
                return 0;
            }

            var index = this.RandomGen.Next(this.Numbers.Count);
            return this.Numbers[index];
        }
    }

    /**
     * Your RandomizedSet object will be instantiated and called as such:
     * RandomizedSet obj = new RandomizedSet();
     * bool param_1 = obj.Insert(val);
     * bool param_2 = obj.Remove(val);
     * int param_3 = obj.GetRandom();
     */
}
