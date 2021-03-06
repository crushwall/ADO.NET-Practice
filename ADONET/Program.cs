using Shapes;
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
                using(StreamWriter writer = new StreamWriter(outPath))
                {
                    //Cube c = new Cube(new Point(-1.2, 5, 4), 2.7, true, true, true);
                    Cube c = new Cube(new Point(), 5, true, false, true);

                    writer.Write(c);
                }
            }
        }
    }
}
