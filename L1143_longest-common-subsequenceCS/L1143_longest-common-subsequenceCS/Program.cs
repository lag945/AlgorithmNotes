using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1143_longest_common_subsequenceCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();

            bool r = s.LongestCommonSubsequence("adbce", "abcde") == 4;
        }

        public class Solution
        {
            public int LongestCommonSubsequence(string a, string b)
            {
                int size = Math.Max(a.Length, b.Length);
                int [][] m = new int[size + 1][];
                for (int i = 0; i < size + 1; i++)
                    m[i] = new int[size + 1];

                //Print(m);
                for (int i = 0; i < a.Length; ++i)
                    for (int j = 0; j < b.Length; ++j)
                    {
                        Console.WriteLine(string.Format("({0},{1})=({2},{3})",i,j,a[i],b[j]));
                        m[i + 1][j + 1] = (a[i] == b[j] ? m[i][j] + 1 : Math.Max(m[i + 1][j], m[i][j + 1]));
                        Print(m);
                    }
                return m[a.Length][b.Length];

            }

            private void Print(int [][] m)
            {
                Console.WriteLine("------");
                for (int i = 0; i < m.Length; i++)
                {
                    for (int j = 0; j < m[i].Length; j++)
                    {
                        Console.Write($"{m[i][j]} ");
                    }
                    Console.WriteLine();
                }
            }

        }
    }
}
