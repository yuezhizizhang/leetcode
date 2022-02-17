using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        private const int MaxStates = 4;
        private const int Mod = 1000000007;

        public int NumTilings(int n)
        {
            var dp = new int[n][];
            for (var i = 0; i < n; i++)
            {
                dp[i] = new int[MaxStates];
            }

            return Tile(0, n, dp, true, true);
        }

        private int Tile(int column, int n, int[][] dp, bool slot1, bool slot2)
        {
            if (column == n) return 1;

            var state = GetState(slot1, slot2);
            if (dp[column][state] != 0) return dp[column][state];

            var slot3 = column + 1 < n;
            var slot4 = slot3;
            
            var count = 0;
            if (slot1 && slot2) count = Modulo(count + Tile(column + 1, n, dp, true, true));
            if (slot1 && slot2 && slot3) count = Modulo(count + Tile(column + 1, n, dp, false, true));
            if (slot1 && slot2 && slot4) count = Modulo(count + Tile(column + 1, n, dp, true, false));
            if (slot1 && slot2 && slot3 && slot4) count = Modulo(count + Tile(column + 1, n, dp, false, false));
            if (slot1 && !slot2 && slot3) count = Modulo(count + Tile(column + 1, n, dp, false, true));
            if (slot1 && !slot2 && slot3 && slot4) count = Modulo(count + Tile(column + 1, n, dp, false, false));
            if (!slot1 && slot2 && slot4) count = Modulo(count + Tile(column + 1, n, dp, true, false));
            if (!slot1 && slot2 && slot3 && slot4) count = Modulo(count + Tile(column + 1, n, dp, false, false));
            if (!slot1 && !slot2) count = Modulo(count + Tile(column + 1, n, dp, true, true));

            dp[column][state] = count;
            return dp[column][state];
        }

        private int GetState(bool slot1, bool slot2)
        {
            var state = 0;
            if (!slot1) state |= 1;
            if (!slot2) state |= 2;

            return state;
        }

        private int Modulo(int number)
        {
            return number % Mod;
        }
    }
}
