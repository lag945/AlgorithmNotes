using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0053_Maximum_SubarrayCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            //bool r = s.MaxSubArray(new int[] { 5, 4, -1, 7, 8 }) == 23;

            bool r = s.MaxSubArray(new int[] { -2, -1 }) == -1;
        }

        public class Solution
        {
            //https://leetcode.com/problems/maximum-subarray
            public int MaxSubArray(int[] nums)
            {
                //https://leetcode.com/problems/maximum-subarray/discuss/20193/DP-solution-and-some-thoughts
                int max = nums[0];
                int[] sums = new int[nums.Length];
                sums[0] = nums[0];

                for (int i = 0; i < nums.Length; i++)
                {
                    if (i > 0)
                    {
                        sums[i] = nums[i] + sums[i - 1];
                        if (sums[i] > max)
                        {
                            max = sums[i];
                        }
                    }

                    if (sums[i] < 0) sums[i] = 0;
                }


                return max;

            }

            public int MaxSubArray2(int[] nums)
            {
                // brute-force        
                int max = nums[0];

                for (int i = 0; i < nums.Length; i++)
                {
                    int sum = nums[i];
                    if (sum > max)
                    {
                        max = sum;
                    }
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        sum += nums[j];
                        if (sum > max)
                        {
                            max = sum;
                        }
                    }
                }

                return max;

            }

        }
    }
}
