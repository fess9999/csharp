using System;

namespace Loops
{
    class Program
    {
        static void Main()
        {
            //ForLoop();
            //ForeachLoop();
            WhileLoop();

            Console.ReadLine();
        }

        private static void ForLoop()
        {
            for (var i = 0; i < 5; i++)
                Console.WriteLine($"Number is {i}");
        }

        private static void WhileLoop()
        {
            var i = 0;

            while (i < 10)
            {
                Console.WriteLine(i++);
            }

            do
            {
                Console.WriteLine(i--);
            } while (i >= 0);
        }

        private static void ForeachLoop()
        {
            var cars = new[] { "Ford", "BMW", "Honda", "Toyota" };

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }

        }
    }
}
