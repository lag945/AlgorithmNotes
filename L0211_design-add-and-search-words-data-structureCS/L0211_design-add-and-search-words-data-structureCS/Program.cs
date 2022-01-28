using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0211_design_add_and_search_words_data_structureCS
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDictionary wordDictionary = new WordDictionary();
            wordDictionary.AddWord("bad");
            wordDictionary.AddWord("dad");
            wordDictionary.AddWord("mad");
            bool r1 = wordDictionary.Search("pad") == false; // return False
            bool r2 = wordDictionary.Search("bad") == true; // return True
            bool r3 = wordDictionary.Search(".ad") == true; // return True
            bool r4 = wordDictionary.Search("b..") == true; // return True
        }

        public class WordDictionary
        {

            class TrieNode
            {
                private Dictionary<char, TrieNode> m_Links = new Dictionary<char, TrieNode>();

                private bool m_IsEnd;

                public TrieNode()
                {
                    m_Links = new Dictionary<char, TrieNode>();
                }

                public bool HasKey()
                {
                    return (m_Links.Count > 0);
                }

                public bool ContainsKey(char ch)
                {
                    return (m_Links.ContainsKey(ch));
                }
                public TrieNode Get(char ch)
                {
                    return (m_Links.ContainsKey(ch) ? m_Links[ch] : null);
                }

                public List<TrieNode> Get()
                {
                    return m_Links.Values.ToList();
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


            public WordDictionary()
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

            public void AddWord(string word)
            {
                Insert(word);
            }

            public bool Search(string word)
            {
                return Dfs(word, 0, m_Root);
            }

            private bool Dfs(string word, int index, TrieNode node)
            {
                if (node == null)
                    return false;

                char ch = word[index];

                if (index == word.Length - 1)
                {
                    if (ch == '.')
                    {
                        foreach (TrieNode n in node.Get())
                        {
                            if (n.IsEnd())
                                return true;
                        }
                        return false;
                    }
                    else
                    {
                        TrieNode n = node.Get(ch);
                        if (n != null)
                        {
                            return n.IsEnd();
                        }
                    }
                }
                else
                {
                    if (ch == '.')
                    {
                        foreach (TrieNode n in node.Get())
                        {
                            if (Dfs(word, index + 1, n))
                                return true;
                        }
                    }
                    else
                    {
                        TrieNode n = node.Get(ch);
                        if (n != null)
                        {
                            if (Dfs(word, index+1, n))
                                return true;
                        }
                    }
                }

                return false;
            }

        }

        /**
         * Your WordDictionary object will be instantiated and called as such:
         * WordDictionary obj = new WordDictionary();
         * obj.AddWord(word);
         * bool param_2 = obj.Search(word);
         */
    }
}
