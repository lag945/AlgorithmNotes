using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0287_find_the_duplicate_numberCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            bool r = s.FindDuplicate2(new int[] { 3, 1, 3, 4, 2 }) == 3;
        }
        //https://leetcode.com/problems/find-the-duplicate-number/solution/
        public class Solution
        {
            //Approach 6: Sum of Set Bits
            // wrong version
            public int FindDuplicate2(int[] nums)
            {
                int max = 1;
                //2^17 = 131,072 > 100,000
                int[] sum = new int[32];

                for (int i = 0; i < nums.Length; i++)
                {
                    max = Math.Max(max, nums[i]);
                    BitArray ba = new BitArray(BitConverter.GetBytes(nums[i]));
                    for (int j = 0; j < 32; j++)
                        sum[j] += ba[j] ? 1 : 0;
                }

                for (int i = 1; i < nums.Length; i++)
                {
                    BitArray ba = new BitArray(BitConverter.GetBytes(i));
                    for (int j = 0; j < 32; j++)
                        sum[j] -= ba[j] ? 1 : 0;
                }

                int ret = 0;

                for (int i = 0; i < 32; i++)
                {
                    ret += sum[i] * (int)Math.Pow(2, i);
                }

                return ret;
            }

            //Approach 7: Floyd's Tortoise and Hare (Cycle Detection)
            public int FindDuplicate(int[] nums)
            {
                // Find the intersection point of the two runners.
                int tortoise = nums[0];
                int hare = nums[0];

                do
                {
                    tortoise = nums[tortoise];
                    hare = nums[nums[hare]];
                } while (tortoise != hare);

                // Find the "entrance" to the cycle.
                tortoise = nums[0];

                while (tortoise != hare)
                {
                    tortoise = nums[tortoise];
                    hare = nums[hare];
                }

                return hare;

            }
        }
    }
}
