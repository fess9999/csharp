using System;
using System.Collections.Generic;
using System.Linq;

namespace Lambdas
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> {4, 6, 42, 7, 1, 8, 54, 3, 6 };

            MethodChains(list);
            //SqlLike(list);
            //LinqToObjects(list);

            Console.ReadLine();
        }

        private static void LinqToObjects(List<int> list)
        {
            var first = list.First(i => i > 1);
            var firstOrDefault = list.FirstOrDefault(i => i < 1);
            var single = list.Single(i => i == 42);
            var singleOrDefault = list.Single(i => i == 55);

            list.ForEach(i => Console.WriteLine(i));

            var groups = list.GroupBy(i => i > 8).ToList();
            var max = list.Max();
            var min = list.Min();
            var takeSkip = list.Skip(2).Take(3).ToList();
            var takeLast = list.TakeLast(4).ToList();
        }

        private static void SqlLike(List<int> list)
        {
            var moreThan4 = from i in list
                where i > 4
                orderby i
                select i;

            var newList = moreThan4.ToList();
        }

        private static void MethodChains(List<int> list)
        {
            var moreThan4 = list.Where(i => i > 4).OrderBy(i => i).ToList();

            var hasAny = list.Any(i => i < 0);
            var hasAll = list.All(i => i > 1);
        }
    }
}
