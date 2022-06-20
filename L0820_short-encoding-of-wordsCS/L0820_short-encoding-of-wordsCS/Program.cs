using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0820_short_encoding_of_wordsCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();

            string[] words = new string[] { "time", "time", "time", "time" };
            bool r = s.MinimumLengthEncoding(words) == 5;
        }

        public class Solution
        {

            public class TrieNode
            {
                public int depth = 0;
                public char val = char.MinValue;
                public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
            }

            public int MinimumLengthEncoding(string[] words)
            {
                int ret = 0;
                HashSet<TrieNode> leaves = new HashSet<TrieNode>();
                TrieNode root = new TrieNode();
                //reverse for rull
                for (int i = 0; i < words.Length; i++)
                {
                    string w = words[i];
                    TrieNode node = null;
                    if (root.children.ContainsKey(w[w.Length - 1]))
                        node = root.children[w[w.Length - 1]];
                    else
                    {
                        node = new TrieNode();
                        node.val = w[w.Length-1];
                        node.depth = 1;
                        root.children.Add(node.val, node);
                        leaves.Add(node);
                    }
                    //T:(n*m)
                    for (int j = w.Length - 2; j >=0; j--)
                    {
                        if (node.children.ContainsKey(w[j]))
                            node = node.children[w[j]];
                        else
                        {
                            var _node = new TrieNode();
                            _node.val = w[j];
                            _node.depth = node.depth+1;
                            node.children.Add(_node.val, _node);
                            leaves.Add(_node);
                            leaves.Remove(node);
                            node = _node;
                        }
                    }
                }

                foreach (var leaf in leaves)
                {
                    ret += leaf.depth + 1;
                }

                return ret;
            }

            public int MinimumLengthEncoding2(string[] words)
            {
                int ret = 0;
                //t: O(nlogn)
                Array.Sort(words, (x, y) => y.Length - x.Length);

                HashSet<string> map = new HashSet<string>();
                for (int i = 0; i < words.Length; i++)
                {
                    string w = words[i];
                    if (map.Add(w))
                    {
                        ret += w.Length + 1;
                        //t:O(n*m)
                        while (w.Length > 0)
                        {
                            map.Add(w);
                            w = w.Remove(0, 1);
                        }

                    }
                }

                return ret;
            }
        }
    }
}
