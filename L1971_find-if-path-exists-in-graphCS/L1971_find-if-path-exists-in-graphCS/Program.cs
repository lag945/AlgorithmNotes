using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1971_find_if_path_exists_in_graphCS
{
    class Program
    {
        //https://leetcode.com/problems/find-if-path-exists-in-graph/solutions/2715942/find-if-path-exists-in-graph/
        //https://leetcode.com/explore/learn/card/graph/618/disjoint-set/3881/
        //https://leetcode.com/explore/learn/card/graph/618/disjoint-set/3879/
        static void Main(string[] args)
        {
            Solution s = new Solution();
            bool r1 = true == s.ValidPath(3, new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 2, 0 } }, 0, 2);
            bool r2 = false == s.ValidPath(6, new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 3, 5 }, new int[] { 5, 4 }, new int[] { 4, 3 } }, 0, 5);
        }

        public class Solution
        {
            public bool ValidPath(int n, int[][] edges, int source, int destination)
            {

                UnionFind2 uf = new UnionFind2(n);

                foreach (int[] edge in edges)
                {
                    uf.union(edge[0], edge[1]);
                }

                return uf.connected(source, destination);

            }

            class UnionFind
            {
                private int[] root;
                private int[] rank;

                public UnionFind(int n)
                {
                    this.root = new int[n];
                    this.rank = new int[n];
                    for (int i = 0; i < n; ++i)
                    {
                        this.root[i] = i;
                    }
                }

                public int find(int x)
                {
                    if (this.root[x] != x)
                    {
                        this.root[x] = find(this.root[x]);
                    }
                    return this.root[x];
                }
                public void union(int x, int y)
                {
                    int rootX = find(x);
                    int rootY = find(y);
                    if (rootX != rootY)
                    {
                        if (this.rank[rootX] > this.rank[rootY])
                        {
                            int tmp = rootX;
                            rootX = rootY;
                            rootY = tmp;
                        }
                        // Modify the root of the smaller group as the root of the
                        // larger group, also increment the size of the larger group.
                        this.root[rootX] = rootY;
                        this.rank[rootY] += this.rank[rootX];
                    }
                }
                public bool connected(int x, int y)
                {
                    return find(x) == find(y);
                }
            }

            class UnionFind2
            {
                private int[] root;
                private int[] rank;

                public UnionFind2(int n)
                {
                    this.root = new int[n];
                    this.rank = new int[n];
                    for (int i = 0; i < n; ++i)
                    {
                        this.root[i] = i;
                        this.rank[i] = i;
                    }
                }

                public int find(int x)
                {
                    while (x != root[x])
                    {
                        x = root[x];
                    }
                    return x;
                }
                public void union(int x, int y)
                {
                    int rootX = find(x);
                    int rootY = find(y);
                    if (rootX != rootY)
                    {
                        if (rank[rootX] > rank[rootY])
                        {
                            root[rootY] = rootX;
                        }
                        else if (rank[rootX] < rank[rootY])
                        {
                            root[rootX] = rootY;
                        }
                        else
                        {
                            root[rootY] = rootX;
                            rank[rootX] += 1;
                        }
                    }
                }

                public bool connected(int x, int y)
                {
                    return find(x) == find(y);
                }
            }

        }
    }
}
