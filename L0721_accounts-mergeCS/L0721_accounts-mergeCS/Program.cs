using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0721_accounts_mergeCS
{
    class Program
    {
        //https://leetcode.com/problems/accounts-merge/submissions/
        static void Main(string[] args)
        {
            Solution s = new Solution();
            List<List<string>> accounts = new List<List<string>>();
            accounts.Add(new List<string>());
            accounts.Add(new List<string>());
            accounts.Add(new List<string>());
            accounts.Add(new List<string>());
            accounts[0].AddRange(new string[] { "John", "johnsmith@mail.com", "john_newyork@mail.com" });
            accounts[1].AddRange(new string[] { "John", "johnsmith@mail.com", "john00@mail.com" });           
            accounts[2].AddRange(new string[] { "Mary", "mary@mail.com" });
            accounts[3].AddRange(new string[] { "John", "johnnybravo@mail.com" });

            var ret = s.AccountsMerge(accounts.ToArray());
        }

        public class Solution
        {
            public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
            {
                List<List<string>> ret = new List<List<string>>();

                //create pair
                Dictionary<string, HashSet<string>> mailMap = new Dictionary<string, HashSet<string>>();
                foreach (List<string> account in accounts)
                {
                    string name = account[0];
                    string mainMail = account[1];
                    for (int i = 1; i < account.Count; i++)
                    {
                        string subMail = account[i];
                        if (!mailMap.ContainsKey(mainMail))
                            mailMap.Add(mainMail, new HashSet<string>());
                        mailMap[mainMail].Add(subMail);

                        if (!mailMap.ContainsKey(subMail))
                            mailMap.Add(subMail, new HashSet<string>());
                        mailMap[subMail].Add(mainMail);
                    }
                }

                foreach (List<string> account in accounts)
                {
                    string name = account[0];
                    string mail = account[1];
                    HashSet<string> mails = new HashSet<string>() ;
                    DFS(mail, mailMap, mails);
                    if (mails.Count > 0)
                    {
                        List<string>mergeMails = mails.ToList();
                        mergeMails.Sort(SortMail);
                        ret.Add(new List<string>());
                        ret[ret.Count - 1].Add(name);
                        ret[ret.Count - 1].AddRange(mergeMails);
                        //foreach (string m in mails)
                        //{
                        //    mailMap.Remove(m);
                        //}
                    }
                }

                return ret.ToArray();
            }

            private int SortMail(string a, string b)
            {
                if (a == b)
                    return 0;

                int ret = 1;
                if (a.Length < b.Length)
                {
                    ret = -1;
                }
                int len = Math.Min(a.Length, b.Length);
                for (int i = 0; i < len; i++)
                {
                    if (a[i] > b[i])
                    {
                        ret = 1;
                        break;
                    }
                    else if (a[i] < b[i])
                    {
                        ret = -1;
                        break;
                    }
                }
                return ret;
            }

            private void DFS(string mail, Dictionary<string, HashSet<string>> mailMap, HashSet<string> ret)
            {
                if (mailMap.ContainsKey(mail))
                {
                    foreach (string m in mailMap[mail])
                    {
                        if (!ret.Contains(m))
                        {
                            ret.Add(m);
                            DFS(m, mailMap, ret);
                        }
                    }
                    mailMap.Remove(mail);
                }
            }

        }
    }
}
