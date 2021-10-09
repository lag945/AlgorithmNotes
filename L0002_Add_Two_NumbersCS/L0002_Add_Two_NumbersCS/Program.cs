using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0002_Add_Two_NumbersCS
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://leetcode.com/problems/add-two-numbers/
            List<int> list1 = new List<int>(new int[] { 9 });
            List<int> list2 = new List<int>(new int[] { 1, 9, 9, 9, 9, 9, 9, 9, 9, 9 });

            long sum = 0;

            for (int i = 0; i < list1.Count; i++)
            {
                Console.Write(sum.ToString());
                long num = list1[i] * (long)Math.Pow(10, i);
                sum += num;
                Console.WriteLine("+" + num.ToString() + "=" + sum.ToString());
            }

            for (int i = 0; i < list2.Count; i++)
            {
                Console.Write(sum.ToString());
                long num = list2[i] * (long)Math.Pow(10, i);
                sum += num;
                Console.WriteLine("+" + num.ToString() + "=" + sum.ToString());
            }
            //Input
            //[9]
            //[1, 9, 9, 9, 9, 9, 9, 9, 9, 9]
            //Output
            //[8, 0, 4, 5, 6, 0, 0, 1, 4, 1]
            //Expected
            //[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1]

            //9999
            //99
            //10098->89001
            //89001

            //[9,9,9,9,9,9,9]
            //[9,9,9,9]
            //Output:
            //[9,9,9,8,8,9,9,2]
            //Expected:
            //[8,9,9,9,0,0,0,1]

            //8




        }


        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }


        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            //= 999+999=1998
            // worth space algorithm
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();

            // ListNode is class
            while (l1 != null)
            {
                list1.Add(l1.val);
                l1 = l1.next;
            }

            while (l2 != null)
            {
                list2.Add(l2.val);
                l2 = l2.next;
            }

            int max = list1.Count;
            if (list2.Count > max)
            {
                max = list2.Count;
            }

            //list1.Reverse();
            //list2.Reverse();
            List<int> sums = new List<int>();

            bool addNext = false;
            for (int i = 0; i < max; i++)
            {
                int sum = 0;
                if (i < list1.Count)
                {
                    sum += list1[i];
                }
                if (i < list2.Count)
                {
                    sum += list2[i];
                }
                if (addNext) sum++;
                if (sum > 9)
                {
                    sum -= 10;
                    addNext = true;
                }
                else
                {
                    addNext = false;
                }
                sums.Add(sum);
            }

            if (addNext)
            {
                sums.Add(1);
            }

            ListNode ret = null;
            ListNode current = null;

            //sums.Reverse();

            for (int i = 0; i < sums.Count; i++)
            {
                ListNode temp = new ListNode();
                temp.val = sums[i];

                if (ret == null)
                {
                    ret = temp;
                }
                else
                {
                    current.next = temp;
                }
                current = temp;
            }

            return ret;

        }

    }
}
