using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0230_kth_smallest_element_in_a_bstCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(1, null, new TreeNode(2));
            root.right = new TreeNode(4);
            bool r = s.KthSmallest(root,3)==3;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        public class Solution
        {
            public int KthSmallest(TreeNode root, int k)
            {
                // left -> middle -> right to find smallest                

                if (root == null)
                    return -1;

                Stack<TreeNode> stack = new Stack<TreeNode>();
                stack.Push(root);

                while (stack.Count != 0)
                {
                    TreeNode peek = stack.Peek();

                    if (peek.left == null)
                    {
                        k--;
                        if (k == 0)
                            return peek.val;

                        stack.Pop();
                        if (peek.right != null)
                        {
                            stack.Push(peek.right);
                            peek.right = null;
                        }
                    }
                    else
                    {
                        stack.Push(peek.left);
                        peek.left = null;
                    }

                }

                return -1;
            }


        }
    }
}
