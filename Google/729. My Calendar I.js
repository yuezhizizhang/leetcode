
var MyCalendar = function() {
	this.bookings = null;
};

/** 
 * @param {number} start 
 * @param {number} end
 * @return {boolean}
 */
MyCalendar.prototype.book = function(start, end) {
	if (!this.bookings) {
		this.bookings = new TreeNode(start, end);
		return true;
	}

	return insert(this.bookings, start, end);
};

var insert = function(node, start, end) {
	if (end <= node.start) {
		if (!node.left) {
			node.left = new TreeNode(start, end);
			return true;
		} else return insert(node.left, start, end);
	} else if (start >= node.end) {
		if (!node.right) {
			node.right = new TreeNode(start, end);
			return true;
		} else return insert(node.right, start, end);
	} else return false;
}

class TreeNode {
	constructor(start, end) {
		this.start = start;
		this.end = end;
		this.left = null;
		this.right = null;
	}
};

/** 
 * Your MyCalendar object will be instantiated and called as such:
 * var obj = new MyCalendar()
 * var param_1 = obj.book(start,end)
 */

 const calendar = new MyCalendar();
 calendar.book(47, 50);
 calendar.book(33, 41);
 calendar.book(39, 45);