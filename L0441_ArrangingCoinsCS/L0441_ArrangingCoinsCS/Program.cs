using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0441_ArrangingCoinsCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int ret = s.ArrangeCoins(8);
        }

        public class Solution
        {
            public int ArrangeCoins(int n)
            {
                int ret = 1;

                int sum = -1;
                while (sum < n)
                {
                    sum = (1 + ret) * ret/2;
                    if (sum == n)
                    {
                        return ret;
                    }
                    else if (sum > n)
                    {
                        return ret - 1;
                    }
                    ret++;
                }

                return ret;
            }
        }
    }
}
