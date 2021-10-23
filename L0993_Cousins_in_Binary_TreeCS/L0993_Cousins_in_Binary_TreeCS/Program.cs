using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0993_Cousins_in_Binary_TreeCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.right = new TreeNode(4);
            root.right.right = new TreeNode(5);
            bool ret = s.IsCousins(root, 5, 4);//true

            root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            ret = s.IsCousins(root, 2, 3);//false
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
            public bool IsCousins(TreeNode root, int x, int y)
            {
                //BFS
                bool ret = false;
                int depth = 0;
                List<TreeNode> nodes = new List<TreeNode>();
                nodes.Add(root);
                while (nodes.Count > 0)
                {
                    int times = MeetTimes(nodes, x, y);
                    if (times == 0)
                    {
                        List<TreeNode> _nodes = new List<TreeNode>();
                        for (int i = 0; i < nodes.Count; i++)
                        {
                            if (nodes[i] != null)
                            {
                                _nodes.Add(nodes[i].left);
                                _nodes.Add(nodes[i].right);
                            }
                        }
                        nodes = _nodes;
                        depth++;
                    }
                    else
                    {
                        if (times == 1)
                        {
                            ret = false;
                        }
                        else if (times == 2)
                        {
                            ret = true;
                        }
                        nodes.Clear();
                    }
                }

                return ret;
            }

            public int MeetTimes(List<TreeNode> nodes, int x, int y)
            {
                int ret = 0;

                int meet1 = -1;
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (nodes[i] == null)
                    {
                        continue;
                    }
                    if (nodes[i].val == x || nodes[i].val == y)
                    {
                        if (meet1 == -1)
                        {
                            meet1 = i;
                        }
                        else
                        {
                            if (meet1 % 2 == 0 && i == meet1 + 1)//brothers
                            {
                                break;
                            }
                        }
                        ret++;
                    }
                }

                return ret;
            }

        }

    }
}
