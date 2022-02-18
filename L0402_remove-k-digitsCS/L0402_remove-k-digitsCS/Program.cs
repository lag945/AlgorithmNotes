using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0402_remove_k_digitsCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            string ret = s.RemoveKdigits("1432219", 3);
        }
    }

    public class Solution
    {

        public string RemoveKdigits(string num, int k)
        {
            //corner case
            if (k >= num.Length)
                return "0";


            var st = new Stack<int>();

            //its a straigh fwd case of stack
            //we move will from from left, left digit will most signifacnt, it will contribute in max number generation
            //so we will remove number from left

            for (int left = 0; left < num.Length; left++)
            {
                int n = num[left] - '0';
                // Console.WriteLine($"n: {n}");
                while (k > 0 && st.Count > 0 && st.Peek() > n)
                {
                    st.Pop();
                    k--;
                }

                st.Push(n);
            }

            //say number is strictly increasing then k wont be uitlized
            //like "3456", k = 2;
            while (k > 0)
            {
                st.Pop();
                k--;
            }

            //front zero does not make any sense, trim that
            var result = string.Join("", st.ToArray().Reverse()).TrimStart('0');

            //if length is zero,means our result would be "00" or "0" so in this case we have to return zero
            return result.Length == 0 ? "0" : result;
        }

        int min = Int32.MaxValue;
        public string RemoveKdigits2(string num, int k)
        {

            if (num.Length == k)
                return "0";
            else
            {
                Pick(new List<char>(), num, 0, num.Length - k);
                return min.ToString();
            }
        }

        private void Pick(List<char> candidates, string num, int index, int target)
        {
            if (candidates.Count == target)
            {
                string str = new string(candidates.ToArray());
                //Console.WriteLine(str);
                int temp = Convert.ToInt32(str);
                if (temp < min)
                    min = temp;
                return;
            }

            for (int i = index; i < num.Length; i++)
            {
                candidates.Add(num[i]);
                Pick(candidates, num, i + 1, target);
                candidates.RemoveAt(candidates.Count - 1);
            }
        }


    }


}
