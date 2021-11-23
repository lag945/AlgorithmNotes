using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0952_largest_component_size_by_common_factorCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int r = s.LargestComponentSize(new int[] { 2, 7, 522, 526, 535, 26, 944, 35, 519, 45, 48, 567, 266, 68, 74, 591, 81, 86, 602, 93, 610, 621, 111, 114, 629, 641, 131, 651, 142, 659, 669, 161, 674, 163, 180, 187, 190, 194, 195, 206, 207, 218, 737, 229, 240, 757, 770, 260, 778, 270, 272, 785, 274, 290, 291, 292, 296, 810, 816, 314, 829, 833, 841, 349, 880, 369, 147, 897, 387, 390, 905, 405, 406, 407, 414, 416, 417, 425, 938, 429, 432, 926, 959, 960, 449, 963, 966, 929, 457, 463, 981, 985, 79, 487, 1000, 494, 508 });//84
            r = s.LargestComponentSize(new int[] { 99, 68, 70, 77, 35, 52, 53, 25, 62 });//8
            r = s.LargestComponentSize(new int[] { 2, 3, 6, 7, 4, 12, 21, 39 });//8
            r = s.LargestComponentSize(new int[] { 4, 6, 15, 35 });//4
            r = s.LargestComponentSize(new int[] { 20, 50, 9, 63 });//2
        }

        public class Solution
        {
            //	Time Limit Exceeded
            public int LargestComponentSize(int[] nums)
            {
                GeneratePrimesNaive(nums.Max());
                List<int> [] factorList = new List<int>[nums.Length];

                // calc prime factor > 1
                for (int i=0;i<nums.Length;i++)
                    factorList[i]=PrimeFactor(nums[i]);

                List<List<int>> unions = new List<List<int>>();
                List<int> group = new List<int>();
                do
                {
                    if (group.Count > 0)
                        unions.Add(group.ToList());
                    group.Clear();
                    for (int i = 0; i < nums.Length; i++)
                    {
                        if (nums[i] == 0)
                            continue;

                        if (group.Count == 0)
                        {
                            group.AddRange(factorList[i]);
                            nums[i] = 0;
                        }
                        else
                        {
                            if (Intersect(group, factorList[i]))
                            {
                                Union(group, factorList[i]);
                                nums[i] = 0;
                                i = 0;
                            }
                        }
                    }
                }
                while (group.Count > 0);



                int max = 0;
                for (int i = 0; i < unions.Count; i++)
                {
                    int stream = 0;
                    for (int j = 0; j < factorList.Length; j++)
                    {
                        if (Intersect(unions[i], factorList[j]))
                        {
                            stream++;
                        }
                        else
                        {
                            //Console.WriteLine(j.ToString());
                        }
                    }

                    Console.WriteLine(stream.ToString());

                    if (stream > max)
                    {
                        max = stream;
                    }
                }

                return max;
            }

            private List<int> Factor(int number)
            {
                List<int> factors = new List<int>();
                int max = (int)Math.Sqrt(number);  // Round down

                for (int factor = 1; factor <= max; ++factor) // Test from 1 to the square root, or the int below it, inclusive.
                {
                    if (number % factor == 0)
                    {
                            factors.Add(factor);
                        if (factor != number / factor) // Don't add the square root twice!  Thanks Jon
                            factors.Add(number / factor);
                    }
                }
                return factors;
            }

            //https://zh.wikipedia.org/wiki/%E8%B3%AA%E6%95%B8%E5%88%97%E8%A1%A8
            private List<int> PrimeFactor(int number)
            {
                List<int> factors = new List<int>();

                foreach (int prime in primeMap.ToList())
                {
                    if (prime > number)
                        break;
                    if (number % prime == 0)
                        factors.Add(prime);
                }
                return factors;
            }

            private HashSet<int> primeMap = new HashSet<int>();
            public void GeneratePrimesNaive(int max)
            {
                primeMap.Add(2);
                int nextPrime = 3;
                List<int> primes = primeMap.ToList();
                while (nextPrime < max)
                {
                    int sqrt = (int)Math.Sqrt(nextPrime);
                    bool isPrime = true;
                    for (int i = 0; (int)primes[i] <= sqrt; i++)
                    {
                        if (nextPrime % primes[i] == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                    {
                        primeMap.Add(nextPrime);
                        primes.Add(nextPrime);
                    }
                    nextPrime += 2;
                }
            }

            private bool Intersect(List<int> a, List<int> b)
            {
                bool ret = false;

                for (int i = 0; i < a.Count; i++)
                {
                    for (int j = 0; j < b.Count; j++)
                    {
                        if (a[i] == b[j])
                        {
                            ret = true;
                            break;
                        }
                    }
                }

                return ret;
            }

            private void Union(List<int> a, List<int> b)
            {
                for (int i = 0; i < b.Count; i++)
                {
                    bool find = false;
                    for (int j = 0; j < a.Count; j++)
                    {
                        if (b[i] == a[j])
                        {
                            find = true;
                            break;
                        }
                    }

                    if (!find)
                        a.Add(b[i]);
                }
            }


        }

    }
}
