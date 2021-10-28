using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0567_Permutation_in_StringCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            bool ret = s.CheckInclusion("ab", "eidboaoo");
        }

        public class Solution
        {
            public bool CheckInclusion(string s1, string s2)
            {

                bool ret = false;

                // ascii 97~122

                int[] times = new int[26];

                for (int i = 0; i < s1.Length; i++)
                {
                    times[Convert.ToInt32(s1[i]) - 97]++;
                }

                for (int i = 0; i < s2.Length - s1.Length + 1; i++)
                {
                    int[] _times = (int[])times.Clone();
                    for (int j = 0; j < s1.Length; j++)
                    {
                        _times[Convert.ToInt32(s2[i + j]) - 97]--;
                    }

                    if (AllZero(_times))
                    {
                        ret = true;
                        break;
                    }
                }
                
                return ret;
            }

            public bool AllZero(int[] times)
            {
                bool ret = true;

                for (int i = 0; i < times.Length; i++)
                {
                    if (times[i] != 0)
                    {
                        ret = false;
                        break;
                    }
                }

                return ret;
            }

            public bool CheckInclusion2(string s1, string s2)
            {

                bool ret = false;

                char[] source = new char[s1.Length];
                for (int i = 0; i < s1.Length; i++)
                {
                    source[i] = s1[i];
                }

                Array.Sort(source);

                char[] target = new char[s1.Length];
                for (int i = 0; i < s2.Length - s1.Length + 1; i++)
                {
                    for (int j = 0; j < s1.Length; j++)
                    {
                        target[j] = s2[i + j];
                    }

                    Array.Sort(target);

                    if (source.SequenceEqual(target))
                    {
                        ret = true;
                        break;
                    }
                }

                return ret;
            }
        }
    }
}
