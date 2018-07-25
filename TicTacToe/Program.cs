using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        public static void draw(TTTLogic logic)
        {
            Console.Clear();
            Console.WriteLine("Current Game Board -------------");

            if(logic.turn() == TTTLogic.XO.O)
            {
                Console.WriteLine("o is turn:");
            }
            else if (logic.turn() == TTTLogic.XO.X)
            {
                Console.WriteLine("x is turn:");
            }

            for (int row=0; row<3; row++)
            {
                for(int col=0; col<3; col++)
                {
                   TTTLogic.XO xo =logic.Getpiece(col, row);
                    if(xo == TTTLogic.XO.Empty)
                    {
                        Console.Write(" ");
                    }
                    if(xo == TTTLogic.XO.O)
                    {
                        Console.Write("o");
                    }
                    if(xo == TTTLogic.XO.X)
                    {
                        Console.Write("x");
                    }
                    
                }
                Console.WriteLine("|");
            }
        }
        static void OnError()
        {
            throw new Exception("Something done messed up");
        }
        static void Main(string[] args)
        {
            TTTLogic ttt = new TTTLogic(Program.OnError);

            int x;
            int y;

            while(true)
            {
                draw(ttt);
                do
                {
                    Console.WriteLine("Enter your X position: ");
                    x = Convert.ToInt32(Console.ReadLine());
                } while (!TTTLogic.IsValidCol(x));

                do
                {
                    Console.WriteLine("Enter your Y position: ");
                    y = Convert.ToInt32(Console.ReadLine());
                } while (!TTTLogic.IsValidRow(y));

                // it is guaranteed that x and y are valid rows/columns, or else the loops wouldn't have exited

                ttt.placingpiece(x, y);
            }
            

                
        }
    }
}
