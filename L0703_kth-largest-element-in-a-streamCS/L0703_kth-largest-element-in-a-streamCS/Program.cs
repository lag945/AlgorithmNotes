using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0703_kth_largest_element_in_a_streamCS
{
    class Program
    {
        static void Main(string[] args)
        {

            KthLargest kl = new KthLargest(3, new int[] { 4, 5, 8, 2 });
            bool r = kl.Add(3) == 4;
        }

        public class KthLargest
        {
            List<int> m_List = null;
            int m_K = 0;
            MinHeap m_MinHeap = new MinHeap();//desc comparer

            public class MinHeap : IComparer<int>
            {
                public int Compare(int x, int y)
                {
                    return y - x;
                }
            }

            //T:O(n^2)
            //S:O(k+1)
            //public KthLargest(int k, int[] nums)
            //{
            //    m_K = k;
            //    m_List = new List<int>(k + 1);// max size  S: O(k+1)

            //    for (int i = 0; i < nums.Length; i++)
            //    {
            //        int index = m_List.BinarySearch(nums[i], m_MinHeap);//T:O(log(n))

            //        if (index < 0)
            //            index = ~index;
            //        m_List.Insert(index, nums[i]);//T:O(n)

            //        if (m_List.Count > k)
            //            m_List.RemoveAt(m_List.Count - 1);//T:O(1)
            //    }
            //}

            //T:O(nlog(n))
            //S:O(n)
            public KthLargest(int k, int[] nums)
            {
                m_K = k;
                m_List = new List<int>(nums);
                m_List.Sort(m_MinHeap);

                if (m_List.Count > k)
                {
                    m_List.RemoveRange(k, m_List.Count - k);
                }
            }

            //T:O(n)
            public int Add(int val)
            {
                // special case , no inserting. T:O(1)
                if (m_List.Count == m_K && val < m_List[m_List.Count - 1])
                {
                    return m_List[m_List.Count - 1];
                }

                //inserting , T:O(log(n))
                int index = m_List.BinarySearch(val, m_MinHeap);
                if (index < 0)
                    index = ~index;
                m_List.Insert(index, val);//*T:O(n)

                //remove  last  when array is full ,  T:O(1)
                if (m_List.Count > m_K)
                    m_List.RemoveAt(m_List.Count - 1);

                return m_List[m_List.Count - 1]; //T: O(1)
            }
        }

        public class KthLargest2
        {

            List<int> m_List = null;
            int m_K = 0;
            public KthLargest2(int k, int[] nums)
            {
                m_K = k;
                m_List = new List<int>(nums);
                m_List.Sort();//T:n*log(n)
            }

            public int Add(int val)
            {
                //bs T:log(n)

                int index = m_List.BinarySearch(val);
                if (index < 0)
                    index = ~index;
                m_List.Insert(index, val);
                return m_List[m_List.Count - m_K];
            }
        }

    }
}
