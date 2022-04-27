using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0706_design_hashmapCS
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashmap = new MyHashMapv3();
            hashmap.Put(3, 9);
            hashmap.Put(3, 9);
            hashmap.Put(5000, 9);
            bool r1 = hashmap.Get(3) == 9;
            hashmap.Remove(3);
            bool r2 = hashmap.Get(3) == -1;
            bool r3 = hashmap.Get(5000) == 9;
        }
    }

    /**
     * Your MyHashMap object will be instantiated and called as such:
     * MyHashMap obj = new MyHashMap();
     * obj.Put(key,value);
     * int param_2 = obj.Get(key);
     * obj.Remove(key);
     */

    // constructor too slow
    public class MyHashMap
    {

        int[] map = null;
        public MyHashMap()
        {

            map = new int[1000000 + 1];
            for (int i = 0; i < map.Length; i++)
            {
                map[i] = -1;
            }

        }

        public void Put(int key, int value)
        {
            map[key] = value;
        }

        public int Get(int key)
        {
            return map[key];
        }

        public void Remove(int key)
        {
            map[key] = -1;
        }
    }


    // speed up constructor using default initial null
    public class MyHashMapv2
    {
        int?[] array = new int?[1000001];
        public MyHashMapv2()
        {
        }

        public void Put(int key, int value)
        {
            array[key] = value;
        }

        public int Get(int key)
        {
            if (array[key] == null)
            {
                return -1;
            }
            else
            {
                return (int)array[key];
            }
        }

        public void Remove(int key)
        {
            array[key] = null;
        }
    }

    // using hash function 
    public class MyHashMapv3
    {
        SortedList<int, int>[] array = new SortedList<int, int>[1000];
        public MyHashMapv3()
        {
        }

        public int Hash(int key)
        {
            return key % 1000;
        }

        public void Put(int key, int value)
        {
            int hash = Hash(key);
            if (array[hash] == null)
            {
                array[hash] = new SortedList<int, int>();
            }
            if (array[hash].ContainsKey(key))
                array[hash][key] = value;
            else 
                array[hash].Add(key, value);
        }

        public int Get(int key)
        {
            int hash = Hash(key);

            if (array[hash] == null)
                return -1;
            else
            {
                if (array[hash].ContainsKey(key))
                {
                    return array[hash][key];
                }
            }

            return -1;
        }

        public void Remove(int key)
        {
            int hash = Hash(key);

            if (array[hash] != null)
            {
                array[hash].Remove(key);
            }

        }
    }


}
