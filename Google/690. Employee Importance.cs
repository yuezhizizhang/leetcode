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
            var solution = new Solution();
            solution.NumSmallerByFrequency(new string[] { "bba", "abaaaaaa", "aaaaaa", "bbabbabaab", "aba", "aa", "baab", "bbbbbb", "aab", "bbabbaabb" }, 
                new string[] { "aaabbb", "aab", "babbab", "babbbb", "b", "bbbbbbbbab", "a", "bbbbbbbbbb", "baaabbaab", "aa" });
        }
    }

    /*
    // Definition for Employee.
    class Employee {
        public int id;
        public int importance;
        public IList<int> subordinates;
    }
    */
    public class Solution
    {
        public int GetImportance(IList<Employee> employees, int id)
        {
            var employeesMap = new Dictionary<int, Employee>();

            foreach (var e in employees)
            {
                employeesMap.Add(e.id, e);
            }

            return dfs(id, employeesMap);
        }

        private int dfs(int id, IDictionary<int, Employee> map)
        {
            var e = map[id];
            var sum = e.importance;
            var subordinates = e.subordinates;
            foreach (var key in subordinates)
            {
                sum += dfs(key, map);
            }

            return sum;
        }

        public class Employee
        {
            public int id;
            public int importance;
            public IList<int> subordinates;
        }
    }
}
