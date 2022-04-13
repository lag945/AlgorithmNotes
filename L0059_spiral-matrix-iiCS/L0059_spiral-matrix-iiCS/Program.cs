using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0059_spiral_matrix_iiCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int n = 4;
            int [][]  r = s.GenerateMatrix(4);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(r[i][j].ToString("00"));
                }
                Console.WriteLine("");
            }
        }

        public class Solution
        {
            public int[][] GenerateMatrix(int n)
            {
                int[][] ret = new int[n][];

                for (int i = 0; i < n; i++)
                    ret[i] = new int[n];

                int x = 0;
                int y = 0;
                int type = 0;
                for (int i = 1; i <= n * n; i++)
                {
                    while (ret[x][y] != 0)
                    {
                        if (type == 0)//r
                        {
                            if (y + 1 < n && ret[x][y + 1] == 0)
                                y = y + 1;
                            else
                                type++;
                        }
                        else if (type == 1 )//d
                        {
                            if (x + 1 < n && ret[x + 1][y] == 0)
                                x = x + 1;
                            else
                                type++;
                        }
                        else  if (type == 2)//l
                        {
                            if (y - 1 >= 0 && ret[x][y - 1] == 0)
                                y = y - 1;
                            else
                                type++;
                        }
                        else if (type == 3)//up
                        {
                            if (x - 1 >= 0 && ret[x - 1][y] == 0)
                                x = x - 1;
                            else
                                type = 0;
                        }
                    }
                    ret[x][y] = i;

                }

                return ret;
            }


        }
    }
}
