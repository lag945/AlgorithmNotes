using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0208_implement_trie_prefix_treeCS
{
    //https://leetcode.com/problems/implement-trie-prefix-tree/
    class Program
    {
        static void Main(string[] args)
        {
            Trie trie = new Trie();
            trie.Insert("apple");
            bool r1 = trie.Search("apple") == true;
            bool r2 = trie.Search("app") == false;
            bool r3 = trie.StartsWith("app") == true;
            trie.Insert("app");
            bool r4 = trie.Search("app") == true;
        }

        // supports multi-language version
        public class Trie
        {
            class TrieNode
            {
                private Dictionary<char, TrieNode> m_Links = new Dictionary<char, TrieNode>();

                private bool m_IsEnd;

                public TrieNode()
                {
                    m_Links = new Dictionary<char, TrieNode>();
                }

                public bool ContainsKey(char ch)
                {
                    return (m_Links.ContainsKey(ch));
                }
                public TrieNode Get(char ch)
                {
                    return (m_Links.ContainsKey(ch) ? m_Links[ch] : null);
                }
                public void Put(char ch, TrieNode node)
                {
                    m_Links[ch] = node;
                }
                public void SetEnd()
                {
                    m_IsEnd = true;
                }
                public bool IsEnd()
                {
                    return m_IsEnd;
                }
            }

            TrieNode m_Root = null;
            public Trie()
            {
                m_Root = new TrieNode();
            }

            public void Insert(string word)
            {
                if (word.Length == 0)
                    return;

                TrieNode node = m_Root;
                for (int i = 0; i < word.Length; i++)
                {
                    char ch = word[i];
                    if (node.ContainsKey(ch))
                    {
                    }
                    else
                    {
                        TrieNode newNode = new TrieNode();
                        node.Put(ch, newNode);
                    }
                    node = node.Get(ch);
                }

                node.SetEnd();

            }

            private TrieNode SearchNode(string word)
            {
                TrieNode node = m_Root;

                for (int i = 0; i < word.Length; i++)
                {
                    char ch = word[i];
                    if (node.ContainsKey(ch))
                    {
                        node = node.Get(ch);
                    }
                    else
                    {
                        return null;
                    }
                }

                return node;
            }

            public bool Search(string word)
            {
                TrieNode node = SearchNode(word);
                return (node == null ? false : node.IsEnd());
            }

            public bool StartsWith(string prefix)
            {
                TrieNode node = SearchNode(prefix);
                return (node != null);
            }
        }

        /**
         * Your Trie object will be instantiated and called as such:
         * Trie obj = new Trie();
         * obj.Insert(word);
         * bool param_2 = obj.Search(word);
         * bool param_3 = obj.StartsWith(prefix);
         */

        // pure dictionary version
        public class Trie2
        {

            Dictionary<string, int> m_Words = new Dictionary<string, int>();

            public Trie2()
            {

            }

            public void Insert(string word)
            {
                m_Words[word] = 1;
                for (int i = 1; i < word.Length; i++)
                {
                    string key = word.Substring(0, i);
                    if (!m_Words.ContainsKey(key))
                    {
                        m_Words[key] = 0;
                    }
                }
            }

            public bool Search(string word)
            {
                bool ret = false;
                if (m_Words.ContainsKey(word))
                {
                    ret = (m_Words[word] == 1);
                }
                return ret;
            }

            public bool StartsWith(string prefix)
            {
                return m_Words.ContainsKey(prefix);
            }
        }
    }
}
