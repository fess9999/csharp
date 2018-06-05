using System;
using System.Globalization;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Value 1: ");
                var string1 = Console.ReadLine();
                if (string1.ToLower() == "exit") break;

                Console.Write("Value 2: ");
                var string2 = Console.ReadLine();
                if (string2.ToLower() == "exit") break;

                if (decimal.TryParse(string1, out var operand1) 
                    && decimal.TryParse(string2, out var operand2))
                {
                    string result;
                    Console.Write("Operation: ");
                    var operation = Console.ReadLine();

                    switch (operation)
                    {
                        case "-":
                            result = (operand1 - operand2).ToString();
                            break;
                        case "*":
                            result = (operand1 * operand2).ToString();
                            break;
                        case "/":
                            result = operand2 != 0 ? (operand1 / operand2).ToString() : "Division by zero!";
                            break;
                        case "+": result = (operand1 + operand2).ToString();
                            break;
                        default: result = "Unknown operation!"; break;
                    }

                    Console.WriteLine($"Result: {result}");
                }
                else
                    Console.WriteLine("Bad arguments");
            }
        }
    }
}
