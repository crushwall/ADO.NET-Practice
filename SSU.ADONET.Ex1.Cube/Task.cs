using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;

namespace SSU.ADONET.Ex1.Cube
{
    public static class Task
    {
        public static void Start()
        {
            const string input4PointsPath = "../../input/cube/4 points.txt";
            const string input8PointsPath = "../../input/cube/8 points.txt";
            const string input5PointsPath = "../../input/cube/5 points.txt";

            Console.WriteLine("Ex. 1");
            CreateCube(input4PointsPath);

            Console.WriteLine($"{Environment.NewLine}Ex. 2");
            CreateCube(input8PointsPath);

            Console.WriteLine($"{Environment.NewLine}Ex. 3");
            CreateCube(input5PointsPath);

            ///////////////////////////////////////
            /// CUBE BY 1 POINT AND SIDE LENGTH ///
            ///////////////////////////////////////

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{Environment.NewLine}cube by 1 point and side length:");
            Console.ForegroundColor = ConsoleColor.Gray;

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            bool correct = false;

            while (!correct)
            {
                Console.Write("Enter point coord: ");
                correct = true;

                string[] tmpStr = Console.ReadLine().Split();
                if (tmpStr.Length != 3)
                {
                    correct = false;
                    continue;
                }

                correct = double.TryParse(tmpStr[0], out p1) ? correct : false;
                correct = double.TryParse(tmpStr[1], out p2) ? correct : false;
                correct = double.TryParse(tmpStr[2], out p3) ? correct : false;
            }

            double sideLength = 0;

            correct = false;
            while (!correct)
            {
                Console.Write("Enter side length: ");
                correct = double.TryParse(Console.ReadLine(), out sideLength);
            }
            sideLength = Math.Abs(sideLength);

            CubeFactory cubeFactory = new CubeFactory();
            Cube cube = new Cube();

            try
            {
                cube = cubeFactory.CreateCubeFromOnePointAndsideLength(new Point(p1, p2, p3), sideLength);

                Console.WriteLine($"\tSquare: {cube.Square}{Environment.NewLine}\tVolume: {cube.Volume}{Environment.NewLine}");
            }

            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        private static Point[] GetPointsFromFile(string path)
        {
            string[] tmpStr;
            List<Point> points = new List<Point>(4);

            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    tmpStr = reader.ReadLine().Split();

                    double p1 = 0;
                    double p2 = 0;
                    double p3 = 0;

                    bool correct = true;

                    correct = double.TryParse(tmpStr[0], out p1) ? correct : false;
                    correct = double.TryParse(tmpStr[1], out p2) ? correct : false;
                    correct = double.TryParse(tmpStr[2], out p3) ? correct : false;

                    if (!correct)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorrect input file format.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    points.Add(new Point(p1, p2, p3));
                }
            }

            return points.ToArray();
        }

        private static void CreateCube(string path)
        {
            Point[] points = GetPointsFromFile(path);
            bool check = ValidateCubePoints(points);

            Console.WriteLine($"cube by {points.Length} points:");
            CubeFactory cubeFactory = new CubeFactory();
            Cube cube;

            if (check)
            {
                try
                {
                    cube = cubeFactory.CreateCubeFromPoints(points);

                    Console.WriteLine($"\tSquare: {cube.Square}{Environment.NewLine}\tVolume: {cube.Volume}{Environment.NewLine}");
                }

                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(e.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }

        private static bool ValidateCubePoints(Point[] pounts)
        {
            var validator = new CubePointsValidator();
            ValidationResult results = validator.Validate(pounts);

            if (results.IsValid)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Cube points are successfully validated.");
                Console.ForegroundColor = ConsoleColor.Gray;
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed.");
                Console.ForegroundColor = ConsoleColor.Gray;

                foreach (ValidationFailure failure in results.Errors)
                {
                    Console.WriteLine(failure.ErrorMessage);
                }

                return false;
            }
        }
    }
}
