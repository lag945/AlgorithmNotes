using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0474_ones_and_zeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strs = new string[5];
            strs[0] = "10";
            strs[1] = "0001";
            strs[2] = "111001";
            strs[3] = "1";
            strs[4] = "0";
            Solution s = new Solution();

            bool r = s.FindMaxForm2(strs, 3, 4) == 3;
        }

        public class Solution
        {

            public struct Data
            {
                public int zeroes;
                public int ones;

                public Data(int a_zeroes, int a_ones)
                {
                    zeroes = a_zeroes;
                    ones = a_ones;
                }
            }

            public int FindMaxForm2(string[] strs, int m, int n)
            {

                int ret = 0;

                List<Data> datas = new List<Data>();

                for (int i = 0; i < strs.Length; i++)
                {
                    int len = strs[i].Length;
                    if (len > (m + n))
                        continue;

                    int zeroes = 0;
                    int ones = 0;
                    for (int j = 0; j < len; j++)
                    {
                        if (strs[i][j] == '0')
                            zeroes++;
                        else if (strs[i][j] == '1')
                            ones++;
                    }
                    if (zeroes > m)
                        continue;
                    if (ones > n)
                        continue;

                    //Console.WriteLine(string.Format("{0}-{1}", zeroes, ones));
                    datas.Add(new Data(zeroes, ones));
                }


                int[][] dp = new int[m + 1][];

                for (int i = 0; i < m + 1; i++)
                    dp[i] = new int[n + 1];

                for (int k = 0; k < datas.Count; k++)
                {
                    for (int i = m; i >= datas[k].zeroes; i--)  
                    {
                        for (int j = n; j >= datas[k].ones; j--)
                        {
                            dp[i][j] = Math.Max(dp[i][j], dp[i- datas[k].zeroes][ j- datas[k].ones] + 1);
                        }
                    }
                }

                ret = dp[m][n];
                return ret;
            }

            public int FindMaxForm(string[] strs, int m, int n)
            {

                int ret = 0;

                List<Data> datas = new List<Data>();

                for (int i = 0; i < strs.Length; i++)
                {
                    int len = strs[i].Length;
                    if (len > (m + n))
                        continue;

                    int zeroes = 0;
                    int ones = 0;
                    for (int j = 0; j < len; j++)
                    {
                        if (strs[i][j] == '0')
                            zeroes++;
                        else if (strs[i][j] == '1')
                            ones++;
                    }
                    if (zeroes > m)
                        continue;
                    if (ones > n)
                        continue;

                    Console.WriteLine(string.Format("{0}-{1}",zeroes,ones));
                    datas.Add(new Data(zeroes, ones));
                }


                for (int i = 0; i < datas.Count; i++)
                    DFS(i, 0, m, n, datas, ref ret);

                return ret;
            }

            private void DFS(int index, int count, int m, int n, List<Data> datas, ref int ret)
            {
                m -= datas[index].zeroes;
                n -= datas[index].ones;
                count++;
                Console.WriteLine(string.Format("{0}-{1}-{2}-{3}",index,count,m,n));
                if (m < 0)
                    return;
                if (n < 0)
                    return;

                ret = Math.Max(ret, count);

                for (int i = index + 1; i < datas.Count; i++)
                {
                    DFS(i, count, m, n, datas, ref ret);
                }

            }
        }
    }
}
