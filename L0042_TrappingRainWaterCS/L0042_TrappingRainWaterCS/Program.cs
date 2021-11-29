using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0042_TrappingRainWaterCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();

            int ret = s.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
            ret = s.Trap(new int[] { 4, 2, 0, 3, 2, 5 });
        }

        public class Solution
        {
            //https://leetcode.com/problems/trapping-rain-water/solution/
            public int Trap(int[] height)
            {
                //Approach 2: Dynamic Programming
                if (height.Length==0)
                    return 0;
                int ans = 0;
                int size = height.Length;
                int [] left_max = new int[size];
                int[] right_max = new int[size];
                left_max[0] = height[0];
                for (int i = 1; i < size; i++)
                {
                    left_max[i] = Math.Max(height[i], left_max[i - 1]);
                }
                right_max[size - 1] = height[size - 1];
                for (int i = size - 2; i >= 0; i--)
                {
                    right_max[i] = Math.Max(height[i], right_max[i + 1]);
                }
                for (int i = 1; i < size - 1; i++)
                {
                    ans += Math.Min(left_max[i], right_max[i]) - height[i];
                }
                return ans;

            }
            public int Trap2(int[] height)
            {
                //Approach 1: Brute force
                int[] water = new int[height.Length];

                for (int i = 0; i < height.Length; i++)
                {
                    int left = height[i];
                    int right = height[i];

                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (height[j] > left)
                        {
                            left = height[j];
                        }
                    }

                    for (int j = i + 1; j < height.Length; j++)
                    {
                        if (height[j] > right)
                        {
                            right = height[j];
                        }
                    }

                    water[i] = Math.Min(left, right) - height[i];
                }


                return water.Sum();

            }

            //Approach 4: Using 2 pointers
            public int Trap3(int[] height)
            {
                int left = 0, right = height.Length - 1;
                int ans = 0;
                int left_max = 0, right_max = 0;
                while (left < right)
                {
                    if (height[left] < height[right])
                    {
                        if (height[left] >= left_max)
                            left_max = height[left];
                        else 
                            ans += (left_max - height[left]);
                        ++left;
                    }
                    else
                    {
                        if (height[right] >= right_max)
                            right_max = height[right];
                        else
                            ans += (right_max - height[right]);
                        --right;
                    }
                }
                return ans;

            }


        }
    }
}
