using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0051_N_QueensCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            IList<IList<string>> ret =s.SolveNQueens(4);
        }

        //https://leetcode.com/problems/n-queens/

        public class Solution
        {
            List<List<string>> answer = null;
            public IList<IList<string>> SolveNQueens(int n)
            {
                answer = new List<List<string>>();
                List<string> board = new List<string>();
                string init = "";
                for (int i = 0; i < n; i++)
                    init += ".";
                for (int i = 0; i < n; i++)
                {
                    board.Add(init);
                }

                Dfs(board, 0);

                return answer.ToArray();
            }

            public void Dfs(List<string> board, int x)
            {
                if (x > board.Count)
                    return;

                for (int y = 0; y < board.Count; y++)
                {
                    char[] ch = board[x].ToCharArray();
                    ch[y] = 'Q';
                    board[x] = new string(ch);
                    if (Valid(board, x, y))
                    {
                        if (x == board.Count - 1)
                        {
                            answer.Add(board.ToList());
                        }
                        else
                        {
                            Dfs(board, x+1);
                        }
                    }
                    ch[y] = '.';
                    board[x] = new string(ch);
                }
            }

            public bool Valid(List<string> board, int x, int y)
            {
                bool ret = true;

                //bottom doesn't set up yet.
                int _x = 0;
                int _y = 0;
                //top check
                _y = y;
                for (_x = 0; _x < x; _x++)
                {
                    if (board[_x][_y] == 'Q')
                        return false;
                }
                //left top check
                _x = x - 1;
                _y = y - 1;
                while (_x >= 0 && _y >= 0)
                {
                    if (board[_x][_y] == 'Q')
                        return false;
                    _x--;
                    _y--;
                }
                //right top check
                _x = x - 1;
                _y = y + 1;
                while (_x >=0 && _y < board.Count)
                {
                    if (board[_x][_y] == 'Q')
                        return false;
                    _x--;
                    _y++;
                }

                return ret;
            }
        }
    }
}
