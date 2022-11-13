using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L6235_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();

            var n7 = new TreeNode(7);
            var n6 = new TreeNode(6);
            var n5 = new TreeNode(5);
            var n4 = new TreeNode(4);

            var n3 = new TreeNode(3,n7,n6);
            var n2 = new TreeNode(2,n5,n4);
            var root = new TreeNode(1,n3,n2);

            var r = s.MinimumOperations(root);
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
            int ret = 0;
            public int MinimumOperations(TreeNode root)
            {
                var nums = new List<TreeNode>();
                nums.Add(root);
                Check(nums);
                return ret;
            }

            public void Check(List<TreeNode> nums)
            {
                if (nums.Count == 0)
                    return;

                if (nums.Count > 1)
                {
                    var list = new List<int>();
                    for (int i = 0; i < nums.Count; i++)
                    {
                        list.Add(nums[i].val);
                    }

                    for (int i = 0; i < list.Count; i++)
                    {
                        int n = list[i];
                        int min = n;
                        int idx = i;
                        for (int j = i + 1; j < list.Count; j++)
                        {
                            if (list[j] < min)
                            {
                                min = list[j];
                                idx = j;
                            }
                        }

                        if (i != idx)
                        {
                            //swap
                            list[i] = min;
                            list[idx] = n;
                            ret++;
                        }

                    }
                }


                var next = new List<TreeNode>();
                for (int i = 0; i < nums.Count; i++)
                {
                    if (nums[i].left != null)
                        next.Add(nums[i].left);
                    if (nums[i].right != null)
                        next.Add(nums[i].right);
                }

                Check(next);
            }
        }
    }
}
