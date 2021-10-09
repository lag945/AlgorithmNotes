using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0212_Word_Search_IICS
{
    class Program
    {
        static void Main(string[] args)
        {

            char[][] a = new char[4][];

            a[0] = new char[] { 'o', 'a', 'a', 'n' };
            a[1] = new char[] { 'e', 't', 'a', 'e' };
            a[2] = new char[] { 'i', 'h', 'k', 'r' };
            a[3] = new char[] { 'i', 'f', 'l', 'v' };
            var ret = FindWords(a, new string[] { "oath", "pea", "eat", "rain" });


            /*
            char[][] a = new char[1][];

            a[0] = new char[] { 'a' };
            var ret = FindWords(a, new string[] { "ab" });
            */


            //char[][] a = new char[1][];

            //a[0] = new char[] { 'a', 'a' };
            //var ret = FindWords(a, new string[] { "aaa" });


            /*
            char[][] a = new char[3][];

            a[0] = new char[] { 'a', 'b', 'c', 'e' };
            a[1] = new char[] { 'x', 'x', 'c', 'd' };
            a[2] = new char[] { 'x', 'x', 'b', 'a' };
            var ret = FindWords(a, new string[] { "abc", "abcd" });
            */

        }

        // 40/51, not all pass
        public static IList<string> FindWords(char[][] board, string[] words)
        {
            List<string> ret = new List<string>();
            bool[] arrpearWords = new bool[words.Length];

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    for (int k = 0; k < words.Length; k++)
                    {
                        if (arrpearWords[k])
                        {
                            continue;
                        }
                        else
                        {
                            if (i == 2 && j == 3 && k==1)
                            {
                                Console.WriteLine("in'");
                            }

                            //find 4 adjacent cell
                            bool appear = false;
                            appear = findWord(board, words[k], i, j);
                            Console.WriteLine(string.Format("{0},{1},{2}={3}", i, j, k, appear));
                            arrpearWords[k] = appear;
                        }
                    }
                }
            }

            for (int i = 0; i < arrpearWords.Length; i++)
            {
                if (arrpearWords[i])
                {
                    ret.Add(words[i]);
                }
            }

            return ret;
        }

        public static bool findWord(char[][] board, string word, int i, int j, int index = 0)
        {
            bool ret = false;

            if (i >= 0 && i < board.Length)
            {
                if (j >= 0 && j < board[i].Length)
                {
                    if (board[i][j] == word[index])
                    {
                        Console.WriteLine(i.ToString() + "," + j.ToString() + "=" + word + "[" + index.ToString() + "]");
                        // find next
                        int next = index + 1;
                        char temp = board[i][j];//don't go back
                        board[i][j] = '*';
                        if (next < word.Length)
                        {
                            List<int[]> directions = new List<int[]>();
                            directions.Add(new int[] { i - 1, j });
                            directions.Add(new int[] { i + 1, j });
                            directions.Add(new int[] { i, j - 1 });
                            directions.Add(new int[] { i, j + 1 });
                            for (int k = 0; k < directions.Count; k++)
                            {
                                int a = directions[k][0];
                                int b = directions[k][1];
                                if (a >= 0 && a < board.Length && b >= 0 && b < board[a].Length)
                                {
                                    if (board[a][b] != '*')
                                    {
                                        ret = ret || findWord(board, word, a, b, next);
                                    }
                                }
                            }
                        }
                        else
                        {
                            ret = true;
                        }

                        board[i][j] = temp;
                    }
                    else
                    {
                        ret = false;
                    }
                }
            }

            return ret;
        }

    }
}
