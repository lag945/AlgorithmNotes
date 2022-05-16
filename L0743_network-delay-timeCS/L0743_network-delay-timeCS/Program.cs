using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0743_network_delay_timeCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution3 s = new Solution3();
            int[][] times = new int[3][];
            times[0] = new int[] { 2, 1, 1 };
            times[1] = new int[] { 2, 3, 1 };
            times[2] = new int[] { 3, 4, 1 };
            int r = s.NetworkDelayTime(times, 4, 2);

            //int[][] times = new int[1][];
            //times[0] = new int[] { 1, 2, 1 };
            //int r = s.NetworkDelayTime(times, 2, 1);

            //int[][] times = new int[1][];
            //times[0] = new int[] { 1, 2, 1 };
            //int r = s.NetworkDelayTime(times, 2, 2);

        }

        public class Solution
        {
            public int NetworkDelayTime(int[][] times, int n, int k)
            {

                int[] delayTime = new int[n + 1];
                for (int i = 0; i <= n; i++)
                    delayTime[i] = -1;

                Dictionary<int, List<int[]>> map = new Dictionary<int, List<int[]>>();

                foreach (int[] t in times)
                {
                    if (!map.ContainsKey(t[0]))
                    {
                        map[t[0]] = new List<int[]>();
                    }

                    map[t[0]].Add(t);
                }

                Visit(k, 0, map, delayTime);

                delayTime[0] = 0;

                if (delayTime.Min() < 0)
                    return -1;
                else
                    return delayTime.Max();

            }

            private void Visit(int k, int passTime, Dictionary<int, List<int[]>> map, int[] delayTime)
            {

                if (delayTime[k] < 0)
                    delayTime[k] = passTime;
                else if (passTime < delayTime[k])
                {
                    delayTime[k] = passTime;
                }
                else
                    return;

                if (map.ContainsKey(k))
                {
                    foreach (int[] edge in map[k])
                    {
                        Visit(edge[1], passTime + edge[2], map, delayTime);
                    }
                }

            }

        }

        //DFS
        public class Solution2
        {
            // Adjacency list
            Dictionary<int, List<int[]>> adj = new Dictionary<int, List<int[]>>();

            public int NetworkDelayTime(int[][] times, int n, int k)
            {
                // Build the adjacency list
                foreach (int[] time in times)
                {
                    int source = time[0];
                    int dest = time[1];
                    int travelTime = time[2];

                    if (!adj.ContainsKey(source))
                        adj[source] = new List<int[]>();
                    adj[source].Add(new int[] { travelTime, dest });
                }

                int[] signalReceivedAt = new int[n + 1];
                for (int i = 0; i < signalReceivedAt.Length; i++)
                    signalReceivedAt[i] = Int32.MaxValue;

                DFS(signalReceivedAt, k, 0);

                int answer = Int32.MinValue;
                for (int node = 1; node <= n; node++)
                {
                    answer = Math.Max(answer, signalReceivedAt[node]);
                }

                // Integer.MAX_VALUE signifies atleat one node is unreachable
                return answer == Int32.MaxValue ? -1 : answer;
            }

            private void DFS(int[] signalReceivedAt, int currNode, int currTime)
            {
                // If the current time is greater than or equal to the fastest signal received
                // Then no need to iterate over adjacent nodes
                if (currTime >= signalReceivedAt[currNode])
                {
                    return;
                }

                // Fastest signal time for currNode so far
                signalReceivedAt[currNode] = currTime;

                if (!adj.ContainsKey(currNode))
                {
                    return;
                }

                // Broadcast the signal to adjacent nodes
                foreach (int[] edge in adj[currNode])
                {
                    int travelTime = edge[0];
                    int neighborNode = edge[1];

                    // currTime + time : time when signal reaches neighborNode
                    DFS(signalReceivedAt, neighborNode, currTime + travelTime);
                }
            }

        }

        //BFS
        public class Solution3
        {
            // Adjacency list
            Dictionary<int, List<int[]>> adj = new Dictionary<int, List<int[]>>();

            public int NetworkDelayTime(int[][] times, int n, int k)
            {
                // Build the adjacency list
                foreach (int[] time in times)
                {
                    int source = time[0];
                    int dest = time[1];
                    int travelTime = time[2];

                    if (!adj.ContainsKey(source))
                        adj[source] = new List<int[]>();
                    adj[source].Add(new int[] { travelTime, dest });
                }

                int[] signalReceivedAt = new int[n + 1];
                for (int i = 0; i < signalReceivedAt.Length; i++)
                    signalReceivedAt[i] = Int32.MaxValue;

                BFS(signalReceivedAt, k);

                int answer = Int32.MinValue;
                for (int node = 1; node <= n; node++)
                {
                    answer = Math.Max(answer, signalReceivedAt[node]);
                }

                // Integer.MAX_VALUE signifies atleat one node is unreachable
                return answer == Int32.MaxValue ? -1 : answer;
            }

            private void BFS(int[] signalReceivedAt, int sourceNode)
            {
                Queue<int> q = new Queue<int>();
                q.Enqueue(sourceNode);

                // Time for starting node is 0
                signalReceivedAt[sourceNode] = 0;

                while (q.Count > 0)
                {
                    int currNode = q.Dequeue();

                    if (!adj.ContainsKey(currNode))
                    {
                        continue;
                    }

                    // Broadcast the signal to adjacent nodes
                    foreach (int[] edge in adj[currNode])
                    {
                        int time = edge[0];
                        int neighborNode = edge[01];

                        // Fastest signal time for neighborNode so far
                        // signalReceivedAt[currNode] + time : 
                        // time when signal reaches neighborNode
                        int arrivalTime = signalReceivedAt[currNode] + time;
                        if (signalReceivedAt[neighborNode] > arrivalTime)
                        {
                            signalReceivedAt[neighborNode] = arrivalTime;
                            q.Enqueue(neighborNode);
                        }
                    }
                }

            }
        }

    }
}