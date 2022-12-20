using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TictactoeSimulation
{
    class Tictactoe
    {
        /// <summary>
        /// 丼字盤，index對應鍵盤 0-9，index=0未使用
        /// </summary>
        int[] board = new int[10];
        static Random rnd = new Random();

        int[][] winner_path = new int[8][];

public bool ShowInfo { get; set; } = false;

        public Tictactoe()
        {
            InitWinnerPath();
        }

        private void InitWinnerPath()
        {
            winner_path[0] = new int[] { 1, 2, 3 };
            winner_path[1] = new int[] { 4, 5, 6 };
            winner_path[2] = new int[] { 7, 8, 9 };
            winner_path[3] = new int[] { 1, 4, 7 };
            winner_path[4] = new int[] { 2, 5, 8 };
            winner_path[5] = new int[] { 3, 6, 9 };
            winner_path[6] = new int[] { 1, 5, 9 };
            winner_path[7] = new int[] { 3, 5, 7 };
        }

        /// <summary>
        /// 清洗棋盤，全設為0
        /// </summary>
        private void RefreshBoard()
        {
            for (int i = 0; i < board.Length; i++)
                board[i] = 0;
        }

        /// <summary>
        /// 先手(X=1)
        /// </summary>
        /// <returns></returns>
        private int First()
        {
            return rnd.Next(9 + 1);
        }

        /// <summary>
        /// 後手(O=2)
        /// </summary>
        /// <returns></returns>
        private int Second()
        {
            //找要贏的，下最後一步
            foreach (var wp in winner_path)
            {
                var r = CountState(wp);
                if (r[2] == 2 && r[0] == 1)
                {
                    foreach (var p in wp)
                    {
                        if (board[p] == 0)
                            return p;
                    }
                }
            }

            //找對方要贏的，封
            foreach (var wp in winner_path)
            {
                var r = CountState(wp);
                if (r[1] == 2 && r[0] == 1)
                {
                    foreach (var p in wp)
                    {
                        if (board[p] == 0)
                            return p;
                    }
                }
            }

            //統計找對方有1子的，取最大的
            int[] sum = new int[10];
            foreach (var wp in winner_path)
            {
                var r = CountState(wp);
                if (r[1] == 1 && r[0] == 2)
                {
                    foreach (var p in wp)
                    {
                        if (board[p] == 0)
                        {
                            sum[p]++;
                        }
                    }
                }
            }

            int max = sum.Max();

            //優先走中，可以降2%
            if (sum[5] == max)
                return 5;
            
            for (int i = 1; i <= 9; i++)
            {
                if (sum[i] == max)
                    return i;
            }

            //隨便選一個能走的
            var path = GetPath();

            return path[0];
        }

        /// <summary>
        /// 取得所有可走的路徑
        /// </summary>
        /// <returns></returns>
        private List<int> GetPath()
        {
            List<int> ret = new List<int>();
            for (int i = 1; i <= 9; i++)
            {
                if(board[i]==0)
                    ret.Add(i);
            }

            return ret;
        }

        /// <summary>
        /// 開始模擬到完賽
        /// </summary>
        /// <returns></returns>
        public string Simulate()
        {
            string ret = Check();

            int cnt = 0;

            HashSet<int> roads = new HashSet<int>();
            for (int i = 1; i <= 9; i++)
                roads.Add(i);

            while (ret == "Pending" && cnt < 9)
            {
                int road = 0;

                do
                {
                    if (cnt % 2 == 0)
                        road = First();
                    else
                        road = Second();
                }
                while (!roads.Remove(road));

                board[road] = cnt % 2 == 0 ? 1 : 2;
                cnt++;
                ret = Check();
                if(ShowInfo)
                    PrintBoard();
            }

            if(ShowInfo)
                Console.WriteLine(ret);
            return ret;
        }

        /// <summary>
        /// 印出棋盤
        /// </summary>
        public void PrintBoard()
        {
            Console.WriteLine($"---");
            Console.WriteLine($"{board[7]}{board[8]}{board[9]}");
            Console.WriteLine($"{board[4]}{board[5]}{board[6]}");
            Console.WriteLine($"{board[1]}{board[2]}{board[3]}");
        }

        /// <summary>
        /// 檢查目前盤面狀態
        /// </summary>
        /// <returns></returns>
        public String Check()
        {
            int w = 0;

            for (int i = 0; i < winner_path.Length; i++)
            {
                var r = CountState(winner_path[i]);
                if (r[1] == 3)
                {
                    w = 1;
                    break;
                }
                else if (r[2] == 3)
                {
                    w = 2;
                    break;
                }
            }

            if (w == 1)
                return "X";
            else if (w == 2)
                return "O";
            else
            {
                return GetPath().Count == 0 ? "Draw" : "Pending";
            }
        }

        /// <summary>
        /// 目標盤位統計(0:未下子、1:X、2:O)
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        int[] CountState(int[] target)
        {
            int[] ret = new int[3];

            foreach (int t in target)
            {
                ret[board[t]]++;
            }

            return ret;
        }

    }
}
