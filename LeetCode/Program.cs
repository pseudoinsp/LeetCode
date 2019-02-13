using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    // https://leetcode.com/problems/number-of-islands/
    class Program
    {
        static void Main(string[] args)
        {
            string[] frt = File.ReadAllLines("../../input.txt");

            ParseInput(frt);

            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    if (_map[i, j]) islandCount++;

                    VisitCoordinate(i, j);
                }
            }

            Console.WriteLine($"Islands: {islandCount}");

            Console.ReadKey();
        }

        static void ParseInput(string[] lines)
        {
            var lineLength = lines.First().Length;
            var lineCount = lines.Count();

            _map = new bool[lineCount, lineLength];

            for (int i = 0; i < lineCount; i++)
            {
                for (int j = 0; j < lineLength; j++)
                {
                    if (lines[i][j] == '1')
                    {
                        _map[i, j] = true;
                    }
                    else
                    {
                        _map[i, j] = false;
                    }
                }
            }
        }

        static public void VisitCoordinate(int x, int y)
        {
            PrintMap();

            if (!_map[x, y]) return;

            _map[x, y] = false;

            if (x > 0 && _map[x - 1, y])
            {
                VisitCoordinate(x - 1, y);
            }
            if (x < _map.GetLength(0)-1 && _map[x + 1, y])
            {
                VisitCoordinate(x + 1, y);
            }
            if (y > 0 && _map[x, y-1])
            {
                VisitCoordinate(x, y-1);
            }
            if (y < _map.GetLength(1)-1 && _map[x, y + 1])
            {
                VisitCoordinate(x, y + 1);
            }
        }

        static void PrintMap()
        {
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    if (_map[i, j])
                        Console.Write(1);
                    else
                        Console.Write(0);
                    
                }

                Console.WriteLine();
            }
        }

        static bool[,] _map;

        static int islandCount = 0;
    }
}
