using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0043_Multiply_StringsCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            //string ret = s.Multiply("2", "3");
            //string ret = s.Multiply("20", "3");
            string ret = s.Multiply("2330", "1000000000000001");
            //string ret = s.Multiply("9133", "0");
        }

        public class Solution
        {
            public string Multiply(string num1, string num2)
            {
                if (num1 == "0" || num2 == "0") return "0";

                int [] res = new int[num1.Length + num2.Length];

                int i = 0;
                for (i = num1.Length - 1; i >= 0; i--)
                {
                    for (int j = num2.Length - 1; j >= 0; j--)
                    {
                        res[i + j + 1] += (Convert.ToInt32(num1[i])-48) * (Convert.ToInt32(num2[j]) - 48);
                        res[i + j] += res[i + j + 1] / 10;
                        res[i + j + 1] %= 10;
                    }
                }

                i = 0;
                string ans = "";
                while (res[i] == 0) i++;
                while (i < res.Length) ans += res[i++].ToString();

                return ans;
            }

            public string Multiply2(string num1, string num2)
            {
                if (num1 == "0" || num2 == "0")
                    return "0";
                else
                {
                    string sum = num1;
                    while (num2 != "1")
                    {
                        sum = Add(sum, num1);
                        num2 = (Convert.ToInt64(num2) - 1).ToString();
                    }
                    return sum;
                }
            }

            public string Add(string num1, string num2)
            {
                int[] nums = new int[201];

                bool next = false;
                for (int i = 0; i < 201; i++)
                {
                    int a = 0;
                    int b = 0;

                    int _i = num1.Length - 1 - i;
                    int _j = num2.Length - 1 - i;

                    if (_i >= 0 && _i < num1.Length)
                    {
                        a = Convert.ToInt32(num1[_i].ToString());
                    }

                    if (_j >= 0 && _j < num2.Length)
                    {
                        b = Convert.ToInt32(num2[_j].ToString());
                    }
                    int sum = a + b;
                    if (next)
                        sum++;
                    nums[i] = sum % 10;
                    next = (sum >= 10);
                }

                StringBuilder sb = new StringBuilder(201);
                bool add = false;
                for (int i = 200; i >= 0; i--)
                {
                    if (nums[i] != 0)
                    {
                        add = true;
                    }
                    if (add)
                    {
                        sb.Append(nums[i]);
                    }
                }

                if (sb.ToString() == "") return "0";
                else
                {
                    return sb.ToString();
                }
            }

        }
    }
}
