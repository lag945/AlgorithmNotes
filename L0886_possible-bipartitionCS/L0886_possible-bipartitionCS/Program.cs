using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0886_possible_bipartitionCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            bool r = s.PossibleBipartition(4, new int[][] { new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 2, 4 } }) == true;
            //bool r = s.PossibleBipartition(3, new int[][] { new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 2, 3 } }) == false;
            //bool r = s.PossibleBipartition(5, new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 4 }, new int[] { 4, 5 }, new int[] { 1, 5 } }) == false;
            //bool r = s.PossibleBipartition(10, new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { 5, 6 }, new int[] { 6, 7 }, new int[] { 8, 9 }, new int[] { 7, 8 } }) == true;
            //bool r = s.PossibleBipartition(1, new int[][] { }) == true;
        }

        public class Solution
        {
            public bool dfs(int node, int nodeColor, Dictionary<int, List<int>> adj, int[] color)
            {
                color[node] = nodeColor;
                if (!adj.ContainsKey(node))
                    return true;
                foreach (int neighbor in adj[node])
                {
                    if (color[neighbor] == color[node])
                        return false;
                    if (color[neighbor] == -1)
                    {
                        if (!dfs(neighbor, 1 - nodeColor, adj, color))
                            return false;
                    }
                }
                return true;
            }

            public bool PossibleBipartition(int n, int[][] dislikes)
            {
                var adj = new Dictionary<int, List<int>>();
                foreach (int[] edge in dislikes)
                {
                    int a = edge[0], b = edge[1];
                    if (!adj.ContainsKey(a))
                        adj[a] = new List<int>();
                    adj[a].Add(b);
                    if (!adj.ContainsKey(b))
                        adj[b] = new List<int>();
                    adj[b].Add(a);
                }

                // 0 stands for red and 1 stands for blue.
                int[] color = new int[n + 1];
                for (int i = 0; i < color.Length; i++)
                    color[i] = -1;

                for (int i = 1; i <= n; i++)
                {
                    if (color[i] == -1)
                    {
                        // For each pending component, run DFS.
                        if (!dfs(i, 0, adj, color))
                            // Return false, if there is conflict in the component.
                            return false;
                    }
                }
                return true;
            }

            //邏輯有錯
            public bool PossibleBipartition_WrongAnswer(int n, int[][] dislikes)
            {
                List<HashSet<int>> groups = new List<HashSet<int>>();
                Dictionary<int, HashSet<int>> hateSet = new Dictionary<int, HashSet<int>>();

                foreach (var d in dislikes)
                {
                    if (!hateSet.ContainsKey(d[0]))
                        hateSet[d[0]] = new HashSet<int>();

                    if (!hateSet.ContainsKey(d[1]))
                        hateSet[d[1]] = new HashSet<int>();

                    hateSet[d[0]].Add(d[1]);
                    hateSet[d[1]].Add(d[0]);
                }

                for (int i = 1; i <= n; i++)
                {
                    bool done = false;
                    foreach (var g in groups)
                    {
                        bool ok = true;
                        if (hateSet.ContainsKey(i))
                        {
                            foreach (var id in g.ToArray())
                            {
                                if (hateSet[i].Contains(id))
                                {
                                    ok = false;
                                    break;
                                }
                            }
                        }

                        if (ok)
                        {
                            g.Add(i);
                            done = true;
                            break;
                        }
                    }

                    if (!done)
                    {
                        var g = new HashSet<int>();
                        g.Add(i);
                        groups.Add(g);
                        if (groups.Count > 2)
                            return false;
                    }
                }

                return groups.Count <= 2;
            }
        }

    }
}
