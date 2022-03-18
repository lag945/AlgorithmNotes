using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1081_smallest_subsequence_of_distinct_charactersCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            bool r = s.SmallestSubsequence("bcbcbcababa") == "bca";
        }

        public class Solution
        {
            public string SmallestSubsequence(string s)
            {
                int[] times = new int[26];
                for (int i = 0; i < s.Length; i++)
                    times[s[i] - 'a']++;

                bool[] pass = new bool[26];
                List<char> list = new List<char>();

                for (int i = 0; i < s.Length; i++)
                {
                    int index = s[i] - 'a';
                    times[index]--;
                    if (pass[index])
                        continue;

                    //把比自己大後面還有的刪掉

                    while (list.Count > 0 && ((list[list.Count - 1] - s[i]) >= 0) && times[list[list.Count - 1] - 'a'] > 0)
                    {
                        pass[list[list.Count - 1] - 'a'] = false;
                        list.RemoveAt(list.Count - 1);//remove tail.
                    }


                    list.Add(s[i]);

                    pass[index] = true;
                }

                return new String(list.ToArray());
            }
        }
    }
}
