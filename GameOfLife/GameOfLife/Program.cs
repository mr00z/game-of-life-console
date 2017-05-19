using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Specify rules of the game");
            string rules = Console.ReadLine();
            World w = new World(rules, @"C:\Users\Marcin\Source\Repos\game-of-life-console\GameOfLife\GameOfLife\gol.txt");
            w.LoadWorld();
            w.ShowWorld();
            Console.WriteLine();
            w.PlayGame();
        }
    }
}
