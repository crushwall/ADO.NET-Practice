using FluentValidation.Results;
using Shapes;
using System;
using System.Collections.Generic;
using System.IO;

namespace ADONET
{
    public static class Tasks
    {
        static string outputPath = "../../output.txt";

        public static void Task1()
        {
            const string input4PointsPath = "../../input/4 points.txt";
            const string input8PointsPath = "../../input/8 points.txt";
            const string input5PointsPath = "../../input/5 points.txt";

            ////////////////////////
            /// CUBE BY 4 POINTS ///
            ////////////////////////

            Console.WriteLine("cube by 4 points:");
            Cube cube = new Cube(GetPointsFromFile(input4PointsPath));

            var validator = new CubeValidator();
            ValidationResult results = validator.Validate(cube);

            if (results.IsValid)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Successfully validated.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.WriteLine($"\tSquare: {cube.Square}\n\tVolume: {cube.Volume}\n");

            ////////////////////////
            /// CUBE BY 8 POINTS ///
            ////////////////////////

            Console.WriteLine("cube by 8 points:");
            cube = new Cube(GetPointsFromFile(input8PointsPath));

            validator = new CubeValidator();
            results = validator.Validate(cube);

            if (results.IsValid)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Successfully validated.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.WriteLine($"\tSquare: {cube.Square}\n\tVolume: {cube.Volume}\n");

            ///////////////////////////////////////
            /// CUBE BY 1 POINT AND SIDE LENGTH ///
            ///////////////////////////////////////

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("cube by 1 point and side length:");
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

            cube = new Cube(new Point(p1, p2, p3), sideLength);

            validator = new CubeValidator();
            results = validator.Validate(cube);

            if (results.IsValid)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Successfully validated.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.WriteLine($"\tSquare: {cube.Square}\n\tVolume: {cube.Volume}");
            Console.WriteLine($"points:\n{cube}\n");

            ////////////////////////
            ///// INCORRECT DATA ///
            ////////////////////////
            
            //Console.WriteLine("cube by 5 points:");
            //cube = new Cube(GetPointsFromFile(input5PointsPath));

            //validator = new CubeValidator();
            //results = validator.Validate(cube);

            //if (results.IsValid)
            //{
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.WriteLine("Successfully validated.");
            //    Console.ForegroundColor = ConsoleColor.Gray;
            //}
            //else
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("Failed.");
            //    Console.ForegroundColor = ConsoleColor.Gray;
            //}

            //Console.WriteLine($"\tSquare: {cube.Square}\n\tVolume: {cube.Volume}\n");
        }

        static private Point[] GetPointsFromFile(string path)
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

                if (points.Count != 4 && points.Count != 8)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect input file points count.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }

            return points.ToArray();
        }
    }
}
