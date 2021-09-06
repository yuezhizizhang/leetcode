## 380. Insert Delete GetRandom O(1)
https://leetcode.com/problems/insert-delete-getrandom-o1/

> Implement the RandomizedSet class:
> * RandomizedSet() Initializes the RandomizedSet object.
> * bool insert(int val) Inserts an item val into the set if not present. Returns true if the item was not present, false otherwise.
> * bool remove(int val) Removes an item val from the set if present. Returns true if the item was present, false otherwise.
> * int getRandom() Returns a random element from the current set of elements (it's guaranteed that at least one element exists when this method is called). Each element must have the same probability of being returned.
> You must implement the functions of the class such that each function works in average O(1) time complexity.
>
> Example 1:
> Input
>   ["RandomizedSet", "insert", "remove", "insert", "getRandom", "remove", "insert", "getRandom"]
>   [[], [1], [2], [2], [], [1], [2], []]
> Output
>   [null, true, false, true, 2, true, false, 2]
>
> Explanation
>   RandomizedSet randomizedSet = new RandomizedSet();
>   randomizedSet.insert(1); // Inserts 1 to the set. Returns true as 1 was inserted successfully.
>   randomizedSet.remove(2); // Returns false as 2 does not exist in the set.
>   randomizedSet.insert(2); // Inserts 2 to the set, returns true. Set now contains [1,2].
>   randomizedSet.getRandom(); // getRandom() should return either 1 or 2 randomly.
>   randomizedSet.remove(1); // Removes 1 from the set, returns true. Set now contains [2].
>   randomizedSet.insert(2); // 2 was already in the set, so return false.
>   randomizedSet.getRandom(); // Since 2 is the only number in the set, getRandom() will always return 2.
>
> Constraints:
> * -231 <= val <= 231 - 1
> * At most 2 * 105 calls will be made to insert, remove, and getRandom.
> * There will be at least one element in the data structure when getRandom is called.

** Solution **

```C#
public class RandomizedSet {

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
```

```JavaScript
/**
 * Initialize your data structure here.
 */
var RandomizedSet = function() {
    this.set = [];
    this.map = new Map();
};

/**
 * Inserts a value to the set. Returns true if the set did not already contain the specified element. 
 * @param {number} val
 * @return {boolean}
 */
RandomizedSet.prototype.insert = function(val) {
    if (this.map.has(val)) {
    	return false;
    }

    this.set.push(val);
    this.map.set(val, this.set.length - 1);
    return true;
};

/**
 * Removes a value from the set. Returns true if the set contained the specified element. 
 * @param {number} val
 * @return {boolean}
 */
RandomizedSet.prototype.remove = function(val) {
    if (this.set.length < 1 || !this.map.has(val)) {
    	return false;
    }

    let index = this.map.get(val);
    this.map.delete(val);
    let last = this.set.length - 1;
    let num = this.set.pop();
    if (index != last) {
    	this.set[index] = num;
    	this.map.set(num, index);
    }
    return true;
};

/**
 * Get a random element from the set.
 * @return {number}
 */
RandomizedSet.prototype.getRandom = function() {
	if (this.set.length < 1) {
		return 0;
	}

    let rand = Math.floor(Math.random() * this.set.length);
    return this.set[rand];
};
```