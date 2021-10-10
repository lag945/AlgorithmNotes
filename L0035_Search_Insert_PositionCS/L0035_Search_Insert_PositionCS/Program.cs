using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0035_Search_Insert_PositionCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int r = s.SearchInsert(new int[] { 1, 3, 5, 6 }, 2);
        }

        public class Solution
        {
            public int SearchInsert(int[] nums, int target)
            {
                List<int> list = new List<int>(nums);
                int ret = list.BinarySearch(target);
                if (ret < 0)
                {
                    ret = (ret * -1) - 1;
                }
                return ret;
            }
        }
    }
}
