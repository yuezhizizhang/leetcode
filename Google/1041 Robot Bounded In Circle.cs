using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program
    {
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

        static void Main(string[] args)
        {
            var instructions = "RLLGGLRGLGLLLGRLRLRLRRRRLRLGRLLLGGL";
            var result = IsRobotBounded(instructions);
        }

        public static bool IsRobotBounded(string instructions)
        {
            var posX = 0;
            var posY = 0;
            var direction = Direction.North;

            foreach (var command in instructions)
            {
                if (command == 'G')
                {
                    switch (direction)
                    {
                        case Direction.North:
                            posY += 1;
                            break;
                        case Direction.East:
                            posX += 1;
                            break;
                        case Direction.South:
                            posY -= 1;
                            break;
                        default:
                            posX -= 1;
                            break;
                    }
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

        public bool IsRobotBoundedMethod2(string instructions)
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
}
