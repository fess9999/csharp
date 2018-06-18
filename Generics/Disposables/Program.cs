using System;
using System.IO;

namespace Disposables
{
    class Program
    {
        static void Main()
        {
            var textFile = File.OpenRead(@"myFile.txt");
            PrintFile(textFile);
            textFile.Dispose();

            Console.WriteLine();

            using (var file = File.OpenRead(@"myFile.txt"))
            {
                PrintFile(file);
            }

            Console.ReadLine();
        }

        private static void PrintFile(FileStream file)
        {
            while (file.Position < file.Length)
                Console.Write($"{file.ReadByte()} ");
        }
    }
}