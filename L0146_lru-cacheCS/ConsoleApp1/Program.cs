using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        //https://leetcode.com/problems/lru-cache/
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            /*
            LRUCache lru = new LRUCache(2);
            lru.Put(1, 1);
            lru.Put(2, 2);
            bool r = lru.Get(1) == 1;
            lru.Put(3, 3);
            r = lru.Get(2) == -1;
            */

            /*
            LRUCache lru = new LRUCache(2);
            lru.Put(2, 1);
            lru.Put(2, 2);
            bool r = lru.Get(2) == 2;
            */

            string[] lines = File.ReadAllLines("testcase.txt");

            string[] commands = lines[0].Split(',');
            string[] values = lines[1].Split(']');

            int len = commands.Length;
            for (int i = 0; i < commands.Length; i++)
            {
                commands[i] = commands[i].Replace("\"", "").Replace("[", "").Replace("]", "");
            }

            List<List<int>> valueList = new List<List<int>>(len);
            for (int i = 0; i < len; i++)
            {
                values[i] = values[i].Replace("\"", "").Replace("[[", "").Replace(",[", "").Replace("]", "");
                List<int> l = new List<int>();
                if (commands[i] == "LRUCache")
                {
                    l.Add(Convert.ToInt32(values[i]));
                }
                else if (commands[i] == "get")
                {
                    l.Add(Convert.ToInt32(values[i]));
                }
                else if (commands[i] == "put")
                {
                    string[] s = values[i].Split(',');
                    l.Add(Convert.ToInt32(s[0]));
                    l.Add(Convert.ToInt32(s[1]));
                }

                valueList.Add(l);

            }

            Console.WriteLine(commands[0]);
            Console.WriteLine(commands[1]);
            Console.WriteLine(commands[len - 2]);
            Console.WriteLine(commands[len - 1]);
            Console.WriteLine(values[0]);
            Console.WriteLine(values[1]);
            Console.WriteLine(values[len - 2]);
            Console.WriteLine(values[len - 1]);

            Stopwatch sw = new Stopwatch();
            sw.Restart();

            LRUCache lru1 = null;
            for (int i = 0; i < len; i++)
            {
                if (commands[i] == "put")
                {
                    lru1.Put(valueList[i][0], valueList[i][1]);
                }
                else if (commands[i] == "get")
                {
                    lru1.Get(valueList[i][0]);
                }
                else if (commands[i] == "LRUCache")
                {
                    lru1 = new LRUCache(valueList[i][0]);
                }
            }

            sw.Stop();
            Console.WriteLine("lru1:" + sw.Elapsed.TotalSeconds.ToString("0.00"));

            sw.Restart();

            LRUCache2 lru2 = null;
            for (int i = 0; i < len; i++)
            {
                if (commands[i] == "put")
                {
                    lru2.Put(valueList[i][0], valueList[i][1]);
                }
                else if (commands[i] == "get")
                {
                    lru2.Get(valueList[i][0]);
                }
                else if (commands[i] == "LRUCache")
                {
                    lru2 = new LRUCache2(valueList[i][0]);
                }
            }

            sw.Stop();
            Console.WriteLine("lru2:" + sw.Elapsed.TotalSeconds.ToString("0.00"));

            sw.Restart();

            LRUCache3 lru3 = null;
            for (int i = 0; i < len; i++)
            {
                if (commands[i] == "put")
                {
                    lru3.Put(valueList[i][0], valueList[i][1]);
                }
                else if (commands[i] == "get")
                {
                    lru3.Get(valueList[i][0]);
                }
                else if (commands[i] == "LRUCache")
                {
                    lru3 = new LRUCache3(valueList[i][0]);
                }
            }

            sw.Stop();
            Console.WriteLine("lru3:" + sw.Elapsed.TotalSeconds.ToString("0.00"));

            for (int i = 0; i < len; i++)
            {
                if (commands[i] == "put")
                {
                    lru1.Put(valueList[i][0], valueList[i][1]);
                    lru3.Put(valueList[i][0], valueList[i][1]);
                }
                else if (commands[i] == "get")
                {
                    if (lru1.Get(valueList[i][0]) != lru3.Get(valueList[i][0]))
                    {
                        Console.WriteLine("wrong");
                    }
                }
            }
        }

        // Status: Time Limit Exceeded  and I don't know why?
        // https://docs.microsoft.com/zh-tw/dotnet/api/system.collections.generic.linkedlist-1.remove?view=net-6.0
        // because Remove(LinkedListNode<T>) = O(1),Remove(T)=O(N)
        public class LRUCache
        {
            private Dictionary<int, LinkedListNode<int>> m_KeyMap = null;
            private Dictionary<int, int> m_KVMap = null;
            private LinkedList<int> m_List = null;
            private readonly int m_capacity;

            public LRUCache(int capacity)
            {
                m_KeyMap = new Dictionary<int, LinkedListNode<int>>(capacity);
                m_KVMap = new Dictionary<int, int>(capacity);
                m_List = new LinkedList<int>();
                m_capacity = capacity;
            }

            public int Get(int key)
            {
                if (m_KVMap.ContainsKey(key))
                {
                    m_List.Remove(m_KeyMap[key]);//O(1)
                    var node = m_List.AddLast(key);//O(1)
                    m_KeyMap[key] = node;
                    return m_KVMap[key];
                }
                else
                {
                    return -1;
                }
            }

            public void Put(int key, int value)
            {
                if (m_KVMap.ContainsKey(key))
                {
                    m_KVMap[key] = value;//O(1)
                    m_List.Remove(m_KeyMap[key]);//O(1)
                    var node = m_List.AddLast(key);//O(1)
                    m_KeyMap[key] = node;
                }
                else
                {
                    if (m_List.Count == m_capacity)//full, remove lru first
                    {
                        var delNode = m_List.First();
                        m_KeyMap.Remove(delNode);
                        m_KVMap.Remove(delNode);
                        m_List.Remove(delNode);
                    }
                    var addNode = m_List.AddLast(key);//O(1)
                    m_KeyMap[key] = addNode;
                    m_KVMap[key] = value;
                }
            }
        }

        public class LRUCache2
        {

            Dictionary<int, Node> m_Map = null;
            int m_Capacity = 0;
            Node m_Head = null;
            Node m_Tail = null;

            public LRUCache2(int capacity)
            {

                m_Map = new Dictionary<int, Node>(capacity);
                m_Capacity = capacity;
            }

            public int Get(int key)
            {
                int ret = -1;

                if (m_Map.ContainsKey(key))
                {
                    ret = m_Map[key].Val;
                    Update(m_Map[key]);
                }
                return ret;
            }

            public void Put(int key, int value)
            {

                Node node = null;
                if (m_Map.ContainsKey(key))
                {
                    node = m_Map[key];
                    node.Val = value;
                }
                else
                {
                    node = new Node(key, value);
                    m_Map.Add(key, node);
                }

                Update(node);
            }

            private void Update(Node node)
            {
                if (m_Capacity == 1)
                {
                    if (m_Tail != null)
                    {
                        m_Map.Remove(m_Tail.Key);
                    }
                    m_Map[node.Key] = node;
                    m_Tail = node;
                }
                else
                {
                    if (m_Head == null && m_Tail == null)
                    {
                        node.Previous = null;
                        node.Next = null;
                        m_Head = node;
                        m_Tail = node;
                    }
                    else
                    {
                        if (m_Tail == node)
                            return;

                        if (node == m_Head)//==HEAD
                        {
                            m_Head = node.Next;
                        }
                        else
                        {
                            if (node.Previous != null)
                            {
                                node.Previous.Next = node.Next;
                                if (node.Next != null)
                                    node.Next.Previous = node.Previous;
                            }
                        }
                        // linked to tail.
                        m_Tail.Next = node;
                        node.Previous = m_Tail;
                        node.Next = null;
                        m_Tail = node;

                        if (m_Map.Count > m_Capacity)//remove
                        {
                            m_Map.Remove(m_Head.Key);
                            m_Head = m_Head.Next;
                        }

                    }
                }
            }

            public class Node
            {
                public int Key = -1;
                public int Val = -1;
                public Node Previous = null;
                public Node Next = null;

                public Node(int a_key, int a_val)
                {
                    Key = a_key;
                    Val = a_val;
                }
            }
        }

        /**
         * Your LRUCache object will be instantiated and called as such:
         * LRUCache obj = new LRUCache(capacity);
         * int param_1 = obj.Get(key);
         * obj.Put(key,value);
         */
    }

    public class LRUCache3
    {
        private Dictionary<int, LinkedListNode<int>> _hashes;
        private LinkedList<int> _list;
        private readonly int _capacity;

        public LRUCache3(int capacity)
        {
            _hashes = new Dictionary<int, LinkedListNode<int>>(capacity);
            _list = new LinkedList<int>();
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if (!_hashes.ContainsKey(key))
                return -1;
            var node = _hashes[key];
            if (node.List == null)
            {
                _hashes.Remove(key);
                return -1;
            }
            _list.Remove(node);
            _list.AddFirst(node);
            return node.Value;
        }

        public void Put(int key, int value)
        {
            if (_hashes.ContainsKey(key))
            {
                var node = _hashes[key];
                if (node.List != null)
                {
                    node.Value = value;
                    _list.Remove(node);
                    _list.AddFirst(node);
                    return;
                }
                else
                    _hashes.Remove(key);
            }
            if (_list.Count == _capacity)
                _list.RemoveLast();
            var newNode = _list.AddFirst(value);
            _hashes.Add(key, newNode);
        }
    }

}
