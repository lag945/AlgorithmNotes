using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0763_partition_labelsCS
{
    class Program
    {

        //https://leetcode.com/problems/partition-labels/
        static void Main(string[] args)
        {
            Solution s = new Solution();
            s.PartitionLabels("ababcbacadefegdehijhklij");//9,7,8
            s.PartitionLabels("eccbbbbdec");//10
        }

        public class Solution
        {
            public IList<int> PartitionLabels(string s)
            {
                int[] last = new int[26];
                for (int i = 0; i < s.Length; ++i)
                    last[s[i] - 'a'] = i;

                int j = 0, anchor = 0;
                List<int> ans = new List<int>();
                for (int i = 0; i < s.Length; ++i)
                {
                    j = Math.Max(j, last[s[i] - 'a']);
                    if (i == j)
                    {
                        ans.Add(i - anchor + 1);
                        anchor = i + 1;
                    }
                }
                return ans;
            }

            public IList<int> PartitionLabels2(string s)
            {
                List<int> ret = new List<int>();
                int[] count = new int[26];

                for (int i = 0; i < s.Length; i++)
                {
                    count[s[i] - 'a']++;
                }


                int c = 0;
                Dictionary<int, int> map = new Dictionary<int, int>();
                for (int i = 0; i < s.Length; i++)
                {
                    c++;
                    int index = s[i] - 'a';
                    if (map.ContainsKey(index))
                    {
                        map[index]--;
                    }
                    else
                    {
                        map[index] = count[index] - 1;
                    }
                    if (map[index] == 0)
                    {
                        map.Remove(index);
                    }

                    if (map.Count == 0)
                    {
                        ret.Add(c);
                        c = 0;
                    }

                }

                return ret.ToArray();
            }
        }
    }
}
