using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0055_jump_gameCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            bool r = s.CanJump2(new int[] { 2, 3, 1, 1, 4 }) == true;
            bool r2 = s.CanJump2(new int[] { 3, 2, 1, 0, 4 }) == false;
        }

        public class Solution
        {
            public bool CanJump(int[] nums)
            {
                int n = nums.Length;
                int last = n - 1, i, j;
                for (i = n - 2; i >= 0; i--)
                {
                    if (i + nums[i] >= last) last = i;
                }
                return last <= 0;
            }

            public bool CanJump2(int[] nums)
            {

                bool ret = false;

                int left = 0;
                int right = nums.Length - 1;

                if (nums.Length == 1)
                    return true;
                if (nums[left] == 0)
                    return ret;

                while (left < right)
                {
                    //don't go to zero
                    bool move = false;
                    /*
                    for (int i = 1; i <= nums[left]; i++)
                    {
                        int n = left + i;
                        if (n < 0 || n >= nums.Length)
                            break;
                        if (nums[n] > 0)
                        {
                            left = n;
                            move = true;
                        }
                    }
                    */
                    for (int i = 1; i <= right; i++)
                    {
                        int n = right - i;
                        if (n < 0 || n >= nums.Length)
                            break;
                        if (right - n <= nums[n])
                        {
                            right = n;
                            move = true;
                            break;
                        }
                    }

                    if (!move)
                        return ret;

                }

                ret = true;

                return ret;
            }
        }
    }
}
