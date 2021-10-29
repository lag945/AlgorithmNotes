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

            List<int[]> grid = new List<int[]>();
            //grid.Add(new int[] { 2, 1, 1 });
            //grid.Add(new int[] { 1, 1, 0 });
            //grid.Add(new int[] { 0, 1, 1 });
            //bool ret = s.OrangesRotting(grid.ToArray()) == 4;
            //grid.Clear();
            //grid.Add(new int[] { 2, 1, 1 });
            //grid.Add(new int[] { 0, 1, 1 });
            //grid.Add(new int[] { 1, 0, 1 });
            //ret = s.OrangesRotting(grid.ToArray()) == -1;
            //grid.Clear();
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
            bool ret = s.OrangesRotting(grid.ToArray()) == 58;
        }

        public class Solution
        {
            public int OrangesRotting(int[][] grid)
            {
                int minute = 0;
                int size = grid.Length * grid[0].Length;
                Dictionary<string, int> orangesMap = new Dictionary<string, int>(size);

                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        string key = string.Format("{0},{1}", i, j);
                        orangesMap[key] = grid[i][j];
                    }
                }

                List<string> freshList = CountFresh(orangesMap);

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

            public List<string> CountFresh(Dictionary<string, int> map)
            {
                List<string> ret = new List<string>();

                foreach (string key in map.Keys)
                {
                    if (map[key] == 1)
                    {
                        ret.Add(key);
                    }
                }

                return ret;
            }

            public int Rotting(Dictionary<string, int> map, List<string> freshList)
            {
                List<string> _freshList = new List<string>(freshList.Count);
                List<string> rotList = new List<string>(freshList.Count);

                for (int i = 0; i < freshList.Count; i++)
                {
                    string[] strs = freshList[i].Split(',');
                    int x = Convert.ToInt32(strs[0]);
                    int y = Convert.ToInt32(strs[1]);
                    bool rot = false;
                    int val;
                    //Left
                    string key = string.Format("{0},{1}", x - 1, y);
                    if (!rot && map.TryGetValue(key, out val))
                    {
                        if (val == 2)
                        {
                            rot = true;
                        }
                    }
                    //Top
                    key = string.Format("{0},{1}", x, y + 1);
                    if (!rot && map.TryGetValue(key, out val))
                    {
                        if (val == 2)
                        {
                            rot = true;
                        }
                    }
                    //Right
                    key = string.Format("{0},{1}", x + 1, y);
                    if (!rot && map.TryGetValue(key, out val))
                    {
                        if (val == 2)
                        {
                            rot = true;
                        }
                    }
                    //Bottom
                    key = string.Format("{0},{1}", x, y - 1);
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
