using System;
using System.Runtime.InteropServices;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //UnhandledException();
            HandleException();

            Console.ReadKey();
        }

        private static void UnhandledException()
        {
            var ints = new[] {1, 2, 3, 4, 5};

            PrintArrayElement(ints, 0);
            PrintArrayElement(ints, 1);
            PrintArrayElement(ints, 2);
            PrintArrayElement(ints, 3);
            PrintArrayElement(ints, 4);
            //PrintArrayElement(ints, 5);

            PrintArrayElement(null, 0);
        }

        private static void HandleException()
        {
            var ints = new[] { 1, 2, 3, 4, 5 };

            try
            {
                PrintArrayElement(ints, 0);
                PrintArrayElement(ints, 1);
                PrintArrayElement(ints, 2);
                PrintArrayElement(ints, 3);
                PrintArrayElement(ints, 4);
                //PrintArrayElement(ints, 5);

                PrintArrayElement(null, 0);
            }
            catch (NullReferenceException nullReferenceException) //when(ints.Length > 10)
            {
                Console.WriteLine(nullReferenceException.Message);
            }
            catch (ArgumentOutOfRangeException outOfRangeException)
            {
                Console.WriteLine(outOfRangeException.Message);
            }
            catch (Exception exception)
            {
                //just a general exception
                Console.WriteLine(exception.Message);
            }
            finally
            {
                Console.WriteLine("This block of code is always executed");
            }
        }

        private static void PrintArrayElement(int[] array, int index)
        {
            //if (array == null) throw new ArgumentNullException(nameof(array));

            if (index == 3) throw new MyAwesomeException()
            {
                SomeInt = index
            };

            Console.WriteLine(array[index]);
        }

        class MyAwesomeException : Exception
        {
            public int SomeInt { get; set; }
        }
    }
}
