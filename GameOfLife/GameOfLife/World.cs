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
        private int[,] world;
        private int _length1, _length2;

        public World(string choice, string filename)
        {
            world = new int[9, 9];
            _var1.Add(int.Parse(choice.ElementAt(0).ToString()));
            _var1.Add(int.Parse(choice.ElementAt(1).ToString()));
            _var2.Add(int.Parse(choice.ElementAt(3).ToString()));
            _var2.Add(int.Parse(choice.ElementAt(4).ToString()));

            _filename = filename;

            _length1 = world.GetLength(0);
            _length2 = world.GetLength(1);
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

        public void performRound()
        {
            int[,] next = new int[9, 9];
            for (int i = 0; i < world.GetLength(0); i++)
            {
                for (int j = 0; j < world.GetLength(1); j++)
                {
                    if (isAlive(i, j)) next[i, j] = 1;
                    else next[i, j] = 0;
                }
            }
            world = next;
            ShowWorld();
        }

        private bool isAlive(int index1, int index2)
        {
            int neighbours;
            if (index1==0 && index2 == 0)
            {
                neighbours = countTopLeft();
                if (_var1.Contains(neighbours)) return true;
                else return false;
            }
            else if (index1==0 && index2 == 9)
            {
                neighbours = countTopRight();
                if (_var1.Contains(neighbours)) return true;
                else return false;
            }
            else if (index1 == 9 && index2 == 0)
            {
                neighbours = countDownLeft();
                if (_var1.Contains(neighbours)) return true;
                else return false;
            }
            else if (index1 == 9 && index2 == 9)
            {
                neighbours = countDownRight();
                if (_var1.Contains(neighbours)) return true;
                else return false;
            }

        }

        private int countTopLeft()
        {
            return world[0, 1] + world[1, 0] + world[1, 1];
        }

        private int countTopRight()
        {
            return world[0, 8] + world[1, _length2-1] + world[1, _length2];
        }

        private int countDownLeft()
        {
            return world[_length1-1, 0] + world[_length1-1, 1] + world[_length1, 0];
        }

        private int countDownRight()
        {
            return world[_length1, _length2-1] + world[_length1-1, _length2-1] + world[_length1-1, _length2];
        }
    }
}
