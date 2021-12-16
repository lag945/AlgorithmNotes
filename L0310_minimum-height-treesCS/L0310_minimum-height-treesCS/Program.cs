using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0310_minimum_height_treesCS
{
    class Program
    {
        //https://leetcode.com/problems/minimum-height-trees
        //https://zh.wikipedia.org/wiki/%E6%8B%93%E6%92%B2%E6%8E%92%E5%BA%8F
        //https://alrightchiu.github.io/SecondRound/graph-li-yong-dfsxun-zhao-dagde-topological-sorttuo-pu-pai-xu.html
        static void Main(string[] args)
        {
            Solution s = new Solution();
            /*
            int[] a = new int[] { 1, 0 };
            int[] b = new int[] { 1, 2 };
            int[] c = new int[] { 1, 3  };
            int[][] edges = new int[][] { a, b, c };
            IList<int> ret = s.FindMinHeightTrees(4, edges);
            */

            int[] a = new int[] { 3, 0 };
            int[] b = new int[] { 3, 1 };
            int[] c = new int[] { 3, 2 };
            int[] d = new int[] { 3, 4 };
            int[] e = new int[] { 5, 4 };
            int[][] edges = new int[][] { a, b, c ,d, e};
            IList<int> ret = s.FindMinHeightTrees(6, edges);
        }
    }

    public class Solution
    {

        Dictionary<int, List<int>> links = new Dictionary<int, List<int>>();
        int min = 0;

        public List<int> FindMinHeightTrees(int n, int[][] edges)
        {

            // base cases
            if (n < 2)
            {
                List<int> centroids = new List<int>();
                for (int i = 0; i < n; i++)
                    centroids.Add(i);
                return centroids;
            }

            // Build the graph with the adjacency list
            List<HashSet<int>> neighbors = new List<HashSet<int>>();
            for (int i = 0; i < n; i++)
                neighbors.Add(new HashSet<int>());

            foreach (int[] edge in edges)
            {
                int start = edge[0], end = edge[1];
                neighbors[start].Add(end);
                neighbors[end].Add(start);
            }

            // Initialize the first layer of leaves
            List<int> leaves = new List<int>();
            for (int i = 0; i < n; i++)
                if (neighbors[i].Count == 1)
                    leaves.Add(i);

            // Trim the leaves until reaching the centroids
            int remainingNodes = n;
            while (remainingNodes > 2)
            {
                remainingNodes -= leaves.Count;
                List<int> newLeaves = new List<int>();

                // remove the current leaves along with the edges
                foreach (int leaf in leaves)
                {
                    // the only neighbor left for the leaf node

                    //neighbor = neighbors[leaf].iterator().next();
                    int neighbor = 0;
                    foreach (int next in neighbors[leaf])
                        neighbor = next;
                    // remove the edge along with the leaf node
                    neighbors[neighbor].Remove(leaf);
                    if (neighbors[neighbor].Count == 1)
                        newLeaves.Add(neighbor);
                }

                // prepare for the next round
                leaves = newLeaves;
            }

            // The remaining nodes are the centroids of the graph
            return leaves;
        }

        //Time Limit Exceeded 65/68
        public IList<int> FindMinHeightTrees2(int n, int[][] edges)
        {
            List<int> ret = new List<int>();

            if (n == 1)
            {
                ret.Add(0);
                return ret;
            }
            else if (n == 1)
            {
                ret.Add(0);
                ret.Add(1);
                return ret;
            }

            // establish links.        
            for (int i = 0; i < edges.Length; i++)
            {
                int from = edges[i][0];
                int to = edges[i][1];

                if (!links.ContainsKey(from))
                {
                    links[from] = new List<int>();
                }
                links[from].Add(to);

                if (!links.ContainsKey(to))
                {
                    links[to] = new List<int>();
                }
                links[to].Add(from);
            }

            HashSet<int> visit = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                visit.Add(i);
                int h = DFS(n, i, visit, 0);
                if (min == 0 || h == min)
                {
                    min = h;
                    ret.Add(i);
                }
                else if (h < min)
                {
                    min = h;
                    ret.Clear();
                    ret.Add(i);
                }
                visit.Remove(i);
            }

            return ret;
        }

        private int DFS(int n, int current, HashSet<int> visit, int h)
        {
            int ret = h;
            List<int> link = links[current];
            foreach (int l in link)
            { 
                if (visit.Contains(l))
                    continue;

                visit.Add(l);
                ret = Math.Max(ret, DFS(n, l, visit, h + 1));
                visit.Remove(l);
            }
            return ret;
        }
    }
}
