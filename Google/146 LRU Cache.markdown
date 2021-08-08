## 146. LRU Cache
https://leetcode.com/problems/lru-cache/

> Design a data structure that follows the constraints of a Least Recently Used (LRU) cache.
> Implement the LRUCache class:
>
> * LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
> * int get(int key) Return the value of the key if the key exists, otherwise return -1.
> * void put(int key, int value) Update the value of the key if the key exists. Otherwise, add the key-value pair to the cache. If the number of keys exceeds the capacity from this operation, evict the least recently used key.
>
> The functions get and put must each run in O(1) average time complexity.
>
> Example 1:
> Input
>   ["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
>   [[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]
> Output
>   [null, null, null, 1, null, -1, null, -1, 3, 4]
> Explanation
>   LRUCache lRUCache = new LRUCache(2);
>   lRUCache.put(1, 1); // cache is {1=1}
>   lRUCache.put(2, 2); // cache is {1=1, 2=2}
>   lRUCache.get(1);    // return 1
>   lRUCache.put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
>   lRUCache.get(2);    // returns -1 (not found)
>   lRUCache.put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
>   lRUCache.get(1);    // return -1 (not found)
>   lRUCache.get(3);    // return 3
>   lRUCache.get(4);    // return 4
>
> Constraints:
> * 1 <= capacity <= 3000
> * 0 <= key <= 104
> * 0 <= value <= 105
> * At most 2 * 105 calls will be made to get and put.

**Solution:**

Since get and put operations run in o(1) time complexity, the key/value pair must be saved in a Hash table, with the key being the key of the data, the value being the key/value pair.

Besides, the visited history should be stored in a double linked list. 

```C#
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

public class Data
{
    public int Key { get; set; }
    public int Value { get; set; }
    public Data Prev { get; set; }
    public Data Next { get; set; }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
```

```JavaScript
class LRUCache {
    constructor(capacity) {
        this.cache = new Map();
        this.capacity = capacity;
        this.head = null;
        this.tail = null;
    }
    
    get(key) {
        if (this.cache.has(key)) {
            let data = this.cache.get(key);
            this.removeNode(data);
            this.appendNode(data);
            return data.value;
        } else {
            return -1;
        }
    }
    
    put(key, value) {
        if (this.cache.has(key)) {
            let data = this.cache.get(key);
            data.value = value;
            this.removeNode(data);
            this.appendNode(data);
        } else if (this.cache.size < this.capacity) {
            let data = new Node(key, value);
            this.cache.set(key, data);
            this.appendNode(data);
        } else {
            let data = this.head;
            let oldKey = data.key;
            data.key = key;
            data.value = value;
            this.cache.delete(oldKey);
            this.cache.set(key, data);
            this.removeNode(data);
            this.appendNode(data);
        }
    }
    
    removeNode(node) {
        if (!node) {
            return;
        }
        
        if (!!node.prev) {
            node.prev.next = node.next;
        }
        
        if (!!node.next) {
            node.next.prev = node.prev;
        }
        
        if (this.head === node) {
            this.head = node.next;
        }
        
        if (this.tail === node) {
            this.tail = node.prev;
        }
    }
    
    appendNode(node) {
        if (!node) {
            return;
        }
        
        node.prev = this.tail;
        node.next = null;
        
        if (!!this.tail) {
            this.tail.next = node;
        }
        this.tail = node;
        
        if (!this.head) {
            this.head = node;
        }
    }
}

class Node {
    constructor(key, value, prev = null, next = null) {
        this.key = key;
        this.value = value;
        this.prev = prev;
        this.next = next;
    }
}
```