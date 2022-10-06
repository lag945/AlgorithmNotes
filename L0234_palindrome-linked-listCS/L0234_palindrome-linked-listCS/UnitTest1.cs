using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace L0234_palindrome_linked_listCS
{
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

    public class Solution
    {
        //T:O(n), S:O(n)
        public bool IsPalindrome(ListNode head)
        {
            List<int> list = new List<int>();

            while (head != null)
            {
                list.Add(head.val);
                head = head.next;
            }

            for (int i = 0; i < list.Count / 2; i++)
            {
                if (list[i] != list[list.Count - i - 1])
                    return false;
            }

            return true;
        }

        public ListNode CreateLinkedList(int[] arr)
        {
            ListNode ret = null;
            ListNode prev = null;

            if (arr.Length > 0)
            {
                ret = new ListNode(arr[0]);
                prev = ret;
            }

            for (int i = 1; i < arr.Length; i++)
            {
                var node = new ListNode(arr[i]);
                prev.next = node;
                prev = node;
            }

            return ret;
        }

        public void ReverseLinkedList(ListNode head)
        {
            ListNode prev = null;

            while (head != null)
            {
                var next = head.next;
                head.next = prev;
                head = next;
                prev = head;
            }
        }
    }

    [TestClass]
    public class UnitTest1
    {
        Solution solution = new Solution();
        [TestMethod]
        public void TestMethod1()
        {
            var input = solution.CreateLinkedList(new int[] { 1, 2, 2, 1 });
            Assert.AreEqual(solution.IsPalindrome(input), true);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = solution.CreateLinkedList(new int[] { 1, 2 });
            Assert.AreEqual(solution.IsPalindrome(input), false);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = solution.CreateLinkedList(new int[] { 1, 2, 3, 4, 5 });
            Assert.AreEqual(solution.IsPalindrome(input), false);
        }

        [TestMethod]
        public void TestMethod_Reverse()
        {
            var input = solution.CreateLinkedList(new int[] { 1, 2, 3, 4, 5 });
            solution.ReverseLinkedList(input);
            Assert.AreEqual(input.val, 5);
            input = input.next;
            Assert.AreEqual(input.val, 4);
            input = input.next;
            Assert.AreEqual(input.val, 3);
            input = input.next;
            Assert.AreEqual(input.val, 2);
            input = input.next;
            Assert.AreEqual(input.val, 1);
        }
    }
}
