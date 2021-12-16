using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0207_course_scheduleCS
{
    class Program
    {
        //https://leetcode.com/problems/course-schedule/
        static void Main(string[] args)
        {
            Solution s = new Solution();
            //bool r = s.CanFinish(2, new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 } });
            //bool r = s.CanFinish(2, new int[][] { new int[] { 1, 0 } });
            //bool r = s.CanFinish(20, new int[][] { new int[] { 0, 10 }, new int[] { 3, 18 }, new int[] { 5, 5 } });

            bool r = s.CanFinish(4, new int[][] { new int[] { 1, 0 }, new int[] { 2, 0 }, new int[] { 0, 3 }, new int[] { 2, 3 } });
        }
        //https://leetcode.com/problems/course-schedule/discuss/250882/C-graph-cycle-detection-summary-DFSTopological-SortUnion-Find
        public class Solution
        {
            //Topological Sort
            public bool CanFinish(int numCourses, int[][] prerequisites)
            {
                var n = numCourses;
                var inDegree = new int[n];
                var matrix = new int[n, n];

                for (int i = 0; i < prerequisites.GetLength(0); i++)
                {
                    var r = prerequisites[i][1];
                    var c = prerequisites[i][0];

                    if (matrix[r, c] == 0)
                    {
                        matrix[r, c] = 1;
                        inDegree[c]++;
                    }
                }

                var q = new Queue<int>();
                for (int i = 0; i < n; i++)
                {
                    if (inDegree[i] == 0) q.Enqueue(i);
                }
                var count = 0;
                while (q.Count != 0)
                {
                    var temp = q.Dequeue();
                    count++;

                    for (int i = 0; i < n; i++)
                    {
                        if (matrix[temp, i] == 1)
                        {
                            if (--inDegree[i] == 0)
                                q.Enqueue(i);
                        }
                    }
                }

                return count == n;
            }
            Dictionary<int, List<int>> edges = new Dictionary<int, List<int>>();
            //DFS
            public bool CanFinish2(int numCourses, int[][] prerequisites)
            {
                bool ret = false;
                foreach (int[] edge in prerequisites)
                {
                    int from = edge[0];
                    int to = edge[1];

                    if (from == to)
                        return ret;

                    if (!edges.ContainsKey(from))
                    {
                        edges[from] = new List<int>();
                    }
                    edges[from].Add(to);
                }

                HashSet<int> hash = new HashSet<int>();

                for (int i = 0; i < numCourses; i++)
                {
                    if (edges.ContainsKey(i))
                        continue;
                    hash.Add(i);

                    if (Visit(i, hash, numCourses))
                        return true;

                    hash.Remove(i);
                }

                return ret;
            }

            public bool Visit(int current, HashSet<int> hash, int numCourses)
            {
                //check prerequisites
                if (edges.ContainsKey(current))
                {
                    for (int i = 0; i < edges[current].Count; i++)
                    {
                        if (!hash.Contains(edges[current][i]))
                            return false;
                    }
                }

                if (hash.Count == numCourses)
                    return true;

                for (int i = 0; i < numCourses; i++)
                {
                    if (hash.Contains(i))
                        continue;
                    hash.Add(i);

                    if (Visit(i, hash, numCourses))
                        return true;

                    hash.Remove(i);
                }

                return false;
            }
        }
    }
}
