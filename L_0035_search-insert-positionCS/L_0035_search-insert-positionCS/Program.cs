using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_0035_search_insert_positionCS
{
    //https://leetcode.com/problems/search-insert-position/
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int ret = s.SearchInsert(new int[] { 1, 3, 5, 6 }, 7);
            ret = s.SearchInsert2(new int[] { 1, 3, 5, 6 }, 4);
        }

        public class Solution
        {
            public int SearchInsert(int[] nums, int target)
            {
                //T:O(log(n))
                return FindIndex(nums, 0, nums.Length-1, target);
            }

            private int FindIndex(int[] nums, int left, int right, int target)
            {
                int ret = 0;
                if (left >= right)
                {
                    if (target > nums[left])
                    {
                        ret = left + 1;
                    }
                    else
                    {
                        ret = left;
                    }
                }
                else
                {
                    int mid = (left + right) / 2;

                    if (target > nums[mid])
                    {
                        return FindIndex(nums, mid + 1, right, target);
                    }
                    else
                    {
                        return FindIndex(nums, left, right - 1, target);
                    }
                }

                return ret;
            }

            public int SearchInsert2(int[] nums, int target)
            {
                int ret = (new List<int>(nums).BinarySearch(target));
                if (ret < 0)
                {
                    ret = ret * -1 - 1;
                }
                return ret;
            }
        }
    }
}
