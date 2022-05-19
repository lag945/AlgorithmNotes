using System.Collections.Generic;

namespace L0785_is_graph_bipartiteCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            //[[1,2,3],[0,2],[0,1,3],[0,2]]
            int[][] graph1 = new int[4][];
            graph1[0] = new int[] { 1, 2, 3 };
            graph1[1] = new int[] { 0, 2 };
            graph1[2] = new int[] { 0, 1, 3 };
            graph1[3] = new int[] { 0, 2 };
            bool r1 = s.IsBipartite(graph1) == false;
            // [[1,3],[0,2],[1,3],[0,2]]
            int[][] graph2 = new int[4][];
            graph2[0] = new int[] { 1, 3 };
            graph2[1] = new int[] { 0, 2 };
            graph2[2] = new int[] { 1, 3 };
            graph2[3] = new int[] { 0, 2 };
            bool r2 = s.IsBipartite(graph2) == true;

            int[][] graph3 = new int[2][];
            graph3[0] = new int[] { 1 };
            graph3[1] = new int[] { 0 };
            bool r3 = s.IsBipartite(graph3) == true;

            //[[1],[0,3],[3],[1,2]]
            int[][] graph4 = new int[4][];
            graph4[0] = new int[] { 1 };
            graph4[1] = new int[] { 0,3 };
            graph4[2] = new int[] {  3 };
            graph4[3] = new int[] { 1, 2 };
            bool r4 = s.IsBipartite(graph4) == true;


        }

        public class Solution
        {
            int[] vis = null;
            int[] col = null;
            public bool IsBipartite(int[][] graph)
            {
                int n = graph.Length;
                vis = new int[n];
                col = new int[n];

                for (int i = 0; i < n; ++i)
                {
                    if (vis[i] == 0 && DFS(i, 0, graph) == false)
                    {
                        return false;
                    }
                }

                return true;
            }

            bool DFS(int v, int c, int[][] graph)
            {
                vis[v] = 1;
                col[v] = c;
                foreach (int child in graph[v])
                {
                    if (vis[child] == 0)
                    {
                        // here c^1 is for flipping 1 by 0 or 0 by 1, that is flip the current color
                        if (DFS(child, c ^ 1, graph) == false)
                            return false;
                    }
                    else
                    {
                        if (col[v] == col[child])
                            return false;
                    }
                }
                return true;
            }

        }
    }
}
