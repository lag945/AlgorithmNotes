using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0792_number_of_matching_subsequencesCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            bool r1 = s.NumMatchingSubseq("abcde", new string[] { "a", "bb", "acd", "ace" }) == 3;
            bool r2 = s.NumMatchingSubseq("dsahjpjauf", new string[] { "ahjpjau", "ja", "ahbwzgqnuk", "tnmlanowax" }) == 2;
        }

        public class Solution
        {
            
            private bool IsSubsequence(string s, ref string t)
            {
                if (s.Length > t.Length)
                {
                    return false;
                }

                if (s.Length == 0)
                {
                    return true;
                }

                int i = 0;
                int j = 0;

                while (true)
                {
                    if (i == s.Length)
                    {
                        return true;
                    }

                    if (j == t.Length)
                    {
                        return false;
                    }

                    if (s[i] == t[j])
                    {
                        i++;
                        j++;
                        continue;
                    }

                    j++;
                }
            }

            public int NumMatchingSubseq(string s, string[] words)
            {
                int res = 0;
                IDictionary<string, int> word2Count = new Dictionary<string, int>();
                foreach (var word in words)
                {
                    if (!word2Count.ContainsKey(word))
                    {
                        word2Count[word] = 0;
                    }

                    word2Count[word]++;
                }

                foreach (var w2c in word2Count)
                {
                    if (IsSubsequence(w2c.Key, ref s))
                    {
                        res += w2c.Value;
                    }
                }
                return res;
            }

            //Trie: too slow
            #region Trie
            public class Trie
            {
                public char val = 'a';
                public Trie(char c)
                {
                    val = c;
                }
                public Dictionary<char, Trie> children = new Dictionary<char, Trie>();
            }

            Trie[] list = new Trie[26];

            public int NumMatchingSubseq2(string s, string[] words)
            {
                int ret = 0;

                for (int i = 0; i < s.Length; i++)
                {
                    if (list[s[i] - 'a'] == null)
                        list[s[i] - 'a'] = new Trie(s[i]);
                    Visit(list[s[i] - 'a'], i, ref s);
                }


                for (int i = 0; i < words.Length; i++)
                {
                    if (list[words[i][0] - 'a'] != null)
                    {
                        if (Check(list[words[i][0] - 'a'], 1, ref words[i]))
                            ret++;
                    }
                }


                return ret;
            }

            private void Visit(Trie node, int index, ref string s)
            {
                for (int i = index + 1; i < s.Length; i++)
                {
                    if (!node.children.ContainsKey(s[i]))
                    {
                        node.children[s[i]] = new Trie(s[i]);
                    }
                    Visit(node.children[s[i]], i, ref s);
                }

            }

            private bool Check(Trie node, int index, ref string s)
            {
                if (index >= s.Length)
                    return true;

                if (node == null)
                    return false;
                if (node.children.ContainsKey(s[index]))
                {
                    return Check(node.children[s[index]], ++index, ref s);
                }
                else
                {
                    return false;
                }
            }
            #endregion Trie
        }
    }
}
