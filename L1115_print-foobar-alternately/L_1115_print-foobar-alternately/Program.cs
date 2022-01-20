using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L_1115_print_foobar_alternately
{
    class Program
    {
        static void Main(string[] args)
        {
            FooBar fb = new FooBar(5);
        }

        public class FooBar
        {
            private int n;
            private ManualResetEvent mre1;
            private ManualResetEvent mre2;

            public FooBar(int n)
            {
                this.n = n;
                mre1 = new ManualResetEvent(true);
                mre2 = new ManualResetEvent(false);
            }

            public void Foo(Action printFoo)
            {

                for (int i = 0; i < n; i++)
                {
                    mre1.WaitOne();
                    mre1.Reset();
                    printFoo();
                    mre2.Set();
                }
            }

            public void Bar(Action printBar)
            {

                for (int i = 0; i < n; i++)
                {
                    mre2.WaitOne();
                    mre2.Reset();
                    printBar();
                    mre1.Set();
                }
            }
        }
    }
}
