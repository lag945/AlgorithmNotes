using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0897_increasing_order_search_treeCS
{
    class Program
    {
        //https://leetcode.com/problems/increasing-order-search-tree/
        static void Main(string[] args)
        {
            TreeNode a = new TreeNode(5, new TreeNode(1), new TreeNode(7));
            Solution s = new Solution();
            TreeNode r = s.IncreasingBST(a);
        }

        //Definition for a binary tree node.
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
            public TreeNode IncreasingBST(TreeNode root)
            {
                Stack<TreeNode> stack = new Stack<TreeNode>();
                List<TreeNode> nodes = new List<TreeNode>();
                if (root != null)
                {
                    stack.Push(root);
                }
                DFS(stack, nodes);

                //link
                for (int i = 0; i < nodes.Count; i++)
                {
                    nodes[i].left = null;
                    if (i == nodes.Count - 1)
                        nodes[i].right = null;
                    else
                        nodes[i].right = nodes[i + 1];
                }

                if (nodes.Count != 0)
                    return nodes[0];
                else
                    return null;
            }

            private void DFS(Stack<TreeNode> stack, List<TreeNode> nodes)
            {
                if (stack.Count == 0)
                    return;

                TreeNode peek = stack.Peek();
                if (peek.left == null)
                {
                    TreeNode node = stack.Pop();
                    if (node.right != null)
                    {
                        stack.Push(node.right);
                        node.right = null;
                    }
                    nodes.Add(node);
                }
                else
                {
                    stack.Push(peek.left);
                    peek.left = null;
                }
                DFS(stack, nodes);
            }
        }
    }
}
