using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0169_Majority_ElementCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int ret = s.MajorityElement(new int[] { 2, 2,  4, 2, 5 });//must more than half
            ret = s.MajorityElement2(new int[] { 2, 2, 1, 3, 4, 2, 5 });//no need more than half
        }

        public class Solution
        {
            public int MajorityElement(int[] nums)
            {
                int major = 0, count = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (count == 0)
                    {
                        count++;
                        major = nums[i];
                    }
                    else if (major == nums[i])
                    {
                        count++;
                    }
                    else count--;

                }
                return major;

            }

            public int MajorityElement2(int[] nums)
            {
                Dictionary<int, int> maps = new Dictionary<int, int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    if (maps.ContainsKey(nums[i]))
                    {
                        maps[nums[i]]++;
                    }
                    else
                    {
                        maps[nums[i]] = 1;
                    }
                }

                int max = 0;
                int ret = 0;

                foreach (int key in maps.Keys)
                {
                    if (maps[key] > max)
                    {
                        max = maps[key];
                        ret = key;
                    }
                }

                return ret;

            }
        }
    }
}
