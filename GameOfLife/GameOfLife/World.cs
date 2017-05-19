using DeepEqual.Syntax;
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
            world = new int[10, 10];
            _var1.Add(int.Parse(choice.ElementAt(0).ToString()));
            _var1.Add(int.Parse(choice.ElementAt(1).ToString()));
            _var2.Add(int.Parse(choice.ElementAt(3).ToString()));
            if(choice.Length>4) _var2.Add(int.Parse(choice.ElementAt(4).ToString()));

            _filename = filename;

            _length1 = world.GetLength(0);
            _length2 = world.GetLength(1);
        }

        public void LoadWorld()
        {
            using (var sr = new StreamReader(_filename))
            {
                for (int i = 0; i < _length1; i++)
                {
                    string[] line = Regex.Matches(sr.ReadLine(), @"\d").Cast<Match>().Select(m => m.Value).ToArray();
                    for (int j = 0; j < _length2; j++)
                    {
                        world[i, j] = int.Parse(line[j]);
                    }
                }
            }
        }

        public void ShowWorld()
        {
            for (int i = 0; i < _length1; i++)
            {
                for (int j = 0; j < _length2; j++)
                {
                    var a = world[i, j];
                    Console.Write(world[i,j]+" ");
                }
                Console.WriteLine();
            }
        }

        public void PlayGame()
        {
            int iter = 0;
            while (true)
            {
                int[,] next = new int[10, 10];
                for (int i = 0; i < _length1; i++)
                {
                    for (int j = 0; j < _length2; j++)
                    {
                        if (IsAlive(i, j)) next[i, j] = 1;
                        else next[i, j] = 0;
                    }
                }
                if (world.IsDeepEqual(next)) break;
                else
                {
                    world = next;
                    ShowWorld();
                    Console.WriteLine();
                }
                iter++;
                if (iter == 20) break;
            }
            
        }

        private bool IsAlive(int index1, int index2)
        {
            int neighbours = 0;
            int[,] neighbourhood = CreateNeighbourhood(index1, index2);

            for (int i = 0, ind1 = index1 - 1; i < neighbourhood.GetLength(0); i++, ind1++)
            {
                for (int j = 0, ind2 = index2 - 1; j < neighbourhood.GetLength(1); j++, ind2++)
                {
                    if (neighbourhood[i, j] == 1) neighbours+=world[ind1, ind2];
                }
            }


            if (world[index1, index2] == 1)
            {
                int l = _var1.Count();

                if (l == 1)
                {
                    if (neighbours == _var1.ElementAt(0)) return true;
                    else return false;
                }
                else
                {
                    if (neighbours == _var1.ElementAt(0)||neighbours==_var1.ElementAt(1)) return true;
                    else return false;
                }
            }
            else
            {
                int l = _var2.Count();

                if (l == 1)
                {
                    if (neighbours == _var2.ElementAt(0)) return true;
                    else return false;
                }
                else
                {
                    if (neighbours == _var2.ElementAt(0) || neighbours == _var2.ElementAt(1)) return true;
                    else return false;
                }
            }
        }

        private int[,] CreateNeighbourhood(int index1, int index2)
        {
            int[,] neighbourhood = new int[3, 3];

            for (int i = 0, ind1 = index1 -1; i < 3; i++, ind1++)
            {
                for (int j = 0, ind2 = index2-1; j < 3; j++, ind2++)
                {
                    if (ind1 < 0 || ind1 > 9 || ind2 < 0 || ind2 > 9) neighbourhood[i, j] = 0;
                    else if (ind1 == index1 && ind2 == index2) neighbourhood[i, j] = 0;
                    else neighbourhood[i, j] = 1;
                }
            }
            return neighbourhood;
        }

    }
}
