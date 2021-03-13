using CubeExceptions;
using Shapes;
using System;
using System.Collections.Generic;
using System.IO;

namespace ADONET
{
    class Program
    {
        static void Main(string[] args)
        {
            string inPath = "../../points.txt";
            string outPath = "../../output.txt";

            using (StreamReader reader = new StreamReader(inPath))
            {
                string[] tmp;
                List<Point> points = new List<Point>(8);

                while (!reader.EndOfStream)
                {
                    tmp = reader.ReadLine().Split();
                    points.Add(new Point(double.Parse(tmp[0]), double.Parse(tmp[1]), double.Parse(tmp[2])));
                }

                Cube cube = new Cube();
                try
                {
                    cube = new Cube(points);

                }
                catch(InvalidNumberOfPointsException e)
                {
                    Console.WriteLine("Invalid input.");
                }

                using (StreamWriter writer = new StreamWriter(outPath))
                {
                    //Cube c = new Cube(new Point(-1.2, 5, 4), 2.7, true, true, true);
                    Cube c = new Cube(new Point(), 5);

                    try
                    {
                        writer.Write(c);

                    }
                    catch(NullReferenceException e)
                    {
                        Console.WriteLine("Cube is empty.");
                    }
                }

                Console.WriteLine($"Volume: {cube.Volume}\nSquare: {cube.Square}");
            }
        }
    }
}
