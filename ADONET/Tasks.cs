using CubeExceptions;
using Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET
{
    public static class Tasks
    {
         static string outputPath = "../../output.txt";

        public static void Task1()
        {
            const string in4PointsPath = "../../input/4 points.txt";
            const string in8PointsPath = "../../input/8 points.txt";

            using (StreamReader reader = new StreamReader(in4PointsPath))
            {
                string[] tmpStr;
                List<Point> points = new List<Point>(8);

                while (!reader.EndOfStream)
                {
                    tmpStr = reader.ReadLine().Split();
                    double p1, p2, p3;

                    bool correct = true;

                    correct = double.TryParse(tmpStr[0], out p1) ? correct : false;
                    correct = double.TryParse(tmpStr[1], out p2) ? correct : false;
                    correct = double.TryParse(tmpStr[2], out p3) ? correct : false;

                    if (!correct)
                    {
                        Console.WriteLine("Incorrect input file format.");
                    }

                    points.Add(new Point(p1, p2, p3));
                }

                Cube cube = new Cube();
                try
                {
                    cube = new Cube(points);

                }
                catch (InvalidNumberOfPointsException e)
                {
                    Console.WriteLine("Invalid input.");
                }

                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    //Cube c = new Cube(new Point(-1.2, 5, 4), 2.7, true, true, true);
                    //Cube c = new Cube(new Point(), 5);

                    try
                    {
                        writer.Write(cube);

                    }
                    catch (NullReferenceException e)
                    {
                        Console.WriteLine("Cube is empty.");
                    }
                }

                Console.WriteLine($"Volume: {cube.Volume}\nSquare: {cube.Square}");
            }
        }
    }
}
