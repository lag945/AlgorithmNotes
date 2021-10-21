using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamming_weight
{
    class Program
    {
        //https://leetcode.com/problems/number-of-1-bits/discuss/55255/C%2B%2B-Solution%3A-n-and-(n-1)
        //https://en.wikipedia.org/wiki/Hamming_weight
        static void Main(string[] args)
        {
            int r = HammingWeight(44);
            r = HammingWeight(40);
            r = HammingWeight(32);
        }

        static int HammingWeight(uint n)
        {
            int count = 0;

            while (n!=0)
            {
                n &= (n - 1);
                count++;
            }

            return count;
        }
    }
}
