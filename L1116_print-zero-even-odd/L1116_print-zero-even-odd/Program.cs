using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace L1116_print_zero_even_odd
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class ZeroEvenOdd
        {
            private int n;
            AutoResetEvent mreZero = new AutoResetEvent(true);
            AutoResetEvent mreEven = new AutoResetEvent(false);
            AutoResetEvent mreOdd = new AutoResetEvent(false);

            public ZeroEvenOdd(int n)
            {
                this.n = n;
            }

            // printNumber(x) outputs "x", where x is an integer.
            public void Zero(Action<int> printNumber)
            {
                for (int i = 1; i <= n; i++)
                {
                    mreZero.WaitOne();
                    printNumber(0);
                    if (i % 2 == 0)
                    {
                        mreEven.Set();
                    }
                    else
                    {
                        mreOdd.Set();
                    }
                }
            }

            public void Even(Action<int> printNumber)
            {
                for (int i = 2; i <= n; i += 2)
                {
                    mreEven.WaitOne();
                    printNumber(i);
                    mreZero.Set();
                }
            }

            public void Odd(Action<int> printNumber)
            {
                for (int i = 1; i <= n; i += 2)
                {
                    mreOdd.WaitOne();
                    printNumber(i);
                    mreZero.Set();
                }
            }
        }
    }
}
