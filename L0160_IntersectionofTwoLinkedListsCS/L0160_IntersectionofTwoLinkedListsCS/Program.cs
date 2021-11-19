using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0160_IntersectionofTwoLinkedListsCS
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode i1 = new ListNode(8);
            i1.next = new ListNode(4);          
            i1.next.next = new ListNode(5);
            ListNode a1 = new ListNode(4);
            a1.next = new ListNode(1);
            a1.next.next = i1;
            ListNode b1 = new ListNode(5);
            b1.next = new ListNode(6);
            b1.next.next = new ListNode(1);
            b1.next.next.next = i1;

            Solution s = new Solution();
            s.GetIntersectionNode(a1, b1);
            s.GetIntersectionNode2(a1, b1);
            s.GetIntersectionNode3(a1, b1);

            ListNode a2 = new ListNode(2);
            a2.next = new ListNode(6);
            a2.next.next = new ListNode(4);
            ListNode b2 = new ListNode(1);
            b2.next = new ListNode(5);
            s.GetIntersectionNode(a2, b2);
            s.GetIntersectionNode2(a2, b2);
            s.GetIntersectionNode3(a2, b2);

            a2.next.next.next = a1;
            b2.next.next = b1;
            s.GetIntersectionNode(a2, b2);
            s.GetIntersectionNode2(a2, b2);
            s.GetIntersectionNode3(a2, b2);

        }

        /**
         * Definition for singly-linked list.
         */
        public class ListNode
        {
            public int val;
            public ListNode next = null;
            public ListNode(int x) { val = x; }
        }
        public class Solution
        {
            public ListNode GetIntersectionNode3(ListNode headA, ListNode headB)
            {
                //T(m+n)
                //S(m+n)
                List<ListNode> a = new List<ListNode>();
                List<ListNode> b = new List<ListNode>();

                int cnt = 0;
                while (headA != null)
                {
                    cnt++;
                    a.Add(headA);
                    headA = headA.next;
                }

                while (headB != null)
                {
                    cnt++;
                    b.Add(headB);
                    headB = headB.next;
                }

                ListNode ret = null;
                int min = Math.Min(a.Count, b.Count);
                for (int i = 0; i < min; i++)
                {
                    cnt++;
                    ListNode na = a[a.Count - i - 1];
                    ListNode nb = b[b.Count - i - 1];
                    if (na == nb)
                    {
                        ret = na;
                    }
                    else
                    {
                        break;
                    }
                }

                Console.WriteLine("GetIntersectionNode3");
                Console.WriteLine("T={0}", cnt);
                Console.WriteLine("S={0}+{1}={2}", a.Count, b.Count, a.Count + b.Count);
                Console.WriteLine("R={0}", ret == null ? "null" : ret.val.ToString());

                return ret;
            }

            // O(n) time and use only O(1) memory?
            public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
            {
                //boundary check
                if (headA == null || headB == null) return null;

                int cnt = 0;
                ListNode a = headA;
                ListNode b = headB;

                //if a & b have different len, then we will stop the loop after second iteration
                while (a != b)
                {
                    //for the end of first iteration, we just reset the pointer to the head of another linkedlist
                    a = a == null ? headB : a.next;
                    b = b == null ? headA : b.next;
                    cnt++;
                }

                Console.WriteLine("GetIntersectionNode");
                Console.WriteLine("T={0}", cnt);
                Console.WriteLine("S=2");
                Console.WriteLine("R={0}", a == null ? "null" : a.val.ToString());

                return a;
            }

            public ListNode GetIntersectionNode2(ListNode headA, ListNode headB)
            {
                ListNode ret = null;

                int cnt = 0;
                while (headA != null)
                {
                    ListNode _headB = headB;
                    while (_headB != null)
                    {
                        cnt++;
                        if (headA == _headB)
                        {
                            ret = headA;
                            Console.WriteLine("GetIntersectionNode2");
                            Console.WriteLine("T={0}", cnt);
                            Console.WriteLine("S=1");
                            Console.WriteLine("R={0}", ret == null ? "null" : ret.val.ToString());
                            return ret;
                        }
                        else
                        {
                            _headB = _headB.next;
                        }
                    }
                    headA = headA.next;
                }

                Console.WriteLine("GetIntersectionNode2");
                Console.WriteLine("T={0}", cnt);
                Console.WriteLine("S=1");
                Console.WriteLine("R={0}", ret == null ? "null" : ret.val.ToString());

                return ret;
            }
        }
    }
}
