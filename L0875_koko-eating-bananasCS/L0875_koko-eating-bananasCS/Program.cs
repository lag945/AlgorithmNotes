using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0875_koko_eating_bananasCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            bool r3 = 1000000000 == s.MinEatingSpeed(new int[] { 1000000000, 1000000000 }, 3);
            bool r2 = 14 == s.MinEatingSpeed(new int[] { 332484035, 524908576, 855865114, 632922376, 222257295, 690155293, 112677673, 679580077, 337406589, 290818316, 877337160, 901728858, 679284947, 688210097, 692137887, 718203285, 629455728, 941802184 }, 823855818);
            bool r1 = 2 == s.MinEatingSpeed(new int[] { 312884470 }, 312884469);
        }

        public class Solution
        {
            //BinarySearch&no sort
            public int MinEatingSpeed(int[] piles, int h)
            {
                //max is the 100% solution but no minimum.
                int max = piles[0];
                foreach (int pile in piles)
                {
                    max = Math.Max(max, pile);
                }
                //min is the minimum possible solution. 
                //it should be better than 1
                int min =  (int)Math.Ceiling(max / (double)h);
                int ret = max;

                if (min == max)
                    return ret;
                
                return BinarySearch(piles, min, max, h);
            }
            //BinarySearch
            public int MinEatingSpeed2(int[] piles, int h)
            {
                Array.Sort(piles);
                int max = piles[piles.Length - 1];
                int min = (int)Math.Ceiling(max / (double)h);
                int ret = max;

                if (min == max)
                    return ret;

                return BinarySearch(piles, min, max, h);
            }

            // BinarySearch to find minimum.
            private int BinarySearch(int[] piles, int min, int max, int h)
            {
                int ret = max;

                while (min <= max)
                {
                    int mid = min + (max - min) / 2;
                    if (Pass(piles, mid, h))
                    {
                        max = mid - 1;
                        ret = mid;
                    }
                    else
                    {
                        min = mid + 1;
                    }
                }

                return ret;
            }

            /// <summary>
            ///  Check if Coco can eat all banana done.
            /// </summary>
            /// <param name="piles"></param>
            /// <param name="eph">eat per hour</param>
            /// <param name="h"></param>
            /// <returns></returns>
            private bool Pass(int[] piles, int eph, int h)
            {
                bool ret = true;

                int sum = 0;
                for (int i = 0; i < piles.Length; i++)
                {
                    sum += (int)Math.Ceiling(piles[i] / (double)eph);
                    if (sum > h)
                    {
                        ret = false;
                        break;
                    }
                }

                return ret;
            }

            //Time Limit Exceeded
            public int MinEatingSpeed3(int[] piles, int h)
            {
                Array.Sort(piles);
                int max = piles[piles.Length - 1];
                int min = (int)Math.Ceiling(max / (double)h);
                int ret = max;

                if (min == max)
                    return ret;

                for (int i = min; i < max; i++)
                {
                    bool match = Pass(piles, i, h);

                    if (match)
                    {
                        ret = i;
                        break;
                    }
                }

                return ret;
            }


        }

    }
}
