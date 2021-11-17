using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0027_RemoveElementCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] nums = new int[] { 3,2,2,3};
            int ret = s.RemoveElement(nums, 3);
        }

        //https://leetcode.com/problems/remove-element/

        public class Solution
        {
            public int RemoveElement(int[] nums, int val)
            {
                int ret = 0;

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != val)
                    {
                        nums[ret] = nums[i];
                        ret++;
                    }
                }

                return ret;
            }
            public int RemoveElement2(int[] nums, int val)
            {
                int ret = 0;
                int swapIndex = nums.Length - 1;

                for (int i = 0; i < nums.Length; i++)
                {
                    if (i > swapIndex)
                        break;
                    if (nums[i] == val)
                    {
                        while (i < swapIndex)
                        {
                            nums[i] = nums[swapIndex];
                            swapIndex--;
                            if (nums[i] != val)
                            {
                                ret++;
                                break;
                            }
                        }
                    }
                    else
                    {
                        ret++;
                    }
                }

                return ret;
            }
        }
    }
}
