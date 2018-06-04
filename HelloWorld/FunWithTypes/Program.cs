using System;

namespace FunWithTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            NumericTypes();
            //CharType();
            //Parse();
            //DateTimeType();
            //TimeSpanType();
            //StringType();

            Console.ReadLine();
        }

        static void StringType()
        {
            var str = "Sapfir";

            Console.WriteLine(str);
            Console.WriteLine(str.Length);
            Console.WriteLine(str.ToUpper());
            Console.WriteLine(str.ToLower());
            Console.WriteLine(str.Contains("sa"));
            Console.WriteLine(str.Replace("fir", "phire"));
        }

        static void TimeSpanType()
        {
            var timeSpan = new TimeSpan(4, 40, 33);

            Console.WriteLine(timeSpan.Minutes);
            Console.WriteLine(timeSpan.TotalMinutes);
        }

        static void DateTimeType()
        {
            var dateTime = new DateTime(2018, 6, 5);
            
            Console.WriteLine(dateTime);
            Console.WriteLine($"Day: {dateTime.Day} Month: {dateTime.Month} Year: {dateTime.Year}");
        }

        static void Parse()
        {
            Console.WriteLine(int.Parse("432423"));
            Console.WriteLine(decimal.Parse("4.43"));
            Console.WriteLine(DateTime.Parse("2018-06-05"));
        }

        static void CharType()
        {
            Console.WriteLine(char.IsDigit('5'));
            Console.WriteLine(char.IsLetter('d'));
            Console.WriteLine(char.IsLetterOrDigit('A'));
            Console.WriteLine(char.IsWhiteSpace(' '));
            Console.WriteLine(char.IsWhiteSpace("Hello there!", 5));
            Console.WriteLine(char.IsPunctuation(','));
        }

        static void NumericTypes()
        {
            Console.WriteLine(int.MaxValue);
            Console.WriteLine(int.MinValue);
            Console.WriteLine(double.MaxValue);
            Console.WriteLine(double.MinValue);
            Console.WriteLine(double.Epsilon);
            Console.WriteLine(double.NegativeInfinity);
            Console.WriteLine(double.PositiveInfinity);
            Console.WriteLine(double.NaN);
        }
    }
}
