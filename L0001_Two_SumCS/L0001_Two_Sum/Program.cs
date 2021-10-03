using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0001_Two_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 3, 2, 4 };
            int target = 6;
            int[] ret = Solution3(nums, target);
            if (ret[0] == 1 && ret[1] == 2)
            {
                Console.WriteLine("pass");
            }
            else
            {
                Console.WriteLine("error");
            }
        }

        //Approach 1: Brute Force 暴力法
        static public int[] Solution1(int[] nums, int target)
        {
            int[] ret = new int[2];

            bool find = false;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (nums[i] + nums[j] == target)
                    {
                        ret[0] = i;
                        ret[1] = j;
                        find = true;
                        break;
                    }
                }
                if (find)
                {
                    break;
                }
            }

            if (!find)
            {
                throw new Exception();
            }
            return ret;
        }

        //Approach 2: Two-pass Hash Table
        static public int[] Solution2(int[] nums, int target)
        {
            int[] ret = new int[2];

            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!map.ContainsKey(nums[i]))
                {
                    map.Add(nums[i], i);
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int sub = target - nums[i];
                if (map.ContainsKey(sub))
                {
                    ret[0] = i;
                    ret[1] = map[sub];
                    if (ret[0]!=ret[1])
                    {
                        break;
                    }
                }
            }

            return ret;
        }

        //One-pass Hash Table
        static public int[] Solution3(int[] nums, int target)
        {
            int[] ret = new int[2];

            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!map.ContainsKey(nums[i]))
                {
                    map.Add(nums[i], i);
                }

                int sub = target - nums[i];
                if (map.ContainsKey(sub))
                {
                    ret[0] = i;
                    ret[1] = map[sub];
                    if (ret[0] != ret[1])
                    {
                        if (ret[0] > ret[1])
                        {
                            int tmp = ret[0];
                            ret[0] = ret[1];
                            ret[1] = tmp;
                        }
                        break;
                    }

                }
            }

            return ret;
        }


    }
}
