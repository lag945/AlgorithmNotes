using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0088_Merge_Sorted_ArrayCS
{
    class Program
    {
        //https://leetcode.com/problems/merge-sorted-array/
        static void Main(string[] args)
        {
            Solution s = new Solution();
            s.Merge(new int[] {  0 }, 0, new int[] { 1 }, 1);
            //s.Merge(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3);
        }

        public class Solution
        {
            public void Merge(int[] nums1, int m, int[] nums2, int n)
            {
                int i = m - 1;
                int j = n - 1;
                int current = nums1.Length - 1;

                while (current >= 0)
                {
                    if (i<0)
                    {
                        nums1[current] = nums2[j];
                        j--;
                    }
                    else if (j < 0)
                    {
                        nums1[current] = nums1[i];
                        i--;
                    }
                    else if (nums1[i] >= nums2[j] )
                    {
                        nums1[current] = nums1[i];
                        i--;
                    }
                    else
                    {
                        nums1[current] = nums2[j];
                        j--;
                    }
                    current--;
                }
            }
        }
        }
}
