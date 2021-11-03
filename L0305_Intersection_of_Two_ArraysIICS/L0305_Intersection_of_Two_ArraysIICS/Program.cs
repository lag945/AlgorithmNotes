using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0305_Intersection_of_Two_ArraysIICS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] ret = s.Intersect(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 });
        }

        public class Solution
        {
            public int[] Intersect(int[] nums1, int[] nums2)
            {
                int[] count1 = new int[1001];
                int[] count2 = new int[1001];

                for (int i = 0; i < nums1.Length; i++)
                {
                    count1[nums1[i]]++;
                }

                for (int i = 0; i < nums2.Length; i++)
                {
                    count2[nums2[i]]++;
                }

                List<int> ret = new List<int>(1001);

                for (int i = 0; i < count1.Length; i++)
                {
                    if (count1[i] > 0 && count2[i] > 0)
                    {
                        int intersection = Math.Min(count1[i], count2[i]);
                        for (int j = 0; j < intersection; j++)
                        {
                            ret.Add(i);
                        }
                    }
                }

                return ret.ToArray();

            }
        }
    }
}
