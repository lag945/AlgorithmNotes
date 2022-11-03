using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0433_minimum_genetic_mutationCS
{
    class Program
    {
        //https://leetcode.com/problems/minimum-genetic-mutation/
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var r1 = s.MinMutation("AACCGGTT", "AAACGGTA", new string[] { "AACCGGTA", "AACCGCTA", "AAACGGTA" }) == 2;
        }

        public class Solution
        {
            int ret = -1;
            public int MinMutation(string start, string end, string[] bank)
            {

                var bankSet = new HashSet<string>();
                foreach (string s in bank)
                    bankSet.Add(s);

                if (!bankSet.Contains(end))
                    return ret;

                if (start == end)
                    ret = 0;
                else
                {
                    Mutation(0, start.ToCharArray(), end, bankSet);
                }

                return ret;
            }

            private void Mutation(int count, char[] start, string end, HashSet<string> bankSet)
            {
                string cur = new String(start);
                if (cur == end)
                {
                    if (ret == -1 || count < ret)
                        ret = count;
                    return;
                }

                if (ret != -1 && count >= ret)
                    return;

                for (int i = 0; i < 8; i++)
                {
                    char temp = start[i];
                    start[i] = 'A';
                    cur = new string(start);
                    if (bankSet.Remove(cur))
                    {
                        Mutation(count + (temp == 'A' ? 0 : 1), start, end, bankSet);
                        bankSet.Add(cur);
                    }
                    start[i] = 'C';
                    cur = new string(start);
                    if (bankSet.Remove(cur))
                    {
                        Mutation(count + (temp == 'C' ? 0 : 1), start, end, bankSet);
                        bankSet.Add(cur);
                    }
                    start[i] = 'G';
                    cur = new string(start);
                    if (bankSet.Remove(cur))
                    {
                        Mutation(count + (temp == 'G' ? 0 : 1), start, end, bankSet);
                        bankSet.Add(cur);
                    }
                    start[i] = 'T';
                    cur = new string(start);
                    if (bankSet.Remove(cur))
                    {
                        Mutation(count + (temp == 'T' ? 0 : 1), start, end, bankSet);
                        bankSet.Add(cur);
                    }

                    start[i] = temp;
                }

            }
        }
    }
}
