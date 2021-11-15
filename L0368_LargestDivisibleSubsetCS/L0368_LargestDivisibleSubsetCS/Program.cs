using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0368_LargestDivisibleSubsetCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            IList<int> ret = s.LargestDivisibleSubset2(new int[] { 5, 9, 18, 54, 108, 540, 90, 180, 360, 720 }); ;
            ret = s.LargestDivisibleSubset(new int[] { 1, 2, 3 });
            ret = s.LargestDivisibleSubset(new int[] { 3,4,16,8 });

        }

        public class Solution
        {

            public IList<int> LargestDivisibleSubset(int[] nums)
            {
                //https://leetcode.com/problems/largest-divisible-subset/discuss/602045/C-faster-than-97.14-less-than-100-Mem-O(n2)
                if (nums.Length == 0) { return new List<int>(); }
                Array.Sort(nums);

                List<int>[] dp = new List<int>[nums.Length];

                dp[0] = new List<int>() { nums[0] };

                List<int> crnt;
                int crntMaxIndex;
                int globalIndex = 0;

                for (int i = 1; i < nums.Length; i++)
                {
                    crnt = null;
                    crntMaxIndex = -1;
                    for (int j = 0; j < i; j++)
                    {
                        if (nums[i] % nums[j] == 0)
                        {
                            if (crntMaxIndex == -1 || crnt.Count < dp[j].Count)
                            {
                                crnt = dp[j];
                                crntMaxIndex = j;
                            }
                        }
                    }

                    if (crntMaxIndex == -1)
                    {
                        dp[i] = new List<int>() { nums[i] };
                    }
                    else
                    {
                        dp[i] = dp[crntMaxIndex].ToList();
                        dp[i].Add(nums[i]);
                    }

                    if (dp[i].Count > dp[globalIndex].Count) { globalIndex = i; }
                }

                return dp[globalIndex];
            }

            // wrong
            public IList<int> LargestDivisibleSubset2(int[] nums)
            {
                //T:O(nlogn)
                Array.Sort(nums);
                //list all, S:O(n^2)
                List<List<int>> result = new List<List<int>>();
                int max = 0;
                int maxIndex = -1;
                //T:O(n^2)
                for (int i = 0; i < nums.Length; i++)
                {
                    if (result.Count == 0)
                    {
                        List<int> list = new List<int>();
                        list.Add(nums[i]);
                        result.Add(list);
                        max = list.Count;
                        maxIndex = 0;
                        continue;
                    }

                    int _max = 0;
                    int _idx = -1;
                    for (int j = 0; j < i; j++)
                    {
                        if (nums[i] % nums[j] == 0)
                        {
                            if (result[j].Count > _max)
                            {
                                _max = result[j].Count;
                                _idx = j;
                            }
                        }
                    }

                    if (_idx >= 0)
                    {
                        result.Add(result[_idx].ToList());
                        result[i].Add(nums[i]);
                        if (result[i].Count > max)
                        {
                            max = result[i].Count;
                            maxIndex = i;
                        }
                    }
                    else
                    {
                        List<int> list = new List<int>();
                        list.Add(nums[i]);
                        result.Add(list);
                    }
                }

                return (maxIndex>=0?result[maxIndex]:null);
                
            }
        }

    }
}
