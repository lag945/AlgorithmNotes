using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0540_SingleElement_in_a_SortedArrayCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int ret = s.SingleNonDuplicate(new int[] { 1, 1, 2 });
            ret = s.SingleNonDuplicate(new int[] { 1 });
            ret = s.SingleNonDuplicate(new int[] { 1, 1, 2, 3, 3, 4, 4, 8, 8 });
            ret = s.SingleNonDuplicate(new int[] { 3, 3, 7, 7, 10, 11, 11 });
            ret = s.SingleNonDuplicate(new int[] { 1, 1, 2, 3, 3 });
        }

        public class Solution
        {
            public int SingleNonDuplicate(int[] nums)
            {
                int start = 0, end = nums.Length - 1;

                while (start < end)
                {
                    // We want the first element of the middle pair,
                    // which should be at an even index if the left part is sorted.
                    // Example:
                    // Index: 0 1 2 3 4 5 6
                    // Array: 1 1 3 3 4 8 8
                    //            ^
                    int mid = (start + end) / 2;
                    if (mid % 2 == 1) mid--;

                    // We didn't find a pair. The single element must be on the left.
                    // (pipes mean start & end)
                    // Example: |0 1 1 3 3 6 6|
                    //               ^ ^
                    // Next:    |0 1 1|3 3 6 6
                    if (nums[mid] != nums[mid + 1]) end = mid;

                    // We found a pair. The single element must be on the right.
                    // Example: |1 1 3 3 5 6 6|
                    //               ^ ^
                    // Next:     1 1 3 3|5 6 6|
                    else start = mid + 2;
                }

                // 'start' should always be at the beginning of a pair.
                // When 'start > end', start must be the single element.
                return nums[start];

            }
            public int SingleNonDuplicate2(int[] nums)
            {
                if (nums.Length == 1)
                    return nums[0];
                //nums.Length must be odd
                return FindSingle(nums, 0, nums.Length - 1);
            }

            private int FindSingle(int[] nums, int left, int right)
            {
                int mid = (left + right) / 2;

                if (left >= right)
                {
                    if (left % 2 == 0)
                    {
                        if (left == nums.Length - 1)
                            return nums[left];

                        if (nums[left] == nums[left + 1])
                            return nums[left - 1];
                        else
                            return nums[left];
                    }
                    else
                    {
                        if (left == 0)
                            return nums[left];

                        if (nums[left] == nums[left - 1])
                            return nums[left + 1];
                        else
                            return nums[left];
                    }
                }

                if (mid % 2 == 0)//index 0 2 4 : odd
                {
                    if (nums[mid] == nums[mid + 1])
                    {
                        return FindSingle(nums, mid + 1, right);
                    }
                    else
                    {
                        return FindSingle(nums, left, mid - 1);
                    }
                }
                else
                {
                    if (nums[mid] == nums[mid - 1])
                    {
                        return FindSingle(nums, mid + 1, right);
                    }
                    else
                    {
                        return FindSingle(nums, left, mid - 1);
                    }
                }

                return nums[mid];
            }
        }


    }
}
