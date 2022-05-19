using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0057_insert_intervalCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            //[[1,2],[3,5],[6,7],[8,10],[12,16]]
            //[4,8]
            int[][] intervals = new int[5][];
            intervals[0] = new int[] { 1, 2 };
            intervals[1] = new int[] { 3, 5 };
            intervals[2] = new int[] { 6, 7 };
            intervals[3] = new int[] { 8, 10 };
            intervals[4] = new int[] { 12, 16 };
            var r = s.Insert(intervals, new int[] { 4, 8 });
        }

    }

    public class Solution
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var ret = new List<int[]>();
            bool insert = false;
            for (int i = 0; i < intervals.Length; i++)
            {
                int[] current = intervals[i];

                if (!insert && newInterval[1] < current[0])
                {
                    ret.Add(newInterval);
                    insert = true;
                }

                if (current[0] > newInterval[1] || current[1] < newInterval[0]) //no intersect
                {
                    ret.Add(current);
                }
                else
                {
                    newInterval[0] = Math.Min(current[0], newInterval[0]);
                    newInterval[1] = Math.Max(current[1], newInterval[1]);
                }
            }


            if (!insert)
            {
                ret.Add(newInterval);
                insert = true;
            }

            return ret.ToArray();
        }
    }
}
