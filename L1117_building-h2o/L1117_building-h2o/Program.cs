using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace L1117_building_h2o
{
    class Program
    {
        //https://leetcode.com/problems/building-h2o/

        static H2O h2o = new H2O();
        static void Main(string[] args)
        {
            Thread t1 = new Thread(CallO);
            Thread t2 = new Thread(CallO);
            Thread t3 = new Thread(CallO);
            Thread t4 = new Thread(CallH);
            Thread t5 = new Thread(CallH);
            Thread t6 = new Thread(CallH);
            Thread t7 = new Thread(CallH);
            Thread t8 = new Thread(CallH);
            Thread t9 = new Thread(CallH);
            t1.Start(h2o);
            t2.Start(h2o);
            t3.Start(h2o);
            t4.Start(h2o);
            t5.Start(h2o);
            t6.Start(h2o);
            t7.Start(h2o);
            t8.Start(h2o);
            t9.Start(h2o);
            //"OHOOHOHHHHOHHOHHHH"
        }

        public static void CallH(object data)
        {
            ((H2O)data).Hydrogen(null);
        }

        public static void CallO(object data)
        {
            ((H2O)data).Oxygen(null);
        }


        public class H2O
        {
            AutoResetEvent mreH = new AutoResetEvent(true);//auto每次只通過一個
            AutoResetEvent mreO = new AutoResetEvent(false);
            int status = 0;

            public H2O()
            {

            }

            public void Hydrogen(Action releaseHydrogen)
            {

                mreH.WaitOne();
                System.Diagnostics.Debug.WriteLine("Hydrogen");
                // releaseHydrogen() outputs "H". Do not change or remove this line.
                //releaseHydrogen();
                status++;
                if (status == 1)
                {
                    mreH.Set();
                }
                else if (status == 2)
                {
                    mreO.Set();
                }
                else
                { 
                }
            }

            public void Oxygen(Action releaseOxygen)
            {
                mreO.WaitOne();
                System.Diagnostics.Debug.WriteLine("Oxygen");
                // releaseOxygen() outputs "O". Do not change or remove this line.
                //releaseOxygen();
                status = 0;
                mreO.Reset();
                mreH.Set();
            }
        }


    }
}
