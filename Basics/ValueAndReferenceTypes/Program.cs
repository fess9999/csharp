using System;

namespace ValueAndReferenceTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            ValueTypesExample();
            RefTypesExample();
            //NullableTypesExample();

            Console.ReadLine();
        }

        private static void NullableTypesExample()
        {
            bool? myBool = null;
            Console.WriteLine(myBool);

            myBool = true;

            if (myBool.HasValue)
                Console.WriteLine(myBool);  

            myBool = GetBoolFromDataBase() ?? false;
            Console.WriteLine(myBool);
        }

        private static bool? GetBoolFromDataBase()
        {
            return null;
        }

        private static void ValueTypesExample()
        {
            int a = 5, b = 9;
            Console.WriteLine($"{a} {b}, {a==b}");

            a = b;
            Console.WriteLine($"{a} {b}, {a==b}");

            a = 4;
            Console.WriteLine($"{a} {b}, {a == b}");
        }

        private static void RefTypesExample()
        {
            MyInt a = new MyInt(5), b = new MyInt(9);
            Console.WriteLine($"{a} {b}, {a == b}");

            a = b;
            Console.WriteLine($"{a} {b}, {a == b}");

            a.Value = 4;
            Console.WriteLine($"{a} {b}, {a == b}");

            a = new MyInt(48);
            Console.WriteLine($"{a} {b}, {a == b}");
        }

        private class MyInt
        {
            public int Value { private get; set; }

            public MyInt(int value)
            {
                Value = value;
            }

            public override string ToString()
            {
                return Value.ToString();
            }
        }
    }
}
