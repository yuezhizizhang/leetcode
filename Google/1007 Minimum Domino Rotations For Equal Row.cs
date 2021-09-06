using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Solution
    {
        public int MinDominoRotations(int[] tops, int[] bottoms)
        {
            if (tops.Length != bottoms.Length)
            {
                throw new ArgumentException();
            }

            if (tops.Length < 2)
            {
                return 0;
            }

            var size = tops.Length;
            var rotations = CheckRotations(tops[0], tops, bottoms, size);
            if (rotations != -1  || tops[0] == bottoms[0])
            {
                return rotations;
            }
            return CheckRotations(bottoms[0], tops, bottoms, size);
        }

        public int CheckRotations(int target, int[] tops, int[] bottoms, int length)
        {
            var topRotations = 0;
            var bottomRotations = 0;
            for (var i = 0; i < length; i++)
            {
                var up = tops[i];
                var down = bottoms[i];

                if (up != target && down != target)
                {
                    return -1;
                }
                else if (up != target)
                {
                    topRotations += 1;
                }
                else if (down != target)
                {
                    bottomRotations += 1;
                }
            }

            return Math.Min(topRotations, bottomRotations);
        }
    }
}
