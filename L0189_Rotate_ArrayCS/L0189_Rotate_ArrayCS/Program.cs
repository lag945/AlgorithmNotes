using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0189_Rotate_ArrayCS
{
    //https://leetcode.com/problems/rotate-array/
    //https://leetcode.com/problems/rotate-array/discuss/54250/Easy-to-read-Java-solution
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int k = 3;
            Solution s = new Solution();
            s.RotateV3(nums,k);
        }

        public class Solution
        {
            public void Rotate(int[] nums, int k)
            {
                RotateV3(nums, k);
            }

            public void RotateV1(int[] nums, int k)
            {
                //T:O((n+n)*k)=O(2kn)=O(kn)=worth=(n^2)
                //S:O(n)
                int n = nums.Length;
                List<int> list = new List<int>(nums);
                //O((n+n)*k)=O(2kn)=O(kn)=worth=(n^2)
                for (int i = 0; i < k; i++)
                {
                    int temp = list[n - 1];
                    list.RemoveAt(n - 1);//O(n)
                    list.Insert(0, temp);//O(n)
                }
                for (int i = 0; i < n; i++)
                {
                    nums[i] = list[i];
                }
            }

            public void RotateV2(int[] nums, int k)
            {
                if (nums.Length <= 1 || k == 0 || nums.Length == k)
                {
                    return;
                }

                var copy = new int[nums.Length];
                // index of the element that will be first in the rotated array
                int offset = nums.Length - (k % nums.Length);

                // loop through the new array and copy elements in the correct order
                for (int i = 0; i < nums.Length; i++)
                {
                    copy[i] = nums[offset];
                    if (offset == nums.Length - 1)
                    {
                        offset = 0;
                    }
                    else
                    {
                        offset++;
                    }
                }

                // copy back to original array
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i] = copy[i];
                }
            }

            public void RotateV3(int[] nums, int k)
            {
                //S:O(1)
                k %= nums.Length;
                reverse(nums, 0, nums.Length - 1);
                reverse(nums, 0, k - 1);
                reverse(nums, k, nums.Length - 1);
            }

            public void reverse(int[] nums, int start, int end)
            {
                while (start < end)
                {
                    int temp = nums[start];
                    nums[start] = nums[end];
                    nums[end] = temp;
                    start++;
                    end--;
                }
            }

        }

    }
}
