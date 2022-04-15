using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0684_redundant_connectionCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            //int[][] edges = new int[3][];
            //edges[0] = new int[] { 1, 2 };
            //edges[1] = new int[] { 1, 3 };
            //edges[2] = new int[] { 2, 3 };
            //int[] r = s.FindRedundantConnection(edges);
            //bool ret = r[0] == 2 && r[1] == 3;
            int[][] edges = new int[10][];
            edges[0] = new int[] { 3, 7 };
            edges[1] = new int[] { 1, 4 };
            edges[2] = new int[] { 2, 8 };
            edges[3] = new int[] { 1, 6 };
            edges[4] = new int[] { 7, 9 };
            edges[5] = new int[] { 6, 10 };
            edges[6] = new int[] { 1, 7 };
            edges[7] = new int[] { 2, 3 };
            edges[8] = new int[] { 8, 9 };
            edges[9] = new int[] { 5, 9 };
            int[] r = s.FindRedundantConnection(edges);
            bool ret = r[0] == 8 && r[1] == 9;
        }

        public class Solution
        {
            static int MAX_EDGE_VAL = 1000;
            class DSU
            {
                int[] parent;
                int[] rank;

                public DSU(int size)
                {
                    parent = new int[size];
                    for (int i = 0; i < size; i++) parent[i] = i;
                    rank = new int[size];
                }

                public int find(int x)
                {
                    if (parent[x] != x) parent[x] = find(parent[x]);
                    return parent[x];
                }

                public bool union(int x, int y)
                {
                    int xr = find(x), yr = find(y);
                    if (xr == yr)
                    {
                        return false;
                    }
                    else if (rank[xr] < rank[yr])
                    {
                        parent[xr] = yr;
                    }
                    else if (rank[xr] > rank[yr])
                    {
                        parent[yr] = xr;
                    }
                    else
                    {
                        parent[yr] = xr;
                        rank[xr]++;
                    }
                    return true;
                }
            }

            //T:O(n)
            public int[] FindRedundantConnection(int[][] edges)
            {
                DSU dsu = new DSU(MAX_EDGE_VAL + 1);
                int[] ret = new int[2];
                int n = edges.Length;
                foreach (int[] edge in edges)
                {
                    if (!dsu.union(edge[0], edge[1])) return edge;
                }

                return ret;
            }
            //T:O(n^2)
            public int[] FindRedundantConnection3(int[][] edges)
            {
                int[] ret = new int[2];
                int n = edges.Length;
                Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
                HashSet<int> seen = new HashSet<int>();
                foreach (int[] edge in edges)
                {
                    int a = edge[0];
                    int b = edge[1];

                    if (!map.ContainsKey(a))
                        map[a] = new List<int>();
                    if (!map.ContainsKey(b))
                        map[b] = new List<int>();


                    seen.Add(a);
                    bool find = Dfs(a, b, map, seen);
                    seen.Remove(a);
                    seen.Clear();
                    if (find)
                    {
                        ret[0] = a;
                        ret[1] = b;
                    }
                    else
                    {
                        map[a].Add(b);
                        map[b].Add(a);
                    }
                }

                return ret;
            }

            private bool Dfs(int a, int b, Dictionary<int, List<int>> map, HashSet<int> seen)
            {
                for (int i = 0; i < map[a].Count; i++)
                {
                    int t = map[a][i];
                    if (t == b)
                        return true;
                    else 
                    {
                        if (seen.Add(t))
                        {
                            bool find = Dfs(t, b, map, seen);
                            seen.Remove(t);
                            if (find)
                                return true;
                        }
                    }
                }

                return false;
            }

            //T:O(n*n!)
            public int[] FindRedundantConnection2(int[][] edges)
            {
                int [] ret = new int[2];
                int n = edges.Length;
                Dictionary<int, HashSet<int>> map = new Dictionary<int, HashSet<int>>();

                foreach (int[] edge in edges)
                {
                    int a = edge[0];
                    int b = edge[1];

                    if (!map.ContainsKey(a))
                        map[a] = new HashSet<int>();
                    if (!map.ContainsKey(b))
                        map[b] = new HashSet<int>();

                    if (map[a].Contains(b))
                    {
                        ret[0] = a;
                        ret[1] = b;
                    }

                    //link a & b
                    map[a].Add(b);
                    map[b].Add(a);
                    //link a & b set
                    foreach (int bl in map[b].ToArray())
                    {
                        map[a].Add(bl);
                    }

                    //link b & a set
                    foreach (int al in map[a].ToArray())
                    {
                        map[b].Add(al);
                    }
                    //link a set & bset
                    foreach (int al in map[a].ToArray())
                    {
                        foreach (int bl in map[b].ToArray())
                        {
                            map[al].Add(bl);
                            map[bl].Add(al);
                        }
                    }
                }

                return ret;
            }

            private void SetMatrix(int i, int j, bool[,] matrix)
            {
                Console.WriteLine("(" + i.ToString() + "," + j.ToString() + ")");
                matrix[i, j] = true;
            }

            private void ShowMatrix(bool[,] matrix)
            {
                int n = (int)Math.Sqrt(matrix.Length);
                for (int i = 0; i < n;i++)
                {
                    for (int j = 0; j < n;j++)
                    {
                        Console.Write(matrix[i, j] ? "T " : "F ");
                    }
                    Console.WriteLine("");
                }
            }

        }
    }
}
