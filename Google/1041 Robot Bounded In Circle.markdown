## 1041. Robot Bounded In Circle
https://leetcode.com/problems/robot-bounded-in-circle/

> On an infinite plane, a robot initially stands at (0, 0) and faces north. The robot can receive one of three instructions:
> * "G": go straight 1 unit;
> * "L": turn 90 degrees to the left;
> * "R": turn 90 degrees to the right.
> The robot performs the instructions given in order, and repeats them forever.
> Return true if and only if there exists a circle in the plane such that the robot never leaves the circle.
>
> Example 1:
>  Input: instructions = "GGLLGG"
>  Output: true
>  Explanation: The robot moves from (0,0) to (0,2), turns 180 degrees, and then returns to (0,0).
When repeating these instructions, the robot remains in the circle of radius 2 centered at the origin.
>
> Example 2:
>  Input: instructions = "GG"
>  Output: false
>  Explanation: The robot moves north indefinitely.
>
> Example 3:
>  Input: instructions = "GL"
>  Output: true
>  Explanation: The robot moves from (0, 0) -> (0, 1) -> (-1, 1) -> (-1, 0) -> (0, 0) -> ...
>
> Constraints:
> * 1 <= instructions.length <= 100
> * instructions[i] is 'G', 'L' or, 'R'.

**Solution:**

This is a very tricky problem. 

The first thought coming to mind is after 1 sequence or several sequence of instructions, if the robot goes back to the beginning point (0, 0), then there must be a circle. But how many of repeat can the robot go back to the beginning? You can't run a while loop infinitely.

I could think of 2 sets of instructions, one of which it will never going back. The other it will go back to the beginning.

1. "GLGR": It goes far and far away.
2. "GLGLGLGG": It goes back after 4 repeats.

Since I don't really have a solution for the problem, I read this explanation:
[https://leetcode.com/problems/robot-bounded-in-circle/discuss/290856/JavaC++Python-Let-Chopper-Help-Explain](https://leetcode.com/problems/robot-bounded-in-circle/discuss/290856/JavaC++Python-Let-Chopper-Help-Explain)

And I watched a video explaining about it [https://www.youtube.com/watch?v=-7UvHgT7u30](https://www.youtube.com/watch?v=-7UvHgT7u30). In the video, two essential factors are explained.

1. change in position
2. change in direction

If there is no change in position, the result is true. If there is change in position, but the facing direction is not North after 1 cycle, the result is true as well.

```C#
/**
 * Note: You can use modulus to calculate direction, but it is very slow.
 * else if (command == 'L')
 * {
 *     direction = (direction + 3) % 4;
 * }
 * else if (command == 'R')
 * {
 *     direction = (direction + 1) % 4;
 * }
 */
public class Solution {
    public enum Direction
    {
        North = 0,
        East,
        South,
        West,
    }

    private int[][] directions = new int[4][]
    {
        new int[2] { 0, 1 },
        new int[2] { 1, 0 },
        new int[2] { 0, -1 },
        new int[2] { -1, 0 },
    };
    
    public bool IsRobotBounded(string instructions)
    {
        // north = 0, east = 1, south = 2, west = 3
        var posX = 0;
        var posY = 0;
        var direction = Direction.North; // facing north

        foreach (var command in instructions)
        {
            if (command == 'G')
            {
                var move = directions[(int)direction];
                posX += move[0];
                posY += move[1];
            }
            else if (command == 'L')
            {
                switch (direction)
                {
                    case Direction.North:
                        direction = Direction.West;
                        break;
                    case Direction.East:
                        direction = Direction.North;
                        break;
                    case Direction.South:
                        direction = Direction.East;
                        break;
                    default:
                        direction = Direction.South;
                        break;
                }
            }
            else if (command == 'R')
            {
                switch (direction)
                {
                    case Direction.North:
                        direction = Direction.East;
                        break;
                    case Direction.East:
                        direction = Direction.South;
                        break;
                    case Direction.South:
                        direction = Direction.West;
                        break;
                    default:
                        direction = Direction.North;
                        break;
                }
            }
        }

        return (posX == 0 && posY == 0) || direction != Direction.North;
    }
}
```

```Javascript
/**
 * @param {string} instructions
 * @return {boolean}
 */
var isRobotBounded = function(instructions) {
    // north: 0, east: 1, south: 2, west: 3
    let directions = [
        {x: 0, y: 1},
        {x: 1, y: 0},
        {x: 0, y: -1},
        {x: -1, y: 0}
    ];
    
    let [x, y] = [0, 0];
    let direction = 0;
    for (var command of instructions) {
        if (command === 'G') {
            x += directions[direction].x;
            y += directions[direction].y;
        } else if (command === 'L') {
            direction = (direction + 3) % 4;
        } else if (command === 'R') {
            direction = (direction + 1) % 4;
        }
    }
    
    return (x === 0 && y === 0) || direction !== 0;
};
```