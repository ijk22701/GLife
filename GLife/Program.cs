//////////////////////////////////////////////////////////////////////////////////////
//Date         Developer            Description
//2021-02-6   Isaac K         --Creation of file for program
//2021-02-6   Isaac K         --Completion of program

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program is Conway's Game Of Life");
            Console.WriteLine("Select a start pattern and enter the number of generations");
            Console.WriteLine("and the program will simulate that pattern for that number of generations.");
            Console.WriteLine();
            //create a single object for game
            Game game = new Game();
            game.PlayTheGame();
        }
    }
}
