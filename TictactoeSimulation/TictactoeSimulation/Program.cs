using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TictactoeSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int b = 0;
            int draw = 0;
            int size = 10000;
            for (int i = 0; i < size; i++)
            {
                Tictactoe game = new Tictactoe();
                //game.ShowInfo = true;
                string ret = game.Simulate();
                if (ret == "X")
                    a++;
                else if (ret == "O")
                    b++;
                else if (ret == "Draw")
                    draw++;
            }

            Console.WriteLine($"{a}({a/ (double)size * 100}%)-{b}({b / (double)size * 100}%)-{draw}({draw / (double)size * 100}%)");
        }
    }
}
