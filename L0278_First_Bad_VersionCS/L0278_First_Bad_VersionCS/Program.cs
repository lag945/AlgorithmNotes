using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0278_First_Bad_VersionCS
{
    //https://leetcode.com/problems/first-bad-version/
    class Program
    {
        static int bad = 0;
        static void Main(string[] args)
        {
            int n = 2126753390;
            bad = 1702766719;

            int r = FirstBadVersion(n);
        }

        public static int FirstBadVersion(int n)
        {
            int ret = 0;
            ret = BinarySearch(1, n);
            return ret;
        }

        public static  int BinarySearch(int v1, int v2)
        {
            int ret = 0;
            Console.WriteLine(string.Format("{0},{1}", v1, v2));
            if (v1 <= v2)
            {
                int mid = (int)(((long)v1 + (long)v2) / 2);
                bool bad = IsBadVersion(mid);

                if (bad && (mid == 1 || !IsBadVersion(mid - 1)))
                {
                    ret = mid;//firstbad
                }
                else
                {
                    if (bad)
                    {
                        //forward
                        ret = BinarySearch(v1, mid - 1);
                    }
                    else
                    {
                        //backward
                        ret = BinarySearch(mid + 1, v2);
                    }
                }
            }

            return ret;
        }

        public static bool IsBadVersion(int n)
        {
            return n >= bad;
        }
    }

}
