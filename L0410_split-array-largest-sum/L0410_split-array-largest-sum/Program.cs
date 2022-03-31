using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0410_split_array_largest_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            bool r = s.SplitArray(new int[] { 7, 2, 5, 10, 8 }, 2) == 18;
        }
        //https://leetcode.com/problems/split-array-largest-sum/

        public class Solution
        {
            private int minimumSubarraysRequired(int[] nums, int maxSumAllowed)
            {
                int currentSum = 0;
                int splitsRequired = 0;

                foreach (int element in nums)
                {
                    // Add element only if the sum doesn't exceed maxSumAllowed
                    if (currentSum + element <= maxSumAllowed)
                    {
                        currentSum += element;
                    }
                    else
                    {
                        // If the element addition makes sum more than maxSumAllowed
                        // Increment the splits required and reset sum
                        currentSum = element;
                        splitsRequired++;
                    }
                }

                // Return the number of subarrays, which is the number of splits + 1
                return splitsRequired + 1;
            }

            public int SplitArray(int[] nums, int m)
            {
                // Find the sum of all elements and the maximum element
                int sum = 0;
                int maxElement = Int32.MinValue;
                foreach (int element in nums)
                {
                    sum += element;
                    maxElement = Math.Max(maxElement, element);
                }

                // Define the left and right boundary of binary search
                int left = maxElement;
                int right = sum;
                int minimumLargestSplitSum = 0;
                while (left <= right)
                {
                    // Find the mid value
                    int maxSumAllowed = left + (right - left) / 2;

                    // Find the minimum splits. If splitsRequired is less than
                    // or equal to m move towards left i.e., smaller values
                    if (minimumSubarraysRequired(nums, maxSumAllowed) <= m)
                    {
                        right = maxSumAllowed - 1;
                        minimumLargestSplitSum = maxSumAllowed;
                    }
                    else
                    {
                        // Move towards right if splitsRequired is more than m
                        left = maxSumAllowed + 1;
                    }
                }

                return minimumLargestSplitSum;
            }


            // Defined it as per the maximum size of array and split count
            // But can be defined with the input size as well
            int[,] memo = new int[1001, 51];
            public int SplitArray3(int[] nums, int m)
            {
                // Store the prefix sum of nums array.
                int n = nums.Length;
                int[] prefixSum = new int[n + 1];

                for (int i = 0; i < n; i++)
                {
                    prefixSum[i + 1] = prefixSum[i] + nums[i];
                }

                return getMinimumLargestSplitSum(prefixSum, 0, m);
            }

            private int getMinimumLargestSplitSum(int[] prefixSum, int currIndex, int subarrayCount)
            {
                int n = prefixSum.Length - 1;

                // We have already calculated the answer so no need to go into recursion
                if (memo[currIndex, subarrayCount] != 0)
                {
                    return memo[currIndex, subarrayCount];
                }

                // Base Case: If there is only one subarray left, then all of the remaining numbers
                // must go in the current subarray. So return the sum of the remaining numbers.
                if (subarrayCount == 1)
                {
                    return memo[currIndex, subarrayCount] = prefixSum[n] - prefixSum[currIndex];
                }

                // Otherwise, use the recurrence relation to determine the minimum largest subarray
                // sum between currIndex and the end of the array with subarrayCount subarrays remaining.
                int minimumLargestSplitSum = Int32.MaxValue;
                for (int i = currIndex; i <= n - subarrayCount; i++)
                {
                    // Store the sum of the first subarray.
                    int firstSplitSum = prefixSum[i + 1] - prefixSum[currIndex];

                    // Find the maximum subarray sum for the current first split.
                    int largestSplitSum = Math.Max(firstSplitSum,
                                              getMinimumLargestSplitSum(prefixSum, i + 1, subarrayCount - 1));

                    // Find the minimum among all possible combinations.
                    minimumLargestSplitSum = Math.Min(minimumLargestSplitSum, largestSplitSum);

                    if (firstSplitSum >= minimumLargestSplitSum)
                    {
                        break;
                    }
                }

                memo[currIndex, subarrayCount] = minimumLargestSplitSum;
                return memo[currIndex, subarrayCount];
            }

            public int SplitArray2(int[] nums, int m)
            {
                int ret = -1;
                List<int> groups = new List<int>(m);
                int[] sums = new int[nums.Length];
                for (int i = 0; i < nums.Length; i++)
                {
                    sums[i] = nums[i];
                    if (i > 0)
                        sums[i] += sums[i - 1];
                }
                Split(nums, m, groups, 0, 0, ref ret, sums);
                return ret;
            }

            private void Split(int[] nums, int m, List<int> groups, int index, int max, ref int min, int[] sums)
            {
                if (index >= nums.Length || groups.Count >= m)
                {
                    if (index == nums.Length && groups.Count == m)
                    {
                        if (min < 0)
                            min = max;
                        else
                            min = Math.Min(min, max);
                    }
                    return;
                }

                for (int i = 1; i <= nums.Length - index; i++)
                {
                    if ((groups.Count + nums.Length - index) < m)//not enough groups
                        break;
                    int _max = max;//temp max
                    int sum = 0;
                    /*
                    for(int j=index;j<index+i;j++)
                    {
                        sum+=nums[j];
                    }
                    */
                    if (index + i - 1 >= nums.Length)
                        break;
                    sum = sums[index + i - 1];
                    if (index > 0)
                    {
                        sum -= sums[index - 1];
                    }

                    max = Math.Max(max, sum);
                    if (min <= 0 || max < min)//pass to big result
                    {
                        groups.Add(sum);
                        Split(nums, m, groups, index + i, max, ref min, sums);
                        groups.RemoveAt(groups.Count - 1);
                    }
                    max = _max;
                }
            }
        }

    }
}
