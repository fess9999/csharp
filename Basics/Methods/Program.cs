using System;

namespace Basics
{
    class Program
    {
        static void Main()
        {
            //by value example
            int x = 9, y = 10;
            var sum = Add(x, y);
            Console.WriteLine(sum);

            //ref example
            var value = "Too long string for our applications";

            var result = CutTheLine(value);
            Console.WriteLine($"Original value: {value}");
            Console.WriteLine($"Result value: {result}");

            //out example
            var divisionResult = TryDivide(x, y, out var d);
            Console.WriteLine(divisionResult);
            Console.WriteLine(d);

            //params example
            var f = Multiply(x, 5, y, 6);
            Console.WriteLine(f);

            var formattedString = string.Format("Value here: {0} and another one there: {1}", 5, "VALUE", 444);
            Console.WriteLine(formattedString);

            //overload example
            var a = 34.3;
            var b = 244.3;

            var c = Add(a, b);
            Console.WriteLine(c);

            Console.ReadLine();
        }

        public static string CutTheLine(string str, int count = 15)
        {
            str = str.Remove(count);
            return str;
        }

        public static bool TryDivide(int x, int y, out int result)
        {
            result = 0;

            if (y == 0) return false;

            result = x / y;
            return true;
        }

        public static int Multiply(params int[] values)
        {
            var result = 1;
            foreach (var value in values)
            {
                result *= value;
            }

            return result;
        }

        //bad overload
        //public static void Add(int x, int y)
        //{

        //}

        public static int Add(int x, int y)
        {
            int result = x + y;
            x = 100500;
            y = 432423;
            return result;
        }

        public static double Add(double x, double y)
        {
            return x + y;
        }
    }
}
