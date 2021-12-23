using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0210_course_schedule_ii
{
    class Program
    {
        //https://leetcode.com/problems/course-schedule-ii/solution/
        static void Main(string[] args)
        {
            Solution s = new Solution();
            //int[] ret = s.FindOrder(2, new int[][] { new int[] { 1, 0 } });
            //int[] ret = s.FindOrder(1, new int[][] { });
            //int[] ret = s.FindOrder(2, new int[][] { new int[] { 0, 1 } });
            int[] ret = s.FindOrder(4, new int[][] { new int[] { 1, 0 }, new int[] { 3, 0 }, new int[] { 0, 3 }, new int[] { 3, 2 } });
            //int[] ret = s.FindOrder(4, new int[][] { new int[] { 1, 0 }, new int[] { 2, 0 }, new int[] { 3, 1 }, new int[] { 3, 2 } });
        }

        public class Solution
        {
            public int[] FindOrder(int numCourses, int[][] prerequisites)
            {
                Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
                int[] indegree = new int[numCourses];
                int[] topologicalOrder = new int[numCourses];
                int i = 0;
                // Create the adjacency list representation of the graph
                for (i = 0; i < prerequisites.Length; i++)
                {
                    int dest = prerequisites[i][0];
                    int src = prerequisites[i][1];
                    if (!adjList.ContainsKey(src))
                    {
                        adjList[src] = new List<int>();
                    }
                    adjList[src].Add(dest);
                    // Record in-degree of each vertex
                    indegree[dest] += 1;
                }

                // Add all vertices with 0 in-degree to the queue
                Queue<int> q = new Queue<int>();
                for (i = 0; i < numCourses; i++)
                {
                    if (indegree[i] == 0)
                    {
                        q.Enqueue(i);
                    }
                }

                i = 0;
                // Process until the Q becomes empty
                while (q.Count != 0)
                {
                    int node = q.Dequeue();
                    topologicalOrder[i++] = node;

                    // Reduce the in-degree of each neighbor by 1
                    if (adjList.ContainsKey(node))
                    {
                        foreach(int neighbor in adjList[node])
                        {
                            indegree[neighbor]--;

                            // If in-degree of a neighbor becomes 0, add it to the Q
                            if (indegree[neighbor] == 0)
                            {
                                q.Enqueue(neighbor);
                            }
                        }
                    }
                }

                // Check to see if topological sort is possible or not.
                if (i == numCourses)
                {
                    return topologicalOrder;
                }

                return new int[0];
            }
            //Time Limit Exceeded
            public int[] FindOrder2(int numCourses, int[][] prerequisites)
            {
                HashSet<int> ret = new HashSet<int>();

                Dictionary<int, HashSet<int>> cpMap = new Dictionary<int, HashSet<int>>(numCourses);

                foreach (int[] p in prerequisites)
                {
                    int course = p[0];
                    int prerequisite = p[1];
                    if (!cpMap.ContainsKey(course))
                    {
                        cpMap.Add(course, new HashSet<int>());
                    }
                    cpMap[course].Add(prerequisite);
                }

                for (int i = 0; i < numCourses; i++)
                {
                    //find head without prerequisites
                    if (cpMap.ContainsKey(i))
                        continue;
                    if (Visit(i, numCourses, cpMap, ret))
                    {
                        break;
                    }
                    else
                    {
                        ret.Clear();
                    }
                }
                return ret.ToArray();//make sure hashset's order
            }

            private bool Visit(int course, int numCourses, Dictionary<int, HashSet<int>> cpMap, HashSet<int> ret)
            {
                if (cpMap.ContainsKey(course))
                {
                    foreach (int p in cpMap[course])
                    {
                        if (!ret.Contains(p))//not satisfied
                        {
                            return false;
                        }
                    }
                }

                ret.Add(course);

                if (ret.Count == numCourses)
                    return true;

                for (int i = 0; i < numCourses; i++)
                {
                    if (ret.Contains(i))
                        continue;

                    if (Visit(i, numCourses, cpMap, ret))
                    {
                        return true;
                    }
                }
                ret.Remove(course);//no solution

                return false;
            }
        }
    }
}
