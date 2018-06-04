using System;

namespace Conditions
{
    class Program
    {
        static void Main()
        {
            //IfSample();
            SwitchSample();

            Console.ReadLine();
        }

        private static void SwitchSample()
        {
            Console.WriteLine("Enter any language");

            var language = Console.ReadLine();

            switch (language)
            {
                case "C#": Console.WriteLine("What a nice choice!"); break;
                case "JavaScript": Console.WriteLine("Hmm... Are you sure?"); break;
                case "Java": Console.WriteLine("C'mon. You can't be serious!"); break;
                default: Console.WriteLine("Well... Good luck with that!"); break;
            }
        }

        private static void IfSample()
        {
            var age = 17;
            var name = "Alex";

            if (age == 20)
                Console.WriteLine("Age is 20");
            else
                Console.WriteLine("Age is not 20");

            if (age >= 18)
                Console.WriteLine("Person is allowed to buy alcohol");
            else
                Console.WriteLine("Person is not allowed to buy alcohol");

            if (name == "Alex" && age < 18)
                Console.WriteLine("Alex is under 18 yet");
        }
    }
}
