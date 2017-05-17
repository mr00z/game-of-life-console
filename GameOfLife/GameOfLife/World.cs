using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class World
    {  
        private List<int> _var1 = new List<int>(), _var2 = new List<int>();
        private readonly string _filename;
        private int[,] world = new int[9, 9];

        public World(string choice, string filename)
        {
            int i1 = int.Parse(choice.ElementAt(0).ToString());
            _var1.Add(int.Parse(choice.ElementAt(0).ToString()));
            _var1.Add(int.Parse(choice.ElementAt(1).ToString()));
            _var2.Add(int.Parse(choice.ElementAt(3).ToString()));
            _var2.Add(int.Parse(choice.ElementAt(4).ToString()));

            _filename = filename;
        }

        public void LoadWorld()
        {
            using (var sr = new StreamReader(_filename))
            {
                for (int i = 0; i < world.GetLength(0); i++)
                {
                    string[] line = Regex.Matches(sr.ReadLine(), @"\d").Cast<Match>().Select(m => m.Value).ToArray();
                    for (int j = 0; j < world.GetLength(1); j++)
                    {
                        world[i, j] = int.Parse(line[j]);
                    }
                }
            }
        }

        public void ShowWorld()
        {
            for (int i = 0; i < world.GetLength(0); i++)
            {
                for (int j = 0; j < world.GetLength(1); j++)
                {
                    var a = world[i, j];
                    Console.Write(world[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
