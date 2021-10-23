using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0006_ZigZag_ConversionCS
{
    //https://leetcode.com/problems/zigzag-conversion/
    //https://docs.google.com/spreadsheets/d/1XdvD0QJ9eMfbBy9-zOH55MZ-jCQnzDVHlmm0cu59k3E/edit?usp=sharing
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            string ret = s.Convert("Apalindromeisaword,phrase,number,orothersequenceofunitsthatcanbereadthesamewayineitherdirection,withgeneralallowancesforadjustmentstopunctuationandworddividers.", 10);
            ret = s.Convert("ABCD", 2);
            ret = s.Convert("ABC", 1);
            ret = s.Convert("PAYPALISHIRING", 3);
            ret = s.Convert("PAYPALISHIRING", 4);
            ret = s.Convert("A", 1);
        }

        public class Solution
        {
            public string Convert(string s, int numRows)
            {
                string ret = "";
                // initialize matrix
                // m = numRows
                // n = ?
                // one size = m + m-2
                int length = s.Length;
                int m = numRows;
                int n = 0;
                if (m > 2)
                {
                    int setSize = m + m - 2;
                    int setCount = length / (setSize);
                    n = (m - 2 + 1) * setCount;
                    int leaveSize = length - (setSize* setCount);
                    if (leaveSize <= m && leaveSize > 0)
                    {
                        n++;
                    }
                    else if(leaveSize > m)
                    {
                        n = n + 1 + (leaveSize - m);
                    }
                }
                else
                {
                    n = (int)Math.Ceiling(length / (double)m);
                }

                StringBuilder sb = new StringBuilder(s.Length);

                // handle m = 1,2

                if (m == 1)
                {
                    sb.Append(s);
                }
                else if (m == 2)
                {
                    for (int i = 0; i < length; i += 2)
                    {
                        sb.Append(s[i]);
                    }
                    for (int i = 1; i < length; i += 2)
                    {
                        sb.Append(s[i]);
                    }
                }
                else
                {

                    char[,] matrix = new char[m, n];

                    int index = 0;
                    bool down = true;
                    int _m = 0;
                    int _n = 0;
                    while (index < length)
                    {
                        char c = s[index];

                        if (down && _m == m)
                        {
                            down = false;
                            _m -= 2;
                            if (_m < 0) _m = 0;
                            _n++;
                        }
                        else if (!down && _m == 0)
                        {
                            down = true;
                            if (_n == n)
                            {
                                _n--;
                            }
                        }
                        if (down)
                        {
                            matrix[_m, _n] = c;
                            _m++;
                        }
                        else
                        {
                            matrix[_m, _n] = c;
                            _m--;
                            if (_m < 0) _m = 0;
                            _n++;
                        }
                        index++;
                    }

                    for (int i = 0; i < m; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            char c = matrix[i, j];
                            if (c != '\0')
                            {
                                sb.Append(c);
                            }
                        }
                    }
                }

                ret = sb.ToString();

                return ret;
            }
        }
    }
}
