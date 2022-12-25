using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L6270_take_k_of_each_character_from_left_and_rightCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var answer = s.TakeCharacters("aabaaaacaabc", 2);
            bool r = 8 == answer;

            //var answer = s.TakeCharacters("abc", 1);
            //bool r = 3 == answer;
        }

        public class Solution
        {

            //this solution OOM
            public int TakeCharacters(string s, int k)
            {
                if (k == 0)
                    return 0;
                if (s.Length < k * 3)
                    return -1;


                Queue<int[]> queue = new Queue<int[]>();

                //left,right,[left,right],total
                queue.Enqueue(new int[] { 0, s.Length - 1, 0, 1,0,0,0 });
                queue.Enqueue(new int[] { 0, s.Length - 1, 1, 1,0,0,0 });

                while (queue.Count > 0)
                {
                    var run = queue.Dequeue();

                    int a = run[4];
                    int b = run[5];
                    int c = run[6];


                    if (run[2] == 0)
                    {
                        if (s[run[0]] == 'a')
                            a++;
                        if (s[run[0]] == 'b')
                            b++;
                        if (s[run[0]] == 'c')
                            c++;
                    }
                    else
                    {
                        if (s[run[1]] == 'a')
                            a++;
                        if (s[run[1]] == 'b')
                            b++;
                        if (s[run[1]] == 'c')
                            c++;
                    }

                    //Console.WriteLine($"{a}-{b}-{c}");

                    if (a >= k && b >= k && c >= k)
                        return run[3];

                    int left = run[0];
                    int right = run[1];

                    if (left + 1 <= right)
                    {
                        queue.Enqueue(new int[] { run[0] + (run[2] == 0 ? 1 : 0), run[1]-(run[2] == 1 ? 1 : 0), 0, run[3] + 1, a, b, c });
                    }
                    if (right - 1 >= left)
                    {
                        queue.Enqueue(new int[] { run[0] + (run[2] == 0 ? 1 : 0), run[1] - (run[2] == 1 ? 1 : 0), 1, run[3] + 1,a,b,c });
                    }
                }


                return -1;
            }

        }
    }
}
