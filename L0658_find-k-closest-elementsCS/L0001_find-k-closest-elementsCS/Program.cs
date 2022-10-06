using System;
using System.Collections.Generic;

namespace L0001_find_k_closest_elementsCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var ret = s.FindClosestElements(new int[] { 0, 2, 2, 3, 4, 5, 5, 6, 6, 6, 7, 8, 9, 11, 11, 15, 16, 19, 20, 21, 22, 22, 22, 23, 25, 26, 27, 28, 28, 28, 29, 29, 29, 31, 31, 31, 32, 34, 34, 34, 35, 35, 35, 38, 40, 41, 42, 45, 45, 45, 46, 49, 53, 53, 54, 58, 61, 62, 63, 63, 65, 66, 66, 67, 69, 70, 71, 72, 73, 74, 74, 74, 74, 75, 76, 76, 77, 77, 79, 80, 82, 82, 83, 86, 86, 86, 87, 89, 90, 90, 91, 92, 95, 96, 96, 97, 98, 98, 98, 99 }, 28, 57);
        }

        public class Solution
        {
            public IList<int> FindClosestElements(int[] arr, int k, int x)
            {
                SortedDictionary<int, List<int>> dic = new SortedDictionary<int, List<int>>();
                foreach (int a in arr)
                {
                    int distance = Math.Abs(a - x);
                    if (!dic.ContainsKey(distance))
                        dic[distance] = new List<int>();

                    dic[distance].Add(a);
                }

                List<int> ret = new List<int>();

                foreach (int dis in dic.Keys)
                {
                    for (int i = 0; i < dic[dis].Count; i++)
                    {
                        ret.Add(dic[dis][i]);
                        if (ret.Count >= k)
                        {
                            ret.Sort();
                            return ret.ToArray();
                        }
                    }
                }

                return ret.ToArray();
            }

        }
    }
}
