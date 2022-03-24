using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0991_broken_calculatorCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int ret = s.BrokenCalc(1, 5);
        }

        public class Solution
        {
            public int BrokenCalc(int startValue, int target)
            {
                int ans = 0;
                while (target > startValue)
                {
                    ans++;
                    if (target % 2 == 1)
                        target++;
                    else
                        target /= 2;
                }

                return ans + startValue - target;
            }

            public int BrokenCalc2(int startValue, int target)
            {
                int min = 0;
                if (target == startValue)
                {
                    min = 0;
                }
                else if (target < startValue)
                {
                    min = startValue - target;
                }
                else
                {
                    double scale = target / (double)startValue;
                    double log = Math.Log(scale, 2);
                    int ceiling = (int)Math.Ceiling(log);
                    min = ceiling + (startValue * (int)Math.Pow(2, ceiling) - target);
                }
                DFS(startValue, target, 0, ref min);
                return min;
            }

            public void DFS(int startValue, int target, int current, ref int min)
            {
                if (startValue == target)
                {
                    min = Math.Min(current, min);
                    return;
                }

                if (current > min)
                    return;

                DFS(startValue * 2, target, current + 1, ref min);
                DFS(startValue - 1, target, current + 1, ref min);

            }

            public int BrokenCalc3(int startValue, int target)
            {
                int min = Int32.MaxValue;

                if (target == startValue)
                {
                    min = 0;
                }
                else if (target < startValue)
                {
                    min = startValue - target;
                }
                else
                {
                    double scale = target / (double)startValue;
                    double log = Math.Log(scale, 2);
                    int ceiling = (int)Math.Ceiling(log);
                    min = ceiling + (startValue * (int)Math.Pow(2, ceiling) - target);
                    int extra = 0;
                    while (target % 2 == 0)
                    {
                        target /= 2;
                        extra++;
                        int _min = 0;
                        if (target == startValue)
                        {
                            _min = extra;
                        }
                        else if (target < startValue)
                        {
                            _min = startValue - target + extra;
                        }
                        else
                        {
                            scale = target / (double)startValue;
                            log = Math.Log(scale, 2);
                            ceiling = (int)Math.Ceiling(log);
                            _min = ceiling + (startValue * (int)Math.Pow(2, ceiling) - target) + extra;
                        }
                        min = Math.Min(min, _min);
                    }
                }

                return min;
            }
        }

    }
}
