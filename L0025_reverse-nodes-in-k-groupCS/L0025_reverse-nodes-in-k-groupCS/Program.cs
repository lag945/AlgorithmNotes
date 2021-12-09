using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0025_reverse_nodes_in_k_groupCS
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            /*
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            */

            Solution s = new Solution();
            ListNode r = s.ReverseKGroup(head, 2);
        }

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
        public class Solution
        {
            public ListNode ReverseKGroup(ListNode head, int k)
            {
                ListNode ret = head;
                if (k == 1)
                    return ret;

                List<ListNode> nodes = new List<ListNode>();
                while (head != null)
                {
                    nodes.Add(head);
                    head = head.next;
                }

                int index = k - 1;
                ListNode tail = null;
                for (; index < nodes.Count; index += k)
                {
                    if (tail == null)
                    {
                        ret = nodes[index];
                    }
                    else
                    {
                        tail.next = nodes[index];
                    }


                    for (int i = 0; i < k - 1; i++)
                    {
                        nodes[index - i].next = nodes[index - i - 1];
                    }
                    Console.WriteLine(index.ToString());
                    tail = nodes[index - k + 1];
                }

                if (index == nodes.Count + k - 1)
                    tail.next = null;
                else
                    tail.next = nodes[index - k + 1];

                return ret;
            }

            //low memory
            public ListNode ReverseKGroup2(ListNode head, int k)
            {
                ListNode curr = head;
                int count = 0;
                while (curr != null && count != k)
                { // find the k+1 node
                    curr = curr.next;
                    count++;
                }
                if (count == k)
                { // if k+1 node is found
                    curr = ReverseKGroup2(curr, k); // reverse list with k+1 node as head
                                                   // head - head-pointer to direct part, 
                                                   // curr - head-pointer to reversed part;
                    while (count-- > 0)
                    { // reverse current k-group: 
                        ListNode tmp = head.next; // tmp - next head in direct part
                        head.next = curr; // preappending "direct" head to the reversed list 
                        curr = head; // move head of reversed part to a new node
                        head = tmp; // move "direct" head to the next node in direct part
                    }
                    head = curr;
                }
                return head;
            }
        }
    }
}
