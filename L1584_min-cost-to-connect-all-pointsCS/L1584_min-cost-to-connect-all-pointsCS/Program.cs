using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1584_min_cost_to_connect_all_pointsCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[][] points = new int[5][];
            points[0] = new int[] { 0, 0 };
            points[1] = new int[] { 2, 2 };
            points[2] = new int[] { 3, 10 };
            points[3] = new int[] { 5, 2 };
            points[4] = new int[] { 7, 0 };
            bool r = s.MinCostConnectPoints(points) == 20;
        }

        public class Solution
        {
            struct Edge
            {
                public int from;
                public int to;
                public int weight;
            }
            public int MinCostConnectPoints(int[][] points)
            {
                int ret = 0;
                List<Edge> edges = new List<Edge>();

                for (int i = 0; i < points.Length; i++)
                {
                    for (int j = 0; j < points.Length; j++)
                    {
                        if (i != j)
                        {
                            Edge edge = new Edge();
                            edge.from = i;
                            edge.to = j;
                            edge.weight = Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]);
                            edges.Add(edge);
                        }
                    }
                }
                edges.Sort(Asc);

                UnionFind uf = new UnionFind(points.Length);
                List<Edge> answer = new List<Edge>();
                for (int i = 0; i < edges.Count; i++)
                {
                    answer.Add(edges[i]);
                    if (uf.union(edges[i].from, edges[i].to))
                    {
                        ret += edges[i].weight;
                    }
                    else
                    {
                        answer.RemoveAt(answer.Count - 1);
                    }
                }

                return ret;
            }

            private int Asc(Edge x, Edge y)
            {
                return x.weight - y.weight;
            }

            class UnionFind
            {
                public int[] group;
                public int[] rank;

                public UnionFind(int size)
                {
                    group = new int[size];
                    rank = new int[size];
                    for (int i = 0; i < size; ++i)
                    {
                        group[i] = i;
                    }
                }

                public int find(int node)
                {
                    if (group[node] != node)
                    {
                        group[node] = find(group[node]);
                    }
                    return group[node];
                }

                public bool union(int node1, int node2)
                {
                    int group1 = find(node1);
                    int group2 = find(node2);

                    // node1 and node2 already belong to same group.
                    if (group1 == group2)
                    {
                        return false;
                    }

                    if (rank[group1] > rank[group2])
                    {
                        group[group2] = group1;
                    }
                    else if (rank[group1] < rank[group2])
                    {
                        group[group1] = group2;
                    }
                    else
                    {
                        group[group1] = group2;
                        rank[group2] += 1;
                    }

                    return true;
                }
            }


        }
    }
}
