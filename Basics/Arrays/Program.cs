using System;
using System.Xml.Serialization;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleArrays();
            //ArraysOfObjects();
            //Matrix();
            ArrayClassMethods();

            Console.ReadLine();
        }

        private static void ArrayClassMethods()
        {
            var myArray = new[] {2, 4, 6, 8, 1, 0, 5};

            PrintArray(myArray);
            Console.WriteLine(myArray.Length);
            Console.WriteLine(myArray.Rank);

            Console.WriteLine("Sorted array:");
            Array.Sort(myArray);
            PrintArray(myArray);

            Console.WriteLine("Reversed array:");
            Array.Reverse(myArray);
            PrintArray(myArray);

            Console.WriteLine("Copy to another array:");
            var anotherArray = new int[10];
            myArray.CopyTo(anotherArray, 3);
            PrintArray(anotherArray);

            Console.WriteLine("Clear 3 elements from 2:");
            Array.Clear(myArray, 2, 3);
            PrintArray(myArray);

            Console.WriteLine("Resized array:");
            Array.Resize(ref myArray, 10);
            Console.WriteLine(myArray.Length);
            PrintArray(myArray);
        }

        private static void PrintArray(int[] intArray)
        {
            foreach (var i in intArray)
                Console.Write($"{i} ");

            Console.WriteLine();
        }

        private static void Matrix()
        {
            var matrix = new int[6, 6];

            for (var i = 0; i < 6; i++) for (var j = 0; j < 6; j++) matrix[i, j] = i * j;

            for (int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 6; j++) Console.Write(matrix[i, j] + "\t");
                Console.WriteLine();
            } 
        }

        private static void ArraysOfObjects()
        {
            var objectArray = new object[5];

            objectArray[0] = 5;
            objectArray[1] = "myString";
            objectArray[2] = 5.6;
            objectArray[3] = 15.6m;

            foreach (var o in objectArray)
                Console.WriteLine(o);
        }

        private static void SimpleArrays()
        {
            var myInts = new int[3];
            myInts[1] = 100500;

            foreach (var myInt in myInts)
                Console.WriteLine(myInt);

            var myStrings = new[] { "string1", "string2", "string3"};

            Console.WriteLine($"First string: {myStrings[0]}");
            Console.WriteLine($"Last string: {myStrings[2]}");

            //Console.WriteLine($"What'll hapen there?: {myStrings[20]}");
        }
    }
}
