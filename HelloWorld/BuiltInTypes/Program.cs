using System;

namespace BuiltInTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool
            bool booleanValue = true;
            Console.WriteLine("Bool: "+ booleanValue);

            //bytes
            Console.WriteLine("\r\nBytes");

            byte byteValue1 = 201;          //Decimal
            Console.WriteLine(byteValue1);

            byte byteValue2 = 0x00C9;       // Hexadecimal
            Console.WriteLine(byteValue2);

            byte byteValue3 = 0b1100_1001;  // Binary
            Console.WriteLine(byteValue3);

            //chars
            Console.WriteLine("\r\nChars");
            var chars = new char[4];

            chars[0] = 'X';        // Character literal
            chars[1] = '\x0058';   // Hexadecimal
            chars[2] = (char)88;   // Cast from integral type
            chars[3] = '\u0058';   // Unicode

            foreach (var c in chars)
                Console.Write(c + " ");
            Console.WriteLine();

            //Decimal
            var d = 9.1m;
            Console.WriteLine("\r\nDecimal: " + d);

            //Double
            var w = 1.7E+3;
            Console.WriteLine("\r\nDouble: " + w);

            //Ints
            Console.WriteLine("\r\nInts");
            var intValue1 = 90946;
            Console.WriteLine(intValue1);
            var intValue2 = 0x16342;
            Console.WriteLine(intValue2);
            var intValue3 = 0b0001_0110_0011_0100_0010;
            Console.WriteLine(intValue3);

            //Longs
            Console.WriteLine("\r\nLongs");
            long longValue1 = 4294967296;
            Console.WriteLine(longValue1);

            long longValue2 = 0x100000000;
            Console.WriteLine(longValue2);

            long longValue3 = 0b1_0000_0000_0000_0000_0000_0000_0000_0000;
            Console.WriteLine(longValue3);

            //String
            string a = "good " + "morning";
            Console.WriteLine("\r\nString: " +a);

            //Objects
            Console.WriteLine("\r\nObjects");
            object o;
            o = 1;   // an example of boxing
            Console.WriteLine(o);
            Console.WriteLine(o.GetType());
            Console.WriteLine(o.ToString());

            Console.ReadLine();
        }
    }
}
