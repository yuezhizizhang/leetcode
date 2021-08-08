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

var lruCache = new LRUCache(2);
lruCache.put(1, 1);
lruCache.put(2, 2);
lruCache.get(1);
lruCache.put(3, 3);
lruCache.get(2);
lruCache.put(4, 4);
lruCache.get(1);
lruCache.get(3);
lruCache.get(4);

