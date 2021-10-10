using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0201_Bitwise_And_Of_Numbers_RangeCS
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://leetcode.com/problems/bitwise-and-of-numbers-range/submissions/
            //https://leetcode.com/problems/bitwise-and-of-numbers-range/discuss/1513163/C%2B%2B-Match-Prefix
            Solution s = new Solution();
            //int ret = s.RangeBitwiseAnd3(5, 7);// 101 110 111=>100
            //ret = s.RangeBitwiseAnd3(4, 6);// 100,101,110=>100
            //ret = s.RangeBitwiseAnd3(1, 2147483647);
            //ret = s.RangeBitwiseAnd3(600000000, 2147483645);
            int ret = s.RangeBitwiseAnd3(2147483646, 2147483647);
        }
    }

    public class Solution
    {
        //太慢
        public int RangeBitwiseAnd(int left, int right)
        {
            //5-101
            //6-110
            //7-111
            //AND 100
            int[] ret = new int[1];
            BitArray ba = null;
            for (int i = left; i <= right; i++)
            {

                if (ba == null)
                {
                    ba = new BitArray(BitConverter.GetBytes(i));
                }
                else
                {
                    BitArray _ba = new BitArray(BitConverter.GetBytes(i));
                    ba.And(_ba);
                }

                if (ba.Count == 0)
                {
                    break;
                }

            }


            ba.CopyTo(ret, 0);
            return ret[0];

        }

        public int RangeBitwiseAnd2(int left, int right)
        {
            int ret = 0;
            int[] bits = new int[32];

            int i = 0;
            List<int> indexs = new List<int>(32);
            for (i = 0; i < 32; i++)
            {
                indexs.Add(i);
            }

            i = left;
            while (i <= right)
            {
                BitArray ba = new BitArray(BitConverter.GetBytes(i));
                List<int> removeIndexs= new List<int>();
                if (i == left)
                {
                    for (int j = 0; j < ba.Length; j++)
                    {
                        if (!ba.Get(j))
                        {
                            removeIndexs.Add(j);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < indexs.Count; j++)
                    {
                        if (!ba.Get(indexs[j]))
                        {
                            removeIndexs.Add(j);
                        }
                    }
                }

                for (int j = removeIndexs.Count - 1; j >= 0; j--)
                {
                    indexs.RemoveAt(removeIndexs[j]);
                }

                if (indexs.Count == 0)
                {
                    break;
                }

                i++;
            }

            BitArray result = new BitArray(32);
            for (i = 0; i < indexs.Count; i++)
            {
                result.Set(indexs[i], true);
            }

            int [] array = new int[1];
            result.CopyTo(array, 0);
            ret = array[0];

            return ret;
        }

        public int RangeBitwiseAnd3(int left, int right)
        {
            int ret = 0;
            int[] bits = new int[32];

            int i = 0;
            List<int> indexs = new List<int>(32);
            for (i = 0; i < 32; i++)
            {
                indexs.Add(i);
            }

            //移除其中最大的n次方
            int max = -1;

            for (i = 0; i < 32; i++)
            {
                int value = (int)Math.Pow(2, i);
                if (value >= left && value <= right)
                {
                    max = i;
                }
            }

            if (max >= 0)
            {
                BitArray ba = new BitArray(BitConverter.GetBytes((int)Math.Pow(2, max)));
                List<int> removeIndexs = new List<int>();
                for (int j = 0; j < ba.Length; j++)
                {
                    if (!ba.Get(j))
                    {
                        removeIndexs.Add(j);
                    }
                }

                for (int j = removeIndexs.Count - 1; j >= 0; j--)
                {
                    indexs.RemoveAt(removeIndexs[j]);
                }
            }

            i = left;
            while (i <= right)
            {
                if (i < 0) 
                {
                    break;
                }
                BitArray ba = new BitArray(BitConverter.GetBytes(i));
                List<int> removeIndexs = new List<int>();
                if (i == left)
                {
                    for (int j = 0; j < indexs.Count; j++)
                    {
                        if (!ba.Get(indexs[j]))
                        {
                            removeIndexs.Add(j);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < indexs.Count; j++)
                    {
                        if (!ba.Get(indexs[j]))
                        {
                            removeIndexs.Add(j);
                        }
                    }
                }

                for (int j = removeIndexs.Count - 1; j >= 0; j--)
                {
                    indexs.RemoveAt(removeIndexs[j]);
                }

                if (indexs.Count == 0)
                {
                    break;
                }

                i++;
            }

            BitArray result = new BitArray(32);
            for (i = 0; i < indexs.Count; i++)
            {
                result.Set(indexs[i], true);
            }

            int[] array = new int[1];
            result.CopyTo(array, 0);
            ret = array[0];

            return ret;
        }

    }
}
