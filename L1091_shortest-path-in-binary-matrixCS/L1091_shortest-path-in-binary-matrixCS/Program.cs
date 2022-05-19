using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace L1091_shortest_path_in_binary_matrixCS
{
    class Program
    {
        static void Main(string[] args)
        {

            Stopwatch sw = new Stopwatch();

            int max = 15;
            Solution s = new Solution();

            for (int n = 1; n <= max; n++)
            {
                int[][] grid = new int[n][];
                for (int i = 0; i < n; i++)
                {
                    grid[i] = new int[n];
                    for (int j = 0; j < i; j++)
                        grid[i][j] = 1;
                }

                sw.Restart();
                int r = s.ShortestPathBinaryMatrix(grid);
                sw.Stop();
                Console.WriteLine(string.Format("DFS:n={0},r={1},t={2}", n, r, sw.Elapsed.TotalSeconds.ToString("0.00")));

                sw.Restart();
                int r2 = s.ShortestPathBinaryMatrix_BFS(grid);
                sw.Stop();
                Console.WriteLine(string.Format("BFS:n={0},r={1},t={2}", n, r2, sw.Elapsed.TotalSeconds.ToString("0.00")));
            }

        }

        public class Solution
        {
            int path = Int32.MaxValue;

            int[,] directions = new int[,] { { 0, -1 }, { 1, -1 }, { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, 1 }, { -1, 0 }, { -1, -1 } };
            public int ShortestPathBinaryMatrix(int[][] grid)
            {
                int n = grid.Length;
                path = Int32.MaxValue;

                //no start or end point
                if (grid[0][0] == 1 || grid[n - 1][n - 1] == 1)
                    return -1;

                grid[0][0] = 1;
                DFS(1, 0, 0, grid);
                grid[0][0] = 0;

                if (path == Int32.MaxValue)
                    path = -1;

                return path;
            }

            private bool Valid(int x, int y, int[][] grid)
            {
                int n = grid.Length;

                if (x < 0)
                    return false;
                if (x >= n)
                    return false;
                if (y < 0)
                    return false;
                if (y >= n)
                    return false;

                if (grid[x][y] == 1)
                    return false;

                return true;
            }

            private void DFS(int step, int x, int y, int[][] grid)
            {
                if (step > path)
                    return;

                int n = grid.Length;
                if (x == n - 1 && y == n - 1)
                {
                    path = Math.Min(step, path);
                    return;
                }

                for (int i = 0; i < 8; i++)
                {
                    int _x = x + directions[i, 0];
                    int _y = y + directions[i, 1];
                    if (!Valid(_x, _y, grid))
                        continue;
                    grid[_x][_y] = 1;
                    DFS(step + 1, _x, _y, grid);
                    grid[_x][_y] = 0;
                }

            }

            private bool Valid_BFS(int x, int y, int[][] grid, bool[,] visited)
            {
                int n = grid.Length;

                if (x < 0)
                    return false;
                if (x >= n)
                    return false;
                if (y < 0)
                    return false;
                if (y >= n)
                    return false;

                if (grid[x][y] == 1)
                    return false;

                if (visited[x, y])
                    return false;

                return true;
            }

            public int ShortestPathBinaryMatrix_BFS(int[][] grid)
            {
                int n = grid.Length;

                //no start or end point
                if (grid[0][0] == 1 || grid[n - 1][n - 1] == 1)
                    return -1;

                bool[,] visited = new bool[n, n];
                Queue<int[]> queue = new Queue<int[]>();
                queue.Enqueue(new int[] { 0, 0, 0 });
                visited[0, 0] = true;

                while (queue.Count > 0)
                {
                    int [] current = queue.Dequeue();
                    if (current[0] == n - 1 && current[1] == n - 1)
                        return current[2] + 1;

                    for (int i = 0; i < 8; i++)
                    {
                        int x = current[0] + directions[i, 0];
                        int y = current[1] + directions[i, 1];
                        if (Valid_BFS(x, y, grid, visited))
                        {
                            visited[x, y] = true;
                            queue.Enqueue(new int[] { x, y, current[2] + 1 });
                        }
                    }
                }

                return -1;
            }

        }

    }
}
