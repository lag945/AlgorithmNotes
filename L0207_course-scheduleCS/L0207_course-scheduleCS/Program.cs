using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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
            //bool r = s.CanFinish(4, new int[][] { new int[] { 1, 0 }, new int[] { 2, 0 }, new int[] { 0, 3 }, new int[] { 2, 3 } });
            //bool r = s.CanFinish(4, new int[][] { new int[] { 1, 2 }, new int[] { 2, 0 }, new int[] { 2, 3 } });
            string testcase = "[[6, 27],[83, 9],[10, 95],[48, 67],[5, 71],[18, 72],[7, 10],[92, 4],[68, 84],[6, 41],[82, 41],[18, 54],[0, 2],[1, 2],[8, 65],[47, 85],[39, 51],[13, 78],[77, 50],[70, 56],[5, 61],[26, 56],[18, 19],[35, 49],[79, 53],[40, 22],[8, 19],[60, 56],[48, 50],[20, 70],[35, 12],[99, 85],[12, 75],[2, 36],[36, 22],[21, 15],[98, 1],[34, 94],[25, 41],[65, 17],[1, 56],[43, 96],[74, 57],[19, 62],[62, 78],[50, 86],[46, 22],[10, 13],[47, 18],[20, 66],[83, 66],[51, 47],[23, 66],[87, 42],[25, 81],[60, 81],[25, 93],[35, 89],[65, 92],[87, 39],[12, 43],[75, 73],[28, 96],[47, 55],[18, 11],[29, 58],[78, 61],[62, 75],[60, 77],[13, 46],[97, 92],[4, 64],[91, 47],[58, 66],[72, 74],[28, 17],[29, 98],[53, 66],[37, 5],[38, 12],[44, 98],[24, 31],[68, 23],[86, 52],[79, 49],[32, 25],[90, 18],[16, 57],[60, 74],[81, 73],[26, 10],[54, 26],[57, 58],[46, 47],[66, 54],[52, 25],[62, 91],[6, 72],[81, 72],[50, 35],[59, 87],[21, 3],[4, 92],[70, 12],[48, 4],[9, 23],[52, 55],[43, 59],[49, 26],[25, 90],[52, 0],[55, 8],[7, 23],[97, 41],[0, 40],[69, 47],[73, 68],[10, 6],[47, 9],[64, 24],[95, 93],[79, 66],[77, 21],[80, 69],[85, 5],[24, 48],[74, 31],[80, 76],[81, 27],[71, 94],[47, 82],[3, 24],[66, 61],[52, 13],[18, 38],[1, 35],[32, 78],[7, 58],[26, 58],[64, 47],[60, 6],[62, 5],[5, 22],[60, 54],[49, 40],[11, 56],[19, 85],[65, 58],[88, 44],[86, 58]]";
            testcase = testcase.Replace("[", "").Replace("]", "").Replace(" ", "");
            string[] str_testcase = testcase.Split(',');
            int[][] prerequisites = new int[str_testcase.Length / 2][];

            for (int i = 0; i < str_testcase.Length; i += 2)
            {
                prerequisites[i / 2] = new int[] { Convert.ToInt32(str_testcase[i]), Convert.ToInt32(str_testcase[i + 1]) };
            }
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            bool r = s.CanFinish(100, prerequisites);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalSeconds.ToString("0.000000"));
            sw.Restart();
            r = s.CanFinish3(100, prerequisites);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalSeconds.ToString("0.000000"));
        }
        //https://leetcode.com/problems/course-schedule/discuss/250882/C-graph-cycle-detection-summary-DFSTopological-SortUnion-Find
        public class Solution
        {
            //Topological Sort
            int CanFinishCnt = 0;
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

            //Topological Sort my edition
            int CanFinishCnt3 = 0;
            public bool CanFinish3(int numCourses, int[][] prerequisites)
            {
                List<HashSet<int>> limit = new List<HashSet<int>>(numCourses);
                for (int i = 0; i < numCourses; i++)
                    limit.Add(new HashSet<int>());

                for (int i = 0; i < prerequisites.Length; i++)
                {
                    int from = prerequisites[i][0];
                    int to = prerequisites[i][1];

                    if (from == to)
                        return false;

                    limit[from].Add(to);
                }

                List<int> candidates = new List<int>();
                //no prerequisite , at least need one from head
                for (int i = 0; i < numCourses; i++)
                {
                    if (limit[i].Count == 0)
                        candidates.Add(i);
                }

                int count = 0;
                while (candidates.Count > 0)
                {
                    int temp = candidates[candidates.Count - 1];
                    candidates.RemoveAt(candidates.Count - 1);
                    count++;

                    for (int i = 0; i < numCourses; i++)
                    {
                        if (limit[i].Count > 0 && limit[i].Contains(temp))
                        {
                            limit[i].Remove(temp);
                            if (limit[i].Count == 0)
                                candidates.Add(i);
                        }
                    }
                }

                return count== numCourses;

            }
        }
    }
}
