using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0980_Unique_PathsCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();

            List<int[]> grid = new List<int[]>();
            grid.Add(new int[] { 1, 0, 0, 0 });
            grid.Add(new int[] { 0, 0, 0, 0 });
            grid.Add(new int[] { 0, 0, 2, -1 });
            int ret = s.UniquePathsIII(grid.ToArray());
        }

        public class Solution
        {

            int solution = 0;
            int empty = 0;

            public int UniquePathsIII(int[][] grid)
            {
                int m = grid.Length, n = grid[0].Length;

                int sx = -1;
                int sy = -1;
                // counting empty and find starting square.
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (grid[i][j] == 0)
                        {
                            empty++;
                        }
                        else if (grid[i][j] == 1)
                        {
                            empty++;
                            sx = i;
                            sy = j;
                        }
                    }
                }
                DFS(grid, sx, sy);
                return solution;
            }

            public void DFS(int[][] grid, int x, int y)
            {
                // cross the border
                if (x < 0 || y < 0 || x >= grid.Length || y >= grid[0].Length || grid[x][y] < 0)
                {
                    return;
                }

                //find end
                if (grid[x][y] == 2)
                {
                    if (empty == 0)
                    {
                        solution++;
                    }
                    return;
                }

                empty--;

                grid[x][y] = -2;
                DFS(grid, x + 1, y);
                DFS(grid, x - 1, y);
                DFS(grid, x, y + 1);
                DFS(grid, x, y - 1);
                grid[x][y] = 0;

                empty++;
            }
        }
    }
}
