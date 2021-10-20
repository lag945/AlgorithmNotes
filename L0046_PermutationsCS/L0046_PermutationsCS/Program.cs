using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0046_PermutationsCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var ret = s.Permute(new int[] { 1, 2, 3 });
            ret = s.Permute(new int[] { 0 , 1 });
            ret = s.Permute(new int[] { 1 });
        }

        public class Solution
        {
            public IList<IList<int>> Permute(int[] nums)
            {
                List<List<int>> ret = new List<List<int>>();
                AddNext(nums, 0, ref ret);
                return ret.ToArray();
            }

            public void AddNext(int[] nums, int index, ref List<List<int>> ret)
            {
                if (index >= nums.Length) 
                    return;

                if (index == 0)
                {
                    for (int i = 0; i < nums.Length; i++)
                    {
                        List<int> list = new List<int>();
                        list.Add(nums[i]);
                        ret.Add(list);
                    }
                }
                else
                {
                    List<List<int>> _ret = new List<List<int>>();
                    for (int i = 0; i < ret.Count; i++)
                    {
                        List<int> list = ret[i];

                        for (int j = 0; j < nums.Length; j++)
                        {
                            bool exists = false;
                            for (int k = 0; k < list.Count; k++)
                            {
                                if (nums[j] == list[k])
                                {
                                    exists = true;
                                    break;
                                }
                            }

                            if (!exists)
                            {
                                List<int> _list = new List<int>();
                                _list.AddRange(list);
                                _list.Add(nums[j]);
                                _ret.Add(_list);
                            }
                        }
                    }

                    ret = _ret;
                }
                AddNext(nums, ++index, ref ret);
            }
        }
    }
}
