using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0329_longest_increasing_path_in_a_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[][] matrix = new int[3][];
            matrix[0] = new int[] { 9, 9, 4 };
            matrix[1] = new int[] { 6, 6, 8 };
            matrix[2] = new int[] { 2, 1, 1 };
            int r = s.LongestIncreasingPath(matrix);
        }

        public class Solution
        {
            int max = 1;
            public int LongestIncreasingPath(int[][] matrix)
            {
                Dictionary<int, List<long>> map = new Dictionary<int, List<long>>();
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        int key = matrix[i][j];
                        if (!map.ContainsKey(key))
                            map[key] = new List<long>();

                        long code = ((long)i)<< 32 | (long)j;
                        map[key].Add(code);
                    }
                }

                Dictionary<long, int> dp = new Dictionary<long, int>();
                int[] keys = map.Keys.ToArray();
                Array.Sort(keys);
                Array.Reverse(keys);

                foreach (int key in keys)
                {
                    foreach (long code in map[key])
                    {
                        dp[code] = 1;
                        DFS(code, matrix, dp);
                        Console.WriteLine(key.ToString() + "," + dp[code].ToString());
                    }
                }

                return max;
            }

            private void DFS(long code, int[][] matrix, Dictionary<long, int> dp)
            {
                int x = (int)(code >> 32);
                int y = (int)code;
                int current = matrix[x][y];
                int _x = x;
                int _y = y;

                //L
                _x = x - 1;
                _y = y;

                if (_x >= 0 && _x < matrix.Length && _y >= 0 && _y < matrix[x].Length)
                {
                    int next = matrix[_x][_y];
                    if (next > current)
                    {
                        long _code = ((long)_x) << 32 | (long)_y;
                        int len = dp[_code] + 1;
                        dp[code] = Math.Max(dp[code], len);
                        max = Math.Max(max, len);
                    }
                }

                //T
                _x = x ;
                _y = y-1;

                if (_x >= 0 && _x < matrix.Length && _y >= 0 && _y < matrix[x].Length)
                {
                    int next = matrix[_x][_y];
                    if (next > current)
                    {
                        long _code = ((long)_x) << 32 | (long)_y;
                        int len = dp[_code] + 1;
                        dp[code] = Math.Max(dp[code], len);
                        max = Math.Max(max, len);
                    }
                }

                //R
                _x = x + 1;
                _y = y;

                if (_x >= 0 && _x < matrix.Length && _y >= 0 && _y < matrix[x].Length)
                {
                    int next = matrix[_x][_y];
                    if (next > current)
                    {
                        long _code = ((long)_x) << 32 | (long)_y;
                        int len = dp[_code] + 1;
                        dp[code] = Math.Max(dp[code], len);
                        max = Math.Max(max, len);
                    }
                }

                //B
                _x = x ;
                _y = y+1;

                if (_x >= 0 && _x < matrix.Length && _y >= 0 && _y < matrix[x].Length)
                {
                    int next = matrix[_x][_y];
                    if (next > current)
                    {
                        long _code = ((long)_x) << 32 | (long)_y;
                        int len = dp[_code] + 1;
                        dp[code] = Math.Max(dp[code], len);
                        max = Math.Max(max, len);
                    }
                }



            }
        }
    }
}
