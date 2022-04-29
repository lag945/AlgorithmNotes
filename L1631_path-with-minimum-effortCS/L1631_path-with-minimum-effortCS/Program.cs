using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1631_path_with_minimum_effortCS
{
    class Program
    {

        //https://leetcode.com/problems/path-with-minimum-effort/
        
        static void Main(string[] args)
        {
            Solution s = new Solution();
            //Input: heights = [[1, 2, 2],[3,8,2],[5,3,5]]
            //int[][] heights = new int[3][];
            //heights[0] = new int[] { 1, 2, 2 };
            //heights[1] = new int[] { 3, 8, 2 };
            //heights[2] = new int[] { 5, 3, 5 };
            //bool r = s.MinimumEffortPath(heights) == 2;

            //[[1,10,6,7,9,10,4,9]]
            //int[][] heights = new int[1][];
            //heights[0] = new int[] { 1, 10, 6, 7, 9, 10, 4, 9 };
            //bool r = s.MinimumEffortPath(heights) == 9;

            //[[1,2,1,1,1],[1,2,1,2,1],[1,2,1,2,1],[1,2,1,2,1],[1,1,1,2,1]]
            //int[][] heights = new int[5][];
            //heights[0] = new int[] { 1, 2, 1, 1, 1 };
            //heights[1] = new int[] { 1, 2, 1, 2, 1 };
            //heights[2] = new int[] { 1, 2, 1, 2, 1 };
            //heights[3] = new int[] { 1, 2, 1, 2, 1 };
            //heights[4] = new int[] { 1, 1, 1, 2, 1 };
            //bool r = s.MinimumEffortPath(heights) == 0;

            //[[8,6,8,1,4,1],[10,3,1,8,9,10],[1,5,6,9,8,5],[10,4,6,7,3,3],[6,6,9,1,3,3],[3,1,10,3,4,1],[6,1,6,10,7,10]]

            int[][] heights = new int[7][];
            heights[0] = new int[] { 8, 6, 8, 1, 4, 1 };
            heights[1] = new int[] { 10, 3, 1, 8, 9, 10 };
            heights[2] = new int[] { 1, 5, 6, 9, 8, 5 };
            heights[3] = new int[] { 10, 4, 6, 7, 3, 3 };
            heights[4] = new int[] { 6, 6, 9, 1, 3, 3 };
            heights[5] = new int[] { 3, 1, 10, 3, 4, 1 };
            heights[6] = new int[] { 6, 1, 6, 10, 7, 10 };
            bool r = s.MinimumEffortPath(heights) == 3;
        }

        public class Solution
        {
            struct Edge
            {
                public int from;
                public int to;
                public int weight;
                public Edge(int a, int b, int c)
                {
                    from = a;
                    to = b;
                    weight = c;
                }
            }

            int[] DIR = new int[] { 0, 1, 0, -1, 0 };
            //dijkstra
            public int MinimumEffortPath(int[][] heights)
            {
                int ret = 0;
                List<List<Edge>> edges = new List<List<Edge>>();
                int m = heights.Length;
                int n = heights[0].Length;

                for (int i = 0; i < heights.Length; i++)
                {
                    for (int j = 0; j < heights[i].Length; j++)
                    {
                        List<Edge> eds = new List<Edge>();
                        for (int k = 0; k < DIR.Length - 1; k++)
                        {
                            int i2 = i + DIR[k];
                            int j2 = j + DIR[k + 1];
                            //make inside edge
                            if (i2 >= 0 && i2 < heights.Length && j2 >= 0 && j2 < heights[i].Length)
                            {
                                Edge edge = new Edge(i * n + j, i2 * n + j2, Math.Abs(heights[i][j] - heights[i2][j2]));
                                eds.Add(edge);
                            }
                        }
                        edges.Add(eds);
                    }
                }
                //https://zh.wikipedia.org/wiki/%E6%88%B4%E5%85%8B%E6%96%AF%E7%89%B9%E6%8B%89%E7%AE%97%E6%B3%95
                int[] dist = new int[m * n];
                bool[] visited = new bool[m * n];
                for (int i = 0; i < m * n; i++)
                {
                    dist[i] = Int32.MaxValue;
                    visited[i] = false;
                }

                int src = 0;
                int target = m * n - 1;
                SortedSet<Tuple<int, int>> pq = new SortedSet<Tuple<int, int>>();
                Solution s = new Solution();
                dist[src] = 0;
                pq.Add(Tuple.Create(dist[src], src));

                while (pq.Count > 0)
                {
                    //Console.WriteLine(pq.Count.ToString());
                    // 每次从优先队列中取出顶点事实上是这一轮最短路径权值确定的点
                    int u = pq.Min.Item2;
                    pq.Remove(pq.Min);
                    if (visited[u])
                    {
                        continue;
                    }
                    visited[u] = true;
                    // 遍历所有边
                    foreach (Edge edge in edges[u])
                    {
                        // 得到顶点边号以及边权
                        int v = edge.to;
                        int weight = Math.Max(dist[u], edge.weight);

                        if (weight < dist[v])
                        {
                            dist[v] = weight;
                            pq.Add(Tuple.Create(dist[v], v));
                        }
                    }
                }


                ret = dist[m * n - 1];
                return ret;
            }

        }

        public class Solution2
        {
            private int[] dirs = new int[] { 0, 1, 0, -1, 0 };

            public int MinimumEffortPath(int[][] heights)
            {
                int r = heights.Length;
                int c = heights[0].Length;
                bool[] visited = new bool[r * c];
                var pq = new SortedSet<Tuple<int, int, int>>();
                pq.Add(Tuple.Create(0, 0, 0));
                while (pq.Count > 0)
                {
                    var cur = pq.Min;
                    if (cur.Item2 == r - 1 && cur.Item3 == c - 1)
                        return cur.Item1;
                    visited[cur.Item2 * c + cur.Item3] = true;
                    pq.Remove(cur);
                    for (int d = 0; d < 4; d++)
                    {
                        int nx = cur.Item2 + dirs[d];
                        int ny = cur.Item3 + dirs[d + 1];
                        if (nx < 0 || nx == r || ny < 0 || ny == c || visited[nx * c + ny])
                            continue;
                        int nh = Math.Max(cur.Item1, Math.Abs(heights[cur.Item2][cur.Item3] - heights[nx][ny]));
                        pq.Add(Tuple.Create(nh, nx, ny));
                    }
                }

                return 0;
            }
        }
    }

}