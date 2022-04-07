using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1046_last_stone_weightCS
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://leetcode.com/problems/last-stone-weight/
            Solution s = new Solution();
            bool r = s.LastStoneWeight3(new int[] { 2, 7, 4, 1, 8, 1 })==1;
            //bool r = s.LastStoneWeight2(new int[] { 1,3 }) == 2;
            //bool r = s.LastStoneWeight2(new int[] { 2, 2 }) == 0;
        }

        public class Solution
        {
            public int LastStoneWeight(int[] stones)
            {
                //T: O(n^2log(n))
                //S: O(n)
                int ret = 0;
                List<int> stoneList = new List<int>(stones);
                while (stoneList.Count > 1)
                {
                    stoneList.Sort();
                    int x = stoneList[stoneList.Count - 2];
                    int y = stoneList[stoneList.Count - 1];
                    if (x == y)
                    {
                        stoneList.RemoveAt(stoneList.Count - 1);
                        stoneList.RemoveAt(stoneList.Count - 1);
                    }
                    else
                    {
                        stoneList.RemoveAt(stoneList.Count - 1);
                        stoneList.RemoveAt(stoneList.Count - 1);
                        stoneList.Add(y - x);
                    }
                }

                if (stoneList.Count == 1)
                    ret = stoneList[0];

                return ret;
            }

            //you can use PriorityQueue in .NET6
            public int LastStoneWeight2(int[] stones)
            {
                //T: O(nlog(n))
                //S: O(n)
                int ret = 0;
                SortedDictionary<int, int> map = new SortedDictionary<int, int>();
                foreach (int stone in stones)
                {
                    if (map.ContainsKey(stone))
                        map[stone]++;
                    else
                        map[stone] = 1;
                }

                while (map.Count > 1)//T:O(n)
                {
                    int y = map.Keys.ElementAt<int>(map.Count - 1);//T:O(1)
                    if (map[y] % 2 == 0)
                    {
                        map.Remove(y);//T:O(log(n))
                    }
                    else
                    {
                        map.Remove(y);//T:O(log(n))
                        int x = map.Keys.ElementAt<int>(map.Count - 1);
                        map[x] -= 1;
                        if(map[x]==0)
                            map.Remove(x);
                        int z = y - x;
                        if (map.ContainsKey(z))//T:O(log(n))
                            map[z]++;
                        else
                            map[z] = 1;
                    }
                }

                if (map.Count == 1)
                {
                    int key = map.Keys.ElementAt<int>(map.Count - 1);
                    if (map[key] % 2 != 0)
                        ret = key;
                }

                return ret;
            }

            public int LastStoneWeight3(int[] stones)
            {
                //T: O(nlog(n))
                //S: O(n)
                int ret = 0;
                List<int> stoneList = new List<int>(stones);
                stoneList.Sort();
                while (stoneList.Count > 1)
                {
                    int x = stoneList[stoneList.Count - 2];
                    int y = stoneList[stoneList.Count - 1];
                    if (x == y)
                    {
                        stoneList.RemoveAt(stoneList.Count - 1);
                        stoneList.RemoveAt(stoneList.Count - 1);
                    }
                    else
                    {
                        stoneList.RemoveAt(stoneList.Count - 1);
                        stoneList.RemoveAt(stoneList.Count - 1);
                        int z = y - x;
                        int index = stoneList.BinarySearch(z);
                        if (index < 0)
                            index = ~index;

                        stoneList.Insert(index,z);
                    }
                }

                if (stoneList.Count == 1)
                    ret = stoneList[0];

                return ret;
            }

        }

    }
}
