using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0037_sudoku_solverCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            char[][] board = new char[9][];
            board[0] = new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' };
            board[1] = new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' };
            board[2] = new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' };
            board[3] = new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' };
            board[4] = new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' };
            board[5] = new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' };
            board[6] = new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' };
            board[7] = new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' };
            board[8] = new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' };
            s.SolveSudoku(board);
        }

        //https://leetcode.com/problems/sudoku-solver
        // backtracking
        // T: O(N!^N) S:(1)
        public class Solution
        {
            List<HashSet<char>> c1 = new List<HashSet<char>>();
            List<HashSet<char>> c2 = new List<HashSet<char>>();
            List<HashSet<char>> c3 = new List<HashSet<char>>();
            char[] items = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            List<Node> nodes = new List<Node>(9 * 9);

            public class Node
            {
                public char val = '.';
                public int x = 0;
                public int y = 0;
                public HashSet<char> c1 = null;
                public HashSet<char> c2 = null;
                public HashSet<char> c3 = null;

                public bool IsOk(char c)
                {
                    bool ret = true;
                    ret = (!c1.Contains(c)) && (!c2.Contains(c)) && (!c3.Contains(c));
                    return ret;
                }

                public void Set(char c)
                {
                    c1.Remove(val);
                    c2.Remove(val);
                    c3.Remove(val);

                    c1.Add(c);
                    c2.Add(c);
                    c3.Add(c);
                    val = c;
                }
            }
            public void SolveSudoku(char[][] board)
            {
                //init c1 - c3

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        //if (board[i][j] != '.')
                        {
                            if (c1.Count <= i)
                            {
                                c1.Add(new HashSet<char>());
                            }
                            c1[i].Add(board[i][j]);
                            if (c2.Count <= j)
                            {
                                c2.Add(new HashSet<char>());
                            }
                            c2[j].Add(board[i][j]);

                            int c3index = (i / 3) * 3 + (j / 3);

                            if (c3.Count <= c3index)
                            {
                                c3.Add(new HashSet<char>());
                            }
                            c3[c3index].Add(board[i][j]);

                            Node node = new Node();
                            node.x = i;
                            node.y = j;
                            node.val = board[i][j];
                            node.c1 = c1[i];
                            node.c2 = c2[j];
                            node.c3 = c3[c3index];
                            nodes.Add(node);
                        }

                    }
                }

                bool r = Run();

                int cnt = 0;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        board[i][j] = nodes[cnt].val;
                        cnt++;
                    }
                }
            }

            private bool Run(int index = 0)
            {
                bool ret = false;
                if (index >= nodes.Count)
                    return true;

                if (nodes[index].val != '.')
                {
                    return Run(index + 1);
                }

                foreach (char c in items)
                {
                    if (nodes[index].IsOk(c))
                    {
                        nodes[index].Set(c);
                        if (Run(index + 1))
                        {
                            return true;
                        }
                        nodes[index].Set('.');
                    }
                }

                return ret;
            }

        }
    }
}
