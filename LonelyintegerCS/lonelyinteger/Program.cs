using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lonelyinteger
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int lonelyinteger(List<int> a)
        {
            //https://www.hackerrank.com/challenges/lonely-integer/problem
            int ret = -1;
            //create array
            int n = 100;
            List<int> timesList = new List<int>(n + 1);
            for (int i = 0; i <= n; i++)
            {
                timesList.Add(0);
            }
            // visit unique
            for (int i = 0; i < a.Count; i++)
            {
                timesList[a[i]]++;
            }

            // Define the query expression.
            var timesQuery =
                from time in timesList
                where time == 1
                select time;

            //foreach (int time in timesQuery)
            //{
            //    ret = time;
            //}


            for (int i = 0; i < timesList.Count; i++)
            {
                if (timesList[i] == 1)
                {
                    ret = i;
                    break;
                }
            }


            return ret;

        }

    }
}
