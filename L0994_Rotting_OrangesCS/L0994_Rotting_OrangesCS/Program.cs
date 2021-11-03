using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0994_Rotting_OrangesCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();

            long key = s.MakeKey(1024, 568);

            int[] values = s.GetValue(key);

            List<int[]> grid = new List<int[]>();
            grid.Add(new int[] { 2, 1, 1 });
            grid.Add(new int[] { 1, 1, 0 });
            grid.Add(new int[] { 0, 1, 1 });
            bool ret = s.OrangesRotting(grid.ToArray()) == 4;
            grid.Clear();
            grid.Add(new int[] { 2, 1, 1 });
            grid.Add(new int[] { 0, 1, 1 });
            grid.Add(new int[] { 1, 0, 1 });
            ret = s.OrangesRotting(grid.ToArray()) == -1;
            grid.Clear();
            grid.Add(new int[] { 2, 0, 1, 1, 1, 1, 1, 1, 1, 1 });
            grid.Add(new int[] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 1 });
            grid.Add(new int[] { 1, 0, 1, 0, 1, 1, 1, 1, 0, 1 });
            grid.Add(new int[] { 1, 0, 1, 0, 1, 0, 0, 1, 0, 1 });
            grid.Add(new int[] { 1, 0, 1, 0, 1, 0, 0, 1, 0, 1 });
            grid.Add(new int[] { 1, 0, 1, 0, 1, 1, 0, 1, 0, 1 });
            grid.Add(new int[] { 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 });
            grid.Add(new int[] { 1, 0, 1, 1, 1, 1, 1, 1, 0, 1 });
            grid.Add(new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 });
            grid.Add(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
            //[[2,0,1,1,1,1,1,1,1,1],[1,0,1,0,0,0,0,0,0,1],[1,0,1,0,1,1,1,1,0,1],[1,0,1,0,1,0,0,1,0,1],[1,0,1,0,1,0,0,1,0,1],[1,0,1,0,1,1,0,1,0,1],[1,0,1,0,0,0,0,1,0,1],[1,0,1,1,1,1,1,1,0,1],[1,0,0,0,0,0,0,0,0,1],[1,1,1,1,1,1,1,1,1,1]]
            ret = s.OrangesRotting(grid.ToArray()) == 58;
        }

        public class Solution
        {
            public long MakeKey(int x, int y)
            {
                long ret = 0;

                ret = ((long)x) << 32 | (long)y;

                return ret;
            }

            public int[] GetValue(long key)
            {
                int[] ret = new int[2];

                ret[0] = (int)(key >> 32);
                ret[1] = (int)(key);

                return ret;
            }
            public int OrangesRotting(int[][] grid)
            {
                int minute = 0;
                int size = grid.Length * grid[0].Length;
                Dictionary<long, int> orangesMap = new Dictionary<long, int>(size);

                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        long key = MakeKey(i, j);
                        orangesMap[key] = grid[i][j];
                    }
                }

                List<long> freshList = CountFresh(orangesMap);

                while (freshList.Count != 0)
                {
                    int rotCnt = Rotting(orangesMap, freshList);
                    minute++;
                    if (rotCnt == 0)
                    {
                        minute = -1;
                        break;
                    }
                }

                return minute;
            }

            public List<long> CountFresh(Dictionary<long, int> map)
            {
                List<long> ret = new List<long>();

                foreach (long key in map.Keys)
                {
                    if (map[key] == 1)
                    {
                        ret.Add(key);
                    }
                }

                return ret;
            }

            public int Rotting(Dictionary<long, int> map, List<long> freshList)
            {
                List<long> _freshList = new List<long>(freshList.Count);
                List<long> rotList = new List<long>(freshList.Count);

                for (int i = 0; i < freshList.Count; i++)
                {
                    int[] keys = GetValue(freshList[i]);
                    int x = keys[0];
                    int y = keys[1];
                    bool rot = false;
                    int val;
                    //Left
                    long key = MakeKey(x - 1, y);
                    if (!rot && map.TryGetValue(key, out val))
                    {
                        if (val == 2)
                        {
                            rot = true;
                        }
                    }
                    //Top
                    key = MakeKey(x, y + 1);
                    if (!rot && map.TryGetValue(key, out val))
                    {
                        if (val == 2)
                        {
                            rot = true;
                        }
                    }
                    //Right
                    key = MakeKey(x + 1, y);
                    if (!rot && map.TryGetValue(key, out val))
                    {
                        if (val == 2)
                        {
                            rot = true;
                        }
                    }
                    //Bottom
                    key = MakeKey(x, y - 1);
                    if (!rot && map.TryGetValue(key, out val))
                    {
                        if (val == 2)
                        {
                            rot = true;
                        }
                    }
                    if (rot)
                    {
                        rotList.Add(freshList[i]);
                    }
                    else
                    {
                        _freshList.Add(freshList[i]);
                    }
                }

                for (int i = 0; i < rotList.Count; i++)
                {
                    map[rotList[i]] = 2;
                }

                freshList.Clear();
                freshList.AddRange(_freshList);

                return rotList.Count;
            }

        }
    }
}
