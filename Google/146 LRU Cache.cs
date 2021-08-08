using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var cache = new LRUCache(2);
            cache.Put(2, 1);
            cache.Put(3, 2);
            cache.Get(3);
            cache.Get(2);
            cache.Put(4, 3);
            cache.Get(2);
            cache.Get(3);
            cache.Get(4);
        }
    }

    public class LRUCache
    {
        private Dictionary<int, Data> Cache;
        private int Capacity;
        private Data Head;
        private Data Tail;

        public LRUCache(int capacity)
        {
            this.Cache = new Dictionary<int, Data>(capacity);
            this.Capacity = capacity;
        }

        public int Get(int key)
        {
            if (this.Cache.ContainsKey(key))
            {
                var data = this.Cache[key];
                this.RemoveNode(data);
                this.AddNode(data);

                return data.Value;
            }
            else
            {
                return -1;
            }
        }

        public void Put(int key, int value)
        {
            if (this.Cache.ContainsKey(key))
            {
                var data = this.Cache[key];
                data.Value = value;
                this.RemoveNode(data);
                this.AddNode(data);
            }
            else if (this.Cache.Count < this.Capacity)
            {
                var data = new Data
                {
                    Key = key,
                    Value = value,
                    Prev = this.Tail,
                };

                this.Cache[key] = data;
                this.AddNode(data);
            }
            else
            {
                var data = this.Head;
                var oldKey = data.Key;
                data.Key = key;
                data.Value = value;
                this.Cache.Remove(oldKey);
                this.Cache.Add(key, data);

                this.RemoveNode(data);
                this.AddNode(data);
            }
        }

        private void RemoveNode(Data data)
        {
            if (data == null)
            {
                return;
            }

            if (data.Prev != null)
            {
                data.Prev.Next = data.Next;
            }

            if (data.Next != null)
            {
                data.Next.Prev = data.Prev;
            }

            if (this.Head == data)
            {
                this.Head = data.Next;
            }

            if (this.Tail == data)
            {
                this.Tail = data.Prev;
            }
        }

        private void AddNode(Data data)
        {
            if (data == null)
            {
                return;
            }

            data.Prev = this.Tail;
            data.Next = null;

            if (this.Tail != null)
            {
                this.Tail.Next = data;
            }
            this.Tail = data;

            if (this.Head == null)
            {
                this.Head = data;
            }
        }
    }

    class Data
    {
        public int Key { get; set; }
        public int Value { get; set; }
        public Data Prev { get; set; }
        public Data Next { get; set; }
    }
}
