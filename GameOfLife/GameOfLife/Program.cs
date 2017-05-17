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
            World w = new World("23/23", @"C:\Users\Marcin\Source\Repos\game-of-life-console\GameOfLife\GameOfLife\gol.txt");
            w.LoadWorld();
            w.ShowWorld();
        }
    }
}
