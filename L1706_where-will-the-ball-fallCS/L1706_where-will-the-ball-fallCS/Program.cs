using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1706_where_will_the_ball_fallCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var grid = new int[5][];
            grid[0] = new int[] { 1, 1, 1, -1, -1 };
            grid[1] = new int[] { 1, 1, 1, -1, -1 };
            grid[2] = new int[] { -1, -1, -1, 1, 1 };
            grid[3] = new int[] { 1, 1, 1, 1, -1 };
            grid[4] = new int[] { -1, -1, -1, -1, -1 };
            var ret = s.FindBall(grid);
            bool isEqual = Enumerable.SequenceEqual(ret, new int[] { 1, -1, -1, -1, -1 });
        }

        public class Solution
        {
            public int[] FindBall(int[][] grid)
            {
                int h = grid.Length;
                int w= grid[0].Length;
                int[] ret = new int[w];

                for (int i = 0; i < w; i++)
                {
                    ret[i] = -1;
                    int x = i;
                    for (int j = 0; j < h; j++)
                    {
                        if (grid[j][x] == 1)
                        {
                            if (x + 1 < w)
                            {
                                if (grid[j][x + 1] == 1)
                                {
                                    if (j == h - 1)
                                    {
                                        ret[i] = x + 1;
                                    }
                                    x++;
                                }
                                else
                                    break;
                            }
                            else
                                break;
                        }
                        else
                        {
                            if (x - 1 >= 0)
                            {
                                if (grid[j][x - 1] == -1)
                                {
                                    if (j == h - 1)
                                    {
                                        ret[i] = x - 1;
                                    }
                                    x--;
                                }
                                else
                                    break;
                            }
                            else
                                break;
                        }
                    }
                }

                return ret;
            }
        }

    }
}
